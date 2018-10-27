using System.Diagnostics;
using System.IO;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    static class Visualizer
    {
        static public void PlotUtilizationGraph(SimulationSystem System)
        {
            Process p = new Process();
            p.StartInfo.FileName = "python";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = Directory.GetCurrentDirectory() + "\\ess.py";
            p.StartInfo.RedirectStandardInput = true;
            int ServerNum = 1;
            foreach(Server s in System.Servers)
            {
                p.Start();
                bool flag = false;
                int lastStart = 0;
                foreach(var pair in s.UtilizationTimes)
                {
                    for(int i = lastStart; i < pair.Key; i++)
                    {
                        if (flag)
                            p.StandardInput.Write(',');
                        else
                            flag = true;
                        p.StandardInput.Write(0);
                    }
                    for(int i = pair.Key; i <= pair.Value; i++)
                    {
                        if (flag)
                            p.StandardInput.Write(',');
                        else
                            flag = true;
                        p.StandardInput.Write(1);
                    }
                    lastStart = pair.Value + 1;
                }
                for(int i = lastStart; i <= System.TotalSimulationTime; i++)
                {
                    if (flag)
                        p.StandardInput.Write(',');
                    else
                        flag = true;
                    p.StandardInput.Write(0);
                }
                p.StandardInput.Write('\n');
                p.StandardInput.WriteLine(ServerNum++);
                p.WaitForExit();
            }
        }
    }
}
