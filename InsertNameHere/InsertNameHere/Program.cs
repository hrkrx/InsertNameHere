using System;
using InsertNameHere.Controller;

namespace InsertNameHere
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Shoot("Init Settings Window");
            //Loads the Settings Window
            Settings s = new Settings();
            var res = s.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                using (var game = new Game1())
                {
                    Logger.Shoot("Init Settings for the Game");
                    // Passes the Resolution and Fullscreen parameters
                    game.LaunchParameters.Add("Height", s.rHeight);
                    game.LaunchParameters.Add("Width", s.rWidth);
                    game.LaunchParameters.Add("Fullscreen", s.Fullscreen ? "yes" : "no");
                    Logger.Shoot(string.Format("Height = {0} Width = {1} Fullscreen = {2}", s.rHeight, s.rWidth, s.Fullscreen));
                    game.Run();
                }
            }
            Logger.Shoot("Exit");
        }
    }
#endif
}
