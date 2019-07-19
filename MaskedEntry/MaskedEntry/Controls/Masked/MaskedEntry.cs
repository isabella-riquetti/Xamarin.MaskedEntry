using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using Masked.Library;
using System.Text.RegularExpressions;

namespace Masked.Controls
{
    public class MyEntry : Entry
    {
        public static readonly BindableProperty MaskProperty =
            BindableProperty.Create("Mask", typeof(string), typeof(MyEntry), null);

        public string Mask
        {
            get { return (string)GetValue(MaskProperty); }
            set
            {
                SetValue(MaskProperty, value);
                SetMaskPositions();
                PureMask = Regex.Replace(Mask, @"\W", string.Empty);
            }
        }

        public string PureText { get; set; }
        public string PureMask { get; set; }

        public string ApplyMask(string text, string mask)
        {
            RemoveOverflow(ref text);
            PureText = Regex.Replace(text, @"\W", "");
            string formatedText;

            formatedText = PureText;
            if (string.IsNullOrWhiteSpace(formatedText) || _maskPositions == null)
                return formatedText;

            foreach (var position in _maskPositions)
                if (formatedText.Length >= position.Key + 1)           
                    formatedText = formatedText.Insert(position.Key, position.Value.ToString());

            return formatedText;
        }

        public void RemoveOverflow(ref string text)
        {
            if(text.Length > Mask.Length)
            {
                text = text.Remove(this.CursorPosition, 1);
            }
        }

        private IDictionary<int, char> _maskPositions { get; set; }
        void SetMaskPositions()
        {
            if (string.IsNullOrEmpty(Mask))
            {
                return;
            }

            var positions = new Dictionary<int, char>();
            for (var i = 0; i < Mask.Length; i++)
                if (Mask[i] != 'X')
                    positions.Add(i, Mask[i]);

            _maskPositions = positions;
        }
    }
}
