using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PatientDemographics.Models;
using System.Xml.Serialization;
using System.IO;
using System;

namespace PatientDemographics.DataAccessLayer
{
    public class GetPatientInfoDataLayer
    {

        private GetPatientInfoDataLayer()
        {

        }

        private static GetPatientInfoDataLayer _instance = null;
        public static GetPatientInfoDataLayer getInstance()
        {
            if (_instance == null)
                _instance = new GetPatientInfoDataLayer();
            return _instance;
        }
        public List<PatientInfo> getPatientInfo()
        {
            List<PatientInfo> patientInfoList = new List<PatientInfo>();
            string xmlString = string.Empty;
            DBConnection dbconnection=DBConnection.getInstance();
            try
            {
                if (dbconnection.IsConnect())
                {
                    MySqlCommand cmd = new MySqlCommand("select * from patient", dbconnection.Connection);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        PatientInfo patientInfo = null;
                        xmlString = dr["patient_data"].ToString();
                        XmlSerializer xs = new XmlSerializer(typeof(PatientInfo));
                        using (TextReader reader = new StringReader(xmlString))
                        {
                            patientInfo = (PatientInfo)xs.Deserialize(reader);
                        }
                        if (patientInfo != null)
                        {
                            patientInfoList.Add(patientInfo);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                dbconnection.Close();
            }
            return patientInfoList;
        }
    }
}