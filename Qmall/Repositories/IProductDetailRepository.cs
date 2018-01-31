using Qmall.Models;
using Qmall.Models.ProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Repositories
{
    public interface IProductDetailRepository
    {
        Task<ProductDetailBaseModel> GetAsyncParamDetailLogin(string parameters, string email, string customerToken);

        Task<ProductDetailViewModel> GetAsyncParam(string prameters);
    }
}
