using DevShop.Application.Abstractions.Services;
using DevShop.Application.Helpers.Utilities.FileHelper;
using DevShop.Application.Repositories.Pictures;
using DevShop.Application.Repositories.Products;
using DevShop.Domain.Entities.Concrete;
using DevShop.Persistance.Context;
using Microsoft.AspNetCore.Http;
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

        public ProductService(AppDbContext context)
        {
            _context = context;
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

        public async Task<IEnumerable<Product>> SimilarProducts(Guid subCatagoryId,Guid productId)
        {
            var products = await _context.Product.Include(x => x.ProductPictures).ThenInclude(x => x.Picture)
                            .Where(x => x.SubCatagoryId == subCatagoryId && x.Id != productId).ToListAsync();
            return products;
        }
    }
}
