using Simplic.Framework.DBUI;
using Simplic.TenantSystem;
using System.Linq;

namespace Simplic.Studio.TenantSystem.UI
{
    public class ApplicationHelper
    {
        private static readonly IOrganizationService organizationService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IOrganizationService>();

        /// <summary>
        /// Opens <see cref="OrganizationDetailsView"/> to create a new organization.
        /// </summary>
        public static GridInvokeMethodResult NewOrganization(GridFunctionParameter parameter)
        {
            var win = new OrganizationDetailsView();

            if (win.ShowDialog() == true)
            {
                return new GridInvokeMethodResult
                {
                    RefreshGrid = true,
                    Window = win
                };
            };

            return new GridInvokeMethodResult
            {
                RefreshGrid = false,
                Window = win
            };
        }

        /// <summary>
        /// Opens <see cref="OrganizationDetailsView"/> to edit a organization.
        /// </summary>
        public static GridInvokeMethodResult EditOrganization(GridFunctionParameter parameter)
        {
            var win = new OrganizationDetailsView();

            win.Edit(parameter.GetSelectedRowsAsDataRow().Select(item => organizationService.GetByName((string)item["Name"])).ToList());

            if (win.ShowDialog() == true)
            {
                return new GridInvokeMethodResult
                {
                    RefreshGrid = true,
                    Window = win
                };
            };

            return new GridInvokeMethodResult
            {
                RefreshGrid = false,
                Window = win
            };
        }

        /// <summary>
        /// Deletes (deactivates) a organization.
        /// </summary>
        public static GridInvokeMethodResult DeleteOrganization(GridFunctionParameter parameter)
        {
            var organizationsToDelete = parameter.GetSelectedRowsAsDataRow().Select(item => organizationService.GetByName((string)item["Name"])).ToList();

            foreach (var org in organizationsToDelete)
            {
                organizationService.Delete(org);
            }

            return new GridInvokeMethodResult
            {
                RefreshGrid = true
            };
        }
    }
}
