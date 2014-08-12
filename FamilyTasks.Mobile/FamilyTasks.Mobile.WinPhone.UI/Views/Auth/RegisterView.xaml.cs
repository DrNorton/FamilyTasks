using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FamilyTasks.Mobile.WinPhone.UI.Views.Auth
{
    public partial class RegisterView : MvxPhonePage
    {
        public RegisterView()
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