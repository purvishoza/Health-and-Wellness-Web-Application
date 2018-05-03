<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Exam_Presentation" Codebehind="Exam_Presentation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
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
            <div class="row justify-content-md-center">
            <div class="col-xs-12 col-md-12">
             
                 <span style="color:red;font-size:medium">Done Watching?</span><br />
                 <asp:Button runat="server" ID ="done" Text="Click Here" CssClass="btn " BackColor="#093965" ForeColor="White" OnClick="done_Click"/>
                 </div>
        </div>
   
</asp:Content>

