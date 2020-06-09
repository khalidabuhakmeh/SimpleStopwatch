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

            Time.StringValue = _stopwatch.Elapsed.ToString("g");

            var timer = NSTimer.CreateRepeatingTimer(TimeSpan.FromMilliseconds(100), t =>
            {
                if (_stopwatch.IsRunning)
                {
                    Time.StringValue = _stopwatch.Elapsed.ToString("g");
                }
            });
            
            NSRunLoop.Main.AddTimer(timer, NSRunLoopMode.Common);
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

            Time.StringValue = _stopwatch.Elapsed.ToString("g");
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
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
