using System;
using Convey.CQRS.Queries;
using Trill.Services.Ads.Core.DTO;

namespace Trill.Services.Ads.Core.Queries
{
    public class BrowseAds : PagedQueryBase, IQuery<Paged<AdDto>>
    {
        public Guid? UserId { get; set; }
    }
}