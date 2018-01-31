using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qmall.Controllers;
using Qmall.Areas.Login.Models;
using System.Net.Http;
using Qmall.Repositories;
using Qmall.Services.RestApi;
using System.Net;
using Newtonsoft.Json;
using Qmall.Extensions;

namespace Qmall.Areas.Login.Controllers
{
    [Area("Login")]
    public class FormController : Controller
    {
        private const string LOGIN_USERNAME_PARAM_KEY = "email";
        private const string LOGIN_CUSTOMER_PASSWORD_PARAM_KEY = "customerPassword";
        private const string USERNAME_ERROR_MSG_KEY = "emailError";
        private const string USERNAME_ERROR_MSG = "User not register, Please register before login.";
        private const string PASSWORD_ERROR_MSG_KEY = "passwordError";
        private const string PASSWORD_ERROR_MSG = "Username and Password not match.";
        private const int LOGIN_API_SUCCESS_CODE = 7000;
        private const int USER_NOT_REGISTERED_LOGIN_API_ERR_CODE = 7001;
        private const string USER_LOGIN_SESSION_KEY = "USER_LOGIN_SESSION";
        private const string PARAMETER_SESSION_PRODUCT_KEY = "PARAMETER_SESSION_PRODUCT";

        public IActionResult Index(string searchingKey = null, string brandId = null)
        {
            ParameterProductsSession tempSessionParam = new ParameterProductsSession();
            tempSessionParam.searchingKey = searchingKey;
            tempSessionParam.brandId = brandId;

            SaveSessionProductsParameter(tempSessionParam);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginFormModel input)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage responseMessage = await HttpClientRequest.PostAsync(ApiEndpoints.Login, ConstructLoginParams(input));

                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    LoginModel responseModel = JsonConvert.DeserializeObject<LoginModel>(
                        await responseMessage.Content.ReadAsStringAsync());

                    if (responseModel.code == LOGIN_API_SUCCESS_CODE)
                    {
                        ParameterProductsSession productsParam = await GetParameterProductsSession();
                        SaveUserLoginSession(responseModel.data.First());

                        if (productsParam.searchingKey != null)
                        {
                            return RedirectToAction("Index", "Home", new { area = "ProductList", searchingKey = productsParam.searchingKey });
                        } else
                        {
                            return RedirectToAction("Index", "Home", new { area = "" });
                        }                      
                    }
                    else
                    {
                        return HandleLoginFailAction(responseModel.code, input);
                    }
                }
                else
                {
                    return View(input);
                }
            }
            else
            {
                return View(input);
            }
        }

        private IActionResult HandleLoginFailAction(int apiResponseCode, LoginFormModel input)
        {
            if (apiResponseCode == USER_NOT_REGISTERED_LOGIN_API_ERR_CODE)
            {
                SetSingleViewData(USERNAME_ERROR_MSG_KEY, USERNAME_ERROR_MSG);
                return View(input);
            }
            else
            {
                SetSingleViewData(PASSWORD_ERROR_MSG_KEY, PASSWORD_ERROR_MSG);
                return View(input);
            }
        }

        private void SetSingleViewData(string key, string messageValue)
        {
            ViewData[key] = messageValue;
        }

        private void SaveUserLoginSession(Object sessionData)
        {
            HttpContext.Session.SetObject(USER_LOGIN_SESSION_KEY, sessionData);
        }

        private void SaveSessionProductsParameter(Object sessionTempParam)
        {
            HttpContext.Session.SetObject(PARAMETER_SESSION_PRODUCT_KEY, sessionTempParam);
        }

        private void RemoveUserLoginSession()
        {
            HttpContext.Session.Remove(USER_LOGIN_SESSION_KEY);
        }

        private Dictionary<string, string> ConstructLoginParams(LoginFormModel input)
        {
            return new Dictionary<string, string>
            {
                { LOGIN_USERNAME_PARAM_KEY, input.Email },
                { LOGIN_CUSTOMER_PASSWORD_PARAM_KEY, input.Password }
            };
        }

        public IActionResult Logout()
        {
            RemoveUserLoginSession();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private async Task<ParameterProductsSession> GetParameterProductsSession()
        {
            return await Task.FromResult(HttpContext.Session.GetObject<ParameterProductsSession>(PARAMETER_SESSION_PRODUCT_KEY));
        }

        private class ParameterProductsSession
        {
            public string searchingKey { get; set; }
            public string brandId { get; set; }
        }
    }
}