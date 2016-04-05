using System;

namespace TP_Pong
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

///******************************************************************************************************///
/// ******************************************* PROBLEMS/SOLUTIONS *************************************///
/// Current Porblem : How to make the pongs move only when the buttons are down (not a continous move). ///
/// Reflexion : It's most probably because of the update function and how it updates the position.      ///
///             Need to stop the update each time the button is pressed.                                ///
///             Or find something to do with the ElapsedGameTime.                                       ///
///  Solution : Using of isKeyUp to control the release of the buttons. It seems to be a good solution  ///
///             but dont really like it. Try to google/find something better.                           ///
///*****************************************************************************************************///
