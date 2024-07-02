using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YSLDotNetCore.Shared;
using YSLDotNetCore.WinFormsApp.Models;

namespace YSLDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        private const int _edit = 1;
        private const int _delete = 2;
        public FrmBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void BlogList()
        {
            List<BlogModel> list = _dapperService.Query<BlogModel>("select * from Tbl_Blog");
            dgvData.DataSource = list;
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var colIndex = e.ColumnIndex;
            //var rowIndex =  e.RowIndex;

            if (e.RowIndex == -1) return;
            var blogID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colID"].Value);

            if(e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                FrmBlog frmBlog = new FrmBlog(blogID);
                frmBlog.ShowDialog();
                BlogList();
            }
            else if(e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;

                DeleteBlog(blogID);
                BlogList();
            }
        }

        private void DeleteBlog(int id)
        {
            string query = @"Delete From [dbo].[Tbl_Blog] Where BlogID = @BlogID";
            var result = _dapperService.Execute(query, new { BlogID = id });
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            MessageBox.Show(message);
        }
    }
}
