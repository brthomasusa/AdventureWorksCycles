#pragma warning disable CS0414

using AWC.SharedKernel.Utilities;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace AWC.Server.Interceptors
{
    public sealed class ServerTracingInterceptor : Interceptor
    {
        private readonly ILogger<ServerTracingInterceptor> _logger;

        public ServerTracingInterceptor(ILogger<ServerTracingInterceptor> logger)
            => _logger = logger;

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            LogCall(context);

            try
            {
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw new ServerTracingInterceptorException(Helpers.GetExceptionMessage(ex));
            }
        }

        public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, ServerCallContext context, ClientStreamingServerMethod<TRequest, TResponse> continuation)
        {
            LogCall(context);

            try
            {
                return await continuation(requestStream, context);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw new ServerTracingInterceptorException(Helpers.GetExceptionMessage(ex));
            }
        }

        public override async Task ServerStreamingServerHandler<TRequest, TResponse>(TRequest request, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, ServerStreamingServerMethod<TRequest, TResponse> continuation)
        {
            LogCall(context);

            try
            {
                await continuation(request, responseStream, context);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw new ServerTracingInterceptorException(Helpers.GetExceptionMessage(ex));
            }
        }

        public override async Task DuplexStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, DuplexStreamingServerMethod<TRequest, TResponse> continuation)
        {
            LogCall(context);

            try
            {
                await continuation(requestStream, responseStream, context);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw new ServerTracingInterceptorException(Helpers.GetExceptionMessage(ex));
            }
        }

        private void LogCall(ServerCallContext context)
        {
            _logger.LogDebug($"gRPC call request: {context.GetHttpContext().Request.Path}");
        }

        private void LogException(Exception ex)
        {
            _logger.LogError(ex, Helpers.GetExceptionMessage(ex));
        }
    }

    public sealed class ServerTracingInterceptorException : Exception
    {
        public ServerTracingInterceptorException(string message) : base(message) { }
    }
}