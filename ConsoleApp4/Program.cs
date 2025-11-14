using Demo;
using Microsoft.Extensions.Hosting;
using MintPlayer.CliGenerator.Attributes;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddGreetCommand();
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

        [CliCommand("greet", Description = "Greets a person")]
        public partial class Greet : ICliCommand
        {
            public Task<int> Execute(CancellationToken cancellationToken)
            {
                if (Verbose)
                    Console.WriteLine("Running demo command in verbose mode");

                var message = $"Hello, {Name}!";
                for (var i = 0; i < Times; i++)
                    Console.WriteLine(Uppercase ? message.ToUpperInvariant() : message);

                return Task.FromResult(0);
            }

            [CliArgument(0, Name = "name", Description = "Name of the person to greet")]
            public string Name { get; set; }

            [CliArgument(1, Name = "times", Description = "Number of times to greet")]
            public int Times { get; set; }

            [CliOption("--uppercase", "-u", Description = "Output in uppercase")]
            public bool Uppercase { get; set; }

            [CliOption("--verbose", "-v", Description = "Enable verbose output")]
            public bool Verbose { get; set; }

            [CliCommand("farewell", Description = "Says farewell to a person")]
            public partial class Farewell : ICliCommand
            {
                public Task<int> Execute(CancellationToken cancellationToken)
                {
                    var farewellMessage = $"Goodbye, {Name}!";
                    if (!string.IsNullOrEmpty(MeetAgain))
                    {
                        farewellMessage += $" See you again {MeetAgain}.";
                    }
                    Console.WriteLine(farewellMessage);
                    return Task.FromResult(0);
                }

                [CliArgument(0, Name = "name", Description = "Name of the person to bid farewell")]
                public string Name { get; set; }

                [CliOption("--meet-again", "-m", Description = "When will we meet again")]
                public string MeetAgain { get; set; }
            }
        }
    }
}