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
    public class NameTest
    {
        private IUnityContainer unityContainer;

        public NameTest()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<ISessionService, SessionMock>();
            unityContainer.RegisterType<IConfigurationService, ConfigurationMock>();

            unityContainer.RegisterType<IOrganizationRepository, OrganizationRepository>();
            unityContainer.RegisterType<IOrganizationService, OrganizationService>();
        }

        [TestMethod]
        public void NameOrderTest()
        {
            var tenants = new Organization[]
            {
                new Organization { Name = "Tenant 1", MatchCode = "T1" },
                new Organization { Name = "Tenant 2", MatchCode = "T2" },
                new Organization { Name = "Tenant 3", MatchCode = "T3" }
            };

            var service = unityContainer.Resolve<IOrganizationService>();

            var id = service.CreateOrGetGroup(tenants);
            var group = service.Get(id);

            Assert.AreEqual(group.Name, "Tenant 1;Tenant 2;Tenant 3");
        }

        [TestMethod]
        public void MatchCodeOrderTest()
        {
            var tenants = new Organization[]
            {
                new Organization { Name = "Tenant 1", MatchCode = "T1" },
                new Organization { Name = "Tenant 2", MatchCode = "T2" },
                new Organization { Name = "Tenant 3", MatchCode = "T3" }
            };

            var service = unityContainer.Resolve<IOrganizationService>();

            var id = service.CreateOrGetGroup(tenants);
            var group = service.Get(id);

            Assert.AreEqual(group.MatchCode, "T1;T2;T3");
        }
    }
}
