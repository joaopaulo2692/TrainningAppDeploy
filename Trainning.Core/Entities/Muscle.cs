using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Entities
{
    public class Muscle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Exercise> Exercises { get; set; }
    }
}
