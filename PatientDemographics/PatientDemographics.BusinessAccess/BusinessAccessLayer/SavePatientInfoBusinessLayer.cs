using PatientDemographics.DataAccessLayer;
using PatientDemographics.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System;

namespace PatientDemographics.BusinessAccessLayer
{
    public class SavePatientInfoBusinessLayer:ISavePatientInfoBusinessLayer
    {

        ISavePatientInfoDataLayer _objSavePatientIfo;
        public SavePatientInfoBusinessLayer(ISavePatientInfoDataLayer objSavePatientIfo)
        {
            _objSavePatientIfo = objSavePatientIfo;
        }

        private SavePatientInfoBusinessLayer()
        {

        }

        private static SavePatientInfoBusinessLayer _instance = null;
        public static SavePatientInfoBusinessLayer getInstance()
        {
            if (_instance == null)
                _instance = new SavePatientInfoBusinessLayer();
            return _instance;
        }

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
            try
            {
                SavePatientInfoDataLayer.getInstance().savePatientData(patientXmlData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in gettingPatientInfo", ex);
            }
        }
    }
}