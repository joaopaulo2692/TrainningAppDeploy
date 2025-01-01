using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrainningApp.Core.Entities
{
    public class ApplicationUser 
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public float? Heigth { get; set; }
        public string? Gender { get; set; }
        public float? Weight { get; set; }
        public int? GymId { get; set; }  
        // Usado para "Users"
        public DateTime Byrthday { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("disabled_at")]
        public DateTime? DisabledAt { get; set; }

        //public virtual List<Trainning> Trainnings { get; set; }
        public virtual List<Trainning> Trainings { get; set; } // Relacionamento como Personal
        public virtual List<Management> Managements { get; set; }
        public virtual Gym? Gym { get; set; }



        public List<ApplicationUser> GetAllPersonal()
        {
            return new List<ApplicationUser>() { new ApplicationUser() {
                Id = "1",
                Name = "José"},
            new ApplicationUser()
            {
                Id = "2",
                Name = "Gustavo"
            },
            new ApplicationUser(){
                Id = "3",
                Name = "Rodrigo"
                }
            };
        }

    }
}
