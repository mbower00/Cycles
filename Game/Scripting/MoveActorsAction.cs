using System.Collections.Generic;
using cse210_cycles.Game.Casting;


namespace cse210_cycles.Game.Scripting
{
    // TODO: Implement the MoveActorsAction class here

    // 1) Add the class declaration. Use the following class comment. Make sure you
    //    inherit from the Action class.

    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>
    class MoveActorsAction : Action{


    // 2) Create the class constructor. Use the following method comment.

    /// <summary>
    /// Constructs a new instance of MoveActorsAction.
    /// </summary>
        public MoveActorsAction(){}

    // 3) Override the Execute(Cast cast, Script script) method. Use the following 
    //    method comment. You custom implementation should do the following:
        public void Execute(Cast cast, Script script, string player){
            // a) get all the actors from the cast
            List<Actor> actors = cast.GetAllActors();
            // b) loop through all the actors
            foreach(Actor i in actors){
                // c) call the MoveNext() method on each actor.
                i.MoveNext();
            }
        }

    }
}