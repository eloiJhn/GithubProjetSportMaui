﻿using Newtonsoft.Json;
using ProjetSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.Services
{
    class ActiviteService
    {
        readonly static string baseURI = "https://resterenforme20230125215043.azurewebsites.net/api/Activite";


        private static string GetDataFromApi(string url)
        {
            String response = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url); //Uri : classe qui permet de construire une URL 
            response = client.GetStringAsync(client.BaseAddress).Result;
            return response;
        }

        public static List<ActiviteModel>? GetActivities(int id)
        {
            try
            {
                var json = GetDataFromApi(baseURI + "/GetActivitesProgramByUser/" + id);
                return JsonConvert.DeserializeObject<List<ActiviteModel>>(json);
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
