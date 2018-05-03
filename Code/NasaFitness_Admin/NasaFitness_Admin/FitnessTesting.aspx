<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" Inherits="FitnessTesting" Codebehind="FitnessTesting.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script> 
<script type="text/javascript" src="../Scripts/gridviewScroll.min.js"></script> 
<script type="text/javascript"> 
    $(document).ready(function () {
        gridviewScroll();
    });

    function gridviewScroll() {

        $('#<%=gv1.ClientID%>').gridviewScroll({
            //width: 900,
            // height: 500, 
            //freezesize: 2
        });
    } 
</script>--%>
    <style>
        .addnew {
            background-color: #093965;
            color: white;
        }

        #meal, #contact, #meal1 {
            background-color: #093965;
            color: white;
        }

        .table th, .table td {
            border-top: none !important;
        }

        .redtext {
            text-decoration: underline;
            color: red;
        }

        .greentext {
            text-decoration: underline;
            color: green;
        }

        .sub {
            font: bold;
        }
        /*.date
        {
            z-index:1151 !important;
        }*/
        .GridviewScrollHeader TH
{ 
    padding: 5px; 
    font-weight: bold; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #093965;
     color:white;
    text-align: left; 
    vertical-align: bottom; 
} 
        .GridviewScrollHeader TD 
{ 
    padding: 5px; 
    font-weight: bold; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #EFEFEF; 
    text-align: left; 
    vertical-align: bottom; 
} 
.GridviewScrollItem TD 
{ 
    padding: 5px; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
} 
.GridviewScrollPager  
{ 
    border-top: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
} 
.GridviewScrollPager TD 
{ 
    padding-top: 3px; 
    font-size: 14px; 
    padding-left: 5px; 
    padding-right: 5px; 
} 
.GridviewScrollPager A 
{ 
    color: #666666; 
}
.GridviewScrollPager SPAN

{

    font-size: 16px;

    font-weight: bold;

}
    </style>
    </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <form runat="server">
         <div class="row">
            <div class="col-md-8">
                <h3 style="color: #093965">Employees Fitness Testing Reports</h3>
                
            </div>
            
               </div>
      <hr />
        
        <div class="row">
            <br />
            <br />
          
            Search: <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'gv1')" />
               <hr />
            </div>
         <div class="row">
             <div class="col-md-10" style="overflow-x:scroll;">
           <asp:GridView runat="server" RowStyle-Wrap="false" AutoGenerateColumns="False" DataKeyNames="ID"  DataSourceID="SqlDataSource1" ID="gv1" GridLines="None">
                 <HeaderStyle BackColor="#093965" ForeColor="white" />
                <Columns>
                  
                    <%--<asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="fitness_id" HeaderText="fitness_id" SortExpression="fitness_id" />--%>
                    <asp:BoundField DataField="employee_id" HeaderText="employee_id" SortExpression="employee_id" ItemStyle-BackColor="#EFEFEF"/>
                    <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" ItemStyle-BackColor="#EFEFEF"/>
                    <asp:BoundField DataField="sit_reach1" HeaderText="sit_reach1" SortExpression="sit_reach1" />
                    <asp:BoundField DataField="sit_reach2" HeaderText="sit_reach2" SortExpression="sit_reach2" />
                    <asp:BoundField DataField="sit_reach3" HeaderText="sit_reach3" SortExpression="sit_reach3" />
                    <asp:BoundField DataField="hip_flexion" HeaderText="hip_flexion" SortExpression="hip_flexion" />
                    <asp:BoundField DataField="hip_extension" HeaderText="hip_extension" SortExpression="hip_extension" />
                    <asp:BoundField DataField="l_side_bridge" HeaderText="l_side_bridge" SortExpression="l_side_bridge" />
                    <asp:BoundField DataField="r_side_bridge" HeaderText="r_side_bridge" SortExpression="r_side_bridge" />
                    <asp:BoundField DataField="curl_ups" HeaderText="curl_ups" SortExpression="curl_ups" />
                    <asp:BoundField DataField="push_up" HeaderText="push_up" SortExpression="push_up" />
                    <asp:BoundField DataField="height" HeaderText="height" SortExpression="height" />
                    <asp:BoundField DataField="weight" HeaderText="weight" SortExpression="weight" />
                    <asp:BoundField DataField="grip_left" HeaderText="grip_left" SortExpression="grip_left" />
                    <asp:BoundField DataField="grip_right" HeaderText="grip_right" SortExpression="grip_right" />
                    <asp:BoundField DataField="arm_raise" HeaderText="arm_raise" SortExpression="arm_raise" />
                    <asp:BoundField DataField="knee_bend" HeaderText="knee_bend" SortExpression="knee_bend" />
                    <asp:BoundField DataField="blood_pressure" HeaderText="blood_pressure" SortExpression="blood_pressure" />
                    <asp:BoundField DataField="heart_rate" HeaderText="heart_rate" SortExpression="heart_rate" />
                    <asp:BoundField DataField="blood_oxygen" HeaderText="blood_oxygen" SortExpression="blood_oxygen" />
                    <asp:BoundField DataField="body_fat1" HeaderText="body_fat1" SortExpression="body_fat1" />
                    <asp:BoundField DataField="body_fat2" HeaderText="body_fat2" SortExpression="body_fat2" />
                    <asp:BoundField DataField="body_fat3" HeaderText="body_fat3" SortExpression="body_fat3" />
                    <asp:BoundField DataField="skin_fold1" HeaderText="skin_fold1" SortExpression="skin_fold1" />
                    <asp:BoundField DataField="skin_fold2" HeaderText="skin_fold2" SortExpression="skin_fold2" />
                    <asp:BoundField DataField="skin_fold3" HeaderText="skin_fold3" SortExpression="skin_fold3" />
                    <asp:BoundField DataField="bmi" HeaderText="bmi" SortExpression="bmi" />
                    <asp:BoundField DataField="blood_pressure2" HeaderText="blood_pressure2" SortExpression="blood_pressure2" />
                    <asp:BoundField DataField="notes" HeaderText="notes" SortExpression="notes" />
                  
                </Columns>

                <HeaderStyle CssClass="GridviewScrollHeader" />
                <RowStyle CssClass="GridviewScrollItem" />
                <PagerStyle CssClass="GridviewScrollPager" />


            </asp:GridView>
            </div>
        </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:caps17g3ConnectionString %>" SelectCommand="SELECT * FROM [FitnessTesting] ORDER BY [date] DESC"></asp:SqlDataSource>
            
        </form>
     <script type="text/javascript">
         function Search_Gridview(strKey, strGV) {
             var strGV = '<%= gv1.ClientID %>'
             var strData = strKey.value.toLowerCase().split(" ");
             var tblData = document.getElementById(strGV);
             var rowData;
             for (var i = 1; i < tblData.rows.length; i++) {
                 rowData = tblData.rows[i].innerHTML;
                 var styleDisplay = 'none';
                 for (var j = 0; j < strData.length; j++) {
                     if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                         styleDisplay = '';
                     else {
                         styleDisplay = 'none';
                         break;
                     }
                 }
                 tblData.rows[i].style.display = styleDisplay;
             }
         }    
</script>
 </asp:Content>
