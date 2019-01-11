using Simplic.Tenant;
using Simplic.UI.MVC;
using System.Collections.Generic;
using System.Linq;

namespace Simplic.Studio.Tenant.UI
{
    /// <summary>
    /// Selector viewmodel
    /// </summary>
    public class UserSessionOrganizationSelectorViewModel : ViewModelBase
    {
        private Organization selectedOrganization;
        private readonly IOrganizationService organizationService;

        /// <summary>
        /// Initialize viewmodel
        /// </summary>
        public UserSessionOrganizationSelectorViewModel()
        {
            organizationService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IOrganizationService>();

            // TODO: Only load organizations that are allowed for the current user
            Organizations = new List<Organization>(organizationService.GetAll().Where(x => !x.IsGroup));
        }

        /// <summary>
        /// Gets or sets a list of available organizations
        /// </summary>
        public IList<Organization> Organizations { get; set; }
        
        /// <summary>
        /// Gets or sets the selected organization
        /// </summary>
        public Organization SelectedOrganization
        {
            get => selectedOrganization;
            set
            {
                selectedOrganization = value;
                RaisePropertyChanged(nameof(SelectedOrganization));
            }
        }
    }
}
