using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Entities
{
    public class Management : BaseEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Trainning> Trainnings { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
    }
}
