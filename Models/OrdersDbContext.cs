﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApp1.Models
{
    public class OrdersDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}