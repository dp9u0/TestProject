﻿#region

using System.Web.Mvc;

#endregion

namespace LinqTocnblogs {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}