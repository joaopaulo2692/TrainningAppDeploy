using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Constants
{
    public static class Constants
    {
        public static string GetUrlForCustomer(string userId)
        {
            return $"/aluno/{userId}";
            //return $"/TrainningAppDeploy/aluno/{userId}";
        }

    }

}
