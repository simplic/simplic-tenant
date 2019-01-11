using System;
using System.Collections.Generic;
using System.Linq;

namespace Simplic.Tenant.Data.Memory
{
    /// <summary>
    /// Organization repository memory implementation
    /// </summary>
    public class OrganizationRepository : IOrganizationRepository
    {
        public IList<Organization> organizations;

        /// <summary>
        /// Initialize repository
        /// </summary>
        public OrganizationRepository()
        {
            organizations = new List<Organization>();
        }

        /// <summary>
        /// Delete organization
        /// </summary>
        /// <param name="obj">Object instance</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(Organization obj)
        {
            return Delete(obj.Id);
        }

        /// <summary>
        /// Delete organization by id
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(Guid id)
        {
            var ot = organizations.FirstOrDefault(x => x.Id == id);
            if (ot != null)
            {
                organizations.Remove(ot);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets an organization by its id
        /// </summary>
        /// <param name="id">Unique organization id</param>
        /// <returns>organization instance</returns>
        public Organization Get(Guid id)
        {
            return organizations.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get all organizations
        /// </summary>
        /// <returns>Enumerable of organizations</returns>
        public IEnumerable<Organization> GetAll()
        {
            return organizations;
        }

        /// <summary>
        /// Gets all groups which have n sub items/organizations
        /// </summary>
        /// <param name="count">Sub organization count</param>
        /// <returns>Enumerable of organizations</returns>
        public IEnumerable<Organization> GetGroupsBySubOrganizationCount(int count)
        {
            return organizations.Where(x => x.SubOrganizationCount == count);
        }

        /// <summary>
        /// Save existing or new organization
        /// </summary>
        /// <param name="obj">organization instance</param>
        /// <returns>True if successfuk</returns>
        public bool Save(Organization obj)
        {
            Delete(obj);
            organizations.Add(obj);

            return true;
        }
    }
}
