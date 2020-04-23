using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Limdo.Web.App.HttpService
{
    public static class HttpClientProvider
    {


        public static HttpClient HttpClient
        {
            get
            {
                return new HttpClient
                {
                    //BaseAddress = new Uri("https://localhost:44344/api/")
                    BaseAddress = new Uri("https://localhost:44344/api/")
                };
            }
        }
    }

}
