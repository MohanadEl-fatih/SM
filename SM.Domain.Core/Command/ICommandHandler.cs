using System.Threading.Tasks;

namespace SM.Core
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task Handle(TCommand command);
    }
}
