using System;

namespace ConstructionFirm.BL
{
    public class Worker : User, IWorker
    {

        public void MakeTask(string task)
        {
            Console.WriteLine($"{UserName} выполнил задачу {task}");
            Console.WriteLine($"{UserName} отправил отчет {task}");
        }
    }
}