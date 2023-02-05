using DevShop.Application.Cqrs.Commands.Products.Create;
using DevShop.Application.DTOs.Products;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetPopularProducts();
        Task<IEnumerable<Product>> GetNewProducts();
        Task<IEnumerable<Product>> SimilarProducts(Guid subCatagoryId, Guid productId);
        Task<int> GetRatingOfProduct(Guid productId);
        Task<bool> CalculateRating(Guid productId);
        Task<bool> IncreaseView(Guid productId);
        Task<PaymentResponse> GetPaymentFromSales(List<Guid> productIds); 
    }
}
