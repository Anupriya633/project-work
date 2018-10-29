using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientDemographics.DataAccess;
using PatientDemographics.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace PatientDemographics.ServiceAccess
{
    public class GetPatientInfoService
    {
        public List<PatientInfo> getPatientData()
        {
            GetPatientInfoDao getPatientInfoDao = new GetPatientInfoDao();
            List<PatientInfo> patientInfoList =getPatientInfoDao.getPatientInfo();
            XmlSerializer xs = new XmlSerializer(typeof(PatientInfo));
            return patientInfoList;
        }
    }
}