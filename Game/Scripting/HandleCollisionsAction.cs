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
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script, string player)
        {
            if (isGameOver == false)
            {
                HandleFoodCollisions(cast, player);
                HandleSegmentCollisions(cast, player);
                HandleGameOver(cast, player);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleFoodCollisions(Cast cast, string player)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Score score = (Score)cast.GetFirstActor("score");
            Food food = (Food)cast.GetFirstActor("food");
            
            if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
            {
                int points = food.GetPoints();
                snake.GrowTail(points);
                score.AddPoints(points);
                food.Reset();
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast, string player)
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
            Actor head = cycle.GetHead();
            List<Actor> body = cycle.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast, string player)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
            }
        }

    }
}