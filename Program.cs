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
            Actor playerTag1 = new Actor();
            Actor playerTag2 = new Actor();

            ///setting the banners to the propspective player colors
            playerTag1.SetColor(Constants.BANNER_RED);
            playerTag2.SetColor(Constants.BANNER_BLUE);


            ///Creating Positions for the player banners that show up in their prospective corners
            Point position1 = new Point(Constants.MAX_X-900, Constants.MAX_Y-600);
            Point position2 = new Point(Constants.MAX_X, Constants.MAX_Y-600); 
            playerTag1.SetPosition(position1); 
            playerTag2.SetPosition(position2);

            ///Instructions and the full text of the banner
            playerTag1.SetText("Player 1: WASD & E = Jump"); 
            playerTag2.SetText("Player 2: IJKL & U = Jump");


            //Create the _timer_ actor
            Game.Casting.Timer timer = new Game.Casting.Timer();
            timer.SetColor(Constants.BANNER_WHITE);
            Point timerStartingPoint = new Point(Constants.MAX_X / 2 - 50, 0 + (Constants.MAX_Y - 100));
            timer.SetPosition(timerStartingPoint);
            timer.SetText("");
            timer.SetFontSize(50);
            //Add timer to cast
            cast.AddActor("timer", timer);



            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new SteerActorsAction(keyboardService));
            script.AddAction("input", new JumpActorAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new ManageTimerAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
            
        }
    }
}