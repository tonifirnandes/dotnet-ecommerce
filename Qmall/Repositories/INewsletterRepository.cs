using Qmall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Repositories
{
    public interface INewsletterRepository
    {
        Task<NewsletterModel> GetAsync();
    }
}
