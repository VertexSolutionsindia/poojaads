<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Estimate_entry.aspx.cs" Inherits="Admin_Sales_entry" %>

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
                 </style>
 <script type="text/javascript" language="javascript">
     document.getElementById("TextBox15")
    .addEventListener("keyup", function (event) {
        event.preventDefault();
        if (event.keyCode == 13) {
            document.getElementById("Button3").click();
        }
    });


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
.tablestyle table
{
    text-align:center;
}
.tablestyle table  th
{
    padding:8px;
   
}
.tablestyle table  td
{
    padding:8px;
}
</style>
<style>
.tablestyles table tr td
{
    padding:5px;
}
.tablestyles1 table tr td
{
    padding:10px;
}
</style>
<script type="text/javascript" language="javascript">
    document.getElementById("TextBox5")
    .addEventListener("keyup", function (event) {
        event.preventDefault();
        if (event.keyCode == 13) {
            document.getElementById("Button1").click();
        }
    });


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
        <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet"> 
        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
          <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->
         <style>
    
      .red
            {
                text-align:center;
                font-size:15px;
            }
            .goo
            {
               color:#13c4a5;
            }
            .goo:hover
            {
                color:#3a5a7a;
            }
            .color
            {
                color:#555555;
                height:30px;
            }
             .completionList {
        border:solid 1px Gray;
        margin:0px;
        padding:3px;
        height: 120px;
        overflow:auto;
        background-color:#FAEBD7;     
        } 
        .listItem {
        color: #191919;
        } 
        .itemHighlighted {
        background-color: #ADD6FF;       
        }
        .dropbox
        {
            width:100%;
            height:30px;
        display: block;
        font-size:16px;
        font-family: 'Open Sans',"HelveticaNeue", "Helvetica Neue", Helvetica, Arial,sans-serif;
   
 }
        .gvwCasesPager
        {
           
          color:black;
          margin-right:20px;
          text-align:right;
          padding:20px;
        }
        .gvwCasesPager a
            {
               
                margin-left:10px;
                margin-right:10px;
                font-size:20px;
                
                 padding:10px;
                
              
              
            }

         .dropbox1
        {
            width:10%;
            height:30px;
           
           
            
        }
        
        .see
        {
           height:400px; 
           margin-top:-60px;
        }
        .see1
        {
            margin-top:-20px;
        }
         .see2
        {
          
            margin-left:-15px;
            margin-bottom:30px;
        }
        
          @media (max-width: 767px)
        {
             .see
        {
           height:400px; 
           margin-top:-10px;
        }
         .see1
        {
            margin-top:-40px;
        }
         .see2
        {
            margin-top:50px;
            
        }
      
        }
        
    
    
    </style>
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
                   <%-- <ul class="nav navbar-nav">
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
                                <a href="#"><i class="fa fa-folder-open fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp;Master </span><span class="fa arrow"></span></a>
                          
                          <ul class="nav nav-second-level collapse">
                                    <li><a href="Service_Type.aspx">Service Type</a></li>
                           </ul>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Location.aspx">Location</a></li>
                           </ul>
                            <ul class="nav nav-second-level collapse">
                                    <li><a href="Service_Entry.aspx">Service Entry</a></li>
                           </ul>
                          
                           
                          
                               
                            </li>
                             
                              <li>
                                <a href="#"><i class="fa fa-arrow-right fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Expenses </span><span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level collapse">
                                    <li><a href="Expenses.aspx">Expenses</a></li>
                           </ul>
                                 <ul class="nav nav-second-level collapse">
                                    <li><a href="Expenses_Report.aspx">Expenses Report</a></li>
                           </ul>
                          
                               
                            </li>
                                   <li>
                                <a href="#"><i class="fa fa-check-square-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Account</span><span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level collapse">
                                    <li><a href="Account_Entry.aspx">Account_Entry</a></li>
                           </ul>
                           
                          
                               
                            </li>

                         
                              <li>
                                <a href="#"><i class="fa fa-male fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Customers </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Customer-Entry.aspx">Customer Entry</a></li>
                           </ul>
                           <ul class="nav nav-second-level collapse">
                                    <li><a href="Client_Entry.aspx">Client Entry</a></li>
                           </ul>
                          
                               
                            </li>
                            
                           
                             <li>
                                <a href="#"><i class="fa fa-arrow-left fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Order</span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Order_entry.aspx">Order Entry</a></li>
                                    <li><a href="Oreders_Report.aspx">Orders Report</a></li>
                           </ul>
                          
                               
                            </li>
                             <li>
                                <a href="#"><i class="fa fa-users fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Staff </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                    <li><a href="Staff-Entry.aspx">Staff Entry</a></li>
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
                                    <li><a href="Inventory_entry.aspx">Inventody Entry</a></li>
                                     
                                    
                           </ul>
                          
                               
                            </li>
                            <li>
                                <a href="#"><i class="fa fa-file-text-o fa-2x" aria-hidden="true"></i> <span class="nav-label">&nbsp;&nbsp; Reports </span><span class="fa arrow"></span></a>
                             <ul class="nav nav-second-level collapse">
                                   <li><a href="Expenses_Report.aspx">Expenses Report</a></li>
                                    <li><a href="Service_report.aspx">Service Report</a></li>
                                     <li><a href="profit_loss.aspx">Profit and Loss</a></li>
                                      <li><a href="Estimate_report.aspx">Invoice Report</a></li>
                                     
                                     
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
                                <h2>Estimate Entry
                                 </h2>
                             
                             
  



                                
                            </div>
                            
                        </div>
                    </div><!-- end .page title-->
                     <div class="row">
                    <div class="col-md-12">
                  




                    <div class="row see"  >


           
                            
                            <div class="container">
 
  <div class="panel panel-default">
  <div class="panel-body">
  <br /><h2>Enter Estimate Details Here</h2><hr />
   <div class="col-md-6">
                 <div class="panel-body">
                           <div class="form-horizontal">
                               <br />

                               <div class="form-group"><label class="col-lg-4 control-label">Estimate No : </label>

                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel19" runat="server">
   <ContentTemplate>
                               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                      </ContentTemplate>
               
                           </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-3">
                                  
                                    </div>
                                </div>



                                 <div class="form-group"><label class="col-lg-4 control-label">Date</label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel17" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control input-x2 dropbox"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox8" Format="MM-dd-yyyy"></asp:CalendarExtender>
                                    </ContentTemplate>
              
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>
                                                               <div class="form-group"><label class="col-lg-4 control-label">Customer Name : </label>
                              
                                    <div class="col-lg-4">
                                     <asp:UpdatePanel ID="UpdatePanel24" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox13" runat="server" 
                                        class="form-control input-x2 dropbox" AutoPostBack="true" ontextchanged="TextBox13_TextChanged"></asp:TextBox>
                                  <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="TextBox13" WatermarkText="Customer name" ></asp:TextBoxWatermarkExtender>
                           <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" MinimumPrefixLength="1" ServiceMethod="SearchCustomersdetails" FirstRowSelected = "false" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TextBox13"  CompletionListCssClass="completionList"
     CompletionListItemCssClass="listItem"
     CompletionListHighlightedItemCssClass="itemHighlighted">
      </asp:AutoCompleteExtender>
                                    </ContentTemplate>
             
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                <div class="col-lg-4 ad"> <a href="Customer-Entry.aspx">Add New Customer</a></div>
                               
                                
                                </div>
                                <div class="form-group"><label class="col-lg-4 control-label">Mobile No : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="true" class="form-control input-x2 dropbox" 
                                        ontextchanged="TextBox6_TextChanged"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TextBox6" WatermarkText="Enter mobile no" ></asp:TextBoxWatermarkExtender>
                           <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1" ServiceMethod="SearchCustomers2" FirstRowSelected = "false" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TextBox6"  CompletionListCssClass="completionList"
     CompletionListItemCssClass="listItem"
     CompletionListHighlightedItemCssClass="itemHighlighted">
      </asp:AutoCompleteExtender>
                                    </ContentTemplate>
                                    
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

 


           



       
















                                <div class="form-group"><label class="col-lg-4 control-label">Customer Address : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel25" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox14" runat="server" class="form-control input-x2 dropbox" TextMode="MultiLine"></asp:TextBox>
                                  
                                    </ContentTemplate>
                                    
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                                






<!-------------Editing tag----------------->




 <div class="form-group"><label class="col-lg-4 control-label">Service Type : </label>

                                    <div class="col-lg-5">
                                   <asp:UpdatePanel ID="UpdatePanel11" runat="server" >
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true" 
                                       onselectedindexchanged="DropDownList3_SelectedIndexChanged" ></asp:DropDownList>
                              </ContentTemplate>
                             
                               
     </asp:UpdatePanel>       
                                    </div>
                                     <div class="col-lg-3 ad"><br /><a href="Service_Entry.aspx">New Service</a></div>
                                </div>
                                                         <div class="form-group"><label class="col-lg-4 control-label">Service Name : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel12" runat="server">
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true" 
                                       onselectedindexchanged="DropDownList5_SelectedIndexChanged" ></asp:DropDownList>
                                    </ContentTemplate>
              
                           </asp:UpdatePanel>
                                    
                                    </div>
                               
                                
                                </div>












     
                                           <div class="form-group"><label class="col-lg-4 control-label">Estimate Cost : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel31" runat="server">
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true" ></asp:DropDownList>
                             
                                
                             
                           
                                    </ContentTemplate>
            
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                               
                                           <div class="form-group"><label class="col-lg-4 control-label">From : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel32" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox30" runat="server" 
                                        class="form-control input-x2 dropbox" AutoPostBack="true"></asp:TextBox>
                             
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox30"></asp:CalendarExtender>
                             
                           
                                    </ContentTemplate>
           
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>


                                           <div class="form-group"><label class="col-lg-4 control-label">To: </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel33" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox31" runat="server" 
                                        class="form-control input-x2 dropbox" AutoPostBack="true" ontextchanged="TextBox13_TextChanged"></asp:TextBox>
                             
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox31"></asp:CalendarExtender>
                             
                           
                                    </ContentTemplate>
           
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>



                                           <div class="form-group"><label class="col-lg-4 control-label">Payment Term : </label>
                              
                                    <div class="col-lg-8">
                                     <asp:UpdatePanel ID="UpdatePanel34" runat="server">
   <ContentTemplate>
                                    <asp:TextBox ID="TextBox32" runat="server" 
                                        class="form-control input-x2 dropbox" AutoPostBack="true" ontextchanged="TextBox13_TextChanged"></asp:TextBox>
                             
                                
                             
                           
                                    </ContentTemplate>
         
                           </asp:UpdatePanel>
                                    
                                    </div>
                                
                                
                                </div>

                          <br />      <h2>Bank Details</h2>
             
             <hr />
          <div class="form-group"><label class="col-lg-4 control-label">Account Nick Name : </label>

                                    <div class="col-lg-5">
                                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true" 
                                       onselectedindexchanged="DropDownList4_SelectedIndexChanged" ></asp:DropDownList>
                              </ContentTemplate>
                             
                               
     </asp:UpdatePanel>       
                                    </div>
                                     <div class="col-lg-3 ad"><br /><a href="Account_Entry.aspx">New Account</a></div>
                                </div>
                                 <div class="form-group"><label class="col-lg-4 control-label">Account No : </label>

                                    <div class="col-lg-8">
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList6" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true" 
                                       onselectedindexchanged="DropDownList6_SelectedIndexChanged" ></asp:DropDownList>
                              </ContentTemplate>
                             
                               
     </asp:UpdatePanel>       
                                    </div>
                                </div>
                                 <div class="form-group"><label class="col-lg-4 control-label">Account Name : </label>

                                    <div class="col-lg-8">
                                   <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList7" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true" 
                                       onselectedindexchanged="DropDownList7_SelectedIndexChanged" ></asp:DropDownList>
                              </ContentTemplate>
                             
                               
     </asp:UpdatePanel>       
                                    </div>
                                </div>
                                 <div class="form-group"><label class="col-lg-4 control-label">IFSC CODE : </label>

                                    <div class="col-lg-8">
                                   <asp:UpdatePanel ID="UpdatePanel5" runat="server" >
   <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList8" runat="server" CssClass="form-control" 
                                        data-width="100%" AutoPostBack="true"></asp:DropDownList>
                              </ContentTemplate>
                             
                               
     </asp:UpdatePanel>       
                                    </div>
                                </div>

                                <br />


                                                      <asp:UpdatePanel ID="UpdatePanel6" runat="server">
   <ContentTemplate>

                      <asp:Button ID="Button1" runat="server" class="btn-primary" Width="70px" Height="30px"  Text="Create" onclick="Button1_Click" ></asp:Button>&nbsp;
 <asp:Button ID="Button2" runat="server" class="btn-primary2" Width="70px" Height="30px"  Text="Clear" onclick="Button2_Click" ></asp:Button>
                          </ContentTemplate>
                           </asp:UpdatePanel>
                          </div></div></div></div></div></div>
                          
                          
                          
                          </div></div></div></div></div></div>

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



