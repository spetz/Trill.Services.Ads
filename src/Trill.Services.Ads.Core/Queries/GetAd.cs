using System;
using Convey.CQRS.Queries;
using Trill.Services.Ads.Core.DTO;

namespace Trill.Services.Ads.Core.Queries
{
    public class GetAd : IQuery<AdDetailsDto>
    {
        public Guid AdId { get; set; }
    }
}