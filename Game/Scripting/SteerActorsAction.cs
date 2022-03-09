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
        private Point direction1 = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);

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
            if (player == "player1") // only execute this method once per frame
            {
                // left 1
                if (keyboardService.IsKeyDown("a"))
                {
                    direction1 = new Point(-Constants.CELL_SIZE, 0);
                }

                // right 1
                if (keyboardService.IsKeyDown("d"))
                {
                    direction1 = new Point(Constants.CELL_SIZE, 0);
                }

                // up 1
                if (keyboardService.IsKeyDown("w"))
                {
                    direction1 = new Point(0, -Constants.CELL_SIZE);
                }

                // down 1
                if (keyboardService.IsKeyDown("s"))
                {
                    direction1 = new Point(0, Constants.CELL_SIZE);
                }

                // left 2
                if (keyboardService.IsKeyDown("j"))
                {
                    direction2 = new Point(-Constants.CELL_SIZE, 0);
                }

                // right 2
                if (keyboardService.IsKeyDown("l"))
                {
                    direction2 = new Point(Constants.CELL_SIZE, 0);
                }

                // up 2
                if (keyboardService.IsKeyDown("i"))
                {
                    direction2 = new Point(0, -Constants.CELL_SIZE);
                }

                // down 2
                if (keyboardService.IsKeyDown("k"))
                {
                    direction2 = new Point(0, Constants.CELL_SIZE);
                }

                Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle");
                Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
                cycle1.TurnHead(direction1);
                cycle2.TurnHead(direction2);
            }
        }
    }
}