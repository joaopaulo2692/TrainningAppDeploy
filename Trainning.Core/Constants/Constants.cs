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

        public static string GetAllCustomer()
        {
            return $"/TrainningAppDeploy/alunos";

        }

        public static string GetAllTrainning()
        {
            return $"/TrainningAppDeploy/treinos";

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

        public static string GetUrlForAllTrainning(string userId)
        {
            //return $"/aluno/{userId}/treinos/{trainningId}";
            return $"/TrainningAppDeploy/aluno/{userId}/treinos";
        }

        public static string GetUrlForTrainningLibrary(int trainningId)
        {
            //return $"/treinos/{trainningId}";
            return $"/TrainningAppDeploy/treinos/{trainningId}";
        }

        public static string GetUrlForPhysicalAssessment(string userId)
        {
            //return $"/treinos/{trainningId}";
            return $"/TrainningAppDeploy/aluno/{userId}/avaliacao/";
        }

        public static string GetAllPersonals()
        {
            return $"/TrainningAppDeploy//personais";

        }


        public static string GetUrlForPersonal(string userId)
        {
            return $"/TrainningAppDeploy/personal/{userId}";

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


        //public static string GetAllCustomer()
        //{
        //    return $"/alunos";

        //}

        //public static string GetAllTrainning()
        //{
        //    return $"/treinos";

        //}

        //public static string GetAllPersonals()
        //{
        //    return $"/personais";

        //}


        //public static string GetUrlForPersonal(string userId)
        //{
        //    return $"/personal/{userId}";

        //}

        //public static string GetUrlForTrainning(string userId, int trainningId)
        //{
        //    return $"/aluno/{userId}/treinos/{trainningId}";

        //}

        //public static string GetUrlForTrainningLibrary(int trainningId)
        //{
        //    return $"/treinos/{trainningId}";

        //}

        //public static string GetUrlForAllTrainning(string userId)
        //{
        //    //return $"/aluno/{userId}/treinos/{trainningId}";
        //    return $"/aluno/{userId}/treinos";
        //}

        //public static string GetUrlForPhysicalAssessment(string userId)
        //{

        //    return $"/aluno/{userId}/avaliacao/";
        //}

    }
}
