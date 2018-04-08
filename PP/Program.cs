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
using RoundRobin;
using System.Windows.Forms;

namespace Main
{

    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //PriorityPreemptive();
            Process.Process p = new Process.Process();
            //Preemptive preemptive = new Preemptive(p);
            //preemptive.Start();

            List<Process.Process> pList = new List<Process.Process>();
            int[] b = {53, 17, 68,24};
            int[] pro = { 1, 2, 3, 4 };

            RoundRobin.RoundRobin round = new RoundRobin.RoundRobin(b,pro,20);
            round.Start();


            GanttChart.Form1 f1 = new GanttChart.Form1();
            f1.process = round.Gprocess.ToArray();
            f1.waiting_time = round.Gwait.ToArray();
            f1.AverageTime = round.GetAverageWaitingTime();
            f1.Show();
            Application.Run(f1);
        }



    }
}
