using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simplic.TenantSystem.UnitTest
{
    [TestClass]
    public class TenantEqualTest
    {
        [TestMethod]
        public void EqualById()
        {
            var id = Guid.NewGuid();
            var t1 = new TenantSystem.Organization { Id = id };
            var t2 = new TenantSystem.Organization { Id = id };

            Assert.AreEqual(t1, t2);
            Assert.IsTrue(t1 == t2);
            Assert.IsFalse(t1 != t2);
        }
    }
}
