[![](https://img.shields.io/nuget/v/soenneker.email.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.email.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.email.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.email.util/actions/workflows/codeql.yml)

# Soenneker.Email.Util

A utility to place emails on Service Bus.

## Install

```bash
dotnet add package Soenneker.Email.Util
```

## Quick start

```csharp
using Soenneker.Email.Util.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddEmailUtilAsSingleton();
```

Adds `IEmailUtil` as a singleton service.

## What you get

- `IEmailUtil` — A utility to place emails on Service Bus.
- `EmailUtilRegistrar` — A utility to place emails on Service Bus.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IEmailUtil.PlaceOnQueue(msgModel, cancellationToken)` | Places on Queue. | A task that completes when the place on queue operation is complete. |
| `EmailUtilRegistrar.AddEmailUtilAsSingleton(services)` | Adds `IEmailUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `EmailUtilRegistrar.AddEmailUtilAsScoped(services)` | Adds `IEmailUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
