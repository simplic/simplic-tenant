using Simplic.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simplic.TenantSystem.Service
{
    /// <summary>
    /// Organization service implementation
    /// </summary>
    public class OrganizationService : IOrganizationService
    {
        private const string ConfigurationName = "OrganizationMode";
        private const string ConfigurationPluginName = "Tenant";
        private readonly IOrganizationRepository organizationRepository;
        private readonly IConfigurationService configurationService;

        /// <summary>
        /// Initialize service
        /// </summary>
        /// <param name="organizationRepository">Repository instance</param>
        /// <param name="configurationService">Configuration service</param>
        public OrganizationService(IOrganizationRepository organizationRepository, IConfigurationService configurationService)
        {
            this.organizationRepository = organizationRepository;
            this.configurationService = configurationService;
        }

        /// <summary>
        /// Delete organization
        /// </summary>
        /// <param name="obj">Object instance</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(Organization obj) => organizationRepository.Delete(obj);

        /// <summary>
        /// Create or get organization by organization group
        /// </summary>
        /// <param name="Organizations">List of organizations</param>
        /// <returns>New organization id</returns>
        public Guid CreateOrGetGroup(IList<Organization> Organizations)
        {
            if (Organizations.Count == 0)
                return Guid.Empty;

            if (Organizations.Count == 1)
                return Organizations[0].Id;

            // Find group
            var existingGroups = GetGroupsBySubOrganizationCount(Organizations.Count).ToList();

            if (existingGroups.Any())
            {
                foreach (var organization in Organizations)
                {
                    existingGroups = existingGroups.Where(x => x.SubOrganizations.Any(y => y == organization.Id)).ToList();
                    if (!existingGroups.Any())
                        break;
                }
            }

            // Return matching group
            if (existingGroups.Count > 0)
                return existingGroups[0].Id;

            var newOrganizationGroup = new Organization
            {
                IsActive = true,
                SubOrganizations = Organizations.Select(x => x.Id).ToList()
            };

            // Set name and matchcode
            newOrganizationGroup.Name = string.Join(";", Organizations.Select(x => x.Name).OrderBy(x => x));
            newOrganizationGroup.MatchCode = string.Join(";", Organizations.Select(x => x.MatchCode).OrderBy(x => x));

            // Save new group
            Save(newOrganizationGroup);

            return newOrganizationGroup.Id;
        }

        /// <summary>
        /// Gets all groups which have n sub items/organizations
        /// </summary>
        /// <param name="count">Sub organization count</param>
        /// <returns>Enumerable of organizations</returns>
        public IEnumerable<Organization> GetGroupsBySubOrganizationCount(int count) => organizationRepository.GetGroupsBySubOrganizationCount(count);

        /// <summary>
        /// Delete organization by id
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <returns>True if successfuk</returns>
        public bool Delete(Guid id) => organizationRepository.Delete(id);

        /// <summary>
        /// Gets an organization by its id
        /// </summary>
        /// <param name="id">Unique organization id</param>
        /// <returns>organization instance</returns>
        public Organization Get(Guid id) => organizationRepository.Get(id);

        /// <summary>
        /// Get all assigned organizations
        /// </summary>
        /// <param name="userId">Unique user id</param>
        /// <returns>Get all tenants that are enabled for the given user</returns>
        public IEnumerable<Organization> GetByUserId(int userId) => organizationRepository.GetByUserId(userId);

        /// <summary>
        /// Get all available organizations
        /// </summary>
        /// <param name="userId">Unique user id</param>
        /// <returns>Enumerable of organizations</returns>
        public IEnumerable<Organization> GetAvailableOrganizations(int userId) => GetByUserId(userId).Where(x => x.IsActive);

        /// <summary>
        /// Get all organizations
        /// </summary>
        /// <returns>Enumerable of organizations</returns>
        public IEnumerable<Organization> GetAll() => organizationRepository.GetAll();

        /// <summary>
        /// Save existing or new organization
        /// </summary>
        /// <param name="obj">organization instance</param>
        /// <returns>True if successfuk</returns>
        public bool Save(Organization obj) => organizationRepository.Save(obj);

        /// <summary>
        /// Gets or sets the organization mode
        /// </summary>
        public OrganizationMode Mode
        {
            get => (OrganizationMode)configurationService.GetValue<int>(ConfigurationName, ConfigurationPluginName, "");
            set => configurationService.SetValue<int>(ConfigurationName, ConfigurationPluginName, "", (int)value);
        }
    }
}
