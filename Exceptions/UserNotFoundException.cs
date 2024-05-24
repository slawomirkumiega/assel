namespace users.Exceptions
{
    internal sealed class UserNotFoundException : Exception
    {
        public int Id { get; }

        public UserNotFoundException(int id) : base($"User with id: '{id}' doesn't exists.")
        {
            Id = id;
        }
    }
}
