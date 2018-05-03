<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Exam_End" Codebehind="Exam_End.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        td {
            width: 50%;
        }

        table {
            border-collapse: separate;
            border-spacing: 1.5em;
            width:100%;
        }
      
    .radioButtonList { list-style:none; margin: 0; padding: 0;}
    .radioButtonList.horizontal li { display: inline;}

    .radioButtonList label{
        display:inline;
    }
      #save{
            margin-bottom:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
            <div class="row">
                <div  class="col-md-10 col-md-offset-2 page-header">
                    <h1 id="head" runat="server"></h1>
                    <p id="tag" runat="server">Fill the Questionnaire to view the Result</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <h1>Questionnaire
                    </h1>
                    <hr />

                    <table id="table2" runat="server">
                        <thead>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="display:inline-block;width:500px;overflow-x:scroll;"><%--1. Anaerobic means “without oxygen”--%>
                                </td>
                                <td>
                                     <asp:RadioButtonList ID="RadioButtonList" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>True</asp:ListItem>
                                     <asp:ListItem>False</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                </td>
                            

                            </tr>
                            <tr >
                                <td style="display:inline-block;width:500px;overflow-x:scroll;"><%--2. Long endurance events such a half marathon is a form of anaerobic training/exercise.--%>
                                </td>
                                <td>
                                   <asp:RadioButtonList ID="RadioButtonList1" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>True</asp:ListItem>
                                     <asp:ListItem>False</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="display:inline-block;width:500px;overflow-x:scroll;"><%--3. Resistance training may increase bone density and reduce the risk of osteopenia or osteoporosis.--%> 
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList2" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>True</asp:ListItem>
                                     <asp:ListItem>False</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="display:inline-block;width:500px;overflow-x:scroll;"><%--4. When doing resistance exercise training, it is recommended that an individual does not rest to maximize performance outcomes.--%>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList3" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>True</asp:ListItem>
                                     <asp:ListItem>False</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="display:inline-block;width:500px;overflow-x:scroll;" ><%--5. Only a well-seasoned “gym-goer” should participate in resistance training.--%>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList4" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>True</asp:ListItem>
                                     <asp:ListItem>False</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                  <center><asp:Button runat="server" ID ="save" Text="Save" CssClass="btn " BackColor="#093965" ForeColor="White" OnClick="save_Click" /></center>

                </div>
            </div>
       
</asp:Content>

