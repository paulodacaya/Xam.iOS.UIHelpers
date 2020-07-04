using System;
using CoreGraphics;
using UIKit;

namespace Xam.iOS.UIHelpers
{
    /// <summary>
    /// A UICollectionViewFlowLayout that left justifies only the cells
    /// </summary>
    public class LeftAlignCollectionViewFlowLayout: UICollectionViewFlowLayout
    {
        public LeftAlignCollectionViewFlowLayout()
        {
        }

        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
        {
            UICollectionViewLayoutAttributes[] layoutAttributes = base.LayoutAttributesForElementsInRect(rect);

            nfloat leftMargin = SectionInset.Left;
            double maxY = -1.0;

            foreach (UICollectionViewLayoutAttributes layoutAttribute in layoutAttributes)
            {
                // We only care about cells and not headers, footers, etc.
                if (layoutAttribute.RepresentedElementCategory == UICollectionElementCategory.Cell)
                {
                    if (layoutAttribute.Frame.Location.Y >= maxY ||
                        layoutAttribute.Frame.Location.X == SectionInset.Left)
                    {
                        leftMargin = SectionInset.Left;
                    }

                    if (layoutAttribute.Frame.Location.X == SectionInset.Left)
                    {
                        leftMargin = SectionInset.Left;
                    }
                    else
                    {
                        var frame = new CGRect(
                                leftMargin,
                                layoutAttribute.Frame.Location.Y,
                                layoutAttribute.Frame.Size.Width,
                                layoutAttribute.Frame.Size.Height);
                        layoutAttribute.Frame = frame;
                    }

                    leftMargin += layoutAttribute.Frame.Width + MinimumInteritemSpacing;
                    maxY = Math.Max(layoutAttribute.Frame.GetMaxY(), maxY);
                }
            }

            return layoutAttributes;
        }
    }
}
