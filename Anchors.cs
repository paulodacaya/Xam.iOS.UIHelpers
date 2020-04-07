using System;
using CoreGraphics;
using UIKit;

namespace Xam.iOS.UIHelpers
{
    public static class Anchors
    {
        /// <summary>
        /// Activate constraints on a UIView.
        /// </summary>
        public static UIView ActivateConstaints(this UIView view)
        {
            view.TranslatesAutoresizingMaskIntoConstraints = false;
            return view;
        }

        /// <summary>
        /// Constraint leading anchor to another anchor.
        /// </summary>
        public static UIView ConstraintLeadingEqualTo(this UIView view, NSLayoutXAxisAnchor anchor, nfloat constant = default)
        {
            view.LeadingAnchor.ConstraintEqualTo(anchor, constant).Active = true;
            return view;
        }

        /// <summary>
        /// Constraint top anchor to another anchor.
        /// </summary>
        public static UIView ConstraintTopEqualTo(this UIView view, NSLayoutYAxisAnchor anchor, nfloat constant = default)
        {
            view.TopAnchor.ConstraintEqualTo(anchor, constant).Active = true;
            return view;
        }

        /// <summary>
        /// Constraint trailing anchor to another anchor.
        /// </summary>
        public static UIView ConstraintTrailingEqualTo(this UIView view, NSLayoutXAxisAnchor anchor, nfloat constant = default)
        {
            view.TrailingAnchor.ConstraintEqualTo(anchor, constant).Active = true;
            return view;
        }

        /// <summary>
        /// Constraint bottom anchor to another anchor.
        /// </summary>
        public static UIView ConstraintBottomEqualTo(this UIView view, NSLayoutYAxisAnchor anchor, nfloat constant = default)
        {
            view.BottomAnchor.ConstraintEqualTo(anchor, constant).Active = true;
            return view;
        }

        /// <summary>
        /// Constraint centreX anchor to another anchor.
        /// </summary>
        public static UIView ConstraintCentreXEqualTo(this UIView view, NSLayoutXAxisAnchor anchor, nfloat constant = default)
        {
            view.CenterXAnchor.ConstraintEqualTo(anchor, constant).Active = true;
            return view;
        }

        /// <summary>
        /// Constraint centreY anchor to another anchor.
        /// </summary>
        public static UIView ConstraintCentreYEqualTo(this UIView view, NSLayoutYAxisAnchor anchor, nfloat constant = default)
        {
            view.CenterYAnchor.ConstraintEqualTo(anchor, constant).Active = true;
            return view;
        }

        /// <summary>
        /// Constraint height anchor to a constant.
        /// </summary>
        public static UIView ConstraintWidthEqualTo(this UIView view, nfloat constant)
        {
            if( constant > 0 )
                view.WidthAnchor.ConstraintEqualTo(constant).Active = true;
            return view;
        }

        /// <summary>
        /// Constraint width anchor to a constant.
        /// </summary>
        public static UIView ConstraintHeightEqualTo(this UIView view, nfloat constant)
        {
            if (constant > 0)
                view.HeightAnchor.ConstraintEqualTo(constant).Active = true;
            return view;
        }

        /// <summary>
        /// Fill superview by constraining leading, top, trailing and bottom to superview.
        /// </summary>
        public static UIView AnchorFill(this UIView view, UIEdgeInsets edgeInsets)
        {
            return view.ActivateConstaints()
                .ConstraintLeadingEqualTo(view.Superview.LeadingAnchor, edgeInsets.Left)
                .ConstraintTopEqualTo(view.Superview.TopAnchor, edgeInsets.Top)
                .ConstraintTrailingEqualTo(view.Superview.TrailingAnchor, -edgeInsets.Right)
                .ConstraintBottomEqualTo(view.Superview.BottomAnchor, -edgeInsets.Bottom);
        }

        /// <summary>
        /// Center in superview by constraining centerX and centerY to superview, respectively.
        /// </summary>
        public static UIView AnchorCenter(this UIView view, UIOffset offset = default, CGSize size = default)
        {
            return view.ActivateConstaints()
                .ConstraintCentreXEqualTo(view.Superview.CenterXAnchor, offset.Horizontal)
                .ConstraintCentreYEqualTo(view.Superview.CenterYAnchor, offset.Vertical)
                .ConstraintWidthEqualTo(size.Width)
                .ConstraintHeightEqualTo(size.Height);
        }

        /// <summary>
        /// Get constraints applied to view.
        /// </summary>
        public static AnchoredConstraints CaptureAnchoredConstraints(this UIView view)
        {
            var constraints = new AnchoredConstraints();

            foreach(var constraint in view.Constraints)
            {
                switch(constraint.FirstAttribute)
                {
                    case NSLayoutAttribute.Leading:
                        constraints.Leading = constraint;
                        break;
                    case NSLayoutAttribute.Top:
                        constraints.Top = constraint;
                        break;
                    case NSLayoutAttribute.Trailing:
                        constraints.Trailing = constraint;
                        break;
                    case NSLayoutAttribute.Bottom:
                        constraints.Bottom = constraint;
                        break;
                    case NSLayoutAttribute.CenterX:
                        constraints.CenterX = constraint;
                        break;
                    case NSLayoutAttribute.CenterY:
                        constraints.CenterY = constraint;
                        break;
                    case NSLayoutAttribute.Width:
                        constraints.Width = constraint;
                        break;
                    case NSLayoutAttribute.Height:
                        constraints.Height = constraint;
                        break;
                }
            }

            return constraints;
        }
    }

    public class AnchoredConstraints
    {
        public NSLayoutConstraint Top { get; internal set; }
        public NSLayoutConstraint Leading { get; internal set; }
        public NSLayoutConstraint Bottom { get; internal set; }
        public NSLayoutConstraint Trailing { get; internal set; }
        public NSLayoutConstraint CenterX { get; internal set; }
        public NSLayoutConstraint CenterY { get; internal set; }
        public NSLayoutConstraint Width { get; internal set; }
        public NSLayoutConstraint Height { get; internal set; }

        internal AnchoredConstraints()
        {
        }
    }
}
