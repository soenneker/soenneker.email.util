using Soenneker.Messages.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Util.Abstract;

/// <summary>
/// A utility to place emails on Service Bus
/// </summary>
public interface IEmailUtil
{
    ValueTask PlaceOnQueue<T>(T msgModel, CancellationToken cancellationToken = default) where T : Message;
}
