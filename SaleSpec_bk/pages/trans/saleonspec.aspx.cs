﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Security.Cryptography;


namespace SaleSpec.pages.trans
{
    public partial class saleonspec : System.Web.UI.Page
    {
        string ssql;
        DataTable dt = new DataTable();

        SqlConnection Conn = new SqlConnection();
        SqlCommand Comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlTransaction transac;
        
        public string strMsgAlert = "";
        public string strTblDetail = "";
        public string strTblActive = "";

        dbConnection dbConn = new dbConnection();

        ReportDocument rpt = new ReportDocument();


        public string sPage = "SaleOnSpec";

        protected void Page_Load(object sender, EventArgs e)
        {
            //string strUserID = Session["UserID"].ToString();
            if (Session["UserID"] == null)
            {
                Response.Redirect("../../pages/users/login");
            }

            if (!IsPostBack)
            {
                GetInitialData();
            }
        }

        protected void GetInitialData()
        {
            GetProjectDataBind();
        }

        protected void GetProjectDataBind()
        {
            try
            {
                //ssql = "SELECT	a.ProjectID, a.ProjectYear, a.ProjectMonth, a.ProjectName, a.ArchitecID, a.CompanyID, a.CompanyName, " +
                //        "        a.Location, a.ProvinceID, a.ProvinceName, a.MainCons, a.RefRfDf, a.ProductType, a.RefProfile, a.Quantity, a.RefType,  " +
                //        "        a.DeliveryDate, a.Drawing, a.ProcID, a.StepID, a.SaleID, a.EmpCode, a.sEmFirstName, a.sEmLastName, a.CreatedDate,  " +
                //        "        a.CreatedBy, a.LastedUpdate, a.UpdatedBy, a.StatusConID, b.ConDesc2 " +
                //        "FROM    adProjects2 AS a LEFT JOIN " +
                //        "        adStatusConfirm AS b ON a.StatusConID = b.StatusConID " +
                //        "WHERE  a.StepID in ('sold', 'sos') ";

                ssql = "exec spSaleOnSpec '2019-12-16', '2019-12-31' ";

                dt = new DataTable();
                dt = dbConn.GetDataTable(ssql);

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strCompanyID = dt.Rows[i]["CompanyID"].ToString();
                        string strCompanyName = dt.Rows[i]["CompanyName"].ToString();
                        string strArchitecID = dt.Rows[i]["ArchitecID"].ToString();
                        string strName = dt.Rows[i]["Name"].ToString();
                        string strSpec = dt.Rows[i]["Spec"].ToString();
                        string strDocuNo = dt.Rows[i]["DocuNo"].ToString();
                        string strDocDate = dt.Rows[i]["DocDate"].ToString();
                        string strRollformer = dt.Rows[i]["Rollformer"].ToString();
                        string strProjectID = dt.Rows[i]["ProjectID"].ToString();
                        string strProjectName = dt.Rows[i]["ProjectName"].ToString();
                        string strRefPO = dt.Rows[i]["RefPO"].ToString();
                        string strGoodCode = dt.Rows[i]["GoodCode"].ToString();
                        string strModel = dt.Rows[i]["Model"].ToString();
                        string strAcutalM = dt.Rows[i]["AcutalM"].ToString();
                        string strSpecM = dt.Rows[i]["SpecM"].ToString();
                        string strPrice = dt.Rows[i]["Price"].ToString();
                        string strRentAmount = dt.Rows[i]["RentAmount"].ToString();
                        string strNetRF = dt.Rows[i]["NetRF"].ToString();
                        string strNetCom = dt.Rows[i]["NetCom"].ToString();
                        string strNetItem = dt.Rows[i]["NetItem"].ToString();
                        string strPort = dt.Rows[i]["Port"].ToString();
                        string strSendDate = dt.Rows[i]["SendDate"].ToString();
                        string strPriceRate = dt.Rows[i]["PriceRate"].ToString();
                        string strPriceOver = dt.Rows[i]["PriceOver"].ToString();
                        string strssConfirm = dt.Rows[i]["ssConfirm"].ToString();

                        string strClass = "";


                        if (strssConfirm == "Pending")
                        {
                            strClass = "class=\"text-red\"";
                        }
                        else 
                        {
                            strClass = "class=\"text-blue\"";
                        }
                        //else
                        //{
                        //    strConDesc2 = "<span class=\"text-red\">" + strConDesc2 + "</span>";
                        //}

                        strTblDetail += "<tr "+ strClass + "> " +
                                    "     <td>" + strCompanyID + "</td> " +
                                    "     <td >" + strCompanyName + "</td> " +
                                    "     <td >" + strArchitecID + "</td> " +
                                    "     <td>" + strName + "</td> " +
                                    "     <td >" + strSpec + "</td> " +
                                    "     <td >" + strDocuNo + "</td> " +
                                    "     <td>" + strDocDate + "</td> " +
                                    "     <td>" + strRollformer + "</td> " +
                                    "     <td >" + strProjectID + "</td> " +
                                    "     <td >" + strProjectName + "</td> " +
                                    "     <td >" + strRefPO + "</td> " +
                                    "     <td >" + strGoodCode + "</td> " +
                                    "     <td>" + strModel + "</td> " +
                                    "     <td >" + strAcutalM + "</td> " +
                                    "     <td >" + strSpecM + "</td> " +
                                    "     <td>" + strPrice + "</td> " +
                                    "     <td>" + strRentAmount + "</td> " +
                                    "     <td>" + strNetRF + "</td> " +
                                    "     <td >" + strNetCom + "</td> " +
                                    "     <td >" + strNetItem + "</td> " +
                                    "     <td >" + strPort + "</td> " +
                                    "     <td >" + strSendDate + "</td> " +
                                    "     <td class=\"hidden\">" + strPriceRate + "</td> " +
                                    "     <td class=\"hidden\">" + strPriceOver + "</td> " +
                                    "     <td>" + strssConfirm + "</td> " +
                                    "<td style=\"width: 20px; text-align: center;\"> " +
                                    "       <a href=\"#\" title=\"Edit\"><i class=\"fa fa-pencil-square-o text-green\"></i></a></td> " +
                                    "<td style=\"width: 20px; text-align: center;\"> " +
                                    "       <a href=\"#\" title=\"Delete\"><i class=\"fa fa-trash text-red\"></i></a></td> " +
                                    "</tr>";
                    }

                    Session["datalist"] = strTblDetail;
                }
            }
            catch (Exception ex)
            {
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                             "      <strong>พบข้อผิดพลาด..!</strong> " + ex.Message + " " +
                             "</div>";
                return;
            }
        }

        protected void btnSaveNewData_click(object sender, EventArgs e)
        {
            try
            {
                Conn = new SqlConnection();
                Conn = dbConn.OpenConn();
                transac = Conn.BeginTransaction();

                string strGradeID = Request.Form["txtGradeID"];
                string strGradeDesc = Request.Form["txtGradeDesc"];
                string strGradeDetail = Request.Form["txtGradeDetail"];

                if (strGradeID != "" && strGradeDesc != "")
                {
                    ssql = "insert into adGrade (GradeID, GradeDesc, GradeDetail) " +
                           "values    (@GradeID, @GradeDesc, @GradeDetail)  ";

                    Comm = new SqlCommand();
                    Comm.CommandText = ssql;
                    Comm.CommandType = CommandType.Text;
                    Comm.Connection = Conn;
                    Comm.Transaction = transac;
                    Comm.Parameters.Add("@GradeID", SqlDbType.NVarChar).Value = strGradeID;
                    Comm.Parameters.Add("@GradeDesc", SqlDbType.NVarChar).Value = strGradeDesc;
                    Comm.Parameters.Add("@GradeDetail", SqlDbType.NVarChar).Value = strGradeDetail;

                    Comm.ExecuteNonQuery();

                }
                else
                {
                    strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                               "      <strong>Warning..!</strong> Details is not complete please check.. " +
                               "</div>";
                    return;
                }

                transac.Commit();
                Conn.Close();

                GetInitialData();

            }
            catch (Exception ex)
            {
                transac.Rollback();
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                             "      <strong>พบข้อผิดพลาด..!</strong> " + ex.Message + " " +
                             "</div>";
                return;
            }
        }

        protected void btnUpdateData_click(object sender, EventArgs e)
        {
            try
            {
                Conn = new SqlConnection();
                Conn = dbConn.OpenConn();
                transac = Conn.BeginTransaction();

                string strArchitecID = Request.Form["txtArchitectIDEdit"];
                string strFirstName = Request.Form["txtFirstNameEdit"];
                string strLastName = Request.Form["txtLastNameEdit"];
                string strNickName = Request.Form["txtNickNameEdit"];
                string strPosition = Request.Form["txtPositionEdit"];
                string strAddress = Request.Form["txtAddressEdit"];
                string strPhone = Request.Form["txtPhoneEdit"];
                string strMobile = Request.Form["txtMobileEdit"];
                string strEmail = Request.Form["txtEmailEdit"];

                if (strArchitecID != "")
                {
                    ssql = "update adArchitecture set  ArchitecID=@ArchitecID, FirstName=@FirstName, LastName=@LastName, NickName=@NickName, " +
                           "       Position=@Position, Address=@Address, Phone=@Phone, Mobile=@Mobile, Email=@Email " +
                           "where    ArchitecID=@ArchitecID  ";

                    Comm = new SqlCommand();
                    Comm.CommandText = ssql;
                    Comm.CommandType = CommandType.Text;
                    Comm.Connection = Conn;
                    Comm.Transaction = transac;
                    Comm.Parameters.Add("@ArchitecID", SqlDbType.NVarChar).Value = strArchitecID;
                    Comm.Parameters.Add("@CompanyID", SqlDbType.NVarChar).Value = "";
                    Comm.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = strFirstName;
                    Comm.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = strLastName;
                    Comm.Parameters.Add("@NickName", SqlDbType.NVarChar).Value = strNickName;
                    Comm.Parameters.Add("@Position", SqlDbType.NVarChar).Value = strPosition;
                    Comm.Parameters.Add("@Address", SqlDbType.NVarChar).Value = strAddress;
                    Comm.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = strPhone;
                    Comm.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = strMobile;
                    Comm.Parameters.Add("@Email", SqlDbType.NVarChar).Value = strEmail;
                    Comm.ExecuteNonQuery();

                }
                else
                {
                    strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                               "      <strong>Warning..!</strong> Details is not complete please check.. " +
                               "</div>";
                    return;
                }

                transac.Commit();
                Conn.Close();

                GetInitialData();

            }
            catch (Exception ex)
            {
                transac.Rollback();
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                             "      <strong>พบข้อผิดพลาด..!</strong> " + ex.Message + " " +
                             "</div>";
                return;
            }
        }

        protected void btnDeleteData_click(object sender, EventArgs e)
        {
            try
            {
                Conn = new SqlConnection();
                Conn = dbConn.OpenConn();
                transac = Conn.BeginTransaction();

                string strArchitecID = Request.Form["txtArchitectIDDel"];

                if (strArchitecID != "")
                {
                    ssql = "delete from adArchitecture " +
                           "where    ArchitecID=@ArchitecID  ";

                    Comm = new SqlCommand();
                    Comm.CommandText = ssql;
                    Comm.CommandType = CommandType.Text;
                    Comm.Connection = Conn;
                    Comm.Transaction = transac;
                    Comm.Parameters.Add("@ArchitecID", SqlDbType.NVarChar).Value = strArchitecID;
                    Comm.ExecuteNonQuery();

                }
                else
                {
                    strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                               "      <strong>Warning..!</strong> Details is not complete please check.. " +
                               "</div>";
                    return;
                }

                transac.Commit();
                Conn.Close();

                GetInitialData();

            }
            catch (Exception ex)
            {
                transac.Rollback();
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                             "      <strong>พบข้อผิดพลาด..!</strong> " + ex.Message + " " +
                             "</div>";
                return;
            }
        }

        protected void btnExportPDF_click(object sender, EventArgs e)
        {
            try
            {
                //string strDate = DateTime.Now.ToString("yyyy-MM-dd");

                string sdate = Request.Form["datepickertrans"];
                string edate = Request.Form["datepickerend"];
                string cmonth = Convert.ToDateTime(sdate).ToString("MM");
                string cyear = Convert.ToDateTime(sdate).ToString("yyyy");

                string namemonth = "";
                string nameyear = "";

                if (cmonth == "01") { namemonth = "มกราคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "02") { namemonth = "กุมภาพันธ์"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "03") { namemonth = "มีนาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "04") { namemonth = "เมษายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "05") { namemonth = "พฤษภาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "06") { namemonth = "มิถุนายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "07") { namemonth = "กรกฏาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "08") { namemonth = "สิงหาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "09") { namemonth = "กันยายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "10") { namemonth = "ตุลาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "11") { namemonth = "พฤศจิกายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else { namemonth = "ธันวาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }

                rpt = new ReportDocument();
                rpt.Load(Server.MapPath("../reports/rptSalesOnSpec.rpt"));
                rpt.SetDatabaseLogon("sa", "AmpelCloud@2020", "203.154.45.40", "db_salespec");
                rpt.SetParameterValue("@sdate", sdate);
                rpt.SetParameterValue("@edate", edate);
                rpt.SetParameterValue("namemonth", namemonth);
                rpt.SetParameterValue("nameyear", nameyear);

                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "SalesOnSpec-" + sdate + "-" + edate);
            }
            catch (Exception ex)
            {
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                            "      <strong>Error ExportExcel..!</strong> " + ex.Message + " " +
                            "</div>";
                return;
            }
        }

        protected void btnExportExcel_click(object sender, EventArgs e)
        {
            try
            {
                Conn = new SqlConnection();
                Conn = dbConn.OpenConn();

                string sdate = Request.Form["datepickertrans"];
                string edate = Request.Form["datepickerend"];
                //ssql = "exec spSaleOnSpecFinal_rpt " + sdate + ", " + edate + " ";

                Comm = new SqlCommand("spSaleOnSpecFinal_excel", Conn);
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.AddWithValue("@sdate", sdate);
                Comm.Parameters.AddWithValue("@edate", edate);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = Comm;
                dt = new DataTable();
                da.Fill(dt);

                //dt = dbConn.GetDataTable(ssql);

                GridView GridviewExport = new GridView();

                if (dt.Rows.Count != 0)
                {

                    GridviewExport.DataSource = dt;
                    GridviewExport.DataBind();

                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=SalesOnSpec"+sdate+"-"+edate+".xls");
                    Response.ContentType = "application/ms-excel";
                    Response.ContentEncoding = System.Text.Encoding.Unicode;
                    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

                    GridviewExport.RenderControl(hw);
                    string style = @"<style> td { mso-number-format:\@;} </style>";
                    Response.Write(style);
                    Response.Write(sw.ToString());
                    Response.End();

                }
            }
            catch (Exception ex)
            {
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                            "      <strong>Error ExportExcel..!</strong> " + ex.Message + " " +
                            "</div>";
                return;
            }
        }

        protected void btnExportPDF2_click(object sender, EventArgs e)
        {
            try
            {
                //string strDate = DateTime.Now.ToString("yyyy-MM-dd");

                string sdate = Request.Form["datepickertrans"];
                string edate = Request.Form["datepickerend"];
                string cmonth = Convert.ToDateTime(sdate).ToString("MM");
                string cyear = Convert.ToDateTime(sdate).ToString("yyyy");

                string namemonth = "";
                string nameyear = "";

                if (cmonth == "01") { namemonth = "มกราคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "02") { namemonth = "กุมภาพันธ์"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "03") { namemonth = "มีนาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "04") { namemonth = "เมษายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "05") { namemonth = "พฤษภาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "06") { namemonth = "มิถุนายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "07") { namemonth = "กรกฏาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "08") { namemonth = "สิงหาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "09") { namemonth = "กันยายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "10") { namemonth = "ตุลาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else if (cmonth == "11") { namemonth = "พฤศจิกายน"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }
                else { namemonth = "ธันวาคม"; nameyear = Convert.ToString(int.Parse(cyear) + 543); }

                rpt = new ReportDocument();
                rpt.Load(Server.MapPath("../reports/rptSalesOnSpec2.rpt"));
                rpt.SetDatabaseLogon("sa", "AmpelCloud@2020", "203.154.45.40", "db_salespec");
                rpt.SetParameterValue("@sdate", sdate);
                rpt.SetParameterValue("@edate", edate);
                rpt.SetParameterValue("namemonth", namemonth);
                rpt.SetParameterValue("nameyear", nameyear);

                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "SalesOnSpecUnidentifeid-" + sdate + "-" + edate);
            }
            catch (Exception ex)
            {
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                            "      <strong>Error ExportExcel..!</strong> " + ex.Message + " " +
                            "</div>";
                return;
            }
        }

        protected void btnExportExcel2_click(object sender, EventArgs e)
        {
            try
            {
                Conn = new SqlConnection();
                Conn = dbConn.OpenConn();

                string sdate = Request.Form["datepickertrans"];
                string edate = Request.Form["datepickerend"];
                //ssql = "exec spSaleOnSpecFinal_rpt " + sdate + ", " + edate + " ";

                Comm = new SqlCommand("spSaleOnSpecFinalWithoutPort_rpt", Conn);
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.AddWithValue("@sdate", sdate);
                Comm.Parameters.AddWithValue("@edate", edate);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = Comm;
                dt = new DataTable();
                da.Fill(dt);

                //dt = dbConn.GetDataTable(ssql);

                GridView GridviewExport = new GridView();

                if (dt.Rows.Count != 0)
                {

                    GridviewExport.DataSource = dt;
                    GridviewExport.DataBind();

                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=SalesOnSpecUnidentifeid" + sdate + "-" + edate + ".xls");
                    Response.ContentType = "application/ms-excel";
                    Response.ContentEncoding = System.Text.Encoding.Unicode;
                    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

                    GridviewExport.RenderControl(hw);
                    string style = @"<style> td { mso-number-format:\@;} </style>";
                    Response.Write(style);
                    Response.Write(sw.ToString());
                    Response.End();

                }
            }
            catch (Exception ex)
            {
                strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                            "      <strong>Error ExportExcel..!</strong> " + ex.Message + " " +
                            "</div>";
                return;
            }
        }
    }
}