using Avalonia;
using Avalonia.Headless;

[assembly: AvaloniaTestApplication(typeof(RapidPack.Tests.TestApp))]
namespace RapidPack.Tests;

public class TestApp
{
    // Ta metoda jest szukana przez Avalonia.Headless.
    // Musi się nazywać dokładnie tak: BuildAvaloniaApp
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}