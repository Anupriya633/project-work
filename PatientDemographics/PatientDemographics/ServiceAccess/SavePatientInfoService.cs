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
    public class SavePatientInfoService
    {
        public void savePatientData(PatientInfo patientData)
        {
            XmlSerializer xs = new XmlSerializer(typeof(PatientInfo));
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PatientInfo));
            string patientXmlData = string.Empty;
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, patientData);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                patientXmlData = xmlDoc.InnerXml;
            }
            SavePatientInfoDao savePatientInfoDao = new SavePatientInfoDao();
            savePatientInfoDao.savePatientData(patientXmlData);
        }
    }
}