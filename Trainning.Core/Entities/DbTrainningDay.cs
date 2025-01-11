using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO;
using TrainningApp.Core.DTO.TrainningDay;
using TrainningApp.Core.DTO.TrainningExercise;

namespace TrainningApp.Core.Entities
{
    public class DbTrainningDay
    {
        public List<TrainningDay> TrainningDays { get; set; }

        private readonly DbMusclesAndExercises _musclesAndExercises;
        private readonly DbTrainningExercise _trainningExercise;

        public event Action TrainningDaysUpdated;


        public TrainningDayReturnVO TrainningDayToVO(TrainningDay trainningDay)
        {
            TrainningDayReturnVO trainningVO =  new TrainningDayReturnVO
            {
                Name = trainningDay.Name,
                Id = trainningDay.Id
                

            };
            return trainningVO;
        }

        public TrainningDay AddNewTrainningDay(string letter, int trainningId)
        {
            int id = TrainningDays.Max(x => x.Id) + 1;
            
            TrainningDay trainningDay = new TrainningDay()
            {
                Id = id,
                Name = letter,
                TrainningExercises = new List<TrainningExercise>(),
                TrainningId = trainningId
            };
            TrainningDays.Add(trainningDay);
            TrainningDaysUpdated?.Invoke();
            return trainningDay;
        }

        public void AddNewExercise(int trainningDayId, int trainningExerciseId)
        {
            

            TrainningExercise trainningExercise = _trainningExercise.TrainningExercises.Where(x => x.Id == trainningExerciseId).FirstOrDefault();

            TrainningDay trainningDay = TrainningDays.Where(x => x.Id == trainningDayId).FirstOrDefault();
            if (trainningDay != null)
            {
                trainningDay.TrainningExercises.Add(trainningExercise);
            }

            TrainningDaysUpdated?.Invoke();
        }

        public bool RemoveById(int trainningDayId, bool? isOnlyOneTrainning = false)
        {
            var trainningDay = TrainningDays.FirstOrDefault(x => x.Id == trainningDayId);
            if (trainningDay == null) return false;

            if(trainningDay.Name == "A" && isOnlyOneTrainning == true)
            {
                trainningDay.TrainningExercises = new List<TrainningExercise>();
                TrainningDaysUpdated?.Invoke(); // Notifica a alteração
                return true;
            }
            TrainningDays.Remove(trainningDay);
            char newLetter = 'A';
            foreach (var trainnDay in TrainningDays)
            {
                if (trainnDay.TrainningId == trainningDay.TrainningId)
                {
                    trainnDay.Name = newLetter.ToString();
                    newLetter++;
                }

            }
            TrainningDaysUpdated?.Invoke(); // Notifica a alteração
            return true;
        }

        public List<TrainningDayReturnVO> TrainningDaysToVOList(List<TrainningDay> trainningDays)
        {
            return trainningDays.Select(trainningDay => new TrainningDayReturnVO
            {
                Name = trainningDay.Name,
                Id = trainningDay.Id,
                Ordenation = trainningDay.Ordenation,
                TrainningExercises = _trainningExercise.TrainningExerciseTOListVO(trainningDay.TrainningExercises),
                TrainningId = trainningDay.TrainningId
            }).ToList();
        }

        public void UpdateTrainningExercise()
        {


            // Atualiza os TrainningDays para refletir qualquer mudança
            foreach (var trainning in TrainningDays)
            {
                trainning.TrainningExercises = _trainningExercise.TrainningExercises
                   .Where(td => trainning.TrainningExercises.Select(t => t.Id).Contains(td.Id))
                   .ToList();

               
            }

        }


        public DbTrainningDay(DbTrainningExercise trainningExercise, DbMusclesAndExercises musclesAndExercises)
        {

            _trainningExercise = trainningExercise ?? throw new ArgumentNullException(nameof(trainningExercise));
            _musclesAndExercises = musclesAndExercises ?? throw new ArgumentNullException(nameof(musclesAndExercises));

            _trainningExercise.TrainningExerciseUpdated += UpdateTrainningExercise;

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
                    TrainningId = 1,
                    TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.Id == 4 || x.Id == 5).ToList()
                },
                new TrainningDay
                {
                    Id = 3,
                    Name = "C",
                    Ordenation = 3,
                    TrainningId = 1,
                    TrainningExercises =  _trainningExercise.TrainningExercises.Where(x => x.Id == 6 || x.Id == 7 || x.Id == 8 || x.Id == 9).ToList()
                },
                   new TrainningDay
                {
                    Id = 4,
                    Name = "A",
                    Ordenation = 2,
                    TrainningId = 2,
                    TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.Id == 10 || x.Id == 11).ToList()
                },
                      new TrainningDay
                {
                    Id = 5,
                    Name = "B",
                    Ordenation = 2,
                    TrainningId = 2,
                    TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.Id == 12).ToList()
                },
                new TrainningDay
                    {
                        Id = 6,
                        Name = "A",
                        Ordenation = 1,
                        TrainningId = 5,
                        TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.TrainningDayId == 6).ToList()
                    },
                    new TrainningDay
                    {
                        Id = 7,
                        Name = "B",
                        Ordenation = 1,
                        TrainningId = 5,
                        TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.TrainningDayId == 7).ToList()
                    },
                     new TrainningDay
                    {
                        Id = 8,
                        Name = "C",
                        Ordenation = 1,
                        TrainningId = 5,
                        TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.TrainningDayId == 8).ToList()
                    },

            };

            TrainningDays.Select(x => x.TrainningExercises.OrderBy(x => x.Ordenation)).ToList();
        }
    }
}           
        
    

