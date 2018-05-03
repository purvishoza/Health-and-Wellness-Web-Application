<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" Inherits="Reports_P" EnableEventValidation = "false" Codebehind="Reports_P.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <style>
        #modal_table {
            width: 100%;
            border-collapse: separate;
            border-spacing: 1.5em;
        }
        thead tr th, th {
            background-color: #093965;
            text-align: center;
            color: white;
        }

        td {
            text-align: center;
        }

        .radioButtonList {
            list-style: none;
            margin: 0;
            padding: 0;
            margin-right: 15px;
            margin-left: 15px;
        }

            .radioButtonList.horizontal li {
                display: inline;
                margin-right: 15px;
                margin-left: 15px;
            }

            .radioButtonList label {
                display: inline;
                margin-right: 15px;
                margin-left: 15px;
            }


    </style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" id="Content2">
<form runat="server">
<asp:Panel runat="server" id="Panel2" Visible="true">
<p style="color: #093965; font-size: 32px;">Physical Fitness Readiness Questionnaire Report</p>
<hr/>
<div class="row">
  <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Health Questionnaire Report" PostBackUrl="Reports.aspx"></asp:LinkButton></li>
                        <li role="presentation">
                            <asp:LinkButton runat="server" Text="Fitness Questionnaire Report" PostBackUrl="Reports_Fitness.aspx"></asp:LinkButton></li>
                        <li role="presentation" class="active">
                            <asp:LinkButton runat="server" Text="Physical Fitness Readiness Questionnaire Report" ></asp:LinkButton></li>
                    </ul>
                </div>
</div>
			<br/><br/>
			<div class="row">
                    <div class="col-md-8 col-md-offset-2">
                    <center>
                   <div id="ppp" runat="server">
		             <asp:Label id="empName" runat="server" Style="font-weight: bold;font-size: large; float: left;"></asp:Label><br/><br/>
                            <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                        
                          <thead>
                                <tr>
                                    <th>Questions</th>
                                    <th>Selected Answers</th>
                                    </tr>
                            </thead>
                            <tbody>
                                 <%=BindData3()%>
                            
                           </tbody>

                        </table>
                            <br/><br/>
							<table style="width:100%; border-spacing: 0px;">
							<tr><td style="text-align: left;"> _____ PCP Release Required</td></tr>
                            <tr><td style="text-align: left;">Release Limitation Comments:________________________________________________________ </td></tr>
                            <tr><td style="text-align: left;"> _____ This Patient is released to perform aerobic excercise in thier target heart rate range</td></tr>
                            <tr><td style="text-align: left;"> _____ This patient is NOT released to perform aerobic exercise</td></tr>
                            <tr><td style="text-align: left;"> _____ This patient is released to perform low intensity aerobic exercise only</td></tr>
                            <tr><td style="text-align: left;"> _____ This patient needs additional testing to determine their ability to perform within their target heart range</td></tr>
							</table>
                          </div>
                          <br /><br />
                               <button runat="server" style="background-color:#093965;color:white" ID="PARQ_save" type="button" class="btn btn-lg" data-toggle="modal" data-target="#myModal">Send Mail to Doctor</button>
                        </center>
                    </div>
                </div>
			</asp:Panel>

	 <div class="modal fade" id="myModal" role="dialog" >
                <div class="modal-dialog modal-lg">
                <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Send PARQ to Your Doctor</h4>
                        </div>
                        <div class="modal-body">
                        <div class="row">
                        <div class="col-md-10">

                            <table style="width:100%" id="modal_table">
                                <tr>
                                    <td> <asp:Label runat="server" Text="Email Id:"></asp:Label></td>
                                    <td><asp:TextBox runat="server" placeholder="Email Id of your Doctor" ID="doctor" CssClass="form-control input-lg"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" style="vertical-align:middle;" Text ="Your Message:"></asp:Label></td>
                                    <td> <asp:TextBox runat="server" placeholder="Your message to your Doctor" style="vertical-align:middle;" ID="comments" TextMode="MultiLine" Columns="15" Rows="4" CssClass="form-control input-lg"></asp:TextBox></td>
                                </tr>
                            </table> 
                            </div>
                          </div>     
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat ="server" ID="hello" OnClick="hello_Click" Text="Send Mail" CssClass="btn"/>
                            <button type="button" class="btn" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
		</form>

</asp:Content>