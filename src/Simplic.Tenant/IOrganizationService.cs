using System;
using System.Collections.Generic;

namespace Simplic.Tenant
{
    /// <summary>
    /// organization service definition
    /// </summary>
    public interface IOrganizationService : IOrganizationRepository
    {
        /// <summary>
        /// Create or get tenant by tenant group
        /// </summary>
        /// <param name="Organizations">List of organizations</param>
        /// <returns>New organization id</returns>
        Guid CreateOrGetGroup(IList<Organization> Organizations);
    }
}
