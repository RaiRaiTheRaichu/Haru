﻿using Haru.Models.EFT.Hideout;
using Haru.Databases;

namespace Haru.Repositories
{
    public class HideoutRepository
    {
        private readonly Database _database;

        public HideoutRepository()
        {
            _database = Database.Instance;
        }

        public SettingsModel GetSettings()
        {
            return _database.HideoutSettings;
        }

        public ScavcaseModel[] GetScavcases()
        {
            return _database.Scavcases.ToArray();
        }
    }
}