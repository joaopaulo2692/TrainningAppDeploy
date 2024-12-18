using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainningApp.Core.DTO.Exercise;
using TrainningApp.Core.DTO.Muscle;
using TrainningApp.Core.DTO.Trainning;
using TrainningApp.Core.DTO.TrainningDay;
using TrainningApp.Core.DTO.TrainningExercise;
using TrainningApp.Core.DTO.User;

namespace TrainningApp.Core.Entities
{
    public class DbMusclesAndExercises
    {
        public List<Muscle> Muscles { get; set; }
        public List<Exercise> Exercises { get; set; }

        public List<MuscleVO> MuscleToDTO()
        {
            return Muscles.Select(x => new MuscleVO
            {
                Id = x.Id,
                Name = x.Name


            }).ToList();
        }

        public List<ExerciseVO> ExercisesToDTO()
        {
            return Exercises.Select(x => new ExerciseVO
            {
                Id = x.Id,
                Name = x.Name,
                Muscles = x.Muscles.Select(x => x.Name).ToList()

            }).ToList();
        }

        public Exercise ExerciseVOToExercise(ExerciseVO exerciseVO)
        {
            return new Exercise()
            {
                Video = exerciseVO.Video,
                Name = exerciseVO.Name,
                //Muscles = Muscles.Where(x => x.Name.Contains(exerciseVO.Muscles)).ToList()
                Muscles = Muscles.Where(x => exerciseVO.Muscles.Contains(x.Name)).ToList(),
                Description = exerciseVO.Description,
                Level = exerciseVO.Level
                

            };
        }

        public Muscle MuscleVOToMuscle(MuscleVO muscleVO)
        {
            return new Muscle()
            {
                Exercises = Exercises.Where(x => x.Muscles.Select(x => x.Name).Contains(muscleVO.Name)).ToList(),
                Name = muscleVO.Name,
                Id = muscleVO.Id
            };
        }

        public bool AddMuscle(MuscleVO muscleVO)
        {
            if(Muscles.Select(x => x.Name).Contains(muscleVO.Name))
            {
                return false;
            }

            Muscle newMuscle = MuscleVOToMuscle(muscleVO);
            newMuscle.Id = Muscles.LastOrDefault().Id + 1;
            if(newMuscle != null)
            {
                Muscles.Add(newMuscle);
                return true;
            }
            return false;
        }

        public bool AddExercise(ExerciseVO exerciseVO)
        {
            if (Exercises.Select(x => x.Name).Contains(exerciseVO.Name))
            {
                return false;
            }

            Exercise newExercise = ExerciseVOToExercise(exerciseVO);
            newExercise.Id = Exercises.Max(e => e.Id) + 1;
            if (newExercise != null)
            {
                Exercises.Add(newExercise);
                return true;
            }
            return false;
        }

        public bool EditExercise(ExerciseVO exerciseVO)
        {
            Exercise exercise = Exercises.Where(x => x.Id == exerciseVO.Id).FirstOrDefault();
            if (exercise == null) return false;

            Exercises.Remove(exercise);
            Exercise exerciseToSave = ExerciseVOToExercise(exerciseVO);

            exercise.Muscles = exerciseToSave.Muscles;
            exercise.Description = exerciseToSave.Description;
            exercise.Level = exerciseToSave.Level;
            exercise.Name = exerciseToSave.Name;
            exercise.Video = exerciseToSave.Video;
            Exercises.Add(exercise);

            Exercises.OrderBy(x => x.Name);
            return true;
        }

        public bool RemoveExercise(ExerciseVO exerciseVO)
        {
            Exercise exercise = Exercises.Where(x => x.Id == exerciseVO.Id).FirstOrDefault();
            if (exercise == null) return false;

            Exercises.Remove(exercise);
            return true;
        }

        public DbMusclesAndExercises()
        {
            Muscles = new List<Muscle>()
            {
                  new Muscle { Id = 1, Name = "Abdômen" },
                  new Muscle { Id = 4, Name = "Alongamento" },
                  new Muscle { Id = 5, Name = "Antebraço" },
                  new Muscle { Id = 6, Name = "Aquecimento" },
                  new Muscle { Id = 7, Name = "Bíceps" },
                  new Muscle { Id = 10, Name = "Core" },
                  new Muscle { Id = 11, Name = "Dorsal" },
                  new Muscle { Id = 13, Name = "Glúteo" },
                  new Muscle { Id = 14, Name = "Lombar" },
                  new Muscle { Id = 18, Name = "Ombro" },
                  new Muscle { Id = 19, Name = "Outros" },
                  new Muscle { Id = 20, Name = "Panturrilha" },
                  new Muscle { Id = 21, Name = "Peito" },
                  new Muscle { Id = 22, Name = "Perna" },
                  new Muscle { Id = 23, Name = "Punho" },
                  new Muscle { Id = 24, Name = "Quadril" },
                  new Muscle { Id = 26, Name = "Tornozelo" },
                  new Muscle { Id = 27, Name = "Trapézio" },
                  new Muscle { Id = 28, Name = "Tríceps" }
            };


            Exercises = new List<Exercise>
            {
                new Exercise
                {
                    Id = 1,
                    Name = "Supino",
                    Muscles = Muscles.Where(m => m.Id == 21 || m.Id == 28).ToList()
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Agachamento",
                    Muscles = Muscles.Where(m => m.Id == 22).ToList()
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Rosca Direta",
                    Muscles = Muscles.Where(m => m.Id == 7).ToList()
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Levantamento Terra",
                    Muscles = Muscles.Where(m => m.Id == 11 || m.Id == 13 || m.Id == 22).ToList()
                },
                new Exercise
                {
                    Id = 5,
                    Name = "Desenvolvimento com Halteres",
                    Muscles = Muscles.Where(m => m.Id == 18 || m.Id == 28).ToList()
                },
                new Exercise
                {
                    Id = 6,
                    Name = "Remada Curvada",
                    Muscles = Muscles.Where(m => m.Id == 11 || m.Id == 7).ToList()
                },
                new Exercise
                {
                    Id = 7,
                    Name = "Cadeira Extensora",
                    Muscles = Muscles.Where(m => m.Id == 22).ToList()
                },
                new Exercise
                {
                    Id = 8,
                    Name = "Flexão de Braço",
                    Muscles = Muscles.Where(m => m.Id == 21 || m.Id == 28 || m.Id == 18).ToList()
                },
                new Exercise
                {
                    Id = 9,
                    Name = "Crucifixo",
                    Muscles = Muscles.Where(m => m.Id == 21).ToList()
                },
                new Exercise
                {
                    Id = 10,
                    Name = "Abdominal",
                    Muscles = Muscles.Where(m => m.Id == 1).ToList()
                }
            };
        }
    }

    

   
}
