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
        public List<Trainning> TrainningsLibrary { get; set; }



        private readonly DbUsers _dbUsers;
        private readonly DbTrainningDay _trainningDay;
        private readonly DbTrainningExercise _trainningExercise;


        public void CheckActivateAndDisable(Trainning trainning)
        {
            List<Trainning> trainningsByUser = Trainnings
            .Where(x => x.User != null && x.User.Id == trainning.User.Id)
            .ToList();

            Trainning trainningActivate = trainningsByUser.Where(x => x.Activate == true).FirstOrDefault();

            if(trainningActivate != trainning && trainning.Activate)
            {
                trainningActivate.Activate = false;
            }
        }
        

        public void UpdateTrainningInfo(TrainningReturnVO trainningVO)
        {
            if (trainningVO == null)
                throw new ArgumentNullException(nameof(trainningVO));

            // Localiza o Trainning na lista pelo ID
            var trainning = Trainnings.FirstOrDefault(x => x.Id == trainningVO.Id);
           


            if (trainning != null)
            {
                trainning.Activate = trainningVO.Activate;
                if (!trainning.IsLibrary)
                {
                    CheckActivateAndDisable(trainning);
                }
               
                // Atualiza as propriedades do Trainning existente              
                trainning.Type = trainningVO.Type;
                trainning.FrequencyWeekly = trainningVO.FrequencyWeekly;
                trainning.Gender = trainningVO.Gender;
                trainning.Goal = trainningVO.Goal;
                trainning.Level = trainningVO.Level;
                trainning.Name = trainningVO.Name;
                trainning.Observation = string.IsNullOrEmpty(trainningVO.Observation) ? null : trainningVO.Observation;
                trainning.Personal = !string.IsNullOrEmpty(trainningVO.PersonalName)
                    ? _dbUsers.Personals.FirstOrDefault(x => x.Name == trainningVO.PersonalName)
                    : null;

                //if (trainningVO.TrainningDays != null)
                //{
                //    trainning.TrainningDays = _trainningDay.TrainningDaysVOToList(trainningVO.TrainningDays);
                //}
            }
        }

        public Trainning TrainningVOToTrainning(TrainningReturnVO trainningReturnVO)
        {
            if (trainningReturnVO == null)
                throw new ArgumentNullException(nameof(trainningReturnVO));

            var trainning = new Trainning()
            {
                Type = trainningReturnVO.Type,
                Id = trainningReturnVO.Id,
                Activate = trainningReturnVO.Activate,
                CreatedAt = trainningReturnVO.CreatedAt,
                FrequencyWeekly = trainningReturnVO.FrequencyWeekly,
                Gender = trainningReturnVO.Gender,
                Goal = trainningReturnVO.Goal,
                Level = trainningReturnVO.Level,
                Name = trainningReturnVO.Name,
                Observation = string.IsNullOrEmpty(trainningReturnVO.Observation) ? null : trainningReturnVO.Observation,
                Personal = !string.IsNullOrEmpty(trainningReturnVO.PersonalName)
                    ? _dbUsers.Personals.Where(x => x.Name == trainningReturnVO.PersonalName).FirstOrDefault() : new ApplicationUser(),
            };

            return trainning;
        }

        public int AddTrainning(Trainning trainning)
        {
            
            int id = Trainnings.Max(x => x.Id);
            id++;
            trainning.Id = id;
            trainning.CreatedAt = DateTime.Now;
            Trainnings.Add(trainning);
            CheckActivateAndDisable(trainning);
            return id;
        }

        public TrainningReturnVO AddNewTrainning(string? userId, bool isLibrary = false)
        {
            int id = Trainnings.Max(x => x.Id);
            id++;
            ApplicationUser user = _dbUsers.Customers.Where(x => x.Id == userId).FirstOrDefault();
            TrainningDay trainningDay = _trainningDay.AddNewTrainningDay("A", id);
            List<TrainningDay> trainningDayList = new List<TrainningDay>() { trainningDay };
            Trainning newTrainning = new Trainning()
            {
                Id = id,
                User = user,
                TrainningDays = trainningDayList,
                CreatedAt = DateTime.Now,
                IsLibrary = isLibrary
            };
            
            Trainnings.Add(newTrainning);

            return TrainningToTrainningVO(newTrainning);
        }

        public TrainningReturnVO TrainningToTrainningVO(Trainning trainning)
        {
            TrainningReturnVO trainningDayReturnVO = new TrainningReturnVO()
            {
                Type = trainning.Type,
                Id = trainning.Id,
                Activate = trainning.Activate,
                CreatedAt = trainning.CreatedAt,
                FrequencyWeekly = trainning.FrequencyWeekly,
                Gender = trainning.Gender,
                Goal = trainning.Goal,
                Level = trainning.Level,
                Name = trainning.Name,
                Observation = trainning.Observation != null ? trainning.Observation : string.Empty ,
                PersonalName = trainning.Personal != null ? trainning.Personal.Name : string.Empty,
                TrainningDays = trainning.TrainningDays != null ?_trainningDay.TrainningDaysToVOList(trainning.TrainningDays) : new List<TrainningDayReturnVO>()
            };

            return trainningDayReturnVO;
        }

        public List<TrainningReturnVO> TrainningListToTrainningVOList(List<Trainning> trainnings)
        {
            var trainningReturnVOList = new List<TrainningReturnVO>();

            foreach (var trainning in trainnings)
            {
                var trainningReturnVO = new TrainningReturnVO()
                {
                    Type = trainning.Type,
                    Id = trainning.Id,
                    Activate = trainning.Activate,
                    CreatedAt = trainning.CreatedAt,
                    FrequencyWeekly = trainning.FrequencyWeekly,
                    Gender = trainning.Gender,
                    Goal = trainning.Goal,
                    Level = trainning.Level,
                    Name = trainning.Name,
                    Observation = trainning.Observation != null ? trainning.Observation : string.Empty,
                    PersonalName = trainning.Personal != null ? trainning.Personal.Name : string.Empty,
                    TrainningDays = trainning.TrainningDays != null ? _trainningDay.TrainningDaysToVOList(trainning.TrainningDays) : new List<TrainningDayReturnVO>()
                };

                trainningReturnVOList.Add(trainningReturnVO);
            }

            return trainningReturnVOList.OrderByDescending(x => x.Activate == true).ThenByDescending(x => x.CreatedAt).ToList();
        }


        public List<TrainningReturnVO> GetByCustomerId(string userId)
        {
            List<Trainning> trainnings = Trainnings.Where(x => x.User != null && x.User.Id == userId).ToList();
            return TrainningListToTrainningVOList(trainnings);
        }

        public List<TrainningReturnVO> TrainningToTrainningVOList()
        {
            return Trainnings.Select(trainning => new TrainningReturnVO
            {
                Type = trainning.Type,
                Id = trainning.Id,
                Activate = trainning.Activate,
                CreatedAt = trainning.CreatedAt,
                FrequencyWeekly = trainning.FrequencyWeekly,
                Gender = trainning.Gender,
                Goal = trainning.Goal,
                Level = trainning.Level,
                Name = trainning.Name,
                Observation = trainning.Observation != null ? trainning.Observation : string.Empty,
                PersonalName = trainning.Personal != null ? trainning.Personal.Name : string.Empty,
                TrainningDays = trainning.TrainningDays != null ? _trainningDay.TrainningDaysToVOList(trainning.TrainningDays) : new List<TrainningDayReturnVO>()
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

    //        TrainningsLibrary = new List<Trainning>
    //        {
    //           new Trainning
    //{
    //            Id = 1,
    //            CreatedAt = new DateTime(2024, 12, 10),
    //            Goal = "Condicionamento Físico",
    //            Name = "Treino ABC",
    //            Personal = _dbUsers.Personals.Where(x => x.Id == "1").FirstOrDefault(),
    //            Activate = true,
    //            TrainningDays =  _trainningDay.TrainningDays.Where(x => x.Id == 6 || x.Id == 7 || x.Id == 8).ToList(),
    //            Gender = "Masculino",
    //            Level = "Intermediário",
    //},
    //        };

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
                User = _dbUsers.Customers.Where(x => x.Id == "4").FirstOrDefault()

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
                User = _dbUsers.Customers.Where(x => x.Id == "4").FirstOrDefault()
            },
             new Trainning()
            {
                 Id = 3,
                CreatedAt = new DateTime(2024, 9, 4),
                Goal = "Condicionamento",
                Name = "Treino AB",
                 Personal = _dbUsers.Personals.Where(x => x.Id == "3").FirstOrDefault(),
                Activate = false,
                TrainningDays = new List<TrainningDay>(),
                User = _dbUsers.Customers.Where(x => x.Id == "4").FirstOrDefault()
            },

             new Trainning()
            {
                Id = 4,
                CreatedAt = new DateTime(2024, 11, 20),
                Goal = "Hipertrofia",
                Name = "Treino 2024",
                Personal = _dbUsers.Personals.Where(x => x.Id == "1").FirstOrDefault(),
                Activate = true,
                TrainningDays = _trainningDay.TrainningDays.Where(x => x.Id == 1 || x.Id == 2 || x.Id == 3).ToList(),
                User = _dbUsers.Customers.Where(x => x.Id == "5").FirstOrDefault()

            },
                        new Trainning
    {
                Id = 5,
                CreatedAt = new DateTime(2024, 12, 10),
                Goal = "Condicionamento Físico",
                Name = "Treino ABC",
                Personal = _dbUsers.Personals.Where(x => x.Id == "1").FirstOrDefault(),
                Activate = true,
                TrainningDays =  _trainningDay.TrainningDays.Where(x => x.Id == 6 || x.Id == 7 || x.Id == 8).ToList(),
                Gender = "Masculino",
                Level = "Intermediário",
                IsLibrary = true,
                User = new ApplicationUser()
    },
                                              new Trainning
    {
                Id = 6,
                CreatedAt = new DateTime(2024, 12, 10),
                Goal = "Condicionamento Físico",
                Name = "Treino 2025",
                Personal = _dbUsers.Personals.Where(x => x.Id == "1").FirstOrDefault(),
                Activate = true,
                TrainningDays =  _trainningDay.TrainningDays.Where(x => x.Id == 1 || x.Id == 2 || x.Id == 3).ToList(),
                Gender = "Feminino",
                Level = "Intermediário",
                IsLibrary = true,
                User = new ApplicationUser()
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
