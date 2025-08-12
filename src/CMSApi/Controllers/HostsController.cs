using CMSApi.Abstraction.Services;
using CMSApi.Controllers.Extensions;
using Infrastructure.GenericRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMSApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [Authorize]
    public class HostsController : Controller
    {
        private readonly ICMSService _cmsService;
        private readonly ILogger<HostsController> _logger;



        public HostsController(ILogger<HostsController> logger, ICMSService cmsService)
        {
            _logger = logger;
            _cmsService = cmsService;
        }



        [HttpPost]
        public async Task<ActionResult<HostVM>> CreateHostAsync([FromBody] HostCreationRequest request)
        {
            var host = await _cmsService.AddHostAsync(request.Title);

            return Ok(host.ToVM());
        }

        [HttpDelete()]
        public async Task<ActionResult> RemoveHostAsync([FromBody] Guid id)
        {
            await _cmsService.RemoveHostAsync(id);

            return Accepted();
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<HostVM>> GetHostAsync(Guid id)
        {
            var theHost = await _cmsService.GetHostWithItsCreatorAsync(id);

            return Ok(theHost.ToVM());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HostVM>>> GetHostsAsync([FromQuery] int pageSize, [FromQuery] int pageNum)
        {
            var hosts = await _cmsService.GetHostsWithItsCreatorAsync(new Pagination
            {
                Number = pageNum,
                Size = pageSize,
            });

            return Ok(hosts.Select(x => x.ToVM()));
        }

        [HttpPut]
        public ActionResult UpdateHost()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}/settings")]
        public ActionResult UpdateSettings()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}/settings")]
        public ActionResult GetSettings(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id:Guid}/Generate")]
        public async Task<ActionResult<string[]>> GenerateHostAsync(Guid id)
        {
            var filesInformation = await _cmsService.GenerateHostAsync(id);

            return Ok(filesInformation.Select(x => x.FullName));
        }
    }

}
