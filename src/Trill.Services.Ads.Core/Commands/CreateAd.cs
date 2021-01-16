using System;
using System.Collections.Generic;
using System.Linq;
using Convey.CQRS.Commands;

namespace Trill.Services.Ads.Core.Commands
{
    public class CreateAd : ICommand
    {
        public Guid AdId { get; }
        public Guid UserId { get; }
        public string Header { get; }
        public string Content { get; }
        public IEnumerable<string> Tags { get; }
        public DateTime From { get; }
        public DateTime To { get; }

        public CreateAd(Guid adId, Guid userId, string header, string content, IEnumerable<string> tags,
            DateTime from, DateTime to)
        {
            AdId = adId == Guid.Empty ? Guid.NewGuid() : adId;
            UserId = userId;
            Header = header;
            Content = content;
            Tags = tags ?? Enumerable.Empty<string>();
            From = @from;
            To = to;
        }
    }
}