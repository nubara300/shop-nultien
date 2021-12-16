using NultienShop.Common.ViewModels;
using NultienShop.DataAccess.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NultienShop.BusinessLogic.Mappers
{
    public static class Mappers
    {
        public static List<CustomerVM> AdaptToViewModel(this List<Customer> customerVM)
        {
            return customerVM == null ? new List<CustomerVM>() : customerVM.Select(x => new CustomerVM
            {
                CustomerEmail = x.CustomerEmail,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName
            }).ToList();
        }

        public static Customer AdaptToModel(this CustomerVM customerVM)
        {
            return customerVM == null ? new() : new()
            {
                CustomerId = SetId(customerVM.CustomerId),
                CustomerEmail = customerVM.CustomerEmail,
                CustomerName = customerVM.CustomerName,
            };
        }


        public static List<ArticleVM> AdaptToViewModel(this List<Article> customerVM)
        {
            return customerVM == null ? new List<ArticleVM>() : customerVM.Select(x => x.AdaptToViewModel()).ToList();
        }

        public static ArticleVM AdaptToViewModel(this Article article)
        {
            return article == null ? new ArticleVM() : new ArticleVM
            {
                ArticleId = article.ArticleId,
                ArticleName = article.ArticleName,
                ArticlePrice = article.ArticlePrice,
                DateCreated = article.DateCreated
            };
        }

        public static Article AdaptToModel(this ArticleVM article)
        {
            return article == null ? new() : new()
            {
                ArticleId = SetId(article.ArticleId),
                ArticleName = article.ArticleName,
                ArticlePrice = article.ArticlePrice,
                DateCreated = article.ArticleId == 0 ? DateTime.Now : article.DateCreated
            };
        }


        public static int SetId(int? id)
        {
            return (int)(id != null && id > 0 ? id : 0);
        }
    }
}