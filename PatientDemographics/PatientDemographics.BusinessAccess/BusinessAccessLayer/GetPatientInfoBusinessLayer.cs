using System.Collections.Generic;
using PatientDemographics.DataAccessLayer;
using PatientDemographics.Models;
using System.Xml.Serialization;
using System;

namespace PatientDemographics.BusinessAccessLayer
{
    public class GetPatientInfoBusinessLayer : IGetPatientInfoBusinessLayer
    {
        private GetPatientInfoDataLayer _objGetPatientIfo;
      
        private GetPatientInfoBusinessLayer(){
           
        }

        private static GetPatientInfoBusinessLayer _instance = null;
        public static GetPatientInfoBusinessLayer getInstance()
        {
            if (_instance == null)
                _instance = new GetPatientInfoBusinessLayer();
            return _instance;
        }

        public List<PatientInfo> getPatientData()
        {
            List<PatientInfo> patientInfoList=new List<PatientInfo>();
            try
            {
                patientInfoList = GetPatientInfoDataLayer.getInstance().getPatientInfo();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in gettingPatientInfo" ,ex);
            }
            return patientInfoList;
        }
    }
}