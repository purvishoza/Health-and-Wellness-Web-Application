<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="HealthCoaching" Codebehind="HealthCoaching.aspx.cs" %>

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
    <form runat="server" id="sub">
		<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
		<asp:Panel runat="server" ID="Panel2" Visible="true">
    <p style="color: #093965; font-size:32px">Health Questionnaire
        </p>
        <hr />
			<div class="row">
                <div class="col-md-10 col-xs-10">
                   <ul class="nav nav-tabs">
                        <li role="presentation" class="active" >
                            <asp:LinkButton runat="server" Text="Health Questionnaire" ></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Fitness Questionnaire" PostBackUrl="FitnessCoaching.aspx"></asp:LinkButton></li>
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
                        <th style="text-align: center"></th>
                        <th style="text-align: center">Past</th>
                        <th style="text-align: center">Current</th>
                        <th style="text-align: center">Desire Treatment</th>
                    </tr>
                    <tr>
                        <td>Headache
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="headache_past" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="headache_current" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="headache_treatment" />
                        </td>
                    </tr>
                    <tr>
                        <td>Neck Pain
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="Neckpain_past" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="Neckpain_current" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="Neckpain_treatment" />
                        </td>
                    </tr>
                    <tr>
                        <td>Arms/Hands Pain/Numbness/Tingling
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="arms_past" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="arms_current" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="arms_treatment" />
                        </td>
                    </tr>
                    <tr>
                        <td>Shoulder Blade Pain
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="shoulder_past" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="shoulder_current" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="shoulder_treatment" />
                        </td>
                    </tr>
                    <tr>
                        <td>Low Back Pain
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="lowback_past" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="lowback_current" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="lowback_treatment" />
                        </td>
                    </tr>
                    <tr>
                        <td>Legs/Feet Pain,Numbness or Tingling
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="leg_past" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="leg_current" />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="leg_treatment" />
                        </td>
                    </tr>
                </table>
                <asp:Label Style="vertical-align: middle" runat="server">Any Other Complaints:</asp:Label>
                <asp:TextBox Style="vertical-align: middle; width: 80%" runat="server" ID="health_comments" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <br />
                <br />
                <center>   <asp:Button ID="Button1" runat="server" Text="Next" BackColor="#093965" ForeColor="white" OnClick="health_save_Click"  CausesValidation="false"  OnClientClick="return dosome();" CssClass="btn"/>
</center>
                </div>
					</div>
            </asp:Panel>
		</form>

     <script>
	function dosome (){
        if ($(":checkbox:checked").length > 0){
        if (confirm('The details you entered in this page is about to be recorded before you move on to the next page. Are you Sure?')) {
       $("#sub").submit();
		return true;
        } else {
        if ($(":checkbox:checked").length > 0){alert('Please click next to save the details in this page before moving on to the next page.');}
        return false;
		}
        } else {
        alert("If you do not have any health issues, You can move on to the next page by clicking on the tab above. Else select the desired behaviour treatment plan and click on next button to move on to the next page.");
        return false;
		}
		}
		
	</script>       

</asp:Content>


