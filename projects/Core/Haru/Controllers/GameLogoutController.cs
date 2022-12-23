﻿using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Framework.Utils;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class GameLogoutController : Controller
    {
        private readonly ControllerHelper _controllerHelper;
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;

        public GameLogoutController()
        {
            _controllerHelper = new ControllerHelper();
            _requestHelper = new RequestHelper();
            _json = new Json();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/logout";
        }

        public override async Task Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyResponse();
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}