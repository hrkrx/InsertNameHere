using System;

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
            //Loads the Settings Window
            Settings s = new Settings();
            var res = s.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                using (var game = new Game1())
                {
                    // Passes the Resolution and Fullscreen parameters
                    game.LaunchParameters.Add("Height", s.rHeight);
                    game.LaunchParameters.Add("Width", s.rWidth);
                    game.LaunchParameters.Add("Fullscreen", s.Fullscreen ? "yes" : "no");
                    game.Run();
                }
            }
        }
    }
#endif
}
