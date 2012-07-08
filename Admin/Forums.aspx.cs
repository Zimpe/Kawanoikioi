using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kawanoikioi.Models;

namespace Kawanoikioi.Admin
{
    public partial class Forums : System.Web.UI.Page
    {
        AdminRepository _repository = new AdminRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            AddButton.Enabled = false;
            if (_repository.CreateForum(NameTextBox.Text, ContentTextBox.Text, int.Parse(CategoryList.SelectedValue)))
            {
                ResultLabel.Text = NameTextBox.Text + " was successfully added to the database";
                NameTextBox.Text = "";
                ContentTextBox.Text = "";
                AddButton.Enabled = true;
            }
            else
            {
                ResultLabel.Text = "An error has occured " + NameTextBox.Text + " was not added to the database. Please try again.";
                AddButton.Enabled = true;
            }
        }
    }
}