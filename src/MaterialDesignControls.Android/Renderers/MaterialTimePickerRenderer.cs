﻿using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Android.Utils;
using Android.Views;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(Plugin.MaterialDesignControls.Android.MaterialTimePickerRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialTimePickerRenderer : TimePickerRenderer
    {
        public static void Init() { }

        public MaterialTimePickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                this.Control.SetPadding(4, 0, 0, 0);

                if (this.Element is CustomTimePicker customTimePicker)
                {
                    this.Control.TextAlignment = TextAlignmentHelper.ConvertToAndroid(customTimePicker.HorizontalTextAlignment);

                    if (!customTimePicker.Time.HasValue && !string.IsNullOrEmpty(customTimePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.Hint = customTimePicker.Placeholder;
                        this.Control.SetHintTextColor(customTimePicker.PlaceholderColor.ToAndroid());
                    }
                }
            }
        }
    }
}
