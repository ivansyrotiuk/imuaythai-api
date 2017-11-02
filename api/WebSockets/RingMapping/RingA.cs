using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Data;

namespace MuaythaiSportManagementSystemApi.WebSockets.RingMapping
{
    public class RingA : FightHandler
    {

        public RingA(ApplicationDbContext context, WebSocketConnectionManager connectionManager) : base(context, connectionManager)
        {
            Ring = "A";
        }
    }
}
