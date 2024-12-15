using Microsoft.JSInterop;
using TrainningApp.Core.DTO.TrainningExercise;

namespace TrainningDeploy.Service
{
    public class OrdenationService
    {
        [JSInvokable("UpdateOrdenation")]
        public void UpdateOrdenation(string[] newOrder)
        {
            List<TrainningExerciseVO> exercises = new List<TrainningExerciseVO>
        {
            new TrainningExerciseVO { Reps = "10", Set = 3, ExerciseName = "Supino", Info = "Normal", Ordenation = 1 },
            new TrainningExerciseVO { Reps = "10", Set = 3, ExerciseName = "Supino reto", Info = "Normal", Ordenation = 2 },
            new TrainningExerciseVO { Reps = "10", Set = 3, ExerciseName = "Supino inclinado", Info = "Normal", Ordenation = 3 }
        };
            for (int i = 0; i < newOrder.Length; i++)
            {
                var item = exercises.FirstOrDefault(x => x.Ordenation.ToString() == newOrder[i]);
                if (item != null)
                {
                    item.Ordenation = i + 1; // Atualiza a ordenação
                }
            }

            // Reordena a lista na memória
            exercises = exercises.OrderBy(x => x.Ordenation).ToList();

            // Atualiza a interface
            //StateHasChanged();
        }
    }
}
