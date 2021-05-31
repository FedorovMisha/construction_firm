using System;
using System.Collections.Generic;

namespace ConstructionFirm.BL
{
    public class ConstructionPhase
    {
        public string PhaseName { get; set; }
        
        public DateTime DateStart { get; set; }
        
        public DateTime DateEnd { get; set; }
        
        public List<string> Tasks { get; set; }
        
        public bool IsComplete { get; set; }

        public Brigade Brigade { get; set; }
        
        public ConstructionPhase(List<string> tasks, Brigade brigade)
        {
            PhaseName = Guid.NewGuid().ToString();
            Brigade = brigade;
            Tasks = tasks;
            brigade.Tasks = Tasks;
        }
        
        public override string ToString()
        {
            return $"Construction Phase: {PhaseName} - [{DateEnd} - {DateEnd}] - {IsComplete}";
        }

        public void MakeConstructionPhase()
        {
            while (Brigade.MakeTask())
            {
            }

            IsComplete = true;
        }
    }
}