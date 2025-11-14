using System.CommandLine;

var nameArgument = new Argument<string>("name") { Description = "Name of the person to greet" };
var timesArgument = new Argument<int>("times") { Description = "Number of times to greet" };
var upperOption = new Option<bool>("upper", ["--uppercase", "-u"]) { Description = "Output in uppercase" };

// demo greet <name> <times> -u
var greetCommand = new Command("greet", "Prints a greeting")
{
    nameArgument,
    timesArgument,
    upperOption
};

greetCommand.SetAction(async (parsed) =>
{
    var name = parsed.GetRequiredValue(nameArgument);
    var times = parsed.GetValue(timesArgument);
    var uppercase = parsed.GetValue(upperOption);

    var message = $"Hello, {name}!";
    if (uppercase)
        message = message.ToUpperInvariant();

    for (int i = 0; i < times; i++)
        Console.WriteLine(message);

    return 0;
});

var rootCommand = new RootCommand("Demo CLI")
{
    greetCommand
};

var app = rootCommand.Parse(args);

return await app.InvokeAsync();
