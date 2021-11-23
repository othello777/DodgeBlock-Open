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
        List<double> frames = new List<double>();

        // called every tick. automatically calls GetFps every once in a while
        public double DoGetFps()
        {
            if (wait > 10)
            {
                fps = GetFps();
                frames.Add(fps);
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

        //gets the average of all records
        public double GetAverageFps()
        {
            double sum = 0;
            foreach (var frame in frames)
            {
                sum += frame;
            }
            return Math.Round(sum / frames.Count, 4);
        }
    }
}
