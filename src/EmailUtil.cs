using Soenneker.Email.Util.Abstract;
using Soenneker.Messages.Base;
using Soenneker.ServiceBus.Transmitter.Abstract;
using System.Threading.Tasks;

namespace Soenneker.Email.Util;

///<inheritdoc cref="IEmailUtil"/>
public class EmailUtil : IEmailUtil
{
    private readonly IServiceBusTransmitter _serviceBusTransmitter;

    public EmailUtil(IServiceBusTransmitter serviceBusTransmitter)
    {
        _serviceBusTransmitter = serviceBusTransmitter;
    }

    public ValueTask PlaceOnQueue<T>(T msgModel) where T : Message
    {
        return _serviceBusTransmitter.SendMessage(msgModel);
    }
}