<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" EnableViewState="true" Inherits="FitnessLogging" Codebehind="FitnessLogging.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.3.1/css/buttons.dataTables.min.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/responsive/1.0.2/css/dataTables.responsive.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" rel="stylesheet">
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
<style type="text/css">
     #sumTable {border-spacing: 25px 6px; border-collapse: separate;}
#sumTable td    {padding: 6px;}
        .table-hover tbody tr:hover td
        {
            background-color: #D3D3D3;         
        }

        .modal-body {
    
    overflow: auto;
}
        
        
        input[type="search"] {
 -webkit-box-sizing: content-box;
 -moz-box-sizing: content-box;
 box-sizing: content-box;
 -webkit-appearance: searchfield;
}

input[type="search"]::-webkit-search-cancel-button {
-webkit-appearance: searchfield-cancel-button;
}
        .toolbar { float: left; }
        .table thead tr th {
        background-color: #f9f9f9 !important;
        }

        #example th {
        vertical-align:middle;
        }

     #example td {
        vertical-align:middle;
        }

        #mealTable thead tr th {
        background-color: #093965 !important;
        color: white;
        }

        #mealTable>tbody>tr:nth-child(odd)>td {
background-color: #778899; // Choose your own color here
 }
        
    </style>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <form runat="server">
        <p style="color: #093965; font-size:32px">Fitness Inventory Details of Employee:
            
        <asp:Label runat="server" Style="font-size:32px;" ID="empnamehealthPage" />
        </p>
        <hr />
        <div class="row">
                <div class="col-md-10 col-xs-10">
                    <ul class="nav nav-tabs">
                        <li role="presentation"  >
                            <asp:LinkButton runat="server" Text="Fitness Issues and Prescription" PostBackUrl="Fitness.aspx"></asp:LinkButton></li>
                        <li role="presentation" class="active">
                            <asp:LinkButton runat="server" Text="Prescription History for Fitness Issues"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Employee's Fitness details" PostBackUrl="FitnessTesting_Fitness.aspx"></asp:LinkButton></li>
                        <li role="presentation">
                            <asp:LinkButton runat="server" Text="Employee's Medical Records" PostBackUrl="Fitness_Records.aspx" ></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
       <br/>
            <br/>
            <br/>
        <div class="row">
            <div class="col-md-10 col-md-offset-1" >
            <asp:Panel ID="panel1" runat="server" Visible="true" Width="100%">
                         
                         <table id="example" class="table table-striped table-bordered table-hover dt-responsive nowrap" cellspacing="0" style="border-radius: 5px;" >
                           <thead>
                                <tr>
                                <th class="text-center" >Date</th>
                                <th class="text-center" >Problem</th>
                             <th class="text-center" >History of the problem</th>
                                <th class="text-center" >Review Date</th>
                                <th class="text-center" >Summary</th>
                                <th class="text-center" >Meal Plan</th>
                                </tr>
                            </thead>
                            <tbody>
                                 <%=BindData()%>
                             
                           </tbody>

                        </table>
                             
                    </asp:Panel>

           </div>
        </div>
      
    </form>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/1.10.3/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/responsive/1.0.2/js/dataTables.responsive.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/buttons/1.3.1/js/buttons.colVis.min.js"></script>
    
 


    <script type="text/javascript">
        
        $(document).ready(function() {
    var oTable = $('#example').dataTable( {
        "oLanguage": {
            "sSearch": "Search all columns:"
        }
    } );  
     
    $('.summary').click(function(){ 
     var tds = $(this).closest('tr').children('td');
        var date_curr = tds[0].innerText;
     var prob = tds[1].innerText;
     var dataValue = "{ date_curr: '"+date_curr+"', prob: '"+prob+"'}";
        var res;
        $.ajax({
    type: "POST",
    url: "HealthLogging.aspx/GetSummary",
    data: dataValue,
    contentType: 'application/json; charset=utf-8',
    dataType: 'json',
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
    },
    success: function (result) {
 res = result.d.split("^");
          $("#sumModal").modal("show");

    }
});  
     $('#sumModal').on('shown.bs.modal', function() {
    $("#empname").html("Prescription summary of " + res[0]);
     $('.fil').each(function(i) {
        if (res[i+1] != ""){ 
    $(this).html(res[i+1]);
        } else {
        $(this).html('----');
        }
});
     });
        });
        

        $('.meal').click(function(){ 
     var tds = $(this).closest('tr').children('td');
        var date_curr = tds[0].innerText;
     var prob = tds[1].innerText;
        var rdate = tds[3].innerText;
     var dataValue = "{ date_curr: '"+date_curr+"', prob: '"+prob+"', rdate: '"+rdate+"'}";
        var res;
        $.ajax({
    type: "POST",
    url: "HealthLogging.aspx/ViewMealPlan_Click",
    data: dataValue,
    contentType: 'application/json; charset=utf-8',
    dataType: 'json',
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
    },
    success: function (result) {
 res = result.d.split("^");
          $("#myModal2").modal("show");

    }
});  
     $('#myModal2').on('shown.bs.modal', function() {
    $("#empname1").html("Meal Plan for : " + res[0]);
        var times = res[1].split(",");
        $("#from").html(times[0].replace(/\]|\[|"/g,""));
        $("#to").html(times[1].replace(/\]|\[|"/g,""));
     $('.time').each(function(i) {
    $(this).html(times[i+2].replace(/\]|\[|"/g,""));      
    });
        var mon = res[2].split(",");
        var tue = res[3].split(",");
        var wed = res[4].split(",");
        var thu = res[5].split(",");
        var fri = res[6].split(",");
        var sat = res[7].split(",");
        var sun = res[8].split(",");
        $('.meal-fil-mon').each(function(i) {
    $(this).html(mon[i].replace(/\]|\[|"/g,""));      
});
        $('.meal-fil-tue').each(function(i) {
    $(this).html(tue[i].replace(/\]|\[|"/g,""));      
});
        $('.meal-fil-wed').each(function(i) {
    $(this).html(wed[i].replace(/\]|\[|"/g,""));      
});
        $('.meal-fil-thu').each(function(i) {
    $(this).html(thu[i].replace(/\]|\[|"/g,""));      
});
        $('.meal-fil-fri').each(function(i) {
    $(this).html(fri[i].replace(/\]|\[|"/g,""));      
});
        $('.meal-fil-sat').each(function(i) {
    $(this).html(sat[i].replace(/\]|\[|"/g,""));      
});
        $('.meal-fil-sun').each(function(i) {
    $(this).html(sun[i].replace(/\]|\[|"/g,""));      
});
     });
        });
        
       } ); 
       
</script>
    <div class="modal" id="sumModal" >
<div class="modal-dialog modal-lg">
  <div class="modal-content">
    <div class="modal-header">
      <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
      <h3 class="modal-title" id="empname"></h3>
    </div>
    <div class="modal-body" id="modal-sum">
                     <table id="sumTable">
                             <tr><td><b>Date</b></td><td class="fil"></td></tr>
                               <tr><td><b>Problem</b></td><td class="fil"></td></tr>
                             <tr><td><b>History of problem</b></td><td class="fil"></td></tr>
                             <tr><td><b>Problem code group</b></td><td class="fil"></td></tr>
                             <tr><td><b>Problem DX code description</b></td><td class="fil"></td></tr>
                             <tr><td><b>Monthly plan start date</b></td><td class="fil"></td></tr>
                             <tr><td><b>Monthly plan end date</b></td><td class="fil"></td></tr>
                             <tr><td><b>Goal</b></td><td class="fil"></td></tr>
                             <tr><td><b>Payoffs</b></td><td class="fil"></td></tr>
                             <tr><td><b>Suggested videos</b></td><td class="fil"></td></tr>
                             <tr><td><b>Suggested classes</b></td><td class="fil"></td></tr>
                             <tr><td><b>Mini goal date</b></td><td class="fil"></td></tr>
                             <tr><td><b>Mini goal</b></td><td class="fil"></td></tr>
                             <tr><td><b>Miscellaneous</b></td><td class="fil"></td></tr>
                             <tr><td><b>Fitness buddies</b></td><td class="fil"></td></tr>
                             <tr><td><b>Review Date</b></td><td class="fil"></td></tr>
                     </table>    
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
    </div>
  </div><!-- /.modal-content -->
</div><!-- /.modal-dialog -->
</div><!-- /.modal -->

 <div class="modal" id="myModal2">
     <div class="modal-dialog modal-lg">
          <div class="modal-content">
               <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h3 class="modal-title" id="empname1"></h3>
                </div>
                <div class="modal-body" id="meal-modal">
                    <p style="width:100%;font-weight: bold;"><span style="float:left">Plan Start Date : <span id="from"></span></span><span style="float:right">Plan End Date : <span id="to"></span></span></p><br/>
                    <table id="mealTable" class="table table-striped">
                        <thead>
                            <tr>
                                <th class="col-md-2"></th>
                                <th class="col-md-2">Breakfast<br/><span class="time"></span></th>
                                <th class="col-md-2">Breakfast Snack<br/><span class="time"></span></th>
                                <th class="col-md-2">Lunch<br/><span class="time"></span></th>
                                <th class="col-md-2">Lunch Snack<br/><span class="time"></span></th>
                                <th class="col-md-2">Dinner<br/><span class="time"></span></th>
                                <th class="col-md-2">Dinner Snack<br/><span class="time"></span></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="col-md-2">Monday</td>
                                <td class="meal-fil-mon col-md-2"></td>
                                <td class="meal-fil-mon col-md-2"></td>
                                <td class="meal-fil-mon col-md-2"></td>
                                <td class="meal-fil-mon col-md-2"></td>
                                <td class="meal-fil-mon col-md-2"></td>
                                <td class="meal-fil-mon col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2">Tuesday</td>
                                <td class="meal-fil-tue col-md-2"></td>
                                <td class="meal-fil-tue col-md-2"></td>
                                <td class="meal-fil-tue col-md-2"></td>
                                <td class="meal-fil-tue col-md-2"></td>
                                <td class="meal-fil-tue col-md-2"></td>
                                <td class="meal-fil-tue col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2">Wednesday</td>
                                <td class="meal-fil-wed col-md-2"></td>
                                <td class="meal-fil-wed col-md-2"></td>
                                <td class="meal-fil-wed col-md-2"></td>
                                <td class="meal-fil-wed col-md-2"></td>
                                <td class="meal-fil-wed col-md-2"></td>
                                <td class="meal-fil-wed col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2">Thursday</td>
                                <td class="meal-fil-thu col-md-2"></td>
                                <td class="meal-fil-thu col-md-2"></td>
                                <td class="meal-fil-thu col-md-2"></td>
                                <td class="meal-fil-thu col-md-2"></td>
                                <td class="meal-fil-thu col-md-2"></td>
                                <td class="meal-fil-thu col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2">Friday</td>
                                <td class="meal-fil-fri col-md-2"></td>
                                <td class="meal-fil-fri col-md-2"></td>
                                <td class="meal-fil-fri col-md-2"></td>
                                <td class="meal-fil-fri col-md-2"></td>
                                <td class="meal-fil-fri col-md-2"></td>
                                <td class="meal-fil-fri col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2">Saturday</td>
                                <td class="meal-fil-sat col-md-2"></td>
                                <td class="meal-fil-sat col-md-2"></td>
                                <td class="meal-fil-sat col-md-2"></td>
                                <td class="meal-fil-sat col-md-2"></td>
                                <td class="meal-fil-sat col-md-2"></td>
                                <td class="meal-fil-sat col-md-2"></td>
                            </tr>
                            <tr>
                                <td class="col-md-2">Sunday</td>
                                <td class="meal-fil-sun col-md-2"></td>
                                <td class="meal-fil-sun col-md-2"></td>
                                <td class="meal-fil-sun col-md-2"></td>
                                <td class="meal-fil-sun col-md-2"></td>
                                <td class="meal-fil-sun col-md-2"></td>
                                <td class="meal-fil-sun col-md-2"></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
  </div>
    </asp:Content>