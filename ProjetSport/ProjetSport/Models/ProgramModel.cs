using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.Models
{
    public class ProgramModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgramDescription { get; set; }
        public bool IsActive { get; set; }
        public int? NbCalorie { get; set; }
    }
}
