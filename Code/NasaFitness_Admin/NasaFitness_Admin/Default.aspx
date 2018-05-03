<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <meta charset="UTF-8"/>
  <title>NASA Fitness, LLC</title>
  
  
  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Open+Sans:600' />

      <link rel="stylesheet" href="css/style.css" />
</head>
<body onload="HideDiv('fa')">
     <header>
           <center><h1 style="text-align:center;color:rgba(40,57,101,.9);font-family:Georgia Bold;margin-left:0;font-size:50PX">NASA FITNESS, LLC</h1></center> 
        
        </header>
    <form id="form1" runat="server">
        
    <div id="myform1" class="login-wrap">
	<div class="login-html">

		<input id="tab-1" type="radio" name="tab" class="sign-in" checked="checked"/><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab"></label>
		<div class="login-form">
			<div class="sign-in-htm">
				<div class="group">
					<label for="user" class="label">Username</label><br />
                    <asp:TextBox runat="server" id="user" type="text" class="input" placeholder="Jone123" ></asp:TextBox>
					
				</div>
               
				<div class="group">
					<label for="pass" class="label">Password</label><br />
                    <asp:TextBox runat="server" id="pass" textmode="Password" class="input" data-type="password"></asp:TextBox>
					
				</div>
				<div class="group">
                   
					<input runat="server" id="check" type="checkbox" class="check" checked="checked"/>
					<label for="check"><span class="icon"></span> Keep me Signed in</label>
				</div>
				<div class="group">
                    <asp:Button runat="server" type="submit" class="button" value="Sign In" Text="Sign In" OnClick="logIn" />
					
				</div>
				<div class="hr"></div>
				<div class="group">
					<!--<a href="#" onclick="HideDiv(Flag);return:false" style="color:white">Forgot Password? </a>-->
                    <asp:Button runat="server" type="submit" class="button" value="Forgot Password" Text="Forgot Password?" OnClientClick="HideDiv('first');return false;" />
					
				</div>
			</div>
			<!--<div class="sign-up-htm">
				<div class="group">
					<label for="user" class="label">Username</label>
                    <asp:TextBox runat="server" ID ="user1" class="input" placeholder="Joe213"></asp:TextBox>
					
				</div>
                 <div class="group">
					<label for="pass" class="label">First Name</label><br />
                    <asp:TextBox runat="server" id="fname" class="input"></asp:TextBox>
					
				</div>
                 <div class="group">
					<label for="pass" class="label">Last Name</label><br />
                    <asp:TextBox runat="server" id="lname" class="input"></asp:TextBox>
					
				</div>
                <div class="group">
					<label for="pass" class="label">Employee ID</label><br />
                    <asp:TextBox runat="server" id="empid" class="input"></asp:TextBox>
					
				</div>
				<div class="group">
					<label for="pass" class="label">Password</label><br />
                    <asp:TextBox runat="server" id="pass1" type="password" class="input" text-mode="password"></asp:TextBox>
					
				</div>
				<div class="group">
					<label for="pass" class="label">Repeat Password</label><br />
                    <asp:TextBox runat="server" id="pass2" type="password" class="input" text-mode="password"></asp:TextBox>
					
				</div>
				
				<div class="group">
                    <asp:Button runat="server" type="submit" class="button" value="Sign Up" Text="Sign Up" OnClick="signUP" />
					
				</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					<label for="tab-1" style="color:white"><a>Already Member?</a></label>
				</div>
			</div>-->
		</div>
	</div>
    </div>
        <div id="myform2" class="login-wrap">
	<div class="login-html">
        <div class="login-form">
        <div class="group">      
            <label for="recovery" class="label">Recovery Password</label><br />
            <asp:TextBox runat="server" id="recovery" type="text" class="input" ></asp:TextBox><br />
             <asp:RequiredFieldValidator id="RequiredFieldValidator" runat="server" ControlToValidate="recovery" ErrorMessage="Enter valid Email " ForeColor="Red" Display="none" ValidationGroup="recover">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="recovery" ErrorMessage="Missing @ symbol" ValidationExpression=".+@.+" ValidationGroup="recover" ForeColor="red" Display="none">
                </asp:RegularExpressionValidator><br/><br />
            <label style="color:white">The email you are typing must match the email in records.If the emails match you will receive an email with login information.</label><br /><br />
        
             <asp:Button runat="server" type="submit" class="button" value="Recovery Password" Text="Recovery Password" OnClick="Recovery_Click" ValidationGroup="recover"/><br /><br />
             <asp:Button runat="server" type="submit" class="button" value="cancel and go back" Text="Cancel and go back"/>
        </div>
            </div>
    </div>
</div>
    </form>
    <script type="text/javascript">
    function HideDiv(Flag) {
        if (Flag == "first") {
            document.getElementById('myform1').style.display = 'none';
            document.getElementById('myform2').style.display = 'block';           
        }
        else {
            document.getElementById('myform1').style.display = 'block';
            document.getElementById('myform2').style.display = 'none';
        }
    }
</script>
</body>
</html>
