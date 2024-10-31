using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoFormDangNhap
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        Modify modify= new Modify();    
        private void button1_Click(object sender, EventArgs e)
        {
            string email=txt_email.Text;
            string query = "Select*from TaiKhoan where Email='" + email + "'";
            if (modify.CheckEmailExists(email))
            {
                txt_ketqua.Text = modify.TaiKhoans(query)[0].matkhau;
            }
            else
            {
                MessageBox.Show("Email không trùng khớp");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
