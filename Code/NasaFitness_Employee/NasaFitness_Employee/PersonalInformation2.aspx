﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PersonalInformation2.aspx.cs" Inherits="NasaFitness_Employee.PersonalInformation2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
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
    <form id="form2" class="form-horizontal" runat="server">
		<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
		<asp:Panel runat="server" ID="Panel2" Visible="true">
    <p style="color: #093965; font-size:32px">Primary Insurance
        </p>
        <hr />
			<div class="row">
                <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Personal Information " PostBackUrl="PersonalInfo1.aspx"></asp:LinkButton></li>
                        <li role="presentation"  class="active">
                            <asp:LinkButton runat="server" Text="Primary Insurance" ></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" ID="SButton" Text="Secondary Insurance" PostBackUrl="PersonalInformation3.aspx"></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
		<br/><br/>
        </asp:Panel>
      


<div class="container">
  <h2>STEP 2</h2>
  


    <div class="form-group">
      <label class="control-label col-sm-2" for="pinsID">Primary Insurance Subscriber ID:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="pinsID" class="form-control" placeholder="Enter primary insurance subscriber ID" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
              ControlToValidate="pinsID"
              ErrorMessage="Primary Insurance Subscriber ID is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="pign">Primary Insurance Group Number:</label>
        <div class="col-sm-10">
           <asp:TextBox runat="server" ID ="pign" class="form-control" placeholder="Enter primary insurance group number" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
              ControlToValidate="pign"
              ErrorMessage="Primary Insurance Group Number is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
    </div>


    <div class="form-group">
     <label class="control-label col-sm-2" for="company">Primary Insurance Company:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="company" runat="server">
              <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem Text="test1" Value="test1"></asp:ListItem>
            <asp:ListItem Text="test2" Value="test2"></asp:ListItem>
            <asp:ListItem Text="test3" Value="test3"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>

    <div class="form-group">
     <label class="control-label col-sm-2" for="type">Type of Insurance:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="type" runat="server">
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
     <label class="control-label col-sm-2" for="relation">Relationship to insured:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="relation" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
              <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem  Text="Self" Value="Self"></asp:ListItem>
            <asp:ListItem Text="Spouse" Value="Spouse"></asp:ListItem>
            <asp:ListItem Text="Child" Value="Child"></asp:ListItem>
            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>

    <div class="form-group">
      <label class="control-label col-sm-2" for="Gname">Guarantor Name:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gname" class="form-control" placeholder="Enter Guarantor Name" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
              ControlToValidate="Gname"
              ErrorMessage="Guarantor Name is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>

     <div class="form-group">
      <label class="control-label col-sm-2" for="Gaddress">Guarantor Address:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gaddress" class="form-control" placeholder="Enter address" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
              ControlToValidate="Gaddress"
              ErrorMessage="Guarantor Address is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="Gcity">Guarantor City:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gcity" class="form-control" placeholder="Enter city" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
              ControlToValidate="Gcity"
              ErrorMessage="Guarantor City is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


     <div class="form-group">
      <label class="control-label col-sm-2" for="Gstate">Guarantor State:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gstate" class="form-control" placeholder="Enter state" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
              ControlToValidate="Gstate"
              ErrorMessage="Guarantor State is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


     <div class="form-group">
      <label class="control-label col-sm-2" for="Gzip">Guarantor Zip:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gzip" class="form-control" placeholder="Enter zip" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
              ControlToValidate="Gzip"
              ErrorMessage="Guarantor Zip is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
    </div>


    
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
          <asp:CheckBox ID="checkbox" runat="server" />  Do you have a secondary insurance?
           </div>
    </div>

    <div class="form-group"> 

     <div class="col-sm-offset-2 col-sm-10">
          <asp:Button runat="server"  class="btn btn-default" value="Submit" ID="next" Text="Next" OnClick ="save_primaryIns_info" OnClientClick="javascript:return ValidateDropDown();" />
      </div>

        <div class="col-sm-offset-2 col-sm-10">
           <asp:Button runat="server"  class="btn btn-default" value="Submit" ID="finish" Text="Finish" OnClick ="save_primaryIns_info1" OnClientClick="javascript:return ValidateDropDown();"  />
       </div>

     </div>

    </div>

  </form>


     <script>

        function ValidateDropDown() {
            var cmbID = "<%=company.ClientID %>";
            var cmbID1 = "<%=type.ClientID %>";
            var cmbID2 = "<%=relation.ClientID %>";

            if (document.getElementById(cmbID).selectedIndex == 0) {
                alert("Please select a Value for Primary Insurance Company");
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

         window.onload = function () {
             var a = document.getElementById('<%= checkbox.ClientID %>');
             var b = document.getElementById('<%= SButton.ClientID %>').parentElement;
             var c = document.getElementById('<%= next.ClientID %>');
             var d = document.getElementById('<%= finish.ClientID %>');

             b.style.display = 'none';
             c.style.visibility = "hidden";
             d.style.visibility = "visible";
            

            a.onchange = function () {
                if (a.checked) {
                    b.style.display = 'inline';
                    c.style.visibility = "visible";
                    d.style.visibility = "hidden"; 
                }
                else {
                    b.style.display = 'none';
                    c.style.visibility = "hidden";
                    d.style.visibility = "visible";
                }
            }
          }

       


    </script>



  </asp:Content>