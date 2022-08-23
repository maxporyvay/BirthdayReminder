using System;
using System.Drawing;
using System.Web;
using BirthdayReminder.App_Code;

namespace BirthdayReminder.Pages.FullBirthdaysList
{
    public partial class EditFullBirthdaysList : System.Web.UI.Page
    {
        private int id = 0;
        public string photoname;

        protected void Page_Load(object sender, EventArgs e)
        {
            FileUploadPersonPhoto.Enabled = false;
            if (String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                LabelMessage.Text = "PersonId не определен";
                LabelMessage.ForeColor = Color.Red;
                return;
            }

            LabelMessage.Text = String.Empty;
            id = int.Parse(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindControls()
        {
            Person person = DataAccessor.SelectPerson(id);
            TextBoxPersonName.Text = person.PersonName;
            TextBoxPersonBirthdate.Text = person.PersonBirthdate.ToString("yyyy-MM-dd");
            photoname = person.PersonPhotoName;
        }

        protected void RadioChanged(object sender, EventArgs e)
        {
            bool radio0enabled = Radio0.Checked;
            FileUploadPersonPhoto.Enabled = radio0enabled;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            bool updatePhoto = true;
            string path = HttpContext.Current.Server.MapPath("/image/people/");
            string name = TextBoxPersonName.Text;
            DateTime birthdate = DateTime.Parse(TextBoxPersonBirthdate.Text);
            if (Radio2.Checked)
            {
                DataAccessor.DeletePhoto(id);
                photoname = "none.jpg";
            }
            else if (FileUploadPersonPhoto.HasFile && Radio0.Checked)
            {
                string filename = Server.HtmlEncode(FileUploadPersonPhoto.FileName);
                string[] filenamearr = filename.Split('.');
                string extension = filenamearr[filenamearr.Length - 1];
                photoname = name.Replace(" ", "") + "." + extension;
                string savePath = path + photoname;
                FileUploadPersonPhoto.SaveAs(savePath);
            }
            else
                updatePhoto = false;
            Person person = new Person(id, name, birthdate, photoname);
            DataAccessor.UpdatePerson(person, updatePhoto);
            Response.Redirect("~/Pages/FullBirthdaysList/FullBirthdaysList.aspx");
        }
    }
}