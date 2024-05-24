namespace users.Exceptions
{
    internal sealed class InvalidLoginException : Exception
    {
        public string Login { get; }
        public InvalidLoginException(string login) : base($"Login: '{login}' is invalid.")
        {
            Login = login;
        }
    }
}
