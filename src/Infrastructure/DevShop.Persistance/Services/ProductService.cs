using DevShop.Application.Abstractions.Services;
using DevShop.Application.DTOs.Products;
using DevShop.Application.Helpers.Utilities.FileHelper;
using DevShop.Application.Repositories.Pictures;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using DevShop.Persistance.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IReviewService _reviewService;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepo;
        public ProductService(AppDbContext context, IReviewService reviewService, IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepo)
        {
            _context = context;
            _reviewService = reviewService;
            _productWriteRepository = productWriteRepository;
            _productReadRepo = productReadRepo;
        }

        public async Task<int> GetRatingOfProduct(Guid productId)
        {
            var results = await _context.Reviews.Where(x => x.IsDeleted == false && x.ProductId == productId)
                             .ToListAsync();
            return (int)results.Sum(x => x.Rating);
        }

        public async Task<IEnumerable<Product>> GetNewProducts()
        {
            var products = await _context.Product.Include(x => x.ProductPictures).ThenInclude(x => x.Picture)
                                .Where(x => x.IsDeleted == false)
                                .OrderByDescending(x => x.CreatedDate).Take(8).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetPopularProducts()
        {
            var products = await _context.Product.Include(x => x.ProductPictures).ThenInclude(x => x.Picture)
                                .Where(x => x.IsDeleted == false)
                                .OrderByDescending(x => x.View).Take(8).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SimilarProducts(Guid subCatagoryId, Guid productId)
        {
            var products = await _context.Product.Include(x => x.ProductPictures).ThenInclude(x => x.Picture)
                            .Where(x => x.SubCatagoryId == subCatagoryId && x.Id != productId).ToListAsync();
            return products;
        }

        public async Task<bool> CalculateRating(Guid productId)
        {
            int result = 0;
            var data = await _productReadRepo.GetByIdAsync(productId);
            int totalReviews = await GetRatingOfProduct(productId);//4
            int totalCount = await _reviewService.ReviewCountsOfProduct(productId);//2
            result += totalReviews;
            result /= totalCount == 0 ? 1 : totalCount;

            data.Rating = result;
            await _productWriteRepository.UpdateAsync(data);
            return true;
        }

        public async Task<bool> IncreaseView(Guid productId)
        {
            var product = await _productReadRepo.GetByIdAsync(productId);
            product.View++;
            await _productWriteRepository.UpdateAsync(product);
            return true;
        }

        public async Task<PaymentResponse> GetPaymentFromSales(List<Guid> productIds)
        {
            List<string> sellers = new();
            List<Guid> prods = new();
            for (int i = 0; i < productIds.Count; i++)
            {
                Product? prod = await _context.Product.Where(x => x.Id == productIds[i]).FirstOrDefaultAsync();
                AppUser? data = await _context.Product.Where(x => x.Id == productIds[i]).Select(x => x.User)
                                                                                        .FirstOrDefaultAsync();
                data.Budget += (prod.Price - (prod.Price * prod.Discount / 100));
                prod.Quantity--;
                _context.Users.Update(data);
                _context.Product.Update(prod);
                await _context.SaveChangesAsync();
                sellers.Add(data.Id);
                prods.Add(prod.Id);
            }
            return new() { ProductIds = prods, SellerIds = sellers };

        }
    }
}
