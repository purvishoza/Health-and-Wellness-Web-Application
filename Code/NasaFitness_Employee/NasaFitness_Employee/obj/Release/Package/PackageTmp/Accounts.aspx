<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="NasaFitness_Employee.Accounts" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
   <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        #modal_table {
            width: 100%;
            border-collapse: separate;
            border-spacing: 1.5em;
        }
        thead tr th, th {
            background-color: #093965;
            text-align: center;
            color: white;
        }

        td {
            text-align: center;
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
            label.checkbox:before {
    content: "☐ ";
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server" id="sub">
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
        </form>
          <div class="container">
  <h2>STEP 1</h2>
  <form class="form-horizontal" action="/PersonalInformation2.aspx">
    <div class="form-group">
      <label class="control-label col-sm-2" for="fname">First Name:</label>
      <div class="col-sm-10">
        <input type="text" class="form-control" id="fname" placeholder="Enter first name" name="fname">
      </div>
    </div>
    <div class="form-group">
      <label class="control-label col-sm-2" for="lname">Last Name:</label>
      <div class="col-sm-10">          
        <input type="text" class="form-control" id="lname" placeholder="Enter last name" name="lname">
      </div>
        </div>
        <div class="form-group">
      <label class="control-label col-sm-2" for="address">Address:</label>
      <div class="col-sm-10">
        <input type="text" class="form-control" id="address" placeholder="Enter address" name="address">
      </div>
    </div>
    <div class="form-group">
      <label class="control-label col-sm-2" for="city">City:</label>
      <div class="col-sm-10">          
        <input type="text" class="form-control" id="city" placeholder="Enter city" name="lname">
      </div>
    </div>
        <div class="form-group">
      <label class="control-label col-sm-2" for="state">State:</label>
      <div class="col-sm-10">          
        <input type="text" class="form-control" id="state" placeholder="Enter state" name="state">
      </div>
    </div>
        <div class="form-group">
      <label class="control-label col-sm-2" for="zip">Zip:</label>
      <div class="col-sm-10">          
        <input type="number" class="form-control" id="zip"  name="zip">
      </div>
    </div>
       <div class="form-group">
      <label class="control-label col-sm-2" for="dob">DOB:</label>
      <div class="col-sm-10">          
        <input type="number" class="form-control" id="dob"  name="dob">
      </div>
    </div>
       <div class="form-group">
      <label class="control-label col-sm-2" for="ms">Marital Status:</label>
      <div class="col-sm-10">          
       <select name="marital">
      <option value="single">Single</option>
      <option value="married">Married</option>
      <option value="separated">Separated</option>
</select>
      </div>
    </div>
       <div class="form-group">
      <label class="control-label col-sm-2" for="gender">Gender:</label>
      <div class="col-sm-10">          
       <select name="gender">
      <option value="male">Male</option>
      <option value="female">Female</option>
      <option value="no say">No say</option>
</select>
      </div>
    </div>
      <div class="form-group">
      <label class="control-label col-sm-2" for="race">Race:</label>
      <div class="col-sm-10">          
       <select name="race">
      <option value="asian">Asian</option>
      <option value="american">American</option>
      <option value="canadian">Canadian</option>
</select>
      </div>
    </div>
    
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
        <button type="submit" class="btn btn-default" value ="">Next</button>
      </div>
    </div>
  </form>
</div>
	
   
</asp:Content> 
