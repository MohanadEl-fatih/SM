using System.Threading.Tasks;

namespace SM.Core
{
    public interface ICommandDispatcher
    {
        Task Send<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
