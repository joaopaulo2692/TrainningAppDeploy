using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.DTO.Muscle
{
    public class MuscleVO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<string> exercisesName { get; set; }
        public virtual List<int> exerciseIds { get; set; }
    }
}
