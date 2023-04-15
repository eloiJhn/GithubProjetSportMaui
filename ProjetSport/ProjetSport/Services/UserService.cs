using Newtonsoft.Json;
using ProjetSport.Models;
using System.Security.Cryptography;
using System.Text;

namespace ProjetSport.Services
{
    public class UserService
    {
        readonly static string baseURI = "https://resterenforme20230125215043.azurewebsites.net/api/User";


        private static string GetDataFromApi(string url)
        {
            String response = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url); //Uri : classe qui permet de construire une URL 
            response = client.GetStringAsync(client.BaseAddress).Result;
            return response;
        }

        public static byte[] HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return SHA256.HashData(passwordBytes);
        }


        public static bool VerifConnection(string identifiant, string password)
        {
            try
            {
                // Hacher le mot de passe avant de l'envoyer à l'API
                byte[] hashedPasswordBytes = HashPassword(password);
                string hashedPassword = Convert.ToHexString(hashedPasswordBytes);


                var json = GetDataFromApi (baseURI + "/verif?identifiant=" + identifiant + "&password=" + hashedPassword);

                return JsonConvert.DeserializeObject<bool>(json);
            }
            catch (Exception e)
            {
                //var list = new ObservableCollection<ProgramToExerciceModel>();
                throw e;
                //return list;
            }
        }

        public static int GetStudentId(string identifiant)
        {
            try
            {
                var json = GetDataFromApi(baseURI + "/" + identifiant);
                return JsonConvert.DeserializeObject<int>(json);
            }
            catch (Exception e)
            {
                //var list = new ObservableCollection<ProgramToExerciceModel>();
                throw e;
                //return list;
            }
        }   

        public static UserModel GetStudent(int id)
        {
            try
            {
                var json = GetDataFromApi(baseURI + "/userId/" + id);
                return JsonConvert.DeserializeObject<UserModel>(json);
            }
            catch (Exception e)
            {
                //var list = new ObservableCollection<ProgramToExerciceModel>();
                throw e;
                //return list;
            }
        }

        public async static void PostEleveAuth(string firstName, string lastName, string password, string identifiant)
        {
            var eleveAuth = new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Identifiant = identifiant
            };
            var json = JsonConvert.SerializeObject(eleveAuth);
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await httpClient.PostAsync((baseURI), content))
                    {
                        var status = response.StatusCode;

                        if ((int)status != 200)
                        { 
                            await App.Current.MainPage.DisplayAlert("Un Problème à eu lieu lors de l'envoie", " Error : " + ((int)status).ToString() + " " + status.ToString(),"X");
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
