using BookHosting.Application.Common.Interfaces.Persistence;
using BookHosting.Domain.Entities;

namespace BookHosting.Infrastructure.Persistence;

public class userRepository : IUserRepository
{
    private readonly static List<User> _users = new List<User>();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.Where(x=>x.Email==email).SingleOrDefault();
    }

}