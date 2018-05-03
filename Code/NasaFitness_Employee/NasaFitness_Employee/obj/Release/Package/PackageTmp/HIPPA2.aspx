<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="HIPPA2.aspx.cs" Inherits="NasaFitness_Employee.HIPPA2" %>
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

            .inputwrap label{
                display: inline-block;
                width: 200px;
                text-align: right;
            }
            .input{
                display: inline-block;
                text-align: right;
            }

    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <form id="form1" runat="server" class="border-class">
     
        <div class="form-group" style="font-size:12pt">
            <p style="color: #093965; font-size:32px" class="text-center">Informed Consent</p>
            <div class="col-lg-6" >
                <div class="inputwrap"><label for="user" class="labe2">Patient name:</label><asp:TextBox runat="server" ID ="PatientName" class="input" Disabled="Disabled"></asp:TextBox></div>
                <div class="inputwrap"><label for="user" class="labe2">Dated:</label><asp:TextBox runat="server" ID ="CurrentDate" class="input" Disabled="Disabled"></asp:TextBox></div>
            </div>
             <div class="col-log-6">
                <asp:Button runat="server" type="submit" class="button btn btn-primary center-block" value="Save" Text="Save" OnClick ="save_consent" />
            </div>
        </div>
     <br />
     <div class="clearfix"></div>  
     <hr />
     <div class="form-group" style = "font-size:12pt">
               <p> To the patient: Please read this entire document prior to signing it.  It is important that you understand the information contained in this document.  Please ask questions before you sign if there is anything that is unclear. </p>
        </div>


     <div class="form-group" style = "font-size:12pt">
        <p style = "font-size:12pt"><b>The nature of the chiropractic adjustment.</b></p>
        <p style="margin-left:20px">The primary treatment I use as a Doctor of Chiropractic is spinal manipulative therapy.  I will use that procedure to treat you.  I may use my hands or a mechanical instrument upon your body in such a way as to move your joints.  That may cause an audible “pop” or “click”, much as you have experienced when you “crack” your knuckles.  You may feel a sense of movement.</p>
     </div>


    <div class="form-group" style = "font-size:12pt">
     <p style = "font-size:12pt"><b>What are rehabilitation and fitness examinations.</b></p> 
     <p style="margin-left:20px"> Rehabilitation and fitness examinations comprise four different areas of assessment  1) Cardiovascular Fitness  2) Body Composition  3) Flexibility  4) Muscle Strength and Endurance.  Each provides a general indication  of the level of fitness and individual currently enjoys.  Fitness and rehabilitation examinations are performed for the following reasons:</p>
        <ul>        
            <li> To determine a baseline of individual fitness which can be used for future comparison for the purpose of monitoring improvements in health and fitness status.</li>
            <li>To identify specific area of fitness which need improvement.</li>
            <li>To prescribe and implement nutrition and exercise protocols necessary to accomplish a desired health and fitness outcome.</li>
            <li>To inform and educate individuals on the benefits of long-term fitness programs.  An informed individual is an empowered individual.  Knowledge and understanding pave the way for improved individual health and fitness.</li>
        </ul>
     </div>


      <div class="form-group" style = "font-size:12pt">
      <p><b>Analysis / Examination / Treatment</b></p> 
          <p style="margin-left:20px">As a part of the analysis, examination and treatment you are consenting to the following procedures: </p>
         
              <div class="col-lg-4">
            <ul>
                <li>Spinal Manipulative Therapy</li>
                <li>Range of Motion and felxibility testing</li>
                <li>Muscle strength and endurance testing</li>
                <li>Ultrasound therapy</li>
                <li>Radiographic therapy</li>
                <li>Palpation</li>
            </ul>        
             
              </div>
            
              <div class="col-lg-4">
                  <ul>
                      <li>Orthopedic testing</li>
                      <li>Postural Analysis</li>
                      <li>Hot/Cold therapy</li>
                      <li>Vital signs</li>
                      <li>Basic Nuerological testing</li>
                      <li>Electrical Muscle Stimulation</li>
                    </ul>
              </div>
              <div class="col-lg-4">
                  <ul>
                      <li>Therapuetic Excercise</li>
                      <li>Cardiovescular Excercise</li>
                      <li>Percent fat assesment using skin fold calipers</li>
                  </ul>
          </div>
           
   </div>
     <div class="clearfix"></div>

 


     <div class="form-group" style = "font-size:12pt">
      <p><b>The material risk inherent in chiropractic adjustment.</b></p> 
          <p style="margin-left:20px">As with any healthcare procedure there are certain complications which may arise during chiropractic manipulation and therapy.  These complications include but are not limited to fractures, disc injuries, dislocations, muscle strain, cervical myelopathy, costovertebral strings and separations and burns.  Some types of manipulation of the neck have been associated with injuries to arteries in the neck leading to or contributing to serious complications including stroke.  Some patients will feel some stiffness and soreness following the first few days of treatment.  I will make every reasonable effort during the examination to screen for contraindications to care; however, if you have a condition that would otherwise not come to my attention, it is your responsibility to inform me. </p>
     </div>
     

       <div class="form-group" style = "font-size:12pt">  
         <p><b>The probability of those risks occuring.</b></p>
         <p style="margin-left:20px">Fractures are rare occurrences and generally result from some underlying weakness of the bone which I check for during the taking of your history and during examination and X-ray.  Stroke has been the subject of tremendous disagreement.  The incidences of stroke are exceedingly rare and are estimated to occur between one in one million and one in five million cervical adjustments.  The other complications are also generally described as rare.</p>
     </div>
         

      <div class="form-group" style = "font-size:12pt">
      <p ><b>The risks and discomfort inherent in rehab and fitness exams.</b></p> 
          <p style="margin-left:20px"> There exists the possibility of certain changes occurring during the test.  They include abnormal pressure, fainting, disorders of the heartbeat, and a very rare instance of heart attack.  Every effort will be made to minimize them by the preliminary examination and by observation during testing.</p>
              
      </div>


        <div class="form-group" style = "font-size:12pt">
          <p><b>The availability and nature of other treatment options.</b></p>
          <p style="margin-left:20px"> Other tretament options for your condition may include: </p>
              <ul style="margin-left:20px;">
                <li> Self-administered, over-the-counter analgescis and rest.</li>
                <li> Medical care and prescription drugs as anti-inflammatory, muscle relaxants and pain killers.</li>
                <li> Hospitalization </li>
               <li> Surgery </li>
              </ul>
            <p style="margin-left:20px"> If you chose to use one of the above noted “other treatment” options, you should be aware that there are risks and benefits of such options and you may wish to discuss these with your primary medical physician. </p>
        </div>

        <div class="form-group" style = "font-size:12pt"> 
            <p><b>The risks and dangers attendant to remaining  untreated.</b></p>
            <p style="margin-left:20px">Remaining untreated may allow the formation of adhesions and reduce mobility which may set up a pain reaction further reducing mobility.  Over time, this process may complicate treatment making it more difficult and less effective the longer it is postponed.</p>
            
        </div>
        <div class="form-group" style = "font-size:12pt"> 
            <p>I hereby authorize S.P.A.C.E Center Chriopractic and its employees to release any and all clinical and financial information to insurance carriers and representatives concerning my illness and 
                treatments and to other providers or my attorney if so requested by them. I hereby assign to S.P.A.C.E. Center all payments for health care services rendered to myself or my dependents. I
                understand that I am responsible for any amount not converted by insurance. I further authorize S.P.A.C.E. Center and its employees to perform examination,diagnostic, and treatment procedures on me,
                or my dependents. I also certify that the information I have provided is true to the best of my knowledge.
            </p>
        </div>
        <div class="form-group" style = "font-size:12pt"> 
            <p><b>DO NOT SIGN UNTIL YOU HAVE READ AND UNDERSTAND THE ABOVE .</b>
            <br /><b>PLEASE CHECK THE APPROPRIATE BLOCK AND SIGN BELOW.</b>
            </p>
            <p><b>I have read <asp:CheckBox ID="IRead" runat="server"/> or have had read to me <asp:CheckBox ID="ByRead" runat="server"/> the above explanation of the chiropractic adjustment and related treatments.  I have discussed it with Kyle O. Sprecher, D.C., M.A. and have had my questions answered to my satisfaction.  By signing below I state that I have weighed the risks involved in undergoing treatment and have decided that it is in my best interest to undergo the treatment recommended.  Having been informed of the risks, I hereby give my consent to that treatment.</b></p>
          </div>

    <div class="form-group">
        <div class='col-sm-3'>
            <div class="form-group">
                <label>Dated: </label>
               <div class='input-group date' id='datetimepicker1' >
                    <input type='text' class="form-control"  />
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
    </div>
   <br />

     <div class="clearfix"></div>
     <div>
     _______________________________________<br/>
     <p>Patient's name</p></div>
     <div>Signature on file<br/></div>
     <div>________________________________________<br/></div>
     <div class="form group">Signature: <asp:Button runat="server" type="submit" class="button btn btn-primary" value="Save" Text="Sign" /></div>
     <div>Signature on file<br/></div>
     <div>________________________________________<br/></div>
     <div class="form group">Signature of parent or Guardian(if a minor) <asp:Button runat="server" type="submit" class="button btn btn-primary" value="Save" Text="Sign" /></div>
 </form>
</asp:Content>
