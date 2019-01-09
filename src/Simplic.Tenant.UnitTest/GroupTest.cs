using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplic.Tenant.Data.Memory;
using Simplic.Tenant.Service;
using Unity;

namespace Simplic.Tenant.UnitTest
{
    [TestClass]
    public class GroupTest
    {
        private IUnityContainer unityContainer;

        public GroupTest()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IOrganizationTenantRepository, OrganizationTenantRepository>();
            unityContainer.RegisterType<IOrganizationTenantService, OrganizationTenantService>();
        }

        [TestMethod]
        public void Group_Empty()
        {
            var service = unityContainer.Resolve<IOrganizationTenantService>();
            var id = service.CreateOrGetGroup(new OrganizationTenant[] { });

            Assert.AreEqual(id, Guid.Empty);
        }

        [TestMethod]
        public void Group_1Item()
        {
            var tenantId = Guid.NewGuid();

            var service = unityContainer.Resolve<IOrganizationTenantService>();
            var id = service.CreateOrGetGroup(new OrganizationTenant[] 
            {
                new OrganizationTenant { Id = tenantId }
            });

            Assert.AreEqual(id, tenantId);
        }

        [TestMethod]
        public void Group_3Items()
        {
            var tenants = new OrganizationTenant[]
            {
                new OrganizationTenant { Name = "Tenant 1", MatchCode = "T1" },
                new OrganizationTenant { Name = "Tenant 2", MatchCode = "T2" },
                new OrganizationTenant { Name = "Tenant 3", MatchCode = "T3" }
            };

            var service = unityContainer.Resolve<IOrganizationTenantService>();

            var id1 = service.CreateOrGetGroup(tenants);
            var id2 = service.CreateOrGetGroup(tenants);

            Assert.AreEqual(id1, id2);
        }

        [TestMethod]
        public void Group_3_3_Items_Unequal()
        {
            var tenants1 = new OrganizationTenant[]
            {
                new OrganizationTenant { Name = "Tenant 1", MatchCode = "T1" },
                new OrganizationTenant { Name = "Tenant 2", MatchCode = "T2" },
                new OrganizationTenant { Name = "Tenant 3", MatchCode = "T3" }
            };

            var tenants2 = new OrganizationTenant[]
            {
                new OrganizationTenant { Name = "Tenant 4", MatchCode = "T4" },
                new OrganizationTenant { Name = "Tenant 5", MatchCode = "T5" },
                new OrganizationTenant { Name = "Tenant 6", MatchCode = "T6" }
            };

            var service = unityContainer.Resolve<IOrganizationTenantService>();

            var id1 = service.CreateOrGetGroup(tenants1);
            var id2 = service.CreateOrGetGroup(tenants2);

            Assert.AreNotEqual(id1, id2);
        }

        [TestMethod]
        public void Group_3_2_Items_Unequal()
        {
            var tenants1 = new OrganizationTenant[]
            {
                new OrganizationTenant { Name = "Tenant 1", MatchCode = "T1" },
                new OrganizationTenant { Name = "Tenant 2", MatchCode = "T2" },
                new OrganizationTenant { Name = "Tenant 3", MatchCode = "T3" }
            };

            var tenants2 = new OrganizationTenant[]
            {
                tenants1[0], tenants1[1]
            };

            var service = unityContainer.Resolve<IOrganizationTenantService>();

            var id1 = service.CreateOrGetGroup(tenants1);
            var id2 = service.CreateOrGetGroup(tenants2);

            Assert.AreNotEqual(id1, id2);
        }

        [TestMethod]
        public void Group_2_3_Items_Unequal()
        {
            var tenants1 = new OrganizationTenant[]
            {
                new OrganizationTenant { Name = "Tenant 1", MatchCode = "T1" },
                new OrganizationTenant { Name = "Tenant 2", MatchCode = "T2" },
                new OrganizationTenant { Name = "Tenant 3", MatchCode = "T3" }
            };

            var tenants2 = new OrganizationTenant[]
            {
                tenants1[0], tenants1[1]
            };

            var service = unityContainer.Resolve<IOrganizationTenantService>();

            // 2 than 1 (2 -> 3)
            var id2 = service.CreateOrGetGroup(tenants2);
            var id1 = service.CreateOrGetGroup(tenants1);

            Assert.AreNotEqual(id1, id2);
        }
    }
}
