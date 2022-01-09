using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _01.Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch sw = new Stopwatch();
        private TimeSpan ts = new TimeSpan();
        private List<string> laps = new List<string>();

        public Chronometer()
        {

        }

        public string GetTime => tsToString(sw.Elapsed);

        public List<string> Laps => laps;

        private string tsToString(TimeSpan timeSpan)
        {
            return $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:0000}";
        }

        public string Lap()
        {
            ts = sw.Elapsed;
            string lap = tsToString(ts);
            laps.Add($"{laps.Count}. {lap}");

            return lap;
        }

        public void Reset()
        {
            sw.Reset();
            ts = new TimeSpan();
            laps.Clear();
        }

        public void Start()
        {
            sw.Start();
        }

        public void Stop()
        {
            sw.Stop();
            ts = sw.Elapsed;
        }
    }
}
