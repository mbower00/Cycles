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
            // Cycle cycle = (Cycle)cast.GetFirstActor("cycle"); //Original Code
            if(player == "player1"){
                Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
                return cycle;}
            else if(player == "player2"){
                Cycle cycle = (Cycle)cast.GetSecondActor("cycle");
                return cycle;
            }
            List<Actor> segments = cycle.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActor(score);
            videoService.DrawActor(food);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}