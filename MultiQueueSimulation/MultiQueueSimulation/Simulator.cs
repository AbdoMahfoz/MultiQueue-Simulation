using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    /// <summary>
    /// Static class that drives the simulation
    /// </summary>
    static class Simulator
    {
        static Random rnd = new Random();
        /// <summary>
        /// Extract the random value out of a TimeDistribution object using a given random variable
        /// </summary>
        /// <param name="Distribution">Used to evaluate final random value</param>
        /// <param name="RandomVariable">The random number required by TimeDistribution parameter</param>
        /// <returns>The requested random value</returns>
        static private int CalculateRandomValue(List<TimeDistribution> Distribution, int RandomVariable)
        {
            for (int i = 0; i < Distribution.Count; i++)
            {
                if (!Distribution[i].IsCalculated)
                {
                    if(i == 0)
                    {
                       Distribution[i].CummProbability = Distribution[i].Probability;
                       Distribution[i].MinRange = 1;
                    }
                    else
                    {
                        Distribution[i].CummProbability = Distribution[i].Probability + Distribution[i - 1].CummProbability;
                        Distribution[i].MinRange = Distribution[i - 1].MaxRange + 1;
                    }
                    Distribution[i].MaxRange =(int)(Distribution[i].CummProbability * 100);
                    Distribution[i].IsCalculated = true;
                }
                if(RandomVariable<=Distribution[i].MaxRange && RandomVariable>=Distribution[i].MinRange)
                {
                    return Distribution[i].Time;
                }
            }
            if (RandomVariable < 1 || RandomVariable > 100)
                throw new ArgumentOutOfRangeException("RandomValue should be between 1 and 100");
            else
                throw new Exception("Debug meeeeeeeee");
        }
        /// <summary>
        /// Finds a server to sever the current simulation case
        /// </summary>
        /// <param name="Case">The current simulation case that needs to be served</param>
        /// <param name="Servers">A list of all servers to search in</param>
        /// <returns>The server that will serve the given simulation case</returns>
        static private void GetAssignedServer(SimulationCase Case, List<Server> Servers,Enums.SelectionMethod SelectionMethod)
        {
            int serverNum = 0;
            int minServiceTime = Servers[0].FinishTime;
            int minBigger = 0;
            bool bigger = true;
            decimal minUtilization = Servers[0].Utilization;
            if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
            {
                for (int i = 0; i < Servers.Count; i++)
                {
                    if (Servers[i].FinishTime <= Case.ArrivalTime)
                    {
                        bigger = false;
                    }
                    if (Servers[i].FinishTime < minServiceTime)
                    {
                        minBigger = i;
                        minServiceTime = Servers[i].FinishTime;
                    }
                }
                if (bigger == true)
                {
                    serverNum = minBigger;
                }
                else
                {
                    for (int i = 0; i < Servers.Count; i++)
                    {
                        if (Servers[i].FinishTime <= Case.ArrivalTime)
                        {
                            minServiceTime = Servers[i].FinishTime;
                            serverNum = i;
                            break;
                        }
                    }
                }
            }
            else if (SelectionMethod == Enums.SelectionMethod.LeastUtilization)
            {
                int minValue = Servers[0].FinishTime;
                for (int i = 1; i < Servers.Count; i++)
                {
                    minValue = Math.Min(Servers[i].FinishTime, minValue);
                }
                bool flag = false;
                if(minValue < Case.ArrivalTime)
                {
                    minValue = Case.ArrivalTime;
                    flag = true;
                }
                decimal leastUtil = decimal.MaxValue;
                for(int i = 0; i < Servers.Count; i++)
                {
                    if (flag)
                    {
                        if (Servers[i].FinishTime <= minValue && Servers[i].Utilization < leastUtil)
                        {
                            leastUtil = Servers[i].Utilization;
                            serverNum= i;
                        }
                    }
                    else
                    {
                        if (Servers[i].FinishTime == minValue && Servers[i].Utilization < leastUtil)
                        {
                            leastUtil = Servers[i].Utilization;
                            serverNum = i;
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < Servers.Count; i++)
                {
                    if (Servers[i].FinishTime < minServiceTime)
                    {
                        minServiceTime = Servers[i].FinishTime;
                        serverNum = i;
                    }
                }
            }
            Case.AssignedServer = Servers[serverNum];
            Case.RandomService = rnd.Next(1, 100);
            Case.ServiceTime = CalculateRandomValue(Servers[serverNum].TimeDistribution, Case.RandomService);
            Case.StartTime = Math.Max(Servers[serverNum].FinishTime, Case.ArrivalTime);
            Case.EndTime = Case.StartTime + Case.ServiceTime;
            Case.TimeInQueue = Case.StartTime - Case.ArrivalTime;
            Servers[serverNum].FinishTime = Case.StartTime + Case.ServiceTime;
            Servers[serverNum].TotalWorkingTime += Case.ServiceTime;
            Servers[serverNum].AverageServiceTime += Case.ServiceTime;
            Servers[serverNum].ServedCount++;
        }
        /// <summary>
        /// Entry point of the simulator
        /// </summary>
        /// <param name="System">The system to be simulated</param>
        static private void SimulationMain(SimulationSystem System)
        {
            Queue<SimulationCase> Queue = new Queue<SimulationCase>();
            int SimulationTime = 0;
            int Total_TimeinQueue = 0;
            int Number_Of_Customers_Who_Waited = 0;
            int Max_QueueLength = 0;
            List<SimulationCase> Cases = new List<SimulationCase>();
            if (System.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                for(int i = 0; i < System.StoppingNumber; i++)
                {
                    SimulationCase c = new SimulationCase
                    {
                        CustomerNumber = i,
                        RandomInterArrival = rnd.Next(1, 100)
                    };
                    if (i == 0)
                    {
                        c.InterArrival = 0;
                        c.ArrivalTime = 0;
                    }
                    else
                    {
                        c.InterArrival = CalculateRandomValue(System.InterarrivalDistribution, c.RandomInterArrival);
                        c.ArrivalTime = Cases[i - 1].ArrivalTime + c.InterArrival;
                    }
                    GetAssignedServer(c, System.Servers, System.SelectionMethod);
                    SimulationTime = Math.Max(SimulationTime, c.EndTime);
                    while(Queue.Count > 0)
                    {
                        if(Queue.Peek().StartTime <= c.ArrivalTime)
                        {
                            Queue.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (c.TimeInQueue > 0)
                    {
                        Queue.Enqueue(c);
                        Total_TimeinQueue += c.TimeInQueue;
                        Number_Of_Customers_Who_Waited++;
                    }
                    Max_QueueLength = Math.Max(Max_QueueLength, Queue.Count);
                    Cases.Add(c);
                }
            }
            else
            {
                int Counter = 0;
                while (true)
                {
                    SimulationCase c = new SimulationCase
                    {
                        CustomerNumber = Counter,
                        RandomInterArrival = rnd.Next(1, 100)
                    };
                    if (Cases.Count == 0)
                    {
                        c.InterArrival = 0;
                        c.ArrivalTime = 0;
                    }
                    else
                    {
                        c.InterArrival = CalculateRandomValue(System.InterarrivalDistribution, c.RandomInterArrival);
                        c.ArrivalTime = Cases[Cases.Count - 1].ArrivalTime + c.InterArrival;
                    }
                    if(c.ArrivalTime > System.StoppingNumber)
                    {
                        break;
                    }
                    GetAssignedServer(c, System.Servers, System.SelectionMethod);
                    while (Queue.Count > 0)
                    {
                        if (Queue.Peek().StartTime <= c.ArrivalTime)
                        {
                            Queue.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (c.TimeInQueue > 0)
                    {
                        Queue.Enqueue(c);
                        Total_TimeinQueue += c.TimeInQueue;
                        Number_Of_Customers_Who_Waited++;
                    }
                    SimulationTime = Math.Max(SimulationTime, c.EndTime);
                    Max_QueueLength = Math.Max(Max_QueueLength, Queue.Count);
                    Counter++;
                    Cases.Add(c);
                }
            }
            System.PerformanceMeasures.AverageWaitingTime = ((decimal)Total_TimeinQueue / Cases.Count);
            System.PerformanceMeasures.WaitingProbability = ((decimal)Number_Of_Customers_Who_Waited / Cases.Count);
            System.PerformanceMeasures.MaxQueueLength = Max_QueueLength;
            System.SimulationTable = Cases;
            for(int i = 0; i < System.Servers.Count; i++)
            {
                if(System.Servers[i].ServedCount != 0)
                    System.Servers[i].AverageServiceTime /= System.Servers[i].ServedCount;
                System.Servers[i].Utilization = (decimal)System.Servers[i].TotalWorkingTime / SimulationTime;
            }
        }
        /// <summary>
        /// Tests the simulator using the provided testing dll and test cases
        /// </summary>
        static public async Task Test()
        {
            List<string> Results = new List<string>();
            foreach (string s in Directory.EnumerateFiles(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\TestCases\\"))
            {
                string fileName = s.Substring(s.LastIndexOf("\\") + 1);
                if (fileName.Contains("TestCase"))
                {
                    SimulationSystem system = MultiQueueTesting.TestCase.GetSystem(fileName);
                    await StartSimulation(system);
                    Results.Add(MultiQueueTesting.TestingManager.Test(system, fileName));
                }
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("Number of test cases : " + Results.Count);
            for (int i = 1; i <= Results.Count; i++)
            {
                builder.Append("\nTest #" + i + ":\n" + Results[i - 1]);
            }
            MessageBox.Show(builder.ToString());
        }
        /// <summary>
        /// Runs the Simulation and fills the required outputs
        /// </summary>
        /// <param name="System">The system to be simulated</param>
        static public async Task StartSimulation(SimulationSystem System)
        {
            await Task.Run(() =>
            {
                SimulationMain(System);
            });
        }
    }
}
