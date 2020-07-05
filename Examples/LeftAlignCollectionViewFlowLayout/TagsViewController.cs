using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TagsExampleApplication
{
    // A common use of left justified cells in a UICollectionView are tags
    // This example uses self-sizing cells where the height is has a fixed and the width is self-sized.
    public class TagsViewController : UICollectionViewController, IUICollectionViewDelegateFlowLayout
    {
        // Array representing each tag
        protected string[] Tags = { "Mario", "Luigi", "Bowser", "Princess Peach", "Goomba", "Toad", 
          "Cappy", "Pirahanna", "Broodals", "Toadette", "Rabbit", "Koopa", "Glydon", "Sphynx", "Jaxi", 
          "Lakitu" };

        // Pass a new instance of LeftAlignCollectionViewFlowLayout in the base constructor
        public TagsViewController(): base(new LeftAlignCollectionViewFlowLayout())
        {
            SetupFlowLayout();
            SetupCollectionView();
        }

        // Set properties for UICollectionViewFlowLayout
        private void SetupFlowLayout()
        {
            var flowLayout = (LeftAlignCollectionViewFlowLayout)Layout;
            flowLayout.EstimatedItemSize = UICollectionViewFlowLayout.AutomaticSize;
            flowLayout.SectionInsetReference = UICollectionViewFlowLayoutSectionInsetReference.SafeArea;
            flowLayout.SectionInset = new UIEdgeInsets(0, 12, 0, 12);
            flowLayout.MinimumInteritemSpacing = 8;
            flowLayout.MinimumLineSpacing = 8;
        }

        // Set properties for UICollectionView
        private void SetupCollectionView()
        {
            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Always;
            CollectionView.RegisterClassForSupplementaryView(typeof(TagsHeader), UICollectionElementKindSection.Header, tagsHeaderReuseId);
            CollectionView.RegisterClassForCell(typeof(TagCell), tagCellReuseId);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            // Select the first cell in UICollectionView when view appears
            var firstIndexPath = NSIndexPath.FromItemSection(0, 0);
            CollectionView.SelectItem(firstIndexPath, false, UICollectionViewScrollPosition.None);
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Tags.Length;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (TagCell)collectionView.DequeueReusableCell(tagCellReuseId, indexPath);
            cell.TextLabel.Text = Tags[indexPath.Item];
            return cell;
        }

        public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
        {
            var header = (TagsHeader)collectionView.DequeueReusableSupplementaryView(UICollectionElementKindSection.Header, tagsHeaderReuseId, indexPath);
            header.TitleLabel.Text = "Character Tags";
            return header;
        }

        // Fixed UICollectionView header size
        [Export("collectionView:layout:referenceSizeForHeaderInSection:")]
        public CGSize GetReferenceSizeForHeader(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return new CGSize(collectionView.Frame.Width, 50);
        }

        private const string tagsHeaderReuseId = "tagsHeaderReuseId";
        private const string tagCellReuseId = "tagCellReuseId";
    }

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
