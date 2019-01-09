using System;
using System.Collections.Generic;

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
