using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Data;

namespace MuaythaiSportManagementSystemApi.WebSockets.RingMapping
{
    public class RingA : FightHandler
    {

        public RingA(WebSocketConnectionManager connectionManager) : base(connectionManager)
        {
            Ring = "A";
        }
    }
}
