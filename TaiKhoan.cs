using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFormDangNhap
{
    internal class TaiKhoan
    {
        private string TenTaiKhoan;
        private string MatKhau;

        public TaiKhoan()
        {

        }

        public TaiKhoan(string tenTaiKhoan, string matkhau)
        {
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matkhau;
        }
        public string tentaikhoan
        {
            get=> TenTaiKhoan;
            set=> TenTaiKhoan = value;
        }
        public string matkhau
        {
            get => MatKhau;
            set=> MatKhau = value;
        }
    }
}
