namespace Domain.Model
{
    public class Aircraft : Entity
    {
        public string PlaneName { get; set; }

        public int WingSpanInInches { get; set; }

        public bool IsFoam { get; set; }
    }
}
