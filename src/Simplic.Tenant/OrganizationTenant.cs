using System;
using System.Collections.Generic;

namespace Simplic.Tenant
{
    /// <summary>
    /// Represents an organization tenant
    /// </summary>
    public class OrganizationTenant : IEquatable<OrganizationTenant>
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

        /// <summary>
        /// Gets the hash code of the id
        /// </summary>
        /// <returns>Hashcode</returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// != Operator
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator != (OrganizationTenant obj1, OrganizationTenant obj2)
        {
            return !obj1.Equals(obj2);
        }

        /// <summary>
        /// == Operator
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator == (OrganizationTenant obj1, OrganizationTenant obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Compare by id
        /// </summary>
        /// <param name="obj">Organization tenant</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is OrganizationTenant organizationTenant)
                return organizationTenant.Id == Id;

            return false;
        }

        /// <summary>
        /// Compare by id
        /// </summary>
        /// <param name="other">Other organization tenant</param>
        /// <returns>True if equal</returns>
        public bool Equals(OrganizationTenant other)
        {
            return other?.Id == Id;
        }
    }
}
