using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Entities
{
    public class Exercise : BaseEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public string  Video { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public virtual List<Muscle> Muscles { get; set;}
        public virtual List<TrainningExercise> TrainningExercises { get; set; }
    }
}
