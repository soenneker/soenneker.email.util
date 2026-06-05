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
    /// Executes the place on queue operation.
    /// </summary>
    /// <typeparam name="T">The T type.</typeparam>
    /// <param name="msgModel">The msg model.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask PlaceOnQueue<T>(T msgModel, CancellationToken cancellationToken = default) where T : Message;
}
