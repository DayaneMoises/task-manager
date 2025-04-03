namespace TaskManager.API.Data.Configurations
{
    public interface IDatabaseConfig
    {
        //por padrão o mongDB precisa de duas propriedades: Name e ConnectionString
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
