using program1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrderServiceWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            orderBindingSource.DataSource = orderService.Orders;

            queryInput.DataBindings.Add("Text", this, "KeyWord");

            FindCondition.SelectedIndex = FindCondition.Items.IndexOf("None");

            string[] results = Enum.GetNames(typeof(Products));
        }

                private void ItemAdd_Click(object sender, EventArgs e)
        {
            LinkAddForm form = new LinkAddForm();
            form.Show();
        }

        private void ItemModify_Click(object sender, EventArgs e)
        {
            LinkModifyForm form = new LinkModifyForm();
            form.Show();
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            LinkDeleteForm form = new LinkDeleteForm();
            form.Show();
        }
        
        private void FindBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FindCondition.SelectedItem == null)
                    return;
                if (FindCondition.SelectedItem.ToString() == "订单号")
                {

                    orderBindingSource.DataSource = orderService.FindOrderByOrderNum(KeyWord);
                }
                else if (FindCondition.SelectedItem.ToString() == "客户名")
                {
                    orderBindingSource.DataSource = orderService.FindOrderByClientName(KeyWord);
                }
                else if (FindCondition.SelectedItem.ToString() == "总金额")
                {
                    comboBox1.Visible = true;
                    orderBindingSource.DataSource =
                        orderService.FindOrderByProductBrand(
                            (Products)Enum.Parse(typeof(Products),
                        comboBox1.SelectedItem.ToString()));
                }
                else if (FindCondition.SelectedItem.ToString() == "None")
                {
                    orderBindingSource.DataSource = orderService.Orders;
                }
            }
            catch (DataException ev)
            {
                MessageBox.Show(ev.Message);
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message);
            }
        }

        private bool Save()
        {
            foreach (var o in orderService.Orders)
            {
                Match m1 = rx1.Match(o.PhoneNum);
                if (m1.Success == false)
                {
                    MessageBox.Show("格式错误");
                    return false;
                }
                //Match m2 = rx1.Match(o.OrderNum);
                //if (m2.Success == false)
                //{
                //    MessageBox.Show("订单号格式错误");
                //    return false;
                //}
            }
            orderService.Export(path);
            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }


        private void AddOrder_Click(object sender, EventArgs e)
        {
            bindingNavigatorO.AddNewItem.PerformClick();
        }

        private void RemoveOrder_Click(object sender, EventArgs e)
        {

            foreach (var o in orderService.Orders)
            {
                if (o.OrderNum == ChosenOrder.Text)
                {
                    orderService.RemoveOrder(o);
                    break;
                }
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = orderService.Orders;
            orderBindingSource.DataSource = bs;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {

                Rectangle R = dataGridView2.GetCellDisplayRectangle(
                                    dataGridView2.CurrentCell.ColumnIndex,
                                    dataGridView2.CurrentCell.RowIndex, false);

                comboBox2.Location = new Point(dataGridView2.Location.X + R.X,
                    dataGridView2.Location.Y + R.Y);

                comboBox2.Width = R.Width;
                comboBox2.Height = R.Height;
                comboBox2.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orderDetailsBindingSource.Current == null)
            {
                orderDetailsBindingSource.Add(new OrderDetail());
            }
            ((OrderDetail)orderDetailsBindingSource.Current).Brand =
                (Products)Enum.Parse(typeof(Products), comboBox2.SelectedItem.ToString());
        }



    }
}
