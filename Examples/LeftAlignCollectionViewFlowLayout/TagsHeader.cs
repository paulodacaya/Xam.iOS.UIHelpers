using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TagsExampleApplication
{
    public class TagsHeader: UICollectionReusableView
    {
        public UILabel TitleLabel { get; }

        protected internal TagsHeader(IntPtr handle): base(handle)
        {
            TitleLabel = new UILabel();
            TitleLabel.TextColor = UIColor.FromRGB(104, 45, 218);
            TitleLabel.Font = UIFont.BoldSystemFontOfSize(18);
            SetupContent();
        }

        private void SetupContent()
        {
            var stackView = new UIStackView(new[] { TitleLabel });
            stackView.Alignment = UIStackViewAlignment.Center;
            stackView.LayoutMarginsRelativeArrangement = true;
            stackView.LayoutMargins = new UIEdgeInsets(0, 14, 0, 14);

            AddSubview(stackView);
            stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            stackView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            stackView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            stackView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            stackView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;
        }
    }
}