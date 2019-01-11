using System.Windows.Controls;

namespace Simplic.Studio.Tenant.UI
{
    /// <summary>
    /// Interaction logic for UserSessionOrganizationSelector.xaml
    /// </summary>
    public partial class UserSessionOrganizationSelector : UserControl
    {
        /// <summary>
        /// Initialize selector
        /// </summary>
        public UserSessionOrganizationSelector()
        {
            InitializeComponent();

            DataContext = new UserSessionOrganizationSelectorViewModel();
        }
    }
}
