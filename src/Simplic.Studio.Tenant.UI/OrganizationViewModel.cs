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
        public int subOrganizationCount;
        public IList<Guid> subOrganizations;
        public Guid? cloudOrganizationId;
        private Organization model;
        private bool isCreate;

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="org"></param>
        public OrganizationViewModel(Organization org)
        {
            this.model = org;
            this.IsCreate = false;
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
                    if (organizationService.Save(Model))
                    {
                        IsCreate = false;
                        return true;
                    }
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
