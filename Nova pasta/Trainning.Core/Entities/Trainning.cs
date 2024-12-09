using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Entities
{
    public class Trainning : BaseEntities
    {
        public int Id { get; set; }
        public string Goal { get; set; }
        public DateTime FirstDay{ get; set; }
        public DateTime LastDay{ get; set; }
        public string PersonalId {  get; set; }
        public int? GymId { get; set; }
        public string Level { get; set; }
        public int FrequencyWeekly { get; set; }
        public string Observation {  get; set; }
        public bool Activate { get; set; }
        public string? Gender { get; set; }
        public int ManagementId { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }

        public virtual List<TrainningDay> TrainningDays { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual Management Management { get; set; }

        //public virtual List<TrainningExercise> TrainningExercises { get; set; }

    }
}
