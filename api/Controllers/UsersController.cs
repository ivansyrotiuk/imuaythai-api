using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        [HttpGet]
        [Route("DummyUsers")]
        public List<DummyUser> GetUsers()
        {
            Thread.Sleep(2000);
            return new List<DummyUser>
            {
                new DummyUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Firstname = "John",
                    Surname = "Smith"
                },
                new DummyUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Firstname = "Jan",
                    Surname = "Kowalski"
                },
                new DummyUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Firstname = "Jochan",
                    Surname = "Schmidt"
                },
            };
        }

    }

    public class DummyUser
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}