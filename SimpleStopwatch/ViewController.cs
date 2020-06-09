using System;
using System.Diagnostics;
using AppKit;
using Foundation;

namespace SimpleStopwatch
{
    public partial class ViewController : NSViewController
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetElapsedTime();

            var timer = NSTimer.CreateRepeatingTimer(TimeSpan.FromMilliseconds(100), t =>
            {
                if (_stopwatch.IsRunning)
                {
                    SetElapsedTime();
                }
            });
            
            NSRunLoop.Main.AddTimer(timer, NSRunLoopMode.Common);
        }

        private void SetElapsedTime()
        {
            var emoji = _stopwatch.IsRunning ? "⏱️" : "🛑";
            Time.StringValue = $"{emoji}️ {_stopwatch.Elapsed:g}";
        }

        partial void Reset(AppKit.NSButton sender)
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Restart();
            }
            else
            {
                _stopwatch.Reset();
            }

            SetElapsedTime();
        }

        partial void Start(AppKit.NSButton sender)
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
                sender.Title = "Start";
            }
            else
            {
                _stopwatch.Start();
                sender.Title = "Stop";
            }
            
            SetElapsedTime();
        }
    }
}
