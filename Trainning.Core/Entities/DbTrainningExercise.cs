using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Entities
{
    public class DbTrainningExercise
    {
        public List<TrainningExercise> TrainningExercises { get; set; }

        private readonly DbMusclesAndExercises _musclesAndExercises;

        public DbTrainningExercise() 
        {
            TrainningExercises = new List<TrainningExercise>()
            {
                        new TrainningExercise
                        {
                            Id = 1,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 1).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 1,
                            TrainningDayId = 1


                        },
                        new TrainningExercise
                        {
                            Id = 2,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 2).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 2,
                            TrainningDayId = 1
                        },
                        new TrainningExercise
                        {
                            Id= 3,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 3).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 3,
                            TrainningDayId = 1
                        },
                        new TrainningExercise
                        {
                            Id = 4,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 4).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 1,
                            TrainningDayId = 1
                        },
                        new TrainningExercise
                        {
                            Id = 5,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 5).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 2,
                            TrainningDayId = 1
                        },
                        new TrainningExercise
                        {   
                            Id = 6,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 6).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 3,
                            TrainningDayId = 1
                        },
                        new TrainningExercise
                        {

                            Id=7,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 7).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 1,
                            TrainningDayId = 1
                        },
                        new TrainningExercise
                        {   
                            Id = 8,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 8).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 2,
                            TrainningDayId = 1
                        },
                        new TrainningExercise
                        {
                            Id = 9,
                            Reps = "10",
                            Set = 3,
                            Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == 9).FirstOrDefault(),
                            Info = "Normal",
                            Ordenation = 3,
                            TrainningDayId = 1
                        }

            };
        }
    }
}
