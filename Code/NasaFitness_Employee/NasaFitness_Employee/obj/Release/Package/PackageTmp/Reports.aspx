<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" Inherits="Reports" EnableEventValidation = "false" Codebehind="Reports.aspx.cs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
   <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
            label.checkbox:before {
    content: "☐ ";
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server" id="sub">
		<asp:Panel runat="server" ID="Panel2" Visible="true">
    <p style="color: #093965; font-size:32px">Health Questionnaire Report
        </p>
        <hr />
   <div class="row">
                <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" class="active" >
                            <asp:LinkButton runat="server" Text="Health Questionnaire Report" ></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Fitness Questionnaire Report" PostBackUrl="Reports_Fitness.aspx"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Physical Fitness Readiness Questionnaire Report" PostBackUrl="Reports_P"></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
        <br/><br/>
            <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                    
                         <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                         
                        
                           <thead>
                                <tr>
                                    <th>Problem</th>
                                    <th>Past</th>
                                    <th>Current</th>
                                    <th>Desire Treatment</th>

                                </tr>
                            </thead>
                            <tbody>
                                 <%=BindData()%>
                            
                           </tbody>

                        </table>
					</div>
				</div>
                        </asp:Panel>
                     </form>
	
   
</asp:Content>