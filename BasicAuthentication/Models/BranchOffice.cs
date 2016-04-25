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
using System.Web;
#endregion

namespace WebAPIBasicAuth.Models
{
    public class BranchOffice
    {
        public String Phone { get; set; }
        public String Address { get; set; }
        public String District { get; set; }
        public String State { get; set; }
        public String City { get; set; }
    }

    public class ListBranchOffice
    {
        public List<BranchOffice> BranchOffice { get; set; }
    }
}