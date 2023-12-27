using PhotinoNET;

namespace ValiantTemplate;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        var app = ServerBuilder.BuildWebApplication();
        app.RunAsync();

        var window = new PhotinoWindow()
            .SetTitle("Valiant Template")
            .SetUseOsDefaultSize(false)
            .SetSize(1024, 768)
            .SetMinSize(640, 480)
            .Center()
            .Load(ServerUrl.GetFromApp(app));

        window.WaitForClose();

        app.StopAsync().Wait();
    }
}
