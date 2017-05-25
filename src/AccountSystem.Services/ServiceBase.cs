using AccountSystem.Data;

namespace AccountSystem.Services
{
    public class ServiceBase
    {
        private readonly IDataContextFactory _dataContextFactory;

        protected IDataContext DataContext()
        {
            return _dataContextFactory.GetContext();
        }

        protected ServiceBase(IDataContextFactory dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }
    }
}
