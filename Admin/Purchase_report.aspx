﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Purchase_report.aspx.cs" Inherits="Admin_Purchase_report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html lang="en">
    <head id="Head1" runat="server">
         <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
        <title>Dream Garments</title>
      

              <script type="text/javascript">

                  $(document).ready(function () {

                      $(".selectpicker").selectpicker();

                  });

                 </script>


        <!-- Bootstrap -->
          <script src="bootstrap/js/jquery-3.1.1.min.js"></script>

          <script src="bootstrap/js/bootstrap-select.js"></script>
           <link href="bootstrap/css/bootstrap-select.css" rel="stylesheet" />
           <link rel="stylesheet" type="text/css" media="screen" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.7.5/css/bootstrap-select.min.css">
         <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
        <link href="css/waves.min.css" type="text/css" rel="stylesheet">
        <!--        <link rel="stylesheet" href="css/nanoscroller.css">-->
        <link href="css/menu.css" type="text/css" rel="stylesheet">
        <link href="css/style.css" type="text/css" rel="stylesheet">
        <link href="css1/Stock_Inventorycss.css" type="text/css" rel="stylesheet">
        <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet">
        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
          <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->

    </head>
    <body>
        <!-- Static navbar -->
 <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        
</asp:ToolkitScriptManager>
    <div>
        <nav class="navbar navbar-inverse yamm navbar-fixed-top">
            <div class="container-fluid">
                <button type="button" class="navbar-minimalize minimalize-styl-2  pull-left "><i class="fa fa-bars"></i></button>
                <span class="search-icon"><i class="fa fa-search"></i></span>
                <div class="search" style="display: none;">
                    <form1 role="form">
                        <input type="text" class="form-control" autocomplete="off" placeholder="Write something and press enter">
                        <span class="search-close"><i class="fa fa-times"></i></span>
                    </form1>
                </div>
                  <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">Dream Garments</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="dropdown">
                           
                         <li class="dropdown">
                            <a href="#" class="dropdown-toggle button-wave" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
<asp:Button ID="Button4" runat="server"  Text="ADD" class="btn btn-primary"></asp:Button> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> </a>
                            <ul class="dropdown-menu">
                                <li><a href="Main.aspx"><i class="fa fa-home fa-2x" aria-hidden="true"></i>&nbsp;&nbsp&nbsp;Category</a></li>
                                   <li role="separator" class="divider"></li>
                                <li><a href="Sub_category.aspx"><i class="fa fa-hdd-o" aria-hidden="true"></i>&nbsp;&nbsp&nbsp;Sub Category </a></li>
                                 <li role="separator" class="divider"></li>
                                <li><a href="Product_entry.aspx"><i class="fa fa-building" aria-hidden="true"></i>&nbsp;&nbsp&nbsp;Product Entry </a></li>
                                   <li role="separator" class="divider"></li>
                                <li><a href="Purchase_entry.aspx"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;&nbsp&nbsp;Purchase Entry </a></li>
                                  <li role="separator" class="divider"></li>
                                <li><a href="Stock_Inventory.aspx"><i class="fa fa-edit"></i> &nbsp;&nbsp&nbsp;Stock / Inventory </a></li>
                                 <li role="separator" class="divider"></li>
                                <li><a href="Customer-Entry.aspx"><i class="fa fa-lightbulb-o" aria-hidden="true"></i>  &nbsp;&nbsp&nbsp;New Customer Entry</a></li>

                                <li role="separator" class="divider"></li>
                                <li><a href="Vendor.aspx"><i class="fa fa-thumbs-o-up" aria-hidden="true"></i> &nbsp;&nbsp&nbsp;Supplier Entry </a></li>
                               
                                  <li role="separator" class="divider"></li>
                                <li><a href="Department-Entry.aspx"><i class="fa fa-ticket" aria-hidden="true"></i>&nbsp;&nbsp&nbsp;New Department Entry  </a></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="Sales_entry.aspx"><i class="fa fa-ticket" aria-hidden="true"></i>&nbsp;&nbsp&nbsp;Sales Entry </a></li>
                               
                            </ul>
                        </li>
                    </ul>
                          
                    <ul class="nav navbar-nav navbar-right navbar-top-drops">
                        <li class="dropdown"><a href="#" class="dropdown-toggle button-wave" data-toggle="dropdown">

</a>

                            
                        <li class="dropdown profile-dropdown">
                            <a href="#" class="dropdown-toggle button-wave" data-toggle="dropdown" role="button" ><img src="../default-profile-pic.png" alt="" width="25px"><%=User.Identity.Name%></b></span>  <span class="fa fa-caret-down" aria-hidden="true" style=""></a>
                            <ul class="dropdown-menu">
                                <li><a href="Profile_main.aspx"><i class="fa fa-user"></i>My Profile</a></li>
                                <li><a href="Seetings.aspx"><i class="fa fa-calendar"></i>Settings</a></li>                         
                                <li><a href="Advanced_Settings.aspx"><i class="fa fa-envelope"></i>Advanced Settings</a></li>
                                <li><a href="#"><i class="fa fa-barcode"></i>Custom Field</a></li>
                                <li class="divider"></li>
                               
                                 <li ><a href="#" ><asp:LinkButton id="LoginLink" Text="Log Out"  class="fa fa-sign-out" aria-hidden="true"
                      OnClick="LoginLink_OnClick" runat="server" /></a></li>
                            </ul>
                        </li>
                    </ul>
                </div><!--/.nav-collapse -->
            </div><!--/.container-fluid -->
        </nav>
        <section class="page">

            <nav class="navbar-aside navbar-static-side" role="navigation">
                <div class="sidebar-collapse nano">
                    <div class="nano-content">
                        <ul class="nav metismenu" id="side-menu">

                            <li class="active">
                                <a href="Dashboard.aspx"><i class="fa fa-home fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp;Home </span><span class="fa arrow"></span></a>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Dashboard.aspx">Dashboard </a></li>
                           </ul>
                            </li>
                            <li>
                                <a href=""><i class="fa fa-folder-open fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp;Master </span><span class="fa arrow"></span></a>
                          
                          <ul class="nav nav-second-level collapse">
                                    <li><a href="Main.aspx">Main Category</a></li>
                           </ul>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Sub_category.aspx">Brand</a></li>
                           </ul>
                            <ul class="nav nav-second-level collapse">
                                    <li><a href="Product_entry.aspx">Product Entry</a></li>
                           </ul>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Tax_Entry.aspx">Tax entry</a></li>

                           </ul>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Cutomer_type.aspx">Customer Type entry</a></li>

                           </ul>
                               
                            </li>
                           


                           

                             <li>
                                <a href="Purchase_entry.aspx"><i class="fa fa-paypal fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Purchase </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Purchase_entry.aspx">Entry</a></li>
                                     <li><a href="Purchase_report.aspx">Report</a></li>
                           </ul>
                          
                               
                            </li>

                             <li>
                                <a href="Account_ledger.aspx"><i class="fa fa-line-chart fa-2x" aria-hidden="true"></i><span class="nav-label">&nbsp;&nbsp; Accounts </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Account_ledger.aspx">Account ledger</a></li>
                                    <li><a href="Purchase_payment_outstanding.aspx">Purchase Payment status</a></li>
                           </ul>
                          
                               
                            </li>
                             <li>
                                <a href="Stock_Inventory.aspx"><i class="fa fa-clone fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Inventory </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Stock_Inventory.aspx">Product Stock</a></li>
                           </ul>
                          
                               
                            </li>
                              <li>
                                <a href="Customer-Entry.aspx"><i class="fa fa-male fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Customer </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Customer-Entry.aspx">Retail</a></li>
                           </ul>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Customer Wholesale.aspx">Wholesale</a></li>
                           </ul>
                          
                               
                            </li>
                            
                             <li>
                                <a href="Vendor.aspx"><i class="fa fa-arrows-alt fa-2x" aria-hidden="true"></i>  <span class="nav-label">&nbsp;&nbsp; Supplier </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Vendor.aspx">Entry</a></li>
                           </ul>
                          
                               
                            </li>
                             <li>
                                <a href="Department-Entry.aspx"><i class="fa fa-th fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Department </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Department-Entry.aspx">Entry</a></li>
                           </ul>
                          
                               
                            </li>
                             <li>
                                <a href="Staff-Entry.aspx"><i class="fa fa-users fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Staff </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Staff-Entry.aspx">Entry</a></li>
                           </ul>
                          
                               
                            </li>
                            
                             <li>
                                <a href="Sales_entry.aspx"><i class="fa fa-file-text-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Sales </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                  <li><a href="Sales_entry.aspx">Retail Entry</a></li>
                                     <li><a href="sales_report_details.aspx">Retail Report</a></li>
                                     <li><a href="Sales_entry_wholesales.aspx">Wholesales Entry</a></li>
                           <li><a href="Wholesales_report_details.aspx">wholesale Report</a></li>
                           </ul>
                          
                               
                            </li>
                             <li>
                                <a href="Sales_entry.aspx"><i class="fa fa-file-text-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Reports </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                   <li><a href="Day_wise_purchase.aspx">Days wise Purchase</a></li>
                                    <li><a href="Day_and_month_wise_purchase.aspx">Days and month wise purchase</a></li>
                                     <li><a href="Daily_sales.aspx">Days wise sales</a></li>
                                      <li><a href="Day_and_month_wise_report.aspx">Days and month sales</a></li>
                                      <li><a href="Staff_wise_report.aspx">Day wise staff Sales</a></li>
                                    <li><a href="Staff_wise_total _sales.aspx">day and Month wise Staff Sales</a></li>
                                     
                           </ul>
                          
                               
                            </li>
                                            
                        </ul>

                    </div>
                </div>
                
            </nav>
            <div id="wrapper">
                <div class="content-wrapper container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="page-title see2">
                                <h2>Purchase report
                                 </h2>
                             
                             
  



                                
                            </div>
                            
                        </div>
                    </div><!-- end .page title-->
                     <div class="row">
                    <div class="col-md-12">
                  




                    <div class="row see"  >


                    <div class="container">

                           <div class="container">
                        
 
  <div class="panel panel-default">
  <div class="panel-body">
   




   











</div>



  <div class="panel-body">
   




   <div class="col-md-6">

                        <div class="form-group"><label class="col-lg-3 control-label">Supplier</label>
                           <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
   <ContentTemplate>
  <asp:TextBox ID="TextBox2" runat="server" class="form-control input-x2 dropbox"  AutoPostBack="true"
           ontextchanged="TextBox2_TextChanged"></asp:TextBox>
             <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TextBox2" WatermarkText="Enter Supplier Name" ></asp:TextBoxWatermarkExtender>
                           <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1" ServiceMethod="SearchCustomers1" FirstRowSelected = "false" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TextBox2"  CompletionListCssClass="completionList"
     CompletionListItemCssClass="listItem"
     CompletionListHighlightedItemCssClass="itemHighlighted">
      </asp:AutoCompleteExtender>
                        
                                      </ContentTemplate>
                                      </asp:UpdatePanel></div></div></div>











</div>
<div class="col-lg-12">

<h4>Purchase Date  </h4>
<hr />
</div>


<div class="panel-body">
   <div class="col-md-6">

                             <div class="form-group"><label class="col-lg-3 control-label">From Date</label>

                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
   <ContentTemplate>
  
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control input-x2 dropbox"  AutoPostBack="true"
                                        ontextchanged="TextBox3_TextChanged"></asp:TextBox>
                                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox3"></asp:CalendarExtender>
                                      </ContentTemplate>
                                      </asp:UpdatePanel></div></div></div>




   <div class="col-md-6">

                        <div class="form-group"><label class="col-lg-3 control-label">To Date</label>

                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
   <ContentTemplate>
  <asp:TextBox ID="TextBox4" runat="server" class="form-control input-x2 dropbox" AutoPostBack="true" 
           ontextchanged="TextBox4_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox4"></asp:CalendarExtender>
                                      </ContentTemplate>
                                      </asp:UpdatePanel></div></div></div>











</div>



<div class="panel-body">
   <div class="col-md-6">

                             <div class="form-group"><label class="col-lg-3 control-label">purchase Invoice No</label>

                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
   <ContentTemplate>
  
                                    <asp:TextBox ID="TextBox5" runat="server" class="form-control input-x2 dropbox"  AutoPostBack="true"
                                        ></asp:TextBox>
                                     
                                      </ContentTemplate>
                                      </asp:UpdatePanel></div></div></div>



<div class="col-md-6">

                        <div class="form-group"><label class="col-lg-3 control-label">Barcode No</label>

                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
  
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control input-x2 dropbox"  AutoPostBack="true" ontextchanged="TextBox1_TextChanged"
                                        ></asp:TextBox>
                                               <asp:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" MinimumPrefixLength="1" ServiceMethod="SearchBarcode" FirstRowSelected = "false" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TextBox1"  CompletionListCssClass="completionList"
     CompletionListItemCssClass="listItem"
     CompletionListHighlightedItemCssClass="itemHighlighted">
      </asp:AutoCompleteExtender>

                                      </ContentTemplate>
                                      </asp:UpdatePanel></div></div></div>
   











</div>





</div></div>

<div class="container">

  <div class="panel panel-default">
  <div class="panel-body">
   <div class="col-md-12">
     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
   <ContentTemplate>
   <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" 
         Font-Size="16px" 
           AutoGenerateColumns="False" AllowPaging="True" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowdatabound="GridView1_RowDataBound" ForeColor="#333333" 
        GridLines="None" PageSize="20" 
           onselectedindexchanged="GridView1_SelectedIndexChanged">
       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
       <Columns>
      
               <asp:BoundField HeaderText="Purchase Invoice" DataField="purchase_invoice"  />
           <asp:BoundField HeaderText="Date" DataField="date" DataFormatString="{0:dd/MM/yyyy}"  />
           <asp:BoundField HeaderText="Supplier" DataField="Supplier" />
             <asp:BoundField HeaderText="Total amount" DataField="total_amount" />
            
             <%-- <asp:BoundField HeaderText="Paid Amount" DataField="paid_amount" />
               <asp:BoundField HeaderText="Pending amount" DataField="pending_amount" />--%>
              <asp:TemplateField>
              <ItemTemplate>
              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/edit4.jpg" 
                      Width="20px" Height="20px" onclick="ImageButton1_Click" ></asp:ImageButton>
              </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField>
              <ItemTemplate>
             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Admin/show1.png" 
                      Width="100px" Height="20px" onclick="ImageButton2_Click"></asp:ImageButton>
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
              <ItemTemplate>
              <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/delete3.png"  
                      Width="20px" Height="20px" onclick="ImageButton3_Click" ></asp:ImageButton>
              </ItemTemplate>
              </asp:TemplateField>
                 
       </Columns>
       <EditRowStyle BackColor="#999999" />
       <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
       <HeaderStyle Height="40px" BackColor="#fafbfc" Font-Bold="True" CssClass="red" ForeColor="#656565" />
       <PagerSettings FirstPageText="First" LastPageText="Last" />
       <PagerStyle Wrap="true" BorderStyle="Solid" Width="100%" 
           CssClass="gvwCasesPager" BackColor="#284775" ForeColor="White" 
           HorizontalAlign="Center" />
       <RowStyle Height="40px" BackColor="white" ForeColor="#333333" />
       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
       <SortedAscendingCellStyle BackColor="#E9E7E2" />
       <SortedAscendingHeaderStyle BackColor="#506C8C" />
       <SortedDescendingCellStyle BackColor="#FFFDF8" />
       <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
       </asp:GridView>

        </ContentTemplate>
                                     <Triggers>
              
                
                     <asp:AsyncPostBackTrigger ControlID="TextBox2" EventName="TextChanged"  />
                     
                        <asp:AsyncPostBackTrigger ControlID="TextBox4" EventName="TextChanged"  />
                   
                  
                  </Triggers>
              
                
               
              
                           </asp:UpdatePanel>
</div></div></div></div>



</div></div></div></div></div></div>

                
                   
                  
                           
        </section>

        <script type="text/javascript" src="js/jquery.min.js"></script>
        <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
        <script src="js/metisMenu.min.js"></script>
        <script src="js/jquery-jvectormap-1.2.2.min.js"></script>
        <!-- Flot -->
        <script src="js/flot/jquery.flot.js"></script>
        <script src="js/flot/jquery.flot.tooltip.min.js"></script>
        <script src="js/flot/jquery.flot.resize.js"></script>
        <script src="js/flot/jquery.flot.pie.js"></script>
        <script src="js/chartjs/Chart.min.js"></script>
        <script src="js/pace.min.js"></script>
        <script src="js/waves.min.js"></script>
        <script src="js/jquery-jvectormap-world-mill-en.js"></script>
        <!--        <script src="js/jquery.nanoscroller.min.js"></script>-->
        <script type="text/javascript" src="js/custom.js"></script>
        <script type="text/javascript">
            $(function () {

                var barData = {
                    labels: ["January", "February", "March", "April", "May", "June", "July"],
                    datasets: [
                        {
                            label: "My First dataset",
                            fillColor: "rgba(220,220,220,0.5)",
                            strokeColor: "rgba(220,220,220,0.8)",
                            highlightFill: "rgba(220,220,220,0.75)",
                            highlightStroke: "rgba(220,220,220,1)",
                            data: [65, 59, 80, 81, 56, 55, 40]
                        },
                        {
                            label: "My Second dataset",
                            fillColor: "rgba(14, 150, 236,0.5)",
                            strokeColor: "rgba(14, 150, 236,0.8)",
                            highlightFill: "rgba(14, 150, 236,0.75)",
                            highlightStroke: "rgba(14, 150, 236,1)",
                            data: [28, 48, 40, 19, 86, 27, 90]
                        }
                    ]
                };

                var barOptions = {
                    scaleBeginAtZero: true,
                    scaleShowGridLines: true,
                    scaleGridLineColor: "rgba(0,0,0,.05)",
                    scaleGridLineWidth: 1,
                    barShowStroke: true,
                    barStrokeWidth: 2,
                    barValueSpacing: 5,
                    barDatasetSpacing: 1,
                    responsive: true
                };


                var ctx = document.getElementById("barChart").getContext("2d");
                var myNewChart = new Chart(ctx).Bar(barData, barOptions);

            });
        </script>
        <!-- Google Analytics:  -->
        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r;
                i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments);
                }, i[r].l = 1 * new Date();
                a = s.createElement(o),
                        m = s.getElementsByTagName(o)[0];
                a.async = 1;
                a.src = g;
                m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
            ga('create', 'UA-3560057-28', 'auto');
            ga('send', 'pageview');
        </script>
        </form>
    </body>
</html>



