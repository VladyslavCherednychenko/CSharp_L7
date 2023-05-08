using L7.Data;
using L7.Models;

namespace L7
{
    public partial class Form1 : Form
    {
        private GroupCRUD groupCRUD = new GroupCRUD();
        private StudentCRUD studentCRUD = new StudentCRUD();

        public Form1()
        {
            InitializeComponent();

            List<Group> groups = groupCRUD.GetGroups();
            dataGridView1.DataSource = groups;

            List<Student> students = studentCRUD.GetStudentsFromGroup("KIYKIy-21-2");
            dataGridView2.DataSource = students;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            var gId = Convert.ToInt32(row.Cells["GroupId"].Value);
            var gName = row.Cells["GroupName"].Value.ToString();

            groupCRUD.EditGroup(gId, gName);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

            StudentDTO student = new StudentDTO();
            student.StudentName = row.Cells["StudentName"].Value.ToString();
            student.StudentGroup = row.Cells["StudentGroup"].Value.ToString();
            var studentId = Convert.ToInt32(row.Cells["StudentId"].Value);

            studentCRUD.EditStudent(studentId, student);
        }

        private void deleteGroupBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var rowIndex = dataGridView1.SelectedRows[0].Index;
                var groupName = dataGridView1.Rows[rowIndex].Cells["GroupName"].Value.ToString();

                groupCRUD.DeleteGroup(groupName);

                List<Group> groups = groupCRUD.GetGroups();
                dataGridView1.DataSource = groups;
            }
        }

        private void deleteStudentBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count < 1 || dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var rowIndex = dataGridView2.SelectedRows[0].Index;
                var studentId = Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells["StudentId"].Value);

                studentCRUD.DeleteStudent(studentId);

                List<Student> students = studentCRUD.GetStudentsFromGroup(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["GroupName"].Value.ToString());
                dataGridView2.DataSource = students;
            }
        }

        private void addGroupBtn_Click(object sender, EventArgs e)
        {
            groupCRUD.CreateGroup("New Value");

            List<Group> groups = groupCRUD.GetGroups();
            dataGridView1.DataSource = groups;
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }

            StudentDTO student = new StudentDTO();
            student.StudentName = "StudentName";
            student.StudentGroup = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["GroupName"].Value.ToString();
            studentCRUD.CreateStudent(student);

            List<Student> students = studentCRUD.GetStudentsFromGroup(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["GroupName"].Value.ToString());
            dataGridView2.DataSource = students;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Student> students = studentCRUD.GetStudentsFromGroup(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["GroupName"].Value.ToString());
            dataGridView2.DataSource = students;
        }
    }
}