using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace auction_portal_ubb.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AuctionModel> Auctions { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<AuctionModel>().ToTable("Auction");
            modelBuilder.Entity<TransactionModel>().ToTable("Transaction");
            modelBuilder.Entity<AddressModel>().ToTable("Address");

        }


    }
}