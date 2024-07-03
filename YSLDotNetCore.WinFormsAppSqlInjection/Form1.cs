using YSLDotNetCore.Shared;

namespace YSLDotNetCore.WinFormsAppSqlInjection;

public partial class Form1 : Form
{
    private readonly DapperService _dapperService;
    public Form1()
    {
        InitializeComponent();
        _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    }

    //SqlInjection
    //private void btnLogin_Click(object sender, EventArgs e)
    //{
    //    string query = $"select * from Tbl_User where email = 'txtEmail.Text.Trim()' and password = 'txtPassword.Text.Trim()'";
    //    var model = _dapperService.QueryFirstOrDefault<UsreModel>(query);
    //    if (model is null)
    //    {
    //        MessageBox.Show("User doesn't exist.");
    //        return;
    //    }
    //    MessageBox.Show("Admin is : " + model.Email);
    //}

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string query = $"select * from Tbl_User where email = @Email and password = @password";
        var model = _dapperService.QueryFirstOrDefault<UsreModel>(query,new
        {
            Email = txtEmail.Text.Trim(),
            Password = txtPassword.Text.Trim()
        });
        if ( model is null)
        {
            MessageBox.Show("User doesn't exist.");
            return;
        }
        MessageBox.Show("Admin is : " + model.Email);
    }
}

public class UsreModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}
