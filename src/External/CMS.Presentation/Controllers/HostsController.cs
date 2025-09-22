using CMS.Application.Abstraction.Services;
using CMS.Presentation.Controllers.DTOs.Requests;
using CMS.Presentation.Controllers.DTOs.Responses;
using CMS.Presentation.Controllers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace CMS.Presentation.Controllers
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

            return Ok();
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<HostVM>> GetHostAsync(Guid id)
        {
            var theHost = await _cmsService.GetHostAsync(id);

            return Ok(theHost.ToVM());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HostVM>>> GetHostsAsync([FromQuery] int pageSize, [FromQuery] int pageNum)
        {
            var hosts = await _cmsService.GetHostsAsync(new Pagination
            {
                Number = pageNum,
                Size = pageSize,
            });

            return Ok(hosts.Select(x => x.ToVM()));
        }

        [HttpPatch("{hostId:Guid}")]
        public async Task<ActionResult> UpdateHostAsync(Guid hostId, [FromBody] JsonPatchRequest<PropertyPatchRequest> body)
        {
            var properties = typeof(PropertyPatchRequest).GetProperties();

            var patches = properties
                .IntersectBy(body.PatchedProperties, p => p.Name)
                .ToDictionary(p => p.Name, p => p.GetValue(body.Data));

            //var patches = body.ToDictionary(x => x.Name, x => (object?)x.Number.GetString());

            await _cmsService.PatchUpdateAsync(hostId, patches);

            return Ok();
        }




        [HttpPost("{id:Guid}/Generate")]
        public async Task<ActionResult> GenerateHostAsync(Guid id)
        {
            await _cmsService.GenerateHostAsync(id);

            return Created();
        }
    }

}
