using System;
using System.Collections.Generic;

namespace Simplic.Tenant
{
    /// <summary>
    /// Represents an organization tenant
    /// </summary>
    public class OrganizationTenant
    {
        /// <summary>
        /// Gets or sets the organization tenant id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets the sub organization count
        /// </summary>
        public int SubOrganizationCount { get => SubOrganizations.Count; }

        /// <summary>
        /// Gets or sets all sub items. Only available if this organization tenant is a group of multiple organization tenants
        /// </summary>
        public IList<Guid> SubOrganizations { get; set; } = new List<Guid>();
    }
}
