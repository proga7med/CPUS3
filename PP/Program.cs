/*
    This project is about Priority Preemptive Scheduling Algorithm
    Time Complexity O(N)
    Using Arrival Time - Brust Time & Process Priority
    Is Created By Pr(o,O)g
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Process;
using PriorityScheduling;

namespace Main
{

    
    class Program
    {
        static void Main(string[] args)
        {
            //PriorityPreemptive();
            Process.Process p = new Process.Process();
            Preemptive preemptive = new Preemptive(p);
            preemptive.Start();
        }



    }
}
