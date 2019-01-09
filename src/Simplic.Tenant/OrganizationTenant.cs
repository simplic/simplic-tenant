using System;

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
    }
}
