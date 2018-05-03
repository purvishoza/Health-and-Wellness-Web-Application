<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Inherits="ObjectiveFindingsExam" Codebehind="ObjectiveFindingsExam.aspx.cs" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Objective Findings </title>
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous"/>

<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous">
</script>

    <script type ="text/javascript">

</script>
    <style>
        .table th, .table td { 
     border-top: none !important; 
 }
        .redtext{
            text-decoration:underline;
            color:red;
        }
        .greentext{
            text-decoration:underline;
            color:green;
        }
        .sub{
            font:bold;
        }
  
   </style>
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="row">

            <div class="col-md-10 col-md-offset-1">
         <div class="modal-header">
     
      <h2 style="color:#093965;">Objective Findings Exams</h2>
    
    </div>
        <div class="modal-body">
       
            
            <div class="row">
                <div class="col-md-6 col-md-offset-1">
                    <asp:DropDownList ID="paneldropdown" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="paneldropdown_SelectedIndexChanged">
                        <asp:ListItem Text="--select--" Value=""></asp:ListItem>
                        <asp:ListItem Value="1">Vital Signs</asp:ListItem>
                        <asp:ListItem Value="2">Sit Reach and Grip</asp:ListItem>
                        <asp:ListItem Value="3">Range of Motion</asp:ListItem>
                        <asp:ListItem Value="4">Inspection and Palpation</asp:ListItem>
                        <asp:ListItem Value="5">Orthopedic</asp:ListItem>
                        <asp:ListItem Value="6">Neurological</asp:ListItem>
                    </asp:DropDownList>
                    <%--+++++++++++++++++++++--%>           
                    <asp:Panel runat="server" ID="vitalsigns">
                        <%--<h4>Vital Signs</h4>--%>
                         <br /><asp:Button runat="server" ID="Button6" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Vital Signs"/> <br />
                        <%--<div class="col-sm-6 col-md-4 col-lg-3">--%>
                        <asp:Table ID="Table1" class="table borderless" runat="server">
                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>&nbsp;Systolic</asp:TableCell>
                                <asp:TableCell>Diastolic</asp:TableCell>
                                <asp:TableCell>Heart Rate</asp:TableCell>
                                <%--<asp:TableCell>Weight</asp:TableCell>--%>
                                <%--<asp:TableCell>Height Inches</asp:TableCell>--%>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>Blood Pressure</asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="bps" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="bpd" CssClass="form-control" runat="server"></asp:TextBox>
                                    <%--<asp:Label ID="blah" runat="server" Text="Label">&nbsp;/</asp:Label>--%>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="bph" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                               
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <asp:TableCell>Weight</asp:TableCell>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TableCell>Height Inches</asp:TableCell>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell></asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="weight" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="heigth" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                
                            </asp:TableRow>
                        </asp:Table>
                        <br /><br /><asp:Button runat="server" ID="vitalsigngsSave" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Vital Signs Form Save"
                         OnClick="vitalsigngsSave_Click"/>
                        <%--</div>--%>				   
                    </asp:Panel>
                    <%--+++++++++++++++++++++--%> 
                    <asp:Panel runat="server" ID="sitreach">
                        <%--<h4>Sit Reach and Grip</h4>--%>
                         <br /><asp:Button runat="server" ID="Button5" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Sit Reach and Grip"/> <br />
                        <asp:Table ID="Table2" class="table borderless" runat="server" Width="200px">
                            <asp:TableRow>
                                <asp:TableCell>Flex</asp:TableCell>
                                <asp:TableCell>Grip_L</asp:TableCell>
                                <asp:TableCell>Grip_R</asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="oneone" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="onetwo" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="onethree" CssClass="form-control" runat="server"></asp:TextBox> 
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="twoone" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="twotwo" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="twothree" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="threeone" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="threetwo" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="threethree" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <asp:Button runat="server" ID="sitandreachSave" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Sit and Reach Form Save" OnClick="sitandreachSave_Click" />
                    </asp:Panel>
                    <%--+++++++++++++++++++++--%> 
                    <asp:Panel ID="rangeofmotion" runat="server">
                         <br /><asp:Button runat="server" ID="Button4" CssClass="btn" BackColor="#093965" ForeColor="White" Text="rangeofmotion"/> <br />
                       <%-- <h4>Range of Motion</h4>--%>
                        <asp:Label class="redtext" runat="server" Text="Label">Cervical Spline</asp:Label>
                        <asp:Table ID="Table3" class="table borderless" runat="server" Width="700px">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Flexion:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="cf1" runat="server" Width="80%"></asp:TextBox>
                                    <asp:Label runat="server" Text="Label">&nbsp;/60+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="cfp1" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Extension:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="ce2" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label4" runat="server" Text="Label">&nbsp;/75+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label5" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="cep2" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Left Rotation:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="clr3"  runat="server"></asp:TextBox>
                                    <asp:Label ID="Label6" runat="server" Text="Label">&nbsp;/80+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label7" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="clrp3"  runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label9" runat="server" Text="Label">Right Rotation:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="crr4"  runat="server"></asp:TextBox>
                                    <asp:Label ID="Label8" runat="server" Text="Label">&nbsp;/80+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label10" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="crrp3"  runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label12" runat="server" Text="Label">Left Lateral Flexion:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="cll5" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label11" runat="server" Text="Label">&nbsp;/45+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label13" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="cllp5" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label15" runat="server" Text="Label">Right Lateral Flexion:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="crl6" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label14" runat="server" Text="Label">&nbsp;/45+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label19" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="crlp6" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <%--+++++++++++++++++ Second table +++++++++++++++++--%>
                        <asp:Label class="greentext" runat="server" Text="Label">Thoracolumbar</asp:Label>
                        <asp:Table ID="Table4" runat="server" class="table borderless" Width="600px">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label16" runat="server" Text="Label">Flexion:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tf1" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label17" runat="server" Text="Label">&nbsp;/60+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label20" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="tfp1" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label21" runat="server" Text="Label">Extension:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="te2" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label22" runat="server" Text="Label">&nbsp;/25+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label23" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="tep2" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label24" runat="server" Text="Label">Left Rotation:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tlr3" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label25" runat="server" Text="Label">&nbsp;/30+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label26" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="tlrp3" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label27" runat="server" Text="Label">Right Rotation:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="trr4" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label28" runat="server" Text="Label">&nbsp;/30+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label29" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="trrp4" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label30" runat="server" Text="Label">Left Lateral Flexion:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tll5" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label31" runat="server" Text="Label">&nbsp;/25+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label32" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="tllp5" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label33" runat="server" Text="Label">Right Lateral Flexion:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="trl6" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label34" runat="server" Text="Label">&nbsp;/25+</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="Label35" runat="server" Text="Label">P:&nbsp;</asp:Label>
                                    <asp:TextBox ID="trlp6" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <asp:Button runat="server" ID="rofSave" CssClass="btn" BackColor="#093965" ForeColor="White" Text="ROF Form Save" OnClick="rofSave_Click" />

                    </asp:Panel>
                    <%--+++++++++++++++++++++--%> 
                    <asp:Panel ID="inspection" runat="server" Width="900px">
                       <%-- <h4>Inspection and Palpation</h4>--%>
                        <br /> <asp:Button runat="server" ID="Button3" CssClass="btn" BackColor="#093965" ForeColor="White" Text="inspection"/> <br />
                            <asp:Label class="redtext" runat="server" Text="Label">
                            C/T Spline: Obs Joint Dysf</asp:Label> &nbsp;
                            <asp:TextBox ID="ct" CssClass="form-control" runat="server"></asp:TextBox><br /><br />

                            <asp:Label runat="server">Suboccipital Musculature_L</asp:Label> &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:Label runat="server">Suboccipital Musculature_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smlt" runat="server" name="sml" value="t"/>T <%--runat="server" name="" value=""--%>
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smls" runat="server" name="sml" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smln" runat="server" name="sml" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smlp" runat="server" name="sml" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smrt" runat="server" name="smr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smrs" runat="server" name="smr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smrn" runat="server" name="smr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="smrp" runat="server" name="smr" value="p"/>P
                            </asp:Label> <br /><br />

                        <asp:Label runat="server">SCM Musculature_L</asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label runat="server">SCM Musculature_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmlt" runat="server" name="scm" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmls" runat="server" name="scm" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmln" runat="server" name="scm" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmlp" runat="server" name="scm" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmrt" runat="server" name="scmr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmrs" runat="server" name="scmr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmrn" runat="server" name="scmr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scmrp" runat="server" name="scmr" value="p"/>P
                            </asp:Label>
                        <br /> <br />

                       <asp:Label runat="server">Paraspinal Musculature C/T_L</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server">Paraspinal Musculature C/T_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="pmlt" runat="server" name="pml" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="pmls" runat="server" name="pml" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="pmln" runat="server" name="pml" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="pmlp" runat="server" name="pml" value="p" />P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;   
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="pmrt" runat="server" name="pmr" value="t"/>T
                            </asp:Label>
                            <asp:Label ID="Label63" runat="server" class="radio-inline">
                                <input type="radio" id="pmrs" runat="server" name="pmr" value="s"/>S
                            </asp:Label>
                            <asp:Label ID="Label64" runat="server" class="radio-inline">
                                <input type="radio" id="pmrn" runat="server" name="pmr" value="n"/>N
                            </asp:Label>
                            <asp:Label ID="Label65" runat="server" class="radio-inline">
                                <input type="radio" id="pmrp" runat="server" name="pmr" value="p"/>P
                            </asp:Label>
                        <br /><br /> <br />
                        <%--++++++++++++++++++++ L/S ++++++++++++++++++--%>
                        <asp:Label class="greentext" runat="server">
                            L/S Spine: Obs Joint Dysf</asp:Label>&nbsp;
                            <asp:TextBox ID="ls" CssClass="form-control" runat="server"></asp:TextBox><br /> <br />

                            <asp:Label runat="server">Trapezius muscles_UT_L</asp:Label> &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:Label runat="server">Trapezius muscles_UT_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmlt" runat="server" name="tml" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmls" runat="server" name="tml" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmln" runat="server" name="tml" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmlp" runat="server" name="tml" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmrt" runat="server" name="tmr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmrs" runat="server" name="tmr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmrn" runat="server" name="tmr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tmrp" runat="server" name="tmr" value="p"/>P
                            </asp:Label> <br /><br />

                        <asp:Label runat="server">Trapezius muscles_MT_L</asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:Label runat="server">Trapezius muscles_MT_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtlt" runat="server" name="mtl" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtls" runat="server" name="mtl" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtln" runat="server" name="mtl" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtlp" runat="server" name="mtl" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtrt" runat="server" name="mtr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtrs" runat="server" name="mtr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtrn" runat="server" name="mtr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="mtrp" runat="server" name="mtr" value="p"/>P
                            </asp:Label>
                        <br /> <br />

                        <asp:Label runat="server">Trapezius muscles_LT_L</asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label runat="server">Trapezius muscles_LT_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltlt" runat="server" name="ltl" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltls" runat="server" name="ltl" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltln" runat="server" name="ltl" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltlp" runat="server" name="ltl" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltrt" runat="server" name="ltr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltrs" runat="server" name="ltr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltrn" runat="server" name="ltr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="ltrp" runat="server" name="ltr" value="p"/>P
                            </asp:Label>
                        <br /> <br />

                       <asp:Label runat="server">Paraspinal Musculature T/L_L</asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server">Paraspinal Musculature T/L_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tllt" runat="server" name="tll" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tlls" runat="server" name="tll" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tlln" runat="server" name="tll" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tllp" runat="server" name="tll" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;   
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tlrt" runat="server" name="tlr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tlrs" runat="server" name="tlr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tlrn" runat="server" name="tlr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tlrp" runat="server" name="tlr" value="p"/>P
                            </asp:Label>
                        <br /><br />

                        <asp:Label runat="server">Piriformis Musculature_L</asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label runat="server">Piriformis Musculature_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lslt" runat="server" name="lsl" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lsls" runat="server" name="lsl" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lsln" runat="server" name="lsl" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lslp" runat="server" name="lsl" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lsrt" runat="server" name="lsr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lsrs" runat="server" name="lsr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lsrn" runat="server" name="lsr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="lsrp" runat="server" name="lsr" value="p"/>P
                            </asp:Label>
                        <br /> <br />

                        <asp:Label runat="server">Gluteal Musculature_L</asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                            <asp:Label runat="server">Gluteal Musculature_R</asp:Label><br />&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmlt" runat="server" name="gml" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmls" runat="server" name="gml" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmln" runat="server" name="gml" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmlp" runat="server" name="gml" value="p"/>P
                            </asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmrt" runat="server" name="gmr" value="t"/>T
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmrs" runat="server" name="gmr" value="s"/>S
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmrn" runat="server" name="gmr" value="n"/>N
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="gmrp" runat="server" name="gmr" value="p"/>P
                            </asp:Label>
                        <br /> <br />
                         <br />
                        <asp:Button runat="server" ID="inspectionSave" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Inspection Form Save" OnClick="inspectionSave_Click" />
                    </asp:Panel>
                    <%--+++++++++++++++++++++--%> 
                    <asp:Panel ID="orthopedic" runat="server" Width="900px">
                         <br /><asp:Button runat="server" ID="Button2" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Orthopedic"/> <br />
                       <%--<h4>Ort hopedic</h4>--%>

                        <asp:Label style="color:red;" runat="server" class="checkbox-inline">
                           Cervical &nbsp; &nbsp; &nbsp;<input type="checkbox" runat="server" id="o1"/> 
                        </asp:Label>
                        <asp:Label style="color:red;" runat="server" class="checkbox-inline">
                           Cervicothoracic &nbsp; &nbsp; &nbsp;<input type="checkbox" runat="server" id="o2"/> 
                        </asp:Label><br />
                        <asp:Label runat="server">Soto-Hall</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="shp" name="Soto-Hall" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="shn" name="Soto-Hall" runat="server" value="n"/>N
                            </asp:Label><br /><br />
                        <asp:Label runat="server"  Class="redtext">NRC</asp:Label><br />
                        <asp:Label runat="server">Foraminal Compresion_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" >Foraminal Compresion_R</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="fclp" name="fcl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="fcln" name="fcl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="fcrp" name="fcr" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="fcrn" name="fcr" runat="server" value="n"/>N
                            </asp:Label><br />

                        <asp:Label runat="server" >Cervical Distraction</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">Max Cervical Compression</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="cdp" name="cd" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="cdn" name="cd" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="mcp" name="cm" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="mcn" name="cm" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server" >Shoulder Depression_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">Shoulder Depression_R</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="sdlp" name="sdl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="sdln" name="sdl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="sdrp" name="sdr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="sdrn" name="sdr" runat="server" value="n"/>N
                            </asp:Label> <br /><br />

                        <asp:Label runat="server" class="redtext">IVD</asp:Label><br />
                        <asp:Label runat="server">Dejerine's Triad</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">Swallowing</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="dtp" name="dt" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="dtn" name="dt" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="sp" name="s" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="sn" name="s" runat="server" value="n"/>N
                            </asp:Label> <br /><br />

                        <asp:Label runat="server"  class="redtext">NVC</asp:Label><br />
                        <asp:Label runat="server">V.B.A.I_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">V.B.A.I_R</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="vlp" name="vl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="vln" name="vl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="vrp" name="vr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="vrn" name="vr" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server">Adsons_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" >Adsons_R</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="alp" name="al" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="aln" name="al" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="arp" name="ar" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="arn" name="ar" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server" >Shoulder Compression_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" >Shoulder Compression_R</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="sclp" name="scl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scln" name="scl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scrp" name="scr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="scrpn" name="scr" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server" >Wrights Hyperabduction_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">Wrights Hyperabduction_R</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="whlp" name="whl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="whln" name="whl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="whrp" name="whr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="whrn" name="whr" runat="server" value="n"/>N
                            </asp:Label> <br /><br />

                        
                        <asp:Label style="color:green;" runat="server"  class="checkbox-inline">
                         Thoracolumbar &nbsp; &nbsp; &nbsp;<input type="checkbox" id="ot1" runat="server"/> 
                        </asp:Label>
                        <asp:Label style="color:green;" runat="server"  class="checkbox-inline">
                           Lumbar &nbsp; &nbsp; &nbsp;<input type="checkbox" id="ol2" runat="server"/> 
                        </asp:Label><br /><br />
                        <asp:Label ID="Label1" runat="server" Class="greentext">Nerve Root Compr</asp:Label><br />
                        <asp:Label runat="server" >Bechterew's_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">Bechterew's_R</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="blp" name="bl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="bln" name="bl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="brp" name="br" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="brn" name="br" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server">Kemp's_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">Kemp's_R</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="klp" name="kl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="kln" name="kl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="krp" name="kr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="krn" name="kr" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server">SLR_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">SLR_R</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="slrlp" name="slrl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="slrln" name="slrl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="slrrp" name="slrr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="slrrn" name="slrr" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server">Ely's_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server">Ely's_R</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="elylp" name="elyl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="elyln" name="elyl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="elyrp" name="elyr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="elyrn" name="elyr" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server" >Valsalva's_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" >Valsalva's_R</asp:Label><br />
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tvlp" name="tvl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tvln" name="tvl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="tvrp" name="tvr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="tvrn" name="tvr" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server"  Class="greentext">Sl Joint</asp:Label><br />
                        <asp:Label runat="server">Gaenslen's_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" >Gaenslen's_R</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="glp" name="gl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="gln" name="gl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="grp" name="gr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="grn" name="gr" runat="server" value="n"/>N
                            </asp:Label> <br />

                        <asp:Label runat="server">Yeoaman's_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" >Yeoaman's_R</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="ylp" name="yl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="yln" name="yl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="yrp" name="yr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="yrn" name="yr" runat="server" value="n"/>N
                            </asp:Label> <br />
                
                        <asp:Label runat="server" >Hoover's_L</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label runat="server" >DLR</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="hlp" name="hl" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="hln" name="hl" runat="server" value="n"/>N
                            </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" class="radio-inline">
                                <input type="radio" id="dlrp" name="dlr" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="dlrn" name="dlr" runat="server" value="n"/>N
                            </asp:Label> <br /> 
                        
                        <asp:Label style="color:green;" ID="Label2" runat="server" >Leg Lenght:</asp:Label>                 
                        <asp:TextBox ID="leglen" CssClass="form-control" runat="server"></asp:TextBox>cm<br />

                        <asp:Label runat="server" >Marnuson's_L</asp:Label><br />
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="mlp" name="ml" runat="server" value="p"/>P
                            </asp:Label>
                            <asp:Label runat="server"  class="radio-inline">
                                <input type="radio" id="mln" name="ml" runat="server" value="n"/>N
                            </asp:Label><br /><br />
                         <br />
                        <asp:Button runat="server" ID="orthSave" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Orthopedic Form Save" OnClick="orthSave_Click" />
                    </asp:Panel>
                    <%--+++++++++++++++++++++--%> 
                    <asp:Panel ID="neurlogical" runat="server">
                        <br />
                        <asp:Button runat="server" ID="Button1" CssClass="btn" BackColor="#093965" ForeColor="White" Text="Neurological"/> <br />
                       <%-- <h4>Neurological</h4>--%>
                        <asp:Label class="redtext" runat="server" Text="Label">Cervical Spine</asp:Label>
                        <asp:Table class="table borderless" ID="Table5" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Biceps(C5)_L:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Biceps(C5)_R:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Esthesias_C:</asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="bl1" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="br2" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="ec3" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Brachiorad(C6)_L:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Brachiorad(C6)_R:</asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="bl" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="br" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Triceps(C7)_L:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Triceps(C7)_R:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Muscle Strength</asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="tl1" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="tr2" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="ms" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        
                        <asp:Label class="greentext" runat="server" Text="Label">Lumbar Spine</asp:Label>
                        <asp:Table class="table borderless" ID="Table6" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Patellar(L4)_L:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Patellar(L4)_R:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Esthesias_L:</asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="pl1" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="pr2" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="el" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Achilles(S1)_L:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Achilles(S1)_R:</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">Muscle Strength</asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label runat="server" Text="HeelWalk_L">
                        <asp:RadioButtonList ID="HeelWalk_L" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>P&nbsp&nbsp</asp:ListItem>
                                     <asp:ListItem>N</asp:ListItem>
   
                                    </asp:RadioButtonList>

                        </asp:Label>
                            </div>
                             <div class="col-md-4">
                                 <asp:Label runat="server" Text="HeelWalk_R">
                        <asp:RadioButtonList ID="HeelWalk_R" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>P&nbsp;&nbsp;</asp:ListItem>
                                     <asp:ListItem>N</asp:ListItem>
   
                                    </asp:RadioButtonList>

                        </asp:Label>
                            </div>
                            </div>
                            <div class="row">
                             <div class="col-md-4">
                                 <asp:Label runat="server" Text="ToeWalk_L">
                        <asp:RadioButtonList ID="ToeWalk_L" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>P &nbsp;</asp:ListItem>
                                     <asp:ListItem>N</asp:ListItem>
   
                                    </asp:RadioButtonList>

                        </asp:Label>

                            </div>
                        <div class="col-md-4">
                        <asp:Label runat="server" Text="ToeWalk_R">
                        <asp:RadioButtonList ID="ToeWalk_R" CssClass="radioButtonList" runat="server" RepeatDirection="Horizontal">
   
                                     <asp:ListItem>P&nbsp;</asp:ListItem>
                                     <asp:ListItem>N</asp:ListItem>
   
                                    </asp:RadioButtonList>

                        </asp:Label>
                        </div>
                </div>
                      
                        <asp:Table class="table borderless" ID="Table7" runat="server" Width="450px">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="Label">
                                pathologcal-Babinski's;Fingerto Nose;Heel-Toe;Clonus W/A</asp:Label>
                                </asp:TableCell>
                                <asp:TableCell><asp:TextBox ID="lasttb" CssClass="form-control" runat="server"></asp:TextBox></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label runat="server" Text="All Negative" class="checkbox-inline" ><asp:CheckBox runat="server" id="check"/> </asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                         <br />
                        <asp:Button runat="server" ID="nuerologicalSave" Text="nuerologicalSave" CssClass="btn" BackColor="#093965" ForeColor="White" OnClick="nuerologicalSave_Click" />
                   
                    </asp:Panel>
                </div>
            </div>
        </div>
       
        <div class="modal-footer">
           <%--<center> <asp:Button ID="Button1" width="30%" runat="server" BackColor="#093965"  Text="Save" ForeColor="White" CssClass="btn" OnClick="save_button_Click" data-dismiss="modal" /> --%>
           <asp:Button runat="server" class="btn  btn-danger" ID="close" OnClick="close_Click" Text="Close" UseSubmitBehavior="false"  data-dismiss="modal" target="_blank" />
         
      </div>
        </div>
</div>
        </div>
   </form>
</body>
</html>

