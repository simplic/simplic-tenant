using System;
using System.Collections.Generic;
using System.Linq;

namespace Simplic.Tenant.Service
{
    /// <summary>
    /// Organization tenant service implementation
    /// </summary>
    public class OrganizationTenantService : IOrganizationTenantService
    {
        private readonly IOrganizationTenantRepository tenantRepository;

        /// <summary>
        /// Initialize service
        /// </summary>
        /// <param name="tenantRepository">Repository instance</param>
        public OrganizationTenantService(IOrganizationTenantRepository tenantRepository)
        {
            this.tenantRepository = tenantRepository;
        }

        /// <summary>
        /// Delete organization tenant
        /// </summary>
        /// <param name="obj">Object instance</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(OrganizationTenant obj) => tenantRepository.Delete(obj);

        /// <summary>
        /// Create or get tenant by tenant group
        /// </summary>
        /// <param name="organizationTenants">List of organization tenants</param>
        /// <returns>New organization tenant id</returns>
        public Guid CreateOrGetGroup(IList<OrganizationTenant> organizationTenants)
        {
            if (organizationTenants.Count == 0)
                return Guid.Empty;

            if (organizationTenants.Count == 1)
                return organizationTenants[0].Id;

            // Find group
            var existingGroups = GetGroupsBySubOrganizationCount(organizationTenants.Count).ToList();
            foreach (var tenant in organizationTenants)
                existingGroups = existingGroups.Where(x => x.SubOrganizations.Any(y => y == tenant.Id)).ToList();

            // Return matching group
            if (existingGroups.Count > 0)
                return existingGroups[0].Id;

            var newOrganizationTenantGroup = new OrganizationTenant
            {
                SubOrganizations = organizationTenants.Select(x => x.Id).ToList()
            };

            // Save new group
            Save(newOrganizationTenantGroup);

            return newOrganizationTenantGroup.Id;
        }

        /// <summary>
        /// Gets all groups which have n sub items/tenants
        /// </summary>
        /// <param name="count">Sub tenant count</param>
        /// <returns>Enumerable of organization tenants</returns>
        public IEnumerable<OrganizationTenant> GetGroupsBySubOrganizationCount(int count) => tenantRepository.GetGroupsBySubOrganizationCount(count);

        /// <summary>
        /// Delete organization tenant by id
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(Guid id) => tenantRepository.Delete(id);

        /// <summary>
        /// Gets an organization tenant by its id
        /// </summary>
        /// <param name="id">Unique organization tenant id</param>
        /// <returns>Organization tenant instance</returns>
        public OrganizationTenant Get(Guid id) => tenantRepository.Get(id);

        /// <summary>
        /// Get all organization tenants
        /// </summary>
        /// <returns>Enumerable of organization tenants</returns>
        public IEnumerable<OrganizationTenant> GetAll() => tenantRepository.GetAll();

        /// <summary>
        /// Save existing or new organization tenant
        /// </summary>
        /// <param name="obj">Organization tenant instance</param>
        /// <returns>True if successfuk</returns>
        public bool Save(OrganizationTenant obj) => tenantRepository.Save(obj);
    }
}
