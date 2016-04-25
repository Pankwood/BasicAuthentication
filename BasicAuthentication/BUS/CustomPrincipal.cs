#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using WebAPIBasicAuth.DAL;
#endregion

namespace WebAPIBasicAuth.BUS
{
    //Um objeto principal representa o contexto de segurança do usuário, incluindo a identidade do usuário (IIdentity) e todas as funções que a pertencerem.
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        private RolePrincipal Roles;

        public string[] GetUsers()
        {
            return RoleAcess.GetUsers();
        }

        public bool GetUsers(string usuario, string senha)
        {
            return RoleAcess.GetUsers(usuario, senha);
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public CustomPrincipal(string login, RolePrincipal roles)
        {
            this.Identity = new GenericIdentity(login);
            this.Roles = roles;
        }
    } 
}