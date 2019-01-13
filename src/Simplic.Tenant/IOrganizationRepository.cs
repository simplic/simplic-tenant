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

        /// <summary>
        /// Get all assigned organizations
        /// </summary>
        /// <param name="userId">Unique user id</param>
        /// <returns>Get all tenants that are enabled for the given user</returns>
        IEnumerable<Organization> GetByUserId(int userId);
    }
}
