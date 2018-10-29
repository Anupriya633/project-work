using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientDemographics.Models;
using PatientDemographics.DataAccess;
using PatientDemographics.ServiceAccess;
using System.Web;

namespace PatientDemographics.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<PatientInfo> Get()
        {
            GetPatientInfoService getPatientInfoService = new GetPatientInfoService();
            List<PatientInfo> patientInfoList=getPatientInfoService.getPatientData();
            return patientInfoList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        PatientInfo patientInfo = new PatientInfo();
        [HttpPost]
        [ActionName("Complex")]
        public HttpResponseMessage PostComplex(PatientInfo patientdata)
        {
            if (ModelState.IsValid && patientdata != null)
            {
                // Convert any HTML markup in the status text.
                patientInfo.ForeName = HttpUtility.HtmlEncode(patientdata.ForeName);
                patientInfo.Surname = HttpUtility.HtmlEncode(patientdata.Surname);
                patientInfo.DateOfBirth = HttpUtility.HtmlEncode(patientdata.DateOfBirth);
                patientInfo.Gender = HttpUtility.HtmlEncode(patientdata.Gender);
                patientInfo.TelephoneNumber = new TelephoneNumber();

                TelephoneNumber number = new TelephoneNumber();
                number.Home = HttpUtility.HtmlEncode(patientdata.Home);
                number.Work = HttpUtility.HtmlEncode(patientdata.Work);
                number.Mobile = HttpUtility.HtmlEncode(patientdata.Mobile);
                patientInfo.TelephoneNumber = number;

                // Create a 201 response.
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {

                    Content = new StringContent("Patient Data Saved Successfully")
                };
                SavePatientInfoService savePatientInfoService = new SavePatientInfoService();
                savePatientInfoService.savePatientData(patientInfo);
                //response.Headers.Location =
                //        new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
                return response;
            }
            else
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest,errors);
            }
          }
       }

        
     // POST api/values
        //public void Post([FromBody] string value)
        //{
        //    SavePatientInfoService savePatientInfoService = new SavePatientInfoService();
        //    PatientInfo patientInfo = new PatientInfo();
        //    savePatientInfoService.savePatientData(patientInfo);
        //}

    }


