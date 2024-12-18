using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Entities
{
    public class DbUsers
    {
        public List<ApplicationUser> Personals { get; set; }

        public DbUsers()
        {
            Personals = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Name = "João",
                    Id = "1"
                },
                 new ApplicationUser()
                {
                    Name = "Helena",
                    Id = "2"
                },
                  new ApplicationUser()
                {
                    Name = "José",
                    Id = "3"
                },

            };
        }
    }
}
