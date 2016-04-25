#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System;
using System.Linq;
using WebAPIBasicAuth.Models;
#endregion

namespace WebAPIBasicAuth.DAL
{
    public class BranchOfficeDAL
    {
        public static ListBranchOffice ListBranchOffice()
        {
            BranchOffice[] branchOffice = { new BranchOffice { Address = "5th Avenue", District = "Manhattan", City = "New York", State = "NY", Phone = "1 201 55597848" },
                                            new BranchOffice { Address = "Paulista Avenue", District = "Paraiso", City = "Sao Paulo", State = "SP", Phone = "55 11 49713541" }};

            ListBranchOffice listBranchOffice = new ListBranchOffice();
            listBranchOffice.BranchOffice = branchOffice.ToList(); ;

            return listBranchOffice;
        }
    }
}