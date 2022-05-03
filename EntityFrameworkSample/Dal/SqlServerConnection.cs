using System.Data.SqlClient;

namespace EntityFrameworkSample.Dal
{
    public class SqlServerConnection
    {
        private static readonly SqlServerConnection sqlServerConnection = new SqlServerConnection();

        public string ConnectionString { get; private set; } = string.Empty;
        public SqlConnection? Connection { get; private set; }

        private SqlServerConnection()
        {
            this.CreateConnection();
        }

        public static SqlServerConnection GetInstance()
        {
            return sqlServerConnection;
        }

        private void CreateConnection()
        {
            IConfigurationRoot root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@"../appsettings.json", false).Build();

            ConnectionString = root.GetConnectionString("SqlServer");
            Connection = new SqlConnection(ConnectionString);
        }
    }
}
