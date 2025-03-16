using EvaluationProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace EvaluationProject
{

    public partial class Form1 : Form
    {
        TaskManagementDB context = new TaskManagementDB();
        private User loggedInUser;
        private bool isSortedAscending = true;

        private int currentPage = 1;
        private int pageSize = 9;
        private int totalPages = 1;
        private HashSet<int> alertedTaskIds = new HashSet<int>(); // Store IDs of overdue tasks

        public Form1(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
            this.WindowState = FormWindowState.Maximized;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBoxGroup();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            display();
            button4.Enabled = false;
            button13.Visible = false;
            dataGridView1.CellClick += dataGridView1_CellContentClick;

            timer1.Interval = 60000; // Check every 60 seconds
            timer1.Tick += timer1_Tick; // Attach the Tick event
            timer1.Start();

            CheckOverdueTasks();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Count")
                {
                    string selectedStatus = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                    using (var context = new TaskManagementDB())
                    {
                        var tasksWithStatus = context.tasks
                            .Where(t => t.UserID == loggedInUser.Id && t.Status.ToString() == selectedStatus) // Filter for logged-in user
                            .Select(t => new
                            {
                                t.Title,
                                t.Description,
                                t.Priority,
                                t.Status,
                                t.DueDate
                            })
                            .ToList();

                        if (tasksWithStatus.Any())
                        {
                            ApplyRowColorFormatting();
                            dataGridView1.DataSource = tasksWithStatus;
                            button13.Tag = "Details";
                        }
                        else
                        {
                            MessageBox.Show($"No tasks found with status: {selectedStatus}", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }


        #region functions
        public void display()
        {
            using (var context = new TaskManagementDB())
            {
                var userTasks = context.tasks
                    .Where(t => t.UserID == loggedInUser.Id)
                    .Include(t => t.User)
                    .Include(t => t.Category);

                // Calculate Total Pages
                int totalTasks = userTasks.Count();
                totalPages = (int)Math.Ceiling((double)totalTasks / pageSize);

                // Fetch only tasks for current page
                var Tasks = userTasks
                    .OrderBy(t => t.DueDate)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .Select(t => new
                    {
                        t.Title,
                        t.Description,
                        t.Priority,
                        t.Status,
                        t.DueDate,
                        CategoryName = t.Category.Name
                    }).ToList();

                dataGridView1.DataSource = Tasks;
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
                ApplyRowColorFormatting();
                // Update Button Visibility
                button6.Enabled = currentPage > 1;         // Disable "Prev" if on first page
                button7.Enabled = currentPage < totalPages; // Disable "Next" if on last page
            }
        }
        public void comboBoxGroup()
        {
            List<string> category = new List<string>();
            category = context.Categories.Select(c => c.Name).Distinct().ToList();

            List<string> Priorties = new List<string>() { "Low", "Medium", "High" };
            Priorties.Insert(0, "All");

            List<string> Priorty = new List<string>() { "Low", "Medium", "High" };


            List<string> Status = new List<string>();
            Status = context.tasks.Select(t => t.Status.ToString()).Distinct().ToList();
            Status.Insert(0, "All");

            comboBox1.DataSource = Priorty;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox2.DataSource = System.Enum.GetValues(typeof(EvaluationProject.Models.Enum));
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox3.DataSource = Priorty;
            comboBox3.SelectedIndex = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox4.DataSource = System.Enum.GetValues(typeof(EvaluationProject.Models.Enum));
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox5.DataSource = Status;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox6.DataSource = category;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox7.DataSource = Priorties;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void FilterAndSearchTasks()
        {
            try
            {
                using (var context = new TaskManagementDB())
                {
                    var searchText = richTextBox1.Text.Trim().ToLower();
                    string selectedStatus = comboBox5.SelectedItem?.ToString();
                    string selectedPriority = comboBox7.SelectedItem?.ToString();

                    var query = context.tasks
                        .Where(t => t.UserID == loggedInUser.Id)
                        .Include(t => t.User)
                        .Include(t => t.Category)
                        .Select(t => new
                        {
                            t.Title,
                            t.Description,
                            t.Priority,
                            t.Status,
                            t.DueDate,
                            CategoryName = t.Category.Name
                        });

                    // Apply Search Filter
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        query = query.Where(t => t.Title.ToLower().Contains(searchText) ||
                                                 t.Description.ToLower().Contains(searchText));
                    }

                    // Apply Status Filter
                    if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "All")
                    {
                        query = query.Where(t => t.Status.ToString() == selectedStatus);
                    }

                    // Apply Priority Filter
                    if (!string.IsNullOrEmpty(selectedPriority) && selectedPriority != "All")
                    {
                        query = query.Where(t => t.Priority == selectedPriority);
                    }

                    // Apply Sorting
                    query = isSortedAscending ? query.OrderBy(t => t.DueDate) : query.OrderByDescending(t => t.DueDate);

                    dataGridView1.DataSource = query.ToList();
                    ApplyRowColorFormatting();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowColorFormatting()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    DataGridViewCell cell = row.Cells["Status"]; // Get the specific cell

                    switch (status)
                    {
                        case "Pending":
                            cell.Style.BackColor = Color.Red;
                            cell.Style.ForeColor = Color.White;
                            break;
                        case "InProgress":
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.ForeColor = Color.Black;
                            break;
                        case "Completed":
                            cell.Style.BackColor = Color.Green;
                            cell.Style.ForeColor = Color.White;
                            break;
                        default:
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void CheckOverdueTasks()
        {
            using (var context = new TaskManagementDB())
            {
                var overdueTasks = context.tasks
                    .Where(t => t.DueDate.Date < DateTime.Now.Date && t.Status.ToString() != "Completed" && t.UserID == loggedInUser.Id)
                    .ToList();

                // Filter out already alerted tasks
                var newOverdueTasks = overdueTasks.Where(t => !alertedTaskIds.Contains(t.Id)).ToList();

                if (newOverdueTasks.Any())
                {
                    string message = "You have overdue tasks:\n\n";

                    foreach (var task in newOverdueTasks)
                    {
                        message += $"- {task.Title} (Due: {task.DueDate.ToShortDateString()})\n";
                        alertedTaskIds.Add(task.Id); // Mark as alerted
                    }

                    MessageBox.Show(message, "Task Due Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion


        #region buttons
        //adding task
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new TaskManagementDB())
                {
                    var cat = comboBox6.SelectedItem;
                    var catid = context.Categories.Where(s => s.Name == cat).Select(s => s.Id).FirstOrDefault();
                    var newTask = new TaskItem
                    {
                        Title = textBox1.Text,
                        Description = richTextBox2.Text,
                        DueDate = dateTimePicker1.Value,
                        Priority = comboBox1.SelectedItem.ToString(),
                        Status = (EvaluationProject.Models.Enum)System.Enum.Parse(typeof(EvaluationProject.Models.Enum), comboBox2.SelectedItem.ToString()),

                        UserID = loggedInUser.Id,
                        CategoryID = catid
                    };

                    context.tasks.Add(newTask);
                    context.SaveChanges();
                    textBox1.Text = " ";
                    richTextBox2.Text = " ";


                    display();

                    MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + (ex.InnerException?.Message ?? ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //delete task
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TaskManagementDB())
                {
                    var task = context.tasks.FirstOrDefault(t => t.Title.ToLower() == textBox6.Text.ToLower());

                    if (task == null)
                    {
                        MessageBox.Show("Error: Task not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    context.tasks.Remove(task);
                    context.SaveChanges();
                    textBox6.Text = " ";
                    display();

                    MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + (ex.InnerException?.Message ?? ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //edit task
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TaskManagementDB())
                {

                    // Find the task by Old Title
                    var task = context.tasks.FirstOrDefault(t => t.Title.ToLower() == textBox4.Text.ToLower());

                    if (task == null)
                    {
                        MessageBox.Show("Error: Task not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Update Task Properties
                    task.Title = textBox7.Text; // Set new title
                    task.DueDate = dateTimePicker2.Value; // Set new due date
                    task.Priority = comboBox3.SelectedItem.ToString(); // Assuming label17 is for Priority
                    task.Status = (EvaluationProject.Models.Enum)System.Enum.Parse(typeof(EvaluationProject.Models.Enum), comboBox4.SelectedItem.ToString()); // Assuming label18 is for Status

                    context.SaveChanges();
                    display();
                    textBox4.Text = " ";
                    textBox7.Text = " ";

                    MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + (ex.InnerException?.Message ?? ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //search in database
        private void button4_Click(object sender, EventArgs e)
        {
            FilterAndSearchTasks();

        }


        //clear the search and filteration
        private void button5_Click(object sender, EventArgs e)
        {
            var Clearbtn = " ";
            richTextBox1.Text = " ";
            display();

        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                display();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                display();
            }
        }


        //show the due date task
        private void button8_Click(object sender, EventArgs e)
        {
            using (var context = new TaskManagementDB())
            {
                var overdueTasks = context.tasks
                .Where(t => t.DueDate.Date < DateTime.Now.Date && t.Status.ToString() != "Completed")
                    .Include(t => t.Category)
                    .Select(t => new
                    {
                        t.Title,
                        t.Description,
                        t.Priority,
                        t.Status,
                        t.DueDate,
                        CategoryName = t.Category != null ? t.Category.Name : "No Category" // Handle null categories
                    })
                    .ToList();

                if (overdueTasks.Any())
                {
                    dataGridView1.DataSource = overdueTasks;
                    ApplyRowColorFormatting();
                    dataGridView1.CurrentCell = null;

                }
                else
                {
                    MessageBox.Show("No overdue tasks found!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        //reporting
        private void button9_Click(object sender, EventArgs e)
        {
            ReportingChart reportingChart = new ReportingChart(loggedInUser);
            reportingChart.Show();
            using (var context = new TaskManagementDB())
            {
                var taskReport = context.tasks
                    .Where(t => t.UserID == loggedInUser.Id)
                    .GroupBy(t => t.Status)
                    .Select(g => new
                    {
                        Status = g.Key.ToString(),
                        Count = g.Count()
                    })
                    .ToList();

                if (taskReport.Any())
                {
                    dataGridView1.DataSource = taskReport;

                    if (dataGridView1.Columns.Contains("Count"))
                    {
                        dataGridView1.Columns["Count"].DefaultCellStyle.ForeColor = Color.Blue;
                        ApplyRowColorFormatting();
                        dataGridView1.CurrentCell = null;

                    }

                    button13.Visible = true;
                    button13.Tag = "Report";
                  
                }
                else
                {
                    MessageBox.Show("No tasks found!", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                    button13.Visible = false;
                }
            }
        }


        //compelation time
        private void button10_Click(object sender, EventArgs e)
        {

            using (var context = new TaskManagementDB())
            {
              
                // Get completed tasks for the logged-in user
                var completedTasks = context.tasks
                    .Where(t => t.Status.ToString() == "Completed" && t.UserID == loggedInUser.Id)
                    .ToList();

                if (!completedTasks.Any())
                {
                    MessageBox.Show("You have no completed tasks.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Calculate average completion time
                double averageCompletionTime = completedTasks
                    .Select(t => (DateTime.Now - t.DueDate).TotalDays)
                    .Average();

                MessageBox.Show($"Your Average Task Completion Time: {averageCompletionTime:F2} days", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //add category
        private void button11_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.Name = textBox3.Text;
            if (context.Categories.Where(s => s.Name == textBox3.Text.ToLower()).Select(s => s.Name.ToLower()).FirstOrDefault() != null)
            {
                MessageBox.Show("Category Already Exist", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.Categories.Add(category);
                context.SaveChanges();
                textBox3.Text = " ";
                comboBox6.DataSource = context.Categories.Select(s => s.Name).Distinct().ToList();
            }
        }


        //sort by the date asc // desc
        private void button12_Click(object sender, EventArgs e)
        {
            isSortedAscending = !isSortedAscending;
            FilterAndSearchTasks();
        }


        //back from reporting button
        private void button13_Click(object sender, EventArgs e)
        {
            using (var context = new TaskManagementDB())
            {
                if (button13.Tag != null && button13.Tag.ToString() == "Details")
                {
                    button9_Click(sender, e);
                    button13.Tag = "Report";
                }
                else
                {
                    var userTasks = context.tasks
                                      .Where(t => t.UserID == loggedInUser.Id)
                                      .Include(t => t.User)
                                      .Include(t => t.Category);

                    // Calculate Total Pages
                    int totalTasks = userTasks.Count();
                    totalPages = (int)Math.Ceiling((double)totalTasks / pageSize);

                    // Fetch only tasks for current page
                    var Tasks = userTasks
                        .OrderBy(t => t.DueDate)
                        .Skip((currentPage - 1) * pageSize)
                        .Take(pageSize)
                        .Select(t => new
                        {
                            t.Title,
                            t.Description,
                            t.Priority,
                            t.Status,
                            t.DueDate,
                            CategoryName = t.Category.Name
                        }).ToList();

                    if (Tasks.Any())
                    {
                        dataGridView1.DataSource = Tasks;

                        // Ensure proper column order
                        dataGridView1.Columns["Title"].DisplayIndex = 0;
                        dataGridView1.Columns["Description"].DisplayIndex = 1;
                        dataGridView1.Columns["Priority"].DisplayIndex = 2;
                        dataGridView1.Columns["Status"].DisplayIndex = 3;
                        dataGridView1.Columns["DueDate"].DisplayIndex = 4;
                        dataGridView1.Columns["CategoryName"].DisplayIndex = 5; // Move Status further
                        ApplyRowColorFormatting();
                    }
                    button13.Visible = false;

                }
            }
        }


        #endregion


        #region comboBoxes
        //filter by status
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAndSearchTasks();

        }

        //filter by priority
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAndSearchTasks();
        }

        #endregion
























        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = !string.IsNullOrWhiteSpace(richTextBox1.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckOverdueTasks();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
            loginform login = new loginform();
            login.Show();
            this.Hide();
        }
    }
}