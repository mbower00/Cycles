using System.Collections.Generic;
using cse210_cycles.Game.Casting;
using cse210_cycles.Game.Services;


namespace cse210_cycles.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/> 
        public void Execute(Cast cast, Script script, string player)
        {
            if (player == "player1") //we will only run this method once per frame
            {
                // Cycle cycle = (Cycle)cast.GetFirstActor("cycle"); //Original Code
                Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle");
                Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
                Cycle cycle = cycle1;
                if (player == "player1"){
                    cycle = cycle1;
                }
                else if (player == "player2"){
                    cycle = cycle2;
                }
                List<Actor> segments = cycle1.GetSegments();
                List<Actor> segments2 = cycle2.GetSegments();
                segments.AddRange(segments2);
                Actor score = cast.GetFirstActor("score");
                // food = cast.GetFirstActor("food");
                List<Actor> messages = cast.GetActors("messages");
                videoService.ClearBuffer();
                videoService.DrawActors(segments);
                videoService.DrawActors(messages);
                videoService.DrawActor(cast.GetFirstActor("timer"));
                videoService.FlushBuffer();
            }
        }
    }
}