﻿
using Group4_Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.DbData
{
    public class EFUserRepository : IUserRepository
    {
        private MovieAppDbContext context;

        public EFUserRepository(MovieAppDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<User> Users => context.Users;

        public User GetUserMovies(string email)
        {
            User dbEntry = context.Users
                .FirstOrDefault(u => u.Email == email);
            return dbEntry;
        }

        public void SaveUser(User user)
        {
            if (user.UserId == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users
                   .FirstOrDefault(u => u.UserId == user.UserId);
                if (dbEntry != null)
                {
                    dbEntry.Email = user.Email;
                    dbEntry.Password = user.Password;
                    dbEntry.ConfirmPassword = user.ConfirmPassword;
                }
            }
            context.SaveChanges();
        }
    }
}
