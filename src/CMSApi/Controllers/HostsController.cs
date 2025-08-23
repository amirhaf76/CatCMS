using CMSApi.Abstraction.Services;
using CMSApi.Abstraction.Services.DTOs;
using CMSApi.Controllers.Extensions;
using Infrastructure.GeneratedAPIs.CMSAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
            var hosts = await _cmsService.GetHostsAsync(new PaginationDto
            {
                Number = pageNum,
                Size = pageSize,
            });

            return Ok(hosts.Select(x => x.ToVM()));
        }

        [HttpPatch("{hostId:Guid}")]
        public async Task<ActionResult> UpdateHostAsync(Guid hostId, [FromBody] JsonPatchRequest<PropertyPatch> body)
        {


            var properties = typeof(PropertyPatch).GetProperties();

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
            var filesInformation = await _cmsService.GenerateHostAsync(id);
            
            return Created();
        }
    }

}
