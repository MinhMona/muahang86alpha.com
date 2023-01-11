using NHST.Bussiness;
using NHST.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHST
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        public void LoadData()
        {
            var confi = ConfigurationController.GetByTop1();
            if (confi != null)
            {
                ltrTool.Text = $"<a href=\"{confi.CocCocExtensionLink}\" class=\"btn btn-setting mar-r-15\"> <img src=\"/App_Themes/Muahang86alpha/images/coccoc.png\" alt=\"\">Cốc Cốc</a> " +
                    $"<a href=\"{confi.ChromeExtensionLink}\" class=\"btn btn-setting\"> <img src=\"/App_Themes/Muahang86alpha/images/chrome.png\" alt=\"\">Chrome</a>";

                ltrInfor.Text = $"<ul class=\"list-contact\"> " +
                    $"<li> <a href=\"tel:+{confi.Hotline}\"> " +
                    $"<span class=\"icon-ct\"> " +
                    $"<img src=\"App_Themes/Muahang86alpha/images/ct-1.png\" alt=\"\"> </span> " +
                    $"<span class=\"text-ct\">HOTLINE<br /> " +
                    $"<i>{confi.Hotline}</i></span> </a> </li> <li> " +
                    $"<a href=\"{confi.EmailContact} \"> <span class=\"icon-ct\"> " +
                    $"<img src=\"App_Themes/Muahang86alpha/images/ct-2.png\" alt=\"\"> </span> " +
                    $"<span class=\"text-ct\">EMAIL<br /> <i> {confi.EmailContact} </i></span> </a> " +
                    $"</li> <li> <a href=\"#\"> <span class=\"icon-ct\"> " +
                    $"<img src=\"App_Themes/Muahang86alpha/images/ct-3.png\" alt=\"\"> </span> " +
                    $"<span class=\"text-ct\">GIỜ HOẠT ĐỘNG<br /> <i>{confi.TimeWork}</i></span> " +
                    $"</a> </li> </ul>";
            }

            var sv = ServiceController.GetAll().OrderBy(x => x.Position).ToList();
            if (sv.Count > 0)
            {
                foreach (var item in sv)
                {
                    ltrServices.Text += $"<div class=\"colum\"> " +
                        $"<div class=\"content wow fadeInUp\" data-wow-delay=\".2s\" data-wow-duration=\"1s\">" +
                        $"<div class=\"img-dv\"> <img src=\"{item.ServiceIMG}\" alt=\"\"> </div> " +
                        $"<h3 class=\"title\"> <a href=\"{item.ServiceLink}\">{item.ServiceName}</a> </h3> " +
                        $"<p class=\"desc\"> {item.ServiceContent}</p> </div> </div>";
                }
            }

            var st = StepController.GetAllHome().ToList();
            int js = 1;
            if (st.Count > 0)
            {
                foreach (var item in st)
                {
                    if (item == st.ElementAt(0))
                    {
                        ltrStepNames.Text += $"<li data-tab=\"js-{js}\" class=\"active\"><i class=\"fa fa-long-arrow-left\"></i>{item.StepName}</li>";
                        ltrStepContents.Text += $"<div class=\"c-tab__content js-{js} active wow fadeInUp\" data-wow-delay=\".3s\" data-wow-duration=\"1s\">";
                        ltrStepContents.Text += "<div class=\"box-img\">";
                        ltrStepContents.Text += "<img src=\"App_Themes/Muahang86alpha/images/img-hd.png\" alt=\"\">";
                        ltrStepContents.Text += "</div>";
                        ltrStepContents.Text += "<div class=\"content\">";
                        ltrStepContents.Text += "<div class=\"title-intro\">";
                        ltrStepContents.Text += item.StepName;
                        ltrStepContents.Text += "</div>";
                        ltrStepContents.Text += "<p class=\"desc-intro\">";
                        ltrStepContents.Text += item.StepContent;
                        ltrStepContents.Text += "</p>";
                        ltrStepContents.Text += "<a href=\"/dang-ky\" class=\"btn btn-detail\">đăng kí <i class=\"fa fa-long-arrow-right\"></i></a>";
                        ltrStepContents.Text += "</div>";
                        ltrStepContents.Text += "</div>";
                    }
                    else
                    {
                        ltrStepNames.Text += $"<li data-tab=\"js-{js}\"><i class=\"fa fa-long-arrow-left\"></i>{item.StepName} </li>";
                        ltrStepContents.Text += $"<div class=\"c-tab__content js-{js}\">";
                        ltrStepContents.Text += "<div class=\"box-img\">";
                        ltrStepContents.Text += "<img src=\"App_Themes/Muahang86alpha/images/img-hd.png\" alt=\"\">";
                        ltrStepContents.Text += "</div>";
                        ltrStepContents.Text += "<div class=\"content\">";
                        ltrStepContents.Text += "<div class=\"title-intro\">";
                        ltrStepContents.Text += item.StepName;
                        ltrStepContents.Text += "</div>";
                        ltrStepContents.Text += "<p class=\"desc-intro\">";
                        ltrStepContents.Text += item.StepContent;
                        ltrStepContents.Text += "</p>";
                        ltrStepContents.Text += "<a href=\"/dang-ky\" class=\"btn btn-detail\">đăng kí <i class=\"fa fa-long-arrow-right\"></i></a>";
                        ltrStepContents.Text += "</div>";
                        ltrStepContents.Text += "</div>";
                    }

                    js++;
                }
            }


            var ql = CustomerBenefitsController.GetAllBenefit();
            if (ql.Count > 0)
            {
                foreach (var item in ql)
                {
                    ltrBenefits.Text += $"<div class=\"colum\"> " +
                        $"<div class=\"content wow fadeInUp\" data-wow-delay=\".3s\" data-wow-duration=\"1s\"> " +
                        $"<div class=\"icon\"> <img src=\"{item.Icon}\" alt=\"\"> " +
                        $"</div> <h4 class=\"title\">{item.CustomerBenefitName}</h4> " +
                        $"<p class=\"desc\"> {item.CustomerBenefitDescription} </p> </div> </div>";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    string a = PJUtils.TranslateTextNew(text, "vi", "zh");
                    a = a.Replace("[", "").Replace("]", "").Replace("\"", "");
                    string[] ass = a.Split(',');
                    string page = hdfWebsearch.Value;
                    SearchPage(page, PJUtils.RemoveHTMLTags(ass[0]));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(inputString);
            return bytes;
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append("%" + b.ToString("X2"));

            return sb.ToString();
        }
        public void SearchPage(string page, string text)
        {
            string linkgo = "";
            if (page == "tmall")
            {
                string a = text;
                string textsearch_tmall = GetHashString(a);
                //string fullLinkSearch_tmall = "https://list.tmall.com/search_product.htm?q=" + textsearch_tmall + "&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
                linkgo = "https://list.tmall.com/search_product.htm?q=" + textsearch_tmall + "&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
            }
            else if (page == "taobao")
            {
                string a = text;
                string textsearch_taobao = GetHashString(a);
                //string fullLinkSearch_taobao = "https://world.taobao.com/search/search.htm?q=" + textsearch_taobao + "&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1";
                linkgo = "https://world.taobao.com/search/search.htm?q=" + textsearch_taobao + "&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1";
                //https://world.taobao.com/search/search.htm?q=%B9%AB%BC%A6&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1
            }
            else if (page == "1688")
            {
                string a = text;
                string textsearch_1688 = GetHashString(a);
                //string fullLinkSearch_1688 = "https://s.1688.com/selloffer/offer_search.htm?keywords=" + textsearch_1688 + "&button_click=top&earseDirect=false&n=y";
                linkgo = "https://s.1688.com/selloffer/offer_search.htm?keywords=" + textsearch_1688 + "&button_click=top&earseDirect=false&n=y";
            }
            Response.Redirect(linkgo);
        }


        [WebMethod]
        public static string getPopup()
        {
            if (HttpContext.Current.Session["notshowpopup"] == null)
            {
                var conf = ConfigurationController.GetByTop1();
                string popup = conf.NotiPopupTitle;
                if (!string.IsNullOrEmpty(popup))
                {
                    NotiInfo n = new NotiInfo();
                    n.NotiTitle = conf.NotiPopupTitle;
                    n.NotiEmail = conf.NotiPopupEmail;
                    n.NotiContent = conf.NotiPopup;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Serialize(n);
                }
                else
                    return "null";
            }
            else
                return null;
        }
        [WebMethod]
        public static void setNotshow()
        {
            HttpContext.Current.Session["notshowpopup"] = "1";
        }
        [WebMethod]
        public static string closewebinfo()
        {
            HttpContext.Current.Session["infoclose"] = "ok";
            return "ok";
        }

        [WebMethod]
        public static string getInfo(string ordecode)
        {
            string returnString = "";
            var smallpackage = SmallPackageController.GetByOrderTransactionCode(ordecode);
            if (smallpackage != null)
            {
                int mID = 0;
                int tID = 0;
                if (smallpackage.MainOrderID != null)
                {
                    if (smallpackage.MainOrderID > 0)
                    {
                        mID = Convert.ToInt32(smallpackage.MainOrderID);
                    }
                    else if (smallpackage.TransportationOrderID != null)
                    {
                        if (smallpackage.TransportationOrderID > 0)
                        {
                            tID = Convert.ToInt32(smallpackage.TransportationOrderID);
                        }
                    }
                }
                else if (smallpackage.TransportationOrderID != null)
                {
                    if (smallpackage.TransportationOrderID > 0)
                    {
                        tID = Convert.ToInt32(smallpackage.TransportationOrderID);
                    }
                }
                string ordertype = "Chưa xác định";
                if (tID > 0)
                {
                    ordertype = "Đơn hàng vận chuyển hộ";
                }
                else if (mID > 0)
                {
                    ordertype = "Đơn hàng mua hộ";
                }

                returnString += "<aside style=\"text-align:left;\" class=\"side trk-info fr\"><table>";
                returnString += "   <tbody>";
                returnString += "       <tr>";
                returnString += "           <th style=\"width:50%\">Mã vận đơn:</th>";
                returnString += "           <td class=\"m-color\">" + ordecode + "</td>";
                returnString += "       </tr>";
                returnString += "       <tr>";
                returnString += "           <th style=\"width:50%\">Mã đơn hàng:</th>";
                if (mID > 0)
                    returnString += "           <td class=\"m-color\">" + mID + "</td>";
                else if (tID > 0)
                    returnString += "           <td class=\"m-color\">" + tID + "</td>";
                else
                    returnString += "           <td class=\"m-color\">Chưa xác định</td>";
                returnString += "       </tr>";
                returnString += "       <tr>";
                returnString += "           <th style=\"width:50%\">Loại hàng:</th>";
                returnString += "           <td class=\"m-color\">" + ordertype + "</td>";
                returnString += "       </tr>";
                returnString += "   </tbody>";
                returnString += "</table></aside>";
                returnString += "<aside class=\"side trk-history fl\"><ul class=\"list\">";
                if (smallpackage.Status == 0)
                {
                    returnString += "<li class=\"clear\">";
                    returnString += "  Mã vận đơn đã bị hủy";
                    returnString += "</li>";
                }
                else if (smallpackage.Status == 1)
                {
                    returnString += "<li class=\"clear\">";
                    returnString += "  Mã vận đơn chưa về kho TQ";
                    returnString += "</li>";
                }
                else if (smallpackage.Status == 2)
                {
                    returnString += "<li class=\"it clear\">";
                    if (smallpackage.DateInTQWarehouse != null)
                        returnString += "  <div class=\"date-time tq grey89\"><p>" + string.Format("{0:dd/MM/yyyy HH:mm}", smallpackage.DateInTQWarehouse) + "</p></div>";
                    else
                        returnString += "  <div class=\"date-time grey89\"><p>Chưa xác định</p></div>";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Đã về kho TQ</span></p>";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">NV Xử lý:</span> <span class=\"m-color\">" + smallpackage.StaffTQWarehouse + "</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                }
                else if (smallpackage.Status == 3)
                {
                    returnString += "<li class=\"it clear\">";
                    if (smallpackage.DateInTQWarehouse != null)
                        returnString += "  <div class=\"date-time tq grey89\"><p>" + string.Format("{0:dd/MM/yyyy HH:mm}", smallpackage.DateInTQWarehouse) + "</p></div>";
                    else
                        returnString += "  <div class=\"date-time grey89\"><p>Chưa xác định</p></div>";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Đã về kho TQ</span></p>";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">NV Xử lý:</span> <span class=\"m-color\">" + smallpackage.StaffTQWarehouse + "</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                    returnString += "<li class=\"it clear\">";
                    if (smallpackage.DateInLasteWareHouse != null)
                        returnString += "  <div class=\"date-time vn grey89\"><p>" + string.Format("{0:dd/MM/yyyy HH:mm}", smallpackage.DateInLasteWareHouse) + "</p></div>";
                    else
                        returnString += "  <div class=\"date-time grey89\"><p>Chưa xác định</p></div>";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Đã về kho đích</span></p>";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">NV Xử lý:</span> <span class=\"m-color\">" + smallpackage.StaffVNWarehouse + "</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                }
                else if (smallpackage.Status == 4)
                {
                    returnString += "<li class=\"it clear\">";
                    if (smallpackage.DateInTQWarehouse != null)
                        returnString += "  <div class=\"date-time tq grey89\"><p>" + string.Format("{0:dd/MM/yyyy HH:mm}", smallpackage.DateInTQWarehouse) + "</p></div>";
                    else
                        returnString += "  <div class=\"date-time grey89\"><p>Chưa xác định</p></div>";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Đã về kho TQ</span></p>";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">NV Xử lý:</span> <span class=\"m-color\">" + smallpackage.StaffTQWarehouse + "</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                    returnString += "<li class=\"it clear\">";
                    if (smallpackage.DateInLasteWareHouse != null)
                        returnString += "  <div class=\"date-time vn grey89\"><p>" + string.Format("{0:dd/MM/yyyy HH:mm}", smallpackage.DateInLasteWareHouse) + "</p></div>";
                    else
                        returnString += "  <div class=\"date-time grey89\"><p>Chưa xác định</p></div>";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Đã về kho đích</span></p>";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">NV Xử lý:</span> <span class=\"m-color\">" + smallpackage.StaffVNWarehouse + "</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                    returnString += "<li class=\"it clear\">";
                    if (smallpackage.DateOutWarehouse != null)
                        returnString += "  <div class=\"date-time ht grey89\"><p>" + string.Format("{0:dd/MM/yyyy HH:mm}", smallpackage.DateOutWarehouse) + "</p></div>";
                    else
                        returnString += "  <div class=\"date-time grey89\"><p>Chưa xác định</p></div>";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Đã giao khách</span></p>";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">NV Xử lý:</span> <span class=\"m-color\">" + smallpackage.StaffVNOutWarehouse + "</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                }
                else if (smallpackage.Status == 5)
                {
                    returnString += "<li class=\"it clear\">";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Đang về kho Việt Nam</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                }
                else if (smallpackage.Status == 6)
                {
                    returnString += "<li class=\"it clear\">";
                    returnString += "  <div class=\"statuss ok\">";
                    returnString += "      <p class=\"tit\"><span class=\"grey89 font-w\">Trạng thái:</span><span class=\"m-color\"> Hàng về cửa khẩu</span></p>";
                    returnString += "  </div>";
                    returnString += "</li>";
                }
                returnString += "</ul></aside>";
            }
            else
            {
                returnString += "Không tồn tại mã vận đơn trong hệ thống";
            }
            return returnString;
        }
        public class NotiInfo
        {
            public string NotiTitle { get; set; }
            public string NotiContent { get; set; }
            public string NotiEmail { get; set; }
        }
    }
}