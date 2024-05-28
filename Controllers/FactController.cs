using Assel.DTO;
using Assel.Handlers;
using Assel.Services;
using Assel.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace Assel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactController : ControllerBase
    {
        private readonly IFactService _factService;
        private readonly IEventBus _eventBus;

        public FactController(IFactService factService, IEventBus eventBus)
        {
            _factService = factService;
            _eventBus = eventBus;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactDto>>> Get()
        {
            return Ok(await _factService.GetAll());
        }

        [HttpPost("schedule-import")]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(new ImportDataEvent(), cancellationToken);
            return NoContent();
        }
    }
}
