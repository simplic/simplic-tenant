using Simplic.Data;
using System;
using System.Collections.Generic;

namespace Simplic.Tenant
{
    /// <summary>
    /// organization repository definition
    /// </summary>
    public interface IOrganizationRepository : IRepositoryBase<Guid, Organization>
    {
        /// <summary>
        /// Gets all groups which have n sub items/tenants
        /// </summary>
        /// <param name="count">Sub tenant count</param>
        /// <returns>Enumerable of organizations</returns>
        IEnumerable<Organization> GetGroupsBySubOrganizationCount(int count);
    }
}
