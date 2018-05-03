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
        <!--<input type="text" class="form-control" id="fname" placeholder="Enter first name" name="fname">-->
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="lname">Last Name:</label>
      <div class="col-sm-10"> 
          <asp:TextBox runat="server" ID ="lname" class="form-control" placeholder="Enter last name" ></asp:TextBox>
        <!--<input type="text" class="form-control" id="lname" placeholder="Enter last name" name="lname">-->
      </div>
        </div>


        <div class="form-group">
      <label class="control-label col-sm-2" for="address">Address:</label>
      <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="address" class="form-control" placeholder="Enter address" ></asp:TextBox>
       <!-- <input type="text" class="form-control" id="address" placeholder="Enter address" name="address">-->
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="city">City:</label>
      <div class="col-sm-10">
         <asp:TextBox runat="server" ID ="city" class="form-control" placeholder="Enter city" ></asp:TextBox> 
        <!--<input type="text" class="form-control" id="city" placeholder="Enter city" name="lname">-->
      </div>
    </div>


        <div class="form-group">
      <label class="control-label col-sm-2" for="state">State:</label>
      <div class="col-sm-10">
         <asp:TextBox runat="server" ID ="state" class="form-control" placeholder="Enter state" ></asp:TextBox> 
        <!--<input type="text" class="form-control" id="state" placeholder="Enter state" name="state">-->
      </div>
    </div>


        <div class="form-group">
      <label class="control-label col-sm-2" for="zip">Zip:</label>
      <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="zip" class="form-control"  ></asp:TextBox>
        <!--<input type="number" class="form-control" id="zip"  name="zip">-->
      </div>
    </div>


       <div class="form-group">
      <label class="control-label col-sm-2" for="dob">DOB:</label>
      <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="dob" class="form-control" ></asp:TextBox>
        <!--<input type="number" class="form-control" id="dob"  name="dob">-->
      </div>
    </div>


       <div class="form-group">
      <label class="control-label col-sm-2" for="ms">Marital Status:</label>
      <div class="col-sm-10">
         <asp:DropDownList ID="marital" runat="server">
            <asp:ListItem Enabled="true" Text="Marital Status" Value="single"></asp:ListItem>
            <asp:ListItem Text="Single" Value="single"></asp:ListItem>
            <asp:ListItem Text="Married" Value="married"></asp:ListItem>
            <asp:ListItem Text="Separated" Value="separated"></asp:ListItem>
        </asp:DropDownList>
      <!-- <select name="marital">
      <option value="single">Single</option>
      <option value="married">Married</option>
      <option value="separated">Separated</option>
</select>-->
      </div>
    </div>


       <div class="form-group">
      <label class="control-label col-sm-2" for="gender">Gender:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="gender" runat="server">
            <asp:ListItem Enabled="true" Text="Gender" Value="male"></asp:ListItem>
            <asp:ListItem Text="Male" Value="male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="female"></asp:ListItem>
            <asp:ListItem Text="No say" Value="nosay"></asp:ListItem>
        </asp:DropDownList>
       <!--<select name="gender">
      <option value="male">Male</option>
      <option value="female">Female</option>
      <option value="no say">No say</option>
</select>-->
      </div>
    </div>
      

      <div class="form-group">
      <label class="control-label col-sm-2" for="race">Race:</label>
      <div class="col-sm-10">
           <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Enabled="true" Text="Race" Value="race"></asp:ListItem>
            <asp:ListItem Text="Asian" Value="asian"></asp:ListItem>
            <asp:ListItem Text="American" Value="american"></asp:ListItem>
            <asp:ListItem Text="Canadian" Value="canadian"></asp:ListItem>
        </asp:DropDownList>
       <!--<select name="race">
      <option value="asian">Asian</option>
      <option value="american">American</option>
      <option value="canadian">Canadian</option>
</select>-->
      </div>
    </div>
    
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
          <asp:Button runat="server"  class="btn btn-default" value="Submit" Text="Next" OnClick ="save_personal_info"  />
          
       <!-- <button type="submit" class="btn btn-default" value ="">Next</button>-->
      </div>
    </div>
    </div>
  </form>


  </asp:Content>
