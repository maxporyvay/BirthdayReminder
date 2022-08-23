using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BirthdayReminder.App_Code;

namespace BirthdayReminder
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Person> all_people = DataAccessor.SelectPeople();
            List<Person> people = new List<Person>();
            foreach (Person person in all_people)
            {
                if (IsDateAppropriate(person.PersonBirthdate))
                {
                    people.Add(person);
                }
            }
            if (!IsPostBack)
            {
                BindGrid(people);
            }
            GridViewRecentBirthdaysList.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            GridViewRecentBirthdaysList.Columns[0].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            GridViewRecentBirthdaysList.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewRecentBirthdaysList.Columns[1].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            GridViewRecentBirthdaysList.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewRecentBirthdaysList.Columns[2].ItemStyle.VerticalAlign = VerticalAlign.Middle;
        }

        public bool IsDateAppropriate(DateTime date)
        {
            DateTime today = DateTime.Today;
            date = date.AddYears(today.Year - date.Year);
            DateTime date1 = date.AddDays(-7);
            if (today.Month == 12 && date.Month == 1)
            {
                date.AddYears(1);
                date1.AddYears(1);
            }
            return date1 < today && date >= today;
        }

        public void BindGrid(List<Person> people)
        {
            GridViewRecentBirthdaysList.AutoGenerateColumns = false;
            GridViewRecentBirthdaysList.DataSource = people;
            GridViewRecentBirthdaysList.DataBind();
        }
    }
}