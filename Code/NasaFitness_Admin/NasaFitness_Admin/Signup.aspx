<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="NasaFitness_Admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" style="background-image:none">
     <meta name="viewport" content="width=device-width, initial-scale=1">
   
	<link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.3.1/css/buttons.dataTables.min.css" />
  
    <link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/responsive/1.0.2/css/dataTables.responsive.css" />
     
    <!--<link rel="stylesheet" href="css/style.css" />-->
	<style type="text/css">
        
        body
        {
            margin: 50px;
        }
        body {
    margin: 50px;
    color: #6a6f8c;
    
    /*background:#c8c8c8;*/
    /*background-color: plum;*/
    /* background-image: url('backgro.jpg');*/
   /*background-image: url('../images/bck1.jpg');*/
    background-repeat: no-repeat;
    background-size: 100%;
    font: 600 16px/18px 'Open Sans',sans-serif;
}

*,:after,:before{box-sizing:border-box}
.clearfix:after,.clearfix:before{content:'';display:table}
.clearfix:after{clear:both;display:block}
a{color:inherit;text-decoration:none}

.login-wrap {
    width: 100%;
    margin: auto;
    margin-top:5%;
    max-width: 525px;
    min-height: 750px;
    position: relative;
    /* background: url(https://raw.githubusercontent.com/khadkamhn/day-01-login-form/master/img/bg.jpg) no-repeat center;*/
    /* background-image: url('divback.jpg');*/
    /* background-repeat: no-repeat;
    background-size: 100%;*/
    /* box-shadow: 0 12px 15px 0 rgba(0,0,0,.24),0 17px 50px 0 rgba(0,0,0,.19);*/
}
.login-html{
    width: 100%;
    height: 600px;
    position: absolute;
    padding: 50px 70px 50px 70px;
    background:rgba(40,57,101,.9);
    opacity:0.7;
}
.login-html1{
    width: 100%;
    height: 900px;
    position: absolute;
    padding: 50px 70px 50px 70px;
    background:rgba(40,57,101,.9);
    opacity:0.7;
}

.login-html .sign-in-htm,
.login-html .sign-up-htm,
.login-html1 .sign-up-htm{
	top:3%;
	left:0;
	right:0;
	bottom:0;
    height:550px;

	/*position:absolute;
	-webkit-transform:rotateY(180deg);
	        transform:rotateY(180deg);
	-webkit-backface-visibility:hidden;
	        backface-visibility:hidden;
	-webkit-transition:all .4s linear;
	transition:all .4s linear;*/
}
.login-html .sign-in,
.login-html .sign-up,
.login-html1 .sign-up,
.login-form .group .check{
	display:none;
}
.login-html .tab,
.login-html1 .tab,
.login-form .group .label,
.login-form .group .button{
	text-transform:uppercase;
}
.login-html .tab,
.login-html1 .tab{
	font-size:22px;
   
	margin-right:15px;
	padding-bottom:5px;
	margin:0 15px 10px 0;
	display:inline-block;
	border-bottom:2px solid transparent;
}
.login-html .sign-in:checked + .tab,
.login-html .sign-up:checked + .tab,
.login-html1 .sign-up:checked + .tab{
	color:#fff;
	border-color:#1161ee;
}
.login-form{
	min-height:345px;
	position:relative;
	-webkit-perspective:1000px;
	        perspective:1000px;
	-webkit-transform-style:preserve-3d;
	        transform-style:preserve-3d;
}
.login-form .group{
	margin-bottom:15px;
}
.login-form .group .label,
.login-form .group .input,
.login-form .group .button{
	width:100%;
	color:#fff;
	display:block;
}
.login-form .group .input,
.login-form .group .button{
	border:none;
	padding:15px 20px;
	border-radius:25px;
	background:rgba(255,255,255,.1);
    font-size:18px;
}
.login-form .group input[data-type="password"]{
	text-security:circle;
	-webkit-text-security:circle;
}
    .login-form .group .label {
        /*color:#aaa;*/
        color: #ffffff;
        font-size: 19px;
    }
.login-form .group .button{
	background:#1161ee;
}
.login-form .group label .icon{
	width:15px;
	height:15px;
	border-radius:2px;
	position:relative;
	display:inline-block;
	background:rgb(255,255,255);
}
.login-form .group label .icon:before,
.login-form .group label .icon:after{
	content:'';
	width:10px;
	height:2px;
	background:#fff;
	position:absolute;
	-webkit-transition:all .2s ease-in-out 0s;
	transition:all .2s ease-in-out 0s;
}
.login-form .group label .icon:before{
	left:3px;
	width:5px;
	bottom:6px;
	-webkit-transform:scale(0) rotate(0);
	        transform:scale(0) rotate(0);
}
.login-form .group label .icon:after{
	top:6px;
	right:0;
	-webkit-transform:scale(0) rotate(0);
	        transform:scale(0) rotate(0);
}
.login-form .group .check:checked + label{
	color:#fff;
}
.login-form .group .check:checked + label .icon{
	background:#1161ee;
}
.login-form .group .check:checked + label .icon:before{
	-webkit-transform:scale(1) rotate(45deg);
	        transform:scale(1) rotate(45deg);
}
.login-form .group .check:checked + label .icon:after{
	-webkit-transform:scale(1) rotate(-45deg);
	        transform:scale(1) rotate(-45deg);
}
.login-html .sign-in:checked + .tab + .sign-up + .tab + .login-form .sign-in-htm{
	-webkit-transform:rotate(0);
	        transform:rotate(0);
}
.login-html .sign-up:checked + .tab + .login-form .sign-up-htm{
	-webkit-transform:rotate(0);
	        transform:rotate(0);
}

.hr{
	height:2px;
	margin:60px 0 50px 0;
	background:rgba(255,255,255,.2);
}
.foot-lnk{
    
	text-align:center;
    color:rgba(255,255,255,.2);
}


    </style>
  
   </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" style="background-image:none">
        
        <form runat="server">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <h1>Add New Account</h1>
                    <hr />
                    <asp:Panel ID="panel1" runat="server" Visible="true" Width="100%">
                         <div class="login-wrap">
                             <div class="login-html1">
                                <label for="tab-2" class="tab" style="color:white">Sign Up!</label>
		                        <div class="login-form">           
                                <div class="sign-up-htm">
				                   <div class="group">
					               <label for="user" class="label" style="text-align:left">Username</label>
                                         <asp:TextBox runat="server" ID ="user1" class="input" placeholder="Joe213"></asp:TextBox>		
				                    </div>
                                    <div class="group">
                                        <label for="pass" class="label" style="text-align:left">First Name</label><br />
                                        <asp:TextBox runat="server" ID="fname" class="input"></asp:TextBox>

                                    </div>
                                    <div class="group">
                                        <label for="pass" class="label" style="text-align:left">Last Name</label><br />
                                        <asp:TextBox runat="server" ID="lname" class="input"></asp:TextBox>

                                    </div>
                                    <div class="group">
                                        <label for="pass" class="label" style="text-align:left">Email Address</label><br />
                                        <asp:TextBox runat="server" ID="email" class="input"></asp:TextBox>

                                    </div>
                                    <div class="group">
                                        <label for="pass" class="label" style="text-align:left">Password</label><br />
                                        <asp:TextBox runat="server" ID="pass1" type="password" class="input" text-mode="password"></asp:TextBox>

                                    </div>
                                    <div class="group">
                                        <label for="pass" class="label" style="text-align:left">Repeat Password</label><br />
                                        <asp:TextBox runat="server" ID="pass2" type="password" class="input" text-mode="password"></asp:TextBox>

                                    </div>
                                    <br />

                                    <div class="group">
                                        <asp:Button runat="server" type="submit" class="button" value="Sign Up" Text="Sign Up" OnClick="Signup_Click" />

                                    </div>

                                </div>
                                </div>
                             </div>
                         </div>
                             
                    </asp:Panel>

                </div>
            </div>
 
    </form>
      
</asp:Content>

