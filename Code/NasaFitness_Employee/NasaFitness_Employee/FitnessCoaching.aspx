<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="FitnessCoaching" Codebehind="FitnessCoaching.aspx.cs"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script>
         function Health() {
             var x = document.getElementById('Health_div');
             if (x.style.display === 'none') {
                 x.style.display = 'block';
             } else {
                 x.style.display = 'none';
             }
         }
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        th {
            background-color: #093965;
            text-align: center;
            color: white;
        }

        td {
            text-align: center;
        }

        .thumbnail, .caption {
            text-align: center;
        }

        .hello {
            width: 100%;
            border-collapse: separate;
            border-spacing: 1.5em;
        }

            .hello td {
                text-align: start;
                width: 50%;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
		      <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>

        <asp:Panel runat="server" ID="Panel2" Visible="true">
    <p style="color: #093965; font-size:32px">Fitness Coaching
        </p>
        <hr />
            <div class="row">
                <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Health Questionnaire" PostBackUrl="HealthCoaching.aspx"></asp:LinkButton></li>
                        <li role="presentation" class="active">
                            <asp:LinkButton runat="server" Text="Fitness Questionnaire" ></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Physical Fitness Readiness Questionnaire" PostBackUrl="PARQ.aspx"></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
        <br/><br/>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                <table class="table table-striped table-bordered table-condensed" style="text-align: center">
                    <tr>
                        <th>Lifestyle Habit
                        </th>
                        <th>Problem Status</th>
                        <th>Desire Behaviour Change Program</th>
                    </tr>
                    <tr>
                        <td>Nutrition/Eating
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="nutrition_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="nutrition_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Excercise/Fitness
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="fitness_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="fitness_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Weight Management
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="weight_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="weight_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Muscle Flexibility/Strength
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="muscle_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="muscle_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Stress Management
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="stress_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="stress_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Diabetes
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="diabetes_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="diabetes_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Sleeping Disturbance
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="sleeping_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="sleeping_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Addictive Behaviour<br />
                            <asp:TextBox runat="server" ID="addictive_text"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="addictive_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="Addictive_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Cardiovascular(heart)
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="cardio_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="Cardiovascular_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Cancer
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="cancer_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="Cancer_dp" />
                        </td>
                    </tr>
                    <tr>
                        <td>Lab Assessment Values 
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="lab_status">
                                <asp:ListItem Value="No Problem">
                                               No Problem
                                </asp:ListItem>
                                <asp:ListItem Value="Have Problem">
                                               Have Problem
                                </asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="Labassessment_dp" />
                        </td>
                    </tr>


                </table>
                <asp:Label Style="vertical-align: middle" runat="server">Any Other Complaints:</asp:Label>
                <asp:TextBox Style="vertical-align: middle; width: 80%" runat="server" ID="notes" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <br />
                <br />
                <center> <asp:Button ID="Button1" runat="server" Text="Next" BackColor="#093965" ForeColor="white" OnClick="Fitnessinventory_save_Click"  CausesValidation="false"  OnClientClick="return dosome();" CssClass="btn"/></center>
                </div>
                    </div>
            </asp:Panel>
        </form>

     <script>
     function dosome (){

		var val = [];
        $("select").each(function()
        {
		if($(this).val() == "No Problem"){
        val.push($(this).val());
		} 
        });
        if (val.length == 11 && $(":checkbox:checked").length == 0) {
        alert("If you do not have any fitness issues, You can move on to the next page by clicking on the tab above. Else select the desired behaviour treatment plan and click on next button to move on to the next page.");
		return false;
		} else {
        if (confirm('The details you entered in this page is about to be recorded before you move on to the next page. Are you Sure?')) {
        return true;
        } else {
        alert('Please click next to save the details in this page before moving on to the next page.');
		return false;
        }
		}

        }
        
    </script>       

</asp:Content>

