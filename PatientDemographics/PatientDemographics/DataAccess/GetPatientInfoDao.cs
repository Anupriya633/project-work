using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientDemographics.DataAccess;
using MySql.Data.MySqlClient;
using PatientDemographics.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace PatientDemographics.DataAccess
{
    public class GetPatientInfoDao
    {
        public List<PatientInfo> getPatientInfo()
        {
            List<PatientInfo> patientInfoList = new List<PatientInfo>();
            string xmlString = string.Empty;
            DBConnection dbconnection=DBConnection.getInstance();
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
            dbconnection.Close();
            return patientInfoList;
        }
    }
}