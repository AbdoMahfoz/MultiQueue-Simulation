using System;
using System.Windows.Forms;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem SS;
        public Form1()
        {
            SS = new SimulationSystem();
            InitializeComponent();
        }
        private void NumOfS_ValueChanged(object sender, EventArgs e)
        {
            SS.NumberOfServers = (int)NumOfS.Value;
        }
        private void StopC_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoppingNum.Enabled = true;
            SS.StoppingCriteria = (Enums.StoppingCriteria)(StopC.SelectedIndex + 1);
        }
        private void StoppingNum_ValueChanged(object sender, EventArgs e)
        {
            SS.StoppingNumber = (int)StoppingNum.Value;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SS.SelectionMethod = (Enums.SelectionMethod)(comboBox1.SelectedIndex + 1);
        }
        private async void Submit_Click(object sender, EventArgs e)
        {
            for (int rows = 0; rows < InterAT.Rows.Count -1; rows++)
            {
                SS.InterarrivalDistribution.Add(new TimeDistribution()
                {
                    Time = int.Parse((string)InterAT.Rows[rows].Cells[0].Value) ,
                    Probability = decimal.Parse((string)InterAT.Rows[rows].Cells[1].Value)});
            }
            Submit.Text = "Running...";
            Submit.Enabled = false;
            await Simulator.StartSimulation(SS);
            Submit.Text = "Submit";
            Submit.Enabled = true;
        }
        int i = 1;
        private void NextServer_Click(object sender, EventArgs e)
        {
            NumOfS.Enabled = false;
            Server s = new Server();
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                s.TimeDistribution.Add(new TimeDistribution()
                {
                    Time = int.Parse((string)dataGridView1.Rows[rows].Cells[0].Value),
                    Probability = decimal.Parse((string)dataGridView1.Rows[rows].Cells[1].Value)
                });
            }
            dataGridView1.Rows.Clear();
            i++;
            SS.Servers.Add(s);
            if(i==SS.NumberOfServers)
            {
                NextServer.Text = "Submit Server";
            }
            if(i == SS.NumberOfServers+1)
            {
                NextServer.Enabled = false;
                dataGridView1.Enabled = false;
            }
            else
            {
                ServiceDistribution.Text = "Service Distribution : Server [ " + i + " ] ";
            }
        }
        private async void TestButton_Click(object sender, EventArgs e)
        {
            TestButton.Text = "Testing...";
            TestButton.Enabled = false;
            await Simulator.Test();
            TestButton.Text = "Automatic Testing";
            TestButton.Enabled = true;
        }
    }
}
