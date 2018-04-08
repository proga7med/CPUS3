using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityScheduling
{
    public class Priority
    {
        protected Process.Process process;
        protected List<Process.Process> processList;
        protected Stack<Process.Process> processStack;
        protected List<int> Gprocess;
        protected List<int> Gwait;
        protected int NumberOfProcess;
        //
        protected int[] at;
        protected int[] pp;
        protected int[] b;
    } 
}
