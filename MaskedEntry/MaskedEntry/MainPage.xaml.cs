using Masked.Controls;
using Masked.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaskedEntry
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            var editTextUsuario = new MyEntry();
            editTextUsuario.Text = "";
            editTextUsuario.Mask = "XXX.XXX.XXX-XX";

            var editTextUsuario2 = new MyEntry();
            editTextUsuario2.Text = "";
            editTextUsuario2.Mask = "(XX) X XXXX-XXXX";

            this.Content = new StackLayout
            {
                Children = {

                    new Label  { Text = "editTextUsuario" },
                    editTextUsuario,
                    new Label  { Text = "editTextUsuario2" },
                    editTextUsuario2,
                }
            };
        }
    }
}
