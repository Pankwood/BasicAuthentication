#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System.Web.Mvc;
#endregion

namespace WebAPIBasicAuth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
