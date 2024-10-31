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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();   
            quenMatKhau.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
        }
        Modify modify = new Modify();
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tk=txt_taikhoan.Text;
            string mk=txt_matkhau.Text;
            if(tk.Trim() == "")
            {
                MessageBox.Show("Hay nhap ten tai khoan");
            }
            else if(mk.Trim ()== "")
            {
                MessageBox.Show("Vui long nhap mat khau");

            }
            else
            {
                string query = "Select*from TaiKhoan where TenTaiKhoan= '" + tk + "' and MatKhau='"+mk+"'";
                if (modify.TaiKhoans(query).Count > 0)
                {
                    MessageBox.Show("Dang nhap thanh cong");
                    Home home = new Home();
                    home.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tai Khoan Hoac Mat Khau sai");
                }
            }
        }
    }
}
