using cse210_cycles.Game.Casting;
using cse210_cycles.Game.Directing;
using cse210_cycles.Game.Scripting;
using cse210_cycles.Game.Services;


namespace cse210_cycles
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>

        static void Main(string[] args)
        {

            SoundService ss = new SoundService();
            string filename = "Game/Services/roblox-death-sound_1.mp3" ;
            ss.PlaySound(filename) 
                                     
            // Just a test - for now
            Color player1 = new Color(255,0,0);
            Color player2 = new Color(0,0,255);
            
            // create the cast 
            Cast cast = new Cast();
            // cast.AddActor("food", new Food());
            cast.AddActor("cycle", new Cycle(player1));
            cast.AddActor("cycle", new Cycle(player2));
            // cast.AddActor("score", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
            
        }
    }
}