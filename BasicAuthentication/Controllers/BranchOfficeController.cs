#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIBasicAuth.BUS;
using WebAPIBasicAuth.DAL;
using WebAPIBasicAuth.Models;
#endregion

namespace WebAPIBasicAuth.Controllers
{
    [CustomAuthorize(Roles = "BranchOffice")]
    public class BranchOfficeController : ApiController
    {
        public HttpResponseMessage GetAllBranchOffice(String Token)
        {
            try
            {
                ListBranchOffice listBranchOffice = new ListBranchOffice();

                listBranchOffice = BranchOfficeDAL.ListBranchOffice("0");
                return Request.CreateResponse(HttpStatusCode.OK, listBranchOffice);
            }
            catch (HttpResponseException ex)
            {
                return ex.Response;
            }
            catch (InvalidCastException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }
    }
}
