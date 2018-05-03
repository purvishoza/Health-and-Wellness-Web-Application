<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="View_Presentation" Codebehind="View_Presentation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
            document.onreadystatechange = function () {
                var state = document.readyState
                if (state == 'interactive') {
                    document.getElementById('contents').style.visibility = "hidden";
                } else if (state == 'complete') {
                    setTimeout(function () {
                        document.getElementById('interactive');
                        document.getElementById('overlay').style.visibility = "hidden";
                        document.getElementById('contents').style.visibility = "visible";
                    }, 1000);
                }
               
            }
</script>

    <style type="text/css">
        .align {
            min-height: 100%; /* Fallback for browsers do NOT support vh unit */
            min-height: 100vh; /* These two lines are counted as one :-)       */
            display: flex;
            align-items: center;
        }
        #done{
            margin-bottom:10px;
        }
    </style>
    <style>

            .spinner{
    width: 80px;
    height:80px;
    border: 2px solid #f3f3f3;
    border-top:3px solid #f25a41;
    border-radius:100%;
    position:absolute; 
    display:block;
    top:0;
    bottom:0;
    left:0;
    right:0;
    margin:auto;
    animation: spin 1s infinite linear;
}

@keyframes spin {
    from{
        transform:rotate(0deg);
    }
    to{
        transform:rotate(360deg);
    }
}

#overlay
{
    height:100%;
    width:100%;
    background:rgba(0,0,0, .8);
    position:fixed;
    left:0;
    top:0;
    z-index:9999;
}
.loader {
	position: fixed;
	left: 0px;
	top: 0px;
	width: 100%;
	height: 100%;
	z-index: 9999;
	background: url('images/page-loader.gif') 50% 50% no-repeat rgb(249,249,249);
}
        </style>
     <link href="style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
         <div id="overlay"  class="overlay">
                <div class="spinner">
          </div>
                    </div>
        <div id="contents" >
            <div class="row justify-content-md-center">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <h1 id="heading" runat="server">
                        
                    </h1>
                    <hr style="width:100%" />
                    <div runat="server" id="ppt">
                   <%-- <iframe id="frame1" src='https://onedrive.live.com/embed?cid=6DECB2DEC50A81A9&resid=6DECB2DEC50A81A9%212004&authkey=ANgVJPeHWDcPMVU&em=2&wdAr=1.7777777777777777' width='610px' height='367px' frameborder='1'>This is an embedded <a target='_blank' href='https://office.com'>Microsoft Office</a> presentation, powered by <a target='_blank' href='https://office.com/webapps'>Office Online</a>.</iframe>
                    --%> 
                        <embed id="ppt1" width="610" height="367" runat="server"/>

                    </div>
                        <br />
                   
                </div>
               
            </div>
        <div class="row col-md-6">
                
                <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
                    RepeatColumns="4" CellPadding="1" CellSpacing="1" Width="100%" OnLoad="DataList1_Load">

                    <ItemStyle HorizontalAlign="Center" />

                    <ItemTemplate>
                       <asp:Label runat="server">
                                <%# Eval("Name") %></asp:Label><br />
                             <video id="vidd" class="col-md-2"  data-toggle="modal" data-target="loginModal" style="width: 100%" controls>
                                  
                            <source src="<%# "PresentationFileCS.ashx?id=" + Eval("MonthAndWeek") %>">                       
                                 </video>            
                        <hr />
                        </ItemTemplate>
                    </asp:DataList>
            </div>
            <div class="row justify-content-md-center">
            <div class="col-xs-12 col-md-12">
             
                 <span style="color:red;font-size:medium">Done Watching?</span><br />
                 <asp:Button runat="server" ID ="done" Text="Click Here" CssClass="btn btn-success" OnClick="done_Click"/>
                 </div>
        </div>
            </div>
    </form>
</asp:Content>

