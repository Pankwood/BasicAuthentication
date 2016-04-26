# BasicAuthentication
Basic Authentication being consumed for Asp.NET Web API Application.

<h2>Short Description</h2>

<p>It is defined in <a href="http://www.ietf.org/rfc/rfc2617.txt">RFC 2617, HTTP Authentication: Basic and Digest Access Authentication</a>.</p>

<table>
<tbody><tr>
<th>Advantages</th>
<th>Disadvantages</th>
</tr><tr>
</tr><tr>
<td>
  <ul>
    <li>Internet standard.</li>
    <li>Supported by all major browsers.</li>
    <li>Relatively simple protocol.</li>
  <ul>
</ul></ul></td>


<td>
  <ul>
    <li>User credentials are sent in the request.</li>
    <li>Credentials are sent as plaintext.</li>  
    <li>Credentials are sent with every request.</li>
    <li>No way to log out, except by ending the browser session.</li>
    <li>Vulnerable to cross-site request forgery (CSRF); requires anti-CSRF measures.</li>
  </ul> 
</td>
</tr> 
</tbody></table>

<p>Basic authentication works as follows:</p>

<p>If a request requires authentication, the server returns 401 (Unauthorized). The response includes a WWW-Authenticate header, indicating the server supports Basic authentication.
The client sends another request, with the client credentials in the Authorization header. The credentials are formatted as the string “name:password”, base64-encoded. The credentials are not encrypted.
Basic authentication is performed within the context of a “realm.” The server includes the name of the realm in the WWW-Authenticate header. The user’s credentials are valid within that realm. The exact scope of a realm is defined by the server. For example, you might define several realms in order to partition resources.</p>

<p><sub>See more <a href="http://www.asp.net/web-api/overview/security/basic-authentication">here</a>.</sub></p>

<h2>How To Use</h2>

You can consume Basic Authentication using <b>WebCliente</b> library:


<pre><code>
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
</code>
</pre>  

<p>Or using <b>HTTPClient</b>:</p>

<pre><code>

HttpClient client = new HttpClient();

string authInfo = User.CPF + ":" + User.Senha;

authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

client.BaseAddress = new Uri("http://localhost:1810/");
HttpResponseMessage response = client.GetAsync("api/Filial/c0e93a74-ee02-4689-a222-6b3fa592975f").Result;

if (response.IsSuccessStatusCode)
{
    ListaFilial obj = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
    ListaFilial[] data = new ListaFilial[1];

    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

    ViewBag.Result = json;
    var model = response.Content;
    return View();
}
else 
{
    ViewBag.Result = response.StatusCode;
    return View();
}
</code>
</pre>  

<p>In own project, we created a Controller called BranchOfficeController that uses the authentication. </p>
