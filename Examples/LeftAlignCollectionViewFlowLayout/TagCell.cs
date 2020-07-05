using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TagsExampleApplication
{
    public class TagCell: UICollectionViewCell
    {
        public UILabel TextLabel { get; }

        protected internal TagCell(IntPtr handle): base(handle)
        {
            TextLabel = new UILabel();
            TextLabel.TextColor = UIColor.White;
            TextLabel.Font = UIFont.BoldSystemFontOfSize(14);
            SetupContentView();
            SetupContent();
        }

        private void SetupContentView()
        {
            ContentView.BackgroundColor = UIColor.FromWhiteAlpha(0.7f, 1);
            ContentView.Layer.CornerRadius = ( float )TagHeight / 2;

            // Explicitly constraint ContentView to Cell using Auto Layout.
            // This enables self-sizing the width due to height constraint.
            ContentView.TranslatesAutoresizingMaskIntoConstraints = false;
            ContentView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            ContentView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            ContentView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            ContentView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;
            ContentView.HeightAnchor.ConstraintEqualTo(TagHeight).Active = true;
        }

        private void SetupContent()
        {
            var stackView = new UIStackView(new[] { TextLabel });
            stackView.LayoutMarginsRelativeArrangement = true;
            stackView.LayoutMargins = new UIEdgeInsets(0, 14, 0, 14);

            ContentView.AddSubview(stackView);
            stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            stackView.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor).Active = true;
            stackView.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor).Active = true;
            stackView.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).Active = true;
            stackView.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor).Active = true;
        }

        public override bool Selected
        {
            get => base.Selected;
            set
            {
                base.Selected = value;
                ContentView.BackgroundColor = value ? UIColor.FromRGB(104, 45, 218) : UIColor.FromWhiteAlpha(0.7f, 1);
            }
            
        }

        public const int TagHeight = 28;
    }
}