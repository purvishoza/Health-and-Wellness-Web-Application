<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" Inherits="Fitness" Codebehind="Fitness.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <title>Pick a Date</title>
    

       <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/js/bootstrap.min.js"></script>--%>
    <style>
        .addnew {
            background-color: #093965;
            color: white;
        }

        #meal, #contact, #meal1 {
            background-color: #093965;
            color: white;
        }

        .table th, .table td {
            border-top: none !important;
        }

        .redtext {
            text-decoration: underline;
            color: red;
        }

        .greentext {
            text-decoration: underline;
            color: green;
        }

        .sub {
            font: bold;
        }
        #mealplan,#exam1{
            background-color:#093965;
            color:white;
        }
         </style>
    <script>
      
            $(function () {
                $(".date").datepicker({
                    changeMonth: true,
                    changeYear: true
                });
        });

       
        </script>
   <%-- <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">


        <p style="color: #093965; font-size:32px">Fitness Inventory Details of Employee:
        <asp:Label runat="server" Style="font-size:32px;" ID="empnameFitnessPage"/></p>
        <hr />
       <div class="row">
                <div class="col-md-10 col-xs-10">
                     <ul class="nav nav-tabs">
                        <li role="presentation"  class="active">
                            <asp:LinkButton runat="server" Text="Fitness Issues and Prescription" ></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Prescription History for Fitness Issues" PostBackUrl="FitnessLogging.aspx"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Employee's Fitness details" PostBackUrl="FitnessTesting_Fitness.aspx"></asp:LinkButton></li>
                        <li role="presentation">
                            <asp:LinkButton runat="server" Text="Employee's Medical Records" PostBackUrl="Fitness_Records.aspx" ></asp:LinkButton></li>
                    </ul>
                </div>
               
            </div>
        
           
         <div class="row">
                <div class="col-md-10">
                    <h4 class="text-danger">Current Problem:&nbsp<span class="text-success" runat="server" id="current" style="font-size: 16px; font-family: Candara;"></span></h4>
                    <h4 class="text-danger">Desired Treatment:&nbsp<span class="text-primary" runat="server" id="desired" style="font-size: 16px; font-family: Candara;"></span></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10 col-md-offset-2">
                   <h4>Select a Problem for Treatment</h4>
                   </div>
              <br /><br />
                <div class="col-md-5 col-md-offset-2">
                    <asp:DropDownList runat="server" ID="desiredTreatmentsList" AutoPostBack="true" OnSelectedIndexChanged="desiredTreatmentsList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                   
                </div>
                <div class="col-md-2">
                     <asp:Button runat="server" ID="solved" Text="Solved" CssClass="btn btn-danger" OnClick="solved_Click"/>
                    
                    </div>
                <div class="col-md-2">
                     <asp:Button runat="server" ID="expandallfitbtn" Text="Expand All" CssClass="btn btn-info" OnClick="expandallfitbtn_Click"/>
                    <asp:Button runat="server" ID="expandoutfitbtn" Text ="Collapse" Visible="false" CssClass="btn btn-info" OnClick="expandoutfitbtn_Click" />
                    </div>
            </div>
        <br />
            <div class="row">
                <div class="col-md-10 col-md-offset-1">

                    <div class="panel-group" id="accordion">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#history">History of the Problem</a>

                                </h4>

                                <div id="history" class='<%= state1 %>'>
                                    <div class="panel-body">
                                        <div class="row">
                                            <span runat ="server" id="required" style="color:red">*</span>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="reviewdate1" placeholder="Problem Review Date"  runat="server" CssClass="form-control date" AutoPostBack="true" OnTextChanged="reviewdate1_TextChanged"/>
                                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidationdate" ControlToValidate="reviewdate1" Display="Dynamic" ErrorMessage="Select Review Date" ValidationGroup='valGroup1' style="color:red"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                        <br />
                                        <asp:TextBox TextMode="multiline" ID="historytext1" class="form-control" Rows="4" runat="server" placeholder="History of the problem" /><br />

                                        <asp:ScriptManager runat="server" ID="sm">
                                        </asp:ScriptManager>
                                        <div class="col-md-4">
                                        <asp:Button runat="server" ID="nxtbtn" Text="Next" CssClass="btn btn-primary" AutoPostBack="false" ValidationGroup='valGroup1' OnClick="nxtbtn_Click"/>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#ObjectiveFinidngs">Objective Findings</a>

                            </h4>
                        </div>
                        <div id="ObjectiveFinidngs" class='<%= state3 %>'>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-8">
                                        <a runat="server" href="#" ID="objExam" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Add Objective Findings exam Info">
                                            <button type="button" class="btn" id="exam1">Add Objective Findings Exam Info</button></a>   
                                    </div>
                                </div>
                                <br />
                                <asp:Button runat="server" ID="objectivenxtfitbtn" Text="Next" CssClass="btn btn-primary" ValidationGroup='valGroup1' OnClick="objectivenxtfitbtn_Click" />
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">

                                <a data-toggle="collapse" data-parent="#accordion" href="#Assessments">Assessments of the plan</a>
                            </h4>
                        </div>
                        <div id="Assessments" class='<%= state %>'>
                            <div class="panel-body">
                                <asp:DropDownList runat="server" ID="healthnames" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="healthnames_SelectedIndexChanged" Width="15%"></asp:DropDownList><br />
                                <asp:DropDownList runat="server" ID="healthcodes" CssClass="form-control" Visible="false" Width="40%"></asp:DropDownList>
                                <br />
                                <asp:Button runat="server" ID="assmntnxtbtn" Text="Next" CssClass="btn btn-primary" Visible="false" ValidationGroup='valGroup1' OnClick="assmntnxtbtn_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">

                                <a data-toggle="collapse" data-parent="#accordion" href="#Plan">Plan for the Problem</a>
                            </h4>
                        </div>
                        <div id="Plan" class='<%= state2 %>'>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:TextBox ID="monthlystartdate" placeholder="Start Date"  runat="server" CssClass="form-control date"/>
                                    </div>
                                     <div class="col-md-4">
                                        <asp:TextBox ID="monthlyenddate" placeholder="End Date"  runat="server" CssClass="form-control date"/>
                                    </div>
                                </div>
                                <br />
                                <h5>Goal 1</h5>
                                <asp:TextBox runat="server" ID="goal12" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                                <h5>Payoffs</h5>
                                <asp:TextBox runat="server" ID="pay" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                                <h5>Goal Supportive</h5>

                                <div class="row">
                                    <div class="col-md-2">
                                        <%--Code for PARQ Model--%>
                                        <a data-toggle="modal" href="#" runat="server" data-target="#theModal">
                                            <button runat="server" class="btn" style="background-color: #093965; color: white;">View PARQ</button></a>

                                        <div id="theModal" class="modal fade text-center">
                                            <div class="modal-dialog modal-lg">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                            <h4 class="modal-title">View PARQ</h4>
                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="embed-responsive embed-responsive-16by9">
                                                           <iframe src="FitnessPARQ.aspx" ></iframe>
                                                            </div>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList runat="server" ID="excercisesTypes" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="excercisesTypes_SelectedIndexChanged">
                                           <asp:ListItem Value="0" Text="Select Excerciese Type" />
                                        </asp:DropDownList><br />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList runat="server" ID="excercisenames" CssClass="form-control" Visible="false">
                                            <asp:ListItem>Select Video---</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button runat="server" ID="AddMoreVideos" Text="AddVideo" CssClass="btn" BackColor="#093965" ForeColor="White" Visible="false" OnClick="AddMoreVideos_Click1"/>

                                    </div>
                                    <div class="col-md-4 col-md-offset-1">
                                        <asp:TextBox runat="server" ID="selectedVideos" TextMode="MultiLine" CssClass="form-control" Rows="3" Visible="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">


                                    <div class="col-md-2">
                                       <%--Code for Meal Plan--%>
                                            <button data-toggle="modal" type="button" data-target="#theModal1" class="btn" id="mealplan" style="background-color: #093965; color: white;">AddMealPlan</button></a>

                                        <div id="theModal1" class="modal fade">
                                            <div class="modal-dialog modal-lg">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                            <h4 class="modal-title">Add Meal Plan</h4>
                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="embed-responsive embed-responsive-16by9">
                                                           <iframe src="MealPlan.aspx" class="embed-responsive-item" style="border:0px;width: 100%"></iframe>
                                                            </div>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                      
                                    </div>


                                    <div class="col-md-2">
                                        <asp:DropDownList runat="server" ID="classesddl"  CssClass="form-control">
                                          
                                        </asp:DropDownList></div>
                                        <div class="col-md-2">
                                         <asp:Button runat="server" class="btn" style="background-color: #093965; color: white;" Text="Add classes" OnClick="addclasses_Click" ID="addclasses" />
                                    </div>
                                        <div class="col-md-5">
                                             <asp:TextBox runat="server" ID="classeslisttextbox" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                                        </div>
                                       
                                </div>
                                <h5>Miscellaneous</h5>
                                <asp:TextBox runat="server" ID="miscellaneous" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                                <h5>Mini-Goals and Rewards</h5>
                                <div class="row">
                                    <div class="col-md-4">
                                       <asp:TextBox ID="minigoaldate" placeholder="minigoal date"  runat="server" CssClass="form-control date"/>
                                    </div>
                                </div>
                                <br />
                                <asp:TextBox runat="server" ID="minigoals" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                                <h5>Support Group/ Fitness Buddies</h5>
                                <asp:TextBox runat="server" ID="supportgroup" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                                <br />
                                <asp:Button runat="server" ID="SaveFormIntoDatabase" BackColor="#093965" ForeColor="White" Text="Save Form" CssClass="btn addnew" OnClick="SaveFormIntoDatabase_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        
    
        
        
    </form>

</asp:Content>
