using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.DTO
{
    public class TrainningVO
    {
        public int Id { get; set; }
        public string Goal { get; set; }
        public List<string> UsersId { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
    }
}
