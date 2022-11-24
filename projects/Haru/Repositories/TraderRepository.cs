﻿using Haru.Models.EFT.Trader;
using Haru.Databases;

namespace Haru.Repositories
{
    public class TraderRepository
    {
        private readonly Database _database;

        public TraderRepository()
        {
            _database = Database.Instance;
        }

        public TraderModel[] GetTraders()
        {
            return _database.Traders.ToArray();
        }
    }
}