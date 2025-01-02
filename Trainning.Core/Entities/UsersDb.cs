using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.User;

namespace TrainningApp.Core.Entities
{
    public class UsersDb
    {
        public List<ApplicationUser> Customers { get; set; }
        public List<ApplicationUser> Personals { get; set; }



        public List<UserVO> CustomersToDTO()
        {
            return Customers.Select(user => new UserVO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age.Value
            }).ToList();
        }

  



        public UsersDb()
        {
            // Inicializando Personals com dados fixos
            Personals = new List<ApplicationUser>
        {
            new ApplicationUser { Id = "1", Name = "José", Age = 20, Gender = "Masculino" },
            new ApplicationUser { Id = "2", Name = "Gustavo", Age = 25, Gender = "Masculino" },
            new ApplicationUser { Id = "3", Name = "Rodrigo", Age = 30, Gender = "Masculino" }
        };

            // Inicializando Customers com 20 nomes fixos
            Customers = new List<ApplicationUser>
        {
            new ApplicationUser { Id = "4", Name = "Ana", Age = 24, Gender = "Feminino" },
            new ApplicationUser { Id = "5", Name = "Bruno", Age = 28, Gender = "Masculino" },
            new ApplicationUser { Id = "6", Name = "Carla", Age = 22, Gender = "Feminino" },
            new ApplicationUser { Id = "7", Name = "Daniel", Age = 35, Gender = "Masculino" },
            new ApplicationUser { Id = "8", Name = "Elaine", Age = 26, Gender = "Feminino" },
            new ApplicationUser { Id = "9", Name = "Fernando", Age = 32, Gender = "Masculino" },
            new ApplicationUser { Id = "10", Name = "Gabriela", Age = 27, Gender = "Feminino" },
            new ApplicationUser { Id = "11", Name = "Hugo", Age = 29, Gender = "Masculino" },
            new ApplicationUser { Id = "12", Name = "Isabela", Age = 23, Gender = "Feminino" },
            new ApplicationUser { Id = "13", Name = "João", Age = 31, Gender = "Masculino" },
            new ApplicationUser { Id = "14", Name = "Karen", Age = 25, Gender = "Feminino" },
            new ApplicationUser { Id = "15", Name = "Leonardo", Age = 33, Gender = "Masculino" },
            new ApplicationUser { Id = "16", Name = "Mariana", Age = 24, Gender = "Feminino" },
            new ApplicationUser { Id = "17", Name = "Natália", Age = 28, Gender = "Feminino" },
            new ApplicationUser { Id = "18", Name = "Otávio", Age = 34, Gender = "Masculino" },
            new ApplicationUser { Id = "19", Name = "Patrícia", Age = 26, Gender = "Feminino" },
            new ApplicationUser { Id = "20", Name = "Rafael", Age = 30, Gender = "Masculino" },
            new ApplicationUser { Id = "21", Name = "Sofia", Age = 22, Gender = "Feminino" },
            new ApplicationUser { Id = "22", Name = "Thiago", Age = 29, Gender = "Masculino" },
            new ApplicationUser { Id = "23", Name = "Vanessa", Age = 27, Gender = "Feminino" }
            };
        }

    }
}
