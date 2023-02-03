using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.ViewModels
{
    public class DetailsVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> SimilarProducts { get; set; }
        public IEnumerable<Review> YourReviews { get; set; }
        public IEnumerable<Review> AllReviews { get; set; }
    }
}
