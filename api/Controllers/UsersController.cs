using System;
using System.Collections.Generic;
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
                    Surname = "Smith",
                    ImageUrl = "https://www.shareicon.net/data/32x32/2016/01/12/702155_users_512x512.png"
                },
                new DummyUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Firstname = "Jan",
                    Surname = "Kowalski",
                    ImageUrl = "https://www.shareicon.net/data/32x32/2016/07/21/799335_user_512x512.png"
                },
                new DummyUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Firstname = "Jochan",
                    Surname = "Schmidt",
                    ImageUrl = "https://www.shareicon.net/data/32x32/2016/05/24/770116_people_512x512.png"
                },
            };
        }

    }

    public class DummyUser
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
}