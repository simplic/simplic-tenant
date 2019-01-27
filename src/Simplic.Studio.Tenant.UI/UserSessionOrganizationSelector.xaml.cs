using System.Windows;
using System.Windows.Controls;

namespace Simplic.Studio.TenantSystem.UI
{
    /// <summary>
    /// Interaction logic for UserSessionOrganizationSelector.xaml
    /// </summary>
    public partial class UserSessionOrganizationSelector : UserControl
    {
        public static readonly DependencyProperty UserIdProperty =
                    DependencyProperty.Register("UserId", typeof(int), typeof(UserSessionOrganizationSelector), new PropertyMetadata(-1, UserIdChangedCallback));

        /// <summary>
        /// User id changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void UserIdChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = ((UserSessionOrganizationSelector)d);
            control.DataContext = new UserSessionOrganizationSelectorViewModel((int)e.NewValue);
        }

        /// <summary>
        /// Initialize selector
        /// </summary>
        public UserSessionOrganizationSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the current user id
        /// </summary>
        public int UserId
        {
            get { return (int)GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }
    }
}
