namespace cse210_cycles.Game.Casting{
    class Timer : Actor{
        private int frameTick = -1;
        private int secondTick = 0;
        
        public Timer(){
            
        }

        public void SetFrameTick(int frameTick)
        {
            this.frameTick = frameTick;
        }
        
        public int GetFrameTick()
        {
            return frameTick;
        }

        public void IncremenFrameTick(){
            frameTick++;
        }

        public void SetSecondTick(int secondTick)
        {
            this.secondTick = secondTick;
        }
        
        public int GetSecondTick()
        {
            return secondTick;
        }

        public void IncrementSecondTick(){
            secondTick++;
        }

    }

}