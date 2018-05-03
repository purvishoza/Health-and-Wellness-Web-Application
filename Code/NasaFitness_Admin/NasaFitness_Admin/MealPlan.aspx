<%@ Page Language="C#" AutoEventWireup="true" Inherits="MealPlan" Codebehind="MealPlan.aspx.cs" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css"/>--%>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
          <!--  <script type="text/javascript" src="http://code.jquery.com/jquery-1.10.2.js"></script>-->
    <script src="Scripts/jquery-1.9.1.js"></script>
            <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    
   

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css"/>

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap-theme.min.css"/>
    <link href="StyleSheet.css" rel="stylesheet"/>
    <!--<link href="font-awesome-4.3.0/css/font-awesome.min.css" rel="stylesheet"> -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
     <link href="css/simple-sidebar.css" rel="stylesheet"/>

<style>
        .table{
background-color: #e0dede;
color: white;

        }
        #tuesdaybreak
        {
            background-color:transparent;
            border:none;
        }
       #txtCashAmt, #txtCashAmt2{
            -webkit-border-radius: 50px;
        -moz-border-radius: 50px;
        border-radius: 10px;
        text-align:center;
        z-index:1000000 !important;
        }

            
      
       
    </style>
  <script>
      //$('#theModal1').on('shown.bs.modal', function () {
      //    $('.date').datepicker({
      //        changeMonth: true,
      //        changeYear: true,
      //        container: '#theModal1 modal-body'
      //    }); 
      //});

      $(function () {
          $('#txtCashAmt').datepicker({
              changeMonth: true,
              changeYear: true
          });
          $('#txtCashAmt2').datepicker({
              changeMonth: true,
              changeYear: true
          });
      });
      $('#Save1').click(function () {
          $('')
      });
        </script>
   <%-- <script>
      $(document).on("click", ".modal-body", function () {
          $("#txtCashAmt").datepicker({
         dateFormat: 'yy-mm-dd'                                    
         });
          });  
    </script>--%>
</head>
<body>
    <form runat="server">
        <div class="modal-header">
     
      <%--<h2 style="color:#093965"> Meal Plan Page</h2>--%>
            <br />
    </div>
    <div class="modal-body">
    
    
  <div class="row">
      
      <div class="col-md-6">
                  <center>  <asp:TextBox id="txtCashAmt" placeholder="Start Date"  runat="server" CssClass="date" style="position:relative;z-index:1000000;"></asp:TextBox>
                   
            </center>   
      </div>
       
       <div class="col-md-6">
        <center>   <asp:TextBox ID="txtCashAmt2" placeholder="End Date" runat="server" CssClass="date" style="position:relative;z-index:1000000;"></asp:TextBox></center>
      </div>
  </div>
   <br />
<div class="row">
    <div class="col-md-12">
    <asp:table CssClass="table" runat="server">

        <asp:TableHeaderRow
            runat="server" 
                ForeColor="Snow"
                BackColor=#093965
                Font-Bold="true">
            <asp:TableHeaderCell>
               
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
               BreakFast
                 <asp:textbox type="text" id="breakfasttime" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="Time" />
            </asp:TableHeaderCell><asp:TableHeaderCell>
             Breakfast Snack
                <asp:textbox type="text" id="breakfastsnacktime" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="Time" />
            </asp:TableHeaderCell><asp:TableHeaderCell>
              Lunch
                <asp:textbox type="text" id="lunchtime" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="Time" />
            </asp:TableHeaderCell><asp:TableHeaderCell>
              Lunch Snack
                <asp:textbox type="text" id="lunchsnacktime" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="Time" />
            </asp:TableHeaderCell><asp:TableHeaderCell>
              Dinner
                <asp:textbox type="text" id="dinnertime" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="Time" />
            </asp:TableHeaderCell><asp:TableHeaderCell>
              Dinner Snack
                <asp:textbox type="text" id="dinnersnacktime" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="Time" />
            </asp:TableHeaderCell></asp:TableHeaderRow><asp:TableRow>
            <asp:TableCell ForeColor="Black">Monday</asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="Mondaybreakfast" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaybreakfastsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaylunch" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaylunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaydinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="mondaydinnersnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell></asp:TableRow><asp:TableRow 
            backcolor=#73879b
             >
            <asp:TableCell >Tuesday</asp:TableCell><asp:TableCell><asp:textbox type="text" id="tuesdaybreak" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="tuesdaybreaksnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="tuesdaylunch" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="tuesdaylunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="tuesdaydinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell><asp:textbox type="text" id="tuesdaydinnersnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell></asp:TableRow><asp:TableRow 
               
                >
            <asp:TableCell ForeColor="Black">Wednesday</asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaybreak" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaybreaksnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaylunch" runat="server"  style="background-color:transparent;
            border:thin;width:90%" value="one"/></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaylunchsnack" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaydinner" runat="server" style="background-color:transparent;
            border:thin;width:90%" value="one" /></asp:TableCell><asp:TableCell ForeColor="Black"><asp:textbox type="text" id="wednesdaydinnersnack" runat="server" style="background-color:transparent;

            border:thin;" value="one" /></asp:TableCell></asp:TableRow><asp:TableRow 
               backcolor=#73879b
                >
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
               backcolor=#73879b
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
            border:thin;width:90%" value="one" /></asp:TableCell></asp:TableRow ></asp:table>

    </div>

</div>
    <div class="row">
        <div class="col-md-12">
       <center> <asp:Button ID="save_button" width="30%" runat="server" BackColor="#093965"  Text="Save" ForeColor="White" CssClass="btn" OnClick="save_button_Click"/> 
           </center> </div>
    </div>
    <br />
    </div>
      <div class="modal-footer">
           <%--<center> <asp:Button ID="Button1" width="30%" runat="server" BackColor="#093965"  Text="Save" ForeColor="White" CssClass="btn" OnClick="save_button_Click" data-dismiss="modal" /> --%>
          <%-- <asp:Button runat="server" ID="Save1" class="btn  btn-danger" Text="Close" OnClick="Save1_Click" UseSubmitBehavior="false"  data-dismiss="modal" target="_blank" />--%>
         
      </div>
        </form>
   </body>
    </html>
