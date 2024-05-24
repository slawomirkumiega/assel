namespace users.Exceptions
{
    internal sealed class UserAlreadyExistsException : Exception
    {
        public int Id { get; }

        public UserAlreadyExistsException(int id) : base($"User with id: '{id}' already exists.")
        {
            Id = id;
        }
    }
}
