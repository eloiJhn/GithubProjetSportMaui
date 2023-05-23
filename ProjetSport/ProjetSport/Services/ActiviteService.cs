using Newtonsoft.Json;
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

        public static List<ActiviteModel>? GetActivitiesPrograms(int id)
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

        public static List<ActiviteModel>? GetActivitesByUserByProgram(int id, string programName, DateTime date, int attempt)
        {
            try
            {
                string formattedDate = date.ToString("yyyy-MM-dd");
                var json = GetDataFromApi(baseURI + "/GetActivitesByUserByProgram/" + id + "/" + programName + "/" + formattedDate + "/" + attempt);
                return JsonConvert.DeserializeObject<List<ActiviteModel>>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static int AvanceProgram(int id, string programName, DateTime date, int attempt)
        {
            try
            {
                string formattedDate = date.ToString("yyyy-MM-dd");
                var json = GetDataFromApi(baseURI + "/GetAvance/" + id + "/" + programName + "/" + formattedDate + "/" + attempt);
                return JsonConvert.DeserializeObject<int>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int CaloriePerdu(int id, string programName, DateTime date, int attempt)
        {
            try
            {
                string formattedDate = date.ToString("yyyy-MM-dd");
                var json = GetDataFromApi(baseURI + "/GetCaloriePerduPerUser/" + id + "/" + programName + "/" + formattedDate + "/" + attempt);
                return JsonConvert.DeserializeObject<int>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int CalorieAPerdre(int id, string programName, DateTime date, int attempt)
        {
            try
            {
                string formattedDate = date.ToString("yyyy-MM-dd");
                var json = GetDataFromApi(baseURI + "/GetCalorieAPerdrePerUser/" + id + "/" + programName + "/" + formattedDate + "/" + attempt);
                return JsonConvert.DeserializeObject<int>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<bool> AddActivityAsync(int userId, int idProgram)
        {
            try
            {
                HttpClient client = new HttpClient();
                var content = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("UserId", userId.ToString()),
            new KeyValuePair<string, string>("IdProgram", idProgram.ToString()),
        });

                var response = await client.PostAsync(baseURI, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async static void PostUserActivite(int idProgram, int idExercice, TimeSpan timeSpent)
        {
            var UserAuth = new ActiviteUserModel
            {
                IdProgram = idProgram,
                IdExercice = idExercice,
                TimeElapsed = timeSpent,
                Date = DateTime.Now

            };
            var json = JsonConvert.SerializeObject(UserAuth);
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await httpClient.PostAsync(baseURI, content))
                    {
                        var status = response.StatusCode;
                        var responseContent = await response.Content.ReadAsStringAsync(); // Lire le contenu de la réponse


                        if ((int)status != 200)
                        {
                            await App.Current.MainPage.DisplayAlert("Un problème a eu lieu lors de l'envoi", "Error : " + ((int)status).ToString() + " " + status.ToString() + "\nDétails : " + responseContent, "X");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Un Problème à eu lieu lors de l'envoie", "L'API ne répond pas", "X");
            }
        }


    }
}
