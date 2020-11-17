using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FormQLDichVu : Form
    {
        public FormQLDichVu()
        {
            InitializeComponent();
        }

        private void FormQLDichVu_Load(object sender, EventArgs e)
        {
            reset();
            reset3();
        }

        private DataTable table1;
        private DataTable table2;
        private DataTable table3;
        private Connection connector = new Connection();

        private void reset()
        {
            listView1.Items.Clear();
            table1 = new DataTable();
            table1 = connector.LoadData("5");
            int i = 0;
            foreach (DataRow row in table1.Rows)
            {
                listView1.Items.Add(row[0].ToString());
                listView1.Items[i].SubItems.Add(row[1].ToString());
                listView1.Items[i].SubItems.Add(row[2].ToString());
                i++;
            }
        }

        private void reset2()
        {
            listView1.Items.Clear();
            table1 = connector.FindObject("5", textSearch.Text.Trim());
            int i = 0;
            foreach (DataRow row in table1.Rows)
            {
                listView1.Items.Add(row[0].ToString());
                listView1.Items[i].SubItems.Add(row[1].ToString());
                listView1.Items[i].SubItems.Add(row[2].ToString());
                i++;
            }
        }

        private void reset3()
        {
            listView2.Items.Clear();
            table2 = new DataTable();
            table2 = connector.LoadData("2");
            int i = 0;
            foreach (DataRow row in table2.Rows)
            {
                listView2.Items.Add(row[0].ToString());
                listView2.Items[i].SubItems.Add(row[1].ToString());
                i++;
            }
            listView3.Items.Clear();
            table3 = new DataTable();
            table3 = connector.LoadData("4");
            i = 0;
            foreach (DataRow row in table3.Rows)
            {
                listView3.Items.Add(row[0].ToString());
                listView3.Items[i].SubItems.Add(row[1].ToString());
                i++;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;
                textID1.Text = table1.Rows[index][0].ToString();
                textID2.Text = table1.Rows[index][1].ToString();
                textNum.Text = table1.Rows[index][2].ToString();
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                int index = listView2.SelectedItems[0].Index;
                textID1.Text = table2.Rows[index][0].ToString();
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                int index = listView3.SelectedItems[0].Index;
                textID2.Text = table3.Rows[index][0].ToString();
            }
        }

        private void radView_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            
        }

        private bool check(int k)
        {
            if (textID1.Text.Trim() == "")
            {
                MessageBox.Show("Room ID's values must not be null", "O___O", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textID1.Focus();
                return false;
            }
            if (textID2.Text.Trim() == "")
            {
                MessageBox.Show("Service ID's values must not be null", "O___O", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textID2.Focus();
                return false;
            }
            if (k == 1)
            {
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    if (textID1.Text.Trim() == table1.Rows[i][0].ToString().Trim() && textID2.Text.Trim() == table1.Rows[i][1].ToString().Trim())
                    {
                        MessageBox.Show("This room "+ table1.Rows[i][0].ToString().Trim()+"already has this Service "+table1.Rows[i][1].ToString().Trim()+" counted, please pick new pair", "O___O", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textID1.Focus();
                        return false;
                    }
                }
            }
            
            return true;
        }

        private void butFree_Click(object sender, EventArgs e)
        {
            
        }
    }
}
