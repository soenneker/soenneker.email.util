using Soenneker.Messages.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Util.Abstract;

/// <summary>
/// Queues message envelopes for transmission to Azure Service Bus.
/// </summary>
public interface IEmailUtil
{
    /// <summary>
    /// Places a message on the transmitter's in-process background queue for later delivery to Azure Service Bus.
    /// </summary>
    /// <typeparam name="T">Message envelope type.</typeparam>
    /// <param name="msgModel">Message to queue.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the background queue accepts the work item.</returns>
    ValueTask PlaceOnQueue<T>(T msgModel, CancellationToken cancellationToken = default) where T : Message;
}
