using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientDemographics.Models;
using System.Web;
using PatientDemographics.BusinessAccessLayer;

namespace PatientDemographics.Controllers
{
    public class PatientController : ApiController
    {
        private GetPatientInfoBusinessLayer _objGetPatientInfoBal;
        private SavePatientInfoBusinessLayer _objSavePatientInfoBal;
        public PatientController()
        {
            _objGetPatientInfoBal = GetPatientInfoBusinessLayer.getInstance();
            _objSavePatientInfoBal = SavePatientInfoBusinessLayer.getInstance();
        }
        
        public List<PatientInfo> Get()
        {
            List<PatientInfo> patientInfoList = _objGetPatientInfoBal.getPatientData();
            if (patientInfoList != null && patientInfoList.Count > 0)
            {
                return patientInfoList;
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent("Data Not Found")
                };
                return patientInfoList;
            }
        }

        PatientInfo patientInfo = new PatientInfo();

        [HttpPost]
        [ActionName("Patient")]
        public HttpResponseMessage savePatientData(PatientInfo patientdata)
        {
            if (ModelState.IsValid && patientdata != null)
            {
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
                //SavePatientInfoBusinesslayer savePatientInfoService = new SavePatientInfoBusinesslayer();
                _objSavePatientInfoBal.savePatientData(patientInfo);
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
    }


