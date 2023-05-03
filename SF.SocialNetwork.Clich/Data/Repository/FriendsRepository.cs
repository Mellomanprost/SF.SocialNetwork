using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SF.SocialNetwork.Clich.Models.Users;

namespace SF.SocialNetwork.Clich.Data.Repository
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task AddFriend(User target, User friend)
        {
            var friends = Set.AsEnumerable()
                .FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);

            if (friends == null)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = friend,
                    CurrentFriendId = friend.Id
                };

                await Task.Run(() => Create(item));
            }
        }

        public async Task<List<User>> GetFriendsByUser(User target)
        {
            var friends = Set.Include(x => x.CurrentFriend).AsEnumerable().Where(x => x.UserId == target.Id)
                .Select(x => x.CurrentFriend);

            return await Task.Run(() => friends.ToList());
        }

        public async Task DeleteFriend(User target, User friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);

            if (friends != null)
            {
                await Task.Run(() => Delete(friends));
            }
        }
    }
}
