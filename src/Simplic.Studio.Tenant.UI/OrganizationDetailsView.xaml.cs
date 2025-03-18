using Simplic.Framework.UI;
using Simplic.TenantSystem;
using System.Collections.Generic;
using System.Linq;

namespace Simplic.Studio.TenantSystem.UI
{
    /// <summary>
    /// OrganizationDetailsView for creating and editing<see cref="Organization"/> instances.
    /// </summary>
    public partial class OrganizationDetailsView : DefaultRibbonWindow
    {
        private IOrganizationService organizationService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IOrganizationService>();

        /// <summary>
        /// Constructor for OrganizationDetailsView.
        /// </summary>
        public OrganizationDetailsView()
        {
            InitializeComponent();

            AllowSave = false;
            AllowDelete = false;
            AllowPaging = true;

            WindowMode = WindowMode.New;

            var obj = new Organization();
            AddPagingObject(obj);
            this.DataContext = new OrganizationViewModel(obj);
        }

        /// <summary>
        /// Returns current data context as <see cref="OrganizationViewModel"/>.
        /// </summary>
        public OrganizationViewModel Current
        {
            get
            {
                return DataContext as OrganizationViewModel;
            }
        }

        /// <summary>
        /// Sets title and data context for current organization.
        /// </summary>
        public override void OnOpenPage(WindowOpenPageEventArg e)
        {
            this.DataContext = new OrganizationViewModel((Organization)e.CurrentObject);

            if (!string.IsNullOrEmpty(Current.Name))
            {
                this.Title = Current.Name;
            }

            base.OnOpenPage(e);
        }

        /// <summary>
        /// Saves <see cref="Organization"/> instance.
        /// </summary>
        public override void OnSave(WindowSaveEventArg e)
        {
            if (Current.SaveOrganization())
                base.OnSave(e);
        }

        /// <summary>
        /// Deletes <see cref="Organization"/> instance.
        /// </summary>
        public override void OnDelete(WindowDeleteEventArg e)
        {
            if (organizationService.Delete(Current.Model))
                base.OnDelete(e);
        }

        /// <summary>
        /// Edits <see cref="Organization"/> instance.
        /// </summary>
        /// <param name="models">PagingObjects</param>
        public void Edit(IList<Organization> models)
        {
            PagingObjects.Clear();

            foreach (var model in models)
            {
                AddPagingObject(model);
            }

            WindowMode = WindowMode.Edit;

            if (models.Count > 0)
                this.DataContext = new OrganizationViewModel(models.FirstOrDefault());
        }
    }
}
