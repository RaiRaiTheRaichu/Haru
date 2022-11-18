﻿using System.Collections.Generic;
using Haru.Models.EFT;
using Haru.Models.EFT.Trader;
using Haru.Utils;

namespace Haru.Server.Databases
{
    public static class TraderDatabase
    {
        public static readonly List<TraderModel> Traders;

        static TraderDatabase()
        {
            Traders = new List<TraderModel>();

            var json = Resource.GetText("db.trading.traders.json");
            var body = Json.Deserialize<ResponseModel<TraderModel[]>>(json);
            Traders.AddRange(body.Data);
        }
    }
}