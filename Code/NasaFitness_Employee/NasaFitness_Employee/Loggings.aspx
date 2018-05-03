<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Loggings" Codebehind="Loggings.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<style>
		.cur {
        background-color: #DCDCDC;
		color: black;
		pointer-events:none;
		}
	</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server">
   <p style="color: #093965; font-size:32px">Fitness Testing
        </p>
        <hr />
              <div class="col-md-5 col-md-offset-1">
                <asp:ValidationSummary runat="server" ID="Validationsum1" ShowMessageBox="true" ShowSummary="false" DisplayMode="BulletList" />
                              <table>
                                  <tr>
                                        <td>
                                            Height (inches)
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" CssClass="a1" ID="Height_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidationdate" ControlToValidate="Height_text" Display="None" ErrorMessage="Please Enter Height"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td>
                                          Weight (lbs)
                                      </td>
                                      <td>
                                          <asp:TextBox runat="server" CssClass="a2" ID="Weight_text"></asp:TextBox>
                                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="Weight_text" Display="None" ErrorMessage="Please Enter Weight"></asp:RequiredFieldValidator>
                                      </td>
                                  </tr>
                                  <tr>
                                        <td>
                                           BMI
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="BMI_Text" CssClass="cur" ></asp:TextBox>

                                        </td>
                                  </tr>
                                  <tr>
                                        <td>
                                            Blood Pressure
                                        </td>
                                        <td>
                                            <asp:TextBox style="width:23%;" runat="server" ID="BP_1"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="BP_1" Display="None" ErrorMessage="Please Enter Systolic Value"></asp:RequiredFieldValidator>

                                            /
                                            <asp:TextBox style="width:24%" runat="server" ID="BP_2"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="BP_2" Display="None" ErrorMessage="Please Enter Dystolic Value"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                  <tr>
                                        <td>
                                            Resting Heart Rate
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Heartrate_text"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="Heartrate_text" Display="None" ErrorMessage="Please Enter HeartRate"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Blood Oxygen Level
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="oxygen_text"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="oxygen_text" Display="None" ErrorMessage="Please Enter Blood Oxygen Level"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                 
                              </table>
                              <br />
                                <br />
                               <h3> Skin Fold Measurements</h3>
                                <table>
                                    <tr>
                                        <td>
                                              #1
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="skin1_text"></asp:TextBox>

                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            #2
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="skin2_text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            #3
                                        </td>
                                        
                                    
                                        <td>
                                            <asp:TextBox runat="server" ID="skin3_text"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                               <h3 style="margin-top:0px"> Core Strength</h3>
                                <table>
                                    <tr>
                                        <td>
                                            Hip Flexion
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Hipflex_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="Hipflex_text" Display="None" ErrorMessage="Please Enter Hip Flexion Value"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Hip Extension
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Hipext_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="Hipext_text" Display="None" ErrorMessage="Please Enter Hip Extension Value"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           L side Bridge
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Lside_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="Lside_text" Display="None" ErrorMessage="Please Enter Left Side Bridge Value"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           R side Bridge
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Rside_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="Rside_text" Display="None" ErrorMessage="Please Enter Right Side Bridge Value"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            1' Curl Ups
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="curlup_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="curlup_text" Display="None" ErrorMessage="Please Enter Curl Ups Value"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           1' Push Ups
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Pushup_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="Pushup_text" Display="None" ErrorMessage="Please Enter Push Ups Value"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Grip Left (lbs)
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Gripleft_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="Gripleft_text" Display="None" ErrorMessage="Please Enter Grip Left Value "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Grip Right (lbs)
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Gripright_text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="Gripright_text" Display="None" ErrorMessage="Please Enter Grip Right Value "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Arm Raise
                                        </td>
                                        <td>
                                           <asp:DropDownList runat="server" ID="armraise" style="width:100%">
                                               <asp:ListItem>
                                                   Pass
                                               </asp:ListItem>
                                               <asp:ListItem>
                                                   Fail
                                               </asp:ListItem>
                                           </asp:DropDownList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                           Knee Bend
                                        </td>
                                        <td>
                                           <asp:DropDownList runat="server" ID="KneeBend" style="width:100%">
                                               <asp:ListItem>
                                                   Pass
                                               </asp:ListItem>
                                               <asp:ListItem>
                                                   Fail
                                               </asp:ListItem>
                                           </asp:DropDownList>
                                        </td>
                                    </tr>

                                </table>
                                <br />
                                <br />
                               <h3> Sit and Reach</h3>
                                <table>
                                    <tr>
                                        <td>
                                              #1
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="sit1_text"></asp:TextBox>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            #2
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="sit2_text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            #3
                                        </td>
                                        
                                    
                                        <td>
                                            <asp:TextBox runat="server" ID="sit3_text"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table> <br /><br />
                            </div>
             
                     <asp:Label style="vertical-align:middle;margin-left:7%" runat="server" Text="Notes"> </asp:Label>
                     <asp:TextBox style="vertical-align:middle;width:80%" runat="server" ID="note_text" TextMode="MultiLine" Rows="5"></asp:TextBox>
                     <br /><br /> <center><asp:Button runat="server" BackColor="#093965" ForeColor="White" Width="50%" ID="Fitnesstesting_save" Text="Save" CausesValidation="true" CssClass="btn" OnClick="Fitnesstesting_save_Click"/></center>
   <script>
	$(document).ready(function(){
	var height = 0;
	var weight = 0;
    $('.a1').change(function(){
	height = $(this).val();
    if(height != 0 && weight != 0) {
    var ans = (weight / (height * height)) * 703;
	$('.cur').val(ans.toFixed(1));		
    } else {
    $('.cur').val("Calculating");
    }
	});
    $('.a2').change(function(){
	weight = $(this).val();
	if(height != 0 && weight != 0) {
	var ans = (weight / (height * height)) * 703;
	$('.cur').val(ans.toFixed(1));		
	} else {
	$('.cur').val("Calculating");
	}	
    });

	});		
	</script>  
		</form>
</asp:Content>

