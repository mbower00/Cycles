using cse210_cycles.Game.Casting;
using cse210_cycles.Game.Services;


namespace cse210_cycles.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class SteerActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public SteerActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script, string player)
        {
            if (player == "player1"){
                // left 1
                if (keyboardService.IsKeyDown("a"))
                {
                    direction = new Point(-Constants.CELL_SIZE, 0);
                }

                // right 1
                if (keyboardService.IsKeyDown("d"))
                {
                    direction = new Point(Constants.CELL_SIZE, 0);
                }

                // up 1
                if (keyboardService.IsKeyDown("w"))
                {
                    direction = new Point(0, -Constants.CELL_SIZE);
                }

                // down 1
                if (keyboardService.IsKeyDown("s"))
                {
                    direction = new Point(0, Constants.CELL_SIZE);
                }
            }
            else if (player == "player2"){
                // left 2
                if (keyboardService.IsKeyDown("j"))
                {
                    direction = new Point(-Constants.CELL_SIZE, 0);
                }

                // right 2
                if (keyboardService.IsKeyDown("l"))
                {
                    direction = new Point(Constants.CELL_SIZE, 0);
                }

                // up 2
                if (keyboardService.IsKeyDown("i"))
                {
                    direction = new Point(0, -Constants.CELL_SIZE);
                }

                // down 2
                if (keyboardService.IsKeyDown("k"))
                {
                    direction = new Point(0, Constants.CELL_SIZE);
                }
            }

            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle");
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
            Cycle cycle = cycle1;
            if (player == "player1"){
                cycle = cycle1;
            }
            else if (player == "player2"){
                cycle = cycle2;
            }
            cycle.TurnHead(direction);

        }
    }
}