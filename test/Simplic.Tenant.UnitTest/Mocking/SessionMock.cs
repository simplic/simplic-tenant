using Simplic.Session;
using System;

namespace Simplic.Tenant.UnitTest.Mocking
{
    class SessionMock : ISessionService
    {
        public Session.Session CurrentSession
        {
            get => new Session.Session
            {
                UserName = "Test",
                IsADUser = false,
                IsSuperUser = false,
                UserId = 0
            }; set { }
        }
    }
}
