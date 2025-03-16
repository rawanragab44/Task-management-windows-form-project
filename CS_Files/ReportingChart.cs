using EvaluationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationProject
{
    public partial class ReportingChart : Form
    {
        private User loggedInUser;

        public int Id { get; set; }

        public ReportingChart(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
            InitializeCustomControls();
            LoadTaskCounts();
        }

        private void ReportingChart_Load(object sender, EventArgs e)
        {

        }

        #region Custom Controller
        private reportChart lowProgressCircle, midProgressCircle, highProgressCircle;
        private Label progressLabel, totalTasksLabel;

        private void InitializeCustomControls()
        {
            // Total Tasks Label (Above the Circles)
            totalTasksLabel = new Label
            {
                Text = "Total Tasks: 0",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(140, 20),
                AutoSize = true
            };
            this.Controls.Add(totalTasksLabel);

            // Initialize Progress Circles for Low, Medium, and High Priority
            lowProgressCircle = CreateProgressCircle(new Point(50, 60), Color.Red);
            midProgressCircle = CreateProgressCircle(new Point(180, 60), Color.Orange);
            highProgressCircle = CreateProgressCircle(new Point(310, 60), Color.Green);


            // Percentage Label (Centered)
            progressLabel = new Label
            {
                Text = "0% | 0% | 0%",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(160, 200), // Positioned in the center
                AutoSize = true
            };

            this.Controls.Add(progressLabel);
        }

        private reportChart CreateProgressCircle(Point location, Color progressColor)
        {
            var circle = new reportChart
            {
                Location = location,
                Size = new Size(100, 100),
                ProgressColor = progressColor,
                BackgroundColor = Color.LightGray,
                MaxValue = 100
            };
            this.Controls.Add(circle);
            return circle;
        }
        #endregion

        private void LoadTaskCounts()
        {
            using (TaskManagementDB Context = new TaskManagementDB())
            {
                int pending = Context.tasks.Where(s => s.UserID == loggedInUser.Id).Count(s => s.Status.ToString() == "Pending");
                int inprogress = Context.tasks.Where(s => s.UserID == loggedInUser.Id).Count(s => s.Status.ToString() == "InProgress");
                int completed = Context.tasks.Where(s => s.UserID == loggedInUser.Id).Count(s => s.Status.ToString() == "Completed");

                int totalTasks = pending + inprogress + completed;

                if (totalTasks == 0)
                {
                    progressLabel.Text = "No Tasks";
                    return;
                }

                // Calculate percentages
                double pendingPercent = (pending / (double)totalTasks) * 100;
                double inprogressPercent = (inprogress / (double)totalTasks) * 100;
                double completedPercent = (completed / (double)totalTasks) * 100;

                
                lowProgressCircle.Value = (int)pendingPercent;
                midProgressCircle.Value = (int)inprogressPercent;
                highProgressCircle.Value = (int)completed;

                // Update total tasks label
                totalTasksLabel.Text = $"Total Tasks: {totalTasks}";

                // Update Progress Label with percentages
                progressLabel.Text = $"Pending: {pendingPercent:F1}%     |     InProgrss: {inprogressPercent:F1}%    |     Completed: {completedPercent:F1}%";
            }
        }

        private void report_Load(object sender, EventArgs e)
        {
            LoadTaskCounts(); // Ensure data loads when the form opens
        }
    }
}

