namespace NetCoreClient.ValueObjects
{
    internal class Latitude
    {
        public string Name { get; private set; }
        public double Value { get; private set; }
        public DateTime Date { get; private set; }
        
        public Latitude(double value)
        {
            Name = "latitude";
            this.Value = value;
            Date = DateTime.Now;
        }

    }
}