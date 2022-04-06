using System;
using System.Collections.Generic;
using System.Data;
using cse210_cycles.Game.Casting;
using cse210_cycles.Game.Services;


namespace cse210_cycles.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class ManageTimerAction : Action
    {

        /// <summary>
        /// Constructs a new instance of ManageTimerAction.
        /// </summary>
        public ManageTimerAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script, string player){
            if (player == "player1"){

            Actor timerActor = cast.GetFirstActor("timer");
            Timer timer = (Timer) timerActor;

            timer.SetText($"{timer.GetSecondTick()}");

            timer.IncremenFrameTick();

            if (timer.GetFrameTick() % Constants.FRAME_RATE == 0 && timer.GetFrameTick() != 0){
                timer.IncrementSecondTick();
            } 

            }
        }
    }
}