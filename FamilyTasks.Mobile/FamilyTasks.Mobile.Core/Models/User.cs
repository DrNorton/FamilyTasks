using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace FamilyTasks.Mobile.Core.Models
{
    public class User : MvxNotifyPropertyChanged
    {
        private string _phone;
        private string _email;
        private string _avatarUrl;
        private string _displayName;

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                base.RaisePropertyChanged(()=>Phone);
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                base.RaisePropertyChanged(() => Email);
            }
        }

        public string AvatarUrl
        {
            get { return _avatarUrl; }
            set
            {
                _avatarUrl = value;
                base.RaisePropertyChanged(() => AvatarUrl);
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                base.RaisePropertyChanged(() => DisplayName);
            }
        }
    }
}
