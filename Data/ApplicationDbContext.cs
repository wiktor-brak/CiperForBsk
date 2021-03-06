﻿using System;
using System.Collections.Generic;
using System.Text;
using CiperForBsk.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CiperForBsk.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
