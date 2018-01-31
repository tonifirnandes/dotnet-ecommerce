using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Qmall.Areas.Register.Models;
using Newtonsoft.Json;
using Qmall.Repositories;
using System.Net;
using Qmall.Services.RestApi;
using Microsoft.AspNetCore.DataProtection;

namespace Qmall.Areas.Register.Controllers
{
    [Area("Register")]
    public class FormController : Controller
    {
        readonly IDataProtector _protector;

        const string KEY_PARAMETER_EMAIL = "email";
        const string KEY_PARAMETER_PASSWORD = "password";
        const string KEY_PARAMETER_CONFIRM_PASSWORD = "confirmPassword";
        const string KEY_PARAMETER_PHONE_NUMBER = "phoneNumber";
        const string KEY_PARAMETER_REGISTER_URI = "registerUri";
        const string KEY_PARAMETER_EMAIL_CODE = "emailCode";
        const string KEY_PARAMETER_OTP_CODE = "otpCode";
        const string REGISTER_SUCCESS_MESSAGE = "Register successfully !!";       
        const string REGISTER_NOT_VERIFIED = "You've already registered. But still not Verified !!";
        const string EMAIL_REGISTERED = "Your email already registered";
        const string VERIFIED_CODE_EXPIRED_MESSAGE = "Your code is expired. Please click resend button to get new code.";
        const string VERIFIED_CODE_NOT_VALID = "Verification not valid. Please check again.";
        const string RESEND_CODE_REACH_LIMIT_MESSAGE = "You already reach limit to get verification code today. Please try again later.";
        const string VIEW_DATA_KEY_MESSAGE_USER_SUCCESS = "user-success";
        const string VIEW_DATA_KEY_MESSAGE_ERR_VERIFICATION_CODE = "messageError";

        const int REGISTER_SUCCESS_CODE = 2000;
        const int NOT_VERIFIED_CODE = 2001;
        const int VERIFICATION_CODE_EXPIRED = 3000;
        const int VERIFICATION_CODE_SUCCESS = 3001;
        const int VERIFICATION_CODE_NOT_VALID = 3002;
        const int RESEND_CODE_REACH_LIMIT = 5002;

        public FormController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector(GetType().FullName);
        }
        #region register
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response;
                RegisterResponseModel responseModel;
             
                model.PhoneNumber = FormatPhoneNumber(model.PhoneNumber);
                response = await GetHttpResponseMessageRegister(model);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseModel = await GetResponseModel<RegisterResponseModel>(response);                  

                    if (responseModel.code == REGISTER_SUCCESS_CODE)                     
                        return RedirectToAction("RegisterSuccess", "Form", new { messages = RegisterMessage(REGISTER_SUCCESS_MESSAGE), email = model.Email });
                    else if (responseModel.code == NOT_VERIFIED_CODE)
                        return RedirectToAction("RegisterSuccess", "Form", new { messages = RegisterMessage(REGISTER_NOT_VERIFIED), email = model.Email });
                    else
                    {
                        ViewData["email-registered"] = EMAIL_REGISTERED;

                        return View(model);
                    }
                }
            }
            return View(model);
        }
        private Task<HttpResponseMessage> GetHttpResponseMessageRegister(RegisterFormModel model)
        {
            return HttpClientRequest.PostAsync(ApiEndpoints.Register, GenerateParametersApiRegister(model).Result);
        }
        private Task<Dictionary<string, string>> GenerateParametersApiRegister(RegisterFormModel model)
        {
            return Task.FromResult(new Dictionary<string, string>
            {
                { KEY_PARAMETER_EMAIL, model.Email },
                { KEY_PARAMETER_PASSWORD, model.Password },
                { KEY_PARAMETER_CONFIRM_PASSWORD, model.ConfirmPassword },
                { KEY_PARAMETER_PHONE_NUMBER, model.PhoneNumber },
                { KEY_PARAMETER_REGISTER_URI, GetAbsoluteUri(model).Result }
            });
        }        
        private Task<string> GetAbsoluteUri(RegisterFormModel registerModel)
        {
            return Task.FromResult(string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path));
        }
        public IActionResult RegisterSuccess(string messages, string email)
        {
            RegisterSuccessModel model = new RegisterSuccessModel();
            var msgDecrypted = _protector.Unprotect(messages);

            if (email != null)
                SetViewDataMessage(VIEW_DATA_KEY_MESSAGE_USER_SUCCESS, email);
            model.messages = msgDecrypted;

            return View(model);
        }
        #endregion

        #region verification code
        public IActionResult VerificationCode(string code)
        {
            VerifiedModel verifiedModel = new VerifiedModel();

            if (code != null)
            {
                verifiedModel.verifiedCode = code;
                return View(verifiedModel);
            }
            else
                return RedirectToAction("Index", "Home", new { area = "" });
        }
        [HttpPost]
        public async Task<IActionResult> VerificationCode(VerifiedModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response;
                VerifiedResponseModel verifiedResponseModel = new VerifiedResponseModel();

                response = await GetHttpResponseMessageVerificationCode(model);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    verifiedResponseModel = await GetResponseModel<VerifiedResponseModel>(response);
                    if (verifiedResponseModel.code == VERIFICATION_CODE_EXPIRED) 
                    {
                        SetViewDataMessage(VIEW_DATA_KEY_MESSAGE_ERR_VERIFICATION_CODE, VERIFIED_CODE_EXPIRED_MESSAGE);

                        return View(model);
                    }
                    else if (verifiedResponseModel.code == VERIFICATION_CODE_SUCCESS) 
                    {
                        return RedirectToAction("Index", "Form", new { area = "Login" });
                    }
                    else if (verifiedResponseModel.code == VERIFICATION_CODE_NOT_VALID)
                    {
                        SetViewDataMessage(VIEW_DATA_KEY_MESSAGE_ERR_VERIFICATION_CODE, VERIFIED_CODE_NOT_VALID);

                        return View(model);
                    }
                }
            }
            return View(model);
        }
        private Task<HttpResponseMessage> GetHttpResponseMessageVerificationCode(VerifiedModel model)
        {
            return HttpClientRequest.PostAsync(ApiEndpoints.VerificationCode, GenerateParametersApiVerificationCode(model).Result);
        }
        private Task<Dictionary<string, string>> GenerateParametersApiVerificationCode(VerifiedModel model)
        {
            return Task.FromResult(new Dictionary<string, string>
            {
                { KEY_PARAMETER_EMAIL_CODE, model.verifiedCode },
                { KEY_PARAMETER_OTP_CODE, model.code }
            });
        }
        #endregion

        #region resend code
        public async Task<JsonResult> ResendCode(string verifiedCode)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ResendCodeResponseModel responseModel = new ResendCodeResponseModel();

            response = await GetHttpResponseMessageResendCode(verifiedCode);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                responseModel = await GetResponseModel<ResendCodeResponseModel>(response);
                if (responseModel.code == RESEND_CODE_REACH_LIMIT)
                    responseModel.messageError = RESEND_CODE_REACH_LIMIT_MESSAGE;
            }        

            return Json(responseModel);
        }
        private Task<HttpResponseMessage> GetHttpResponseMessageResendCode(string verifiedCode)
        {
            return HttpClientRequest.PostAsync(ApiEndpoints.ResendCode, GenerateParametersApiResendCode(verifiedCode).Result);
        }
        private Task<Dictionary<string, string>> GenerateParametersApiResendCode(string verifiedCode)
        {
            return Task.FromResult(new Dictionary<string, string>
            {
                { KEY_PARAMETER_EMAIL_CODE, verifiedCode }
            });
        }
        #endregion

        #region Helper
        private Task<T> GetResponseModel<T>(HttpResponseMessage response)
        {
            return Task.FromResult(JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result));
        }
        private string FormatPhoneNumber(string phoneNumber)
        {
            string tempPhone = "";

            tempPhone = phoneNumber.Replace("-", "");
            tempPhone = tempPhone.Substring(1, tempPhone.Length - 1);       
            tempPhone = tempPhone.Insert(0, "62");

            return tempPhone;
        }
        private string RegisterMessage(string messages)
        {
            var msgEncrypted = _protector.Protect(messages);

            return msgEncrypted;
        }
        private void SetViewDataMessage(string key, string messageValue)
        {
            ViewData[key] = messageValue;
        }
        #endregion
    }
}