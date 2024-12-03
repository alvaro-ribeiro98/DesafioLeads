using DesafioLeads.Models;
using DesafioLeads.Repositories.Interaface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLeads.Controllers
{
    [Route("api/lead")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepository _leadRepository;

        public LeadController(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        [HttpGet("invited")]
        public async Task<ActionResult<List<Lead>>> GetInvitedLeads()
        {
            return Ok(await _leadRepository.GetInvitedLeads());
        }

        [HttpGet("accepted")]
        public async Task<ActionResult<List<Lead>>> GetAcceptedLeads()
        {
            return Ok(await _leadRepository.GetAcceptedLeads());
        }

        [HttpPost("accept")]
        public async Task<ActionResult<List<Lead>>> AcceptedLead([FromBody] int leadId)
        {
            return Ok(await _leadRepository.AcceptedLead(leadId));
        }

        [HttpPost("decline")]
        public async Task<ActionResult<List<Lead>>> DeclinedLead([FromBody] int leadId)
        {
            return Ok(await _leadRepository.DeclinedLead(leadId));
        }
    }
}
