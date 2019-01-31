namespace Creating.From.Context
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings{ get; set; }
        public Database Database { get; internal set; }
    }
    public class ConnectionStrings
    {
        public string Library { get; set; }
    }

    public class Database
    {
        public bool UseInMemory { get; internal set; }
        public bool ApplyMigrations { get; internal set; }
        public bool EnsureDeleted { get; internal set; }
        public bool EnsureCreated { get; internal set; }
        public string DbName { get; internal set; }
    }
}
