using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleGame
{
    public class Bench
    {
        DateTime _lastCheckTime = DateTime.Now;
        long _frameCount = 0;
        int wait = 0;
        double fps = 0;

        public double DoGetFps()
        {
            if (wait > 10)
            {
                fps = GetFps();
                wait = 0;
            }
            else
                wait++;
            return fps;
        }

        // called whenever a map is updated
        public void OnMapUpdated()
        {
            Interlocked.Increment(ref _frameCount);
        }

        // called every once in a while
        public double GetFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            long count = Interlocked.Exchange(ref _frameCount, 0);
            double fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            return fps;
        }
    }
}
