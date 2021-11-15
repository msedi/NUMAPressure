using System;
using System.Collections;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Hardcore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"ProcessorCount: {Environment.ProcessorCount}");

            ThreadPool.GetMaxThreads(out var w, out _);
            Console.WriteLine($"Runtime: {RuntimeInformation.ProcessArchitecture}");
            Console.WriteLine($"MaxThreads: {w}");
            Console.WriteLine($"MaxThreads: {w}");
            Console.WriteLine($"AllGroups: {Environment.GetEnvironmentVariable("DOTNET_Thread_UseAllCpuGroups")}");

            Console.WriteLine();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Process");
            foreach (DictionaryEntry data in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process))
            {
                Console.WriteLine($"{data.Key}={data.Value}");
            }

            Console.WriteLine();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("User");
            foreach (DictionaryEntry data in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User))
            {
                Console.WriteLine($"{data.Key}={data.Value}");
            }

            Console.WriteLine();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Machine");
            foreach (DictionaryEntry data in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
            {
                Console.WriteLine($"{data.Key}={data.Value}");
            }


            ParallelOptions options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };


            Parallel.For(0, 100, options, idx =>
            {
                Random r = new();
                double result = 0;

                for (long i = 0; i < long.MaxValue; i++)
                {
                    unchecked { result += Math.Log(r.NextDouble()); };
                }

                Console.WriteLine($"Result {result}");
            });

            Console.WriteLine("Finished");
        }
    }
}
