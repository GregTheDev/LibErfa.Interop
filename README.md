# LibErfa.Interop

.NET wrapper for the liberfa library. 

Includes v2.0.1 of [liberfa](https://github.com/liberfa/erfa) and supports Windows, Linux and MacOS (Intel only for now).

# API Reference

Limited functionality is available initially. If you need a function that is not currently available you can log an issue and it will be added as quickly as possible.

For a full list of available functions see [here](https://github.com/GregTheDev/LibErfa.Interop/wiki/API-Reference).

# Installation

Install the [LibErfa.Interop pacakge](https://www.nuget.org/packages/LibErfa.Interop) from NuGet.

## .NET CLI

```bash
dotnet add package LibErfa.Interop
```

## Package Manager Console

```bash
Install-Package LibErfa.Interop
```

# Usage

Include the `LibErfa.Interop` namespace in your `using` statements.

All methods are exposed as static methods on the `Erfa` class.

```c#
using LibErfa.Interop;

namespace SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] p = new double[3];
            double theta = 0;
            double phi = 0;

            p[0] = 100.0;
            p[1] = -50.0;
            p[2] = 25.0;

            Erfa.c2s(p, ref theta, ref phi);

            Console.WriteLine(result);
        }
    }
}

```


