<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="viewVideo.aspx.cs" Inherits="viewVideo" %>
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
        
            <h4 style="color:#093965">View Videos</h4>
            <hr />
           
            <div class="row">
                
                <div class="col-md-3">
                   <h5> Choose Video category to view:</h5>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="viewcategory" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="viewcategory_SelectedIndexChanged">

                    </asp:DropDownList>
                </div>
                </div>
           
                
            <br />
            <br />
         
            <div class="row col-md-6">
                
                <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
                    RepeatColumns="2" CellPadding="10" CellSpacing="10" Width="200%">

                    <ItemStyle HorizontalAlign="Center" />

                    <ItemTemplate>
                        <%-- pradeep code video player start--%>
                      <%--  <div class="featured-article">
				 <a href="#loginModal" data-toggle="modal" id="videoid1">
                             <video id="vidd11" class="col-md-2"  data-toggle="modal" data-target="loginModal" style="width: 100%" controls>
                                  
                            <source src="<%# "FileCS.ashx?id=" + Eval("Id") %>">

                        </video>
                        </a>
				<div class="block-title">
					<h2>Lorem ipsum dolor asit amet</h2>
					<p class="by-author"><small>By Jhon Doe</small></p>
				</div>
			</div>--%>

                        <%-- pradeep code video player end--%>


                        <asp:Label runat="server">
                                <%# Eval("Name") %></asp:Label><br />
                        <a href="#loginModal" data-toggle="modal" data-theVideo="<%#  Eval("Id") %>" id="<%#  Eval("Id") %>" class="aclass">
                            
                             <video id="vidd" class="col-md-2" style="width: 100%" preload="metadata" controls>
                                  
                            <source src="<%# "FileCS.ashx?id=" + Eval("Id") %>">

                            

                        </video>
                        </a>            
                        <hr />
                    
                          
                    </ItemTemplate>                 
                                                                             <%--pradeep code start--%>
            
                  
                </asp:DataList>
                <%-- start --%>
                  <script>
                      var sr;              
                      $('.aclass').click(function () {
                          var val = $(this).attr('data-theVideo');
                          alert(val);
                          sr = "FileCS.ashx?id=" + val;
                          alert(sr);
                          $('.sid').prop('src',sr );
                          alert($('.sid').prop('src'));
                     
                      });

                      function myfun()
                      {
                          return sr;
                      }
                     
                        </script>
                        <div class="modal fade" tabindex="-1" id="loginModal"
        data-keyboard="false" data-backdrop="static" >
    <div class="modal-dialog modal-lg" >
        <div class="modal-content">
            <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal">
                    &times;
                </button>
            </div>
            <div class="modal-body">
               
                
                      <div class="modal-video">
                    <div class="embed-responsive embed-responsive-16by9">
                        <%--<iframe class="sid" style="width:100%" height="350" > </iframe>--%>
                       <video id="vidd1" class="col-md-2" runat="server"   style="width: 100%" controls>
                                  
                                                <source class="sid">
                           

                        </video>
                     <%-- <iframe id="vidd1" class="col-md-2 sid"   style="width: 100%">
                          <asp:FormView runat="server">

                          </asp:FormView>
                      </iframe>--%>
                    </div>
                </div>
                <%--pradeep code end--%>
                  </div>
            </div>
        </div>
                </div>
                <%-- end --%>
            </div>
           
                <%--</div>
            </div>
        </div>
                </div>--%>
            
           </div>
      </form>
</asp:Content>
