using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.Models
{
    public class ProgramToExerciceModel
    {
        public string NameExercice { get; set; }
        public int IdExercice { get; set; }
        public string DescriptionExercice { get; set; }
        public string? Image { get; set; }
        public string NameProgram { get; set; }
        public TimeSpan TimeExercice { get; set; }

        public string ProgramDescription { get; set; }
        public IList<ProgramToExerciceModel> ProgramToExerciceModels { get; internal set; }
    }
}
