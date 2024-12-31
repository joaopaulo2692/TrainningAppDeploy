using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO;
using TrainningApp.Core.DTO.Trainning;
using TrainningApp.Core.DTO.TrainningDay;
using TrainningApp.Core.DTO.TrainningExercise;

namespace TrainningApp.Core.Entities
{
    public class DbTrainning
    {
        public List<Trainning> Trainnings { get; set; }



        private readonly DbUsers _dbUsers;
        private readonly DbTrainningDay _trainningDay;
        private readonly DbTrainningExercise _trainningExercise;



        public TrainningReturnVO TrainningToTrainningVO(Trainning trainning)
        {
            TrainningReturnVO trainningDayReturnVO = new TrainningReturnVO()
            {
                Id = trainning.Id,
                Activate = trainning.Activate,
                CreatedAt = trainning.CreatedAt,
                FrequencyWeekly = trainning.FrequencyWeekly,
                Gender = trainning.Gender,
                Goal = trainning.Goal,
                Level = trainning.Level,
                Name = trainning.Name,
                Observation = trainning.Observation,
                PersonalName = trainning.Personal.Name,
                TrainningDays = _trainningDay.TrainningDaysToVOList(trainning.TrainningDays)
            };

            return trainningDayReturnVO;
        }

        public List<TrainningReturnVO> TrainningToTrainningVOList()
        {
            return Trainnings.Select(trainning => new TrainningReturnVO
            {
                Id = trainning.Id,
                Activate = trainning.Activate,
                CreatedAt = trainning.CreatedAt,
                FrequencyWeekly = trainning.FrequencyWeekly,
                Gender = trainning.Gender,
                Goal = trainning.Goal,
                Level = trainning.Level,
                Name = trainning.Name,
                Observation = trainning.Observation,
                PersonalName = trainning.Personal?.Name,
                TrainningDays = _trainningDay.TrainningDaysToVOList(trainning.TrainningDays)
            }).ToList();
        }

        //private void UpdateTrainningDays()
        //{
        //    // Atualiza os TrainningDays para refletir qualquer mudança
        //    foreach (var trainning in Trainnings)
        //    {
        //        trainning.TrainningDays = _trainningDay.TrainningDays
        //            .Where(td => trainning.TrainningDays.Select(t => t.Id).Contains(td.Id))
        //            .ToList();
        //    }
        //}


        public void AddTrainningDay(TrainningDay trainningDay, int trainningId)
        {
            Trainning trainning = Trainnings.Where(x => x.Id == trainningId).FirstOrDefault();

            trainning.TrainningDays.Add(trainningDay);
        }

        private void UpdateTrainningDays()
        {
            foreach (var trainning in Trainnings)
            {
                trainning.TrainningDays = _trainningDay.TrainningDays
                    .Where(td => trainning.TrainningDays.Any(t => t.Id == td.Id))
                    .Select(td =>
                    {
                        td.TrainningExercises = _trainningExercise.TrainningExercises
                            .Where(te => td.TrainningExercises.Any(t => t.Id == te.Id))
                            .ToList();
                        return td;
                    })
                    .ToList();
            }
        }


        public TrainningReturnVO GetById(int trainningId)
        {
            Trainning trainning = Trainnings.Where(x => x.Id == trainningId).FirstOrDefault();
            if (trainning == null) return new TrainningReturnVO();
            if (trainning.TrainningDays == null || trainning.TrainningDays.Count == 0)
            {

                trainning.TrainningDays = new List<TrainningDay>()
                {
                    new TrainningDay()
                    {
                        Name = "A",
                        Ordenation = 1,
                        TrainningExercises = new List<TrainningExercise>(),
                    }

                };
            }
            return TrainningToTrainningVO(trainning);
        }

        public DbTrainning(DbUsers dbUsers, DbTrainningDay trainningDay, DbTrainningExercise trainningExercise)
        {
            _dbUsers = dbUsers ?? throw new ArgumentNullException(nameof(dbUsers));
            _trainningDay = trainningDay ?? throw new ArgumentNullException(nameof(trainningDay));
            _trainningExercise = trainningExercise ?? throw new ArgumentNullException(nameof(trainningExercise));


            _trainningDay.TrainningDaysUpdated += UpdateTrainningDays;


            Trainnings = new List<Trainning>{
            new Trainning()
            {
                Id = 1,
                CreatedAt = new DateTime(2024, 11, 20),
                Goal = "Hipertrofia",
                Name = "Treino 2024",
                Personal = _dbUsers.Personals.Where(x => x.Id == "1").FirstOrDefault(),
                Activate = true,
                TrainningDays = _trainningDay.TrainningDays.Where(x => x.Id == 1 || x.Id == 2 || x.Id == 3).ToList(),

            },
             new Trainning()
            {
                 Id = 2,
                CreatedAt = new DateTime(2024, 10, 5),
                Goal = "Emagrecimento",
                Name = "Treino ABC",
                Personal = _dbUsers.Personals.Where(x => x.Id == "2").FirstOrDefault(),
                Activate = false,
                TrainningDays = _trainningDay.TrainningDays.Where(x => x.Id == 4).ToList(),
            },
             new Trainning()
            {
                 Id = 3,
                CreatedAt = new DateTime(2024, 9, 4),
                Goal = "Condicionamento",
                Name = "Treino AB",
                 Personal = _dbUsers.Personals.Where(x => x.Id == "3").FirstOrDefault(),
                Activate = false,
                TrainningDays = new List<TrainningDay>()
            },

        };
            foreach (var trainning in Trainnings)
            {
                foreach (var trainningDayIndex in trainning.TrainningDays)
                {
                    trainningDayIndex.TrainningExercises = trainningDayIndex.TrainningExercises
                        .OrderBy(x => x.Ordenation)
                        .ToList();
                }
            }



        }
    }
}
