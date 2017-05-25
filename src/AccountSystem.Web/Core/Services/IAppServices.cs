using AccountSystem.Data;
using AccountSystem.Web.Core.Configuration;
using OrangeJetpack.Core.Web.Utilities;
using OrangeJetpack.Services.Client.Messaging;

namespace AccountSystem.Web.Core.Services
{
    public interface IAppServices
    {
        IDataContextFactory DataContextFactory { get; }

        AppSettings AppSettings { get; }
        
        IMessageService MessageService { get; }
        ViewRender ViewRender { get; }
    }
}
