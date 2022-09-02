﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FishingGame.ContentManagement
{
    public static class ContentAddresses
    {
        private const string _PREFABS = "Prefabs/";
        
        public static class Prefabs
        {
            private const string _GUI = "GUI/";
            
            public static class GUI
            {
                public const string MAIN_MENU_CANVAS = _PREFABS + _GUI + "MainMenuCanvas";
            }
        }
        
        public static IEnumerable<string> GetAssetAddressesInType(in Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .Select(x => (string) x.GetRawConstantValue())
                .ToArray();
        }

        public static int GetAssetCountInType(in Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .Select(x => (string)x.GetRawConstantValue())
                .ToArray().Length;
        }

        public static IEnumerable<Addressable> ToAddressables(this IEnumerable<string> addresses)
        {
            return addresses.Select(address => new Addressable { Address = address }).ToList();
        }
    }
}