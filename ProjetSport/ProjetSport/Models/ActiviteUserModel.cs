using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.Models
{
    public class ActiviteUserModel
    {
        public int UserId { get; set; }

        public int IdProgram { get; set; }

        public int IdExercice { get; set; }

        public int AttemptId { get; set; }
        public DateTime Date { get; set; }

        public int NbRealise { get; set; }

        public TimeSpan TimeElapsed { get; set; }
    }
}
