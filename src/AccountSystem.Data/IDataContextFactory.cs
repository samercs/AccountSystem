namespace AccountSystem.Data
{
    public interface IDataContextFactory
    {
        IDataContext GetContext();
        //string GetConnectionString();
    }
}
