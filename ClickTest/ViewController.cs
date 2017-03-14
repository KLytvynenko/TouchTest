using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ClickTest
{
    
    public partial class ViewController : UIViewController, IUIGestureRecognizerDelegate
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        UIButton audioView;
        UIView textView;


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            audioView = new UIButton(new CGRect(50, 50, 100, 100)) { BackgroundColor = UIColor.Purple };
            audioView.UserInteractionEnabled = true;
            var g = new UIPanGestureRecognizer(() => Console.WriteLine("audio view")) { CancelsTouchesInView = false };
            g.Delegate = this;
            audioView.AddGestureRecognizer(g);

            textView = new UIView(new CGRect(0,0,200,200)) { BackgroundColor = UIColor.Red };
            textView.UserInteractionEnabled = true;
            var r = new UIPanGestureRecognizer(() => Console.WriteLine("back view")) { CancelsTouchesInView = false };
            r.Delegate = this;

            var m = new UIPanGestureRecognizer(() => Console.WriteLine("main view")) { CancelsTouchesInView = false };
            m.Delegate = this;
            View.UserInteractionEnabled = true;
            textView.AddGestureRecognizer(r);
            View.AddGestureRecognizer(m);
            View.AddSubviews(textView, audioView);
        }

        [Export("gestureRecognizer:shouldReceiveTouch:")]
        public bool ShouldReceiveTouch(UIGestureRecognizer recognizer, UITouch touch)
        { 
            return true;
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {   
            base.TouchesMoved(touches, evt);
        }

        [Export("gestureRecognizerShouldBegin:")]
        public bool ShouldBegin(UIGestureRecognizer recognizer)
        {
            return true;
        }

        [Export("gestureRecognizer:shouldRecognizeSimultaneouslyWithGestureRecognizer:")]
        public bool ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)
        {
            return true;
        }
    }
}
