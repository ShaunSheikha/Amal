using Aman.Droid;
using Aman.ViewModels;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace Aman.Droid
{
    class CustomDatePickerRenderer: DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetHintTextColor(global::Android.Graphics.Color.LightGray);
                Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Black);
                Control.SetTextColor(global::Android.Graphics.Color.Black);

            }
        }
    }
}