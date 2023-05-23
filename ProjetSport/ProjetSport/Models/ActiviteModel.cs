using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.Models
{
    class ActiviteModel
    {
        public int UserId { get; set; }
        public string NameExercice { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Attempt { get; set; }
    }
}
