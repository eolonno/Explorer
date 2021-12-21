namespace Explorer.Application.Behaviors
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Serilog;

    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;

            Log.Information("{@RequestName} {@Request}", requestName, request);

            var response = next();

            return response;
        }
    }
}