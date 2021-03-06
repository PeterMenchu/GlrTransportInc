﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Models;

namespace GlrTransportInc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GlrTransportInc.Models.FreightBill> FreightBill { get; set; }
        public DbSet<GlrTransportInc.Models.UserModel> UserModel { get; set; }
        public DbSet<GlrTransportInc.Models.Announcement> Announcement { get; set; }
        public DbSet<GlrTransportInc.Models.Timesheet> Timesheet { get; set; }
    }
}
