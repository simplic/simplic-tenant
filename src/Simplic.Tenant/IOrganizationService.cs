using System;
using System.Collections.Generic;

namespace Simplic.TenantSystem
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

        /// <summary>
        /// Get all available organizations
        /// </summary>
        /// <param name="userId">Unique user id</param>
        /// <returns>Enumerable of organizations</returns>
        IEnumerable<Organization> GetAvailableOrganizations(int userId);

        /// <summary>
        /// Gets or sets the organization mode
        /// </summary>
        OrganizationMode Mode { get; set; }
    }
}
