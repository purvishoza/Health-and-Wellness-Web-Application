<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Exam_ResultPage" Codebehind="Exam_ResultPage.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
      @media only screen and (orientation:portrait) {
    
      body{
        font-size:30px;
    }
      h1{
          font-size:50px;
      }
    
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
            <div class="row">
                    <div class="col-md-12">
                        <h1 style="color:forestgreen;">
                            Result
                        </h1>
                       <hr />
                    </div>
              </div>
        <div class="row">
            <p>Time taken: <span id="time" runat="server"></span> Mins.<br /><a class="btn btn-warning btn-lg" href="Prescription.aspx" role="button" style="float:right;margin-right:25%">Back</a></p>
            <b>Correct Answers<br /></b>
            &nbsp Before Lecture: <b><span id="before" runat="server">5</span><br /></b>
            &nbsp After Lecture: <b><span id="after" runat="server">5</span></b>
        </div>
        <br />
        <div class="row">
            <p> <b>Answers:</b></p>
        </div>
         <div class="row" runat="server">
            <p id="question1" runat="server" contenteditable="true">1. Anaerobic means “without oxygen”</p>
            <p>Actual answer:&nbsp<span id="ans1" runat="server" style="color:forestgreen;"><b>True</b></span>&nbsp&nbsp&nbsp&nbsp Before Lecture:&nbsp<span id="before1" runat="server">True</span>&nbsp&nbsp&nbsp&nbsp After Lecture:&nbsp<span id="after1" runat="server">True</span> </p>
        </div>
        <div class="row">
            <p id="question2" runat="server">2. Long endurance events such a half marathon is a form of anaerobic training/exercise.</p>
            <p>Actual answer:&nbsp<span id="ans2" runat="server" style="color:forestgreen;"><b>True</b></span>&nbsp&nbsp&nbsp&nbsp Before Lecture:&nbsp<span id="before2" runat="server">True</span>&nbsp&nbsp&nbsp&nbsp After Lecture:&nbsp<span id="after2" runat="server">True</span> </p>
        </div>
        <div class="row">
            <p id="question3" runat="server">3. Resistance training may increase bone density and reduce the risk of osteopenia or osteoporosis.</p>
            <p>Actual answer:&nbsp<span id="ans3" runat="server" style="color:forestgreen;"><b>True</b></span>&nbsp&nbsp&nbsp&nbsp Before Lecture:&nbsp<span id="before3" runat="server">True</span>&nbsp&nbsp&nbsp&nbsp After Lecture:&nbsp<span id="after3" runat="server">True</span> </p>
        </div>
        <div class="row">
            <p id="question4" runat="server">4. When doing resistance exercise training, it is recommended that an individual does not rest to maximize performance outcomes.</p>
            <p>Actual answer:&nbsp<span id="ans4" runat="server" style="color:forestgreen;"><b>True</b></span>&nbsp&nbsp&nbsp&nbsp Before Lecture:&nbsp<span id="before4" runat="server">True</span>&nbsp&nbsp&nbsp&nbsp After Lecture:&nbsp<span id="after4" runat="server">True</span> </p>
        </div>
        <div class="row">
            <p id="question5" runat="server">5. Only a well-seasoned “gym-goer” should participate in resistance training.</p>
            <p>Actual answer:&nbsp<span id="ans5" runat="server" style="color:forestgreen;"><b>True</b></span>&nbsp&nbsp&nbsp&nbsp Before Lecture:&nbsp<span id="before5" runat="server">True</span>&nbsp&nbsp&nbsp&nbsp After Lecture:&nbsp<span id="after5" runat="server">True</span> </p>
        </div>
        
        
      

</asp:Content>

