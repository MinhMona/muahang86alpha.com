<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DPG-Master.Master" CodeBehind="DefaultYPCN.aspx.cs" Inherits="NHST.DefaultYPCN" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <main id="home">
        <div class="banner">
            <ul class="banner-slider">
                <li class="banner__bg" style="background-image: url('/App_Themes/DPG/images/banner-bg.png')"></li>
                <li class="banner__bg" style="background-image: url('/App_Themes/DPG/images/banner-bg.png')"></li>
                <li class="banner__bg" style="background-image: url('/App_Themes/DPG/images/banner-bg.png')"></li>
                <li class="banner__bg" style="background-image: url('/App_Themes/DPG/images/banner-bg.png')"></li>
            </ul>
            <div class="banner__title">
                <div class="title">
                    <p class="sub-hd">Mua hàng 86 alpha</p>
                    <h1>Chúng tôi chuyên nghiệp</h1>
                </div>
                <div class="search">
                    <div class="s_select">
                        <select class="f-control" id="brand-source">
                            <option value="taobao">Taobao</option>
                            <option value="tmall">Tmall</option>
                            <option value="1688">1688</option>
                        </select>
                        <span class="icon">
                            <i class="fa fa-chevron-down"></i>
                        </span>
                    </div>
                    <div class="s_input">
                        <asp:TextBox type="text" class="f-control" runat="server" ID="txtSearch" placeholder="Nhập tên sản phẩm tìm kiếm"></asp:TextBox>
                        <span class="s-button">
                            <a href="javascript:;" onclick="searchProduct()" class="mn-btn">
                                <i class="fa fa-search"></i>
                            </a>
                            <asp:Button ID="btnSearch" runat="server"
                                OnClick="btnSearch_Click" Style="display: none"
                                OnClientClick="document.forms[0].target = '_blank';" UseSubmitBehavior="false" />
                        </span>
                    </div>
                </div>

                <div class="button">
                    <a target="_blank" href="#" class="mn-btn gg-btn"><i class="fa fa-chrome"></i>Chrome</a>
                    <a target="_blank" href="#" class="mn-btn cc-btn"><i class="fa fa-chrome"></i>Cốc Cốc</a>
                </div>

                <div class="slick-button">
                    <span class="s-btn prev"><i class="fa fa-chevron-left"></i></span>
                    <span class="current-num">1</span>/
                    <span class="total-num">5</span>
                    <span class="s-btn next"><i class="fa fa-chevron-right"></i></span>
                </div>

            </div>
        </div>

        <div class="features">
            <ul class="list-feats">
                <asp:Literal runat="server" ID="ltrServices"></asp:Literal>
            </ul>
        </div>

        <div class="steps-order">
            <div class="all">
                <ul class="list-steps">
                    <li class="step__item active" step-nav="#step-dangky">
                        <div class="it-wrap">
                            <div class="icon">
                                <i class="fa fa-file-text"></i>
                            </div>
                            <div class="hd">Đăng ký tài khoản</div>
                        </div>
                    </li>
                    <li class="step__item" step-nav="#step-caidat">
                        <div class="it-wrap">
                            <div class="icon">
                                <i class="fa fa-cog"></i>
                            </div>
                            <div class="hd">Cài đặt công cụ mua hàng</div>
                        </div>
                    </li>
                    <li class="step__item" step-nav="#step-chonhang">
                        <div class="it-wrap">
                            <div class="icon">
                                <i class="fa fa-shopping-bag"></i>
                            </div>
                            <div class="hd">Chọn hàng và thêm vào giỏ hàng</div>
                        </div>
                    </li>
                    <li class="step__item" step-nav="#step-guidon">
                        <div class="it-wrap">
                            <div class="icon">
                                <i class="fa fa-share-square"></i>
                            </div>
                            <div class="hd">Gửi đơn đặng hàng</div>
                        </div>
                    </li>
                    <li class="step__item" step-nav="#step-datcoc">
                        <div class="it-wrap">
                            <div class="icon">
                                <i class="fa fa-usd"></i>
                            </div>
                            <div class="hd">Đặt cọc tiền hàng</div>
                        </div>
                    </li>
                    <li class="step__item" step-nav="#step-nhanhang">
                        <div class="it-wrap">
                            <div class="icon">
                                <i class="fa fa-handshake-o"></i>
                            </div>
                            <div class="hd">Nhận hàng và thanh toán</div>
                        </div>
                    </li>
                </ul>

                <div class="content-wrap">
                    <div class="step-content" id="step-dangky">
                        <div class="detail">
                            <h2 class="hd">Đăng ký tài khoản</h2>
                            <p>
                                Nhập các thông tin cá nhân bắt buộc vào ô, lưu ý nhập chính xác các thông tin để đảm bảo cho việc quản lí đơn hàng và nhận hàng của bạn.
                            </p>
                            <div class="button">
                                <a href="/dang-ky" class="mn-btn btn-1">Đăng ký</a>
                            </div>
                        </div>
                        <div class="img">
                            <img src="/App_Themes/DPG/images/step-img-1.jpg" alt="">
                        </div>
                    </div>

                    <div class="step-content" id="step-caidat">
                        <div class="detail">
                            <h2 class="hd">Cài đặt công cụ mua hàng</h2>
                            <p>
                                Click vào cài đặt công cụ đặt hàng của DPG-Express. Công cụ hỗ trợ đặt hàng các website taobao, tmall, 1688.
                            </p>
                        </div>
                        <div class="img">
                            <img src="/App_Themes/DPG/images/step-img-1.jpg" alt="">
                        </div>
                    </div>
                    <div class="step-content" id="step-chonhang">
                        <div class="detail">
                            <h2 class="hd">Chọn hàng và thêm hàng vào giỏ</h2>
                            <p>
                                Truy cập vào các trang mua sắm Taobao.com, Tmall.com, 1688.com … chọn hàng và thêm hàng vào giỏ.
                            </p>
                        </div>
                        <div class="img">
                            <img src="/App_Themes/DPG/images/step-img-1.jpg" alt="">
                        </div>
                    </div>
                    <div class="step-content" id="step-guidon">
                        <div class="detail">
                            <h2 class="hd">Gửi đơn hàng</h2>
                            <p>
                                Quay lại website DPG-Express và kiểm tra giỏ hàng Click vào “Gửi đơn hàng” để tạo đơn hàng,chờ xác nhận đặt hàng thành công.
                            </p>
                        </div>
                        <div class="img">
                            <img src="/App_Themes/DPG/images/step-img-1.jpg" alt="">
                        </div>
                    </div>
                    <div class="step-content" id="step-datcoc">
                        <div class="detail">
                            <h2 class="hd">Đặt cọc tiền hàng</h2>
                            <p>
                                Kiểm tra đơn hàng và đặt cọc tiền hàng qua hình thức chuyển khoản hoặc trực tiếp tại các văn phòng giao dịch gần nhất của DPG-Express.
                            </p>
                        </div>
                        <div class="img">
                            <img src="/App_Themes/DPG/images/step-img-1.jpg" alt="">
                        </div>
                    </div>
                    <div class="step-content" id="step-nhanhang">
                        <div class="detail">
                            <h2 class="hd">Nhận hàng và thanh toán</h2>
                            <p>
                                Quý khách nhận được thông báo hàng về Việt Nam. Quý khách thanh toán số tiền còn  thiếu qua hình thức chuyển khoản hoặc trực tiếp. Sau khi thanh toán quý khách hàng có thể yêu cầu ship hàng hoặc trực tiếp nhận hàng tại kho của DPG-Express.
                            </p>
                        </div>
                        <div class="img">
                            <img src="/App_Themes/DPG/images/step-img-1.jpg" alt="">
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="benefits">
            <div class="all">
                <div class="title">
                    <h2>Quyền lợi khách hàng</h2>
                </div>
                <ul class="list-benefits">
                    <asp:Literal runat="server" ID="ltrBenefits"></asp:Literal>
                </ul>
            </div>
        </div>

        <div class="present">
            <div class="all">
                <div class="ps__child">
                    <h4 class="hd">10</h4>
                    <p class="sub-hd">Năm kinh nghiệm</p>
                </div>
                <div class="ps__child">
                    <h4 class="hd">12,345</h4>
                    <p class="sub-hd">Khách hàng</p>
                </div>
                <div class="ps__child">
                    <h4 class="hd">67,890</h4>
                    <p class="sub-hd">Đơn hàng</p>
                </div>
            </div>
        </div>

        <div class="contact">
            <div class="ct-box">
                <div class="title">
                    <h2>Liên hệ</h2>
                </div>
                <div class="detail">
                    <p class="sub">Hotline:</p>
                    <p class="main">
                        <asp:Literal runat="server" ID="ltrHotline"></asp:Literal>
                    </p>
                </div>
                <div class="detail">
                    <p class="sub">Giờ hoạt động</p>
                    <p class="main">
                        <asp:Literal runat="server" ID="ltrTimeWork"></asp:Literal>
                    </p>
                </div>
                <div class="detail">
                    <p class="sub">Email:</p>
                    <p class="main">
                        <asp:Literal runat="server" ID="ltrEmail"></asp:Literal>
                    </p>
                </div>
            </div>
            <div class="google-map">
               <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3835.0959619123705!2d108.16054662897608!3d16.00851930988394!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31421be9b7ce1b21%3A0x2bcdddf1ff563b33!2zSzI3IE5ndXnhu4VuIFBow7ogSMaw4budbmcsIEjDsmEgVGjhu40gVMOieSwgQ-G6qW0gTOG7hywgxJDDoCBO4bq1bmcsIFZp4buHdCBOYW0!5e0!3m2!1svi!2s!4v1664251740679!5m2!1svi!2s" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
        </div>

    </main>
    <asp:HiddenField ID="hdfWebsearch" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.txtSearch').on("keypress", function (e) {
                if (e.keyCode == 13) {
                    searchProduct();
                }
            });
        });
        function keyclose_ms(e) {
            if (e.keyCode == 27) {
                close_popup_ms();
            }
        }
        function searchProduct() {
            var web = $("#brand-source").val();
            $("#<%=hdfWebsearch.ClientID%>").val(web);
            $("#<%=btnSearch.ClientID%>").click();
        }
    </script>
    <script type="text/javascript">        
        function close_popup_ms() {
            $("#pupip_home").animate({ "opacity": 0 }, 400);
            $("#bg_popup_home").animate({ "opacity": 0 }, 400);
            setTimeout(function () {
                $("#pupip_home").remove();
                $(".zoomContainer").remove();
                $("#bg_popup_home").remove();
                $('body').css('overflow', 'auto').attr('onkeydown', '');
            }, 500);
        }
        function closeandnotshow() {
            $.ajax({
                type: "POST",
                url: "/Default.aspx/setNotshow",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    close_popup_ms();
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert('lỗi');
                }
            });
        }
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "/Default.aspx/getPopup",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d != "null") {
                        var data = JSON.parse(msg.d);
                        var title = data.NotiTitle;
                        var content = data.NotiContent;
                        var email = data.NotiEmail;
                        var obj = $('form');
                        $(obj).css('overflow', 'hidden');
                        $(obj).attr('onkeydown', 'keyclose_ms(event)');
                        var bg = "<div id='bg_popup_home'></div>";
                        var fr = "<div id='pupip_home' class=\"columns-container1\">" +
                            "  <div class=\"center_column col-xs-12 col-sm-5\" id=\"popup_content_home\">";
                        fr += "<div class=\"popup_header\">";
                        fr += title;
                        fr += "<a style='cursor:pointer;right:5px;' onclick='close_popup_ms()' class='close_message'></a>";
                        fr += "</div>";
                        fr += "     <div class=\"changeavatar\">";
                        fr += "         <div class=\"content1\">";
                        fr += content;
                        fr += "         </div>";
                        fr += "         <div class=\"content2\">";
                        fr += "<a href=\"javascript:;\" class=\"btn btn-close-full\" onclick='closeandnotshow()'>Đóng & không hiện thông báo</a>";
                        fr += "<a href=\"javascript:;\" class=\"btn btn-close\" onclick='close_popup_ms()'>Đóng</a>";
                        fr += "         </div>";
                        fr += "     </div>";
                        fr += "<div class=\"popup_footer\">";
                        fr += "<span class=\"float-right\">" + email + "</span>";
                        fr += "</div>";
                        fr += "   </div>";
                        fr += "</div>";
                        $(bg).appendTo($(obj)).show().animate({ "opacity": 0.7 }, 800);
                        $(fr).appendTo($(obj));
                        setTimeout(function () {
                            $('#pupip').show().animate({ "opacity": 1, "top": 20 + "%" }, 200);
                            $("#bg_popup").attr("onclick", "close_popup_ms()");
                        }, 1000);
                    }
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert('lỗi');
                }
            });
        });
    </script>
    <style>
        #bg_popup_home {
            position: fixed;
            width: 100%;
            height: 100%;
            background-color: #333;
            opacity: 0.7;
            filter: alpha(opacity=70);
            left: 0px;
            top: 0px;
            z-index: 999999999;
            opacity: 0;
            filter: alpha(opacity=0);
        }

        #popup_ms_home {
            background: #fff;
            border-radius: 0px;
            box-shadow: 0px 2px 10px #fff;
            float: left;
            position: fixed;
            width: 735px;
            z-index: 10000;
            left: 50%;
            margin-left: -370px;
            top: 200px;
            opacity: 0;
            filter: alpha(opacity=0);
            height: 360px;
        }

            #popup_ms_home .popup_body {
                border-radius: 0px;
                float: left;
                position: relative;
                width: 735px;
            }

            #popup_ms_home .content {
                /*background-color: #487175;     border-radius: 10px;*/
                margin: 12px;
                padding: 15px;
                float: left;
            }

            #popup_ms_home .title_popup {
                /*background: url("../images/img_giaoduc1.png") no-repeat scroll -200px 0 rgba(0, 0, 0, 0);*/
                color: #ffffff;
                font-family: Arial;
                font-size: 24px;
                font-weight: bold;
                height: 35px;
                margin-left: 0;
                margin-top: -5px;
                padding-left: 40px;
                padding-top: 0;
                text-align: center;
            }

            #popup_ms_home .text_popup {
                color: #fff;
                font-size: 14px;
                margin-top: 20px;
                margin-bottom: 20px;
                line-height: 20px;
            }

                #popup_ms_home .text_popup a.quen_mk, #popup_ms_home .text_popup a.dangky {
                    color: #FFFFFF;
                    display: block;
                    float: left;
                    font-style: italic;
                    list-style: -moz-hangul outside none;
                    margin-bottom: 5px;
                    margin-left: 110px;
                    -webkit-transition-duration: 0.3s;
                    -moz-transition-duration: 0.3s;
                    transition-duration: 0.3s;
                }

                    #popup_ms_home .text_popup a.quen_mk:hover, #popup_ms_home .text_popup a.dangky:hover {
                        color: #8cd8fd;
                    }

            #popup_ms_home .close_popup {
                background: url("/App_Themes/Camthach/images/close_button.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
                display: block;
                height: 28px;
                position: absolute;
                right: 0px;
                top: 5px;
                width: 26px;
                cursor: pointer;
                z-index: 10;
            }

        #popup_content_home {
            height: auto;
            position: fixed;
            background-color: #fff;
            top: 17%;
            z-index: 999999999;
            left: 25%;
            border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            width: 50%;
            padding: 20px;
        }

        #popup_content_home {
            padding: 0;
        }

        .popup_header, .popup_footer {
            float: left;
            width: 100%;
            background: #005792;
            padding: 10px;
            position: relative;
            color: #fff;
        }

        .popup_header {
            font-weight: bold;
            font-size: 16px;
            text-transform: uppercase;
        }

        .close_message {
            top: 10px;
        }

        .changeavatar {
            padding: 10px;
            margin: 5px 0;
            float: left;
            width: 100%;
        }

        .float-right {
            float: right;
        }

        .content1 {
            float: left;
            width: 100%;
        }

        .content2 {
            float: left;
            width: 100%;
            border-top: 1px solid #eee;
            clear: both;
            margin-top: 10px;
        }

        .btn.btn-close {
            float: right;
            background: #d00f0f;
            color: #fff;
            margin-top: 20px;
            text-transform: none;
            padding: 10px 20px;
            width: unset;
        }

            .btn.btn-close:hover {
                background: #5f0d0d;
            }

        .btn.btn-close-full {
            float: right;
            background: #7bb1c7;
            color: #fff;
            margin: 20px 5px;
            text-transform: none;
            padding: 10px 20px;
            width: unset;
        }

            .btn.btn-close-full:hover {
                background: #435156;
            }
    </style>
</asp:Content>
