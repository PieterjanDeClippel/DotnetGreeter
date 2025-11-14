using MintPlayer.CliGenerator.Attributes;
using MintPlayer.SourceGenerators.Attributes;

namespace Demo;

[CliCommand("farewell", Description = "Says farewell to a person")]
[CliParentCommand(typeof(Greet))]
public partial class Farewell : ICliCommand
{
    [Inject] private readonly IDemoService demoService;

    public async Task<int> Execute(CancellationToken cancellationToken)
    {
        var farewellMessage = await demoService.GetGoodbyeMessageFor(Name, MeetAgain);
        Console.WriteLine(farewellMessage);
        return 0;
    }

    [CliArgument(0, Name = "name", Description = "Name of the person to bid farewell")]
    public string Name { get; set; }

    [CliOption("--meet-again", "-m", Description = "When will we meet again")]
    public string MeetAgain { get; set; }
}
