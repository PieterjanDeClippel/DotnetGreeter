using Microsoft.Extensions.DependencyInjection;
using MintPlayer.SourceGenerators.Attributes;

namespace Demo;

public interface IDemoService
{
    Task<string> GetGoodbyeMessageFor(string name, string meetAgain);
}


[Register(typeof(IDemoService), ServiceLifetime.Scoped, "DemoServices")]
internal class DemoService : IDemoService
{
    public Task<string> GetGoodbyeMessageFor(string name, string meetAgain)
    {
        var farewellMessage = $"Goodbye, {name}!";
        if (!string.IsNullOrEmpty(meetAgain))
            farewellMessage += $" See you again {meetAgain}.";

        return Task.FromResult(farewellMessage);
    }
}
