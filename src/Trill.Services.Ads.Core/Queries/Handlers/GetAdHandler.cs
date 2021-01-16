using System.Threading.Tasks;
using Convey.CQRS.Queries;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Trill.Services.Ads.Core.Domain;
using Trill.Services.Ads.Core.DTO;

namespace Trill.Services.Ads.Core.Queries.Handlers
{
    public class GetAdHandler : IQueryHandler<GetAd, AdDetailsDto>
    {
        private readonly IMongoDatabase _database;

        public GetAdHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<AdDetailsDto> HandleAsync(GetAd query)
        {
            var ad = await _database.GetCollection<Ad>("ads")
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == query.AdId);

            return ad is null
                ? null
                : new AdDetailsDto
                {
                    Id = ad.Id,
                    UserId = ad.UserId,
                    Header = ad.Header,
                    Content = ad.Content,
                    Tags = ad.Tags,
                    State = ad.State.ToString().ToLowerInvariant(),
                    From = ad.From,
                    To = ad.To,
                    CreatedAt = ad.CreatedAt,
                    ApprovedAt = ad.ApprovedAt,
                    RejectedAt = ad.RejectedAt,
                    PaidAt = ad.PaidAt,
                    PublishedAt = ad.PublishedAt,
                    Amount = ad.Amount
                };
        }
    }
}