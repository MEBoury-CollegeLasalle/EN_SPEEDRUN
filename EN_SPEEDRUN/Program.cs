using EN_SPEEDRUN.Services;

namespace EN_SPEEDRUN;

internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.


        if (args.Contains("hasher")) {
            MainService.GetInstance().InitTempHasher();
        } else {
            MainService.GetInstance().InitApplication();
        }
    }
}