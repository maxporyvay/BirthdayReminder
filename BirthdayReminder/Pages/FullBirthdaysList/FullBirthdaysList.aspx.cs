using System;
using System.Web.UI.WebControls;
using BirthdayReminder.App_Code;

namespace BirthdayReminder.Pages.FullBirthdaysList
{
    public partial class FullBirthdaysList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            GridViewFullBirthdaysList.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewFullBirthdaysList.Columns[0].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            GridViewFullBirthdaysList.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewFullBirthdaysList.Columns[1].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            GridViewFullBirthdaysList.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewFullBirthdaysList.Columns[2].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            GridViewFullBirthdaysList.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            GridViewFullBirthdaysList.Columns[3].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            GridViewFullBirthdaysList.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewFullBirthdaysList.Columns[4].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            GridViewFullBirthdaysList.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewFullBirthdaysList.Columns[4].ItemStyle.VerticalAlign = VerticalAlign.Middle;
        }

        private void BindGrid()
        {
            GridViewFullBirthdaysList.AutoGenerateColumns = false;
            GridViewFullBirthdaysList.DataSource = DataAccessor.SelectPeople();
            GridViewFullBirthdaysList.DataBind();
        }

        protected void GridViewFullBirthdaysList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridViewFullBirthdaysList.DataKeys[e.RowIndex].Value.ToString());
            DataAccessor.DeletePhoto(id);
            DataAccessor.DeletePerson(id);
            BindGrid();
        }

        protected void GridViewFullBirthdaysList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.Cells[1].Controls[0]).OnClientClick = "return confirm('Вы уверены, что хотите удалить запись?');";
            }
        }

        protected void GridViewFullBirthdaysList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = int.Parse(GridViewFullBirthdaysList.DataKeys[e.NewEditIndex].Value.ToString());
            Response.Redirect("~/Pages/FullBirthdaysList/EditFullBirthdaysList.aspx?id=" + id);
        }
    }
}