<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master"  CodeBehind="Dashboard.aspx.cs" Inherits="NasaFitness_Admin.Dashboard" %>


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
  
   </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form runat="server">
            <div class ="row">
                <div class="col-lg-3 col-lg-3">
                    <h3>Welcome Admin</h3>
                </div>
                
            </div>
            
            
             <div class="row">
                    <div class="col-lg-4 col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-user fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label runat="server" Style="font-size:32px;" ID="nofpatients" />
                                        </div>
                                        <div><h4>Total Number of Patients from JSC and SAFB</h4></div>
                                    </div>
                                </div>
                            </div>
                            <a href="#">
                                <div class="panel-footer">
                                    
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-user fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label runat="server" Style="font-size:32px;" ID="newPatientsLbl" />
                                        </div>
                                        <div><h4>New Cases from Health & Fitness Inventories</h4></div>
                                    </div>
                                </div>
                            </div>
                            <a href="#">
                                <div class="panel-footer">
                                   
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-user fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9">
                                        <div class="huge text-right">
                                             <asp:Label runat="server" Style="font-size:32px;" ID="attendpatientlbl" />
                                             <div class="pull-right"><h4> Attended Cases from Health & Fitness Inventories</h4></div>
                                        </div>
                                        
                                    </div>
                                   
                                </div>
                            </div>
                            <a href="#">
                                <div class="panel-footer">
                                    
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                 </div>
            <div class ="row" >
                    <div class="col-lg-4 col-md-4">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-file-video-o fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label runat="server" Style="font-size:32px;" ID="nofvideos" />
                                        </div>
                                        <div><h4>Total Number of Videos</h4></div>
                                    </div>
                                </div>
                            </div>
                            <a href="#">
                                <div class="panel-footer">

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                 <div class="col-lg-4 col-md-4" >
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-file-pdf-o fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label runat="server" Style="font-size:32px;" ID="nooflectures" />
                                        </div>
                                        <div><h4>Total Number of Lectures</h4></div>
                                    </div>
                                </div>
                            </div>
                            <a href="#">
                                <div class="panel-footer">
                                   
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                 <div class="col-lg-4 col-md-4" >
                        <div class="panel panel-danger">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-file-text-o fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label runat="server" Style="font-size:32px;" ID="mrecords" />
                                        </div>
                                        <div><h4>Medical Records </h4></div>
                                    </div>
                                </div>
                            </div>
                            <a href="#">
                                <div class="panel-footer">
                                   
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                 </div>
            <div class="row">
                 <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h2 class="panel-title"><i class="fa fa-clock-o fa-fw"></i> Activity Panel</h2>
                                
                            </div>
                            <div class="panel-body">
                                
                                <!--<ul class="list-group" id ="transactionpanel">
                                     <%=PopulateValue() %>
                                    <%=PopulateValue1() %>
                                   <%=PopulateValue2() %>
                                    <%=PopulateValue3()%> 
                                </ul> -->
                                <ul class="list-group" id ="transactionpanel"></ul>
                                <div class="text-right">
                                    <a href="Problem_list.aspx">View All Activity <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
            <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-users fa-fw"></i> Employees from JSC & SAFB</h3>
                            </div>
                            <div class="panel-body">
                                <div id="donut-example">
                                  
                                </div>
                                </div>
                                
                            </div>
                        </div>
                    
              
                <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h2 class="panel-title"><i class="fa fa-link"></i> Quick Links</h2>
                                
                            </div>
                            <div class="panel-body" style="height:50%">
                                <ul class="list-group" id ="transactionpanel2">
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="Problem_list.aspx">Click Here for Health Questionnaire</a>
                                </div>
                                        </li>
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="FitnessProblemList.aspx">Click Here for Fitness Questionniare</a>
                                </div>
                                        </li>
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="medical_menu.aspx">Click Here to Upload Medical Record Request</a>
                                </div>
                                        </li>
                                 <li class="list-group-item">
                                <div class="text-left">
                                    <a href="AddVideos.aspx">Click Here to Upload more Videos</a>
                                </div>
                                 </li>
                                    <li class="list-group-item">
                                <div class="text-left">
                                    <a href="Add_Classes.aspx">Click Here for Upload more Presentations</a>
                                </div>
                                 </li>
                                   
                                </ul>
                            </div>
                        </div>
                    </div>
            </div>
    
            </form>
        

    <!-- Bootstrap Core JavaScript -->
  <!--  <script type="text/javascript">
        $(document).ready(function () {
            debugger;
    Morris.Donut({
  element: 'donut-example',
  data: [
     { label: "JSC Employees", value:  <%=GetValue() %> },
     { label: "SAFB Employees", value: <%=GetValue2() %>}
     
  ]
    });


        });

        
        </script> -->
</asp:Content>

