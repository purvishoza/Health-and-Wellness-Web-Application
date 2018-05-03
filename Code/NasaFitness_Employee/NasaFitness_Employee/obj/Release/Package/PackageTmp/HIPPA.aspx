<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="HIPPA.aspx.cs" Inherits="NasaFitness_Employee.HIPPA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

            .mytext{
                width:653px;
            }


            .border-class
            {
            border:thin black solid;
            margin:20px;
            padding:20px;
            }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="border-class" >
            <p style="color: #093965; font-size:32px">HIPPA Consent & Disclosure
                </p>
            <hr />
        <div class="form-group">
            <p style = "font-size:12pt">FEDERAL GOVERNMENT MANDATE TO COMPLETE THE FOLLOWING DOCUMENTS FOR ALL INDIVIDUALS: READ BELOW FOR DETAILS </p>

               <p style = "font-size:12pt"> The following screens have information related to the Health Information Portability Accountability Act (HIPAA). The HIPAA was created to protect the privacy rights of individual’ personal health information. It affects all those who are in contact with medical records or personal health information. 
                Under this law, healthcare providers are restricted from sharing information with others regarding health and fitness information or conditions unless a release is signed. The following documents are required by federal legislation by all health care providers to be signed by all patients. Please read the documents attached and indicate how you desire for your information to be shared as a patient. Thank you! </p>
        </div>
        <hr />
        <div class="row form-group">
                <p style =" font-size:12pt" class="text-center"><b>S.P.A.C.E. Center Chiropractic</b></p>
        </div>
        <div class="row form-group">
                <p style =" font-size:12pt" class="text-center"><b>AUTHORIZATION FOR DISCLOSURE OF HEALTH INFORMATION</b></p>
        </div>
        <div class="row form-group" style="font-size:12pt">
                <p>I,_ authorize S.P.A.C.E. Center Chiropractic to release my Protected Health Information, as described below, to:</p>
                <p>I request that my appointments be called and/or emailed to me at the following: (CHECK ALL THAT APPLY):</p>
            </div>
        <div class="row form-group" style="font-size:12pt">

                <asp:CheckBox ID="WorkEmailOK" runat="server" Text=" Work Email Address:" /><br />
                <asp:CheckBox ID="HomeEmailOK" runat="server" Text=" Home Email Address:" /><br />
                <asp:CheckBox ID="WorkTeleOK" runat="server" Text=" Work Telephone:" /><br />
                <asp:CheckBox ID="WorkAnsOK" runat="server" Text=" Work Telephone Answering Machine:" /><br />
                <asp:CheckBox ID="HomeTeleOK" runat="server" Text=" Home Telephone:" /><br />
                <asp:CheckBox ID="HomeAnsOK" runat="server" Text=" Home Telephone Answering Machine:" /><br />
                <asp:CheckBox ID="CellTeleOK" runat="server" Text=" Cell Telephone:" /><br />
                <asp:CheckBox ID="CellAnsOK" runat="server" Text=" Cell Telephone Answering Machine:" /><br />
                <asp:CheckBox ID="CellSMSOK" runat="server" Text=" Cell Telephone SMS messages:" /><br />
            </div>

        <div class="row form-group" style="font-size:12pt">
                <p>List spouse and/or other family members or individuals at work authorized to receive email, telephone calls and messages</p>
                <asp:TextBox runat="server" id="OhterFamily" class="input mytext" ></asp:TextBox>
            </div>

        <div class="row form-group" style="font-size:12pt">
                <p>I also specifically authorize that any sensitive information regarding (CHECK ALL THAT APPLY)</p>
                <asp:CheckBox ID="ExamResultsOK" runat="server" Text=" Examination Results," />
                <asp:CheckBox ID="HealthFitnessOK" runat="server" Text=" Health and/or Fitness Reports, or" />
                <asp:TextBox runat="server" id="WhatOtherReports" class="input"></asp:TextBox><p> be
                    released to the above referenced recipients. It is my understanding that the information to be released will be used for the following purposes (CHECK ALL THAT APPLY):</p>
                <asp:CheckBox ID="IndivRequestsOK" runat="server" Text=" At the request of the individual (no purpose need be specified)" /><br />
                <asp:CheckBox ID="MedicalCareOK" runat="server" Text=" Additional Medical Care " /><br />
                Other (Specify):<asp:TextBox runat="server" ID ="OtherInfo" class="input mytext" ></asp:TextBox>
            </div>

        <div class="row form-group" style="font-size:12pt">
                <br />
                <p>I understand that if the authorized recipient is not a provider, health plan, or clearinghouse required to comply with federal privacy standards, the information disclosed pursuant to this authorization may no longer be protected by the federal privacy standards and the recipient may redisclose my health information without obtaining any further authorization.</p>

            </div>

        <div class="row form-group" style="font-size:12pt">
                <p>INDIVIDUAL’S RIGHTS RELATING TO THIS AUTHORIZATON:</p>

            </div>

        <div class="row form-group" style="font-size:12pt">
                <p>I understand that I must be provided with a copy of this form if I choose to sign it. I understand that I am under no obligation to sign this form and that the practice may not condition my treatment, payment, or enrollment/eligibility for benefits on my decision to sign this form. I understand that I may revoke this Authorization by notifying the practice in writing of my revocation. To obtain information on how to revoke my Authorization or to receive a copy of my revocation, I am to contact: Dr. Kyle Sprecher at (281)332-1111. I am aware that my revocation will not be effective as to uses and/or disclosures of my health information that the person(s) and or organization(s) listed above have already made in reliance on this Authorization.</p>

            </div>

        <div class="row form-group" style="font-size:12pt">
                <p>EXPIRATION DATE: This Authorization is valid until:</p>
        </div>
        <div class="row form-group" style="font-size:12pt">
             <label for="user" class="labe2">1) No end date: (Patient Initials)</label><asp:TextBox runat="server" ID ="NoEndDate" class="input" OnClick="javascript:change(this);" Enabled="true"></asp:TextBox>  <label for="user" class="labe2"> or 2) End date: </label><asp:TextBox runat="server" ID ="EndDateForOKs" class="input" Enabled="true" OnClick="javascript:change(this);"></asp:TextBox>
         </div>   
         <div class="row form-group" style="font-size:12pt">
            <br />
                <a href="www.spacechiro.com/Policies.doc">Click Here For Policies and Procedures</a>
                <br />
                * <asp:CheckBox ID="Agree" runat="server"/> I have had an opportunity to review and understand the content of this Authorization form. 
                * <asp:CheckBox ID="CheckBox5" runat="server" /> I have had an opportunity to review and understand the content of this Authorization form. 
                    By checking this box, I am confirming that it accurately reflects my wishes.
        </div>
        <hr />

    </form>



 <!--       <script>
            function change(sender) {
                x = document.getElementById('<%= NoEndDate.ClientID %>');
                y = document.getElementById('<%= EndDateForOKs.ClientID %>');
                if (sender == x) {
                    y.disabled = true;
                }
                else {
                    x.disabled = true;
                }   
            }

            window.onload = function () {
                var a = document.getElementById('<%= CheckBox5.ClientID %>');
                var b = document.getElementById('<%= save.ClientID %>');
                b.disabled = true;

                a.onchange = function () {
                    if (a.checked) {
                        b.disabled = false;
                    }
                    else {
                        b.disabled = true;
                    }
                }
            }



    </script> -->


</asp:Content>
