<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Presentations" Codebehind="Presentations.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

   <link href="style.css" rel="stylesheet" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <form id="form1" runat="server">
            <div class="row">
                    <div class="col-md-6">
                        <h1>
                            Lectures
                        </h1>
                     </div>
                     <div class="col-md-6">
                         <h1 style="float:right;">
                        <%--<asp:Button runat="server" type="button" class="btn btn-info" style="font-size:20px;" Text="Add Classes" OnClick="page_navigate"></asp:Button>--%>
                         </h1>
                    </div>
                       <hr />
                   
              </div>
	<div class="row">
  
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_1" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color: #666666; color:white; text-decoration:none;"><h3 runat="server" id="January">January</h3><br /><h2>Effects of Obesity</h2> </asp:LinkButton>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_2" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color: #2ecc71; color:white;text-decoration:none;"><h3 runat="server" id="February">February</h3><br /><h2>Nutrition Labels</h2></asp:LinkButton>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_3" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color:#FFCC00; color:white;text-decoration:none;"><h3 runat="server" id="March">March</h3><br /><h2>Exercise and Nutrition</h2></asp:LinkButton>
	   </div>
       <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_4" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color:#FF5733; color:white;text-decoration:none;"><h3 runat="server" id="April">April</h3><br /><h2>Anaerobic Training</h2></asp:LinkButton>
	   </div>
       <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_5" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color: #000066; color:white;text-decoration:none;"><h3 runat="server" id="May">May</h3><br /><h2>Anerobic Training</h2></asp:LinkButton>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_6" runat="server" OnClick="month_click" class="thumbnail purple" style="text-decoration:none;"><h3 runat="server" id="June">June</h3><br /><h2>Injury Prevention and Management</h2></asp:LinkButton>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_7" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color: #CCCCCC; color:white;text-decoration:none;"><h3 runat="server" id="July">July</h3><br /><h2>Stress Management</h2></asp:LinkButton>
	   </div>
       <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_8" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color:#FF6600; color:white;text-decoration:none;"><h3 runat="server" id="August">August</h3><br /><h2>Diabetes Prevention and Management</h2></asp:LinkButton>
	   </div>
        <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_9" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color: #669966; color:white;text-decoration:none;"><h3 runat="server" id="September">September</h3><br /><h2>Heart Challenge</h2></asp:LinkButton>
	   </div>
        <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_10" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color: #993366; color:white;text-decoration:none;"><h3 runat="server" id="October">October</h3></asp:LinkButton>
	   </div>
        <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_11" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color:#CC3333; color:white;text-decoration:none;"><h3 runat="server" id="November">November</h3></asp:LinkButton>
	   </div>
        <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton ID="month_12" runat="server" OnClick="month_click" class="thumbnail purple" style="background-color:#FFCC00; color:white;text-decoration:none;"><h3 runat="server" id="December">December</h3></asp:LinkButton>
	   </div>  
  	</div>  
       </form>
</asp:Content>

