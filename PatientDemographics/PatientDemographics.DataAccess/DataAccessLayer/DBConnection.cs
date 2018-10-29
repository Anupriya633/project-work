using MySql.Data.MySqlClient;

namespace PatientDemographics.DataAccessLayer
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection getInstance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            string connstring = string.Format("Server=localhost; database={0}; UID=anu; password=anu123", "patient_info");
            connection = new MySqlConnection(connstring);
            connection.Open();
            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}