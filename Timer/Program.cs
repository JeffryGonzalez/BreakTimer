// See https://aka.ms/new-console-template for more information

using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Menus;

var menu = new TextMenu
{
    TitleText = "Choose a break time"
};

menu.AddItems(new List<TextMenuItem>()
{
    new TextMenuItem()
    {
        Id= "1",
        Text = "15 Minutes",
        Command = new TimerCommand(15)
    },
    new TextMenuItem()
    {
        Id= "2",
        Text = "10 Minutes",
        Command = new TimerCommand(10)
    },
    new TextMenuItem()
    {
        Id="3",
        Text = "1 Minute",
        Command = new TimerCommand(1)
    }
});

menu.Display();

class TimerCommand : ICommand
{
    private readonly int _minutes;
    public TimerCommand(int minutes)
    {
        _minutes = minutes;
    }

    public void Execute()
    {
        var endTime = DateTime.Now.AddMinutes(_minutes);
        Console.WriteLine($"Tell them to be back at {endTime:T}");
        Pause.QuickDisplay("Hit Enter to Start");
        while (true)
        {
            var timeLeft = DateTime.Now - endTime;
            Console.Write($"You have {Math.Abs(timeLeft.Minutes)}:{Math.Abs(timeLeft.Seconds)} left until {endTime:T}");
            if (DateTime.Now >= endTime) break;
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop );

        }
        
        Console.WriteLine("\n\nBREAK IS OVER!");
    }

    public bool IsActive { get; } = true;
}