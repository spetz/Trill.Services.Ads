using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace Trill.Services.Ads.Core
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}