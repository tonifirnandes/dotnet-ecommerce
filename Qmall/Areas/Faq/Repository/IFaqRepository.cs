using Qmall.Areas.Faq.Models;
using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Areas.Faq.Repository
{
    public interface IFaqRepository
    {
        Task<FaqModel> GetAsync();
    }
}
