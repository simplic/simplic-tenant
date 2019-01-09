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
        /// Gets or sets the organization tenant name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the match code
        /// </summary>
        public string MatchCode { get; set; }

        /// <summary>
        /// Gets or sets whether the organization tenant is selectable
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets the sub organization count
        /// </summary>
        public int SubOrganizationCount { get => SubOrganizations.Count; }

        /// <summary>
        /// Gets or sets all sub items. Only available if this organization tenant is a group of multiple organization tenants
        /// </summary>
        public IList<Guid> SubOrganizations { get; set; } = new List<Guid>();

        /// <summary>
        /// Gets or sets whether the organization tenant is a group
        /// </summary>
        public bool IsGroup { get => SubOrganizationCount > 0; }
    }
}
