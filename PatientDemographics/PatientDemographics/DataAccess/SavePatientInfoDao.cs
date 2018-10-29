using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace PatientDemographics.DataAccess
{
    public class SavePatientInfoDao
    {
        public void savePatientData(string patientXmlString)
        {
            string xmlString = string.Empty;
            DBConnection dbconnection = DBConnection.getInstance();
            if (dbconnection.IsConnect())
            {
                MySqlCommand cmd = new MySqlCommand("insert into patient values(default,'"+patientXmlString+"')", dbconnection.Connection);
                cmd.ExecuteNonQuery();
            }
            dbconnection.Close();
        }
    }
}