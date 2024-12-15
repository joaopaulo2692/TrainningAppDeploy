using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Entities
{
    public class TrainningDay : BaseEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<TrainningExercise> TrainningExercises { get; set; }
        public int Ordenation {  get; set; }
        public int TrainningId { get; set; }
        public virtual Trainning Trainning { get; set; }
    }
}
