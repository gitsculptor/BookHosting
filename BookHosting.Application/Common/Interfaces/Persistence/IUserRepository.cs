using BookHosting.Domain.Entities;

namespace BookHosting.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}