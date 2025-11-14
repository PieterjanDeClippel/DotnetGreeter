using ConsoleApp4;
using Demo;
using Microsoft.Extensions.Hosting;
using MintPlayer.CliGenerator.Attributes;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddGreetCommand().AddDemoServices();
var app = builder.Build();
var exitCode = await app.InvokeGreetCommandAsync(args);
return exitCode;


namespace Demo
{
    [CliRootCommand(Name = "demo", Description = "Demonstrates the CLI command generator")]
    public partial class GreetCommand : ICliCommand
    {
        public Task<int> Execute(CancellationToken cancellationToken)
        {
            Console.WriteLine("Use this command to greet someone");
            return Task.FromResult(0);
        }
    }
}