using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaNghi.Model;
namespace QuanLyNhaNghi
{
    public partial class CapNhatThongTinNhanVien : Form
    {
        public CapNhatThongTinNhanVien()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            //QuanLyNhanVien fm = new QuanLyNhanVien();
            //fm.Show();

        }
        private void bindgird(List<NHANVIEN> listNhanvien)
        {

            try
            {
                Model1 context = new Model1();
                dgvNhanVien.Rows.Clear();
                foreach (var item in listNhanvien)
                {
                    int index = dgvNhanVien.Rows.Add();
                    dgvNhanVien.Rows[index].Cells[0].Value = item.MaNV;
                    dgvNhanVien.Rows[index].Cells[1].Value = item.TenNV;
                    
                    dgvNhanVien.Rows[index].Cells[2].Value = item.GioiTinh;
                    dgvNhanVien.Rows[index].Cells[3].Value = item.DienThoai;
                    dgvNhanVien.Rows[index].Cells[4].Value = item.ChucVu;
                    dgvNhanVien.Rows[index].Cells[5].Value = item.DiaChi;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void load()
        {
            Model1 context = new Model1();
            List<NHANVIEN> listNhanvien = context.NHANVIENs.ToList();
            bindgird(listNhanvien);
        }
        //insertNhanvien
        private void InserdNhanVien()
        {
            using (var context = new Model1())
            {
                NHANVIEN s = new NHANVIEN()
                {
                    
                    MaNV = txtNVID.Text,
                    TenNV = txtNVName.Text,
                    
                    GioiTinh = Nam.Checked ? "Nam" : "Nữ",
                    DienThoai = txtNVPhoneNumber.Text,
                    ChucVu = comboBox1.SelectedItem.ToString(),                   
                    DiaChi = txtDiaChi.Text
                        
                };
                context.NHANVIENs.Add(s);
                context.SaveChanges();
            }
        }
        //cập nhật lịch làm việc

        private void CapNhatThongTinNhanVien_Load(object sender, EventArgs e)
        {
            load();
        }
        //fill chuc vụ
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            NHANVIEN s = context.NHANVIENs.FirstOrDefault(p => p.MaNV == txtNVID.Text);
            try
            {
                if (txtNVID.Text == "" || txtNVName.Text == ""||txtNVPhoneNumber.Text=="")
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                if (s == null)
                {
                    InserdNhanVien();clearTextBox();
                    load();
                    MessageBox.Show("Thêm mới thành công!", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    load();
                    MessageBox.Show("Mã Nhân viên đã tồn tại!", "Message", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            NHANVIEN s = context.NHANVIENs.FirstOrDefault(p => p.MaNV == txtNVID.Text);
            try
            {
                if (txtNVID.Text == "" || txtNVName.Text == ""  || txtNVPhoneNumber.Text == "")
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                if (s != null)
                {
                    s.TenNV = txtNVName.Text;
                    
                    s.GioiTinh = Nam.Checked ? "Nam" : "Nữ";
                    s.DienThoai = txtNVPhoneNumber.Text;
                    s.ChucVu = comboBox1.SelectedItem.ToString();
                    s.DiaChi = txtDiaChi.Text;
                    
                    context.SaveChanges();
                    clearTextBox();
                    load();
                    MessageBox.Show("Sửa thông tin thành công!", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    load();
                    MessageBox.Show("Mã Nhân viên không tồn tại!", "Message", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
           
            try
            {
                if (txtNVID.Text == "")
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                NHANVIEN s = context.NHANVIENs.FirstOrDefault(p => p.MaNV == txtNVID.Text);
                if (s != null)
                {
                    context.NHANVIENs.Remove(s);
                    context.SaveChanges();
                    
                    load(); clearTextBox();
                    MessageBox.Show("Xóa thành công!", "Message", MessageBoxButtons.OK);
                }
                else
                {
                    load();
                    MessageBox.Show("Mã Nhân viên không tồn tại!", "Message", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //clear data
        private void clearTextBox()
        {
            txtNVID.Clear();
            txtNVName.Clear();
            txtDiaChi.Clear();          
            txtNVPhoneNumber.Clear();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtNVID.Text == "" && txtNVName.Text == "" && txtNVPhoneNumber.Text == "")
            {
                load();
            }
            else
            {
                Model1 context = new Model1();
                NHANVIEN s = context.NHANVIENs.FirstOrDefault(p => p.TenNV.ToLower() == txtNVName.Text.ToLower());
                NHANVIEN x = context.NHANVIENs.FirstOrDefault(p => p.MaNV.ToLower() == txtNVID.Text.ToLower());
                NHANVIEN z = context.NHANVIENs.FirstOrDefault(p => p.DienThoai == txtNVPhoneNumber.Text);
                List<NHANVIEN> listNV1 = new List<NHANVIEN>();
                List<NHANVIEN> listNV2 = new List<NHANVIEN>();
                List<NHANVIEN> listNV3 = new List<NHANVIEN>();
                listNV1.Add(s);
                listNV2.Add(x); listNV3.Add(z);
                if (x != null)
                {
                    dgvNhanVien.Rows.Clear();
                    bindgird(listNV2); clearTextBox();
                    
                }
                else if (s != null)
                {
                    dgvNhanVien.Rows.Clear();
                    bindgird(listNV1); clearTextBox();
                }
                else if (z != null)
                {
                    dgvNhanVien.Rows.Clear();
                    bindgird(listNV3); clearTextBox();
                }
                else
                {
                    MessageBox.Show("không tìm thấy");
                }

            }

        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNVID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void txtNVID_TextChanged(object sender, EventArgs e)
        {
        //    if (txtNVID.Text == "" || txtNVName.Text == "")
        //        load();
        }
    }
}
