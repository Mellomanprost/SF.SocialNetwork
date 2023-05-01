using SF.SocialNetwork.Clich.Models.Users;

namespace SF.SocialNetwork.Clich.Data.Repository
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(ApplicationDbContext db)
        : base(db)
        {

        }
    }
}
