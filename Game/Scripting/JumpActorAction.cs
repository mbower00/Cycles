using cse210_cycles.Game.Casting;
using cse210_cycles.Game.Services;


namespace cse210_cycles.Game.Scripting
{
    public class JumpActorAction : Action
    {
        Cycle cycle; 
        KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
        public JumpActorAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("Cycle");
               if (keyboardService.IsKeyDown("e") && cycle.GetJumpCooldownTick() >= Constants.JUMP_COOLDOWN_CONDITION)
            {
                
            }
        }


    }
}