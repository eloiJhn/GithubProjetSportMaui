using Newtonsoft.Json;
using ProjetSport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.Services
{
    public static class ProgramService
    {
         readonly static string baseURI = "http://10.0.0.31:5033/api/Program";
        private static string GetDataFromApi(string url)
        {
            String response = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url); //Uri : classe qui permet de construire une URL 
            response = client.GetStringAsync(client.BaseAddress).Result;
            return response;
        }
        public static ObservableCollection<ProgramModel> GetPrograms()
        {
            try
            {
                var json = GetDataFromApi(baseURI);
                return JsonConvert.DeserializeObject<ObservableCollection<ProgramModel>>(json);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static ObservableCollection<ProgramToExerciceModel> GetExercicesIntoProgram(int id)
        {
            try
            {
                var json = GetDataFromApi(baseURI + "/ExerciceProgram/" + id);
                return JsonConvert.DeserializeObject<ObservableCollection<ProgramToExerciceModel>>(json);
            }
            catch (Exception e)
            {
                //var list = new ObservableCollection<ProgramToExerciceModel>();
                throw e;
                //return list;
            }
        }
    }
}
