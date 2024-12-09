using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.TrainningExercise;

namespace TrainningApp.Core.DTO.TrainningDay
{
    public class TrainningDayReturnVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ordenation {  get; set; }
        public List<TrainningExerciseVO> TrainningExercises { get; set; } 
        public int TrainningId { get; set; }
    }
}
