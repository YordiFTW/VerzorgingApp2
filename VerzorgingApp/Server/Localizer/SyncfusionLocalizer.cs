﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace VerzorgingApp.Server.Localizer
//{
//    using Syncfusion.Blazor;

//    public class SyncfusionLocalizer : ISyncfusionStringLocalizer
//    {
//        // To get the locale key from mapped resources file
//        public string GetText(string key)
//        {
//            return this.ResourceManager.GetString(key);
//        }

//        // To access the resource file and get the exact value for locale key

//        public System.Resources.ResourceManager ResourceManager
//        {
//            get
//            {
//                // Replace the ApplicationNamespace with your application name.
//                return VerzorgingApp.SfResources.ResourceManager;
//            }
//        }
//    }