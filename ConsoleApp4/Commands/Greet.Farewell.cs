using MintPlayer.CliGenerator.Attributes;

namespace Demo;

[CliCommand("farewell", Description = "Says farewell to a person")]
[CliParentCommand(typeof(Greet))]
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
