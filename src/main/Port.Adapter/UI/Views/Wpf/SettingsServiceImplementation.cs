﻿using System;
using works.ei8.Cortex.Diary.Application.Settings;

namespace works.ei8.Cortex.Diary.Port.Adapter.UI.Views.Wpf
{
    public class SettingsServiceImplementation : ISettingsServiceImplementation
    {
        public bool AddOrUpdateValue(string key, bool value)
        {
            throw new NotImplementedException();
        }

        public bool AddOrUpdateValue(string key, string value)
        {
            throw new NotImplementedException();
        }

        public bool GetValueOrDefault(string key, bool defaultValue)
        {
            throw new NotImplementedException();
        }

        public string GetValueOrDefault(string key, string defaultValue)
        {
            var result = string.Empty;

            switch (key)
            {
                case "avatar_endpoint":
                    result = "http://192.168.8.102:59826/example/";
                    break;
                default:
                    break;
            }

            return result;
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
