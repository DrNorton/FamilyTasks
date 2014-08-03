using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTasks.Dto.Friends
{
    public class FriendListItemDto
    {
        public long UserId { get; set; }
        public string Telephone { get; set; }
        public string AvatarUrl { get; set; }
        public string DisplayName { get; set; }
    }
}

