using MowerEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MowerEngine.MowerActionHandlers
{
    public static class MowerActionHandlerFactory
    {

        private static Dictionary<MowerAction, MowerActionHandlerBase> handlers = new Dictionary<MowerAction, MowerActionHandlerBase>()
        {
            { MowerAction.L, new MowerActionHandlerL() },
            { MowerAction.R, new MowerActionHandlerR() },
            { MowerAction.F, new MowerActionHandlerF() }
        };
        public static MowerActionHandlerBase GetMowerActionHandler(MowerAction mowerAction)=>handlers[mowerAction];
    }
}
