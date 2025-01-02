using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.User;

namespace TrainningApp.Core.Entities
{
    public class DbUsers
    {
        public List<ApplicationUser> Personals { get; set; }
        public List<ApplicationUser> Customers { get; set; }

        public static UserVO UserToVO(ApplicationUser user)
        {
            return new UserVO()
            {
                Age = user.Age.Value,
                Cpf = user.Cpf,
                Email = user.Email,
                Name = user.Name,
                Gender = user.Gender,
                Id = user.Id,
                Birthday = user.Byrthday
            };
        }

        public List<UserVO> UsersToDTO(List<ApplicationUser> applicationUsers)
        {
            return applicationUsers.Select(user => new UserVO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age.Value,
                Gender = user.Gender,
                Email = user.Email
            }).ToList();
        }

        public UserVO GetCustomerById(string id)
        {
            ApplicationUser user = Customers.Where(x => x.Id == id).FirstOrDefault();
            if (user == null) return new UserVO();

            return UserToVO(user);
        }
        public DbUsers()
        {
            //Personals = new List<ApplicationUser>()
            //{
            //    new ApplicationUser()
            //    {
            //        Name = "João",
            //        Id = "1"
            //    },
            //     new ApplicationUser()
            //    {
            //        Name = "Helena",
            //        Id = "2"
            //    },
            //      new ApplicationUser()
            //    {
            //        Name = "José",
            //        Id = "3"
            //    },

            //};
            Personals = new List<ApplicationUser>
        {
            new ApplicationUser { Id = "1", Name = "José", Age = 20, Gender = "Masculino" },
            new ApplicationUser { Id = "2", Name = "Gustavo", Age = 25, Gender = "Masculino" },
            new ApplicationUser { Id = "3", Name = "Rodrigo", Age = 30, Gender = "Masculino" }
        };

            // Inicializando Customers com 20 nomes fixos
            Customers = new List<ApplicationUser>
{
    new ApplicationUser { Id = "1", Name = "Alice", Age = 25, Gender = "Feminino", Email = "alice@gmail.com", Cpf = "222222222", Heigth = 1.65f, Weight = 55, Byrthday = new DateTime(1998, 5, 15) },
    new ApplicationUser { Id = "2", Name = "Bob", Age = 30, Gender = "Masculino", Email = "bob@gmail.com", Cpf = "333333333", Heigth = 1.75f, Weight = 70, Byrthday = new DateTime(1995, 8, 22) },
    new ApplicationUser { Id = "3", Name = "Clara", Age = 28, Gender = "Feminino", Email = "clara@gmail.com", Cpf = "444444444", Heigth = 1.68f, Weight = 58, Byrthday = new DateTime(1997, 3, 10) },
    new ApplicationUser { Id = "4", Name = "David", Age = 35, Gender = "Masculino", Email = "david@gmail.com", Cpf = "555555555", Heigth = 1.80f, Weight = 80, Byrthday = new DateTime(1990, 1, 5) },
    new ApplicationUser { Id = "5", Name = "Eva", Age = 23, Gender = "Feminino", Email = "eva@gmail.com", Cpf = "666666666", Heigth = 1.62f, Weight = 52, Byrthday = new DateTime(2002, 7, 18) },
    new ApplicationUser { Id = "6", Name = "Frank", Age = 40, Gender = "Masculino", Email = "frank@gmail.com", Cpf = "777777777", Heigth = 1.85f, Weight = 85, Byrthday = new DateTime(1985, 12, 1) },
    new ApplicationUser { Id = "7", Name = "Grace", Age = 27, Gender = "Feminino", Email = "grace@gmail.com", Cpf = "888888888", Heigth = 1.70f, Weight = 60, Byrthday = new DateTime(1998, 9, 12) },
    new ApplicationUser { Id = "8", Name = "Henry", Age = 32, Gender = "Masculino", Email = "henry@gmail.com", Cpf = "999999999", Heigth = 1.78f, Weight = 75, Byrthday = new DateTime(1993, 11, 30) },
    new ApplicationUser { Id = "9", Name = "Ivy", Age = 26, Gender = "Feminino", Email = "ivy@gmail.com", Cpf = "101010101", Heigth = 1.63f, Weight = 54, Byrthday = new DateTime(1998, 4, 25) },
    new ApplicationUser { Id = "10", Name = "Jack", Age = 29, Gender = "Masculino", Email = "jack@gmail.com", Cpf = "111111111", Heigth = 1.82f, Weight = 78, Byrthday = new DateTime(1996, 6, 17) }
};

        }
    }
    }

