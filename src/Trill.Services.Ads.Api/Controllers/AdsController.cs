using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Trill.Services.Ads.Core;
using Trill.Services.Ads.Core.Commands;
using Trill.Services.Ads.Core.DTO;
using Trill.Services.Ads.Core.Queries;

namespace Trill.Services.Ads.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public AdsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<Paged<AdDto>>> Get([FromQuery] BrowseAds query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return Ok(result);
        }

        [HttpGet("{adId}")]
        public async Task<ActionResult<Paged<AdDto>>> Get([FromRoute] GetAd query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateAd command)
        {
            await _commandDispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPut("{adId}/approve")]
        public async Task<ActionResult> Approve(ApproveAd command)
        {
            await _commandDispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPut("{adId}/reject")]
        public async Task<ActionResult> Reject(RejectAd command)
        {
            await _commandDispatcher.SendAsync(command);
            return NoContent();
        }
        
        [HttpPut("{adId}/pay")]
        public async Task<ActionResult> Pay(PayAd command)
        {
            await _commandDispatcher.SendAsync(command);
            return NoContent();
        }
        
        [HttpPut("{adId}/publish")]
        public async Task<ActionResult> Publish(PublishAd command)
        {
            await _commandDispatcher.SendAsync(command);
            return NoContent();
        }
    }
}