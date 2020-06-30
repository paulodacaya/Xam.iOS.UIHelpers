using UIKit;

namespace Xam.iOS.UIHelpers
{
    public static class UIViewControllerExtensions
    {
        /// <summary>
        /// Add child view controller to parent controller's view.
        /// </summary>
        public static void AddChild(this UIViewController that, UIViewController viewController)
        {
            that.AddChild(viewController, null);
        }

        /// <summary>
        /// Add child view controller to parent controller. This controller will be the subview of
        /// provided <b>superView</b>. If <b>superView</b> is null, it will default to parent controller's view.
        /// </summary>
        public static void AddChild(this UIViewController that, UIViewController viewController, UIView superView)
        {
            var view = superView ?? viewController.View;
            that.AddChildViewController(viewController);
            that.View.AddSubview(view);
            viewController.DidMoveToParentViewController(that);
        }

        /// <summary>
        /// Remove child view controller from parent.
        /// </summary>
        public static void RemoveChild(this UIViewController that, UIViewController viewController)
        {
            if (viewController.ParentViewController != null)
            {
                viewController.WillMoveToParentViewController(null);
                viewController.View.RemoveFromSuperview();
                viewController.RemoveFromParentViewController();
            }
        }
    }
}
