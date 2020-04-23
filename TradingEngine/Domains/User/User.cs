using TradingEngine.Infrastructure;

namespace TradingEngine.Domains.Entities
{
    public class User : Entity
    {
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
