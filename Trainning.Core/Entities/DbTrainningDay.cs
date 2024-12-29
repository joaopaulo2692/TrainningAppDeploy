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


        public TrainningDayVO TrainningDayToVO(TrainningDay trainningDay)
        {
           TrainningDayVO trainningVO =  new TrainningDayVO
            {
                Name = trainningDay.Name,
                Id = trainningDay.Id
                

            };
            return trainningVO;
        }

        

        public bool RemoveById(int trainningDayId)
        {
            var trainningDay = TrainningDays.FirstOrDefault(x => x.Id == trainningDayId);
            if (trainningDay == null) return false;

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

        //public bool RemoveById(int trainningDayId)
        //{
        //    TrainningDay trainningDay = TrainningDays.Where(x => x.Id == trainningDayId).FirstOrDefault();
        //    if (trainningDay == null) return false;

        //    TrainningDays.Remove(trainningDay);

        //    char newLetter = 'A';
        //    foreach (var trainnDay in TrainningDays)
        //    {
        //        if (trainnDay.TrainningId == trainningDay.TrainningId)
        //        {
        //            trainnDay.Name = newLetter.ToString();
        //            newLetter++;
        //        }

        //    }
        //    return true;
        //}
        public List<TrainningDayReturnVO> TrainningDaysToVOList(List<TrainningDay> trainningDays)
        {
            return trainningDays.Select(trainningDay => new TrainningDayReturnVO
            {
                Name = trainningDay.Name,
                Id = trainningDay.Id,
                Ordenation = trainningDay.Ordenation,
                TrainningExercises = _trainningExercise.TrainningExerciseTOListVO(trainningDay.TrainningExercises),
                TrainningId = trainningDay.Id
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
                    TrainningExercises = _trainningExercise.TrainningExercises.Where(x => x.Id == 4 || x.Id == 5).ToList()
                },
            };

            TrainningDays.Select(x => x.TrainningExercises.OrderBy(x => x.Ordenation)).ToList();
        }
    }
}           
        
    

