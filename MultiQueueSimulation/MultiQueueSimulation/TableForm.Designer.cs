namespace MultiQueueSimulation
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerNumberLabel = new System.Windows.Forms.Label();
            this.RandomInterArrivalLabel = new System.Windows.Forms.Label();
            this.InterArrivalLabel = new System.Windows.Forms.Label();
            this.RandomServiceLabel = new System.Windows.Forms.Label();
            this.ServiceTimeLabel = new System.Windows.Forms.Label();
            this.ServerNumberLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.TimeInQueueLabel = new System.Windows.Forms.Label();
            this.ArrivalTimeLabel = new System.Windows.Forms.Label();
            this.SepratorLabel = new System.Windows.Forms.Label();
            this.ItemsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // CustomerNumberLabel
            // 
            this.CustomerNumberLabel.AutoSize = true;
            this.CustomerNumberLabel.Location = new System.Drawing.Point(30, 25);
            this.CustomerNumberLabel.Name = "CustomerNumberLabel";
            this.CustomerNumberLabel.Size = new System.Drawing.Size(61, 13);
            this.CustomerNumberLabel.TabIndex = 0;
            this.CustomerNumberLabel.Text = "Customer #";
            this.CustomerNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RandomInterArrivalLabel
            // 
            this.RandomInterArrivalLabel.AutoSize = true;
            this.RandomInterArrivalLabel.Location = new System.Drawing.Point(110, 25);
            this.RandomInterArrivalLabel.Name = "RandomInterArrivalLabel";
            this.RandomInterArrivalLabel.Size = new System.Drawing.Size(60, 13);
            this.RandomInterArrivalLabel.TabIndex = 1;
            this.RandomInterArrivalLabel.Text = "Random IA";
            this.RandomInterArrivalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InterArrivalLabel
            // 
            this.InterArrivalLabel.AutoSize = true;
            this.InterArrivalLabel.Location = new System.Drawing.Point(190, 25);
            this.InterArrivalLabel.Name = "InterArrivalLabel";
            this.InterArrivalLabel.Size = new System.Drawing.Size(60, 13);
            this.InterArrivalLabel.TabIndex = 2;
            this.InterArrivalLabel.Text = "Inter Arrival";
            // 
            // RandomServiceLabel
            // 
            this.RandomServiceLabel.AutoSize = true;
            this.RandomServiceLabel.Location = new System.Drawing.Point(354, 25);
            this.RandomServiceLabel.Name = "RandomServiceLabel";
            this.RandomServiceLabel.Size = new System.Drawing.Size(86, 13);
            this.RandomServiceLabel.TabIndex = 3;
            this.RandomServiceLabel.Text = "Random Service";
            // 
            // ServiceTimeLabel
            // 
            this.ServiceTimeLabel.AutoSize = true;
            this.ServiceTimeLabel.Location = new System.Drawing.Point(462, 25);
            this.ServiceTimeLabel.Name = "ServiceTimeLabel";
            this.ServiceTimeLabel.Size = new System.Drawing.Size(69, 13);
            this.ServiceTimeLabel.TabIndex = 4;
            this.ServiceTimeLabel.Text = "Service Time";
            this.ServiceTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerNumberLabel
            // 
            this.ServerNumberLabel.AutoSize = true;
            this.ServerNumberLabel.Location = new System.Drawing.Point(548, 25);
            this.ServerNumberLabel.Name = "ServerNumberLabel";
            this.ServerNumberLabel.Size = new System.Drawing.Size(48, 13);
            this.ServerNumberLabel.TabIndex = 5;
            this.ServerNumberLabel.Text = "Server #";
            this.ServerNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(620, 25);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(29, 13);
            this.StartLabel.TabIndex = 6;
            this.StartLabel.Text = "Start";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(670, 25);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(26, 13);
            this.EndLabel.TabIndex = 7;
            this.EndLabel.Text = "End";
            // 
            // TimeInQueueLabel
            // 
            this.TimeInQueueLabel.AutoSize = true;
            this.TimeInQueueLabel.Location = new System.Drawing.Point(717, 25);
            this.TimeInQueueLabel.Name = "TimeInQueueLabel";
            this.TimeInQueueLabel.Size = new System.Drawing.Size(74, 13);
            this.TimeInQueueLabel.TabIndex = 8;
            this.TimeInQueueLabel.Text = "Time in queue";
            // 
            // ArrivalTimeLabel
            // 
            this.ArrivalTimeLabel.AutoSize = true;
            this.ArrivalTimeLabel.Location = new System.Drawing.Point(266, 25);
            this.ArrivalTimeLabel.Name = "ArrivalTimeLabel";
            this.ArrivalTimeLabel.Size = new System.Drawing.Size(62, 13);
            this.ArrivalTimeLabel.TabIndex = 9;
            this.ArrivalTimeLabel.Text = "Arrival Time";
            // 
            // SepratorLabel
            // 
            this.SepratorLabel.AutoSize = true;
            this.SepratorLabel.Location = new System.Drawing.Point(-3, 38);
            this.SepratorLabel.Name = "SepratorLabel";
            this.SepratorLabel.Size = new System.Drawing.Size(880, 13);
            this.SepratorLabel.TabIndex = 10;
            this.SepratorLabel.Text = "_________________________________________________________________________________" +
    "________________________________________________________________-";
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.AutoScroll = true;
            this.ItemsPanel.Location = new System.Drawing.Point(0, 54);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.Size = new System.Drawing.Size(833, 396);
            this.ItemsPanel.TabIndex = 11;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Controls.Add(this.ItemsPanel);
            this.Controls.Add(this.SepratorLabel);
            this.Controls.Add(this.ArrivalTimeLabel);
            this.Controls.Add(this.TimeInQueueLabel);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.ServerNumberLabel);
            this.Controls.Add(this.ServiceTimeLabel);
            this.Controls.Add(this.RandomServiceLabel);
            this.Controls.Add(this.InterArrivalLabel);
            this.Controls.Add(this.RandomInterArrivalLabel);
            this.Controls.Add(this.CustomerNumberLabel);
            this.Name = "TableForm";
            this.Text = "Simulation Table";
            this.Load += new System.EventHandler(this.TableForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CustomerNumberLabel;
        private System.Windows.Forms.Label RandomInterArrivalLabel;
        private System.Windows.Forms.Label InterArrivalLabel;
        private System.Windows.Forms.Label RandomServiceLabel;
        private System.Windows.Forms.Label ServiceTimeLabel;
        private System.Windows.Forms.Label ServerNumberLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label TimeInQueueLabel;
        private System.Windows.Forms.Label ArrivalTimeLabel;
        private System.Windows.Forms.Label SepratorLabel;
        private System.Windows.Forms.Panel ItemsPanel;
    }
}