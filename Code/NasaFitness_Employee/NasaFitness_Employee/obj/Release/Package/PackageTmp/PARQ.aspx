<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="PARQ" Codebehind="PARQ.aspx.cs"%>
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
    <p style="color: #093965; font-size:32px">Physical Fitness Readiness Questionnaire
				<asp:Button ID="Button3" runat="server" Text="Mail to Doctor" BackColor="#093965" ForeColor="white" OnClick="Mail_Click" Style="float: right;" CausesValidation="false"   CssClass="btn btn-lg"/> 
        </p>
        <hr />
            <div class="row">
                <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Health Questionnaire" PostBackUrl="HealthCoaching.aspx"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Fitness Questionnaire" PostBackUrl="FitnessCoaching.aspx"></asp:LinkButton></li>
                        <li role="presentation" class="active">
                            <asp:LinkButton runat="server" Text="Physical Fitness Readiness Questionnaire" ></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
        <br/><br/>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
					<p class="text-danger">This form is completed to determine if you are at risk for beginning an exercise program. If any answers are “Yes” we need to contact your physician to receive a release to begin an exercise program or any restrictions related to beginning an exercise program. 
</p>
                <table class="hello">
                                  <tr>
                                        <td>
                                            1. Has Your Doctor ever said you have heart trouble?
                                        </td>
                                        <td>
                                           <asp:RadioButtonList ID="RadioButtonList1" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td>
                                         2. Have You ever had chest pain or heavy pressure in your chest as the result of excercise, walking or other physical activity such as climbing a flight of stairs? (This does not include the normal out of breath feeling that results from vigirous excercise.)
                                      </td>
                                      <td>
                                         <asp:RadioButtonList ID="RadioButtonList2" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                      </td>
                                  </tr>
                                  <tr>
                                        <td>
                                          3. Do you often feel faint or experience severe dizziness?
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonList3" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                        </td>
                                  </tr>
                                  <tr>
                                        <td>
                                           4. Has a doctor ever told you that you have high blood pressure or diabetes?
                                        </td>
                                        <td>
                                           <asp:RadioButtonList ID="RadioButtonList4" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                  <tr>
                                        <td>
                                           5. Have you ever had a real or suspected heart attack or stroke
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonList5" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                         6. Do you have any physical condition, impairment or disbility, including any joint or muscle problem, that should be considered before you begin an exercise program?
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonList6" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                              <asp:ListItem>Yes</asp:ListItem>
                                               <asp:ListItem>No</asp:ListItem>
   
                                            </asp:RadioButtonList>
                                        </td>
                                        
                                    </tr>
                                  <tr>
                                      <td>
                                        7. Have you ever taken medication to reduce your blood pressure or your cholestral levels?
                                      </td>
                                      <td>
                                           <asp:RadioButtonList ID="RadioButtonList7" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                       8. Are you excissively overweight?
                                      </td>
                                      <td>
                                           <asp:RadioButtonList ID="RadioButtonList8" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                        9. Is there any good physical reason not mentioned here why you should not follow an activity program even if you wanted to?
                                      </td>
                                      <td>
                                          <asp:RadioButtonList ID="RadioButtonList9" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                       10. Are you over age 35 and not accustomed to vigorous excercise?
                                      </td>
                                      <td>
                                           <asp:RadioButtonList ID="RadioButtonList10" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                         11. Are you Pregnant?
                                      </td>
                                      <td>
                                     <asp:RadioButtonList ID="RadioButtonList11" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>Yes</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
   
                                    </asp:RadioButtonList>
                                      </td>
                                  </tr>
                                 </table>
                <p style="color: red; font-size: medium">
                    NOTE!!!!!
                </p>
                <p>
                    If you answered YES to one or more questions, and if you have not recently done so, consult with your doctor by phone or in person BEFORE starting an excercise program. Ask your doctor if you may participate in:
                </p>
                <p>
                    1. Unrestricted physical activity on a gradually increasing basis or<br />
                    2. restricted activity to meet your specific needs.
                </p>
                <p>
                    If you answered NO to ALL questions, you have reasonable assurance that you may begin a graduated exercise program or have an excercise test.


                </p>
                <br />
                <br />
                <center><asp:Button ID="Button1" runat="server" Text="Save" BackColor="#093965" ForeColor="white" OnClick="PARQ_save_Click"  CausesValidation="false"  OnClientClick="return dosome();" CssClass="btn"/></center>
                </div>
                    </div>
            </asp:Panel>
        </form>

     <script>
    function dosome (){

        if ($("input:checked").length == 11){
         if (confirm('The details you entered in this page is about to be recorded before you move on to the next page. Are you Sure?')) {
		var a = 0;

		$('input:checked').each(function(){
        if ($(this).val() == "Yes") {
        a = a+1;
		}
		});
		if(a != 0 ) {
        alert("On Save, Send this questionnaire to your physician by clicking on Mail to Doctor button.");
		} 
        return true;
        } else {
        return false;
		} 
		} else {
        alert("Please answer all the questions.");
		return false;
		}
        }

    </script>   

	

</asp:Content>

