using MySql.Data.MySqlClient;
using System;


namespace PatientDemographics.DataAccessLayer
{
    public class SavePatientInfoDataLayer:ISavePatientInfoDataLayer
    {
        private static SavePatientInfoDataLayer _instance = null;
        public static SavePatientInfoDataLayer getInstance()
        {
            if (_instance == null)
                _instance = new SavePatientInfoDataLayer();
            return _instance;
        }
        public void savePatientData(string patientXmlString)
        {
            string xmlString = string.Empty;
            DBConnection dbconnection=DBConnection.getInstance(); ;
            try
            {
                if (dbconnection.IsConnect())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into patient values(default,'" + patientXmlString + "')", dbconnection.Connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                dbconnection.Close();
            }
        }
    }
}