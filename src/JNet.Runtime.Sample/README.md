# JNet.Runtime.Sample

> We need your help! Can you help us to document this?

|Component|Description|
|-|-|
|[JNetHost](JNetHost.cs)|A sample host implementation using JNetRuntime.|
|[JNetRunner](JNetRunner.cs)|A sample runner that starts dedicated threads attached to JVM to run the JNetHost runnables.|
|[java.io.PrintStream](java/io/PrintStream.cs)<br>[java.lang.System](java/lang/System.cs)|Some .NET wrappers samples to handle some Java objects.|

## Contract overview

```csharp
// The contract to a runnable action using a runtime instance.
delegate void JNetRunnable(JNetRuntime runtime);

// The contract to a runnable function using a runtime instance.
delegate TResult JNetRunnable<out TResult>(JNetRuntime runtime);


// A sample host implementation using JNetRuntime.
static class JNetHost
{
    // Initializes the host.
    public static void Initialize(JNetConfiguration configuration = null);

    // Runs a action.
    public static void Run(JNetRunnable runnable);

    // Runs a function and returns their result.
    public static T Run<T>(JNetRunnable<T> runnable);
}


static class Program
{
    static void Main()
    {
        JNetHost.Initialize(/* you can specify some config */);

        JNetHost.Run(runtime => {
            // now you can use the JNetRutime here 
        });
    }
}

```
