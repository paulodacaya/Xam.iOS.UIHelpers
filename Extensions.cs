using UIKit;

namespace Xam.iOS.UIHelpers
{
    public static class UIViewControllerExtensions
    {
        /// <summary>
        /// Add child view controller to parent.
        /// </summary>
        public static void AddChild(this UIViewController that, UIViewController viewController)
        {
            that.AddChildViewController(viewController);
            that.View.AddSubview(viewController.View);
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
