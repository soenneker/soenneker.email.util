[![](https://img.shields.io/nuget/v/soenneker.email.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.email.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.email.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.email.util/actions/workflows/codeql.yml)

# Soenneker.Email.Util

Queues an `EmailMessage`—or another `Message` envelope—for asynchronous transmission to Azure Service Bus through `IServiceBusTransmitter`.

## Install

```bash
dotnet add package Soenneker.Email.Util
```

## Configuration

```json
{
  "Azure": {
    "ServiceBus": {
      "Enable": true,
      "ConnectionString": "use-a-secret-provider",
      "TransmitterLogging": false
    }
  }
}
```

`Enable` and `ConnectionString` are required by the registered Service Bus components. Keep the connection string in a secret provider. `TransmitterLogging` is optional and should remain false when message bodies may contain personal or confidential data.

## Registration

```csharp
using Soenneker.Email.Util.Registrars;

services.AddEmailUtilAsSingleton();
```

For a scoped wrapper:

```csharp
services.AddEmailUtilAsScoped();
```

The scoped registration creates `IEmailUtil` and its transmitter per scope while intentionally retaining the background queue, message utility, sender utility, and underlying Service Bus client as shared singleton infrastructure. Ending a scope therefore disposes the wrapper without tearing down and recreating the shared client.

## Queue an email

```csharp
using Soenneker.Email.Util.Abstract;
using Soenneker.Enums.Email.Format;
using Soenneker.Enums.Email.Priority;
using Soenneker.Messages.Email;

var message = new EmailMessage
{
    Type = "email.receipt.v1",
    Id = Guid.NewGuid().ToString("N"),
    Queue = "email",
    Sender = "orders-api",
    CreatedAt = DateTimeOffset.UtcNow,
    To = ["recipient@example.net"],
    Subject = "Your receipt",
    Format = EmailFormat.Html,
    Priority = EmailPriority.Normal,
    ContentFileName = "receipt.html"
};

IEmailUtil email = serviceProvider.GetRequiredService<IEmailUtil>();
await email.PlaceOnQueue(message, cancellationToken);
```

`PlaceOnQueue` uses the transmitter's in-process background queue. Completion means that queue accepted the work item; it does not mean Azure Service Bus accepted the message or that an email was delivered. Transmission failures are handled and logged by the transmitter.

When Service Bus is disabled, the transmitter logs a warning and skips the message. Cancellation can stop work that has not completed, but it cannot retract a message already sent to Service Bus.
