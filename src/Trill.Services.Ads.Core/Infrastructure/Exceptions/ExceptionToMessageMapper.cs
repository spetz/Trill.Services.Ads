using System;
using Convey.MessageBrokers.RabbitMQ;
using Trill.Services.Ads.Core.Domain.Exceptions;
using Trill.Services.Ads.Core.Events;

namespace Trill.Services.Ads.Core.Infrastructure.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch
            {
                DomainException ex => new AdActionRejected(ex.Message, ex.GetExceptionCode()),
                _ => new AdActionRejected("There was an error", "ad_error")
            };
    }
}

