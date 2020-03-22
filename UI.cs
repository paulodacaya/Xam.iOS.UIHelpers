using System;
using UIKit;
using Foundation;

namespace Xam.iOS.UIHelpers
{
    public static class UI
    {
        #region UI Components

        /// <summary>
        /// Create a UILabel.
        /// </summary>
        public static UILabel CreateLabel(string text, UIColor textColor, UIFont font, int lines = 0,
            UITextAlignment textAlignment = UITextAlignment.Left )
        {
            return new UILabel {
                Text = text,
                TextColor = textColor,
                TextAlignment = textAlignment,
                Font = font,
                Lines = lines
            };
        }

        /// <summary>
        /// Create an attributed UILabel.
        /// </summary>
        public static UILabel CreateAttrLabel(string text, UIColor textColor, UIFont font, int lines = 0,
            UITextAlignment textAlignment = UITextAlignment.Left, UIColor backgroundColor = null, UIColor strokeColor = null,
            float lineSpacing = 0, float kerning = 0, NSUnderlineStyle underlineStyle = NSUnderlineStyle.None,
            NSShadow shadow = null, float strokeWidth = 0, NSUnderlineStyle strikeThroughStyle = NSUnderlineStyle.None)
        {
            return new UILabel {
                Lines = lines,
                TextAlignment = textAlignment,
                AttributedText = new NSAttributedString(
                    text,
                    font,
                    textColor,
                    backgroundColor,
                    strokeColor,
                    paragraphStyle: new NSParagraphStyle {
                        LineHeightMultiple = 0,
                        LineSpacing = lineSpacing
                    },
                    NSLigatureType.None,
                    kerning,
                    underlineStyle,
                    shadow,
                    strokeWidth,
                    strikeThroughStyle )
            };
        }

        /// <summary>
        /// Create a UIImageView.
        /// </summary>
        public static UIImageView CreateImageView(UIImage image, UIColor tintColor,
            UIViewContentMode contentMode = UIViewContentMode.ScaleAspectFit)
        {
            return new UIImageView {
                Image = image,
                TintColor = tintColor,
                ContentMode = contentMode
            };
        }

        /// <summary>
        /// Create a UIButton with text.
        /// </summary>
        public static UIButton CreateButton(string title, UIColor titleColor, UIFont font,
            UIEdgeInsets padding = default, EventHandler touchUpInside = null)
        {
            var button = new UIButton(UIButtonType.System);
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(titleColor, UIControlState.Normal);
            button.TitleLabel.Font = font;
            button.ContentEdgeInsets = padding;

            if (touchUpInside != null)
                button.TouchUpInside += touchUpInside;

            return button;
        }

        /// <summary>
        /// Create a UIButton with an image.
        /// </summary>
        public static UIButton CreateButton(UIImage image, UIColor tintColor,
            UIEdgeInsets contentPadding = default, EventHandler touchUpInside = null)
        {
            var button = new UIButton(UIButtonType.System);
            button.SetImage(image, UIControlState.Normal);
            button.TintColor = tintColor;
            button.ClipsToBounds = true;
            button.ContentMode = UIViewContentMode.ScaleAspectFit;
            button.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            button.ContentEdgeInsets = contentPadding;

            if (touchUpInside != null)
                button.TouchUpInside += touchUpInside;

            return button;
        }

        /// <summary>
        /// Create a UIButton with an image and text.
        /// </summary>
        public static UIButton CreateButton(UIImage image, string title, UIColor tintColor, UIColor titleColor,
            UIFont font, UIEdgeInsets contentPadding = default, float imageTitleSpacing = 2, EventHandler touchUpInside = null)
        {
            var button = new UIButton(UIButtonType.System);
            button.SetImage(image, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(titleColor, UIControlState.Normal);
            button.TintColor = tintColor;
            button.TitleLabel.Font = font;
            button.ContentMode = UIViewContentMode.ScaleAspectFit;
            button.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

            button.ContentEdgeInsets = new UIEdgeInsets(
                top: contentPadding.Top,
                left: contentPadding.Left,
                bottom: contentPadding.Bottom,
                right: contentPadding.Right + imageTitleSpacing
            );

            button.TitleEdgeInsets = new UIEdgeInsets(
                top: 0,
                left: imageTitleSpacing,
                bottom: 0,
                right: -imageTitleSpacing
            );

            if (touchUpInside != null)
                button.TouchUpInside += touchUpInside;

            return button;
        }

        #endregion

        #region UI StackView Builder

        /// <summary>
        /// Create a <b>horizontal</b> UIStackView.
        /// </summary>
        public static UIStackView HStack(params UIView[] views)
        {
            return Stack(UILayoutConstraintAxis.Horizontal, views);
        }

        /// <summary>
        /// Create a <b>vertical</b> UIStackView.
        /// </summary>
        public static UIStackView VStack(params UIView[] views)
        {
            return Stack(UILayoutConstraintAxis.Vertical, views);
        }

        /// <summary>
        /// Set spacing between elements UIStackView.
        /// </summary>
        public static UIStackView WithSpacing(this UIStackView stackView, nfloat spacing)
        {
            stackView.Spacing = spacing;
            return stackView;
        }

        /// <summary>
        /// Set alignment of UIStackView.
        /// </summary>
        public static UIStackView WithAlignment(this UIStackView stackView, UIStackViewAlignment alignment)
        {
            stackView.Alignment = alignment;
            return stackView;
        }

        /// <summary>
        /// Set distribution of UIStackView.
        /// </summary>
        public static UIStackView WithDistribution(this UIStackView stackView, UIStackViewDistribution distribution)
        {
            stackView.Distribution = distribution;
            return stackView;
        }

        /// <summary>
        /// Set padding of UIStackView.
        /// </summary>
        public static UIStackView WithPadding(this UIStackView stackView, UIEdgeInsets edgeInsets)
        {
            stackView.LayoutMarginsRelativeArrangement = true;
            stackView.LayoutMargins = edgeInsets;
            return stackView;
        }

        /// <summary>
        /// Set left padding of UIStackView.
        /// </summary>
        public static UIStackView WithPaddingLeft(this UIStackView stackView, nfloat padding)
        {
            stackView.LayoutMarginsRelativeArrangement = true;
            var layoutMargins = stackView.LayoutMargins;
            layoutMargins.Left = padding;
            stackView.LayoutMargins = layoutMargins;
            return stackView;
        }

        /// <summary>
        /// Set top padding of UIStackView.
        /// </summary>
        public static UIStackView WithPaddingTop(this UIStackView stackView, nfloat padding)
        {
            stackView.LayoutMarginsRelativeArrangement = true;
            var layoutMargins = stackView.LayoutMargins;
            layoutMargins.Top = padding;
            stackView.LayoutMargins = layoutMargins;
            return stackView;
        }

        /// <summary>
        /// Set right padding of UIStackView.
        /// </summary>
        public static UIStackView WithPaddingRight(this UIStackView stackView, nfloat padding)
        {
            stackView.LayoutMarginsRelativeArrangement = true;
            var layoutMargins = stackView.LayoutMargins;
            layoutMargins.Right = padding;
            stackView.LayoutMargins = layoutMargins;
            return stackView;
        }

        /// <summary>
        /// Set bottom padding of UIStackView.
        /// </summary>
        public static UIStackView WithPaddingBottom(this UIStackView stackView, nfloat padding)
        {
            stackView.LayoutMarginsRelativeArrangement = true;
            var layoutMargins = stackView.LayoutMargins;
            layoutMargins.Right = padding;
            stackView.LayoutMargins = layoutMargins;
            return stackView;
        }

        /// <summary>
        /// Set custom spacing after an arranged subview of UIStackView.
        /// </summary>
        public static UIStackView WithCustomSpacing(this UIStackView stackView, nfloat spacing, UIView afterView)
        {
            stackView.SetCustomSpacing(spacing, afterView);
            return stackView;
        }

        /// <summary>
        /// Set custom spacing after an arranged subview of UIStackView.
        /// </summary>
        public static UIStackView WithCustomSpacing(this UIStackView stackView, nfloat spacing, int afterIndex)
        {
            return stackView.WithCustomSpacing(spacing, stackView.ArrangedSubviews[afterIndex]);
        }

        private static UIStackView Stack(UILayoutConstraintAxis axis, UIView[] views)
        {
            return new UIStackView(views) {
                Axis = axis
            };
        }

        #endregion

    }
}
