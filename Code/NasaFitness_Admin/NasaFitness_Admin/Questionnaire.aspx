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
                        <button type="button"  class="btn btn-primary" style="color:white; background-color:#093965 "  data-toggle="modal" data-target="#myModal">
                          <span aria-hidden="true" class="glyphicon glyphicon-plus-sign">Add</span>
                    </button>
                            <asp:Button runat="server" CssClass=" btn-group btn-warning btn btn-primary" PostBackUrl="~/Month.aspx"  Text="back" />
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
                        
                     
                        <asp:GridView ID="dgrid" RowStyle-Wrap="true" CssClass="table-responsive table dt-responsive nowrap" AutoGenerateColumns="false" OnRowEditing="dgrid_RowEditing" OnRowCancelingEdit="dgrid_RowCancelingEdit" OnRowDeleting="dgrid_RowDeleting"  OnRowUpdating="dgrid_RowUpdating" runat="server">
                            <Columns >
                              
                               <asp:TemplateField HeaderText="Question" ItemStyle-Wrap="true" ItemStyle-Width="40%">
                                   <EditItemTemplate>
                                       <asp:RequiredFieldValidator ID="reqfield" runat="server" ControlToValidate="quesid" ValidationGroup="validation" ErrorMessage="Please enter all the fields" Display="None">

                                       </asp:RequiredFieldValidator>
                                       <asp:TextBox ID="quesid" Width="100%" CausesValidation="true" runat="server" Text='<%# Eval("Questions") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                        <asp:Label ID="ques" runat="server" Text='<%# Eval("Questions") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                <asp:TemplateField HeaderText="Answers" ItemStyle-Width="25%">
                                   <EditItemTemplate>
                                     <asp:RadioButtonList ID="ansid" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="True" />
                    <asp:ListItem Text="False" Value="False" />
                    </asp:RadioButtonList>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Answers") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                  <asp:CommandField ButtonType="Button" HeaderText="Edit/Delete"  ItemStyle-Wrap="false" ItemStyle-Width="35%" ControlStyle-CssClass="btn btn-info" ShowDeleteButton="true" ShowEditButton="true" />
                            </Columns>

                        </asp:GridView>
                        <%--<table id="example" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Extn.</th>
                <th>Start date</th>
                <th>Salary</th>
            </tr>
        </thead>
                            </table>--%>

                    </div>

        </div>
                    
                  
                    
                    
                  <div class="center-block btn-group-vertical media-middle bottom" style="width:100px">
                        <asp:Button runat="server" ID ="save" Text="Next" CssClass="btn btn-md btn-success" OnClick="save_Click" />
                    </div>
                    
                </div>
                
                
            </div>
       
         <div class="modal fade" id="myModal" role="dialog" data-backdrop="true">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Add New Questions</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox runat="server" ID="modalQuestion" CssClass="form-control dumm"></asp:TextBox><br />
                                     <asp:RadioButtonList ID="ModalRadioButtons" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="T" />
                    <asp:ListItem Text="False" Value="F" />
                    </asp:RadioButtonList>
                                    
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" ID="addCat" CssClass="btn" BackColor="#093965" ForeColor="White" OnClick="Store_Modal_data" Text="Add" />
                                    <button type="button" class="btn btn-danger mdlCls">Close</button>
                                </div>
                                  <script type="text/javascript">
                                 
                      $('.mdlCls').click(function () {
                          $('.dumm').val("");

                          var rad = document.getElementById('<%=ModalRadioButtons.ClientID %>');
                          var radio = rad.getElementsByTagName("input");
                          for (var i = 0; i < radio.length; i++) {
                              radio[i].checked = false;     
                          }
                          $('#myModal').modal('hide');
                     
                      });
                        </script>
                            </div>

                        </div>
                    </div>
    
    </form>
   
    <%--<script>
        $(document).ready(function () {
            var a = [""];
            $('.ans').each(function (i) {
                a[i] = $(this).val();
                
            });
            var l = a.length;
            for (var j = 0; j < a.length; j++) {
                if (a[j] == "True") {
                    //alert(a[j]);
                    var k = document.getElementById("rdt1");
                    
                    $('.rd1').prop("Checked", "True");
                    $('.rd2').prop("Checked", "False");
                   // alert($('.rd1').prop('Checked'));
                }
                else {
                    //alert(a[j]);
                    $('.rd1').prop("Checked", "False");
                    $('.rd2').prop("Checked", "True");
                   // alert($('.rd2').prop('Checked'));
                }
            };

           
        });
    </script>--%>

</asp:Content>








