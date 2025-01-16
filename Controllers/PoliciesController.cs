using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NdegwaInsuranceApi.Models;
using NdegwaInsuranceApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NdegwaInsuranceApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            var policies = await _policyService.GetAllPoliciesAsync();
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            var policy = await _policyService.GetPolicyByIdAsync(id);
            if (policy == null)
                return NotFound();

            return Ok(policy);
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> CreatePolicy(Policy policy)
        {
            var createdPolicy = await _policyService.CreatePolicyAsync(policy);
            return CreatedAtAction(nameof(GetPolicy), new { id = createdPolicy.Id }, createdPolicy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, Policy policy)
        {
            var updatedPolicy = await _policyService.UpdatePolicyAsync(id, policy);
            if (updatedPolicy == null)
                return NotFound();

            return Ok(updatedPolicy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var result = await _policyService.DeletePolicyAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}