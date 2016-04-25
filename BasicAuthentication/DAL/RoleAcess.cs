#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System;
#endregion

namespace WebAPIBasicAuth.DAL
{
    public class RoleAcess
    {
        public static bool IsUserInRole(String username, String roleName)
        {
            //Put here the logic to username
            return true;
        }

        public static string[] GetUsers()
        {
            string[] value = {"user1", "user2"};

            return value;
        }

        internal static bool GetUsers(string usuario, string senha)
        {
            //Put here the logic to get the users
            return true;
        }
    }
}