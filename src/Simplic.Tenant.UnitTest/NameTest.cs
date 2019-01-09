using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplic.Tenant.Data.Memory;
using Simplic.Tenant.Service;
using Unity;

namespace Simplic.Tenant.UnitTest
{
    [TestClass]
    public class NameTest
    {
        private IUnityContainer unityContainer;

        public NameTest()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IOrganizationTenantRepository, OrganizationTenantRepository>();
            unityContainer.RegisterType<IOrganizationTenantService, OrganizationTenantService>();
        }

        [TestMethod]
        public void NameOrderTest()
        {
            var tenants = new OrganizationTenant[]
            {
                new OrganizationTenant { Name = "Tenant 1", MatchCode = "T1" },
                new OrganizationTenant { Name = "Tenant 2", MatchCode = "T2" },
                new OrganizationTenant { Name = "Tenant 3", MatchCode = "T3" }
            };

            var service = unityContainer.Resolve<IOrganizationTenantService>();

            var id = service.CreateOrGetGroup(tenants);
            var group = service.Get(id);

            Assert.AreEqual(group.Name, "Tenant 1;Tenant 2;Tenant 3");
        }

        [TestMethod]
        public void MatchCodeOrderTest()
        {
            var tenants = new OrganizationTenant[]
            {
                new OrganizationTenant { Name = "Tenant 1", MatchCode = "T1" },
                new OrganizationTenant { Name = "Tenant 2", MatchCode = "T2" },
                new OrganizationTenant { Name = "Tenant 3", MatchCode = "T3" }
            };

            var service = unityContainer.Resolve<IOrganizationTenantService>();

            var id = service.CreateOrGetGroup(tenants);
            var group = service.Get(id);

            Assert.AreEqual(group.MatchCode, "T1;T2;T3");
        }
    }
}
