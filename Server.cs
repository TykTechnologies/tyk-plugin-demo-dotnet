using System;
using System.Threading.Tasks;
using Grpc.Core;

class DispatcherImpl : Coprocess.Dispatcher.DispatcherBase {
  public override Task<Coprocess.Object> Dispatch(Coprocess.Object request, ServerCallContext context)
  {
    Console.WriteLine("Receiving request: " + request.ToString());
    // This will return the unmodified request object:
    return Task.FromResult(request);
  }
}
