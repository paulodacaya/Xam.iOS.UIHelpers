Xam.iOS.UIHelpers
=============================================================
![static_nuget_badge](https://img.shields.io/static/v1?label=NuGet&message=v0.1.0-alpha&color=brightgreen)
![license](https://img.shields.io/static/v1?label=License&message=MIT&color=blue)
![license](https://img.shields.io/static/v1?label=Platform&message=Xamarin.iOS&color=orange)

Build your `Xamarin.iOS` UI the easy and clean way in **C#**.

Inspired by **LBTA Tools** by [*Brian Voong*](https://github.com/bhlvoong/LBTATools).

## Install

Find `PDCo.Xamarin.iOS.UIHelpers` on **NuGet** package manager.

## Usage

### 1. Stacking with UIStackView

***Basic Example***

```c#
// Traditional way...

var stackView = new UIStackView(new[] {ImageView, Label}) 
{
    Axis = UILayoutConstraintAxis.Vertical
};
```

```c#
// UIHelpers way...

var stackView = UI.VStack(ImageView, Label);
```

***Advanced Example***

```c#
// Traditional way...

var innerStackView = new UIStackView(new[] {TitleLabel, SubTitleLabel})
{
   Axis = UILayoutConstraintAxis.Vertical,
   Spacing = 3
};

var outerStackView = new UIStackView(new[] {ImageView, innerStackView})
{
   Axis = UILayoutConstraintAxis.Horizontal,
   Alignment = UIStackViewAlignment.Center,
   Spacing = 6
}
```

```c#
// UIHelpers way...

var stackView = UI.HStack(
   ImageView,
   UI.VStack(
       TitleLabel,
       SubTitleLabel
   ).Spacing(3)
).Alignment(UIStackViewAlignment.Center)
 .Spacing(6)
```

### 2. Auto Layout

***Basic Example***

```c#
// Traditional way...

// Anchor subview's leading, top, trailing and bottom constraints to superviews, respectively.

view.AddSubView(someView)

someView.TranslatesAutoresizingMaskIntoConstraints = false;
someView.LeadingAnchor.ConstraintEqualTo(view.LeadingAnchor).Active = true;
someView.TopAnchor.ConstraintEqualTo(view.TopAnchor).Active = true;
someView.TrailingAnchor.ConstraintEqualTo(view.TrailingAnchor).Active = true;
someView.BottomAnchor.ConstraintEqualTo(view.BottomAnchor)./Active = true;
```

```c#
// UIHelpers way...

view.AddSubview(someView)

someView.AnchorFill();
```

## License

Xam.iOS.UIHelpers is available under the MIT license.
