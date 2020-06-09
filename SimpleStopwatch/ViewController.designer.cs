// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SimpleStopwatch
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField Time { get; set; }

		[Action ("Reset:")]
		partial void Reset (AppKit.NSButton sender);

		[Action ("Start:")]
		partial void Start (AppKit.NSButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (Time != null) {
				Time.Dispose ();
				Time = null;
			}

		}
	}
}
