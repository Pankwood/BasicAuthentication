#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System.Web.Security;
using WebAPIBasicAuth.DAL;
#endregion

namespace WebAPIBasicAuth.BUS
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get; set; }

        public override string[] GetRolesForUser(string username)
        {
            return null;
        }

        public override string[] GetAllRoles()
        {
            return null;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return null;
        }

        public override void CreateRole(string roleName)
        { 
        
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return true;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return null;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {

        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        { 
        
        }

        public override bool RoleExists(string roleName)
        {
            return true;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (RoleAcess.IsUserInRole(username, roleName))
                return true;
            else
                return false;
        }
    }
}
