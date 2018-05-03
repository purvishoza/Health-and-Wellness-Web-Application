<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="viewResults.aspx.cs" Inherits="viewResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="row">
                <div class="col-md-8 pull-left">
                    <h1>Results
                    </h1>
                    <hr />                    
                    <br />
                    </div>

    </div>
    <div class="row">
        <div class="col-md-3 col-sm-6 col-xs-6" style="width:100%">
                        
                     
                        <asp:GridView ID="dgrid" RowStyle-Wrap="true" CssClass="table-responsive table dt-responsive nowrap" AutoGenerateColumns="false"  runat="server">
                            <Columns >
                              
                               <asp:TemplateField HeaderText="Question" ItemStyle-Wrap="true" ItemStyle-Width="25
                                   %">
                                 
                                   <ItemTemplate>
                                        <asp:Label ID="ques" runat="server" Text='<%# Eval("Questions") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correct Answers" ItemStyle-Width="25%">
                                   <ItemTemplate>
                                    <asp:Label ID="ques" runat="server" Text='<%# Eval("Answers") %>'></asp:Label>
                                   </ItemTemplate>
                                  
                               </asp:TemplateField>
                                <asp:TemplateField HeaderText="Before Presentation Results" ItemStyle-Width="25%">
                                   <ItemTemplate>
                                    <asp:Label ID="ques" runat="server" Text='<%# Eval("BeforeReading") %>'></asp:Label>
                                   </ItemTemplate>
                                  
                               </asp:TemplateField>
                                <asp:TemplateField HeaderText="After Presentation Results" ItemStyle-Width="25%">
                                   <ItemTemplate>
                                    <asp:Label ID="ques" runat="server" Text='<%# Eval("AfterReading") %>'></asp:Label>
                                   </ItemTemplate>
                                  
                               </asp:TemplateField>
                                 
                            </Columns>

                        </asp:GridView>
                 
            <hr />                    
                    <br />
             <div class="center-block btn-group-vertical media-middle bottom" style="width:100px">
                        <asp:Button runat="server" ID ="Done" Text="Next" CssClass="btn btn-md btn-success" OnClick="save_Click" />
                    </div>
                    </div>

    </div>
        </form>
</asp:Content>
