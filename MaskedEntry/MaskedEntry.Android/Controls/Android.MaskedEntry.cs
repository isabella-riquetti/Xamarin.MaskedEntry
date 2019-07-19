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
            if (source.Text.Length == source.Mask.Length)
                e.Handled = false;
        }

        void Native_AfterTextChanged(object sender, global::Android.Text.AfterTextChangedEventArgs e)
        {
            var startCursorPosition = source.CursorPosition;
            var startText = source.Text;
            var startTextLengthDifference = TextLengthDifference;

            var maskedText = source.ApplyMask(source.Text, source.Mask);
            if (maskedText != source.Text)
            {
                native.Text = maskedText;
                if (startText.Length <= source.Mask.Length)
                {
                    var newCursorPosition = DefineNextCursorPosition(startCursorPosition, startTextLengthDifference, maskedText);
                    native.SetSelection(newCursorPosition, newCursorPosition);
                }
                else
                {
                    native.SetSelection(startCursorPosition, startCursorPosition);
                }
            }
        }

        int DefineNextCursorPosition(int startCursorPosition, int startTextLengthDifference, string maskedText)
        {
            var actionPositionChange = (startTextLengthDifference > 0 ? 1 : -1);
            var newCursorPosition = startCursorPosition + actionPositionChange;

            if(newCursorPosition - 1 == maskedText.Length)
                return newCursorPosition + actionPositionChange;

            var nextCharIfSameAction = maskedText[newCursorPosition - 1];
            if(!char.IsNumber(nextCharIfSameAction) && !char.IsLetter(nextCharIfSameAction))
                newCursorPosition += actionPositionChange;

            return newCursorPosition;
        }
    }
}