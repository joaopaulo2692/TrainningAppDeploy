using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.TrainningDay;
using TrainningApp.Core.DTO.TrainningExercise;

namespace TrainningApp.Core.Entities
{
    public class DbTrainningDay
    {
        public List<TrainningDay> TrainningDays { get; set; }

        public readonly DbMusclesAndExercises _musclesAndExercises;
        public readonly DbTrainningExercise _trainningExercise;


        public TrainningDayVO TrainningDayToVO(TrainningDay trainningDay)
        {
           TrainningDayVO trainningVO =  new TrainningDayVO
            {
                Name = trainningDay.Name,
                Id = trainningDay.Id
                

            };
            return trainningVO;
        }

        public DbTrainningDay()
        {
            TrainningDays = new List<TrainningDay>()
            {
                new TrainningDay
                {
                    Id = 1,
                    Name = "A",
                    Ordenation = 1,
                    TrainningId = 1,
                    TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.Id == 1 || x.Id == 2 || x.Id == 3).ToList(),
                },
                new TrainningDay
                {
                    Id = 2,
                    Name = "B",
                    Ordenation = 2,
                    TrainningId = 2,
                    TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.Id == 4 || x.Id == 5).ToList()
                },
                new TrainningDay
                {
                    Id = 3,
                    Name = "C",
                    Ordenation = 3,
                    TrainningId = 3,
                    TrainningExercises =  _trainningExercise.TrainningExercises.Where(x => x.Id == 6 || x.Id == 7 || x.Id == 8 || x.Id == 9).ToList()
                }
            };
        }
    }
}           
        
    

