using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundRobin
{
    public class RoundRobin
    {
        int[] temp = new int[50];
        int[] tempProcess = new int[50];
        int[] waiting_time = new int[50];
        int[] proc = new int[50];
        int Quntaum;
        int NumberOfProcess = 0;
        int[] awt = new int[50];
        public List<int> Gwait = new List<int>();
        public List<int> Gprocess = new List<int>();
        List<Process.Process> processList =  new List<Process.Process>();
        float AverageWaiting = 0;

        public RoundRobin(List<Process.Process> pList, int Qauntum)
        {
            
            processList = pList;
            NumberOfProcess = pList.Count;
            Quntaum = Qauntum;
        }
        public RoundRobin(int[] burstTime , int[] process , int Qauntum)
        {
            for (int i = 0; i < burstTime.Length; i++)
            {
                Process.Process p = new Process.Process();
                p.burst_time = burstTime[i];
                p.process_num = process[i];
                processList.Add(p);
            }
            NumberOfProcess = process.Length;
            this.Quntaum = Qauntum;
        }
        public void Start()
        {
            //Quntaum = 0;
            //waiting_time[0] = 0;
            Gwait.Add(0);
            int count = 0;
            int j = 0;
            int total = 0;
            while (true)
            {
                if (processList[count % NumberOfProcess].burst_time > 0)
                {
                    if (processList[count % NumberOfProcess].burst_time > Quntaum)
                    {
                        Gprocess.Add(processList[count % NumberOfProcess].process_num);
                        total += Quntaum;
                        Gwait.Add(total);
                        processList[count % NumberOfProcess].burst_time -= Quntaum;
                    }
                    else if (processList[count % NumberOfProcess].process_num <= Quntaum)
                    {
                        Gprocess.Add(processList[count % NumberOfProcess].process_num);
                        total += processList[j % NumberOfProcess].burst_time;
                        Gwait.Add(total);
                        processList[count % NumberOfProcess].burst_time -= Quntaum;
                    }

                }
                int t = 0;
                for (int i = 0; i < NumberOfProcess; i++)
                {
                    if (processList[i].burst_time <= 0)
                        t++;
                }
                if (t == NumberOfProcess)
                    break;

                count++;
                j++;
            }

            for (int o = 0; o < NumberOfProcess; o++)
            {
                int e = 0;
                for (int m = 0; m < processList.Count; m++)
                {
                    if (processList[o].process_num == processList[m].process_num)
                        e = Gwait[m + 1];
                }
                awt[o] = e;
            }

            float wait_total = 0;
            for (int q = 0; q < NumberOfProcess; q++)
            {
                awt[q] = awt[q] - processList[q].burst_time;
                wait_total += awt[q];
            }
            float average_wait_time = wait_total / NumberOfProcess;


        }

        public void GanttChart()
        {
            
        }

        public float GetAverageWaitingTime()
        {
            return AverageWaiting;
        }

    }
}
