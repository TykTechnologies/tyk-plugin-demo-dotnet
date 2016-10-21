using System;
using System.Threading.Tasks;
using Grpc.Core;

class DispatcherImpl : Coprocess.Dispatcher.DispatcherBase {
  public override Task<Coprocess.Object> Dispatch(Coprocess.Object thisObject, ServerCallContext context)
  {
    Console.WriteLine("Receiving object: " + thisObject.ToString());

    var isImplemented = this.GetType().GetMethod(thisObject.HookName);

    if(isImplemented == null) {
      Console.WriteLine("Hook name: " + thisObject.HookName + " (not implemented!)");
      // This will return the unmodified request object:
      return Task.FromResult(thisObject);
    };

    Console.WriteLine("Hook name: " + thisObject.HookName + " (implemented)");
    return MyPreMiddleware(thisObject, context);
  }

  public Task<Coprocess.Object> MyPreMiddleware(Coprocess.Object thisObject, ServerCallContext context)
  {
    Console.WriteLine("Calling MyPreMiddleware.");
    // Injecting a header!
    thisObject.Request.SetHeaders["my-header"] = "my-value";
    return Task.FromResult(thisObject);
  }
}
