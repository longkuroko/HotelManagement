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
    public partial class CapNhatLoaiPhong : Form
    {
        public CapNhatLoaiPhong()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            //QuanLyPhong fm = new QuanLyPhong();
            //fm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void FillcomboBoxTenPhong(List<PHONG> listPhong)
        {
            try
            {

                cmbTenPhong.DataSource = listPhong;
                cmbTenPhong.DisplayMember = "MaPhong";
                cmbTenPhong.ValueMember = "MaPhong";
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //load_data
        private void load()
        {
            Model1 context = new Model1();
            List<PHONG> listPhong = context.PHONGs.ToList();//lấy danh sách phòng
            List<LOAIPHONG> listLoaiPhong = context.LOAIPHONGs.ToList();//lấy danh sách loại phòng
            FillcomboBoxTenPhong(listPhong);

        }
        //cập nhật loại phòng
        private void UpdateLoaiPhong()
        {
            
            Model1 context = new Model1();
            try
            {
                PHONG s = context.PHONGs.FirstOrDefault(p => p.MaPhong == cmbTenPhong.SelectedValue.ToString());
                if (s != null)
                {
                    if (Standard.Checked == true)
                        s.MaLoaiPhong = "LP01";
                        s.GiaTien = 500000;
                    if (Superior.Checked == true)
                        s.MaLoaiPhong = "LP02";
                        s.GiaTien = 1000000;
                   

                    context.SaveChanges();
                    load();
                    MessageBox.Show("Cập nhật thành công!", "Message", MessageBoxButtons.OK);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CapNhatLoaiPhong_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateLoaiPhong();
        }

        private void CapNhatLoaiPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
