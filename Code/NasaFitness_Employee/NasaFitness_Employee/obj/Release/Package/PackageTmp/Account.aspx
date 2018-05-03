<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Account" Codebehind="Account.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <form id="form1" runat="server">
    <div class="row">
    <div class="col-md-6">
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" DisplayMode="BulletList" />
        <asp:Table runat="server" style="border-collapse:separate;border-spacing:1.5em">
        
        <asp:TableRow>
            <asp:TableCell>
                
                 <asp:Label runat="server" Text="Last Name:"   ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               
                 <asp:TextBox ID="lastname" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
       
        <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="First Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="firstname" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="Middle Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="middlename" CssClass="form-control" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Gender"></asp:Label>

            </asp:TableCell>
            <asp:TableCell>
              <asp:DropDownList ID="ddlGender" runat="server" Width="200px">
                <asp:ListItem Text="Select Gender" Value="0"></asp:ListItem>
                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
            </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" InitialValue="0" ControlToValidate="ddlGender" ErrorMessage="Gender is required" Display="None" />
            </asp:TableCell>
        </asp:TableRow>
       
        <asp:TableRow style="padding-bottom:5px;">
            <asp:TableCell>
                 <asp:Label runat="server" Text="Dob:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                
                         <asp:TextBox ID="dob" placeholder="MM/DD/YYYY" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="dob" ErrorMessage="Date of birth is required" Display="None" />
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow style="padding-bottom:5px;">
            <asp:TableCell>
                 <asp:Label runat="server" Text="Marital Status:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:DropDownList ID="maritalstatus" runat="server" Width="200px">
                <asp:ListItem Text="Select Marital Status" Value="0"></asp:ListItem>
                <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                <asp:ListItem Text="Married" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Divorsed" Value="3"></asp:ListItem>
            </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" InitialValue="0" ControlToValidate="maritalstatus" ErrorMessage="Select martial status." Display="None" />
            </asp:TableCell>
        </asp:TableRow>
       
   <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="Email:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="email" placeholder="abc@mail.com" CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="emailValid" ControlToValidate="email" ErrorMessage="Email address is required" Display="None" />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
                   ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="work Phone:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="workphone" CssClass="form-control" runat="server"></asp:TextBox>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="workphone"
        ErrorMessage="Invalid phone number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>--%>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="Cell Phone:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="cellphone" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="cellphone"
                    ErrorMessage="Invalid cell phone number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell>
                <%--<div class="row">
                    <div class="col-md-4">--%>
                        <asp:Label runat="server" Text="Emergency contact:"></asp:Label>

                       <%-- </div>
                    </div>--%>
               </asp:TableCell>
               <asp:TableCell>
              <%-- <div class="row">
                     <div class="col-md-6">
                         <asp:TextBox ID="emergencyname" placeholder="Name" CssClass="form-control" runat="server"></asp:TextBox><br />

                        </div>
                     <div class="col-md-6">--%>
                         <asp:TextBox ID="emergencycontactname" placeholder="contact name" CssClass="form-control" runat="server"></asp:TextBox>

<%--                        </div>

                </div>--%>
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
           <asp:TableCell>
                <%--<div class="row">
                    <div class="col-md-4">--%>
                        <asp:Label runat="server" Text="Emergency contact phone:"></asp:Label>

                       <%-- </div>
                    </div>--%>
               </asp:TableCell>
               <asp:TableCell>
              <%-- <div class="row">
                     <div class="col-md-6">
                         <asp:TextBox ID="emergencyname" placeholder="Name" CssClass="form-control" runat="server"></asp:TextBox><br />

                        </div>
                     <div class="col-md-6">--%>
                         <asp:TextBox ID="emergencyphone" placeholder="Phone" CssClass="form-control" runat="server"></asp:TextBox>

<%--                        </div>

                </div>--%>
                
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        </div>
        <div class="col-md-6">
    <asp:Table runat="server" style="border-collapse:separate;border-spacing:1.5em">
        <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="Address:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="address" placeholder="123 main st" CssClass="form-control" runat="server"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="city:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="State:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
   <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="zip:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="zip" CssClass="form-control" runat="server" ></asp:TextBox>
              <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="zip"
        ErrorMessage="Invalid zipcode" ValidationExpression=" \d{5}-?(\d{4})?$"></asp:RegularExpressionValidator>--%>
               

            </asp:TableCell>
        </asp:TableRow>
    <asp:TableRow >
            <asp:TableCell>
                 <asp:Label runat="server" Text="Hire Date:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             
                         <asp:TextBox ID="hiredate" placeholder="MM/DD/YYYY" CssClass="form-control" runat="server"></asp:TextBox>

            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Termination Date:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             
                         <asp:TextBox ID="terminationdate" placeholder="MM/DD/YYYY" CssClass="form-control" runat="server"></asp:TextBox>

                      
            </asp:TableCell>
        </asp:TableRow>
         
      
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Company Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="company" CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="company" ErrorMessage="Company name is required" Display="None" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Department:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox ID="department" CssClass="form-control" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Designation:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               
                 <asp:TextBox ID="designation" CssClass="form-control" runat="server"></asp:TextBox>
                
                    

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Support Group Contact:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               
                 <asp:TextBox ID="support_group_name" CssClass="form-control" runat="server" placeholder="contact name"></asp:TextBox>
                
                    

            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Support Group Contact:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               
                 <asp:TextBox ID="support_group_number" CssClass="form-control" runat="server" placeholder="phone number"></asp:TextBox>
                
                    

            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Doctor Contact Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               
                 <asp:TextBox ID="doctorname" CssClass="form-control" runat="server" placeholder="contact name"></asp:TextBox>
                
                    

            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
            <asp:TableCell>
                 <asp:Label runat="server" Text="Doctor email"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               
                 <asp:TextBox ID="doctorphone" CssClass="form-control" runat="server" placeholder="contact phone"></asp:TextBox>
                
                    

            </asp:TableCell>
        </asp:TableRow>

        </asp:Table>

        </div>
    </div>
    <div class="row">
        <div class="col-md-4">

        </div>
        <div class="col-md-4" >
<asp:Button   ID="save_button" width="90%"  runat="server" BackColor="#093965"  Text="Save" ForeColor="White" CssClass="btn" OnClick="save_button_Click"/>
        </div>
        <div class="col-md-4">

        </div>
    </div>
       </form>
</asp:Content>

