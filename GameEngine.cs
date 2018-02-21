using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Game
{
    class GameEngine
    {
        const byte FPS_LIMIT = 60;
        Game game;
        private bool stopping;
        Stopwatch stopwatch;
        private long then;

        public GameEngine(Game game)
        {
            this.game = game;
            then = 0;
            stopwatch = new Stopwatch();
        }
        public void Start()
        {
            game.Init();
            stopwatch.Start();
            Loop();
        }
        public void Stop()
        {
            stopwatch.Stop();
            stopping = true;
        }
        private void Loop()
        {
            long now = stopwatch.ElapsedMilliseconds;
            //Wait a bit before continuing if we're going too fast
            if(now - then < 1000/FPS_LIMIT)
            {
                //Wait the difference
                byte waitTime = (byte)(1000 / FPS_LIMIT - (now - then));
                Thread.Sleep(waitTime);
            }
            
            //Get time since last time in ms
            int delta = CalculateDelta(now);

            game.Update(delta);
            game.Draw();
            Thread.Sleep(0);
            if (!stopping) Loop();
        }

        //Returns delta in ms
        private int CalculateDelta(long now)
        {
            int delta = (int)(now - then);
            then = now;
            return delta;
        }
    }
}
