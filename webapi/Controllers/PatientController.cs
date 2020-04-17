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
            // Patient 1  for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p                   = new Patient ();
                p.Id                        = 777;
                p.Name                      = "Ponnamma M";
                p.HospitalAdmitted          = "K C General Hospital";
                string benefitsAndInsurance =  await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray               = JArray.Parse(benefitsAndInsurance);
                string[] strArray           = jArray.ToObject<string[]>();
                p.Benefits                  = strArray[0];
                p.Insurance                 = strArray[1];
                p.Summary                   = "pray for soul"; 
                patients.Add(p);
            }
            // Patient 2  for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p                   = new Patient ();
                p.Id                        = 778;
                p.Name                      = "Ram Paswan";
                p.HospitalAdmitted          = "Kidwai Memorial";
                string benefitsAndInsurance =  await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray               = JArray.Parse(benefitsAndInsurance);
                string[] strArray           = jArray.ToObject<string[]>();
                p.Benefits                  = strArray[0];
                p.Insurance                 = strArray[1];
                p.Summary                   = "pray for soul"; 
                patients.Add(p);
            }
            // Patient 3  for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p                   = new Patient ();
                p.Id                        = 779;
                p.Name                      = "Mariama David";
                p.HospitalAdmitted          = "Kidwai Memorial"; 
                string benefitsAndInsurance =  await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray               = JArray.Parse(benefitsAndInsurance);
                string[] strArray           = jArray.ToObject<string[]>();
                p.Benefits                  = strArray[0];
                p.Insurance                 = strArray[1];
                p.Summary                   = "pray for soul"; 
                patients.Add(p);
            }
            // Patient 4  for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p                   = new Patient ();
                p.Id                        = 780;
                p.Name                      = "Rajini Nair";
                p.HospitalAdmitted          = "E.S.I Hospital";
                string benefitsAndInsurance = await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray               = JArray.Parse(benefitsAndInsurance);
                string[] strArray           = jArray.ToObject<string[]>();
                p.Benefits                  = strArray[0];
                p.Insurance                 = strArray[1];
                p.Summary                   = "pray for soul"; 
                patients.Add(p);
            }
            // Patient 5  for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p                   = new Patient ();
                p.Id                        = 781;
                p.Name                      = "Anil Nambiar";
                p.HospitalAdmitted          = "E.S.I Hospital";
                string benefitsAndInsurance = await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray               = JArray.Parse(benefitsAndInsurance);
                string[] strArray           = jArray.ToObject<string[]>();
                p.Benefits                  = strArray[0];
                p.Insurance                 = strArray[1];
                p.Summary                   = "pray for soul"; 
                patients.Add(p);
            }
            // Patient 6  for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p                   = new Patient ();
                p.Id                        = 782;
                p.Name                      = "Arif Khan";
                p.HospitalAdmitted          = "E.S.I Hospital";
                string benefitsAndInsurance =  await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray               = JArray.Parse(benefitsAndInsurance);
                string[] strArray           = jArray.ToObject<string[]>();
                p.Benefits                  = strArray[0];
                p.Insurance                 = strArray[1];
                p.Summary                   = "pray for soul"; 
                patients.Add(p);
            }
            // Patient 7  for(int i=0; i< 5; i++)// Enumerable.Range(1, 5).Select(index => new Patient
            {
                Patient p                   = new Patient ();
                p.Id                        = 783;
                p.Name                      = "Radha Mani";
                p.HospitalAdmitted          =  "K C General Hospital";

                string benefitsAndInsurance =  await ProcessPatientBenefits();
                Console.WriteLine("BenefitsAndInsurance: " +  benefitsAndInsurance);
                JArray jArray               = JArray.Parse(benefitsAndInsurance);
                string[] strArray           = jArray.ToObject<string[]>();
                p.Benefits                  = strArray[0];
                p.Insurance                 = strArray[1];
                p.Summary                   = "pray for soul"; 
                patients.Add(p);
            }

            //string json = JsonConvert.SerializeObject(patients, Formatting.Indented);
            return patients;
        }


        private async Task<string> ProcessPatientBenefits()
        {
            string theResponse = string.Empty;
            theResponse = "[ \"Paid time off, Retirement benefits,Healthcare spending\", \"Health insurance, Life insurance, Dental insurance, Vision insurance, Long term disability insurance\"]";
            /*try{
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
            }*/
            await Task.Delay(200);
            return theResponse;
        }
    }
}
