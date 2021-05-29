# JNet

JNet is a Java Runtime library to .NET. With JNet you can implement .NET and Java integration under the hood.

[![JNet](https://img.shields.io/nuget/v/JNet?label=JNet)](http://nuget.org/packages/JNet)
[![Status](https://img.shields.io/github/workflow/status/rodrigo-speller/JNet/JNet.Runtime%20test/main?label=JNet.Runtime%20test)](https://github.com/rodrigo-speller/JNet/actions/workflows/JNet.Runtime-test.yml?query=branch%3Amain)

## The components

|Component|Description|Package|
|-|-|-|
|[JNet](src/JNet.Runtime)|The metapackage that refers to all JNet library.|[![JNet](https://img.shields.io/nuget/v/JNet)](http://nuget.org/packages/JNet)|
|[JNet.Runtime](src/JNet.Runtime)|The wrapper library around the JVM library. This is the base runtime to JNet.|[![JNet](https://img.shields.io/nuget/v/JNet.Runtime)](http://nuget.org/packages/JNet.Runtime)|
|[JNet.Runtime.Sample](src/JNet.Runtime.Sample)|A sample application project using JNet.Runtime.|

## Read the docs

JNet is a solution of libraries that runs using the JNet.Runtime. First you need to known about JNI concepts to understand how the runtime interacts with the JVM.

* [JNet.Runtime](src/JNet.Runtime)
* [Java Development Kit Specifications - Java Native Interface Specification](https://docs.oracle.com/en/java/javase/15/docs/specs/jni/index.html)
* [IBM SDK, Java Technology Edition 7 - The Java Native Interface (JNI)](https://www.ibm.com/docs/en/sdk-java-technology/7?topic=components-java-native-interface-jni)

# Bug Reports
If you find any bugs, please report them using the GitHub issue tracker.

# License
This software is distributed under the terms of the Apache 2.0 license
(see [LICENSE.txt](LICENSE.txt)).