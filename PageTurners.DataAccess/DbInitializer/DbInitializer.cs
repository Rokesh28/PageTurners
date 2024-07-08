using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PageTurners.DataAccess.Data;
using PageTurners.Models;
using PageTurners.Utility;
using System;
using System.Linq;

namespace PageTurners.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            // Migrate the database
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
                throw;
            }

            // Create roles if they are not created
            try
            {
                if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

                    // Create admin user
                    var adminUser = new ApplicationUser
                    {
                        UserName = "Rokesh",
                        Email = "rokesh2897@gmail.com",
                        Name = "Rokesh Prakash",
                        PhoneNumber = "9898945345",
                        StreetAddress = "70 lake groove",
                        State = "NY",
                        PostalCode = "23422",
                        City = "Stony Brook"
                    };
                    var result = _userManager.CreateAsync(adminUser, "Admin@789").GetAwaiter().GetResult();

                    if (result.Succeeded)
                    {
                        var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "rokesh2897@gmail.com");
                        if (user != null)
                        {
                            _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                        }
                    }
                    else
                    {
                        // Log user creation errors
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error creating admin user: {error.Description}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while initializing roles and users: {ex.Message}");
                throw;
            }
        }
    }
}
