using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.DTO.Exercise
{
    public class ExerciseReturnVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Video { get; set; }
        public virtual List<string> Muscles { get; set; }
        public string Level { get; set; }
    }
}
