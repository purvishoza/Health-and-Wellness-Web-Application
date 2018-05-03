<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Upload_Documents" Codebehind="Upload_Documents.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <link class="jsbin" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
<script class="jsbin" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
<script class="jsbin" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.0/jquery-ui.min.js"></script>
<meta charset=utf-8 />
<style>
       .GridPager td 
    {
       padding-left: 4px;     
       padding-right: 4px;   
    }
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Medical Record Requests</h2>
            <hr />
            <form runat="server">
            <div class="row">

                <div class="col-md-5">
                    <label>
                        Click here to Add files
              <input type="file" id="FileUpload1" class="btn btn-default" runat="server" onchange="readURL(this);"/>

                    </label>
                    <asp:Button runat="server" ID="UploadButton"  BackColor="#093965" ForeColor="White" Text="Upload" OnClick="UploadButton_Click" CssClass="btn" /><br />

                    <br />
                     <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="#093965" HeaderStyle-ForeColor="White"
                        AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-condensed" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">
                        <Columns>
                            
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Date" HeaderText="Date" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="View" OnClick="Unnamed_Click" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                       <PagerStyle CssClass = "GridPager" />
                    </asp:GridView>
                    <center>
        <asp:Button ID="remove" runat="server"  BackColor="#093965" ForeColor="White" Text="Remove" CssClass="btn" OnClick="remove_Click" />
       </center>
               </div>
                 
                <div class="col-md-5 col-md-offset-1">
                     
                       <center> <asp:Label style="font-weight:bolder" ID="displayfile" runat="server"></asp:Label></center><br />
                        <asp:Literal ID="ltEmbed" runat="server" />
                    
                    

               </div>
			</div>
			</form>
   
</asp:Content>
