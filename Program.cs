using cse210_cycles.Game.Casting;
using cse210_cycles.Game.Directing;
using cse210_cycles.Game.Scripting;
using cse210_cycles.Game.Services;
using cse210_cycles.Game;


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

            //SoundService ss = new SoundService();
            //string filename = "Game/Services/roblox-death-sound_1.mp3" ;
            //ss.PlaySound(filename); 
            
            // create the cast 
            Cast cast = new Cast();

            Cycle cycle1 = new Cycle(Constants.RED, "player1");
            Cycle cycle2 = new Cycle(Constants.BLUE, "player2");
            cast.AddActor("cycle", cycle1);
            cast.AddActor("cycle", cycle2);

            //CREATE PLAYER TAG OBJECTS IN THE "messages" CAST GROUP

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new SteerActorsAction(keyboardService));
            script.AddAction("input", new JumpActorAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
            
        }
    }
}