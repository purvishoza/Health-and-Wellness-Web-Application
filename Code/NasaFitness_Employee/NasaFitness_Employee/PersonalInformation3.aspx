<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PersonalInformation3.aspx.cs" Inherits="NasaFitness_Employee.PersonalInformation3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script>
         function myFunction() {
            if (document.getElementById('.checkbox').checked == true) {
                 document.getElementById('sinsID').disabled = true;
                 document.getElementById('sign').disabled = true;
                 document.getElementById('sinc').disabled = true;
                 document.getElementById('type').disabled = true;
                 document.getElementById('relation').disabled = true;
                 document.getElementById('Gsname').disabled = true;
                 document.getElementById('Gsaddress').disabled = true;
                 document.getElementById('Gcity').disabled = true;
                 document.getElementById('Gsstate').disabled = true;
                 document.getElementById('Gszip').disabled = true;
             }
                 document.getElementById('sinsID').disabled = false;
                 document.getElementById('sign').disabled = false;
                 document.getElementById('sinc').disabled = false;
                 document.getElementById('type').disabled = false;
                 document.getElementById('relation').disabled = false;
                 document.getElementById('Gsname').disabled = false;
                 document.getElementById('Gsaddress').disabled = false;
                 document.getElementById('Gcity').disabled = false;
                 document.getElementById('Gsstate').disabled = false;
                 document.getElementById('Gszip').disabled = false;
             
         }
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        th {
            background-color: #093965;
            text-align: center;
            color: white;
        }

        td {
            text-align: center;
        }

        .thumbnail, .caption {
            text-align: center;
        }

        .hello {
            width: 100%;
            border-collapse: separate;
            border-spacing: 1.5em;
        }

            .hello td {
                text-align: start;
                width: 50%;
            }

        .radioButtonList {
            list-style: none;
            margin: 0;
            padding: 0;
            margin-right: 15px;
            margin-left: 15px;
        }

            .radioButtonList.horizontal li {
                display: inline;
                margin-right: 15px;
                margin-left: 15px;
            }

            .radioButtonList label {
                display: inline;
                margin-right: 15px;
                margin-left: 15px;
            }
		
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form3" class="form-horizontal" runat="server">
		<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
        <asp:Panel runat="server" ID="Panel2" Visible="true">
    <p style="color: #093965; font-size:32px">Secondary Insurance
				<asp:Button ID="Button3" runat="server"  BackColor="#093965" ForeColor="white"  Style="float: right;" /> 
        </p>
        <hr />
            <div class="row">
                <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Personal Information " PostBackUrl="PersonalInfo1.aspx"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Primary Insurance" PostBackUrl="PersonalInformation2.aspx"></asp:LinkButton></li>
                        <li role="presentation" class="active">
                            <asp:LinkButton runat="server" Text="Secondary Insurance" ></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
        <br/><br/>
            </asp:Panel>
       

   <div class="container">
  <h2>STEP 3</h2>

 
     <%--<asp:CheckBox ID="checkbox" runat="server" />  Do you have a secondary insurance?<br>--%>
     
    


    <div class="form-group">
      <label class="control-label col-sm-2" for="sinsID">Secondary Insurance Subscriber ID:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="sinsID" class="form-control" placeholder="Enter secondary insurance subscriber ID" ></asp:TextBox>

      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="Ssign">Secondary Insurance Group Number:</label>
        <div class="col-sm-10">
           <asp:TextBox runat="server" ID ="Ssign" class="form-control" placeholder="Enter secondary insurance group number" ></asp:TextBox>
      </div>
    </div>


    <div class="form-group">
     <label class="control-label col-sm-2" for="Scompany">Secondary Insurance Company:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="Scompany" runat="server" >
              <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem Text="test1" Value="test1"></asp:ListItem>
            <asp:ListItem Text="test2" Value="test2"></asp:ListItem>
            <asp:ListItem Text="test3" Value="test3"></asp:ListItem>
        </asp:DropDownList>

      </div>
    </div>

    <div class="form-group">
     <label class="control-label col-sm-2" for="Stype">Type of Insurance:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="Stype" runat="server">
              <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem Text="Choice Plus" Value="Choice Plus"></asp:ListItem>
            <asp:ListItem Text="HMO" Value="HMO"></asp:ListItem>
            <asp:ListItem Text="PPO" Value="PPO"></asp:ListItem>
            <asp:ListItem Text="POS" Value="POS"></asp:ListItem>
            <asp:ListItem Text="Open Access" Value="Open Access"></asp:ListItem>
            <asp:ListItem Text="Indemnity" Value="Indemnity"></asp:ListItem>
            <asp:ListItem Text="PIP" Value="PIP"></asp:ListItem>
            <asp:ListItem Text="Med-Pay" Value="Med-Pay"></asp:ListItem>
            <asp:ListItem Text="LOP" Value="LOP"></asp:ListItem>
            <asp:ListItem Text="WC" Value="WC"></asp:ListItem>
            <asp:ListItem Text="Medicare" Value="Medicare"></asp:ListItem>
            <asp:ListItem Text="Medicaid" Value="Medicaid"></asp:ListItem>
            <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>


    <div class="form-group">
     <label class="control-label col-sm-2" for="Srelation">Relationship to insured:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="Srelation" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
              <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem Text="Self" Value="Self"></asp:ListItem>
            <asp:ListItem Text="Spouse" Value="Spouse"></asp:ListItem>
            <asp:ListItem Text="Child" Value="Child"></asp:ListItem>
            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>

    <div class="form-group">
      <label class="control-label col-sm-2" for="SGname">Guarantor Name:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="SGname" class="form-control" placeholder="Enter Guarantor Name" ></asp:TextBox>
      </div>
    </div>

     <div class="form-group">
      <label class="control-label col-sm-2" for="SGaddress">Guarantor Address:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="SGaddress" class="form-control" placeholder="Enter address" ></asp:TextBox>
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="SGcity">Guarantor City:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="SGcity" class="form-control" placeholder="Enter city" ></asp:TextBox>
      </div>
    </div>


     <div class="form-group">
      <label class="control-label col-sm-2" for="SGstate">Guarantor State:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="SGstate" class="form-control" placeholder="Enter state" ></asp:TextBox>
      </div>
    </div>


     <div class="form-group">
      <label class="control-label col-sm-2" for="SGzip">Guarantor Zip:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="SGzip" class="form-control" placeholder="Enter zip" ></asp:TextBox>
        </div>
    </div>


    
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
           <asp:Button runat="server"  class="btn btn-default" value="Submit" Text="Finish" OnClick ="save_secondaryIns_info" OnClientClick="javascript:return ValidateDropDown();"  />
        
      </div>
    </div>
    </div>
  </form>

    <script>

        function ValidateDropDown() {
            var cmbID = "<%=Scompany.ClientID %>";
            var cmbID1 = "<%=Stype.ClientID %>";
            var cmbID2 = "<%=Srelation.ClientID %>";

            if (document.getElementById(cmbID).selectedIndex == 0) {
                alert("Please select a Value for Secondary Insurance Company");
                return false;
            }

            if (document.getElementById(cmbID1).selectedIndex == 0) {
                alert("Please select a Value for Type of Insurance");
                return false;
            }

            if (document.getElementById(cmbID2).selectedIndex == 0) {
                alert("Please select a Value for Relationship to Insured");
                return false;
            }
            return true;
        }

        <%--window.onload = function () {
            var a = document.getElementById('<%= checkbox.ClientID %>');
            var b = document.getElementById('<%= sinsID.ClientID %>');
            var c = document.getElementById('<%= Ssign.ClientID %>');
            var d = document.getElementById('<%= Scompany.ClientID %>');
            var e = document.getElementById('<%= Stype.ClientID %>');
            var f = document.getElementById('<%= Srelation.ClientID %>');
            var g = document.getElementById('<%= SGname.ClientID %>');
            var h = document.getElementById('<%= SGaddress.ClientID %>');
            var i = document.getElementById('<%= SGcity.ClientID %>');
            var j = document.getElementById('<%= SGstate.ClientID %>');
            var k = document.getElementById('<%= SGzip.ClientID %>');
            b.disabled = true;
            c.disabled = true;
            d.disabled = true;
            e.disabled = true;
            f.disabled = true;
            g.disabled = true;
            h.disabled = true;
            i.disabled = true;
            j.disabled = true;
            k.disabled = true;

                a.onchange = function () {
                    if (a.checked) {
                        b.disabled = false;
                        c.disabled = false;
                        d.disabled = false;
                        e.disabled = false;
                        f.disabled = false;
                        g.disabled = false;
                        h.disabled = false;
                        i.disabled = false;
                        j.disabled = false;
                        k.disabled = false;
                    }
                    else {
                        b.disabled = true;
                        c.disabled = true;
                        d.disabled = true;
                        e.disabled = true;
                        f.disabled = true;
                        g.disabled = true;
                        h.disabled = true;
                        i.disabled = true;
                        j.disabled = true;
                        k.disabled = true;
                    }
                }
            }--%>



    </script>

</asp:Content>