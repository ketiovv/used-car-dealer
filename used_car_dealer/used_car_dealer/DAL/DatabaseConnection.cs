using MySqlConnector;

namespace used_car_dealer.DAL
{
    class DatabaseConnection
    {
        private static DatabaseConnection _instance = null;
        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseConnection();
                return _instance;
            }
        }

        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        public MySqlConnection Connection => new MySqlConnection(builder.ToString());

        private DatabaseConnection()
        {
            builder.Database = Properties.Settings.Default.database;
            builder.Server = Properties.Settings.Default.server;
            builder.Port = Properties.Settings.Default.port;

            builder.UserID = Properties.Settings.Default.usedID;
            builder.Password = Properties.Settings.Default.password;
        }
    }
}
