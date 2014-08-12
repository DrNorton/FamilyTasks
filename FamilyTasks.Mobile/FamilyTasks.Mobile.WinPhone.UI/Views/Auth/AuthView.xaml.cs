using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Cirrious.MvvmCross.WindowsPhone.Views;

namespace FamilyTasks.Mobile.WinPhone.UI.Views.Auth
{
    public partial class AuthView : MvxPhonePage
    {
        public AuthView()
        {
            InitializeComponent();
        }
        private void Phone_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (e.Key != Key.Unknown && txt.Text.Length == txt.MaxLength)
                FocusNext();
        }

        private void FocusNext()
        {
            Control focused = FocusManager.GetFocusedElement() as Control;
            int focusedIndex = focused != null ? focused.TabIndex : -1;
            var controls = Extensions.GetVisualDescendents<Control>(this);
            var next = (from c in controls where c.TabIndex > focusedIndex orderby c.TabIndex select c).FirstOrDefault();
            if (next != null)
                next.Focus();
        }
    }
}