using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.Exercise;
using TrainningApp.Core.DTO.TrainningDay;
using TrainningApp.Core.DTO.TrainningExercise;

namespace TrainningApp.Core.Entities
{
    public class DbTrainningExercise
    {
        public List<TrainningExercise> TrainningExercises { get; set; }

        private readonly DbMusclesAndExercises _musclesAndExercises;
        //private readonly DbTrainningDay _trainningDay;
        

        public event Action TrainningExerciseUpdated;

        public List<TrainningExerciseVO> TrainningExerciseTOListVO(List<TrainningExercise> list)
        {
            return list
                .OrderBy(exercise => exercise.Ordenation) // Ordena pela propriedade Ordenation
                .Select(exercise => new TrainningExerciseVO
                {
                    ExerciseName = exercise.Exercise.Name,
                    Id = exercise.Id,
                    Info = exercise.Info,
                    Interval = exercise.Interval,
                    Ordenation = exercise.Ordenation,
                    Reps = exercise.Reps,
                    Set = exercise.Set,
                    Weight = exercise.Weight,
                    ExerciseId = exercise.Exercise.Id,
                    TrainningDayId = exercise.TrainningDayId
                })
                .ToList();
        }


        public TrainningExercise TrainningExerciseVOToEntitie(TrainningExerciseVO trainningExerciseVO)
        {
            return new TrainningExercise
            {
                Exercise = _musclesAndExercises.Exercises.Where(x => x.Id == trainningExerciseVO.ExerciseId).FirstOrDefault(),
                Id = trainningExerciseVO.Id,
                Info = trainningExerciseVO.Info,
                Interval = trainningExerciseVO.Interval,
                Ordenation = trainningExerciseVO.Ordenation,
                Reps = trainningExerciseVO.Reps,
                Set = trainningExerciseVO.Set,
                Weight = trainningExerciseVO.Weight,
                ExerciseId = trainningExerciseVO.ExerciseId,
                TrainningDayId = trainningExerciseVO.TrainningDayId
                //TrainningDay = _trainningDay.TrainningDays.Where(x => x.Id == trainningExerciseVO.TrainningDayId).FirstOrDefault(),
                
            };
        }

        public List<TrainningExerciseVO> GetByTrainningDayId(int trainningId)
        {
            List<TrainningExercise> trainningExercise = TrainningExercises.Where(x => x.TrainningDayId == trainningId).ToList();
            return TrainningExerciseTOListVO(trainningExercise);
        }

        public int AddNewExercise(TrainningExerciseVO trainningExerciseVO, TrainningDay trainningDay)
        {
            List<TrainningExercise> trainningExercises = TrainningExercises.Where(x => x.TrainningDayId == trainningExerciseVO.TrainningDayId).ToList();
            if(trainningExercises != null && trainningExercises.Count > 0)
            {
                int ordenation = trainningExercises.Max(x => x.Ordenation);
                ordenation++;
                trainningExerciseVO.Ordenation = ordenation;
            }
            else
            {
                trainningExerciseVO.Ordenation = 1;
            }
            

            int id = TrainningExercises.Max(x => x.Id);
            //trainningExerciseVO.Ordenation = ordenation++;


            TrainningExercise trainningExercise = TrainningExerciseVOToEntitie(trainningExerciseVO);
            trainningExercise.TrainningDay = trainningDay;
            trainningExercise.Id = id + 1;
            TrainningExercises.Add(trainningExercise);
            TrainningExerciseUpdated?.Invoke();
            return trainningExercise.Id;
        }

        public void EditById(TrainningExerciseVO trainningExerciseVO)
        {
            TrainningExercise trainning = TrainningExercises.Where(x => x.Id == trainningExerciseVO.Id).FirstOrDefault();
            if (trainning == null) return;

            TrainningExercises.Remove(trainning);
            DbMusclesAndExercises muscleExercise = new DbMusclesAndExercises();
            Exercise exercise = muscleExercise.Exercises.Where(x => x.Id == trainningExerciseVO.ExerciseId).FirstOrDefault();

            TrainningExercise trainningExercise = TrainningExerciseVOToEntitie(trainningExerciseVO);
            trainningExercise.TrainningDay = trainning.TrainningDay;
            trainningExercise.ExerciseId = exercise.Id;
            //trainningExercise.Exercise = trainning.Exercise;
            trainningExercise.Exercise = exercise;
            trainningExercise.Ordenation = trainning.Ordenation;
            TrainningExercises.Add(trainningExercise);
            TrainningExercises.OrderBy(x => x.Ordenation);
            TrainningExerciseUpdated?.Invoke();

        } 

        public bool RemoveById(int exerciseId)
        {
            TrainningExercise exercise = TrainningExercises.Where(x => x.Id == exerciseId).FirstOrDefault();
            if(exercise == null) return false;

            TrainningExercises.Remove(exercise);
            TrainningExerciseUpdated?.Invoke();

            return true;
        }

        public DbTrainningExercise(DbMusclesAndExercises musclesAndExercises) 
        {
            _musclesAndExercises = musclesAndExercises ?? throw new ArgumentNullException(nameof(musclesAndExercises));
            //_trainningDay = trainningDay ?? throw new ArgumentNullException(nameof(trainningDay));

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
