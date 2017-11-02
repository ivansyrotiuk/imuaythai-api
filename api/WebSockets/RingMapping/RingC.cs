using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Data;

namespace MuaythaiSportManagementSystemApi.WebSockets.RingMapping
{
    public class RingC : FightHandler
    {
        public RingC(WebSocketConnectionManager connectionManager) : base(connectionManager)
        {
            Ring = "C";
        }
    }
}
