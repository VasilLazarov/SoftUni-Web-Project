﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLigaFans.Core.Contracts.CartServices
{
    public interface ICartService
    {
        Task CreateAsync(string userId);
    }
}