using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Utac.Api.Extensions
{
    public static class HttpRequestMessageExtensions
    {

        /// <summary>
        /// Returns a dictionary of QueryStrings that's easier to work with 
        /// than GetQueryNameValuePairs KevValuePairs collection.
        /// 
        /// If you need to pull a few single values use GetQueryString instead.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetQueryStrings(this HttpRequestMessage request)
        {
            return request.GetQueryNameValuePairs()
                          .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns an individual querystring value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetQueryString(this HttpRequestMessage request, string key)
        {
            // IEnumerable<KeyValuePair<string,string>> - right!
            var queryStrings = request.GetQueryNameValuePairs();
            if (queryStrings == null)
                return null;

            var match = queryStrings.FirstOrDefault(kv => string.Compare(kv.Key, key, true) == 0);
            if (string.IsNullOrEmpty(match.Value))
                return null;

            return match.Value;
        }

        /// <summary>
        /// Returns an individual HTTP Header value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHeader(this HttpRequestMessage request, string key)
        {
            IEnumerable<string> keys = null;
            if (!request.Headers.TryGetValues(key, out keys))
                return null;

            return keys.First();
        }

        /// <summary>
        /// Retrieves an individual cookie from the cookies collection
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static string GetCookie(this HttpRequestMessage request, string cookieName)
        {
            CookieHeaderValue cookie = request.Headers.GetCookies(cookieName).FirstOrDefault();
            if (cookie != null)
                return cookie[cookieName].Value;

            return null;
        }

        public static string GetClientIPAddress(this HttpRequestMessage request)
        {
            try
            {
                //if (request.Properties.ContainsKey("MS_HttpContext"))
                //{
                //    //return  
                //    string ip = "";
                //    var AddressList = Dns.GetHostEntry(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostName).AddressList;
                //    foreach (var Address in AddressList)
                //    {
                //        switch (Address.AddressFamily)
                //        {
                //            case System.Net.Sockets.AddressFamily.InterNetwork:
                //                // we have IPv4
                //                ip = Address.ToString();
                //                break;
                //            case System.Net.Sockets.AddressFamily.InterNetworkV6:
                //                // we have IPv6
                //                break;
                //            default:
                //                // umm... yeah... I'm going to need to take your red packet and...
                //                break;
                //        }
                //    }
                //    return ip;
                //}

                bool GetLan = false;
                string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (String.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (string.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

                if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
                {
                    GetLan = true;
                    visitorIPAddress = string.Empty;
                }

                if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
                {
                    //This is for Local(LAN) Connected ID Address
                    string stringHostName = System.Net.Dns.GetHostName();

                    visitorIPAddress = System.Net.Dns.GetHostByName(stringHostName).AddressList[0].ToString();
                }

                return visitorIPAddress;


                //return HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
          
            return null;
        }

        public static string GetClientWorkStation(this HttpRequestMessage request)
        {
            try
            {
                bool GetLan = false;
                string computerName = null;
                string visitorIPAddress = HttpContext.Current.Request.UserHostName;
                if (!String.IsNullOrEmpty(visitorIPAddress))
                {
                    IPAddress myIP = IPAddress.Parse(visitorIPAddress);
                    if (myIP != null)
                    {
                        IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                        if (GetIPHost != null)
                        {
                            List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                            computerName = compName.First();
                        }                       
                    }                                                              
                }

                if (string.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (String.IsNullOrEmpty(visitorIPAddress))
                    visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
              
                if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
                {
                    GetLan = true;
                    visitorIPAddress = string.Empty;
                }

                if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
                {
                    //This is for Local(LAN) Connected ID Address
                    string stringHostName = System.Net.Dns.GetHostName();
                    computerName = System.Net.Dns.GetHostName();
                    visitorIPAddress = System.Net.Dns.GetHostByName(stringHostName).AddressList[0].ToString();
                }

                return (string.IsNullOrEmpty(computerName))? visitorIPAddress : computerName;

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

            return null;
        }


        public static string GetClientUserAgent(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserAgent;
            }
            //if (request.Properties.ContainsKey("MS_OwinContext"))
            //{
            //    return IPAddress.Parse(((OwinContext)request.Properties["MS_OwinContext"]).Request.RemoteIpAddress).ToString();
            //}
            return null;
        }

        public static string GetClientHostName(this HttpRequestMessage request)
        {
            try
            {
                //if (request.Properties.ContainsKey("MS_HttpContext"))
                //{
                //    return Dns.GetHostEntry(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostName).HostName;
                //}
                //return string.Empty;
                return HttpContext.Current.Request.UserHostName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}