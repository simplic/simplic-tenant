using Simplic.TenantSystem;
using Simplic.UI.MVC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Simplic.Studio.TenantSystem.UI
{
    /// <summary>
    /// OrganizationViewModel to handle tenant data.
    /// </summary>
    public class OrganizationViewModel : ViewModelBase
    {
        private IOrganizationService organizationService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IOrganizationService>();
        private ObservableCollection<Organization> organizations;
        public int subOrganizationCount;
        public IList<Guid> subOrganizations;
        public Guid? cloudOrganizationId;
        private Organization model;
        private bool isCreate;

        /// <summary>
        /// Default constructor for the view model
        /// </summary>
        public OrganizationViewModel()
        {
            Organizations = new ObservableCollection<Organization>();

            foreach (var organization in organizationService.GetAll())
            {
                Organizations.Add(organization);
            }

            this.IsCreate = true;
        }

        /// <summary>
        /// Constructor for the view model
        /// </summary>
        /// <param name="id">Tenant ID</param>
        /// <param name="name">Tenant name</param>
        /// <param name="matchCode">Tenant match code</param>
        /// <param name="subOrganizationCount">Tenant suborganizations count</param>
        /// <param name="subOrganizations">Tenant suborganizations IDs collection</param>
        /// <param name="cloudOrganizationId">Tenant cloud organization id</param>
        /// <param name="isActive">Tenant active flag</param>
        /// <param name="isGroup">Tenant group flag</param>
        public OrganizationViewModel(Guid id, string name, string matchCode, int subOrganizationCount,
            IList<Guid> subOrganizations, Guid? cloudOrganizationId, bool isActive, bool isGroup) : this()
        {
            if (this.Model == null)
            {
                this.model = new Organization
                {
                    Id = id,
                    Name = name,
                    MatchCode = matchCode,
                    IsActive = isActive,
                    SubOrganizations = subOrganizations,
                    CloudOrganizationId = cloudOrganizationId
                };

                IsCreate = true;
            }

        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="org"></param>
        public OrganizationViewModel(Organization org) : this(org.Id, org.Name, org.MatchCode, org.SubOrganizationCount,
            org.SubOrganizations, org.CloudOrganizationId, org.IsActive, org.IsGroup)
        {
            this.model = org;
            this.IsCreate = false;
        }

        /// <summary>
        /// Gets all user assigned organizations.
        /// </summary>
        /// <param name="user">Selected user.</param>
        /// <returns>List of all user assigned organizations.</returns>
        public IEnumerable<Organization> GetUserOrganizations(User.User user)
        {
            return organizationService.GetByUserId(user.Ident);
        }

        /// <summary>
        /// Saves <see cref="Organization"/> instance.
        /// </summary>
        /// <returns>Wether the safe was succesfull.</returns>
        public bool SaveOrganization()
        {
            if (Model != null)
            {
                if (IsCreate)
                {
                    var newTenant = new Organization
                    {
                        Id = Model.Id,
                        Name = Model.Name,
                        MatchCode = Model.MatchCode,
                        IsActive = Model.IsActive,
                        SubOrganizations = Model.SubOrganizations,
                        CloudOrganizationId = Model.CloudOrganizationId
                    };

                    IsCreate = false;

                    if (organizationService.Save(newTenant))
                        return true;
                }

                if (organizationService.Save(Model))
                    return true;
            }
            return false;
        }

        #region Properties
        /// <summary>
        /// Gets the base model for <see cref="Organization"/>.
        /// </summary>
        public Organization Model
        {
            get => model;
        }

        /// <summary>
        /// Tenant organization id
        /// </summary>
        public Guid OrganizationId
        {
            get => Model.Id;
            set
            {
                if (!Equals(Model.Id, value))
                {
                    PropertySetter(value, newValue => { Model.Id = value; });
                }
            }
        }

        /// <summary>
        /// Tenant name
        /// </summary>
        public string Name
        {
            get => Model.Name;
            set
            {
                if (!Equals(Model.Name, value))
                {
                    PropertySetter(value, newValue => { Model.Name = value; });
                }
            }
        }

        /// <summary>
        /// Tenant match code
        /// </summary>
        public string MatchCode
        {
            get => Model.MatchCode;
            set
            {
                if (!Equals(Model.MatchCode, value))
                {
                    PropertySetter(value, newValue => { Model.MatchCode = value; });
                }
            }
        }

        /// <summary>
        /// Tenant active flag
        /// </summary>
        public bool IsActive
        {
            get => Model.IsActive;
            set
            {
                if (!Equals(Model.IsActive, value))
                {
                    PropertySetter(value, newValue => { Model.IsActive = value; });
                }
            }
        }

        /// <summary>
        /// Tenant suborganizations IDs collection
        /// </summary>
        public IList<Guid> SubOrganizations
        {
            get => Model.SubOrganizations;
            set
            {
                if (!Equals(Model.SubOrganizations, value))
                {
                    PropertySetter<IList<Guid>>(value, newValue => { Model.SubOrganizations = value; });
                }
            }
        }

        /// <summary>
        /// Tenant group flag
        /// </summary>
        public bool IsGroup
        {
            get => Model.IsGroup;
        }

        /// <summary>
        /// Tenant is create flag.
        /// </summary>
        public bool IsCreate
        {
            get => isCreate;
            set
            {
                PropertySetter(value, newValue => { isCreate = newValue; });
            }
        }

        /// <summary>
        /// Contains all avialable organizations.
        /// </summary>
        public ObservableCollection<Organization> Organizations
        {
            get => organizations;
            set
            {
                if (!Equals(value, organizations))
                {
                    PropertySetter(value, newValue => { organizations = newValue; });
                }
            }
        }

        /// <summary>
        /// Tenant suborganizations count
        /// </summary>
        public int SubOrganizationCount
        {
            get => Model.SubOrganizationCount;
        }

        /// <summary>
        /// Tenant cloud organization id
        /// </summary>
        public Guid? CloudOrganizationId
        {
            get => Model.CloudOrganizationId;
            set
            {
                if (!Equals(Model.CloudOrganizationId, value))
                {
                    PropertySetter(value, newValue => { CloudOrganizationId = value; });
                }
            }
        }
        #endregion
    }
}
