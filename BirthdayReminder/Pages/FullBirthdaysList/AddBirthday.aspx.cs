using System;
using System.Globalization;
using System.Drawing;
using BirthdayReminder.App_Code;

namespace BirthdayReminder.Pages.FullBirthdaysList
{
    public partial class AddBirthday : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
        }
        public bool ValidateDate()
        {
            string text = TextBoxPersonBirthdate.Text.ToString();
            //ErrorMessage.Text = text;
            if (!string.IsNullOrEmpty(text))
            {
                string[] formats = {"yyyy-MM-dd", "dd-MM-yyyy"};
                DateTime value;
                if (!DateTime.TryParseExact(text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out value))
                    return false;
                return true;
            }
            return false;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateDate() && !(string.IsNullOrEmpty(TextBoxPersonName.Text) || TextBoxPersonName.Text == ""))
            {
                string appPath = Request.PhysicalApplicationPath;
                string photoname = "none.jpg";
                string name = TextBoxPersonName.Text;
                DateTime birthdate = DateTime.Parse(TextBoxPersonBirthdate.Text);
                if (FileUploadPersonPhoto.HasFile)
                {
                    string filename = Server.HtmlEncode(FileUploadPersonPhoto.FileName);
                    string[] filenamearr = filename.Split('.');
                    string extension = filenamearr[filenamearr.Length - 1];
                    photoname = name.Replace(" ", "") + "." + extension;
                    string savePath = appPath + "/image/people/" + photoname;
                    FileUploadPersonPhoto.SaveAs(savePath);
                }
                Person person = new Person(0, name, birthdate, photoname);
                DataAccessor.InsertPerson(person);
                Response.Redirect("~/Pages/FullBirthdaysList/FullBirthdaysList.aspx");
            }
            else
            {
                ErrorMessage.Text = "Неверный формат имени или даты";
                ErrorMessage.ForeColor = Color.Red;
            }
        }
    }
}