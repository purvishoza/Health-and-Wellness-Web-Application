<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Add_Classes" Codebehind="Add_Classes.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
    .rbl input[type="radio"]
{
   margin-left: 30px;
   margin-right: 1px;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
          <div class="row">
         <h2 class="col-md-6">Adding Presentations to Classes</h2>
        <h2><asp:Button ID="back" runat="server" onclick="back_nav" Text="BACK" CssClass="btn btn-default col-md-2" style="float:right;" /></h2>
          </div>
  <p></p>
  
    <div class="form-group">
       <div class="row">
      <label for="month">Select Month (select one):</label>
           </div>
        <div class="row">
      <asp:DropDownList class="form-control" runat="server" ID="monthly">
        <asp:ListItem Value="1">January</asp:ListItem>
        <asp:ListItem Value="2">February</asp:ListItem>
        <asp:ListItem Value="3">March</asp:ListItem>
        <asp:ListItem Value="4">April</asp:ListItem>
        <asp:ListItem Value="5">May</asp:ListItem>
        <asp:ListItem Value="6">June</asp:ListItem>
        <asp:ListItem Value="7">July</asp:ListItem>
        <asp:ListItem Value="8">August</asp:ListItem>
        <asp:ListItem Value="9">September</asp:ListItem>
        <asp:ListItem Value="10">October</asp:ListItem>
        <asp:ListItem Value="11">November</asp:ListItem>
        <asp:ListItem Value="12">December</asp:ListItem>
      </asp:DropDownList>
            </div>
        <br />
        <div class="row">
       <label for="week">Select Week (select one):</label>
            </div>
        <div class="row">
      <asp:DropDownList runat="server" class="form-control" ID="weekly">
        <asp:ListItem Value="1">Week-1</asp:ListItem>
        <asp:ListItem Value="2">Week-2</asp:ListItem>
        <asp:ListItem Value="3">Week-3</asp:ListItem>
        <asp:ListItem Value="4">Week-4</asp:ListItem>
      </asp:DropDownList>
        <br />
            </div>
        <div class="row">
       <label for="week">Weekly Topic:</label>
            </div>
        <div class="row">
        <asp:TextBox id="Topic" TextMode="SingleLine" class="form-control" runat="server" OnTextChanged="Topic_TextChanged" AutoPostBack="true" />
         </div>
        <br />
        <div class="row">
       <label>Upload Presentation Here:</label>
         </div>
        <div class="row">
            <div class="col-md-4">
            <asp:FileUpload accept="application/vnd.ms-powerpoint" id="uploadppt" runat="server" class="form-control" /> 
             </div>
            <asp:Button ID="Button1" runat="server"  onclick="Upload_data" Text="Upload File" CssClass="btn btn-default" /> 
        </div>

        <div class="row">
            <asp:Label ID="Label1" runat="server"></asp:Label> <br/>
        </div>
        <div class="row col-md-offset-2" >
            <embed id="embedpdf" runat="server" width="500px" height="300px"  />
        </div>
        <br />
        <div class="row">
       <label>Upload Video Here:</label>
         </div>
        <div class="row">

                <div class="col-md-4">
                   
                    <asp:FileUpload accept="video/*" runat="server" ID="f1" CssClass="form-control" />
                  </div>
                
                    <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" CssClass="btn btn-default" /><br />

                    <br />
               
            </div>
        <br />
        <br />
        <div class="row">
            <label>Add Questionnaire:</label>
             <!-- Trigger the modal with a button -->
                    <button type="button" runat="server" id="addBtn" disabled="disabled"  class="btn addnew pull-right" style="background-color:#093965;color:white;"  data-toggle="modal" data-target="#myModal">Add Questions</button>

                    <!-- Modal -->
                    <div class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Add New Questions</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox runat="server" ID="modalQuestion" CssClass="form-control dumm"></asp:TextBox><br />
                                     <asp:RadioButtonList ID="ModalRadioButtons" runat="server" RepeatDirection="Horizontal" CssClass="rbl mdrdbt">
                    <asp:ListItem Text="True" Value="T" />
                    <asp:ListItem Text="False" Value="F" />
                    </asp:RadioButtonList>
                                    
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" ID="addCat" CssClass="btn" BackColor="#093965" ForeColor="White" OnClick="Store_Modal_data" Text="Add" />
                                    <button type="button" class="btn btn-danger mdlCls">Close</button>
                                </div>
                            </div>

                        </div>
                    </div>
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
        <div class="row">
                <div class="col-md-4">
                    <label>Question1:</label>
                    <asp:TextBox id="Question1" TextMode="multiline" Columns="40" Rows="3" runat="server" />
                    <label>Answer-1:</label>
                    <asp:RadioButtonList ID="Answer1" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="T" />
                    <asp:ListItem Text="False" Value="F" />
                    </asp:RadioButtonList>
                 </div>
         
                <div class="col-md-4">
                    <label>Question2:</label>
                    <asp:TextBox id="Question2" TextMode="multiline" Columns="40" Rows="3" runat="server" />
                    <label>Answer-2:</label>
                    <asp:RadioButtonList ID="Answer2" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="T" />
                    <asp:ListItem Text="False" Value="F" />
                    </asp:RadioButtonList>
                 </div>

                 <div class="col-md-4">
                    <label>Question3:</label>
                    <asp:TextBox id="Question3" TextMode="multiline" Columns="40" Rows="3" runat="server" />
                    <label>Answer-3:</label>
                    <asp:RadioButtonList ID="Answer3" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="T" />
                    <asp:ListItem Text="False" Value="F" />
                    </asp:RadioButtonList>
                 </div>
           </div>
        <br />
        <br />
        <div class="row">
                <div class="col-md-4 col-md-offset-2">
                    <label>Question4:</label>
                    <asp:TextBox id="Question4" TextMode="multiline" Columns="40" Rows="3" runat="server" />
                    <label>Answer-4:</label>
                    <asp:RadioButtonList ID="Answer4" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="T" />
                    <asp:ListItem Text="False" Value="F" />
                    </asp:RadioButtonList>
                 </div>
         
                <div class="col-md-4">
                    <label>Question5:</label>
                    <asp:TextBox id="Question5" TextMode="multiline" Columns="40" Rows="3" runat="server" />
                    <label>Answer-5:</label>
                    <asp:RadioButtonList ID="Answer5" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="True" Value="T" />
                    <asp:ListItem Text="False" Value="F" />
                    </asp:RadioButtonList>
                 </div>
           </div>
        <br />
        <br />
        <br />
           <div class="row">
               <div class="col-md-offset-5">
                    <asp:Button ID="save" runat="server" onclick="Store_data" Text="SAVE DATA" CssClass="btn btn-default btn-lg" /> 
               </div>

           </div>
        
         </div>
   
  </form>
</asp:Content>

