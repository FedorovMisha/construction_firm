using System;

namespace ConstructionFirm.Bl
{
    public class Phase
    {
        public string Id { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public Phase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return Id;
        }
    }
}