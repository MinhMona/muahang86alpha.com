﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MB.Extensions;
using NHST.Controllers;
using NHST.Bussiness;
using System.Text;
using System.Text.RegularExpressions;
using NHST.Models;

namespace NHST.manager
{
    public partial class admin_noti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] == null)
                {
                    Response.Redirect("/trang-chu");
                }
                LoadData();
            }
        }
        public void LoadData()
        {
            string fd = Request.QueryString["fd"];
            string td = Request.QueryString["td"];
            if (!string.IsNullOrEmpty(fd))
                txtFromDate.Text = fd;
            if (!string.IsNullOrEmpty(td))
                txtToDate.Text = td;

            string username = Session["userLoginSystem"].ToString();
            var u = AccountController.GetByUsername(username);
            if (u != null)
            {
                if (u.RoleID != 1)
                {
                    int UID = u.ID;
                    ViewState["UID"] = UID;

                    #region Load Lịch sử nạp tiền
                    var notis = NotificationsController.GetAll(UID).OrderByDescending(x => x.ID).ToList();
                    if (!string.IsNullOrEmpty(fd))
                        notis = notis.Where(n => n.CreatedDate >= DateTime.ParseExact(fd, "dd/MM/yyyy HH:mm", null)).ToList();
                    if (!string.IsNullOrEmpty(td))
                        notis = notis.Where(n => n.CreatedDate <= DateTime.ParseExact(td, "dd/MM/yyyy HH:mm", null)).ToList();

                    if (notis.Count > 0)
                    {
                        List<tbl_Notification> lis = new List<tbl_Notification>();
                        if (Request.QueryString["Page"] != null)
                        {

                            Int32 Page = GetIntFromQueryString("Page");
                            if (Page == 1)
                            {
                                lis = notis.Take(15).ToList();
                            }
                            else
                            {
                                lis = notis.Skip(Page * 15).Take(15).ToList();
                            }
                        }
                        else
                        {
                            lis = notis.Take(15).ToList();
                        }
                        if (lis.Count > 0)
                        {
                            foreach (var item in lis)
                            {
                                NotificationsController.UpdateNoti(item.ID, DateTime.UtcNow.AddHours(7), username);
                            }
                        }
                        pagingall(notis);
                    }
                    #endregion
                }
                else
                {
                    Response.Redirect("/trang-chu");
                }
            }
        }
        #region Paging
        public void pagingall(List<tbl_Notification> acs)
        {
            int PageSize = 15;
            if (acs.Count > 0)
            {
                int TotalItems = acs.Count;
                if (TotalItems % PageSize == 0)
                    PageCount = TotalItems / PageSize;
                else
                    PageCount = TotalItems / PageSize + 1;

                Int32 Page = GetIntFromQueryString("Page");

                if (Page == -1) Page = 1;
                int FromRow = (Page - 1) * PageSize;
                int ToRow = Page * PageSize - 1;
                if (ToRow >= TotalItems)
                    ToRow = TotalItems - 1;

                double totalOrder = 0;
                double totalNap = 0;
                int UID = Convert.ToInt32(ViewState["UID"]);
                for (int i = FromRow; i < ToRow + 1; i++)
                {
                    string stt = "Mới";

                    var item = acs[i];
                    if (item.Status == 2)
                        stt = "Đã xem";
                    ltr.Text += "<tr>";
                    ltr.Text += "   <td>" + string.Format("{0:dd/MM/yyyy}", item.CreatedDate) + "</td>";
                    ltr.Text += "   <td>" + item.OrderID + "</td>";
                    if (item.NotifType == 1)
                    {
                        ltr.Text += "   <td><a href=\"/manager/OrderDetail.aspx?id=" + item.OrderID + "\" target=\"_blank\">" + item.Message + "</a></td>";
                    }
                    else if (item.NotifType == 2)
                    {
                        ltr.Text += "   <td><a href=\"/manager/HistorySendWallet\" target=\"_blank\">" + item.Message + "</a></td>";
                    }
                    else if (item.NotifType == 3)
                    {
                        ltr.Text += "   <td><a href=\"/manager/Withdraw-List\" target=\"_blank\">" + item.Message + "</a></td>";
                    }
                    else if (item.NotifType == 4)
                    {
                        //ltr.Text += "   <td><a href=\"/manager/Withdraw-List\" target=\"_blank\">" + item.Message + "</a></td>";
                    }
                    else if (item.NotifType == 5)
                    {
                        ltr.Text += "   <td><a href=\"/manager/ComplainList\" target=\"_blank\">" + item.Message + "</a></td>";
                    }
                    else if (item.NotifType == 6)
                    {
                        ltr.Text += "   <td><a href=\"/manager/userlist\" target=\"_blank\">" + item.Message + "</a></td>";
                    }
                    else if (item.NotifType == 8)
                    {
                        ltr.Text += "   <td><a href=\"/manager/chi-tiet-thanh-toan-ho.aspx?ID=" + item.OrderID + "\" target=\"_blank\">" + item.Message + "</a></td>";
                    }
                    else if (item.NotifType == 10)
                    {
                        ltr.Text += "   <td><a href=\"/manager/report-vch\" target=\"_blank\">" + item.Message + "</a></td>";
                    }

                    ltr.Text += "   <td>" + stt + "</td>";
                    ltr.Text += "</tr>";
                }
            }
        }
        public static Int32 GetIntFromQueryString(String key)
        {
            Int32 returnValue = -1;
            String queryStringValue = HttpContext.Current.Request.QueryString[key];
            try
            {
                if (queryStringValue == null)
                    return returnValue;
                if (queryStringValue.IndexOf("#") > 0)
                    queryStringValue = queryStringValue.Substring(0, queryStringValue.IndexOf("#"));
                returnValue = Convert.ToInt32(queryStringValue);
            }
            catch
            { }
            return returnValue;
        }
        private int PageCount;
        protected void DisplayHtmlStringPaging1()
        {
            Int32 CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
            if (CurrentPage == -1) CurrentPage = 1;
            string[] strText = new string[4] { "Trang đầu", "Trang cuối", "Trang sau", "Trang trước" };
            if (PageCount > 1)
                Response.Write(GetHtmlPagingAdvanced(6, CurrentPage, PageCount, Context.Request.RawUrl, strText));
        }
        private static string GetPageUrl(int currentPage, string pageUrl)
        {
            pageUrl = Regex.Replace(pageUrl, "(\\?|\\&)*" + "Page=" + currentPage, "");
            if (pageUrl.IndexOf("?") > 0)
            {
                if (pageUrl.IndexOf("Page=") > 0)
                {
                    int a = pageUrl.IndexOf("Page=");
                    int b = pageUrl.Length;
                    pageUrl.Remove(a, b - a);
                }
                else
                {
                    pageUrl += "&Page={0}";
                }

            }
            else
            {
                pageUrl += "?Page={0}";
            }
            return pageUrl;
        }
        public static string GetHtmlPagingAdvanced(int pagesToOutput, int currentPage, int pageCount, string currentPageUrl, string[] strText)
        {
            //Nếu Số trang hiển thị là số lẻ thì tăng thêm 1 thành chẵn
            if (pagesToOutput % 2 != 0)
            {
                pagesToOutput++;
            }

            //Một nửa số trang để đầu ra, đây là số lượng hai bên.
            int pagesToOutputHalfed = pagesToOutput / 2;

            //Url của trang
            string pageUrl = GetPageUrl(currentPage, currentPageUrl);


            //Trang đầu tiên
            int startPageNumbersFrom = currentPage - pagesToOutputHalfed; ;

            //Trang cuối cùng
            int stopPageNumbersAt = currentPage + pagesToOutputHalfed; ;

            StringBuilder output = new StringBuilder();

            //Nối chuỗi phân trang
            //output.Append("<div class=\"paging\">");
            //output.Append("<ul class=\"paging_hand\">");

            //Link First(Trang đầu) và Previous(Trang trước)
            if (currentPage > 1)
            {
                //output.Append("<li class=\"UnselectedPrev \" ><a title=\"" + strText[0] + "\" href=\"" + string.Format(pageUrl, 1) + "\">|<</a></li>");
                //output.Append("<li class=\"UnselectedPrev\" ><a title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\"><i class=\"fa fa-angle-left\"></i></a></li>");
                output.Append("<a class=\"prev-page pagi-button\" title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\">Prev</a>");
                //output.Append("<span class=\"Unselect_prev\"><a href=\"" + string.Format(pageUrl, currentPage - 1) + "\"></a></span>");
            }

            /******************Xác định startPageNumbersFrom & stopPageNumbersAt**********************/
            if (startPageNumbersFrom < 1)
            {
                startPageNumbersFrom = 1;

                //As page numbers are starting at one, output an even number of pages.  
                stopPageNumbersAt = pagesToOutput;
            }

            if (stopPageNumbersAt > pageCount)
            {
                stopPageNumbersAt = pageCount;
            }

            if ((stopPageNumbersAt - startPageNumbersFrom) < pagesToOutput)
            {
                startPageNumbersFrom = stopPageNumbersAt - pagesToOutput;
                if (startPageNumbersFrom < 1)
                {
                    startPageNumbersFrom = 1;
                }
            }
            /******************End: Xác định startPageNumbersFrom & stopPageNumbersAt**********************/

            //Các dấu ... chỉ những trang phía trước  
            if (startPageNumbersFrom > 1)
            {
                output.Append("<a href=\"" + string.Format(GetPageUrl(currentPage - 1, pageUrl), startPageNumbersFrom - 1) + "\">&hellip;</a>");
            }

            //Duyệt vòng for hiển thị các trang
            for (int i = startPageNumbersFrom; i <= stopPageNumbersAt; i++)
            {
                if (currentPage == i)
                {
                    output.Append("<a class=\"pagi-button current-active\">" + i.ToString() + "</a>");
                }
                else
                {
                    output.Append("<a class=\"pagi-button\" href=\"" + string.Format(pageUrl, i) + "\">" + i.ToString() + "</a>");
                }
            }

            //Các dấu ... chỉ những trang tiếp theo  
            if (stopPageNumbersAt < pageCount)
            {
                output.Append("<a href=\"" + string.Format(pageUrl, stopPageNumbersAt + 1) + "\">&hellip;</a>");
            }

            //Link Next(Trang tiếp) và Last(Trang cuối)
            if (currentPage != pageCount)
            {
                //output.Append("<span class=\"Unselect_next\"><a href=\"" + string.Format(pageUrl, currentPage + 1) + "\"></a></span>");
                //output.Append("<li class=\"UnselectedNext\" ><a title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\"><i class=\"fa fa-angle-right\"></i></a></li>");
                output.Append("<a class=\"next-page pagi-button\" title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\">Next</a>");
                //output.Append("<li class=\"UnselectedNext\" ><a title=\"" + strText[3] + "\" href=\"" + string.Format(pageUrl, pageCount) + "\">>|</a></li>");
            }
            //output.Append("</ul>");
            //output.Append("</div>");
            return output.ToString();
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fd = "";
            string td = "";
            if (!string.IsNullOrEmpty(txtFromDate.Text))
            {
                fd = txtFromDate.Text.ToString();
            }
            if (!string.IsNullOrEmpty(txtToDate.Text))
            {
                td = txtToDate.Text.ToString();
            }

            if (fd == "" && td == "")
            {
                Response.Redirect("/manager/admin-noti");
            }
            else
            {
                Response.Redirect("/manager/admin-noti?fd=" + fd + "&td=" + td);
            }
        }
    }
}