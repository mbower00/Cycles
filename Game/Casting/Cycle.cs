using System;
using System.Collections.Generic;
using System.Linq;

namespace cse210_cycles.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Cycle : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private bool isIncognito = false;
        private bool isDrawing = true;
        private int jumpCooldownTick = Constants.JUMP_COOLDOWN_CONDITION; //starts ready to jump
        private Color trailColor;
        

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Cycle(Color color, string player)
        {
            SetColor(color);
            this.trailColor = GetColor();
            PrepareBody(player);
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1));
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor cycle = GetHead();
                Point velocity = cycle.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = cycle.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(trailColor);
                segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            if (jumpCooldownTick >= Constants.JUMP_COOLDOWN_CONDITION){GetHead().SetColor(trailColor);} //if ready to jump, set color to the trail color
            else{GetHead().SetColor(Constants.WHITE);} //else, set color to white
            //if(trailColor == Constants.RED){Console.WriteLine(jumpCooldownTick);} //print Red's cooldown tick

            if (jumpCooldownTick <= Constants.JUMP_FRAME_DURATION){
                GetHead().SetFontSize(Constants.FONT_SIZE + Constants.JUMP_HEIGHT);
            }
            else{
                GetHead().SetFontSize(Constants.FONT_SIZE);
            }

            segments[0].MoveNext();
            if (isDrawing){GrowTail(1);} //if drawing, add a segment

            jumpCooldownTick++; //increment the cooldown
        }

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody(string player)
        {
            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;

            if (player == "player1"){
                x = Constants.MAX_X / 4;
            }
            if (player == "player2"){
                x = Constants.MAX_X / 4 * 3;
            }

            for (int i = 0; i < Constants.CYCLE_START_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "@" : "#";
                Color color = i == 0 ? GetColor() : trailColor;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
            }
        }

        public void SetDrawing(bool isDrawing){
            this.isDrawing = isDrawing;
        }

        public bool IsDrawing(){
            return isDrawing;
        }

        public void SetIsIncognito(bool isIncognito){
            this.isIncognito = isIncognito;
        }

        public bool GetIsIncognito(){
            return isIncognito;
        }

        public void SetJumpCooldownTick(int jumpCooldownTick){
            this.jumpCooldownTick = jumpCooldownTick;
        }

        public int GetJumpCooldownTick(){
            return jumpCooldownTick;
        }

        public void SetTrailColor(Color trailColor){
            this.trailColor = trailColor;
        }

        public Color GetTrailColor(){
            return trailColor;
        }
    }
}