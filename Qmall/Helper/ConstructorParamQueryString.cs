using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Helper
{
    public class ConstructorParamQueryString
    {
        const string USER_LOGIN_SESSION = "USER_LOGIN_SESSION";
        const string BRAND_FILTER_PARAM = "productBrandId";
        const string SEARCHING_KEY_PARAM = "searchingkey";
        const string EQUALCHAR = "=";
        const string ENDCHAR = "&";

        public async static Task<string> ParamQueryString(string productBrandId, string searchingKey)
        {
            string parameters = BRAND_FILTER_PARAM + EQUALCHAR + productBrandId + ENDCHAR +
                SEARCHING_KEY_PARAM + EQUALCHAR + searchingKey;

            return await Task.FromResult(parameters);
        }
    }
}
