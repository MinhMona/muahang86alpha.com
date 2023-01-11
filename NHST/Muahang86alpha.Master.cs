using NHST.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NHST
{
    public partial class Muahang86alpha : System.Web.UI.MasterPage
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
                ltrHeaderLeft.Text += "<p class=\"text-intro\">Tỷ giá 1¥ = <span class=\"color-red\">" + string.Format("{0:N0}", Convert.ToDouble(confi.Currency)) + "</span></p>";
                ltrHeaderLeft.Text += $"<a href=\"{confi.EmailContact}\" class=\"text-intro\">Email: <span class=\"color-red\">{confi.EmailContact}</span></a>";

                ltrLogo.Text = $"<a href=\"/\"> <img src=\"{confi.LogoIMG}\" alt=\"{confi.CompanyName}\"> </a>";

                ltrHeaderSocial.Text = $"<ul class=\"list-social\"> " +
                    $"<li> <a href=\"{confi.Facebook}\"><i class=\"fa fa-facebook\"></i></a> </li> " +
                    $"<li> <a href=\"{confi.Twitter}\"><i class=\"fa fa-twitter\"></i></a> </li> " +
                    $"<li> <a href=\"{confi.YoutubeLink}\"><i class=\"fa fa-youtube-play\"></i></a> </li> " +
                    $"<li> <a href=\"{confi.Instagram}\"><i class=\"fa fa-instagram\"></i></a> </li> " +
                    $"</ul>";
                ltrHeaderHotline.Text = $"<a href=\"tel:{confi.Hotline}\"> " +
                    $"<span class=\"icon-phone\"> " +
                    $"<img src=\"https://muahang86alpha.com/App_Themes/Muahang86alpha/images/phone.png\" alt=\"\"> </span> " +
                    $"<span class=\"text\">HOTLINE<br /> " +
                    $"<span class=\"text-number\">{confi.Hotline}</span> </span> </a>";
            }

            if (Session["userLoginSystem"] != null)
            {
                string username = Session["userLoginSystem"].ToString();
                var acc = AccountController.GetByUsername(username);
                if (acc != null)
                {
                    #region phần thông báo
                    decimal levelID = Convert.ToDecimal(acc.LevelID);
                    int levelID1 = Convert.ToInt32(acc.LevelID);
                    string level = "1 Vương Miện";
                    var userLevel = UserLevelController.GetByID(levelID1);
                    if (userLevel != null)
                    {
                        level = userLevel.LevelName;
                    }
                    string userIMG = "";
                    var ai = AccountInfoController.GetByUserID(acc.ID);
                    if (ai != null)
                    {
                        if (!string.IsNullOrEmpty(ai.IMGUser))
                            userIMG = ai.IMGUser;
                    }
                    decimal countLevel = UserLevelController.GetAll("").Count();
                    decimal te = levelID / countLevel;
                    te = Math.Round(te, 2, MidpointRounding.AwayFromZero);
                    decimal tile = te * 100;
                    #endregion

                    #region New
                    ltrLogin.Text += "<div class=\"acc-info\">";
                    ltrLogin.Text += "<a class=\"acc-info-btn\" href=\"/thong-tin-nguoi-dung\"><i class=\"icon fa fa-user\"></i><span>" + username + "</span></a>";
                    ltrLogin.Text += "<div class=\"status-desktop\">";
                    ltrLogin.Text += "<div class=\"status-wrap\">";
                    ltrLogin.Text += "<div class=\"status__header\">";
                    ltrLogin.Text += "<h4>" + level + "</h4>";
                    ltrLogin.Text += "</div>";
                    ltrLogin.Text += "<div class=\"status__body\">";
                    ltrLogin.Text += "<div class=\"level\">";
                    ltrLogin.Text += "<div class=\"level__info\">";
                    ltrLogin.Text += "<p>Level</p>";
                    ltrLogin.Text += "<p class=\"rank\">" + level + "</p>";
                    ltrLogin.Text += "</div>";
                    ltrLogin.Text += "<div class=\"level__process\"><span style=\"width: " + tile + "%\"></span></div>";
                    ltrLogin.Text += "</div>";
                    ltrLogin.Text += "<div class=\"balance\">";
                    ltrLogin.Text += "<p>Số dư:</p>";
                    ltrLogin.Text += "<div class=\"balance__number\"><p class=\"vnd\">" + string.Format("{0:N0}", acc.Wallet) + " vnđ</p></div>";
                    ltrLogin.Text += "</div>";
                    if (acc.RoleID != 1)
                        ltrLogin.Text += "<div class=\"links\"><a href=\"/manager/login\">Quản trị<i class=\"fa fa-caret-right\"></i></a></div>";
                    ltrLogin.Text += "<div class=\"links\"><a href=\"/thong-tin-nguoi-dung\">Thông tin tài khoản<i class=\"fa fa-caret-right\"></i></a></div>";
                    ltrLogin.Text += "<div class=\"links\"><a href=\"/danh-sach-don-hang?t=1\">Đơn hàng của bạn<i class=\"fa fa-caret-right\"></i></a></div>";
                    ltrLogin.Text += "<div class=\"links\"><a href=\"/lich-su-giao-dich\">Lịch sử giao dịch<i class=\"fa fa-caret-right\"></i></a></div>";
                    ltrLogin.Text += "</div>";
                    ltrLogin.Text += "<div class=\"status__footer\"><a href=\"/dang-xuat\" class=\"ft-btn\">ĐĂNG XUẤT</a></div>";
                    ltrLogin.Text += "</div>";
                    ltrLogin.Text += "</div>";
                    ltrLogin.Text += "<div class=\"status-mobile\">";
                    ltrLogin.Text += "<a href=\"/thong-tin-nguoi-dung\" class=\"user-menu-logo\"><img src=\"" + userIMG + "\" alt=\"\"></a>";
                    ltrLogin.Text += "<h3 class=\"username\">" + username + "</h3>";
                    ltrLogin.Text += "<div class=\"user-info\">Số tiền: <span class=\"money\">" + string.Format("{0:N0}", acc.Wallet) + "</span> vnđ | Level <span class=\"vip\">" + level + "</span></div>";
                    ltrLogin.Text += "<div class=\"nav-percent\">";
                    ltrLogin.Text += "<div class=\"nav-percent-ok\" style=\"width: " + tile + "%\"></div>";
                    ltrLogin.Text += "</div>";
                    ltrLogin.Text += "<div class=\"profile-bottom\">";
                    ltrLogin.Text += "<ul class=\"menu-in-profile\">";
                    ltrLogin.Text += "<li><a href=\"/\"><i class=\"fa fa-home\"></i>TRANG CHỦ</a></li>";
                    ltrLogin.Text += "<li><a href=\"/theo-doi-mvd\"><i class=\"fa fa-search\"></i>TRACKING</a></li>";
                    ltrLogin.Text += "<li><a href=\"/danh-sach-don-hang?t=1\"><i class=\"fa fa-home\"></i>MUA HÀNG HỘ</a></li>";
                    ltrLogin.Text += "<li><a href=\"/lich-su-giao-dich\"><i class=\"fa fa-money\"></i>TÀI CHÍNH</a></li>";
                    ltrLogin.Text += "<li><a href=\"/khieu-nai\"><i class=\"fa fa-exclamation\"></i>KHIẾU NẠI</a></li>";
                    ltrLogin.Text += "<li><a href=\"/thong-tin-nguoi-dung\"><i class=\"fa fa-user\"></i>QUẢN LÝ TÀI KHOẢN</a></li>";
                    ltrLogin.Text += "</ul>";
                    ltrLogin.Text += "</div><a href=\"/dang-xuat\" class=\"main-btn\">Đăng xuất</a></div>";
                    ltrLogin.Text += "<div class=\"overlay-status-mobile\"></div>";
                    ltrLogin.Text += "</div>";
                    #endregion
                }
            }
            else
            {
                ltrLogin.Text += "<div class=\"icon\"><i class=\"fa fa-user-circle-o\" aria-hidden=\"true\"></i></div>" +
                    "<a href=\"/dang-nhap\">Đăng nhập</a> <span> / </span> " +
                    "<a href=\"/dang-ky\">Đăng kí</a>";
            }

            #region LoadMenu
            var menu = MenuController.GetByLevel(0);
            if (menu.Count > 0)
            {
                foreach (var item in menu)
                {
                    if (item.Target != true)
                    {
                        ltrMenu.Text += "<li> <a href=\"" + item.MenuLink + "\">" + item.MenuName + "</a>";
                    }
                    else
                    {
                        ltrMenu.Text += "<li class=\"dropdown\"><a href=\"" + item.MenuLink + "\">" + item.MenuName + "</a>";
                        var subMenu = MenuController.GetByLevel(item.ID);
                        if (subMenu != null && subMenu.Count > 0)
                        {
                            ltrMenu.Text += "<span class=\"btn-dropdown\"> <i class=\"fa fa-caret-down\" aria-hidden=\"true\"></i> </span><div class=\"sub-menu-wrap\"> <ul class=\"sub-menu\">";
                            foreach (var itemSubMenu in subMenu)
                            {
                                ltrMenu.Text += "<li><a href=\"" + itemSubMenu.MenuLink + "\">" + itemSubMenu.MenuName + "</a></li>";
                            }
                            ltrMenu.Text += "</ul></div></li>";
                        }
                    }
                }
            }
            #endregion

            #region LoadFooter
            ltrFooterLogo.Text = $"<a href=\"/\"> <img src=\"{confi.LogoIMG}\" alt=\"{confi.CompanyName}\"> </a>";

            ltrFooterContacr.Text = $"<ul class=\"list-ft\"> " +
                $"<li> <a href=\"#\"><span class=\"font-bold-1\">Địa chỉ:</span> {confi.Address} </a> </li> <li> " +
                $"<a href=\"{confi.EmailContact} \"><span class=\"font-bold-1\">Email:</span> {confi.EmailContact} </a> </li> <li> " +
                $"<a href=\"tel:+{confi.Hotline}\"><span class=\"font-bold-1\">Hotline:</span> {confi.Hotline}</a> </li> <li> " +
                $"<a href=\"#\"><span class=\"font-bold-1\">Website:</span> {confi.Websitename}</a> </li> </ul>";

            ltrSocialFooter.Text = $"<ul class=\"list-ft-social\"> " +
                    $"<li> <a href=\"{confi.Facebook}\"><i class=\"fa fa-facebook\"></i></a> </li> " +
                    $"<li> <a href=\"{confi.Twitter}\"><i class=\"fa fa-twitter\"></i></a> </li> " +
                    $"<li> <a href=\"{confi.YoutubeLink}\"><i class=\"fa fa-youtube-play\"></i></a> </li> " +
                    $"<li> <a href=\"{confi.Instagram}\"><i class=\"fa fa-instagram\"></i></a> </li> " +
                    $"</ul>";
            #endregion
        }
    }
}