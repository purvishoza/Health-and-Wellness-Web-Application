<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Month" Codebehind="Month.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link href="style.css" rel="stylesheet" />
    <style>
        #addclass,
#back{
    display: inline-block;
    vertical-align: top;
    align-items:flex-end;
    align-content:flex-end;
    
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <form id="form1" runat="server">
          <div class="row">
                    <div class="col-md-12">
                        <h2 runat="server" id="heading" style="font-size:40px;">
                            Lectures: 
                        </h2>
                       <hr  />
                        <div class="pull-right">
                             <%--<asp:Button runat="server" ID="addclass"  class=" btn-group btn btn-primary"  Text="Add Classes" PostBackUrl="~/Add_Classes.aspx"></asp:Button>--%>
                        <asp:Button runat="server" ID="back" CssClass=" btn-group btn-warning btn btn-primary" PostBackUrl="~/Presentations.aspx"  Text="back" />
                           <br />
                        </div>
                        
                        <br />
                    </div>
              <br />
            
             
              </div>
	<div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton id="week_1" runat="server" OnClick="questions_navigate" class="thumbnail purple" style="background-color: #666666; color:white; text-decoration:none;"><h3 id="topic_sub1" runat="server">WEEK-1</h3><br /><h2 id="topic_1" runat="server">Anaerobic Training</h2></asp:LinkButton>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton id="week_2" runat="server" OnClick="questions_navigate" class="thumbnail purple" style="background-color: #2ecc71; color:white;text-decoration:none;"><h3 id="topic_sub2" runat="server">WEEK-2</h3><br /><h2 id="topic_2" runat="server">Anaerobic: Setting Up a Program</h2></asp:LinkButton>
      </div>
      <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton id="week_3" runat="server" OnClick="questions_navigate" class="thumbnail purple" style="background-color:#FFCC00; color:white;text-decoration:none;"><h3 id="topic_sub3" runat="server">WEEK-3</h3><br /><h2 id="topic_3" runat="server">Resistance Weights</h2></asp:LinkButton>
	   </div>
       <div class="col-md-3 col-sm-6 col-xs-6">
        <div class="dummy"></div>
        <asp:LinkButton id="week_4" runat="server" OnClick="questions_navigate" class="thumbnail purple" style="background-color:#FF5733; color:white;text-decoration:none;"><h3 id="topic_sub4" runat="server">WEEK-4</h3><br /><h2 id="topic_4" runat="server">Anaerobic Exercise: Program Design</h2></asp:LinkButton>
	   </div>  
  </form>
</asp:Content>

