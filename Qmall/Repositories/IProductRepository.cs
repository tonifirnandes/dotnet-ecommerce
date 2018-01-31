using Qmall.Areas.SearchProducts.Models;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Repositories
{ 
    /// <summary>
    /// <param name="parameters">parameters yg dilempar berupa string</param>
    /// GetProductByBrand() => mengambil product limit 10
    /// GetAllProductByBrand() => mengambil product tanpa limit
    /// </summary>
    public interface IProductRepository
    {
        Task<ProductsTopViewModel> GetTopViewAsync();
        Task<SearchProductsViewModel> SearchFilter(string parameters, string email, string customerToken);
    }
}
