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

namespace DemoFormDangNhap
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }
        public bool CheckAccount(string t)
        {
            return Regex.IsMatch(t, "^[a-zA-Z0-9]{6,18}$");
        }
        public bool CheckEmail(string tmp)
        {
            return Regex.IsMatch(tmp, @"^[a-zA-Z0-9_.]{5,20}@gmail.com$");
        }
        Modify modify = new Modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string tentk = txt_dangnhap.Text;
            string mk= txt_matkhau.Text;
            string xnmk= txt_xnmk.Text;
            string email= txt_email.Text;   
            if (!CheckAccount(tentk)) {
                MessageBox.Show("Tên tài khoản từ 6-18 ký tự,chỉ gồm chữ và số");
                return;
            }
            if (!CheckAccount(mk)) {
                MessageBox.Show("Tên tài khoản từ 6-18 ký tự,chỉ gồm chữ và số");
                return;
            }
            if (xnmk != mk) {
                MessageBox.Show("Vui long xac nhan mat khau ");
                return;
            }
            if (!CheckEmail(email)) {
                MessageBox.Show("Vui long nhap dung dinh dang email");
                return;
            }
            string s = "Select*from TaiKhoan where Email= '" + email + "'";
            if (modify.TaiKhoans(s).Count()>0)
            {
                MessageBox.Show("Email da ton tai");
                return;
            }
            try
            {
                string query = "Select*from TaiKhoan where TenTaiKhoan= '" + tentk +"'";
                if (modify.TaiKhoans(query).Count<=0)
                {
                    modify.InsertUser(tentk, email, mk);
                   if( MessageBox.Show("Dang Ky thanh cong! Ban co muon dang nhap luon khong ?","thong bao",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ten Tai Khoan da ton tai");
                }
                
            }
            catch {
                MessageBox.Show("Ten tai khoan nay da duoc dang ky");
            }

        }
    }
}
