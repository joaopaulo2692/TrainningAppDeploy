using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.TrainningDay;
using TrainningApp.Core.DTO.TrainningExercise;

namespace TrainningApp.Core.DTO.Trainning
{
    public class TrainningReturnVO
    {
        public int Id { get; set; }
        public string Goal { get; set; }
        public string Name { get; set; }
        public string PersonalName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Level { get; set; }
        public int FrequencyWeekly { get; set; }
        public string Observation { get; set; }
        public string Gender { get; set; }
        public bool Activate { get; set; }
        public List<TrainningDayReturnVO> TrainningDays {  get; set; }



        public List<TrainningReturnVO> TrainningList()
        {
            return  new List<TrainningReturnVO>{
            new TrainningReturnVO()
            {
                Id = 1,
                CreatedAt = new DateTime(2024, 11, 20),
                Goal = "Hipertrofia",
                Name = "Treino 2024",
                PersonalName = "José",
                Activate = true,
                TrainningDays = new List<TrainningDayReturnVO>()
                {
                    new TrainningDayReturnVO
                    {
                        Name = "A",
                        Ordenation = 1,
                        TrainningId = 1,
                        TrainningExercises = new List<TrainningExerciseVO>
                        {
                            new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Supino reto",
                                Info = "Normal",
                                Ordenation = 1,
                                TrainningDayId = 1
                            },
                                                        new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Supino inclinado",
                                Info = "Normal",
                                Ordenation = 2,
                                TrainningDayId = 1
                            },
                                                        new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Supino declinado",
                                Info = "Normal",
                                Ordenation = 3,
                                TrainningDayId = 1
                            },
                        }
                    },
                    new TrainningDayReturnVO
                    {
                        Name = "B",
                        Ordenation = 2,
                        TrainningId = 2,
                        TrainningExercises = new List<TrainningExerciseVO>
                        {
                            new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Leg",
                                Info = "Normal",
                                Ordenation = 1,
                                TrainningDayId = 1
                            },
                                                        new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Cadeira",
                                Info = "Normal",
                                Ordenation = 2,
                                TrainningDayId = 1
                            },
                                                        new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Panturrilha",
                                Info = "Normal",
                                Ordenation = 3,
                                TrainningDayId = 1
                            },
                        }
                    },
                    new TrainningDayReturnVO
                    {
                        Name = "C",
                        Ordenation = 3,
                        TrainningId = 3,
                        TrainningExercises = new List<TrainningExerciseVO>
                        {
                            new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Pulley",
                                Info = "Normal",
                                Ordenation = 1,
                                TrainningDayId = 1
                            },
                                                        new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Peck Deck",
                                Info = "Normal",
                                Ordenation = 2,
                                TrainningDayId = 1
                            },
                                                        new TrainningExerciseVO
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseName = "Rosca direta",
                                Info = "Normal",
                                Ordenation = 3,
                                TrainningDayId = 1
                            },
                        }
                    }

                }
            },
             new TrainningReturnVO()
            {
                 Id = 2,
                CreatedAt = new DateTime(2024, 10, 5),
                Goal = "Emagrecimento",
                Name = "Treino ABC",
                PersonalName = "Fernando",
                Activate = false,
                TrainningDays = new List<TrainningDayReturnVO>()
            },
             new TrainningReturnVO()
            {
                 Id = 3,
                CreatedAt = new DateTime(2024, 9, 4),
                Goal = "Condicionamento",
                Name = "Treino AB",
                PersonalName = "Arthur",
                Activate = false,
                TrainningDays = new List<TrainningDayReturnVO>()
            },

        };

        }
    }
}
