using System;
using System.Collections.Generic;

namespace Simplic.Tenant
{
    /// <summary>
    /// Organization tenant service definition
    /// </summary>
    public interface IOrganizationTenantService : IOrganizationTenantRepository
    {
        /// <summary>
        /// Create or get tenant by tenant group
        /// </summary>
        /// <param name="organizationTenants">List of organization tenants</param>
        /// <returns>New organization tenant id</returns>
        Guid CreateOrGetGroup(IList<OrganizationTenant> organizationTenants);
    }
}
