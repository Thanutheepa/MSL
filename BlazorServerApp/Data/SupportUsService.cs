using Newtonsoft.Json;
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class SupportUsService : ISupportUsService
    {
        private readonly HttpClient httpClient;
        public SupportUsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<SchoolClub>> GetSchoolClubs()
        {
            try
            {
                var url = "/api/v1/GetAllScholClubs";
                var req = await httpClient.GetAsync(url);
                var response = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SchoolClub>>(response);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<Volunteer>> GetVolunteers()
        {
            try
            {
                var url = "/api/v1/GetAllVolunteers";
                var req = await httpClient.GetAsync(url);
                var response = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Volunteer>>(response);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> SaveSchoolClub(SchoolClub club)
        {
            try
            {
                var clubJson = new StringContent(JsonConvert.SerializeObject(club), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/api/v1/SaveScholClub", clubJson);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<string>(content);
            }
            catch(Exception e)
            {
                string error = "error";
                return error;
            }
        }

        public async Task<string> SaveVolunteer(Volunteer volunteer)
        {
            try
            {
                var volunteerJson = new StringContent(JsonConvert.SerializeObject(volunteer), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/api/v1/SaveVolunteer", volunteerJson);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<string>(content);
            }
            catch (Exception e)
            {
                string error = "error";
                return error;
            }


        }
    }
}
