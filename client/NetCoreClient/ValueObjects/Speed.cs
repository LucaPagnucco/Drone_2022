namespace NetCoreClient.ValueObjects
{
    internal class Speed
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public DateTime Date { get; private set; }
        
        public Speed(int value)
        {
            Name = "speed";
            this.Value = value;
            Date = DateTime.Now;
        }

    }
}
