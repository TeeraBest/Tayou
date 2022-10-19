using Utac.Api.ViewModels.ApiExternal;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Utac.Api.Helpers
{
    public static class ApiExternalHelper
    {
        public static IEnumerable<MenuResponse> ExecuteAPIFunction(string mainUrl, string url, string appKey, string authKey)
        {
            IEnumerable<MenuResponse> menuList = null;
            try
            {
                url = mainUrl + url;
                var restclient = new RestClient(mainUrl);
                var restRequest = new RestRequest(url, Method.GET) { RequestFormat = DataFormat.Json };
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("app_key", appKey);
                restRequest.AddHeader("auth_key", authKey);

                IRestResponse responseVerify = restclient.Execute(restRequest);
                menuList = JsonConvert.DeserializeObject<IEnumerable<MenuResponse>>(responseVerify.Content);
                
                return menuList;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return menuList;
            }
        }
    }
}