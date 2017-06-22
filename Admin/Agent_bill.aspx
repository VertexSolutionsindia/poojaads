<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agent_bill.aspx.cs" Inherits="Admin_Agent_bill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html lang="en">
    <head id="Head1" runat="server">
         <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
        <title>Pooja Advertising</title>
      

              <script type="text/javascript">

                  $(document).ready(function () {

                      $(".selectpicker").selectpicker();

                  });

                 </script>
                 <style>
                 .tablestyles table tr td
                 {
                    padding:5px; 
                 }
                 
                 </style>


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
          <link href="css1/Staff-Entrycss.css" type="text/css" rel="stylesheet">
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
                    <form role="form">
                        <input type="text" class="form-control" autocomplete="off" placeholder="Write something and press enter">
                        <span class="search-close"><i class="fa fa-times"></i></span>
                    </form>
                </div>
                  <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                  <%--  <ul class="nav navbar-nav">
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
                               
                            </ul>--%>
                    <%--    </li>
                    </ul>--%>
                          
                    <ul class="nav navbar-nav navbar-right navbar-top-drops">
                        <li class="dropdown"><a href="#" class="dropdown-toggle button-wave" data-toggle="dropdown">

</a>

                            
                        <li class="dropdown profile-dropdown">
                            <a href="#" class="dropdown-toggle button-wave" data-toggle="dropdown" role="button" ><img src="../default-profile-pic.png" alt="" width="25px"><%=User.Identity.Name%></b></span>  <span class="fa fa-caret-down" aria-hidden="true" style=""></a>
                            <ul class="dropdown-menu">
                  <%--              <li><a href="Profile_main.aspx"><i class="fa fa-user"></i>My Profile</a></li>
                                <li><a href="Seetings.aspx"><i class="fa fa-calendar"></i>Settings</a></li>                         
                                <li><a href="Advanced_Settings.aspx"><i class="fa fa-envelope"></i>Advanced Settings</a></li>
                                <li><a href="#"><i class="fa fa-barcode"></i>Custom Field</a></li>
                                <li class="divider"></li>--%>
                               
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
                                <a href="#"><i class="fa fa-folder-open fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp;Master </span><span class="fa arrow"></span></a>
                          
                          <ul class="nav nav-second-level collapse">
                                    <li><a href="Service_Type.aspx">Service Type</a></li>
                           </ul>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Service_name.aspx">Service Name</a></li>
                           </ul>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Location.aspx">Location</a></li>
                           </ul>
                            <ul class="nav nav-second-level collapse">
                                    <li><a href="Tax_Entry.aspx">Tax Entry</a></li>
                           </ul>
                              <ul class="nav nav-second-level collapse">
                                    <li><a href="Partners_entry.aspx">Partner Entry</a></li>
                           </ul>
                            
                             
                               
                            </li>
                             <li>
                                <a href="#"><i class="fa fa-male fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Customers </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Agent-Entry.aspx">Agent Entry</a></li>
                           </ul>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Client_Entry.aspx">Client Entry</a></li>
                           </ul>
                          
                               
                            </li>
                             <li>
                                <a href="#"><i class="fa fa-users fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Staff </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Staff-Entry.aspx">Staff Entry</a></li>
                           </ul>
                          
                               
                            </li>
                           
                              <li>
                                <a href="#"><i class="fa fa-arrow-right fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Expenses </span><span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level collapse">
                                    <li><a href="ExpenseName_Entry.aspx">Expense Name Entry</a></li>
                           </ul>
                            <ul class="nav nav-second-level collapse">
                                <li><a href="Expense_entry.aspx">Expense Entry</a></li>
                            </ul>
                          
                               
                            </li>
                                   <li>
                                <a href="#"><i class="fa fa-check-square-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Bank Details</span><span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level collapse">
                                    <li><a href="Account_Entry.aspx">Account Entry</a></li>
                           </ul>
                           
                          
                               
                            </li>

                             <li>
                                <a href="#"><i class="fa fa-arrow-right fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Accounts </span><span class="fa arrow"></span></a>
                               <ul class="nav nav-second-level collapse">
                                    <li><a href="Account_ledger.aspx">Account ledger</a></li>
                           </ul>
                             <ul class="nav nav-second-level collapse">
                             <li><a href="profit_loss.aspx">Profit & loss</a></li>  
                            </ul>
                          
                               
                            </li>
                         
                              <li>
                                <a href="#"><i class="fa fa-arrow-left fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Agent bill</span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Agent_bill.aspx">Agent bill</a></li>
                                   <li><a href="Agent_bill_report.aspx">Agent bill report</a></li>
                                    <li><a href="agent_bill_payment_outstanding.aspx">Agent bill Outstanding</a></li>
                           </ul>
                          
                               
                            </li>
                            
                            
                           
                             <li>
                                <a href="#"><i class="fa fa-arrow-left fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Order</span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Order_entry.aspx">Order Entry</a></li>
                                    <li><a href="Oreders_Report.aspx">Orders Report</a></li>
                                    <li><a href="Order_bill_payment_outstanding.aspx">Order bill Oustanding</a></li>
                           </ul>
                          
                               
                            </li>
                            
                            
                             <li>
                                <a href="#"><i class="fa fa-file-text-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Estimate </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                   
                                     <li><a href="Estimate_entry.aspx">Estimate Entry</a></li>
                                      <li><a href="Estimate_report.aspx">Estimates Report</a></li>
                                    
                           </ul>
                          
                               
                            </li>

                             <li>
                                <a href="#"><i class="fa fa-file-text-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Inventory </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Inventory_entry.aspx">Inventory Entry</a></li>
                                     
                                    
                           </ul>
                          
                               
                            </li>
                            <li>
                                <a href="#"><i class="fa fa-file-text-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Reports </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                   <li><a href="Expenses_Report.aspx">Expenses Report</a></li>
                                    <li><a href="Service_report.aspx">Service Report</a></li>
                         
                                     
                                     
                           </ul>
                          
                               
                            </li>
                                            
                        </ul>

                    </div>
                </div>
                
            </nav>
            <div id="wrapper">
                <div class="content-wrapper container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-1">
                            <div class="page-title see2">
                                <h1>Ajent Bill Entry
                                 </h1>
                             <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                              <asp:UpdatePanel ID="UpdatePanel17" runat="server">
   <ContentTemplate>
   <asp:Button ID="Button8" runat="server"  Text="New" Width="70px" Height="30px" onclick="Button8_Click" 
           ></asp:Button>
   <asp:Button ID="Button6" runat="server"  Text="<" Width="70px" Height="30px" onclick="Button6_Click" 
           ></asp:Button>
  <asp:Button ID="Button7" runat="server"  Text=">" Width="70px" Height="30px" onclick="Button7_Click" 
           ></asp:Button>
       <asp:Button ID="Button9" runat="server"  Text="Save" Width="70px" Height="30px" 
           onclick="Button9_Click" ></asp:Button>   
        <asp:Button ID="Button10" runat="server"  Text="Clear" Width="70px" 
           Height="30px" onclick="Button10_Click"></asp:Button>
         <asp:Button ID="Button11" runat="server"  Text="View" Width="70px" 
           Height="30px" onclick="Button11_Click" ></asp:Button>
           </ContentTemplate>
                              </asp:UpdatePanel>
  

  <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
<asp:Button ID="Button2" runat="server" Text="Button" style="display:none" />
        <asp:Panel ID="panelup" runat="server" class="panel0" BorderColor="Black" BorderStyle="Solid" BackColor="White" Direction="LeftToRight" style="display:none" 
                         HorizontalAlign="Left" ScrollBars="Both" Width="800px" Height="300px"  >
         <div style="padding:12px; border:1px solid #e5e5e5;   border-radius:10px; background-color:#E6E6FA;color:#233445; font-size:15px; font-weight:400px; font-family: 'Open Sans',"HelveticaNeue", "Helvetica Neue", Helvetica, Arial,sans-serif; ">
                     <h3 style="font-size:20px; " class="control-label"> View list  <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/exit11.png" width="30px" height="30px" style="float:right" /></h3>
  
           
        </div>
        <div class="tablestyles1">
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" Width="100%">
                   
                   <Columns>
                 
                   <asp:BoundField HeaderText="Bill No" DataField="bill_no" HeaderStyle-CssClass="col-lg-3 control-label" FooterStyle-CssClass="col-lg-3 control-label"  />
           
               <asp:BoundField HeaderText="Date" DataField="bill_date" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="col-lg-3 control-label" FooterStyle-CssClass="col-lg-3 control-label" />
                 <asp:BoundField HeaderText="Agent name" DataField="agent_name" HeaderStyle-CssClass="col-lg-3 control-label" FooterStyle-CssClass="col-lg-3 control-label" />
                   <asp:BoundField HeaderText="Agent Address" DataField="agent_add" HeaderStyle-CssClass="col-lg-3 control-label" FooterStyle-CssClass="col-lg-3 control-label" />
                    <asp:BoundField HeaderText="Service Name" DataField="service_name" HeaderStyle-CssClass="col-lg-3 control-label" FooterStyle-CssClass="col-lg-3 control-label" />
                  
                     <asp:TemplateField>
                   <ItemTemplate>
                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/edit4.jpg" Width="20px" Height="20px" onclick="ImageButton1_Click"></asp:ImageButton>

                   </ItemTemplate>
                   
                   </asp:TemplateField>
                   </Columns>
                   
                   </asp:GridView>  
        </div>

        </asp:Panel>
       <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button2" PopupControlID="panelup" CancelControlID="ImageButton4" BackgroundCssClass="modelbackground">
        </asp:ModalPopupExtender>     

         </ContentTemplate>
                            
                           </asp:UpdatePanel>

                                
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
  <br /><h2>Agent Details Here</h2>
  <hr />
   <div class="col-md-6">
                 <div class="panel-body">
                           <div class="form-horizontal">
                               <br />
                               <div class="form-group"><label class="col-lg-3 control-label">Bill No : </label>

                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
   <ContentTemplate>
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
                                      </ContentTemplate>
                                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="form-group"><label class="col-lg-3 control-label">Bill Date : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control input-x2 dropbox"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox3" Format="dd-MM-yyyy"></asp:CalendarExtender>
                                    </ContentTemplate>
                                     <Triggers>
         <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                                           <div class="form-group"><label class="col-lg-3 control-label">Agent Name : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
   <ContentTemplate>
                                 
                                       
                                        <asp:DropDownList ID="DropDownList1" runat="server"  
                                        class="form-control input-x2 dropbox" 
                                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                    </ContentTemplate>
                                     <Triggers>
           <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>


                                
                                
                                </div>


                                                                                           <div class="form-group"><label class="col-lg-3 control-label">Agent Address : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel13" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control input-x2 dropbox" 
                                        ></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
             <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>


                                
                                
                                </div>

               <div class="form-group"><label class="col-lg-3 control-label">From and To date : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel16" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox10" runat="server"  width="200px"  
                                        ></asp:TextBox>
<asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox10" Format="dd-MM-yyyy"></asp:CalendarExtender>
                                        <asp:TextBox ID="TextBox11" runat="server" width="200px"    
                                        ></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox11" Format="dd-MM-yyyy"></asp:CalendarExtender>
                                    </ContentTemplate>
                                     <Triggers>
              <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>


                                
                                
                                </div>





               
                           


  <div class="form-group"><label class="col-lg-3 control-label">Service Type : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel14" runat="server">
   <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList3" runat="server" 
                                        class="form-control input-x2 dropbox" AutoPostBack="true"
                                        onselectedindexchanged="DropDownList3_SelectedIndexChanged" ></asp:DropDownList>
                                    </ContentTemplate>
                                     <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                <div class="form-group"><label class="col-lg-3 control-label">Location : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList4" runat="server" class="form-control input-x2 dropbox" AutoPostBack="true" onselectedindexchanged="DropDownList4_SelectedIndexChanged" ></asp:DropDownList>
                                     
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control input-x2 dropbox"></asp:TextBox>
                                  
                                    </ContentTemplate>
                                     <Triggers>
             <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                   
                                  </div>
                                
                                </div>
                                <div class="form-group"><label class="col-lg-3 control-label">Size : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-x2 dropbox"></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                <div class="form-group"><label class="col-lg-3 control-label">Bill Amount : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control input-x2 dropbox"></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                  <div class="form-group"><label class="col-lg-3 control-label">Paid amount : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control input-x2 dropbox" ontextchanged="TextBox7_TextChanged" AutoPostBack="true"  ></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                  <div class="form-group"><label class="col-lg-3 control-label">Pending amt : </label>
                              
                                    <div class="col-lg-9">
                                     <asp:UpdatePanel ID="UpdatePanel15" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control input-x2 dropbox"></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click"  />
                    <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click"  />
                      <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click"  />
                        <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"  />
                           <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                 </div>
                      </div>
                     

    </div>
                                        <!-- End .form-group  -->
                                        
                                       
                                       
                                        
                                   
                                </div>
                                 
                            </div><!-- End .panel -->  




                     



                        </div>
                        <br />
                        <br />
                                                 
  
</div>
                                        <!-- End .form-group  -->
                                        
                                       
                                       
                                        
                                    
                                </div>
                            </div><!-- End .panel --> 
                      
                        



                        </div>
                      


                        
                    </div><!--end .row-->

                  
                  
                        </div>
                   
                   
    </div>
                        </div>
                        </div>
                        </div>
                        </div>
                        

                
                   
                  
                           
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



