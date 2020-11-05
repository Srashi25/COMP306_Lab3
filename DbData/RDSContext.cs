using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group4_Lab3.DbData;

namespace Group4_Lab3.DbData
{
    public class RDSContext: DbContext
    {
        public RDSContext()
      : base(GetRDSConnectionString())
        {
        }

        public static RDSContext Create()
        {
            return new RDSContext();
        }
    }
}
