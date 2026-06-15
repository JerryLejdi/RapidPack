using Avalonia.Headless.XUnit;

namespace RapidPack.Tests;

public class MainWindowTests
{
   [AvaloniaFact]
   public void CreateWindow_ShouldCreateANewWindow()
   {
      var window = new MainWindow();
      Assert.NotNull(window);
   }
}