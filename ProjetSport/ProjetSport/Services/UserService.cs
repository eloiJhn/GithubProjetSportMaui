using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.Services
{
    public class UserService
    {
        readonly static string baseURI = "http://resterenforme20230125215043.azurewebsites.net/api/User";


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

    }
}
