using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Trill.Services.Ads.Core.Domain;

namespace Trill.Services.Ads.Core.Infrastructure.Repositories
{
    internal sealed class AdRepository : IAdRepository
    {
        private readonly IMongoCollection<Ad> _collection;

        public AdRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Ad>("ads");
        }

        public Task<Ad> GetAsync(Guid id) => _collection.AsQueryable().SingleOrDefaultAsync(x => x.Id == id);

        public Task AddAsync(Ad ad) => _collection.InsertOneAsync(ad);

        public Task UpdateAsync(Ad ad) => _collection.ReplaceOneAsync(x => x.Id == ad.Id, ad);
    }
}