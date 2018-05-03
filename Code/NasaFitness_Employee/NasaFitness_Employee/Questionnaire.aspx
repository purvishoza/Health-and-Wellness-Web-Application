<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Questionnaire" CodeBehind="Questionnaire.aspx.cs"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <%-- <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.3.1/css/buttons.dataTables.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/responsive/1.0.2/css/dataTables.responsive.css" />--%>

    <style>
        td {
            border-top: none !important;
            width: 60%;
        }

        table {
            border-collapse: separate;
            border-spacing: 1.5em;
            width:100%;
        }
        #save{
            margin-bottom:10px;
        }
       
      
    .radioButtonList { list-style:none; margin: 0; padding: 0;}
    .radioButtonList.horizontal li { display: inline;}

    .radioButtonList label{
        display:inline;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
     <form id="form1" runat="server">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <h1>Questionnaire
                    </h1>
                    <hr />
                    <div class="pull-right">
                            <asp:Button runat="server" CssClass=" btn-group btn-warning btn btn-primary" PostBackUrl="~/Month.aspx" CausesValidation="false"  Text="back" />
                   <br />
                    </div>
                    
                    <br />
                    <div class="row">
           <br /><br />
             <!-- Trigger the modal with a button -->
                    
                       

                    <!-- Modal -->
                            
                    
                        <%-- 
                            gridview code start
                            --%>
                        <div class="col-md-3 col-sm-6 col-xs-6" style="width:100%">
                        
                     
                        <asp:GridView ID="dgrid" RowStyle-Wrap="true" CssClass="table-responsive table dt-responsive nowrap" AutoGenerateColumns="false"  runat="server">
                            <Columns >
                              
                               <asp:TemplateField HeaderText="Question" ItemStyle-Wrap="true" ItemStyle-Width="40%">
                                 
                                   <ItemTemplate>
                                        <asp:Label ID="ques" runat="server" Text='<%# Eval("Questions") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                <asp:TemplateField HeaderText="Answers" ItemStyle-Width="25%">
                                   <ItemTemplate>
                                            
                                     <asp:RadioButtonList ID="ansid" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="True" />
                    <asp:ListItem Text="False" Value="False" />
                    </asp:RadioButtonList>
                                   </ItemTemplate>
                                  
                               </asp:TemplateField>
                                 
                            </Columns>

                        </asp:GridView>
                 

                    </div>

        </div>
                    
                  
                    
                    
                  <div class="center-block btn-group-vertical media-middle bottom" style="width:100px">
                        <asp:Button runat="server" ID ="save" CausesValidation="true" Text="Next" CssClass="btn btn-md btn-success" OnClick="save_Click" />
                    </div>
                    
                </div>
                
                
            </div>
       
         
    
  
    </form>

</asp:Content>








