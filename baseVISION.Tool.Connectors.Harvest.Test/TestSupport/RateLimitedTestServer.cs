using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace baseVISION.Tool.Connectors.Harvest.Test
{
    internal sealed class RateLimitedTestServer : IDisposable
    {
        private readonly HttpListener listener;
        private readonly Task processingTask;
        private readonly CancellationTokenSource cts = new();
        private readonly byte[] successPayload;
        private readonly int rateLimitResponses;
        private int requestCount;

        public string BaseUrl { get; }

        public RateLimitedTestServer(int rateLimitResponses)
        {
            this.rateLimitResponses = rateLimitResponses;
            BaseUrl = CreateBaseUrl();
            listener = new HttpListener();
            listener.Prefixes.Add(BaseUrl + "/");
            listener.Start();
            successPayload = Encoding.UTF8.GetBytes("{\"clients\":[{\"id\":1,\"name\":\"Test Client\"}],\"per_page\":1,\"total_pages\":1,\"total_entries\":1,\"page\":1}");
            processingTask = Task.Run(ListenLoopAsync);
        }

        private static string CreateBaseUrl()
        {
            var port = GetFreePort();
            return $"http://localhost:{port}";
        }

        private static int GetFreePort()
        {
            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            var port = ((IPEndPoint)listener.LocalEndPoint).Port;
            listener.Close();
            return port;
        }

        private async Task ListenLoopAsync()
        {
            try
            {
                while (!cts.IsCancellationRequested)
                {
                    HttpListenerContext context = await listener.GetContextAsync().ConfigureAwait(false);
                    _ = Task.Run(() => HandleRequestAsync(context));
                }
            }
            catch (HttpListenerException) when (cts.IsCancellationRequested)
            {
                // Listener was stopped.
            }
            catch (ObjectDisposedException) when (cts.IsCancellationRequested)
            {
                // Listener disposed while shutting down.
            }
        }

        private async Task HandleRequestAsync(HttpListenerContext context)
        {
            var count = Interlocked.Increment(ref requestCount);
            if (count <= rateLimitResponses)
            {
                context.Response.StatusCode = 429;
                context.Response.StatusDescription = "Too Many Requests";
                context.Response.Headers.Add("Retry-After", "1");
                context.Response.Close();
                return;
            }

            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            context.Response.ContentLength64 = successPayload.Length;
            await context.Response.OutputStream.WriteAsync(successPayload, 0, successPayload.Length).ConfigureAwait(false);
            context.Response.Close();
        }

        public void Dispose()
        {
            cts.Cancel();
            listener.Stop();
            listener.Close();
            processingTask.Wait(2000);
        }
    }
}
