using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace GalleryConverter.iOS
{
    public class CheckboxRenderer
    {
        //private GCCheckBox.Checkbox nativeCheckbox;

        //protected override void OnElementChanged(ElementChangedEventArgs<Checkbox> e)
        //{
        //    base.OnElementChanged(e);
        //    var model = e.NewElement;
        //    if (model == null)
        //    {
        //        return;
        //    }

        //    nativeCheckbox = new GCCheckbox.Checkbox();
        //    CheckboxPropertyChanged(model, null);
        //    model.PropertyChanged += OnElementPropertyChanged;

        //    nativeCheckbox.ValueChanged += (object sender, EventArgs eargs) => {
        //        model.IsChecked = nativeCheckbox.IsChecked;
        //    };
        //    SetNativeControl(nativeCheckbox);
        //}
        //private void CheckboxPropertyChanged(Checkbox model, String propertyName)
        //{
        //    if (propertyName == null || propertyName == Checkbox.IsCheckedProperty.PropertyName)
        //    {
        //        nativeCheckbox.IsChecked = model.IsChecked;
        //    }
        //    if (propertyName == null || propertyName == Checkbox.ColorProperty.PropertyName)
        //    {
        //        nativeCheckbox.BoxFillColor = model.Color.ToUIColor();
        //        nativeCheckbox.BoxBorderColor = model.Color.ToUIColor();
        //    }
        //}
        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (nativeCheckbox != null)
        //    {
        //        base.OnElementPropertyChanged(sender, e);

        //        CheckboxPropertyChanged((Checkbox)sender, e.PropertyName);
        //    }
        //}


    }
}