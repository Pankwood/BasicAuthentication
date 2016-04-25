using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using ClientAuth.Models;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace ClientAuth.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario User)
        {
            /* Pode ser feito pela classe Web Client ou HTTPClient

            /*
            WebClient client = new WebClient();

            string authInfo = Convert.ToBase64String(Encoding.ASCII.GetBytes(User.CPF + ":" + User.Senha));
            client.Headers[HttpRequestHeader.Authorization] = "Basic " + authInfo;
            
            try
            {
               ViewBag.Result = client.DownloadString("http://localhost:1810/api/Filial/673b5bfd-396e-4179-8g52-1f5d97aba3bd");
               return View();
            }
            catch (WebException e) //Se não autenticou, retorna status code 401 - Unauthorized
            {
                if (e.Response != null)
                {
                    ViewBag.Result = ((System.Net.HttpWebResponse)(e.Response)).StatusCode;
                }
                else
                {
                    ViewBag.Result = HttpStatusCode.ServiceUnavailable;
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Result = e.Message;
                return View();
            }
            */


            //Fornece uma classe base para o envio de solicitações HTTP e receber respostas de HTTP a partir de um recurso identificado por um URI.
            HttpClient client = new HttpClient();

            //Necessário Usuário e Senha para fazer o request
            string authInfo = User.CPF + ":" + User.Senha;

            //Codifica para Base64
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

            //Insere no Header o autorização Basic + Codigo Base64
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

            //Chama a API
            client.BaseAddress = new Uri("http://localhost:1810/");
            HttpResponseMessage response = client.GetAsync("api/Filial/c0e93a74-ee02-4689-a222-6b3fa592975f").Result;

            //Se foi autenticado e não outro tipo de erro, a API é consumida. 
            if (response.IsSuccessStatusCode)
            {
                ListaFilial obj = JsonConvert.DeserializeObject<ListaFilial>(response.Content.ReadAsStringAsync().Result);
                ListaFilial[] data = new ListaFilial[1];

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                ViewBag.Result = json;
                var model = response.Content;
                return View();
            }
            else //Se não autenticou, retorna status code 401 - Unauthorized
            {
                ViewBag.Result = response.StatusCode;
                return View();
            }
        }

     
    }

}