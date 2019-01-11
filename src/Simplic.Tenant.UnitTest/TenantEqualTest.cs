using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simplic.Tenant.UnitTest
{
    [TestClass]
    public class TenantEqualTest
    {
        [TestMethod]
        public void EqualById()
        {
            var id = Guid.NewGuid();
            var t1 = new Tenant.Organization { Id = id };
            var t2 = new Tenant.Organization { Id = id };

            Assert.AreEqual(t1, t2);
            Assert.IsTrue(t1 == t2);
            Assert.IsFalse(t1 != t2);
        }
    }
}
