using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
  public  interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void SaveUser(User user);
    }
}
