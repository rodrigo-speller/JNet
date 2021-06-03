# JNet.Runtime

> We need your help! Can you help us to document this?

JNet.Runtime is a wrapper library around the JVM (Java Native Interface - JNI) library. This is the base runtime to JNet.

**You must understand the JNI approach before use this wrapper library.** Read below documentation first:

* [Java Development Kit Specifications - Java Native Interface Specification](https://docs.oracle.com/en/java/javase/15/docs/specs/jni/index.html)
* [IBM SDK, Java Technology Edition 7 - The Java Native Interface (JNI)](https://www.ibm.com/docs/en/sdk-java-technology/7?topic=components-java-native-interface-jni)
## How to operate on virtual machine

To operante on virtual machine environment you needs a JNetRuntime instance. Three classes are very important for using the JNet.Runtime:

|Class|Usage|
|-|-|
|[JNetVirtualMachine](JNetVirtualMachine.cs)|Initializes the virtual machine; Attach/Detach threads to virtual machine; Gets the runtime instances.|
|[JNetConfiguration](JNetConfiguration.cs)|Configures the virtual machine initialization.|
|[JNetRuntime](JNetRuntime.cs)|Calls the JNI operations on virtual machine enviroment.|

There are the steps to operate on virtual machine environment:

- Start the virtual machine in your process by calling `JNetVirtualMachine.Initialize` method. It must returns the `JNetVirtualMachine` instance.
- Attach the current thread to virtual machine by calling `JNetVirtualMachine.AttachCurrentThread`. It must returns the `JNetRuntime` instance.
- Operate on `JNetRuntime` instance (it must be done on the same thread that is attached)...
- Dettach the thread to release virtual machine environment objects references by calling `JNetVirtualMachine.DettachCurrentThread` (it is very important to collect unused references on virtual machine environment).
- Destroy the virtual machine - if you don't need more in your process - by calling `JNetVirtualMachine.Destroy`.

## How to initialize the virtual machine

To start using the JNet Runtime the program must initializes a the virtual machine by calling the `JNetVirtualMachine.Initialize` method.

> As of JDK/JRE 1.2, creation of multiple virtual machines in a single process is not supported. Support for creating only a single virtual machine within a single job or process follows the standards of the Oracle America, Inc. reference implementation of Java.

### Virtual machine configuration

Pass an `JNetConfiguration` instance to *JNetVirtualMachine.Initialize* to configure the virtual machine.

|Property|Type|*Intialize's* method default behavior|
|-|-|-|
|JavaRuntimePath|string|Infer from *JAVA_HOME* environment variable.|
|Classpath|IEnumerable&lt;string&gt;|No classpath.|
|Bootstrap|IJNetBootstrap|No bootstrap.|
|JNIVersion|JNIVersion|JNIVersion.Version10|
|EnableDiagnostics|bool|false|
|LoggerCallback|JNetConfiguration.Logger|Default JNI logger.|

## Hosting the JNet Runtime usage

Managing the JNetRuntime instances by `AttachCurrentThread` and `DettachCurrentThread` can be complicated in your project. To simplify this, we recommend you to implement a host to handle the runtime operations.

A host sample is available in: [JNetHost sample](../../src/JNet.Runtime.Sample/JNetHost.cs).

> In a future version of JNet we must implement a complete host to abstract it. *You can help us opening issues by offering proposals.*
