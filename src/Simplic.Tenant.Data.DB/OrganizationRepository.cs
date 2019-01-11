using Simplic.Cache;
using Simplic.Data.Sql;
using Simplic.Sql;
using System;
using System.Collections.Generic;

namespace Simplic.Tenant.Data.DB
{
    /// <summary>
    /// Organization repository with cache
    /// </summary>
    public class OrganizationRepository : SqlRepositoryBase<Guid, Organization>, IOrganizationRepository
    {
        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="sqlService">Sql service</param>
        /// <param name="sqlColumnService">Column service</param>
        /// <param name="cacheService">Cache service</param>
        public OrganizationRepository(ISqlService sqlService, ISqlColumnService sqlColumnService, ICacheService cacheService) : base(sqlService, sqlColumnService, cacheService)
        {
            UseCache = true;
        }

        /// <summary>
        /// Gets the id of a organization organization
        /// </summary>
        /// <param name="obj">Organization id</param>
        /// <returns>Unique id</returns>
        public override Guid GetId(Organization obj)
        {
            return obj.Id;
        }

        /// <summary>
        /// Gets all groups which have n sub items/organizations
        /// </summary>
        /// <param name="count">Sub organization count</param>
        /// <returns>Enumerable of organizations</returns>
        public IEnumerable<Organization> GetGroupsBySubOrganizationCount(int count) => GetAllByColumn("SubOrganizationCount", count);

        /// <summary>
        /// Gets the primary columns (Id)
        /// </summary>
        public override string PrimaryKeyColumn => "Id";

        /// <summary>
        /// Gets the organization organization table (Tenant_Organization)
        /// </summary>
        public override string TableName => "Tenant_Organization";
    }
}
