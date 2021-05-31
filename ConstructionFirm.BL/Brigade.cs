using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionFirm.BL
{
    public class Brigade
    {
        public List<IWorker> Workers { get; set; }
        
        public List<string> Tasks { get; set; }

        public Brigade(List<IWorker> workers)
        {
            Workers = workers;
        }
        
        public Brigade(List<string> tasks)
        {
            Tasks = new (tasks);
        }

        public bool MakeTask()
        {
            var worker = Workers[new Random().Next(Workers.Count)];
            var task = Tasks.FirstOrDefault();

            if (task == null) return false;
            
            worker.MakeTask(task);

            Tasks.Remove(task);
            return true;
        }
    }
}