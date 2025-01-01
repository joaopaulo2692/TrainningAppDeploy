using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.DTO.User
{
    public class UserVO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Observation { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public string Goal { get; set; }
        public DateTime Birthday {  get; set; }
        public string Cep {  get; set; }
        public string City {  get; set; }
        public string Address {  get; set; }
        public int NumberHouse {  get; set; }
        public string Neighborhood {  get; set; }
        public string Complement{  get; set; }
    
    }
}
