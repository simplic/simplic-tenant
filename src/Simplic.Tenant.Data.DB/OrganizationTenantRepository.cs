﻿using Simplic.Cache;
using Simplic.Data.Sql;
using Simplic.Sql;
using System;

namespace Simplic.Tenant.Data.DB
{
    /// <summary>
    /// Tenant repository with cache
    /// </summary>
    public class OrganizationTenantRepository : SqlRepositoryBase<Guid, OrganizationTenant>, IOrganizationTenantRepository
    {
        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="sqlService">Sql service</param>
        /// <param name="sqlColumnService">Column service</param>
        /// <param name="cacheService">Cache service</param>
        public OrganizationTenantRepository(ISqlService sqlService, ISqlColumnService sqlColumnService, ICacheService cacheService) : base(sqlService, sqlColumnService, cacheService)
        {
            UseCache = true;
        }

        /// <summary>
        /// Gets the id of a tenant organization
        /// </summary>
        /// <param name="obj">Organization id</param>
        /// <returns>Unique id</returns>
        public override Guid GetId(OrganizationTenant obj)
        {
            return obj.Id;
        }

        /// <summary>
        /// Gets the primary columns (Id)
        /// </summary>
        public override string PrimaryKeyColumn => "Id";

        /// <summary>
        /// Gets the tenant organization table (TenantOrganization)
        /// </summary>
        public override string TableName => "TenantOrganization";
    }
}
