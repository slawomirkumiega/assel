namespace Assel.Entities
{
    internal sealed class Fact
    {
        public string Id { get; private set; }
        public string FactText { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PetType PetType { get; private set; }

        private Fact() {}

        public Fact(string id, string factText, DateTime createdAt, PetType petType)
        {
            Id = id;
            FactText = factText;
            CreatedAt = createdAt;
            PetType = petType;
        }
    }
}
