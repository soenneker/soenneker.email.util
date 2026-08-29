using Soenneker.Messages.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Util.Abstract;

/// <summary>
/// A utility to place emails on Service Bus
/// </summary>
public interface IEmailUtil
{
    /// <summary>
    /// Places on Queue.
    /// </summary>
    /// <typeparam name="T">Type of value handled by the email.</typeparam>
    /// <param name="msgModel">Msg Model for the place on queue operation.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the place on queue operation is complete.</returns>
    ValueTask PlaceOnQueue<T>(T msgModel, CancellationToken cancellationToken = default) where T : Message;
}
