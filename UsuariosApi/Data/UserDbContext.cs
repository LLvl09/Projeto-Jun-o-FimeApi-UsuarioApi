using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 999999999
            };
            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 999999999, Name = "admin", NormalizedName = "ADMIN" }
                );

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 999999998, Name = "regular", NormalizedName = "REGULAR" }
                );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 999999999, UserId = 999999999 }
                );
        }
    }
}