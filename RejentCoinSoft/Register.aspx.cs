using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicTier;
using System.Data.SqlClient;
using System.Data;
using System.Net;

public partial class admin_index : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsUser objUser = new clsUser();
    clsEPin objepin = new clsEPin();
    private delegate void DoStuff(); //delegate for the action
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //loadcountry();
            if (Request.QueryString["sid"] != null)
            {
                txtsponserid.Text = Request.QueryString["sid"];
                loadsusername();
                if (Request.QueryString["p"] != null)
                {
                    rbstandingposition.SelectedValue = Request.QueryString["p"].ToString();
                    rbstandingposition.Enabled = false;
                }
            }

        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {

        //if (ddepin.SelectedValue != "0")
        //{
        string str_image = "default.png";
        //if (FileUpload1.HasFile)
        //{
        //    str_image = Guid.NewGuid().ToString().Substring(0, 6) + FileUpload1.FileName;
        //    FileUpload1.SaveAs(Server.MapPath("admin/userimage/") + str_image);
        //}
        objUser.UserName = txtname.Text;
        objUser.Mobile = txtmobile.Text;
        objUser.Email = txtemail.Text;
        objUser.Gender = ddgender.SelectedValue.ToString();
        objUser.Address ="";
        objUser.CityName = "";
        objUser.CountryId = "0";
        objUser.StateId = "0";
        objUser.AreaName = "";
        objUser.PanCardNo = "";
        objUser.Pincode = "";
        objUser.DateOfBirth = Message.GetIndianDate("01/01/1900");
        objUser.Password = txtuserpassword.Text;
        objUser.MentionBy = "Online";
        objUser.SponserId = txtsponserid.Text;
        objUser.Regtype = "Panel";
        objUser.ImageName = str_image;
        objUser.StateId = "0";

        objUser.StandingPosition = rbstandingposition.SelectedValue.ToString();
    
        objUser.OperatorId = "0";
        objUser.OperatorType = "0";
        objUser.LandMark = "";
        objUser.IsDummyData = "0";

        DataTable dt = new DataTable();
        dt = objUser.Insert_User(objUser);
        string res = dt.Rows[0][0].ToString();
        if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'Mobile No Already Exists');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else if (res == "e")
        {
            string popupScript = "toastr.error('Error', 'Email Already exits');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else if (res == "u")
        {
            string popupScript = "toastr.error('Error', 'User id already exists');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else if (res == "m")
        {
            string popupScript = "toastr.error('Error', 'Mobile No already exists');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        //else if (res == "m")
        //{
        //    string popupScript = "toastr.error('Error', 'Email already exists');";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        //}
        else if (res == "s")
        {
            string popupScript = "toastr.error('Error', 'Select Standing Position');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else if (res == "t")
        {
            //string popupScript = "toastr.success('Success', 'User Added Successfully, UserId is " + res + "');";
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            //create the delegate
            //DoStuff myAction = new DoStuff(M1(lbl_TicketId.Text, ddlEmployee.SelectedValue, lbl_Name.Text,lbl_Client.Text, lbl_Subject.Text, lbl_Priority.Text, lblCompanyName.Text, lbl_ProjectName.Text, LblDomainname.Text));
            //DoStuff myAction = new DoStuff(() => M1("",""));
            ////invoke it asynchrnously, control passes to next statement
            //myAction.BeginInvoke(null, null);

            lbluseridpopup.Text = dt.Rows[0]["userid"].ToString();
            lblnamepopup.Text = txtname.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);


            //Message.Show("User Added Successfully, UserId is " + res + "");
            txtname.Text = txtmobile.Text = txtemail.Text = txtuserpassword.Text = txtconfirmpassword.Text = "";
            //    ddcountry.SelectedValue = "0";
            ddgender.SelectedValue = "0";
            // ddoperator.SelectedValue = "0";
            // loadstate();
            // loadepin();


        }
        else
          
        {
            string popupScript = "toastr.error('Error', 'Unknown error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
     
        //}
        //else
        //{
        //    string popupScript = "toastr.error('Error', 'Select E-Pin');";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        //}
    }


    public async void M1(string str_userid, string str_standingposition)
    {
       


    }




    void loadsusername()
    {
        DataTable dt = new DataTable();
        objUser.UserId = txtsponserid.Text;
        dt = objUser.getUserName(objUser);
        if (dt.Rows.Count > 0)
        {
            txtsponsername.Text = dt.Rows[0]["username"].ToString();

        }
        else
        {
            txtsponsername.Text = "";
            txtsponserid.Text = "";
            string popupScript = "toastr.error('Error', 'Invalid User Id');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
       
    }
    protected void txtsponserid_TextChanged(object sender, EventArgs e)
    {
        loadsusername();

    }
   
}