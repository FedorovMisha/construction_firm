using System.Collections.Generic;
using System.Linq;

namespace ConstructionFirm.BL
{
    public class Order
    {
        public int OrderKey { get; set; }
        
        public List<ConstructionPhase> Phases { get; set; }

        public bool IsComplete { get; set; }
        
        public Order()
        {
            Phases = new();
        }
        
        public Order(List<ConstructionPhase> phases)
        {
            Phases = phases;
        }
        
        public string[] GetPhasesStrings()
        {
            var strings = new List<string> ();
            Phases.ForEach(x => strings.Add(x.ToString()));
            return strings.ToArray();
        }

        public void MakePhase()
        {
            // Phases.ForEach(x => x.MakeConstructionPhase());
            var phase = Phases.FirstOrDefault(x => !x.IsComplete);
            if(phase != null)
                phase.MakeConstructionPhase();
            
            IsComplete = Phases.All(x => x.IsComplete);
        }
    }
}