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
        public static UIView ConstraintLeadingEqualTo(this UIView view, NSLayoutXAxisAnchor anchor, nfloat constant = default, AnchoredConstraints constraints = default)
        {
            var leadingConstraint = view.LeadingAnchor.ConstraintEqualTo(anchor, constant);
            if (constraints != null)
                constraints.Leading = leadingConstraint;
            leadingConstraint.Active = true;
            return view;
        }

        /// <summary>
        /// Constraint top anchor to another anchor.
        /// </summary>
        public static UIView ConstraintTopEqualTo(this UIView view, NSLayoutYAxisAnchor anchor, nfloat constant = default, AnchoredConstraints constraints = default)
        {
            var topConstraint = view.TopAnchor.ConstraintEqualTo(anchor, constant);
            if (constraints != null)
                constraints.Top = topConstraint;
            topConstraint.Active = true;
            return view;
        }

        /// <summary>
        /// Constraint trailing anchor to another anchor.
        /// </summary>
        public static UIView ConstraintTrailingEqualTo(this UIView view, NSLayoutXAxisAnchor anchor, nfloat constant = default, AnchoredConstraints constraints = default)
        {
            var trailingConstraint = view.TrailingAnchor.ConstraintEqualTo(anchor, -constant);
            if (constraints != null)
                constraints.Trailing = trailingConstraint;
            trailingConstraint.Active = true;
            return view;
        }

        /// <summary>
        /// Constraint bottom anchor to another anchor.
        /// </summary>
        public static UIView ConstraintBottomEqualTo(this UIView view, NSLayoutYAxisAnchor anchor, nfloat constant = default, AnchoredConstraints constraints = default)
        {
            var bottomConstraint = view.BottomAnchor.ConstraintEqualTo(anchor, -constant);
            if (constraints != null)
                constraints.Bottom = bottomConstraint;
            bottomConstraint.Active = true;
            return view;
        }

        /// <summary>
        /// Constraint centreX anchor to another anchor.
        /// </summary>
        public static UIView ConstraintCentreXEqualTo(this UIView view, NSLayoutXAxisAnchor anchor, nfloat constant = default, AnchoredConstraints constraints = default)
        {
            var centerXConstraint = view.CenterXAnchor.ConstraintEqualTo(anchor, constant);
            if (constraints != null)
                constraints.CenterX = centerXConstraint;
            centerXConstraint.Active = true;
            return view;
        }

        /// <summary>
        /// Constraint centreY anchor to another anchor.
        /// </summary>
        public static UIView ConstraintCentreYEqualTo(this UIView view, NSLayoutYAxisAnchor anchor, nfloat constant = default, AnchoredConstraints constraints = default)
        {
            var centerYConstraint = view.CenterYAnchor.ConstraintEqualTo(anchor, constant);
            if (constraints != null)
                constraints.CenterY = centerYConstraint;
            centerYConstraint.Active = true;
            return view;
        }

        /// <summary>
        /// Constraint height anchor to a constant.
        /// </summary>
        public static UIView ConstraintWidthEqualTo(this UIView view, nfloat constant, AnchoredConstraints constraints = default)
        {
            if ( constant > 0 )
            {
                var widthConstraint = view.WidthAnchor.ConstraintEqualTo(constant);
                if (constraints != null)
                    constraints.Width = widthConstraint;
                widthConstraint.Active = true;
            }
            return view;
        }

        /// <summary>
        /// Constraint width anchor to a constant.
        /// </summary>
        public static UIView ConstraintHeightEqualTo(this UIView view, nfloat constant, AnchoredConstraints constraints = default)
        {
            if (constant > 0)
            {
                var heightConstraint = view.HeightAnchor.ConstraintEqualTo(constant);
                if (constraints != null)
                    constraints.Height = heightConstraint;
                heightConstraint.Active = true;
            }
            return view;
        }

        /// <summary>
        /// Fill superview by constraining leading, top, trailing and bottom to superview.
        /// </summary>
        public static UIView AnchorFill(this UIView view, UIEdgeInsets edgeInsets = default, AnchoredConstraints constraints = default)
        {
            return view.ActivateConstaints()
                .ConstraintLeadingEqualTo(view.Superview.LeadingAnchor, edgeInsets.Left, constraints)
                .ConstraintTopEqualTo(view.Superview.TopAnchor, edgeInsets.Top, constraints)
                .ConstraintTrailingEqualTo(view.Superview.TrailingAnchor, edgeInsets.Right, constraints)
                .ConstraintBottomEqualTo(view.Superview.BottomAnchor, edgeInsets.Bottom, constraints);
        }

        /// <summary>
        /// Center in superview by constraining centerX and centerY to superview, respectively.
        /// </summary>
        public static UIView AnchorCenter(this UIView view, UIOffset offset = default, CGSize size = default, AnchoredConstraints constraints = default)
        {
            return view.ActivateConstaints()
                .ConstraintCentreXEqualTo(view.Superview.CenterXAnchor, offset.Horizontal, constraints)
                .ConstraintCentreYEqualTo(view.Superview.CenterYAnchor, offset.Vertical, constraints)
                .ConstraintWidthEqualTo(size.Width, constraints)
                .ConstraintHeightEqualTo(size.Height, constraints);
        }
    }

    /// <summary>
    /// An object that captures applied anchored constraints.
    /// </summary>
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

        public AnchoredConstraints()
        {
        }
    }
}
