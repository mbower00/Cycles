using cse210_cycles.Game.Casting;
using cse210_cycles.Game.Services;


namespace cse210_cycles.Game.Scripting
{
    public class JumpActorAction : Action
    {
        KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
        public JumpActorAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, string player)
        {
            // Cycle cycle = (Cycle)cast.GetFirstActor("Cycle"); //Original Code
            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle");
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
            Cycle cycle = cycle1;
            if (player == "player1"){
                cycle = cycle1;
            }
            else if (player == "player2"){
                cycle = cycle2;
            }
            
            if (player == "player1"){
                if (keyboardService.IsKeyDown("e") && cycle.GetJumpCooldownTick() >= Constants.JUMP_COOLDOWN_CONDITION)
                {
                    cycle.SetDrawing(false);
                    cycle.SetIsIncognito(true);
                    cycle.SetJumpCooldownTick(0);
                }
            }

            else if (player == "player2"){
                if (keyboardService.IsKeyDown("u") && cycle.GetJumpCooldownTick() >= Constants.JUMP_COOLDOWN_CONDITION)
                {
                    cycle.SetDrawing(false);
                    cycle.SetIsIncognito(true);
                    cycle.SetJumpCooldownTick(0);
                }
            }

            if (cycle.GetJumpCooldownTick() > Constants.JUMP_FRAME_DURATION){
                cycle.SetDrawing(true);
                cycle.SetIsIncognito(false);
            }
        }


    }
}