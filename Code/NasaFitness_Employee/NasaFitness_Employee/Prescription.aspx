<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Prescription" Codebehind="Prescription.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
      div  .centre{
          width:75%;
          display:inline;
          margin-left:auto;
          margin-right:auto;
          
        }
        .table{
background-color: #e0dede;
color: white;
		

        }
        #tuesdaybreak
        {
            background-color:transparent;
            border:none;
        }
        .date{
            -webkit-border-radius: 50px;
        -moz-border-radius: 50px;
        border-radius: 10px;
        text-align:center;
        }
    </style>
  <script>
            $(function () {
                $(".date").datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });
        </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<form runat="server" id="sub">
<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
<asp:Panel runat="server" ID="Panel2" Visible="true">
<asp:Button runat="server" ID="goback" OnClick="goback_Click" Text="Back to list of prescriptions" CssClass="btn" BackColor="#093965" Style="float: left;" ForeColor="White" />
<div class="row"><center>
<asp:Label id="probName" runat="server" Font-Bold="true"></asp:Label></center>
<div class="col-md-12">
<asp:TextBox ID="txtCashAmt" placeholder="Start Date"  runat="server" CssClass="date" Style="float: left;"></asp:TextBox>
<asp:TextBox ID="txtCashAmt2" placeholder="End Date" runat="server" CssClass="date" Style="float: right;"></asp:TextBox>
   <br /><br/><center>
    <asp:table CssClass="table" runat="server">

        <asp:TableHeaderRow
            runat="server" ForeColor="Snow" BackColor="#093965" Font-Bold="true">
            <asp:TableHeaderCell>
               
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>BreakFast<asp:textbox type="text" id="breakfasttime" runat="server" style="background-color:transparent;border:thin;width:90%" value="Time" /></asp:TableHeaderCell>
			<asp:TableHeaderCell>Breakfast Snack<asp:textbox type="text" id="breakfastsnacktime" runat="server" style="background-color:transparent;border:thin;width:90%" value="Time" /></asp:TableHeaderCell>
			<asp:TableHeaderCell>Lunch<asp:textbox type="text" id="lunchtime" runat="server" style="background-color:transparent;border:thin;width:90%" value="Time" /></asp:TableHeaderCell>
			<asp:TableHeaderCell>Lunch Snack<asp:textbox type="text" id="lunchsnacktime" runat="server" style="background-color:transparent;border:thin;width:90%" value="Time" /></asp:TableHeaderCell>
			<asp:TableHeaderCell>Dinner<asp:textbox type="text" id="dinnertime" runat="server" style="background-color:transparent;border:thin;width:90%" value="Time" /></asp:TableHeaderCell>
			<asp:TableHeaderCell>Dinner Snack<asp:textbox type="text" id="dinnersnacktime" runat="server" style="background-color:transparent;border:thin;width:90%" value="Time" /></asp:TableHeaderCell>
			</asp:TableHeaderRow>
			<asp:TableRow>
            <asp:TableCell ForeColor="Black">Monday</asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" Id="Mondaybreakfast" runat="server" style="background-color:transparent;border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaybreakfastsnack" runat="server" style="background-color:transparent;border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaylunch" runat="server" style="background-color:transparent;border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaylunchsnack" runat="server" style="background-color:transparent;border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaydinner" runat="server" style="background-color:transparent;border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaydinnersnack" runat="server" style="background-color:transparent;border:thin;width:90%" value="one" /></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow backcolor="#73879b">
            <asp:TableCell >Tuesday</asp:TableCell><asp:TableCell><asp:textbox type="text" id="tuesdaybreak" runat="server" style="background-color:transparent; border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell><asp:textbox type="text" id="tuesdaybreaksnack" runat="server" style="background-color:transparent; border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell><asp:textbox type="text" id="tuesdaylunch" runat="server" style="background-color:transparent; border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell><asp:textbox type="text" id="tuesdaylunchsnack" runat="server" style="background-color:transparent; border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell><asp:textbox type="text" id="tuesdaydinner" runat="server" style="background-color:transparent; border:thin;width:90%" value="one" /></asp:TableCell>
			<asp:TableCell><asp:textbox type="text" id="tuesdaydinnersnack" runat="server" style="background-color:transparent; border:thin;width:90%" value="one" /></asp:TableCell>
			</asp:TableRow>
			<asp:TableRow>
            <asp:TableCell ForeColor="Black">Wednesday</asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaybreak" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaybreaksnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaylunch" runat="server"  style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaylunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaydinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaydinnersnack" runat="server" style="background-color:transparent;

            border:thin;" value="one" /></asp:TableCell></asp:TableRow><asp:TableRow 
               backcolor="#73879b">
            <asp:TableCell>Thursday</asp:TableCell><asp:TableCell><asp:textbox type="text" id="thursdaybreak" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="thursdaybreaksnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="thursdaylunch" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="thursdaylunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="thursdaydinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="thursdaydinnersnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell></asp:TableRow><asp:TableRow 
                
                >
            <asp:TableCell ForeColor="Black">Friday</asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="fridaybreak" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="fridaybreaksnack" runat="server"  style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="fridaylunch" runat="server"  style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="fridaylunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="fridaydinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="fridaydinnersnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell></asp:TableRow ><asp:TableRow 
               backcolor="#73879b"
                >
            <asp:TableCell >Saturday</asp:TableCell><asp:TableCell><asp:textbox type="text" id="satbreak" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="satbreaksnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell><asp:textbox type="text" id="satlunch" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell><asp:textbox type="text" id="satlunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="satdinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="satdinnersnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell></asp:TableRow><asp:TableRow 
               
                >
            <asp:TableCell ForeColor="Black">Sunday</asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="sundaybreak" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="sundbreaksnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="sundaylunch" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell ForeColor="Black" ><asp:textbox type="text" id="sundaylunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="sundaydinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="sundaydinnersnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell></asp:TableRow >
			</asp:table>
<asp:Button ID="save_button" width="30%" runat="server" BackColor="#093965"  Text="Save Changes" ForeColor="White" CssClass="btn" OnClick="save_button_Click"/>
				</center><hr />

<div class="panel-group">
<div class="panel panel-default">
<div class="panel-heading">
<h3 class="panel-title">
<a data-toggle="collapse" id="cola" href="#collapse1">Goals</a>
</h3>
</div>
<div id="collapse1" class="panel-collapse collapse">
<div class="panel-body">
<asp:Label runat="server" ID="minigoal" Style="font-size: medium"></asp:Label><br/>
<asp:Label runat="server" ID="minigoaldate" Style="font-size: medium"></asp:Label><br/>
<asp:Label runat="server" ID="goal" Style="font-size: medium"></asp:Label><br/>
<asp:Label runat="server" ID="goalsatrtdate" Style="font-size: medium"></asp:Label><br/>
<asp:Label runat="server" ID="goalenddate" Style="font-size: medium"></asp:Label>
</div>
</div>
</div>
</div>
</div>
</div>
</asp:Panel>
</form>
</asp:Content>

