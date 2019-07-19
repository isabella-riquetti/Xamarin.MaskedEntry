using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Graphics;
using System.Linq;
using System.Collections.Generic;
using Masked.Controls;
using Masked.Library;
using Android.Content;
using Android.Views;
using Android.Text;

[assembly: ExportRenderer(typeof(Masked.Controls.MyEntry), typeof(Masked.Android.Controls.MyEntryRenderer))]
namespace Masked.Android.Controls
{
	public class MyEntryRenderer : EntryRenderer
	{
		private MyEntry source;
		private FormsEditText native;

        private int TextLengthDifference = 0;

        public MyEntryRenderer(Context context) : base(context)
        {
        }

        protected override void Dispose (bool disposing)
		{
			if (native != null) {
				native.AfterTextChanged -= Native_AfterTextChanged;
			}
			base.Dispose (disposing);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (native == null) {
				source = e.NewElement as MyEntry;
				native = this.Control as FormsEditText;

				native.AfterTextChanged += Native_AfterTextChanged;
                native.KeyPress += Native_KeyPress;
                native.BeforeTextChanged += Native_BeforeTextChanged;

                SetNativeControl(native);
			}
		}

        private void Native_BeforeTextChanged(object sender, global::Android.Text.TextChangedEventArgs e)
        {
            TextLengthDifference = e.AfterCount - e.BeforeCount;
        }

        private void Native_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Event.Action == global::Android.Views.KeyEventActions.Up)
            {
                var textLength = native.Text.Length;
                if (e.KeyCode == Keycode.Back || e.KeyCode == Keycode.DpadLeft)
                {
                    if (textLength > 0 && source.CursorPosition > 0)
                        native.SetSelection(source.CursorPosition - 1, source.CursorPosition - 1);
                }
                else if (e.KeyCode == Keycode.Forward || e.KeyCode == Keycode.DpadRight)
                {
                    if (textLength > 0 && source.CursorPosition < textLength)
                        native.SetSelection(source.CursorPosition + 1, source.CursorPosition + 1);
                }

            }
        }

        void Native_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
        {
            var startCursorPosition = source.CursorPosition;
            var startText = source.Text;
            var startTextLengthDifference = TextLengthDifference;

            var maskedText = source.ApplyMask(source.Text);
            if (maskedText != source.Text)
            {
                native.Text = maskedText;

                int newCursorPosition = source.GetNewCursorPosition(startText, maskedText, startCursorPosition, startTextLengthDifference);
                native.SetSelection(newCursorPosition, newCursorPosition);
            }
        }
    }
}