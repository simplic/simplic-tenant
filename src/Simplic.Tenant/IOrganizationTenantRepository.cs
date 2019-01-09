using Simplic.Data;
using System;
using System.Collections.Generic;

namespace Simplic.Tenant
{
    /// <summary>
    /// Organization tenant repository definition
    /// </summary>
    public interface IOrganizationTenantRepository : IRepositoryBase<Guid, OrganizationTenant>
    {
        /// <summary>
        /// Gets all groups which have n sub items/tenants
        /// </summary>
        /// <param name="count">Sub tenant count</param>
        /// <returns>Enumerable of organization tenants</returns>
        IEnumerable<OrganizationTenant> GetGroupsBySubOrganizationCount(int count);
    }
}
