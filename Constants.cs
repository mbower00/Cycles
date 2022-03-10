using System;
using Microsoft.VisualBasic;
using cse210_cycles.Game.Casting;

namespace cse210_cycles.Game
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "CYCLE";
        public static int CYCLE_START_LENGTH = 1;
        public static int JUMP_FRAME_DURATION = 5;
        public static int JUMP_HEIGHT = 10; //the amount that a jumping cycle grows
        public static int JUMP_COOLDOWN_CONDITION = 20; //in frames
        public static Color RED = new Color(255, 0, 0);
        public static Color BANNER_RED = new Color(255, 0, 0, 175);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
        public static Color BLUE = new Color(0, 0, 255);
        public static Color BANNER_BLUE = new Color(0, 0, 255, 175);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color BANNER_WHITE = new Color(255, 255, 255, 175);
    }
}

