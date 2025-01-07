using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.Constants
{
    public static class Constants
    {
        public static string GetUrlHome()
        {
            return "/TrainningAppDeploy/";
        }
        public static string GetUrlForCustomer(string userId)
        {
            //return $"/aluno/{userId}";
            return $"/TrainningAppDeploy/aluno/{userId}";
        }

        public static string GetUrlForTrainning(string userId, int trainningId)
        {
            //return $"/aluno/{userId}/treinos/{trainningId}";
            return $"/TrainningAppDeploy/aluno/{userId}/treinos/{trainningId}";
        }

        public static string GetUrlForTrainningLibrary(int trainningId)
        {
            //return $"/treinos/{trainningId}";
            return $"/TrainningAppDeploy/treinos/{trainningId}";
        }


        ///////////////////// LOCAL HOST //////////////////////////////

        //public static string GetUrlHome()
        //{
        //    return "/";
        //}

        //public static string GetUrlForCustomer(string userId)
        //{
        //    return $"/aluno/{userId}";

        //}

        //public static string GetUrlForTrainning(string userId, int trainningId)
        //{
        //    return $"/aluno/{userId}/treinos/{trainningId}";
     
        //}

        //public static string GetUrlForTrainningLibrary(int trainningId)
        //{
        //    return $"/treinos/{trainningId}";
     
        //}
    }

}
