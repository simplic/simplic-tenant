using CommonServiceLocator;
using Simplic.Session;
using Simplic.TenantSystem;
using Simplic.UI.MVC;
using System.Collections.Generic;
using System.Linq;

namespace Simplic.Studio.TenantSystem.UI
{
    /// <summary>
    /// Selector viewmodel
    /// </summary>
    public class UserSessionOrganizationSelectorViewModel : ViewModelBase
    {
        private Organization selectedOrganization;
        private readonly IOrganizationService organizationService;
        private readonly ISessionService sessionService;

        /// <summary>
        /// Initialize viewmodel
        /// </summary>
        /// <param name="userId">User id</param>
        public UserSessionOrganizationSelectorViewModel(int userId)
        {
            organizationService = ServiceLocator.Current.GetInstance<IOrganizationService>();
            sessionService = ServiceLocator.Current.GetInstance<ISessionService>();

            // TODO: Only load organizations that are allowed for the current user
            Organizations = new List<Organization>(organizationService.GetAvailableOrganizations(userId).Where(x => !x.IsGroup));
            selectedOrganization = Organizations.FirstOrDefault();
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

                sessionService.CurrentSession.Organizations = new List<Organization>
                {
                    selectedOrganization
                };
            }
        }
    }
}
