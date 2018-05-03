<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="MasterPage.master" CodeBehind="DashboardEmp.aspx.cs" Inherits="NasaFitness_Employee.DashboardEmp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">--%>

    <!-- Optional theme -->
   <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">--%>

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous">

    </script>
    <link href="Content/sb-admin.css" rel="stylesheet"/>
    <link href="Content/morris.css" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/responsive/1.0.2/css/dataTables.responsive.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
<script src="http://code.jquery.com/jquery-1.8.2.min.js"></script>
  <script src="http://cdn.oesmith.co.uk/morris-0.4.1.min.js"></script>
    <script src="Scripts/jquery.easing.js"></script>
     <script src="Scripts/jquery.easy-ticker.js"></script>
	<script src="Scripts/justgage.js"></script>
     <script src="Scripts/raphael-2.1.4.min.js"></script>
    <style>
        .list-group { 
    margin: 0; 
    min-width: 280px;
    width: 100%;
    height : 50%;
 }
.legend { list-style: none; }
.legend li { float: left; margin-right: 10px; }
.legend span { border: 1px solid #ccc; float: left; width: 12px; height: 12px; margin: 2px; }

    </style>
   </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <div class="row">
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-body">
                                <div class="row">
                                 <div id="g1" class="gauge"></div>   
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-body">
                                <div class="row">
                                    <div id="g2" class="gauge"></div> 
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-body">
                                <div class="row">
                                    <div id="g3" class="gauge"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-body">
                                <div class="row">
                                    <div id="g4" class="gauge"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    <div class="row">
    <div class="col-lg-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h2 class="panel-title"><i class="fa fa-bell-o" aria-hidden="true"></i> Notification Panel</h2>
                                
                            </div>
                           <div class="panel-body" style="height:25%" id ="transactionpanel">
                                
                                <ul class="list-group">
                                    <%=PopulateValue() %>
                                    <%=PopulateValue1() %>
                                   <%=PopulateValue2() %>
                                    <%=PopulateValue3()%>
                                </ul>
                                <div class="text-right">
                                    <a href="FollowUp.aspx">View All Activity <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

        <div class="col-lg-4">
            <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h2 class="panel-title"><i class="fa fa-link"></i> Quick Links</h2>
                                
                            </div>
                            <div class="panel-body" style="height:25%">
                                <ul class="list-group" id ="transactionpanel2">
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="HealthCoaching.aspx">Click Here for Health Coaching</a>
                                </div>
                                        </li>
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="Reports.aspx">Click Here to View Reports</a>
                                </div>
                                        </li>
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="FollowUp.aspx">Click Here to Check Prescription</a>
                                </div>
                                        </li>
                                 <li class="list-group-item">
                                <div class="text-left">
                                    <a href="Loggings.aspx">Click Here to Log Fitness Details</a>
                                </div>
                                 </li>
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="Account.aspx">Click Here to Update Account Details</a>
                                </div>
                                 </li>
                                   
                                </ul>
                            </div>
                        </div>

            </div>

        <div class="col-lg-4">
            <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h2 class="panel-title"><i class="fa fa-bar-chart" aria-hidden="true"></i> Legend & Scale</h2>
                            </div>
                <div class="panel-body" style="height:25%">
                    <ul class="legend">
    <li><span class="low" style="background-color: #8A2BE2;"></span>&nbsp;Low</li>
    <li><span class="normal" style="background-color: #00ff00;"></span>&nbsp;Normal</li>
    <li><span class="warn" style="background-color: #FFA500;"></span>&nbsp;Warning</li>
    <li><span class="high" style="background-color: #ff0000;"></span>&nbsp;High</li>
</ul><br/><table class="table table-bordered">
			   <tr><td><b>Heart Rate</b></td><td>Normal: 60 - 100</td></tr>
               <tr><td><b>Systolic BP</b></td><td>Normal: 90 - 120</td></tr>
			   <tr><td><b>Diastolic BP</b></td><td>Normal: 60 - 80</td></tr>
			   <tr><td><b>BMI</b></td><td>Normal: 18 - 25</td></tr>
			   </table><p class="text-danger">NOTE!! Contact doctor for more accurate results</p>
                </div>
                </div>
            </div>
        </div>
	<label id="rhr" runat="server" class = "rhr" style="display: none;"></label>
	<label id="bp1" runat="server" class = "bp1" style="display: none;"></label>
	<label id="bp2" runat="server" class = "bp2" style="display: none;"></label>
	<label id="bmi" runat="server" class = "bmi" style="display: none;"></label>
   <script>
       $('#transactionpanel').easyTicker({
           direction: 'up',
           visible: 4,
       });

		document.addEventListener("DOMContentLoaded", function(event) {
        var rhrr = $('.rhr').html();
		var cys = $('.bp1').html();
		var dias = $('.bp2').html();
		var bm = $('.bmi').html();
		
      var g1 = new JustGage({
        id: 'g1',
        value: 0,
        min: 40,
        max: 150,
        title: "Heart Rate",
        relativeGaugeSize: true,
		label: 'BPM',
        gaugeWidthScale: 0.5,
        customSectors: [{
          color: '#ff0000',
          lo: 100,
          hi: 150
        }, {
          color: '#00ff00',
          lo: 60,
          hi: 100
        }, {
          color: '#8A2BE2',
          lo: 40,
          hi: 60
            }],
        counter: true
      });

	var g2 = new JustGage({
        id: 'g2',
        value: 0,
        min: 70,
        max: 190,
        title: "Systolic BP",
        relativeGaugeSize: true,
		label: 'mmHg',
        gaugeWidthScale: 0.5,
        customSectors: [{
          color: '#ff0000',
          lo: 140,
          hi: 190
        }, {
          color: '#00ff00',
          lo: 90,
          hi: 120
        }, {
          color: '#FFA500',
		  lo: 120,
		  hi: 140
		}, {
		  color: '#8A2BE2',
          lo: 70,
          hi: 90
		}],
        counter: true
      });

	var g3 = new JustGage({
        id: 'g3',
        value: 0,
        min: 40,
        max: 100,
        title: "Diastolic BP",
		label: 'mmHg',
        relativeGaugeSize: true,
        gaugeWidthScale: 0.5,
        customSectors: [{
          color: '#ff0000',
          lo: 90,
          hi: 100
        }, {
          color: '#00ff00',
          lo: 60,
          hi: 80
        }, {
          color: '#FFA500',
          lo: 80,
          hi: 90
        }, {
          color: '#8A2BE2',
          lo: 40,
          hi: 60
        }],
        counter: true
      });

	var g4 = new JustGage({
        id: 'g4',
        value: 0,
        min: 12,
        max: 42,
        title: "BMI",
		label: 'Kg/m2',
        relativeGaugeSize: true,
        gaugeWidthScale: 0.5,
        customSectors: [{
          color: '#ff0000',
          lo: 30,
          hi: 42
        }, {
          color: '#00ff00',
          lo: 18,
          hi: 25
        }, {
          color: '#8A2BE2',
          lo: 12,
          hi: 18
        }, {
          color: '#FFA500',
          lo: 25,
          hi: 30
        }],
        counter: true
      });

		g1.refresh(rhrr);g2.refresh(cys);g3.refresh(dias);g4.refresh(bm);
    });
   </script>

    </asp:Content>