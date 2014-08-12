using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FamilyTasks.Mobile.Core.Models;
using FamilyTasks.Mobile.Core.ViewModels.Base;

namespace FamilyTasks.Mobile.Core.ViewModels.Projects
{
    public class AddProjectMembersViewModel:LoadingMvxViewModel
    {
        private List<User> _friendsList;

        private MvxCommand _saveMembersCommand;

        public ICommand SaveMembersCommand
        {
            get
            {
                _saveMembersCommand = _saveMembersCommand ?? new MvxCommand(AddMembers);
                return _saveMembersCommand;
            }
        }

        private void AddMembers()
        {
            
        }


        public List<User> FriendsList
        {
            get { return _friendsList; }
            set
            {
                _friendsList = value;
                base.RaisePropertyChanged(()=>FriendsList);
            }
        }
    }
}
