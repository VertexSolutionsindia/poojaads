<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventory_entry.aspx.cs" Inherits="Admin_Vendor" %>
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
                  <script type="text/javascript" language="javascript">
                      function controlEnter(obj, event) {
                          var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
                          if (keyCode == 13) {
                              document.getElementById(obj).focus();
                              return false;
                          }
                          else {
                              return true;
                          }
                      }
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
        <link href="css1/Vendorcss.css" type="text/css" rel="stylesheet">
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
                    <a class="navbar-brand" href="#">Pooja Advertising</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                <%--    <ul class="nav navbar-nav">
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
                    </ul>--%>
                          
                    <ul class="nav navbar-nav navbar-right navbar-top-drops">
                        <li class="dropdown"><a href="#" class="dropdown-toggle button-wave" data-toggle="dropdown">

</a>

                            
                        <li class="dropdown profile-dropdown">
                            <a href="#" class="dropdown-toggle button-wave" data-toggle="dropdown" role="button" ><img src="../default-profile-pic.png" alt="" width="25px"><%=User.Identity.Name%></b></span>  <span class="fa fa-caret-down" aria-hidden="true" style=""></a>
                            <ul class="dropdown-menu">
                     <%--           <li><a href="Profile_main.aspx"><i class="fa fa-user"></i>My Profile</a></li>
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
                                <h1>Ad Display Management
                                 </h1>
                             
                             
  



                                
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
  <br /><h2>Enter Management Details Here</h2><hr />
   <div class="col-md-6">
                 <div class="panel-body">
                           <div class="form-horizontal">
                               <br />
                               

                               <div class="form-group"><label class="col-lg-4 control-label">Inventory No : </label>

                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
   <ContentTemplate>
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
                                      </ContentTemplate>
                                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="form-group"><label class="col-lg-4 control-label">Taxi Company: </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
  <ContentTemplate>
   
                                 <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" onselectedindexchanged="TextBox3_SelectedIndexChanged"></asp:TextBox>
                              
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                


                                                           <div class="form-group"><label class="col-lg-4 control-label">Taxi No : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control input-x2 dropbox" 
                                        AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                                                                          <div class="form-group"><label class="col-lg-4 control-label">Taxi Driver Name : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel19" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox18" runat="server" class="form-control input-x2 dropbox" 
                                       AutoPostBack="True"  ></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                                                                          <div class="form-group"><label class="col-lg-4 control-label">Taxi Driver No : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel20" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox19" runat="server" class="form-control input-x2 dropbox" 
                                     AutoPostBack="True"    ></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                 <div class="form-group"><label class="col-lg-4 control-label">Type of  Service: </label>
                              
                                    <div class="col-lg-5">
                                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" 
                                        data-width="100%"  AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                     <div class="col-lg-3 ad"><br /><a href="Service_Entry.aspx">New Service</a></div>
                                
                                
                                </div>


                                 <div class="form-group"><label class="col-lg-4 control-label">Service Name : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel21" runat="server">
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList6" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true"  onselectedindexchanged="DropDownLis6_SelectedIndexChanged" ></asp:DropDownList>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                <div class="form-group"><label class="col-lg-4 control-label">Add Duration FROM: </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control input-x2 dropbox"></asp:TextBox>
                                   
                                                                       <asp:CalendarExtender ID="dtpTransDate_CalendarExtender" runat="server" 
  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox11">
  </asp:CalendarExtender>
                                   
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                <div class="form-group"><label class="col-lg-4 control-label">TO : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control input-x2 dropbox"></asp:TextBox>
                                                                       <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox12">
  </asp:CalendarExtender>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                                                 <div class="form-group"><label class="col-lg-4 control-label">Cost :  </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel17" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control input-x2 dropbox"></asp:TextBox>

                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                                                 <div class="form-group"><label class="col-lg-4 control-label">Due Date :  </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel18" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox17" runat="server" class="form-control input-x2 dropbox"></asp:TextBox>
                                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox17">
  </asp:CalendarExtender>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                 <div class="form-group"><label class="col-lg-4 control-label">Advance : </label>
                              
                                    <div class="col-lg-4">
                                     <asp:UpdatePanel ID="UpdatePanel13" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox13" runat="server" 
                                        class="form-control input-x2 dropbox" 
                                        onselectedindexchanged="TextBox13_SelectedIndexChanged" AutoPostBack="True" 
                                        ontextchanged="TextBox13_TextChanged"></asp:TextBox>
                                    
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                </div>

                                                    <div class="form-group"><label class="col-lg-4 control-label">Balance : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel22" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox20" runat="server"  Enabled="False"
                                        class="form-control input-x2 dropbox"></asp:TextBox>
                                    </ContentTemplate>
                                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                  <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"  />
                </Triggers>
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                          
                             
                                                          
                                 
                               
                            </div>
                      </div>
                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
   <ContentTemplate>

                      <asp:Button ID="Button1" runat="server" class="btn-primary" Width="70px" Height="30px"  Text="Save" onclick="Button1_Click" 
                          ></asp:Button>&nbsp;
 <asp:Button ID="Button2" runat="server" class="btn-primary2" Width="70px" Height="30px"  Text="Clear" onclick="Button2_Click" 
                          ></asp:Button>&nbsp;
                           <asp:Button ID="Button3" runat="server" class="btn-primary2" Width="70px" Height="30px"  Text="Cancel" onclick="Button2_Click" 
                          ></asp:Button>
                          </ContentTemplate>
                           </asp:UpdatePanel>
                            </asp:Panel>

    </div>
                                        <!-- End .form-group  -->
                                        
                                       
                                       
                                        
                                   
                                </div>
                                 
                            </div><!-- End .panel -->  

                        



                        </div>
                    <br />
                          <div class="panel panel-default">
  <div class="panel-body">
  <div class="col-md-12">
  <br /> <div class="row">
    <div class="col-md-1" ><h2>Filters</h2>
 
 </div>
 </div>
 <hr />
  <div class="row">
  <div class="col-sm-12">

    <div class="col-sm-6">
   <div class="col-md-4"><h3>Taxi Company :  </h3></div>
   
    <div class="col-md-6"><asp:UpdatePanel ID="UpdatePanel15" runat="server">
   <ContentTemplate>

   <asp:DropDownList ID="DropDownList2" runat="server"  class="form-control input-x2 dropbox" data-style="btn-primary1" data-width="100%" AutoPostBack="true" onselectedindexchanged="DropDownList2_SelectedIndexChanged"  ></asp:DropDownList>
    </ContentTemplate>
                           </asp:UpdatePanel></div>
   
   </div>

    <div class="col-sm-6">
   <div class="col-md-4"><h3>Taxi No:  </h3></div>
   
    <div class="col-md-6"><asp:UpdatePanel ID="UpdatePanel7" runat="server">
   <ContentTemplate>

   <asp:DropDownList ID="DropDownList5" runat="server"  class="form-control input-x2 dropbox" data-style="btn-primary1" data-width="100%" AutoPostBack="true" onselectedindexchanged="DropDownList5_SelectedIndexChanged"></asp:DropDownList>
    </ContentTemplate>
                           </asp:UpdatePanel></div>
   
   </div></div></div></div>
    </div>

                                        <!-- End .form-group  -->
                                        
                                       
                                       
                                        
                                   
                                </div>
                                 
                            </div><!-- End .panel -->

                         <div class="container">
 
  <div class="panel panel-default">
  <div class="panel-body">
                        <div class="col-md-12" >
                                <div class="panel-heading">
                                    <h3 class="panel-title">Show &nbsp;<asp:DropDownList ID="DropDownList4" runat="server" class="dropbox1" style="margin-top:10px;">
                                    <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                        <asp:ListItem>200</asp:ListItem>
                                        <asp:ListItem>300</asp:ListItem>
                                        <asp:ListItem>400</asp:ListItem>
                                        <asp:ListItem>500</asp:ListItem>
                                        <asp:ListItem>700</asp:ListItem>
                                        <asp:ListItem>1000</asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                    
                                    
                                    </asp:DropDownList>&nbsp; Entries </h3>
                                    <hr />
                                    <div class="panel-actions">
                                        <a href="#" class="panel-action panel-action-toggle" data-panel-toggle></a>
                                        <a href="#" class="panel-action panel-action-dismiss" data-panel-dismiss></a>
                                    </div>
                                </div>

                                <div class="panel-body">
                                   
                                       <div class="col-md-3">

</div>
<div class="container">
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   <div class="container">
   <div class="row"><div class="col-sm-12">
   
   <div style="overflow: scroll">
   <asp:GridView ID="GridView1" runat="server" CssClass="red red2"  CellPadding="3" 
         Font-Size="16px" 
           AutoGenerateColumns="False" AllowPaging="True" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowdatabound="GridView1_RowDataBound" PageSize="10" 
           onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" 
           BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
       <Columns>
        <asp:TemplateField>
           
           <ItemTemplate>
               <asp:CheckBox ID="CheckBox3" runat="server" />
            </ItemTemplate>
           
           </asp:TemplateField>
         
           <asp:BoundField HeaderText="ID" ItemStyle-Width="5%" 
               DataField="Invent_No"  >
           <HeaderStyle CssClass="red" />
           <ItemStyle Width="5%" />
           </asp:BoundField>
           <asp:BoundField HeaderText="Company" ItemStyle-Width="12%" 
               DataField="Taxi_Com" >
           <HeaderStyle CssClass="red" />
           <ItemStyle Width="12%" />
           </asp:BoundField>
           <asp:BoundField HeaderText="Taxi No" ItemStyle-Width="15%" 
               DataField="Taxi_No"  >
             <HeaderStyle CssClass="red" />
             <ItemStyle Width="15%" />
           </asp:BoundField>
             <asp:BoundField HeaderText="Driver Name" ItemStyle-Width="10%" 
               DataField="Taxi_Drv_nme"  >
               <HeaderStyle CssClass="red" />
               <ItemStyle Width="10%" />
           </asp:BoundField>
               <asp:BoundField HeaderText="Phone" ItemStyle-Width="10%" 
               DataField="Taxi_Drvr_No"  >
                 <HeaderStyle CssClass="red" />
                 <ItemStyle Width="10%" />
           </asp:BoundField>
                 <asp:BoundField HeaderText="Service" ItemStyle-Width="12%" 
               DataField="Serv_name"  >
                   <HeaderStyle CssClass="red" />
                   <ItemStyle Width="12%" />
           </asp:BoundField>
                   <asp:BoundField HeaderText="From" ItemStyle-Width="12%" 
               DataField="Durationfrm" DataFormatString="{0:dd/MM/yyyy}" > 
                   <HeaderStyle CssClass="red" />
                   <ItemStyle Width="12%" />
           </asp:BoundField>
                   <asp:BoundField HeaderText="To" ItemStyle-Width="8%" 
               DataField="durationto"  >
           <HeaderStyle CssClass="red" />
           <ItemStyle Width="8%" />
           </asp:BoundField>
           <asp:BoundField HeaderText="Price" ItemStyle-Width="15%" DataField="cost" >
            <HeaderStyle CssClass="red" />
            <ItemStyle Width="15%" />
           </asp:BoundField>
            <asp:BoundField HeaderText="Due Date" ItemStyle-Width="10%" DataField="due_date" >
            <HeaderStyle CssClass="red" />
           <ItemStyle Width="10%" />
           </asp:BoundField>
            <asp:BoundField HeaderText="Advance" ItemStyle-Width="30%" DataField="advance" >
            <HeaderStyle CssClass="red" />
            <ItemStyle Width="30%" />
           </asp:BoundField>
            <asp:BoundField HeaderText="Balance" ItemStyle-Width="30%" DataField="balance" >
            <HeaderStyle CssClass="red" />
            <ItemStyle Width="30%" />
           </asp:BoundField>
            <asp:TemplateField>
          <ItemTemplate>
            
          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/edit4.jpg" Height="20px" Width="20px" onclick="ImageButton1_Click"  ></asp:ImageButton>
          </ItemTemplate>
          
          </asp:TemplateField>
           <asp:TemplateField>
          <ItemTemplate>
              <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/delete3.png" Height="20px" Width="20px"  onclick="ImageButton9_Click" />
          
          </ItemTemplate>
          
          </asp:TemplateField>
       </Columns>
       <FooterStyle BackColor="White" ForeColor="#000066" />
       <HeaderStyle Height="40px" BackColor="#006699" Font-Bold="True" CssClass="red" 
           ForeColor="White" />
       <PagerSettings FirstPageText="First" LastPageText="Last" />
       <PagerStyle Wrap="true" BorderStyle="Solid" Width="100%" 
           CssClass="gvwCasesPager" BackColor="White" ForeColor="#000066" 
           HorizontalAlign="Left" />
       <RowStyle Height="40px" ForeColor="#000066" />
       <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
       <SortedAscendingCellStyle BackColor="#F1F1F1" />
       <SortedAscendingHeaderStyle BackColor="#007DBB" />
       <SortedDescendingCellStyle BackColor="#CAC9C9" />
       <SortedDescendingHeaderStyle BackColor="#00547E" />
       </asp:GridView></div></div></div></div>
  </ContentTemplate>
    <Triggers>
               <asp:AsyncPostBackTrigger ControlID="GridView1"  />
                 <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"  />
                 
                   <asp:AsyncPostBackTrigger ControlID="Button16" EventName="Click"  />
                     <asp:AsyncPostBackTrigger ControlID="Button17" EventName="Click"  />
                       <asp:AsyncPostBackTrigger ControlID="Button14" EventName="Click"  />
                 <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged"  /> 
                  
               
                </Triggers>
    </asp:UpdatePanel>



     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
   <ContentTemplate>
 <br />   <asp:Button ID="Button14" runat="server" Text="Delete Seleted Rows" CssClass="buttonbox" OnClientClick="return validate1()" onclick="Button14_Click"/>
       
       <asp:Button ID="Button5" runat="server" CssClass="buttonbox2" Text="Export To Excel" 
           onclick="Button5_Click"></asp:Button>
       
       
        <asp:Button ID="Button15" runat="server" Text="Button" style="display:none" />
  
  
    <asp:Panel ID="Panel2" runat="server" class="panel1" BorderColor="Black" BorderStyle="Solid" BackColor="White" Direction="LeftToRight" style="display:none;" 
                         HorizontalAlign="Left" ScrollBars="Both" Width="500px" Height="400px" >
    
       
       <div style="padding:12px; border:1px solid #e5e5e5;   border-radius:10px; background-color:#C0C0C0; color:#003300; font-size:15px; font-weight:400px; font-family: 'Open Sans'"
            HelveticaNeue", "Helvetica Neue", Helvetica, Arial,sans-serif; ">
                     <h3 style="font-size:20px; " class="control-label"> Update Inventory  <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/exit11.png" width="30px" height="30px" style="float:right" /></h3>
  
  
         
        </div>
        <div class="tablestyles">
        <table>
       
        <tr>
        <td>
            <asp:Label ID="Label28" runat="server" Text=" Id" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:Label ID="Label29" runat="server" Text="" ></asp:Label></td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Company" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server"  class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label30" runat="server" Text="Taxi No" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox16" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
     <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Driver Name" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
         <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Driver NO" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
         <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Service Name" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
         <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="From" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox9" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
                                                                                  <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox9">
  </asp:CalendarExtender>
        </tr>
         <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="To" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>

            <asp:TextBox ID="TextBox10" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
                                                                                          <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox10">
  </asp:CalendarExtender>
        </tr>
                 <tr>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Cost" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
                 <tr>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Due Date" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox14" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
                                                                                          <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox14">
  </asp:CalendarExtender>
        </tr>
                 <tr>
        <td>
            <asp:Label ID="Label11" runat="server" Text="Advance" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox15" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
           <tr>
        <td>
            <asp:Label ID="Label12" runat="server" Text="Balance" Width="200px" class="col-lg-3 control-label"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox21" runat="server"   class="form-control input-x2 dropbox"></asp:TextBox></td>
        </tr>
       
        
                    
       
        </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="Button16" runat="server" onclick="Button16_Click" CssClass="btn-primary" 
                                style="height: 26px" Text="Update" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="Button17" runat="server" onclick="Button17_Click" Visible="false" 
                                Text="Delete" />
                            &nbsp;&nbsp;&nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Label ID="Label31" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
       </div>

        </asp:Panel>
       <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="Button15" PopupControlID="Panel2" CancelControlID="ImageButton6" BackgroundCssClass="modelbackground">
        </asp:ModalPopupExtender>


        </ContentTemplate>
    <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1"  />
                  <asp:AsyncPostBackTrigger ControlID="Button16" EventName="Click"  />
                     <asp:AsyncPostBackTrigger ControlID="Button17" EventName="Click"  />
                       <asp:AsyncPostBackTrigger ControlID="Button14" EventName="Click"  />
                </Triggers>
    </asp:UpdatePanel>
  
</div>
                                        <!-- End .form-group  -->
                                        
                                       
                                       
                                        
                                    
                                </div>
                            </div><!-- End .panel --> 
                      
                        



                        </div>
                      

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


