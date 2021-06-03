# JNet.Runtime.Sample

> We need your help! Can you help us to document this?

## Sample program

```csharp
using JNet.Hosting;

static class Program
{
    static void Main(string[] args)
    {
        var debug = true;

        JNetHost.Initialize(new() {
            EnableDiagnostics = debug
        });

        JNetHost.Run(runtime => {

            // The "runtime" parameter is a JNetRutime object, that exposes the JNI function for usage.
            // See more: https://docs.oracle.com/en/java/javase/15/docs/specs/jni/functions.html

            // java.lang.System class
            var clz_System = runtime.FindClass("java/lang/System");
            // System.out field
            var f_out = runtime.GetStaticFieldID(clz_System, "out", "Ljava/io/PrintStream;");

            // java.io.PrintStream class
            var clz_PrintStream = runtime.FindClass("java/io/PrintStream");
            // PrintStream.println method
            var m_println_A = runtime.GetMethodID(clz_PrintStream, "println", "(Ljava/lang/String;)V");   
            
            // gets the System.out value
            var j_out = runtime.GetStaticObjectField(clz_System, f_out);

            // creates the "Hello, World!" string
            var j_str = runtime.NewString("Hello, World!");

            // call: System.out.println("Hello, World!")
            runtime.CallVoidMethod(j_out, m_println_A, j_str);

        });

        JNetHost.Destroy();
    }
}
```

### Sample program using wrappers

The above sample can be simplified by using some .NET wrappers.
In this sample, we created the wrapper for these classes:

 * [java.io.PrintStream](java/io/PrintStream.cs)
 * [java.lang.System](java/lang/System.cs)

The same sample can be writed like:

```csharp
using JNet.Hosting;

static class Program
{
    static void Main(string[] args)
    {
        var debug = true;

        JNetHost.Initialize(new() {
            EnableDiagnostics = debug
        });

        System.Out.Println("Hello, World!");

        JNetHost.Destroy();
    }
}
```

Clone this sample project to trying more...