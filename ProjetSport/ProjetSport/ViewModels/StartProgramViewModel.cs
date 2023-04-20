using ProjetSport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.ViewModels
{
    public class StartProgramViewModel
    {
        public int UserId { get; private set; }
        public int IdProgram { get; private set; }

        public StartProgramViewModel(int userId, int idProgram)
        {
            UserId = userId;
            IdProgram = idProgram;
        }

        public async Task StartProgramAsync()
        {
            bool succes = await ActiviteService.AddActivityAsync(UserId, IdProgram);
            if (succes)
            {

            }
            else
            {

            }
        }
    }
}
