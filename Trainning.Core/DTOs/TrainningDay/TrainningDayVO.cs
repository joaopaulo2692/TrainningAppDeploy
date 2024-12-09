using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrainningApp.Core.DTO.TrainningDay
{
    public class TrainningDayVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> TrainningExercisesId { get; set; } = new List<int>();
        public int TrainningId { get; set; }
    }
}
