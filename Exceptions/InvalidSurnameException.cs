namespace users.Exceptions
{
    internal sealed class InvalidSurnameException : Exception
    {
        public string Surname { get; }

        public InvalidSurnameException(string surname) : base($"Surname: '{surname}' is invalid.")
        {
            Surname = surname;
        }
    }
}
