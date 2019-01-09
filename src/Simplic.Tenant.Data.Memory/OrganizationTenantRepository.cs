using System;
using System.Collections.Generic;
using System.Linq;

namespace Simplic.Tenant.Data.Memory
{
    /// <summary>
    /// Organization repository memory implementation
    /// </summary>
    public class OrganizationTenantRepository : IOrganizationTenantRepository
    {
        public IList<OrganizationTenant> tenants;

        /// <summary>
        /// Initialize repository
        /// </summary>
        public OrganizationTenantRepository()
        {
            tenants = new List<OrganizationTenant>();
        }

        /// <summary>
        /// Delete organization tenant
        /// </summary>
        /// <param name="obj">Object instance</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(OrganizationTenant obj)
        {
            return Delete(obj.Id);
        }

        /// <summary>
        /// Delete organization tenant by id
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(Guid id)
        {
            var ot = tenants.FirstOrDefault(x => x.Id == id);
            if (ot != null)
            {
                tenants.Remove(ot);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets an organization tenant by its id
        /// </summary>
        /// <param name="id">Unique organization tenant id</param>
        /// <returns>Organization tenant instance</returns>
        public OrganizationTenant Get(Guid id)
        {
            return tenants.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get all organization tenants
        /// </summary>
        /// <returns>Enumerable of organization tenants</returns>
        public IEnumerable<OrganizationTenant> GetAll()
        {
            return tenants;
        }

        /// <summary>
        /// Gets all groups which have n sub items/tenants
        /// </summary>
        /// <param name="count">Sub tenant count</param>
        /// <returns>Enumerable of organization tenants</returns>
        public IEnumerable<OrganizationTenant> GetGroupsBySubOrganizationCount(int count)
        {
            return tenants.Where(x => x.SubOrganizationCount == count);
        }

        /// <summary>
        /// Save existing or new organization tenant
        /// </summary>
        /// <param name="obj">Organization tenant instance</param>
        /// <returns>True if successfuk</returns>
        public bool Save(OrganizationTenant obj)
        {
            Delete(obj);
            tenants.Add(obj);

            return true;
        }
    }
}
