using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.Trainning;
using TrainningApp.Core.DTO.TrainningDay;
using TrainningApp.Core.DTO.TrainningExercise;

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
        public string Name { get; set; }
        public int FrequencyWeekly { get; set; }
        public string Observation {  get; set; }
        public bool Activate { get; set; }
        public string? Gender { get; set; }
        public int ManagementId { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
        public virtual ApplicationUser Personal { get; set; }

        public virtual List<TrainningDay> TrainningDays { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual Management Management { get; set; }

        //public virtual List<TrainningExercise> TrainningExercises { get; set; }


        public List<Trainning> TrainningList()
        {
            return new List<Trainning>{
            new Trainning()
            {
                Id = 1,
                CreatedAt = new DateTime(2024, 11, 20),
                Goal = "Hipertrofia",
                Name = "Treino 2024",
                PersonalId = "1",
                Activate = true,
                TrainningDays = new List<TrainningDay>()
                {
                    new TrainningDay
                    {
                        Name = "A",
                        Ordenation = 1,
                        TrainningId = 1,
                        TrainningExercises = new List<TrainningExercise>
                        {
                            new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 1,
                                Info = "Normal",
                                Ordenation = 1,
                                TrainningDayId = 1
                            },
                            new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 2,
                                Info = "Normal",
                                Ordenation = 2,
                                TrainningDayId = 1
                            },
                             new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 3,
                                Info = "Normal",
                                Ordenation = 3,
                                TrainningDayId = 1
                            },
                        }
                    },
                    new TrainningDay
                    {
                        Name = "B",
                        Ordenation = 2,
                        TrainningId = 2,
                        TrainningExercises = new List<TrainningExercise>
                        {
                            new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 4,
                                Info = "Normal",
                                Ordenation = 1,
                                TrainningDayId = 1
                            },
                             new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 5,
                                Info = "Normal",
                                Ordenation = 2,
                                TrainningDayId = 1
                            },
                            new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 6,
                                Info = "Normal",
                                Ordenation = 3,
                                TrainningDayId = 1
                            },
                        }
                    },
                    new TrainningDay
                    {
                        Name = "C",
                        Ordenation = 3,
                        TrainningId = 3,
                        TrainningExercises = new List<TrainningExercise>
                        {
                            new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 7,
                                Info = "Normal",
                                Ordenation = 1,
                                TrainningDayId = 1
                            },
                         new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 8,
                                Info = "Normal",
                                Ordenation = 2,
                                TrainningDayId = 1
                            },
                            new TrainningExercise
                             {
                                Reps = "10",
                                Set = 3,
                                ExerciseId = 9,
                                Info = "Normal",
                                Ordenation = 3,
                                TrainningDayId = 1
                            },
                        }
                    }

                }
            },
             new Trainning()
            {
                 Id = 2,
                CreatedAt = new DateTime(2024, 10, 5),
                Goal = "Emagrecimento",
                Name = "Treino ABC",
                PersonalId = "2",
                Activate = false,
                TrainningDays = new List<TrainningDay>()
            },
             new Trainning()
            {
                 Id = 3,
                CreatedAt = new DateTime(2024, 9, 4),
                Goal = "Condicionamento",
                Name = "Treino AB",
                PersonalId = "3",
                Activate = false,
                TrainningDays = new List<TrainningDay>()
            },

        };

        }

    }
}
