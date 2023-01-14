﻿using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Trader;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class TraderSettingsController : Controller
    {
        private readonly TraderService _traderService;

        public TraderSettingsController()
        {
            _traderService = new TraderService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/trading/api/traderSettings";
        }

        public override void Run(RouterContext context)
        {
            var data = _traderService.GetTraders();
            var body = new ResponseModel<TraderModel[]>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}