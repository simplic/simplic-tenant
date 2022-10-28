using Dapper;
using Simplic.Cache;
using Simplic.Data.Sql;
using Simplic.Sql;
using System;
using System.Collections.Generic;

namespace Simplic.TenantSystem.Data.DB
{
    /// <summary>
    /// Organization repository with cache
    /// </summary>
    public class OrganizationRepository : SqlRepositoryBase<Guid, Organization>, IOrganizationRepository
    {
        private readonly ISqlService sqlService;

        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="sqlService">Sql service</param>
        /// <param name="sqlColumnService">Column service</param>
        /// <param name="cacheService">Cache service</param>
        public OrganizationRepository(ISqlService sqlService, ISqlColumnService sqlColumnService, ICacheService cacheService) : base(sqlService, sqlColumnService, cacheService)
        {
            UseCache = true;
            this.sqlService = sqlService;
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
        /// Get all assigned organizations
        /// </summary>
        /// <param name="userId">Unique user id</param>
        /// <returns>Get all tenants that are enabled for the given user</returns>
        public IEnumerable<Organization> GetByUserId(int userId)
        {
            return sqlService.OpenConnection((connection) => 
            {
                return connection.Query<Organization>(@"
                        SELECT o.* FROM Tenant_Organization o
                        JOIN Tenant_Organization_User t on t.TenantId = o.Id and t.UserId = :id
                        ORDER BY o.Name
                    ", new { id = userId });
            });
        }

        /// <summary>
        /// Gets all groups which have n sub items/organizations
        /// </summary>
        /// <param name="count">Sub organization count</param>
        /// <returns>Enumerable of organizations</returns>
        public IEnumerable<Organization> GetGroupsBySubOrganizationCount(int count) => GetAllByColumn("SubOrganizationCount", count);

        /// <inheritdoc/>
        public Organization GetByName(string name) => GetByColumn("Name", name);

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
