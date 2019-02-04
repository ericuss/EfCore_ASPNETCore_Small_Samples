namespace Creating.From.Infrastructure.Settings
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings{ get; set; }
        public Database Database { get; set; }
    }

    public class ConnectionStrings
    {
        public string Library { get; set; }
    }

    public class Database
    {
        public bool UseInMemory { get; set; }
        public bool ApplyMigrations { get; set; }
        public bool EnsureDeleted { get; set; }
        public bool EnsureCreated { get; set; }
        public string DbName { get; set; }
    }
}