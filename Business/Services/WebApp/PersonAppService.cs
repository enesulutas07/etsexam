using Entity;
using Entity.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.WebApp
{

    public class PersonAppService
    {
        HttpClient client;
        private readonly string apiUrl = "https://localhost:44340/";
        public PersonAppService()
        {
            if (client == null)
            {
                client = new HttpClient();
            }
        }
        public ServiceResult<Person> GetPersons()
        {
            return JsonConvert.DeserializeObject<ServiceResult<Person>>(client.GetStringAsync(apiUrl+"get-persons").Result);
        }

        public async Task<ServiceResult<Person>> AddPerson(Person personData)
        {
            try
            {
                var result = client.PostAsync(apiUrl+"add-person", new StringContent(JsonConvert.SerializeObject(personData), Encoding.UTF8, "application/json")).Result;
                return JsonConvert.DeserializeObject<ServiceResult<Person>>(await result.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                return new ServiceResult<Person>(false, "Kayıt İşlemi Sırasında Bir Hata Oluştu");
            }
           
        }
    }
}
