<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PersonalInformation2.aspx.cs" Inherits="NasaFitness_Employee.PersonalInformation2" %>
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
                            <asp:LinkButton runat="server" Text="Secondary Insurance" PostBackUrl="PersonalInformation3.aspx"></asp:LinkButton></li>
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
        <!--<input type="number" class="form-control" id="pinsID"  name="pinsID">-->
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="pign">Primary Insurance Group Number:</label>
        <div class="col-sm-10">
           <asp:TextBox runat="server" ID ="pign" class="form-control" placeholder="Enter primary insurance group number" ></asp:TextBox>
        <!--<input type="number" class="form-control" id="pign"  name="pign">-->
        </div>
    </div>


    <div class="form-group">
     <label class="control-label col-sm-2" for="company">Primary Insurance Company:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="company" runat="server">
            <asp:ListItem Enabled="true" Text="test1" Value="test1"></asp:ListItem>
            <asp:ListItem Text="test2" Value="test2"></asp:ListItem>
            <asp:ListItem Text="test3" Value="test3"></asp:ListItem>
        </asp:DropDownList>
      <!--<select name="company">
          <option value="test1">test1</option>
          <option value="test2">test2</option>
          <option value="test3">test3</option>
      </select>-->
      </div>
    </div>

    <div class="form-group">
     <label class="control-label col-sm-2" for="type">Type of Insurance:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="type" runat="server">
            <asp:ListItem Enabled="true" Text="Choice Plus" Value="Choice Plus"></asp:ListItem>
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
      <!--<select name="type">
          <option value="Choice Plus">Choice Plus</option>
          <option value="HMO">HMO</option>
          <option value="PPO">PPO</option>
          <option value="POS">POS</option>
          <option value="Open Access">Open Access</option>
          <option value="Indemnity">Indemnity</option>
          <option value="PIP">PIP</option>
          <option value="Med-Pay">Med-Pay</option>
          <option value="LOP">LOP</option>
          <option value="WC">WC</option>
          <option value="Medicare">Medicare</option>
          <option value="Medicaid">Medicaid</option>
          <option value="Cash">Cash</option>
      </select>-->
      </div>
    </div>


    <div class="form-group">
     <label class="control-label col-sm-2" for="relation">Relationship to insured:</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="relation" runat="server">
            <asp:ListItem Enabled="true" Text="Self" Value="Self"></asp:ListItem>
            <asp:ListItem Text="Spouse" Value="Spouse"></asp:ListItem>
            <asp:ListItem Text="Child" Value="Child"></asp:ListItem>
            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
        </asp:DropDownList>
      <!--<select name="relation">
          <option value="Self">Self</option>
          <option value="Spouse">Spouse</option>
          <option value="Child">Child</option>
          <option value="Other">Other</option>
      </select>-->
      </div>
    </div>

    <div class="form-group">
      <label class="control-label col-sm-2" for="Gname">Guarantor Name:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gname" class="form-control" placeholder="Enter Guarantor Name" ></asp:TextBox>
        <!--<input type="text" class="form-control" id="Gname" placeholder="Enter Guarantor Name" name="Gname">-->
      </div>
    </div>

     <div class="form-group">
      <label class="control-label col-sm-2" for="Gaddress">Guarantor Address:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gaddress" class="form-control" placeholder="Enter address" ></asp:TextBox>
        <!--<input type="text" class="form-control" id="Gaddress" placeholder="Enter address" name="Gaddress">-->
      </div>
    </div>


    <div class="form-group">
      <label class="control-label col-sm-2" for="Gcity">Guarantor City:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gcity" class="form-control" placeholder="Enter city" ></asp:TextBox>
        <!--<input type="text" class="form-control" id="Gcity" placeholder="Enter city" name="Gcity">-->
      </div>
    </div>


     <div class="form-group">
      <label class="control-label col-sm-2" for="Gstate">Guarantor State:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gstate" class="form-control" placeholder="Enter state" ></asp:TextBox>
        <!--<input type="text" class="form-control" id="Gstate" placeholder="Enter state" name="Gstate">-->
      </div>
    </div>


     <div class="form-group">
      <label class="control-label col-sm-2" for="Gzip">Guarantor Zip:</label>
        <div class="col-sm-10">
          <asp:TextBox runat="server" ID ="Gzip" class="form-control" placeholder="Enter zip" ></asp:TextBox>
        <!--<input type="number" class="form-control" id="Gzip"  name="Gzip">-->
        </div>
    </div>


    
    <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
          <asp:Button runat="server"  class="btn btn-default" value="Submit" Text="Next" OnClick ="save_primaryIns_info"  />
       
      </div>
    </div>


    </div>
  </form>


  </asp:Content>