namespace users.Entities
{
    internal sealed class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Login { get; private set; }

        public User(int id, string firstName, string surname, string login)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Login = login;
        }
    }
}
