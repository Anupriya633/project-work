using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientDemographics.Models;
using System.Collections.Generic;
using System.Net;
using PatientDemographics.BusinessAccessLayer;
using System.Web.Http;
using System.Net.Http;
using PatientDemographics.Controllers;
using Moq;

namespace PatientDemographics.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllPatient()
        {
            var controller = new PatientController();
            List < PatientInfo > patientList= controller.Get();
            Assert.IsTrue(patientList.Count > 0);
        }

        [TestMethod]
        public void SavePatient()
        {
            var controller = new PatientController();
            PatientInfo patient = new PatientInfo();
            patient.ForeName = "Mark";
            patient.Surname = "Max";
            patient.DateOfBirth = "03-07-1998";
            patient.Gender = "male";
            patient.Work = "5456476476";
            patient.Home = "768765879";
            patient.Mobile = "986876876";
            HttpResponseMessage response = controller.savePatientData(patient);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
