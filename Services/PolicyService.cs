using Microsoft.EntityFrameworkCore;
using NdegwaInsuranceApi.Data;
using NdegwaInsuranceApi.Models;
using NdegwaInsuranceApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NdegwaInsuranceApi.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly ApplicationDbContext _context;

        public PolicyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllPoliciesAsync()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies.FindAsync(id);
        }

        public async Task<Policy> CreatePolicyAsync(Policy policy)
        {
            policy.CreatedAt = DateTime.UtcNow;
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return policy;
        }

        public async Task<Policy> UpdatePolicyAsync(int id, Policy policy)
        {
            var existingPolicy = await _context.Policies.FindAsync(id);
            if (existingPolicy == null)
                return null;

            existingPolicy.PolicyHolderName = policy.PolicyHolderName;
            existingPolicy.PolicyType = policy.PolicyType;
            existingPolicy.Premium = policy.Premium;
            existingPolicy.StartDate = policy.StartDate;
            existingPolicy.EndDate = policy.EndDate;
            existingPolicy.IsActive = policy.IsActive;
            existingPolicy.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingPolicy;
        }

        public async Task<bool> DeletePolicyAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null)
                return false;

            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}