Xam.iOS.UIHelpers
=============================================================
![static_nuget_badge](https://img.shields.io/static/v1?label=NuGet&message=v1.0.0&color=brightgreen)
![license](https://img.shields.io/static/v1?label=License&message=MIT&color=blue)
![license](https://img.shields.io/static/v1?label=Platform&message=Xamarin.iOS&color=orange)

Build your `Xamarin.iOS` UI the easy and clean way in **C#**. Inspired by **LBTA Tools** by [*Brian Voong*](https://github.com/bhlvoong/LBTATools).

Install
=============================================================
Find `Xamarin.iOS.UIHelpers` on **NuGet** Package Manager.

Usage
=============================================================
### 1. Stacking with UIStackView

***Basic Example***

```c#
// Typical way...

var stackView = new UIStackView(new[] {ImageView, Label}) 
{
    Axis = UILayoutConstraintAxis.Vertical
};
```

```c#
// Xamarin.iOS.UIHelpers way...

var stackView = UI.VStack(ImageView, Label);
```

***Advanced Example***

```c#
var stackView = UI.HStack()
```

License
=======
Xam.iOS.UIHelpers is available under the MIT license.
