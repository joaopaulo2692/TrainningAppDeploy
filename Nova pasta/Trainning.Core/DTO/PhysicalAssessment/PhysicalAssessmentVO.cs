using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.DTO.PhysicalAssessment
{
    public class PhysicalAssessmentVO
    {
        public int Id { get; set; }

        // Informações pessoais
        public string PersonalName { get; set; }

        // Medidas gerais
        public decimal Height { get; set; } // em metros (ex: 1.75)
        public decimal Weight { get; set; } // em quilogramas (ex: 70.5)

        // Circunferências corporais (em centímetros)
        public decimal Chest { get; set; } // Peitoral
        public decimal Waist { get; set; } // Cintura
        public decimal Hips { get; set; } // Quadril
        public decimal Neck { get; set; } // Pescoço

        // Medidas dos membros superiores
        public decimal RightArmRelaxed { get; set; } // Braço direito relaxado
        public decimal LeftArmRelaxed { get; set; } // Braço esquerdo relaxado
        public decimal RightArmFlexed { get; set; } // Braço direito flexionado
        public decimal LeftArmFlexed { get; set; } // Braço esquerdo flexionado
        public decimal RightForearm { get; set; } // Antebraço direito
        public decimal LeftForearm { get; set; } // Antebraço esquerdo

        // Medidas dos membros inferiores
        public decimal RightThigh { get; set; } // Coxa direita
        public decimal LeftThigh { get; set; } // Coxa esquerda
        public decimal RightCalf { get; set; } // Panturrilha direita
        public decimal LeftCalf { get; set; } // Panturrilha esquerda

        // Outras informações importantes
        public decimal BodyFatPercentage { get; set; } // Porcentagem de gordura corporal
        public DateTime? AssessmentDate { get; set; } // Data da avaliação
    }

}
