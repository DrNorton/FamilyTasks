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
    public class ProjectMembersViewModel:LoadingMvxViewModel
    {
        private List<User> _members;
        private MvxCommand _deleteMemberCommand;
        private MvxCommand _addMemberCommand;

        public ICommand AddMemberCommand
        {
            get
            {
                _addMemberCommand = _addMemberCommand ?? new MvxCommand(AddMember);
                return _addMemberCommand;
            }
        }

        public ICommand DeleteMemberCommand
        {
            get
            {
                _deleteMemberCommand = _deleteMemberCommand ?? new MvxCommand(DoDeleteMember);
                return _deleteMemberCommand;
            }
        }

        private void AddMember()
        {
            
        }

        private void DoDeleteMember()
        {
            
        }


        public List<User> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                base.RaisePropertyChanged(()=>Members);
            }
        }


    }
}
