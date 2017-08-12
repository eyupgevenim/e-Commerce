using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Commerce.DAL.Data;
using Commerce.Model;

namespace Commerce.DAL.Initialize
{
    public static class InitializeData
    {
        public static async Task InitializeEIADatabaseAsync(IServiceProvider serviceProvider, bool createUsers = true)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DataContext>();

                // if there isn't database, to create database and return true
                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertData(serviceProvider);

                    if (createUsers)
                    {
                        await CreateUser(serviceProvider);
                    }

                }
            }
        }

        private static async Task InsertData(IServiceProvider serviceProvider)
        {
            await AddOrUpdateAsync(serviceProvider, r => r.Id, Roles.Select(role => role.Value));
        }

        // TODO [EF] This may be replaced by a first class mechanism in EF
        private static async Task AddOrUpdateAsync<TEntity>(
            IServiceProvider serviceProvider,
            Func<TEntity, object> propertyToMatch, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            // Query in a separate context so that we can attach existing entities as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DataContext>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DataContext>();
                foreach (var item in entities)
                {
                    db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                        ? EntityState.Modified
                        : EntityState.Added;
                }

                await db.SaveChangesAsync();
            }
        }//AddOrUpdateAsync

        //create users
        private static async Task CreateUser(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<User>>();

            //Super Admin
            var user1 = new User
            {
                UserName = "superAdminTest",
                Email = "s@s.com"
            };
            await userManager.CreateAsync(user1, "Passw0rd!");
            await userManager.AddToRoleAsync(user1, "SuperAdmin");

            //admin
            var user2 = new User
            {
                UserName = "adminTest",
                Email = "a@a.com"
            };
            await userManager.CreateAsync(user2, "Passw0rd!");
            await userManager.AddToRoleAsync(user2, "Admin");

            // Development
            var user3 = new User
            {
                UserName = "developmentTest",
                Email = "d@d.com"
            };
            await userManager.CreateAsync(user3, "Passw0rd!");
            await userManager.AddToRoleAsync(user3, "Development");
            
            //Customer
            var user4 = new User
            {
                UserName = "customerTest",
                Email = "c@c.com"
            };
            await userManager.CreateAsync(user4, "Passw0rd!");
            await userManager.AddToRoleAsync(user4, "Customer");
        }

        //user roles list
        private static Dictionary<string, IdentityRole> roles;
        private static Dictionary<string, IdentityRole> Roles
        {
            get
            {
                if (roles == null)
                {
                    var rolesList = new IdentityRole[]
                    {
                        new IdentityRole { Name = "Development" , NormalizedName="DEVELOPMENT" },
                        new IdentityRole { Name = "SuperAdmin" , NormalizedName="SUPERADMIN" },
                        new IdentityRole { Name = "Admin" , NormalizedName="ADMIN" },
                        new IdentityRole { Name = "Customer" , NormalizedName="CUSTOMER" }
                    };

                    roles = new Dictionary<string, IdentityRole>();

                    foreach (IdentityRole role in rolesList)
                    {
                        roles.Add(role.Name, role);
                    }
                }
                return roles;
            }
        }
    }
}
