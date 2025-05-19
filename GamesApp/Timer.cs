using System.Diagnostics;

namespace GamesApp
{
    internal class Timer
    {
        System.Windows.Forms.Timer timer;
        Stopwatch stopwatch = new Stopwatch();

        public event EventHandler Tick;

        public Timer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += OnTick;
        }

        public void Start()
        { 
            timer.Start();
            stopwatch.Restart();
        }

        public void Stop()
        {
            timer.Stop();
            stopwatch.Stop();
        }

        private void OnTick(object sender, EventArgs e)
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }

        public string GetTime()
        { 
            return $"{(int)stopwatch.Elapsed.TotalMinutes:D2}:{stopwatch.Elapsed.Seconds:D2}";
        }
    }
}
