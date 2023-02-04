﻿using DevShop.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services
{
    public interface IWishlistService
    {
        Task<IEnumerable<Wishlist>> GetWishlists(string userId,int page = 1,int size =10);
    }
}
