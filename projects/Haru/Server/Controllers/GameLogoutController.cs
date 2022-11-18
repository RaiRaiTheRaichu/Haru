﻿using System.Threading.Tasks;
using Haru.Models;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class GameLogoutController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/game/logout";
        }

        public override async Task Run(RouterContext context)
        {
            var body = RequestHelper.GetEmptyResponse();
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}