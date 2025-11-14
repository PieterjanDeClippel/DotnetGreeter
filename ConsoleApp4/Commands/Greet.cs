using MintPlayer.CliGenerator.Attributes;

namespace Demo;

[CliParentCommand(typeof(GreetCommand))]
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
}