using System.Threading.Tasks;

namespace SM.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IResolver _resolver;

        public CommandDispatcher(IResolver resolver)
        {
            this._resolver = resolver;
        }

        public async Task Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var handler = _resolver.Resolve<ICommandHandler<TCommand>>();
            await handler.Handle(command);
        }
    }
}
