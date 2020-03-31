using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplic.Configuration;
using Simplic.Session;
using Simplic.Tenant.UnitTest.Mocking;
using Simplic.TenantSystem.Data.Memory;
using Simplic.TenantSystem.Service;
using Unity;

namespace Simplic.TenantSystem.UnitTest
{
    [TestClass]
    public class GroupTest
    {
        private IUnityContainer unityContainer;

        public GroupTest()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<ISessionService, SessionMock>();
            unityContainer.RegisterType<IConfigurationService, ConfigurationMock>();

            unityContainer.RegisterType<IOrganizationRepository, OrganizationRepository>();
            unityContainer.RegisterType<IOrganizationService, OrganizationService>();
        }

        [TestMethod]
        public void Group_Empty()
        {
            var service = unityContainer.Resolve<IOrganizationService>();
            var id = service.CreateOrGetGroup(new Organization[] { });

            Assert.AreEqual(id, Guid.Empty);
        }

        [TestMethod]
        public void Group_1Item()
        {
            var tenantId = Guid.NewGuid();

            var service = unityContainer.Resolve<IOrganizationService>();
            var id = service.CreateOrGetGroup(new Organization[] 
            {
                new Organization { Id = tenantId }
            });

            Assert.AreEqual(id, tenantId);
        }

        [TestMethod]
        public void Group_3Items()
        {
            var tenants = new Organization[]
            {
                new Organization { Name = "Tenant 1", MatchCode = "T1" },
                new Organization { Name = "Tenant 2", MatchCode = "T2" },
                new Organization { Name = "Tenant 3", MatchCode = "T3" }
            };

            var service = unityContainer.Resolve<IOrganizationService>();

            var id1 = service.CreateOrGetGroup(tenants);
            var id2 = service.CreateOrGetGroup(tenants);

            Assert.AreEqual(id1, id2);
        }

        [TestMethod]
        public void Group_3_3_Items_Unequal()
        {
            var tenants1 = new Organization[]
            {
                new Organization { Name = "Tenant 1", MatchCode = "T1" },
                new Organization { Name = "Tenant 2", MatchCode = "T2" },
                new Organization { Name = "Tenant 3", MatchCode = "T3" }
            };

            var tenants2 = new Organization[]
            {
                new Organization { Name = "Tenant 4", MatchCode = "T4" },
                new Organization { Name = "Tenant 5", MatchCode = "T5" },
                new Organization { Name = "Tenant 6", MatchCode = "T6" }
            };

            var service = unityContainer.Resolve<IOrganizationService>();

            var id1 = service.CreateOrGetGroup(tenants1);
            var id2 = service.CreateOrGetGroup(tenants2);

            Assert.AreNotEqual(id1, id2);
        }

        [TestMethod]
        public void Group_3_2_Items_Unequal()
        {
            var tenants1 = new Organization[]
            {
                new Organization { Name = "Tenant 1", MatchCode = "T1" },
                new Organization { Name = "Tenant 2", MatchCode = "T2" },
                new Organization { Name = "Tenant 3", MatchCode = "T3" }
            };

            var tenants2 = new Organization[]
            {
                tenants1[0], tenants1[1]
            };

            var service = unityContainer.Resolve<IOrganizationService>();

            var id1 = service.CreateOrGetGroup(tenants1);
            var id2 = service.CreateOrGetGroup(tenants2);

            Assert.AreNotEqual(id1, id2);
        }

        [TestMethod]
        public void Group_2_3_Items_Unequal()
        {
            var tenants1 = new Organization[]
            {
                new Organization { Name = "Tenant 1", MatchCode = "T1" },
                new Organization { Name = "Tenant 2", MatchCode = "T2" },
                new Organization { Name = "Tenant 3", MatchCode = "T3" }
            };

            var tenants2 = new Organization[]
            {
                tenants1[0], tenants1[1]
            };

            var service = unityContainer.Resolve<IOrganizationService>();

            // 2 than 1 (2 -> 3)
            var id2 = service.CreateOrGetGroup(tenants2);
            var id1 = service.CreateOrGetGroup(tenants1);

            Assert.AreNotEqual(id1, id2);
        }
    }
}
