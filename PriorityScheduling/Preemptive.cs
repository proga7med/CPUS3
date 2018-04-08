using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Process;

namespace PriorityScheduling
{
    public class Preemptive : Priority
    {
        int ptr = 1;
        int mostptr = 0;
        int LastBurstTimeValue = 0;

        public Preemptive(Process.Process p)
        {
            for (int i = 0; i < 5; i++)
            {
                p = new Process.Process();
                p.process_num = i + 1;
                p.arrival_time = at[i];
                p.burst_time = b[i];
                p.priority = pp[i];
                processList.Add(p);
            }
        }
        public void Start()
        {
            #region Variable Declaration
            //Declare Variable 
            //Declare Loop Counter;
            int loopCount = 0;    
            //Init Variable
            Gwait.Add(processList[0].arrival_time);
            //Add first Variable
            Gprocess.Add(processList[0].process_num);
            processStack.Push(processList[0]);
            #endregion
            while (true)
            {
                #region First Operation Loop
                //First Operation "First Loop" 
                if (loopCount == NumberOfProcess && processList[mostptr % processList.Count].burst_time > 0)
                {
                    Gwait.Add(Gwait[Gwait.Count - 1] + LastBurstTimeValue);
                    processList.RemoveAt(mostptr);
                    loopCount++;
                    processList.Sort((t, i) => t.priority.CompareTo(i.priority));
                    continue;
                }

                if (ptr < NumberOfProcess)
                {
                    Process.Process ptemp = processList[mostptr];
                    ptemp.burst_time = processList[mostptr].burst_time - (at[ptr] - at[ptr - 1]);
                    processList[mostptr] = ptemp;
                }

                if (processList[mostptr % processList.Count].burst_time <= 0 && ptr < NumberOfProcess)
                {
                    processList.RemoveAt(mostptr % processList.Count);
                    if (at[ptr] - at[mostptr] > b[mostptr])
                        Gwait.Add(at[mostptr] + b[mostptr]);
                    else
                    {
                        Process.Process ptemp = processList[ptr];
                        ptemp.arrival_time = processList[ptr].arrival_time;
                        processList[loopCount] = ptemp;
                    }


                    Process.Process ProcessBack = processStack.Pop();
                    ProcessBack = processStack.Pop();
                    mostptr = Array.IndexOf(Gprocess.ToArray(), ProcessBack.process_num);
                    Gprocess.Add(processList[mostptr].process_num);
                    LastBurstTimeValue = processList[mostptr].burst_time;
                }
                else if (processList[ptr % processList.Count].priority == processList[mostptr % processList.Count].priority)
                    ptr++;

                if (processList[ptr % processList.Count].priority < processList[mostptr % processList.Count].priority && ptr < NumberOfProcess)
                {
                    mostptr = ptr;
                    Gprocess.Add(processList[mostptr].process_num);
                    processStack.Push(processList[mostptr]);
                    Gwait.Add(processList[mostptr].arrival_time);
                    LastBurstTimeValue = processList[mostptr].burst_time;
                }
                #endregion
                #region Final Operation Loop
                //Final Operation "Second Loop"
                if (loopCount > NumberOfProcess)
                {
                    mostptr = 0;
                    Gprocess.Add(processList[mostptr % processList.Count].process_num);
                    Gwait.Add(Gwait[Gwait.Count - 1] + processList[mostptr].burst_time);
                    processList.RemoveAt(mostptr);
                }
                #endregion
                #region Break Loop
                if (processList.Count == 0)
                    break;
                #endregion
                ptr++;
                loopCount++;

            }
        }
    }
}
