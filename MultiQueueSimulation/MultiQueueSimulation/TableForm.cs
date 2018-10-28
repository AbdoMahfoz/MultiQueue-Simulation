using System;
using System.Windows.Forms;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    public partial class TableForm : Form
    {
        SimulationSystem Data;
        public TableForm(SimulationSystem Data)
        {
            this.Data = Data;
            InitializeComponent();
        }
        private void TableForm_Load(object sender, EventArgs e)
        {
            int offset = 0;
            foreach(SimulationCase c in Data.SimulationTable)
            {
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.TimeInQueue.ToString(),
                    Location = new System.Drawing.Point(717, 10 + offset),
                    Size = new System.Drawing.Size(10, 30)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.EndTime.ToString(),
                    Location = new System.Drawing.Point(670, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.StartTime.ToString(),
                    Location = new System.Drawing.Point(620, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.AssignedServer.ID.ToString(),
                    Location = new System.Drawing.Point(548, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.ServiceTime.ToString(),
                    Location = new System.Drawing.Point(462, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.RandomService.ToString(),
                    Location = new System.Drawing.Point(354, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.ArrivalTime.ToString(),
                    Location = new System.Drawing.Point(266, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.InterArrival.ToString(),
                    Location = new System.Drawing.Point(190, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.RandomInterArrival.ToString(),
                    Location = new System.Drawing.Point(110, 10 + offset)
                });
                ItemsPanel.Controls.Add(new Label()
                {
                    Text = c.CustomerNumber.ToString(),
                    Location = new System.Drawing.Point(30, 10 + offset),
                });
                offset += 30;
            }
        }
    }
}
