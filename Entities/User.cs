namespace Assel.Entities
{
    internal sealed class User
    {
        public string Id { get; private set; }

        public ICollection<Fact> Facts { get; private set; }

        public User(string id)
        {
            Id = id;
        }

        public void AddFacts(IEnumerable<Fact> facts)
        {
            foreach (Fact fact in facts)
            {
                Facts = Facts ?? [];
                Facts.Add(fact);
            }
        }
    }
}
