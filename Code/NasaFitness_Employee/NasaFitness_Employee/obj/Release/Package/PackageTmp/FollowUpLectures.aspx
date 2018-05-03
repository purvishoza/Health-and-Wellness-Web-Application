<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="FollowUpLectures.aspx.cs" Inherits="FollowUpLectures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
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
        <script type="text/javascript">
            //$(document).ready(function () {
            //    $("a.aclass").click(function () {
            //        alert($(this).attr('id'))

            //        return false;
            //    });
            //});
        </script>
       

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
     <div id="overlay"  class="overlay">
                <div class="spinner">
          </div>
                    </div>
           
            <div id="contents" >
    <div class="row">
        
            <h4 style="color:#093965">Prescribed Lectures and Videos</h4>
            <hr />
           
    </div>
    <div class="row">
                
                <div class="col-md-3">
                   <h5> Choose a category to view:</h5>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="viewcategory" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="viewcategory_SelectedIndexChanged">

                    </asp:DropDownList>
                    <hr />
                </div>
                </div>
    <asp:DataList ID="DataList2" Visible="true" runat="server" AutoGenerateColumns="false"
                    RepeatColumns="1" CellPadding="10" CellSpacing="10" Width="70%" Height="40%">

                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <div id="ppt" >
                         

                        <embed src="<%# "FollowUpPdf.ashx?id="+Eval("Presentation") %>" style="width:100%; height:450px"  />
                    </div>
                        <br />
                         <br /> <br />
                        </ItemTemplate>
                    </asp:DataList>
  <br />
    <br />
    
    <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
                    RepeatColumns="2" CellPadding="1" CellSpacing="1" Width="100%">

                    <ItemStyle HorizontalAlign="Center" />

                    <ItemTemplate>
                             <video id="vidd" class="col-md-2"  data-toggle="modal" data-target="loginModal" style="width: 100%" controls>     
                            <source src="<%# "FollowUpDetails.ashx?id=" + Eval("Id") %>">                       
                                 </video>            
                        <hr />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
        </form>
</asp:Content>
