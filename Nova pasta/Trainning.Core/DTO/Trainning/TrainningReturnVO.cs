using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.TrainningDay;

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
    }
}
