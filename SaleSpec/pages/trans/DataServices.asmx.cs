﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.IO;

namespace SaleSpec.Class
{
    /// <summary>
    /// Summary description for DataServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DataServices : System.Web.Services.WebService
    {
        dbConnection conn = new dbConnection();

        [WebMethod]
        public void GetDataCompany()
        {
            List<GetCompany> companies = new List<GetCompany>();

            SqlCommand comm = new SqlCommand("spGetCompany", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetCompany company = new GetCompany();
                company.CompanyID = rdr["CompanyID"].ToString();
                company.CompanyNameTH = rdr["CompanyNameTH"].ToString();
                company.CompanyNameEN = rdr["CompanyNameEN"].ToString();
                companies.Add(company);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(companies));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetDataArchitect(string CompanyID)
        {
            List<GetArchitects> architects = new List<GetArchitects>();

            SqlCommand comm = new SqlCommand("spGetArchitect", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter()
            {
                ParameterName = "@CompanyID",
                Value = CompanyID
            };
            //comm.Parameters.Add(new SqlParameter("@username", "username"));
            //comm.Parameters.Add(new SqlParameter("@password", "password"));
            comm.Parameters.Add(param);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetArchitects architect = new GetArchitects();
                architect.ArchitecID = rdr["ArchitecID"].ToString();
                architect.FullName = rdr["FullName"].ToString();
                architects.Add(architect);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(architects));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetPositions()
        {
            List<GetDataPosition> positions = new List<GetDataPosition>();

            SqlCommand comm = new SqlCommand("spGetPositions", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataPosition position = new GetDataPosition();
                position.PositionID = rdr["PositionID"].ToString();
                position.PositionNameTH = rdr["PositionNameTH"].ToString();
                position.PositionNameEN = rdr["PositionNameEN"].ToString();
                positions.Add(position);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(positions));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetStepSpec()
        {
            List<GetDataStepSpec> stepspecs = new List<GetDataStepSpec>();

            SqlCommand comm = new SqlCommand("spGetStep", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataStepSpec stepspec = new GetDataStepSpec();
                stepspec.StepID = rdr["StepID"].ToString();
                stepspec.StepNameTh = rdr["StepNameTh"].ToString();
                stepspec.StepNameEn = rdr["StepNameEn"].ToString();
                stepspecs.Add(stepspec);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(stepspecs));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetProductType()
        {
            List<GetDataProductType> producttypes = new List<GetDataProductType>();
            SqlCommand comm = new SqlCommand("spGetProductType", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataProductType producttype = new GetDataProductType();
                producttype.ProdTypeID = rdr["ProdTypeID"].ToString();
                producttype.ProdTypeNameTH = rdr["ProdTypeNameTH"].ToString();
                producttype.ProdTypeNameEN = rdr["ProdTypeNameEN"].ToString();
                producttypes.Add(producttype);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(producttypes));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetProducts(string ProdTypeID)
        {
            List<GetDataProducts> products = new List<GetDataProducts>();
            SqlCommand comm = new SqlCommand("spGetProducts", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "@ProdTypeID",
                Value = ProdTypeID
            };
            comm.Parameters.Add(param);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataProducts product = new GetDataProducts();
                product.ProdID = rdr["ProdID"].ToString();
                product.ProdTypeID = rdr["ProdTypeID"].ToString();
                product.ProdNameTH = rdr["ProdNameTH"].ToString();
                product.ProdNameEN = rdr["ProdNameEN"].ToString();
                products.Add(product);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(products));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetProfile()
        {
            List<GetDataProfile> profiles = new List<GetDataProfile>();
            
                SqlCommand comm = new SqlCommand("spGetProfile", conn.OpenConn());
                comm.CommandType = CommandType.StoredProcedure;              

                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GetDataProfile profile = new GetDataProfile();
                    profile.ProfID = rdr["ProfID"].ToString();
                    profile.ProfNameTH = rdr["ProfNameTH"].ToString();
                    profile.ProfNameEN = rdr["ProfNameEN"].ToString();
                    profiles.Add(profile);
                }
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(profiles));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetStatus()
        {
            List<GetDataStatus> statuses = new List<GetDataStatus>();            
                SqlCommand comm = new SqlCommand("spGetStatus", conn.OpenConn());
                comm.CommandType = CommandType.StoredProcedure;
               
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GetDataStatus status = new GetDataStatus();
                    status.StatusID = rdr["StatusID"].ToString();
                    status.StatusNameTh = rdr["StatusNameTh"].ToString();
                    status.StatusNameEn = rdr["StatusNameEn"].ToString();
                    statuses.Add(status);
                }
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(statuses));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetStatusWithProject(string ProjectID)
        {
            List<GetDataStatus> statuses = new List<GetDataStatus>();
            SqlCommand comm = new SqlCommand("spGetStatusWithProject", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter() { ParameterName = "@ProjectID", Value = ProjectID };
            comm.Parameters.Add(param1);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataStatus status = new GetDataStatus();
                status.StatusID = rdr["StatusID"].ToString();
                statuses.Add(status);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(statuses));
            conn.CloseConn();
        }

        //GetDataStatusConfirm
        [WebMethod]
        public void GetStatusConfirm()
        {
            List<GetDataStatusConfirm> confirmed = new List<GetDataStatusConfirm>();
            SqlCommand comm = new SqlCommand("spGetStatusConfirm", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataStatusConfirm confirm = new GetDataStatusConfirm();
                confirm.StatusConID = rdr["StatusConID"].ToString();
                confirm.ConDesc = rdr["ConDesc"].ToString();
                confirm.ConDesc2 = rdr["ConDesc2"].ToString();
                confirmed.Add(confirm);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(confirmed));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetTransEntry()
        {
            List<GetDataTransEntry> transactions = new List<GetDataTransEntry>();
            SqlCommand comm = new SqlCommand("spGetTransEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataTransEntry transaction = new GetDataTransEntry();
                transaction.TransID = rdr["TransID"].ToString();
                transaction.TransNameTH = rdr["TransNameTH"].ToString();
                transaction.TransNameEN = rdr["TransNameEN"].ToString();
                transactions.Add(transaction);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(transactions));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetInsertCompanies(string CompanyName, string CompanyName2, string Address, string ProvinceID, string ContactName,
                                        string Phone, string Mobile, string Email, string StatusConID, string Port)
        {
            List<GetInsertCompany> companies = new List<GetInsertCompany>();
            SqlCommand comm = new SqlCommand("spInsertCompany", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@CompanyName", CompanyName);
            comm.Parameters.AddWithValue("@CompanyName2", CompanyName2);
            comm.Parameters.AddWithValue("@Address", Address);
            comm.Parameters.AddWithValue("@ProvinceID", ProvinceID);
            comm.Parameters.AddWithValue("@ContactName", ContactName);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Mobile", Mobile);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@StatusConID", StatusConID);
            comm.Parameters.AddWithValue("@Port", Port);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetDataCountArchitect()
        {
            List<GetCountArchitect> countarchitects = new List<GetCountArchitect>();
            SqlCommand comm = new SqlCommand("spGetCountArchitect", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetCountArchitect countarchitect = new GetCountArchitect();
                countarchitect.ArchitecID = rdr["ArchitecID"].ToString();
                countarchitects.Add(countarchitect);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(countarchitects));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetCountProject()
        {
            List<GetDataCountProject> countprojects = new List<GetDataCountProject>();
            SqlCommand comm = new SqlCommand("spGetCountProject", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataCountProject countproject = new GetDataCountProject();
                countproject.ProjectID = rdr["ProjectID"].ToString();
                countprojects.Add(countproject);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(countprojects));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetDataInsertArchitect(string ArchitecID, string CompanyID, string Name, string FirstName, string LastName,
                                            string NickName, string Position, string Address, string Phone, string Mobile, string Email, string StatusConID)
        {
            List<GetInsertArchitect> companies = new List<GetInsertArchitect>();            
            SqlCommand comm = new SqlCommand("spInsertArchitect", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@CompanyID", CompanyID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@FirstName", FirstName);
            comm.Parameters.AddWithValue("@LastName", LastName);
            comm.Parameters.AddWithValue("@NickName", NickName);
            comm.Parameters.AddWithValue("@Position", Position);
            comm.Parameters.AddWithValue("@Address", Address);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Mobile", Mobile);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@StatusConID", StatusConID);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetInsertWeeklyReport(string WeekDate, string WeekTime, string CompanyID, string CompanyName, string ArchitecID, string Name, string TransID, string TransNameEN,
                                          string ProjectID, string ProjectName, string Location, string TurnKey, string StepID, string StepNameEn, string BiddingName1, string OwnerName1, string BiddingName2, string OwnerName2,
                                          string BiddingName3, string OwnerName3, string AwardMC, string ContactMC, string AwardRF, string ContactRF, string ProdTypeID, string ProdTypeNameEN, string ProdID, string ProdNameEN,
                                          string ProfID, string ProfNameEN, string Quantity, string DeliveryDate, string NextVisitDate, string StatusID, string StatusNameEn, string Remark,
                                          string UserID, string EmpCode, string CreatedBy, string CreatedDate)
        {
            SqlCommand comm = new SqlCommand("spInsertWeeklyReport", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@WeekDate", WeekDate);
            comm.Parameters.AddWithValue("@WeekTime", WeekTime);
            comm.Parameters.AddWithValue("@CompanyID", CompanyID);
            comm.Parameters.AddWithValue("@CompanyName", CompanyName);
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@TransID", TransID);
            comm.Parameters.AddWithValue("@TransNameEN", TransNameEN);
            comm.Parameters.AddWithValue("@ProjectID", ProjectID);
            comm.Parameters.AddWithValue("@ProjectName", ProjectName);
            comm.Parameters.AddWithValue("@Location", Location);
            comm.Parameters.AddWithValue("@TurnKey", TurnKey);
            comm.Parameters.AddWithValue("@StepID", StepID);
            comm.Parameters.AddWithValue("@StepNameEn", StepNameEn);
            comm.Parameters.AddWithValue("@BiddingName1", BiddingName1);
            comm.Parameters.AddWithValue("@OwnerName1", OwnerName1);
            comm.Parameters.AddWithValue("@BiddingName2", BiddingName2);
            comm.Parameters.AddWithValue("@OwnerName2", OwnerName2);
            comm.Parameters.AddWithValue("@BiddingName3", BiddingName3);
            comm.Parameters.AddWithValue("@OwnerName3", OwnerName3);
            comm.Parameters.AddWithValue("@AwardMC", AwardMC);
            comm.Parameters.AddWithValue("@ContactMC", ContactMC);
            comm.Parameters.AddWithValue("@AwardRF", AwardRF);
            comm.Parameters.AddWithValue("@ContactRF", ContactRF);
            comm.Parameters.AddWithValue("@ProdTypeID", ProdTypeID);
            comm.Parameters.AddWithValue("@ProdTypeNameEN", ProdTypeNameEN);
            comm.Parameters.AddWithValue("@ProdID", ProdID);
            comm.Parameters.AddWithValue("@ProdNameEN", ProdNameEN);
            comm.Parameters.AddWithValue("@ProfID", ProfID);
            comm.Parameters.AddWithValue("@ProfNameEN", ProfNameEN);
            comm.Parameters.AddWithValue("@Quantity", Quantity);
            comm.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
            comm.Parameters.AddWithValue("@NextVisitDate", NextVisitDate);
            comm.Parameters.AddWithValue("@StatusID", StatusID);
            comm.Parameters.AddWithValue("@StatusNameEn", StatusNameEn);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@EmpCode", EmpCode);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetInsertWeeklyReportWithExtended(string WeekDate, string WeekTime, string CompanyID, string CompanyName, string ArchitecID, string Name, string TransID, string TransNameEN,
                                          string ProjectID, string ProjectName, string Location, string StepID, string StepNameEn, string BiddingName1, string OwnerName1, string BiddingName2, string OwnerName2,
                                          string BiddingName3, string OwnerName3, string AwardMC, string ContactMC, string AwardRF, string ContactRF, string ProdTypeID, string ProdTypeNameEN, string ProdID, string ProdNameEN,
                                          string ProfID, string ProfNameEN, string Quantity, string DeliveryDate, string NextVisitDate, string StatusID, string StatusNameEn, string Remark,
                                          string UserID, string EmpCode, string CreatedBy, string CreatedDate)
        {
            SqlCommand comm = new SqlCommand("spInsertWeeklyReportWithExtended", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@WeekDate", WeekDate);
            comm.Parameters.AddWithValue("@WeekTime", WeekTime);
            comm.Parameters.AddWithValue("@CompanyID", CompanyID);
            comm.Parameters.AddWithValue("@CompanyName", CompanyName);
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@TransID", TransID);
            comm.Parameters.AddWithValue("@TransNameEN", TransNameEN);
            comm.Parameters.AddWithValue("@ProjectID", ProjectID);
            comm.Parameters.AddWithValue("@ProjectName", ProjectName);
            comm.Parameters.AddWithValue("@Location", Location);
            comm.Parameters.AddWithValue("@StepID", StepID);
            comm.Parameters.AddWithValue("@StepNameEn", StepNameEn);
            comm.Parameters.AddWithValue("@BiddingName1", BiddingName1);
            comm.Parameters.AddWithValue("@OwnerName1", OwnerName1);
            comm.Parameters.AddWithValue("@BiddingName2", BiddingName2);
            comm.Parameters.AddWithValue("@OwnerName2", OwnerName2);
            comm.Parameters.AddWithValue("@BiddingName3", BiddingName3);
            comm.Parameters.AddWithValue("@OwnerName3", OwnerName3);
            comm.Parameters.AddWithValue("@AwardMC", AwardMC);
            comm.Parameters.AddWithValue("@ContactMC", ContactMC);
            comm.Parameters.AddWithValue("@AwardRF", AwardRF);
            comm.Parameters.AddWithValue("@ContactRF", ContactRF);
            comm.Parameters.AddWithValue("@ProdTypeID", ProdTypeID);
            comm.Parameters.AddWithValue("@ProdTypeNameEN", ProdTypeNameEN);
            comm.Parameters.AddWithValue("@ProdID", ProdID);
            comm.Parameters.AddWithValue("@ProdNameEN", ProdNameEN);
            comm.Parameters.AddWithValue("@ProfID", ProfID);
            comm.Parameters.AddWithValue("@ProfNameEN", ProfNameEN);
            comm.Parameters.AddWithValue("@Quantity", Quantity);
            comm.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
            comm.Parameters.AddWithValue("@NextVisitDate", NextVisitDate);
            comm.Parameters.AddWithValue("@StatusID", StatusID);
            comm.Parameters.AddWithValue("@StatusNameEn", StatusNameEn);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@EmpCode", EmpCode);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        // ***************************************//
        // ***************************************//
        // GetData Services for update project
        [WebMethod]
        public void GetDataProjectWithPort(string CompanyID, string ArchitecID, string TypeID)
        {
            List<GetProjectWithPort> projects = new List<GetProjectWithPort>();
            SqlCommand comm = new SqlCommand("spGetProjectWithPort", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter() { ParameterName = "@CompanyID", Value = CompanyID };
            SqlParameter param2 = new SqlParameter() { ParameterName = "@ArchitecID", Value = ArchitecID };
            SqlParameter param3 = new SqlParameter() { ParameterName = "@TypeID", Value = TypeID };

            comm.Parameters.Add(param1);
            comm.Parameters.Add(param2);
            comm.Parameters.Add(param3);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetProjectWithPort project = new GetProjectWithPort();
                project.ProjectID = rdr["ProjectID"].ToString();
                project.ProjectName = rdr["ProjectName"].ToString();
                projects.Add(project);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(projects));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetStepUpdate()
        {
            List<GetDataStepUpdate> stepupdated = new List<GetDataStepUpdate>();
            SqlCommand comm = new SqlCommand("spGetStepUpdate", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataStepUpdate stepupdate = new GetDataStepUpdate();
                stepupdate.StepID = rdr["StepID"].ToString();
                stepupdate.StepNameEn = rdr["StepNameEn"].ToString();
                stepupdated.Add(stepupdate);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(stepupdated));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetProductTypeUpdate()
        {
            List<GetDataProductTypeUpdate> productupdated = new List<GetDataProductTypeUpdate>();
            SqlCommand comm = new SqlCommand("spGetProductTypeUpdate", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataProductTypeUpdate productupdate = new GetDataProductTypeUpdate();
                productupdate.ProdTypeID = rdr["ProdTypeID"].ToString();
                productupdate.ProdTypeNameEN = rdr["ProdTypeNameEN"].ToString();
                productupdated.Add(productupdate);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(productupdated));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetProductsUpdate(string ProdTypeID)
        {
            List<GetDataProductsUpdate> products = new List<GetDataProductsUpdate>();
            SqlCommand comm = new SqlCommand("spGetProductsUpdate", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "@ProdTypeID",
                Value = ProdTypeID
            };
            comm.Parameters.Add(param);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataProductsUpdate product = new GetDataProductsUpdate();
                product.ProdID = rdr["ProdID"].ToString();
                product.ProdTypeID = rdr["ProdTypeID"].ToString();
                product.ProdNameTH = rdr["ProdNameTH"].ToString();
                product.ProdNameEN = rdr["ProdNameEN"].ToString();
                products.Add(product);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(products));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetProfileUpdate()
        {
            List<GetDataProfileUpdate> profiles = new List<GetDataProfileUpdate>();
            SqlCommand comm = new SqlCommand("spGetProfileUpdate", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataProfileUpdate profile = new GetDataProfileUpdate();
                profile.ProfID = rdr["ProfID"].ToString();
                profile.ProfNameTH = rdr["ProfNameTH"].ToString();
                profile.ProfNameEN = rdr["ProfNameEN"].ToString();
                profiles.Add(profile);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(profiles));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetStatusUpdate()
        {
            List<GetDataStatusUpdate> statuses = new List<GetDataStatusUpdate>();
            SqlCommand comm = new SqlCommand("spGetStatusUpdate", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataStatusUpdate status = new GetDataStatusUpdate();
                status.StatusID = rdr["StatusID"].ToString();
                status.StatusNameTh = rdr["StatusNameTh"].ToString();
                status.StatusNameEn = rdr["StatusNameEn"].ToString();
                statuses.Add(status);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(statuses));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetProjectLastUdate(string ProjectID)
        {
            List<GetDataProjectLastUdate> projects = new List<GetDataProjectLastUdate>();            
                SqlCommand comm = new SqlCommand("spGetProjectLastUdate", conn.OpenConn());
                comm.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@ProjectID",
                    Value = ProjectID
                };
                comm.Parameters.Add(param);
               
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GetDataProjectLastUdate project = new GetDataProjectLastUdate();
                    project.ProjectID = rdr["ProjectID"].ToString();
                    project.ProjectYear = rdr["ProjectYear"].ToString();
                    project.ProjectMonth = rdr["ProjectMonth"].ToString();
                    project.ProjectName = rdr["ProjectName"].ToString();
                    project.CompanyID = rdr["CompanyID"].ToString();
                    project.CompanyName = rdr["CompanyName"].ToString();
                    project.ArchitecID = rdr["ArchitecID"].ToString();
                    project.Name = rdr["Name"].ToString();
                    project.Location = rdr["Location"].ToString();
                    project.TurnKey = rdr["TurnKey"].ToString();

                    project.MainCons = rdr["MainCons"].ToString();
                    project.RefRfDf = rdr["RefRfDf"].ToString();
                    project.ProjStep = rdr["ProjStep"].ToString();
                    project.ProductType = rdr["ProductType"].ToString();
                    project.RefProfile = rdr["RefProfile"].ToString();
                    project.ProdTypeID = rdr["ProdTypeID"].ToString();
                    project.ProdTypeNameEN = rdr["ProdTypeNameEN"].ToString();
                    project.ProdID = rdr["ProdID"].ToString();
                    project.ProdNameEN = rdr["ProdNameEN"].ToString();
                    project.ProfID = rdr["ProfID"].ToString();
                    project.ProfNameEN = rdr["ProfNameEN"].ToString();
                    project.StatusID = rdr["StatusID"].ToString();
                    project.StatusNameEn = rdr["StatusNameEn"].ToString();
                    project.Quantity = rdr["Quantity"].ToString();
                    project.RefType = rdr["RefType"].ToString();
                    project.DeliveryDate = rdr["DeliveryDate"].ToString();
                    project.Drawing = rdr["Drawing"].ToString();
                    project.TypeID = rdr["TypeID"].ToString();
                    project.SaleSpec = rdr["SaleSpec"].ToString();
                    project.StatusConID = rdr["StatusConID"].ToString();
                    project.LastUpdate = rdr["LastUpdate"].ToString();

                    project.BiddingName1 = rdr["BiddingName1"].ToString();
                    project.OwnerName1 = rdr["OwnerName1"].ToString();
                    project.BiddingName2 = rdr["BiddingName2"].ToString();
                    project.OwnerName2 = rdr["OwnerName2"].ToString();
                    project.BiddingName3 = rdr["BiddingName3"].ToString();
                    project.OwnerName3 = rdr["OwnerName3"].ToString();
                    project.AwardMC = rdr["AwardMC"].ToString();
                    project.ContactMC = rdr["ContactMC"].ToString();
                    project.AwardRF = rdr["AwardRF"].ToString();
                    project.ContactRF = rdr["ContactRF"].ToString();
                    projects.Add(project);
                }            
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(projects));
            conn.CloseConn();
        }

        //get attached
        [WebMethod]
        public void GetDocAttached(string ProjectID)
        {
            List<GetDataDocAttached> projects = new List<GetDataDocAttached>();
            SqlCommand comm = new SqlCommand("spGetDocAttached", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "@ProjectID",
                Value = ProjectID
            };
            comm.Parameters.Add(param);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataDocAttached project = new GetDataDocAttached();
                project.id = rdr["id"].ToString();
                project.ProjectID = rdr["ProjectID"].ToString();
                project.ProjectName = rdr["ProjectName"].ToString();
                project.Description = rdr["Description"].ToString();
                project.FileName = rdr["FileName"].ToString();
                project.Remark = rdr["Remark"].ToString();
                project.UserID = rdr["UserID"].ToString();
                project.EmpCode = rdr["EmpCode"].ToString();
                project.CreatedBy = rdr["CreatedBy"].ToString();
                project.CreatedDate = rdr["CreatedDate"].ToString();
                projects.Add(project);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(projects));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetInsertWeeklyReportUpdate(string WeekDate, string WeekTime, string CompanyID, string CompanyName, string ArchitecID, string Name,
                                          string TransID, string TransNameEN, string ProjectID, string ProjectName, string Location, string TurnKey,  string StepID,
                                          string StepNameEn, string BiddingName1, string OwnerName1, string BiddingName2, string OwnerName2,
                                          string BiddingName3, string OwnerName3, string AwardMC, string ContactMC, string AwardRF, string ContactRF,
                                          string ProdTypeID, string ProdTypeNameEN, string ProdID, string ProdNameEN, string ProfID, string ProfNameEN,
                                          string Quantity, string DeliveryDate, string NextVisitDate, string StatusID, string StatusNameEn, 
                                          string Remark, string UserID, string EmpCode, string CreatedBy, string CreatedDate)
          
        {
           
                SqlCommand comm = new SqlCommand("spInsertWeeklyReportUpdate", conn.OpenConn());
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@WeekDate", WeekDate);
                comm.Parameters.AddWithValue("@WeekTime", WeekTime);
                comm.Parameters.AddWithValue("@CompanyID", CompanyID);
                comm.Parameters.AddWithValue("@CompanyName", CompanyName);
                comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
                comm.Parameters.AddWithValue("@Name", Name);
                comm.Parameters.AddWithValue("@TransID", TransID);
                comm.Parameters.AddWithValue("@TransNameEN", TransNameEN);
                comm.Parameters.AddWithValue("@ProjectID", ProjectID);
                comm.Parameters.AddWithValue("@ProjectName", ProjectName);
                comm.Parameters.AddWithValue("@Location", Location);
                comm.Parameters.AddWithValue("@TurnKey", TurnKey);
                comm.Parameters.AddWithValue("@StepID", StepID);
                comm.Parameters.AddWithValue("@StepNameEn", StepNameEn);
                comm.Parameters.AddWithValue("@BiddingName1", BiddingName1);
                comm.Parameters.AddWithValue("@OwnerName1", OwnerName1);
                comm.Parameters.AddWithValue("@BiddingName2", BiddingName2);
                comm.Parameters.AddWithValue("@OwnerName2", OwnerName2);
                comm.Parameters.AddWithValue("@BiddingName3", BiddingName3);
                comm.Parameters.AddWithValue("@OwnerName3", OwnerName3);
                comm.Parameters.AddWithValue("@AwardMC", AwardMC);
                comm.Parameters.AddWithValue("@ContactMC", ContactMC);
                comm.Parameters.AddWithValue("@AwardRF", AwardRF);
                comm.Parameters.AddWithValue("@ContactRF", ContactRF);
                comm.Parameters.AddWithValue("@ProdTypeID", ProdTypeID);
                comm.Parameters.AddWithValue("@ProdTypeNameEN", ProdTypeNameEN);
                comm.Parameters.AddWithValue("@ProdID", ProdID);
                comm.Parameters.AddWithValue("@ProdNameEN", ProdNameEN);
                comm.Parameters.AddWithValue("@ProfID", ProfID);
                comm.Parameters.AddWithValue("@ProfNameEN", ProfNameEN);
                comm.Parameters.AddWithValue("@Quantity", Quantity);
                comm.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
                comm.Parameters.AddWithValue("@NextVisitDate", NextVisitDate);
                comm.Parameters.AddWithValue("@StatusID", StatusID);
                comm.Parameters.AddWithValue("@StatusNameEn", StatusNameEn);

                comm.Parameters.AddWithValue("@Remark", Remark);
                comm.Parameters.AddWithValue("@UserID", UserID);
                comm.Parameters.AddWithValue("@EmpCode", EmpCode);
                comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                comm.ExecuteNonQuery();
                conn.CloseConn();           
        }


        [WebMethod]
        public void GetInsertWeeklyReportUpdateOther(string WeekDate, string WeekTime, string CompanyID, string CompanyName, string ArchitecID, string Name, string TransID,
                        string TransNameEN, string ProjectID, string ProjectName, string Location, string TurnKey, string StepID, string StepNameEn, string StatusID, string StatusNameEn,
                        string NewArchitect, string HaveFiles, string FileName, string Remark, string UserID, string EmpCode, string CreatedBy, string CreatedDate)

        {
            SqlCommand comm = new SqlCommand("spInsertWeeklyReportUpdateOther", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@WeekDate", WeekDate);
            comm.Parameters.AddWithValue("@WeekTime", WeekTime);
            comm.Parameters.AddWithValue("@CompanyID", CompanyID);
            comm.Parameters.AddWithValue("@CompanyName", CompanyName);
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@TransID", TransID);
            comm.Parameters.AddWithValue("@TransNameEN", TransNameEN);
            comm.Parameters.AddWithValue("@ProjectID", ProjectID);
            comm.Parameters.AddWithValue("@ProjectName", ProjectName);
            comm.Parameters.AddWithValue("@Location", Location);
            comm.Parameters.AddWithValue("@TurnKey", TurnKey);

            comm.Parameters.AddWithValue("@StepID", StepID);
            comm.Parameters.AddWithValue("@StepNameEn", StepNameEn);
            comm.Parameters.AddWithValue("@StatusID", StatusID);
            comm.Parameters.AddWithValue("@StatusNameEn", StatusNameEn);
            comm.Parameters.AddWithValue("@NewArchitect", NewArchitect);
            comm.Parameters.AddWithValue("@HaveFiles", HaveFiles);
            comm.Parameters.AddWithValue("@FileName", FileName);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@EmpCode", EmpCode);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetInsertWeeklyReportIntakeUpdate(string CompanyID, string CompanyName, string ArchitecID, string Name,
                                                        string ProjectID, string ProjectName, string StepID, string StatusID, string StatusNameEn,
                                                        string UserID, string EmpCode, string CreatedBy, string CreatedDate)
        {
            SqlCommand comm = new SqlCommand("spInsertWeeklyReportIntakeUpdate", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@CompanyID", CompanyID);
            comm.Parameters.AddWithValue("@CompanyName", CompanyName);
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@ProjectID", ProjectID);
            comm.Parameters.AddWithValue("@ProjectName", ProjectName);
            comm.Parameters.AddWithValue("@StepID", StepID);
            comm.Parameters.AddWithValue("@StatusID", StatusID);
            comm.Parameters.AddWithValue("@StatusNameEn", StatusNameEn);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@EmpCode", EmpCode);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetInsertWeeklyReportWithExtendedUpdate(string WeekDate, string WeekTime, string CompanyID, string CompanyName, string ArchitecID, string Name, string TransID, string TransNameEN,
                                          string ProjectID, string ProjectName, string Location, string StepID, string StepNameEn, string BiddingName1, string OwnerName1, string BiddingName2, string OwnerName2,
                                          string BiddingName3, string OwnerName3, string AwardMC, string ContactMC, string AwardRF, string ContactRF, string ProdTypeID, string ProdTypeNameEN, string ProdID, string ProdNameEN,
                                          string ProfID, string ProfNameEN, string Quantity, string DeliveryDate, string NextVisitDate, string StatusID, string StatusNameEn, string Remark,
                                          string UserID, string EmpCode, string CreatedBy, string CreatedDate)
        {

            SqlCommand comm = new SqlCommand("spInsertWeeklyReportWithExtendedUpdate", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@WeekDate", WeekDate);
            comm.Parameters.AddWithValue("@WeekTime", WeekTime);
            comm.Parameters.AddWithValue("@CompanyID", CompanyID);
            comm.Parameters.AddWithValue("@CompanyName", CompanyName);
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@TransID", TransID);
            comm.Parameters.AddWithValue("@TransNameEN", TransNameEN);
            comm.Parameters.AddWithValue("@ProjectID", ProjectID);
            comm.Parameters.AddWithValue("@ProjectName", ProjectName);
            comm.Parameters.AddWithValue("@Location", Location);
            comm.Parameters.AddWithValue("@StepID", StepID);
            comm.Parameters.AddWithValue("@StepNameEn", StepNameEn);
            comm.Parameters.AddWithValue("@BiddingName1", BiddingName1);
            comm.Parameters.AddWithValue("@OwnerName1", OwnerName1);
            comm.Parameters.AddWithValue("@BiddingName2", BiddingName2);
            comm.Parameters.AddWithValue("@OwnerName2", OwnerName2);
            comm.Parameters.AddWithValue("@BiddingName3", BiddingName3);
            comm.Parameters.AddWithValue("@OwnerName3", OwnerName3);
            comm.Parameters.AddWithValue("@AwardMC", AwardMC);
            comm.Parameters.AddWithValue("@ContactMC", ContactMC);
            comm.Parameters.AddWithValue("@AwardRF", AwardRF);
            comm.Parameters.AddWithValue("@ContactRF", ContactRF);
            comm.Parameters.AddWithValue("@ProdTypeID", ProdTypeID);
            comm.Parameters.AddWithValue("@ProdTypeNameEN", ProdTypeNameEN);
            comm.Parameters.AddWithValue("@ProdID", ProdID);
            comm.Parameters.AddWithValue("@ProdNameEN", ProdNameEN);
            comm.Parameters.AddWithValue("@ProfID", ProfID);
            comm.Parameters.AddWithValue("@ProfNameEN", ProfNameEN);
            comm.Parameters.AddWithValue("@Quantity", Quantity);
            comm.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
            comm.Parameters.AddWithValue("@NextVisitDate", NextVisitDate);
            comm.Parameters.AddWithValue("@StatusID", StatusID);
            comm.Parameters.AddWithValue("@StatusNameEn", StatusNameEn);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@EmpCode", EmpCode);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetInsertWeeklyReportNewArchitect(string WeekDate, string WeekTime, string CompanyID, string CompanyName, string ArchitecID, string Name,
                                         string TransID, string TransNameEN, string ProjectID, string ProjectName, string Location, string StepID,
                                         string StepNameEn, string BiddingName1, string OwnerName1, string BiddingName2, string OwnerName2,
                                         string BiddingName3, string OwnerName3, string AwardMC, string ContactMC, string AwardRF, string ContactRF,
                                         string ProdTypeID, string ProdTypeNameEN, string ProdID, string ProdNameEN, string ProfID, string ProfNameEN,
                                         string Quantity, string DeliveryDate, string NextVisitDate, string StatusID, string StatusNameEn, string NewArchitect,
                                         string HaveFiles, string FileName, string Remark, string UserID, string EmpCode, string CreatedBy, string CreatedDate)
        {

            SqlCommand comm = new SqlCommand("spInsertWeeklyReportNewArchitect", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@WeekDate", WeekDate);
            comm.Parameters.AddWithValue("@WeekTime", WeekTime);
            comm.Parameters.AddWithValue("@CompanyID", CompanyID);
            comm.Parameters.AddWithValue("@CompanyName", CompanyName);
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@TransID", TransID);
            comm.Parameters.AddWithValue("@TransNameEN", TransNameEN);
            comm.Parameters.AddWithValue("@ProjectID", ProjectID);
            comm.Parameters.AddWithValue("@ProjectName", ProjectName);
            comm.Parameters.AddWithValue("@Location", Location);
            comm.Parameters.AddWithValue("@StepID", StepID);
            comm.Parameters.AddWithValue("@StepNameEn", StepNameEn);
            comm.Parameters.AddWithValue("@BiddingName1", BiddingName1);
            comm.Parameters.AddWithValue("@OwnerName1", OwnerName1);
            comm.Parameters.AddWithValue("@BiddingName2", BiddingName2);
            comm.Parameters.AddWithValue("@OwnerName2", OwnerName2);
            comm.Parameters.AddWithValue("@BiddingName3", BiddingName3);
            comm.Parameters.AddWithValue("@OwnerName3", OwnerName3);
            comm.Parameters.AddWithValue("@AwardMC", AwardMC);
            comm.Parameters.AddWithValue("@ContactMC", ContactMC);
            comm.Parameters.AddWithValue("@AwardRF", AwardRF);
            comm.Parameters.AddWithValue("@ContactRF", ContactRF);
            comm.Parameters.AddWithValue("@ProdTypeID", ProdTypeID);
            comm.Parameters.AddWithValue("@ProdTypeNameEN", ProdTypeNameEN);
            comm.Parameters.AddWithValue("@ProdID", ProdID);
            comm.Parameters.AddWithValue("@ProdNameEN", ProdNameEN);
            comm.Parameters.AddWithValue("@ProfID", ProfID);
            comm.Parameters.AddWithValue("@ProfNameEN", ProfNameEN);
            comm.Parameters.AddWithValue("@Quantity", Quantity);
            comm.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
            comm.Parameters.AddWithValue("@NextVisitDate", NextVisitDate);
            comm.Parameters.AddWithValue("@StatusID", StatusID);
            comm.Parameters.AddWithValue("@StatusNameEn", StatusNameEn);
            comm.Parameters.AddWithValue("@NewArchitect", NewArchitect);
            comm.Parameters.AddWithValue("@HaveFiles", HaveFiles);
            comm.Parameters.AddWithValue("@FileName", FileName);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@EmpCode", EmpCode);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetUploadDocAttached(string ProjectID, string ProjectName, string Description, string FileName, string Remark, string UserID, string EmpCode, string CreatedBy, string CreatedDate)
        {
            SqlCommand comm = new SqlCommand("spInsertDocAttached", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            //comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@ProjectID", ProjectID);
            comm.Parameters.AddWithValue("@ProjectName", ProjectName);
            comm.Parameters.AddWithValue("@Description", Description);
            comm.Parameters.AddWithValue("@FileName", FileName);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@EmpCode", EmpCode);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void GetSpecPerson()
        {
            List<GetDataSpecPerson> specpersonal = new List<GetDataSpecPerson>();
           
                SqlCommand comm = new SqlCommand("spGetSpecPerson", conn.OpenConn());
                comm.CommandType = CommandType.StoredProcedure;
               
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    GetDataSpecPerson specperson = new GetDataSpecPerson();
                    specperson.SpecID = rdr["SpecID"].ToString();
                    specperson.FullName = rdr["FullName"].ToString();
                    specpersonal.Add(specperson);
                }
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(specpersonal));
            conn.CloseConn();
        }


        [WebMethod]
        public void GetSpecPort(string TypeID)
        {
            List<GetDataSpecPort> specports = new List<GetDataSpecPort>();
            SqlCommand comm = new SqlCommand("spGetSpecPort", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter() { ParameterName = "@TypeID", Value = TypeID };
            comm.Parameters.Add(param);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataSpecPort specport = new GetDataSpecPort();
                specport.SpecID = rdr["SpecID"].ToString();
                specport.FullName = rdr["FullName"].ToString();
                specports.Add(specport);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(specports));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetSpecWithArchitect(string port)
        {
            List<cGetSpecWithArchitect> datas = new List<cGetSpecWithArchitect>();
            SqlCommand comm = new SqlCommand("spGetssSpecWithArchitect", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter() { ParameterName = "@port", Value = port };
            comm.Parameters.Add(param);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGetSpecWithArchitect data = new cGetSpecWithArchitect();
                data.ArchitecID = rdr["ArchitecID"].ToString();
                data.FullName = rdr["FullName"].ToString();
                datas.Add(data);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(datas));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetSpecWithCompany(string architectid)
        {
            List<cGetSpecWithCompany> datas = new List<cGetSpecWithCompany>();
            SqlCommand comm = new SqlCommand("spGetssSpecWithCompany", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;           
            comm.Parameters.AddWithValue("@architectid", architectid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGetSpecWithCompany data = new cGetSpecWithCompany();
                data.CompanyID = rdr["CompanyID"].ToString();
                data.CompanyName = rdr["CompanyName"].ToString();
                datas.Add(data);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(datas));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetCustomerType()
        {
            List<GetDataCustomerType> customers = new List<GetDataCustomerType>();
            SqlCommand comm = new SqlCommand("spGetCustomerType", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataCustomerType customer = new GetDataCustomerType();
                customer.CustTypeID = rdr["CustTypeID"].ToString();
                customer.CustTypeDesc = rdr["CustTypeDesc"].ToString();
                customers.Add(customer);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(customers));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetDataGrade()
        {
            List<GetDataGrade> grades = new List<GetDataGrade>();
            SqlCommand comm = new SqlCommand("spGetGrade", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataGrade grade = new GetDataGrade();
                grade.GradeID = rdr["GradeID"].ToString();
                grade.GradeDesc = rdr["GradeDesc"].ToString();
                grades.Add(grade);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(grades));
            conn.CloseConn();
        }



        [WebMethod]
        public void GetadGoodCustomer()
        {
            List<CGetGoodCustomer> datas = new List<CGetGoodCustomer>();
            SqlCommand comm = new SqlCommand("spGet_adGoodCustomer_detail", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                CGetGoodCustomer data = new CGetGoodCustomer();
                data.id = rdr["id"].ToString();
                data.xno = rdr["xno"].ToString();
                data.inYear = rdr["inYear"].ToString();
                data.AAList = rdr["No_AAList"].ToString();
                data.ArchitecID = rdr["ArchitecID"].ToString();
                data.CompanyID = rdr["CompanyID"].ToString();
                data.FirstName = rdr["FirstName"].ToString();
                data.LastName = rdr["LastName"].ToString();
                data.CustName = rdr["CustName"].ToString();
                data.Name = rdr["Name"].ToString();
                data.CompanyName = rdr["CompanyName"].ToString();
                data.SpecID = rdr["SpecID"].ToString();  
                data.level_desc = rdr["level_desc"].ToString();
                data.Salename = rdr["Salename"].ToString();
                data.urlview = rdr["urlview"].ToString();
                data.urldelete = rdr["urldelete"].ToString();
                datas.Add(data);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }



        [WebMethod]
        public void GetDataYearly()
        {
            List<GetDataYearlym2m> datas = new List<GetDataYearlym2m>();
            SqlCommand comm = new SqlCommand("spGetDataYearly_m2m", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                GetDataYearlym2m data = new GetDataYearlym2m();
                data.id = rdr["id"].ToString();
                data.year_desc = rdr["year_desc"].ToString();
                data.urlview = rdr["urlview"].ToString();
                datas.Add(data);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void GetmmSteptype()
        {
            List<CGetdatasteptype> datas = new List<CGetdatasteptype>();
            SqlCommand comm = new SqlCommand("spGetDataSteptype_m2m", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                CGetdatasteptype data = new CGetdatasteptype();
                data.id = rdr["id"].ToString();
                data.steptype = rdr["steptype"].ToString();
                data.urlview = rdr["urlview"].ToString();
                datas.Add(data);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }



        [WebMethod]
        public void GetadArchitecture()
        {
            List<CGetadArchitecture> datas = new List<CGetadArchitecture>();
            SqlCommand comm = new SqlCommand("spGet_adArchitecture", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                CGetadArchitecture data = new CGetadArchitecture();
                data.ArchitecID = rdr["ArchitecID"].ToString();
                data.CompanyID = rdr["CompanyID"].ToString();  
                data.FirstName = rdr["FirstName"].ToString();
                data.LastName = rdr["LastName"].ToString();
                data.Name = rdr["Name"].ToString();
                data.SpecID = rdr["SpecID"].ToString();   
                data.urlview = rdr["urlview"].ToString();
                datas.Add(data);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }




        [WebMethod]
        public void spsave_adGoodCustomer(string typeupdate, string id, string InYear ,string AACLUB, string strName , string strFirstName , string strLastName 
                                          , string strArchitecID ,string strCompanyID ,string strSpecID, string created_by ,string create_date
                                          , string update_by ,string update_date)
        {

            SqlCommand comm = new SqlCommand("spsave_adGoodCustomer", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@typeupdate", typeupdate);
            comm.Parameters.AddWithValue("@id", id);         
            comm.Parameters.AddWithValue("@InYear", InYear);
            comm.Parameters.AddWithValue("@AACLUB", AACLUB);
            comm.Parameters.AddWithValue("@strName", strName);
            comm.Parameters.AddWithValue("@strFirstName", strFirstName);
            comm.Parameters.AddWithValue("@strLastName", strLastName);
            comm.Parameters.AddWithValue("@strArchitecID", strArchitecID);
            comm.Parameters.AddWithValue("@strCompanyID", strCompanyID);
            comm.Parameters.AddWithValue("@strSpecID", strSpecID);
            comm.Parameters.AddWithValue("@created_by", created_by);
            comm.Parameters.AddWithValue("@create_date", create_date);
            comm.Parameters.AddWithValue("@update_by", update_by);
            comm.Parameters.AddWithValue("@update_date", update_date);
            comm.ExecuteNonQuery();
            conn.CloseConn();

        }



        [WebMethod]
        public void check_GoodCustomer(string ArchitecID, string inYear)
        {
            List<Ccheck_GoodCustomer> datas = new List<Ccheck_GoodCustomer>();
            SqlCommand comm = new SqlCommand("check_GoodCustomer", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@inYear", inYear);          
            conn.OpenConn();

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                Ccheck_GoodCustomer data = new Ccheck_GoodCustomer();
                data.ArchitecID = rdr["ArchitecID"].ToString();
                data.xcount = rdr["xcount"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";

            // comm.ExecuteNonQuery();
            conn.CloseConn();

        }



        [WebMethod]
        public void spsave_mmProjectcontract(string typeupdate, string DocuDate, string DocuNo, string QAmount, string net, string netcheck
                                  , string ArchitecID,string CustCode,string Name, string CustName, string GoodName, string NetRF_B
                                  , string SaleCode, string SaleName,string created_by,string create_date)
        {


            SqlCommand comm = new SqlCommand("spsave_mmProjectcontract", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@typeupdate", typeupdate);
            comm.Parameters.AddWithValue("@DocuDate", DocuDate);
            comm.Parameters.AddWithValue("@DocuNo", DocuNo);
            comm.Parameters.AddWithValue("@QAmount", QAmount);
            comm.Parameters.AddWithValue("@net", net);
            comm.Parameters.AddWithValue("@netcheck", netcheck);
            comm.Parameters.AddWithValue("@ArchitecID", ArchitecID);
            comm.Parameters.AddWithValue("@CustCode", CustCode);            
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@CustName", CustName);
            comm.Parameters.AddWithValue("@GoodName", GoodName);
            comm.Parameters.AddWithValue("@NetRF_B", NetRF_B);
            comm.Parameters.AddWithValue("@SaleCode", SaleCode);
            comm.Parameters.AddWithValue("@SaleName", SaleName);
            comm.Parameters.AddWithValue("@created_by", created_by);
            comm.Parameters.AddWithValue("@create_date", create_date);
            comm.ExecuteNonQuery();
            conn.CloseConn();

        }








        [WebMethod]
        public void spsave_mmpointmaster(string typeupdate,string id,string InYear, string steptype, string pointmin, string pointmax, string descvoucher
                                         , string remark, string create_by, string create_date,string update_by, string update_date)
        {

            SqlCommand comm = new SqlCommand("spsave_mmpointmaster", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@typeupdate", typeupdate);
            comm.Parameters.AddWithValue("@id",id);
            comm.Parameters.AddWithValue("@InYear", InYear);
            comm.Parameters.AddWithValue("@step_type", steptype);
            comm.Parameters.AddWithValue("@pointmin", pointmin);
            comm.Parameters.AddWithValue("@pointmax", pointmax);
            comm.Parameters.AddWithValue("@descvoucher", descvoucher);
            comm.Parameters.AddWithValue("@remark", remark);       
            comm.Parameters.AddWithValue("@create_by", create_by);
            comm.Parameters.AddWithValue("@create_date", create_date);
            comm.Parameters.AddWithValue("@update_by", update_by);
            comm.Parameters.AddWithValue("@update_date", update_date);
            comm.ExecuteNonQuery();
            conn.CloseConn();

        }





        [WebMethod]
        public void check_Pointmaster(string stepetype, string inYear)
        {
            List<Ccheck_GoodCustomer> datas = new List<Ccheck_GoodCustomer>();
            SqlCommand comm = new SqlCommand("check_pointmaster", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@stepetype", stepetype);
            comm.Parameters.AddWithValue("@inYear", inYear);
            conn.OpenConn();

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                Ccheck_GoodCustomer data = new Ccheck_GoodCustomer();           
                data.xcount = rdr["xcount"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";

            // comm.ExecuteNonQuery();
            conn.CloseConn();

        }





        [WebMethod]
        public void GetmmSteptypeoption()
        {
            List<CGetsteptypeoption> datas = new List<CGetsteptypeoption>();
            SqlCommand comm = new SqlCommand("spGetStepoption_m2m", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                CGetsteptypeoption data = new CGetsteptypeoption();
                data.id = rdr["id"].ToString();               
                data.steptype = rdr["step_type"].ToString();
                data.descvoucher = rdr["descvoucher"].ToString();
                data.InYear = rdr["InYear"].ToString();
                data.urlview = rdr["urlview"].ToString();
                datas.Add(data);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }



        [WebMethod]
        public void Getmmoptionmaster()
        {
            List<CGetoption> datas = new List<CGetoption>();
            SqlCommand comm = new SqlCommand("spGetmmoptionmaster", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                CGetoption data = new CGetoption();
                data.option_id = rdr["option_id"].ToString();
                data.optiondetail = rdr["optiondetail"].ToString();      
                datas.Add(data);

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }
      



    }
}
