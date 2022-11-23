using Haru.Models.EFT.Friend;

namespace Haru.Services
{
    public static class FriendService
    {
        public static FriendListModel GetFriends()
        {
            return new FriendListModel();
        }
    }
}