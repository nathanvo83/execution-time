using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutionTime
{
    class Robot
    {
        [Timing]
        public void Run()
        {
            Console.WriteLine("Running...");
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("i: " + i);
            }
        }
    }
}
