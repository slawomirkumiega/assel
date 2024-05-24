namespace users.Exceptions
{
    internal sealed class InvalidFirstNameException : Exception
    {
        public string FirstName { get; set; }

        public InvalidFirstNameException(string firstName) : base($"First name: '{firstName}' is invalid.")
        {
            FirstName = firstName;
        }
    }
}
