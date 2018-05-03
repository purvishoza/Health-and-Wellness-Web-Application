<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PersonalInfo1.aspx.cs" Inherits="NasaFitness_Employee.PersonalInfo1" %>
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
    <form id="form1" class="form-horizontal" runat="server" >
		<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
		<asp:Panel runat="server" ID="Panel2" Visible="true">
    <p style="color: #093965; font-size:32px">Personal Information
        </p>
        <hr />
			<div class="row">
                <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" class="active" >
                            <asp:LinkButton runat="server" Text="Personal Information" ></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Primary Insurance" PostBackUrl="PersonalInformation2.aspx"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Secondary Insurance" PostBackUrl="PersonalInformation3.aspx"></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
		<br/><br/>
        </asp:Panel>
        


<div class="container">
  <h2>STEP 1</h2>

  

    <div class="form-group">
      <label class="control-label col-sm-2" for="fname">First Name:</label>
      <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="fname" class="form-control" placeholder="Enter first name" ></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
              ControlToValidate="fname"
              ErrorMessage="First name is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="lname">Last Name:</label>
      <div class="col-sm-10"> 
          <asp:TextBox runat="server" ID ="lname" class="form-control" placeholder="Enter last name" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
              ControlToValidate="lname"
              ErrorMessage="Last name is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
        </div>


        <div class="form-group">
      <label class="control-label col-sm-2" for="address">Address:</label>
      <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="address" class="form-control" placeholder="Enter address" ></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
              ControlToValidate="address"
              ErrorMessage="Address is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="city">City:</label>
      <div class="col-sm-10">
         <asp:TextBox runat="server" ID ="city" class="form-control" placeholder="Enter city" ></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
              ControlToValidate="city"
              ErrorMessage="City is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


        <div class="form-group">
      <label class="control-label col-sm-2" for="state">State:</label>
      <div class="col-sm-10">
         <asp:TextBox runat="server" ID ="state" class="form-control" placeholder="Enter state" ></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
              ControlToValidate="state"
              ErrorMessage="State is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


        <div class="form-group">
      <label class="control-label col-sm-2" for="zip">Zip:</label>
      <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="zip" class="form-control"  ></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
              ControlToValidate="zip"
              ErrorMessage="Zip is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


       <div class="form-group">
      <label class="control-label col-sm-2" for="dob">DOB(mmddyyyy):</label>
      <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="dob" class="form-control" ></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
              ControlToValidate="dob"
              ErrorMessage="DOB is a required field."
              ForeColor="Red">
            </asp:RequiredFieldValidator>
      </div>
    </div>


       <div class="form-group">
      <label class="control-label col-sm-2" for="ms">Marital Status:</label>
      <div class="demo-settings">
         <asp:DropDownList ID="marital" runat="server">
             <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem Text="Single" Value="single"></asp:ListItem>
            <asp:ListItem Text="Married" Value="married"></asp:ListItem>
            <asp:ListItem Text="Other" Value="other"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>


       <div class="form-group">
      <label class="control-label col-sm-2" for="gender">Gender:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="gender" runat="server">
              <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem Text="Male" Value="male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="female"></asp:ListItem>
            <asp:ListItem Text="No say" Value="nosay"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>
      

      <div class="form-group">
      <label class="control-label col-sm-2" for="race">Race:</label>
      <div class="col-sm-10">
           <asp:DropDownList ID="DropDownList1" runat="server">
               <asp:ListItem Enabled="true" Text="None"></asp:ListItem>
            <asp:ListItem Text="Asian" Value="asian"></asp:ListItem>
            <asp:ListItem Text="African" Value="african"></asp:ListItem>
            <asp:ListItem Text="American" Value="american"></asp:ListItem>
            <asp:ListItem Text="Hispanic" Value="hispanic"></asp:ListItem>
            <asp:ListItem Text="Native American" Value="native american"></asp:ListItem>
            <asp:ListItem Text="Pacific Islander" Value="pacific islander"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>
    
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
          <asp:Button runat="server"  class="btn btn-default" value="Submit" Text="Next" OnClick ="save_personal_info" OnClientClick="javascript:return ValidateDropDown();" />
          
      </div>
    </div>
    </div>
  </form>

    <script>

        function ValidateDropDown() {
            var cmbID = "<%=marital.ClientID %>";
            var cmbID1 = "<%=DropDownList1.ClientID %>";
            var cmbID2 = "<%=gender.ClientID %>";

            if (document.getElementById(cmbID).selectedIndex == 0) {
                alert("Please select a Value for Marital");
                return false;
            }

            if (document.getElementById(cmbID1).selectedIndex == 0) {
                alert("Please select a Value for Race");
                return false;
            }

            if (document.getElementById(cmbID2).selectedIndex == 0) {
                alert("Please select a Value for Gender");
                return false;
            }
            return true;
        }

       


    </script>



   
    


  </asp:Content>
