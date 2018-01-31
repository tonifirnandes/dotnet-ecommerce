using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Qmall.Areas.Login.Models;

namespace Qmall.Repositories {
    public static class HttpClientRequest {
        private const string URL_SCHEME = "http://localhost:4444";
        // private const string URL_SCHEME = "http://192.168.88.70";
        // private const string URL_SCHEME = "http://192.168.14.230:4444";
        private const string API_KEY = "api_key";
        private const string API_KEY_VALUE = "e4577c7d0efb7cb7b0085f38256b13cab93415bd8222b384aaf3af03840d6326";
        private const string EMAIL = "email";
        private const string SESSION_TOKEN = "sessiontoken";

        public static async Task<HttpResponseMessage> GetAsync (string apiUrl) {
            HttpClient httpClient;
            MediaTypeWithQualityHeaderValue contentHeader;
            HttpResponseMessage httpResponseMessage;

            httpClient = new HttpClient ();
            contentHeader = new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded");
            httpClient.BaseAddress = new Uri (URL_SCHEME);

            httpClient.DefaultRequestHeaders.Accept.Add (contentHeader);
            httpClient.DefaultRequestHeaders.Add (API_KEY, API_KEY_VALUE);
            httpResponseMessage = await httpClient.GetAsync (apiUrl);

            return httpResponseMessage;
        }
        public static async Task<HttpResponseMessage> GetAsyncParam (string apiUrl = null, string parameters = null, string email = null, string customerToken = null) {
            HttpClient httpClient;
            MediaTypeWithQualityHeaderValue contentHeader;
            HttpResponseMessage httpResponseMessage;
            UriBuilder builder;

            httpClient = new HttpClient ();
            contentHeader = new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded");
            httpClient.BaseAddress = new Uri (URL_SCHEME);
            builder = new UriBuilder (URL_SCHEME + apiUrl);
            builder.Query = parameters;

            httpClient.DefaultRequestHeaders.Accept.Add (contentHeader);
            httpClient.DefaultRequestHeaders.Add (API_KEY, API_KEY_VALUE);
            if (!String.IsNullOrEmpty (email) && !String.IsNullOrEmpty (customerToken)) {
                httpClient.DefaultRequestHeaders.Add (EMAIL, email);
                httpClient.DefaultRequestHeaders.Add (SESSION_TOKEN, customerToken);
            }

            httpResponseMessage = await httpClient.GetAsync (builder.Uri);

            return httpResponseMessage;
        }

        public static async Task<HttpResponseMessage> PostAsync (string apiUrl, Dictionary<string, string> param) {
            HttpClient httpClient;
            HttpResponseMessage httpResponseMessage;
            FormUrlEncodedContent encodedContent;
            MediaTypeWithQualityHeaderValue contentHeader;

            httpClient = new HttpClient ();
            contentHeader = new MediaTypeWithQualityHeaderValue ("application/json");
            encodedContent = new FormUrlEncodedContent (param);
            httpClient.BaseAddress = new Uri (URL_SCHEME);

            httpClient.DefaultRequestHeaders.Accept.Add (contentHeader);
            httpClient.DefaultRequestHeaders.Add (API_KEY, API_KEY_VALUE);
            httpResponseMessage = await httpClient.PostAsync (apiUrl, encodedContent);

            return httpResponseMessage;
        }
    }
}