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
            }
        }

        public string ApplyMask(string text)
        {
            RemoveOverflow(ref text);

            string formatedText;

            formatedText = Regex.Replace(text, @"\W", "");
            if ( _maskPositions == null || string.IsNullOrEmpty(formatedText))
                return formatedText;

            foreach (var position in _maskPositions)
                if (formatedText.Length >= position.Key)           
                    formatedText = formatedText.Insert(position.Key, position.Value.ToString());

            return formatedText;
        }

        public bool CheckForUnknown(string text)
        {
            var acceptedSpecialChars = _maskPositions.GroupBy(p => p.Value).Select(p => p.Key);
            if (text.Any(c => acceptedSpecialChars.All(a => a != c) && !IsComomCharacter(c)))
                return true;
            else
                return false;
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

        public bool IsComomCharacter(char character)
        {
            return char.IsNumber(character) || char.IsLetter(character);
        }

        public int GetNewCursorPosition(string startText, string maskedText, int startCursorPosition, int startTextLengthDifference)
        {
            if (startText.Length <= Mask.Length && !CheckForUnknown(startText))
            {
                if (startTextLengthDifference > 0)
                {
                    var charDifference = Math.Abs(startText.Length - maskedText.Length);
                    var newCursorPosition = startCursorPosition + ((charDifference > 0 ? charDifference : 1) * startTextLengthDifference);

                    if ((startText.Length == 1 && !IsComomCharacter(maskedText.First())) || !IsComomCharacter(maskedText[newCursorPosition])
                        || newCursorPosition == maskedText.Length || (!IsComomCharacter(maskedText.Last()) && newCursorPosition == maskedText.Length - 1))
                        return newCursorPosition + startTextLengthDifference;
                }

                return startCursorPosition + startTextLengthDifference;
            }
            else
            {
                return startCursorPosition;
            }
        }
    }
}
