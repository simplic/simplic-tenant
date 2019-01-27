using System;
using System.Collections.Generic;

namespace Simplic.TenantSystem
{
    /// <summary>
    /// Represents an organization
    /// </summary>
    public class Organization : IEquatable<Organization>
    {
        /// <summary>
        /// Gets or sets the organization id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the organization name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the match code
        /// </summary>
        public string MatchCode { get; set; }

        /// <summary>
        /// Gets or sets whether the organization is selectable
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets the sub organization count
        /// </summary>
        public int SubOrganizationCount { get => SubOrganizations.Count; }

        /// <summary>
        /// Gets or sets all sub items. Only available if this organization is a group of multiple organizations
        /// </summary>
        public IList<Guid> SubOrganizations { get; set; } = new List<Guid>();

        /// <summary>
        /// Gets or sets whether the organization is a group
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
        public static bool operator !=(Organization obj1, Organization obj2)
        {
            return obj1?.Id != obj2?.Id;
        }

        /// <summary>
        /// == Operator
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator ==(Organization obj1, Organization obj2)
        {
            return obj1?.Id == obj2?.Id;
        }

        /// <summary>
        /// Compare by id
        /// </summary>
        /// <param name="obj">organization</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Organization organization)
                return organization.Id == Id;

            return false;
        }

        /// <summary>
        /// Compare by id
        /// </summary>
        /// <param name="other">Other organization</param>
        /// <returns>True if equal</returns>
        public bool Equals(Organization other)
        {
            return other?.Id == Id;
        }
    }
}
