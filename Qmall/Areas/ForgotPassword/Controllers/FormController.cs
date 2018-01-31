using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Areas.ForgotPassword.Models;
using System.Net.Http;
using Qmall.Repositories;
using Qmall.Services.RestApi;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection;
using Qmall.Areas.Register.Models;

namespace Qmall.Areas.ForgotPassword.Controllers
{
    [Area("ForgotPassword")]
    public class FormController : Controller
    {
        private const string FORGOT_PASSWORD_MSG_EXPIRED_KEY = "msgExpired";
        private const string FORGOT_EMAIL_MSG_KEY = "email-forgot";
        private const string FORGOT_PASSWORD_MSG_ERROR_KEY = "emailErr";
        private const string FORGOT_PASSWORD_ACTION_LIMIT_REACHED_MSG_ERR = "You have reach maximum of forgot password.";
        private const string FORGOT_PASSWORD_EMAIL_ISNOT_EXIST_MSG_ERR = "Email not exist";
        private const string FORGOT_PASSWORD_PATTERN_URL = "{0}://{1}{2}";
        private const string FORGOT_PASSWORD_EMAIL_PARAM_KEY = "email";
        private const string FORGOT_PASSWORD_URI_PARAM_KEY = "forgetPasswordUri";
        private const int FORGOT_PASSWORD_SUCCESS_CODE = 7000;
        private const int FORGOT_PASSWORD_ACTION_LIMIT_REACHED_CODE = 7005;
        //Todo : Separate ForgotPassword and ResetPassword Controller
        private const int RESET_PASSWORD_API_SUCCESS_CODE = 8000;
        private const int RESET_PASSWORD_GENERAL_ERR_CODE = 8001;
        private const int RESET_PASSWORD_EXPIRED_ERR_CODE = 8005;
        private const string RESET_PASSWORD_EXPIRED_ERR_MSG = "Reset password expired. Please resend your email";
        private const string RESET_PASSWORD_PARAM_KEY = "password";
        private const string RESET_PASSWORD_CODE_PARAM_KEY = "customerForgotPasswordCode";
        private const string RESET_CONFIRM_PASSWORD_PARAM_KEY = "confirmPassword";

        //Todo : Evaluate IDataProtector        
        private readonly IDataProtector _protector;

        public FormController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector(GetType().FullName);
        }

        public IActionResult Index(string codeExpired)
        {
            if (codeExpired != null)
            {
                ViewData[FORGOT_PASSWORD_MSG_EXPIRED_KEY] = _protector.Unprotect(codeExpired);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ForgotPasswordModel input)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage httpResponseMessage = await HttpClientRequest.PostAsync(ApiEndpoints.ForgotPassword, 
                    ConstructForgotPasswordParams(input.Email));

                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {                    
                    ForgotPasswordResponseModel responseModel = JsonConvert.DeserializeObject<ForgotPasswordResponseModel>(
                        await httpResponseMessage.Content.ReadAsStringAsync());

                    if (responseModel.code == FORGOT_PASSWORD_SUCCESS_CODE)
                    {
                        return RedirectToAction("ForgotPasswordSuccess", "Form", new { email = ProtectForgotPasswordMessage(input.Email) });
                    } else
                    {
                        return HandleForgotPasswordFailAction(responseModel.code, input);
                    }

                } else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }                
            } else
            {
                return View(input);
            }
        }

        private IActionResult HandleForgotPasswordFailAction(int apiResponseCode, ForgotPasswordModel input)
        {
            if (apiResponseCode == FORGOT_PASSWORD_ACTION_LIMIT_REACHED_CODE)
            {
                SetSingleViewData(FORGOT_PASSWORD_MSG_ERROR_KEY, FORGOT_PASSWORD_ACTION_LIMIT_REACHED_MSG_ERR);
                return View(input);
            } else
            {
                SetSingleViewData( FORGOT_PASSWORD_MSG_ERROR_KEY, FORGOT_PASSWORD_EMAIL_ISNOT_EXIST_MSG_ERR);
                return View(input);
            }
        }

        private void SetSingleViewData(string key, string value)
        {
            ViewData[key] = value;
        }

        private Dictionary<string, string> ConstructForgotPasswordParams(string email)
        {
            return new Dictionary<string, string>
                {
                    { FORGOT_PASSWORD_EMAIL_PARAM_KEY, email },
                    { FORGOT_PASSWORD_URI_PARAM_KEY,  GetForgotPasswordUrl()}
                };
        }

        private string GetForgotPasswordUrl()
        {
            return string.Format(FORGOT_PASSWORD_PATTERN_URL, Request.Scheme, Request.Host, Request.Path);
        }

        public IActionResult ForgotPasswordSuccess(string email)
        {
            if (email != null)
            {                
                SetSingleViewData(FORGOT_EMAIL_MSG_KEY, _protector.Unprotect(email));
            }               

            return View();
        }

        public IActionResult ResetPassword(string code)
        {
            ResetPasswordModel model = new ResetPasswordModel();

            //Todo: ResetPassword evaluate code != null meant for
            if (code != null)
            {
                model.Code = code;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
       
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel input)
        {
            if (ModelState.IsValid)
            {              
                HttpResponseMessage httpResponseMessage = await HttpClientRequest.PostAsync(ApiEndpoints.ResetPassword, 
                    ConstructResetPasswordParams(input));

                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {                    
                    ResetPasswordResponseModel responseModel = JsonConvert.DeserializeObject<ResetPasswordResponseModel>(
                        await httpResponseMessage.Content.ReadAsStringAsync());

                    if (responseModel.code == RESET_PASSWORD_API_SUCCESS_CODE)
                    {
                        return RedirectToAction("Index", "Form", new { area = "Login" });
                    } else
                    {
                        return HandleResetPasswordFailAction(responseModel.code, input);
                    }
                } else
                {
                    return View(input);
                }
            } else
            {
                return View(input);
            }
            
        }

        private IActionResult HandleResetPasswordFailAction(int apiResponseCode, ResetPasswordModel input)
        {
            if (apiResponseCode == RESET_PASSWORD_EXPIRED_ERR_CODE)
            {
                return RedirectToAction("Index", "Form", new { area = "ForgotPassword",
                    codeExpired = ProtectForgotPasswordMessage(RESET_PASSWORD_EXPIRED_ERR_MSG) });
            } else
            {
                return View(input);
            }
        }
        
        private Dictionary<string, string> ConstructResetPasswordParams(ResetPasswordModel input)
        {
            return new Dictionary<string, string>
                {
                    { RESET_PASSWORD_PARAM_KEY, input.Password },
                    { RESET_PASSWORD_CODE_PARAM_KEY, input.Code },
                    { RESET_CONFIRM_PASSWORD_PARAM_KEY, input.ConfirmPassword }
                };
        }

        private string ProtectForgotPasswordMessage(string messages)
        {
            return _protector.Protect(messages);
        }
    }
}