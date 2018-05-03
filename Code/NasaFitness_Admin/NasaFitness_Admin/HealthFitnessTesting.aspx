<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" Inherits="HealthFitnessTesting" Codebehind="HealthFitnessTesting.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.3.1/css/buttons.dataTables.min.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/responsive/1.0.2/css/dataTables.responsive.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" rel="stylesheet">
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>
<style type="text/css">
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


        
    </style>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <form runat="server">
        <p style="color: #093965; font-size:32px">Health Inventory Details of Employee:
            
        <asp:Label runat="server" Style="font-size:32px;" ID="empnamehealthPage" />
        </p>
        <hr />
        <div class="row">
                <div class="col-md-10 col-xs-10">
                    <ul class="nav nav-tabs">
                        <li role="presentation"  >
                            <asp:LinkButton runat="server" Text="Health Issues and Prescription" PostBackUrl="Health.aspx"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Prescription History for Health Issues" PostBackUrl="HealthLogging.aspx"></asp:LinkButton></li>
                        <li role="presentation" class="active">
                            <asp:LinkButton runat="server" Text="Employee's Fitness details" ></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Employee's Medical Records" PostBackUrl="medical_record_request.aspx"></asp:LinkButton></li>
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
                                <th class="text-center" rowspan="2">Date</th>
                                <th class="text-center" colspan="2">Cardio Vascular</th>
                                <th class="text-center" colspan="4">Composition</th>
                                <th class="text-center" >Flexibility</th>
                                </tr>
                                <tr>
                                <th class="text-center" >Blood Pressure</th>
                                <th class="text-center" >RHR</th>
                                <th class="text-center" >Weight</th>
                                <th class="text-center" >Skin fold</th>
                                <th class="text-center" >BMI</th>
                                <th class="text-center" >Percent Body Fat</th>
                                <th class="text-center">Sit and Reach</th>
                                </tr>
                            </thead>
                            <tbody>
                                 <%=GetData(1)%>
                             
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
        },
        "sDom": '<"toolbar">frtip'
    } );
        $("div.toolbar").html('<a data-toggle="modal" href="#myModal" class="btn btn-sm" style="background-color:#428bca; color: white;">Muscle strength and Endurance</a>');
       
        });
       
</script>
    <div class="modal" id="myModal" >
<div class="modal-dialog modal-lg">
  <div class="modal-content">
    <div class="modal-header">
      <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
      <h3 class="modal-title">Muscle strength and Endurance </h3>
    </div>
    <div class="modal-body">
        <table class="table table-striped table-bordered table-hover">
          <thead>
          <tr>
            <th>Date</th>
          <th>Flexion</th>
                                <th>Extension</th>
                                <th>L-Bridge/R-Bridge</th>
                                <th>R-Grip/L-Grip</th>
                                <th>Push Ups</th>
                                <th>Curl Ups</th>
                                <th>Knee bend</th>
                                <th>Arm raise</th>
            </tr>
          </thead>
          <tbody>
             <%=GetData(2)%>
          </tbody>
      </table>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
    </div>
  </div><!-- /.modal-content -->
</div><!-- /.modal-dialog -->
</div><!-- /.modal -->
    </asp:Content>
