using YSLDotNetCore.Shared;
using YSLDotNetCore.WinFormsApp.Models;
using YSLDotNetCore.WinFormsApp.Queries;

namespace YSLDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _blogID;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        public FrmBlog(int blogID)
        {
            InitializeComponent();
            _blogID = blogID;
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var model = _dapperService.QueryFirstOrDefault<BlogModel>("select * from Tbl_Blog where blogID = @BlogID", new { BlogID = _blogID });

            txtTitle.Text = model.BlogTitle.Trim();
            txtAuthor.Text = model.BlogAuthor.Trim();
            txtContent.Text = model.BlogContent.Trim();

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        private void clearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel
                {
                    BlogTitle = txtTitle.Text,
                    BlogAuthor = txtAuthor.Text,
                    BlogContent = txtContent.Text
                };
                int result = _dapperService.Execute(BlogQuery.BlogCreate);
                string message = result > 0 ? "Saving Successfully" : "Saving Failed";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
                if (result > 0) clearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel
                {
                    BlogID = _blogID,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };
                var query = @"Update Tbl_Blog Set [BlogTitle] = @BlogTitle
                                ,[BlogAuthor] = @BlogAuthor
                                ,[BlogContent] = @BlogContent Where blogID = @BlogID";
                int result = _dapperService.Execute(query,item);
                string message = result > 0 ? "Updating Successfully" : "Updating Failed";
                MessageBox.Show(message);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
