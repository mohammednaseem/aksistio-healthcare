using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Healthcare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public IConfiguration _configuration { get; }

        public PatientController(IConfiguration configuration, 
                                IHttpClientFactory clientFactory, 
                                ILogger<PatientController> logger)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _configuration  = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            var rng = new Random();
           // string benefitsServiceResponse = await ProcessPatientBenefits();

            List<Patient> patients = new List<Patient>();
            for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p           = new Patient ();
                p.PatientId         = rng.Next(1, 20);
                string benefitsAndInsurance =  await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray       = JArray.Parse(benefitsAndInsurance);
                string[] strArray   = jArray.ToObject<string[]>();
                p.PatientBenefits   = strArray[0];
                p.PatientBenefits   = strArray[1];
                p.Summary           = "pray for soul"; 
                patients.Add(p);
            }
            
            //string json = JsonConvert.SerializeObject(patients, Formatting.Indented);
            return patients;
        }


        private async Task<string> ProcessPatientBenefits()
        {
            string theResponse = string.Empty;
            try{
                var url = _configuration["BenefitsUrl"] + "/Patient";
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var client = _clientFactory.CreateClient("BenefitsClient");

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    theResponse = await response.Content.ReadAsStringAsync();    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return theResponse;
        }
    }
}
