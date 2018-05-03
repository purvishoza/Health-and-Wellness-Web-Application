<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="Fitness_Records" EnableEventValidation="false" Codebehind="Fitness_Records.aspx.cs" %>

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
        .sel
        {
        cursor: pointer;
        }
        body
        {
            margin: 50px;
        }
        textarea {
        resize: none;
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
        
        .delete { float: right; }
        .table thead tr th {
        background-color: #f9f9f9 !important;
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
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Prescription History for Fitness Issues" PostBackUrl="FitnessLogging.aspx"></asp:LinkButton></li>
                        <li role="presentation" >
                            <asp:LinkButton runat="server" Text="Employee's Fitness details" PostBackUrl="FitnessTesting_Fitness.aspx" ></asp:LinkButton></li>
                        <li role="presentation" class="active">
                            <asp:LinkButton runat="server" Text="Employee's Medical Records" ></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
       <br/>
            <br/>
            <br/>
        <div class="row">
            <div class="col-md-10 col-md-offset-1" >
            <asp:Panel ID="panel1" runat="server" Visible="true" Width="100%">
                     
      <h5 class="text-danger"><b>Records uploaded by the Employee</b></h5>
     <br/>
                         <table id="example" class="table table-striped table-bordered table-hover dt-responsive nowrap" cellspacing="0" style="border-radius: 5px; height: auto;" >
                           <thead>
                                <tr>
                                <th class="text-center" >File Name</th>
                                <th class="text-center" >Date</th>
                                <th class="text-center" ><input type="checkbox" id="select-all" value=""/></th>
                                </tr>
                            </thead>
                            <tbody>
                                 <%=BindData()%>
                             
                           </tbody>

                        </table><br/>
                         <button type="button" class="btn btn-sm btn-primary" data-toggle="modal" data-target="#myModal" style="margin: auto;">Send Mail to the doctor</button>
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
        "columnDefs": [ {
"targets": 2,
"orderable": false
} ],
        "sDom": '<"delete">frtip'
    } );
        
        $("div.delete").html('&nbsp;<button type="button" id="clear" class="btn btn-sm btn-danger"><i class="fa fa-times" aria-hidden="true"></i>Delete</button>');

        $('#select-all').click(function(event) {   
    if(this.checked) {
        // Iterate each checkbox
        $(':checkbox').each(function() {
            this.checked = true;                        
        });
    } else {
    $(':checkbox').each(function() {
            this.checked = false;                        
        });
        }
});
        $('#select-all1').click(function(event) {   
    if(this.checked) {
        // Iterate each checkbox
        $(':checkbox').each(function() {
            this.checked = true;                        
        });
    } else {
    $(':checkbox').each(function() {
            this.checked = false;                        
        });
        }
});
        
        $('#clear').click(function () {
            var a = $(".remove");
            if (a.filter(":checked").length == 0) {
                alert("Select the files to be deleted");
            } else {
                if ($('#select-all').is(":checked")) {
                    var conf = confirm("You are deleting all the records uploaded by the Employee. Are you sure?");
                    if (conf == true) {
                        var dataValue = "{ ids: 'None'}";
                        $.ajax({
                            type: "POST",
                            url: "Fitness_Records_request.aspx/Delete",
                            data: dataValue,
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                            },
                            success: function (result) {
                                location.reload(true);
                            }
                        });
                    }
                } else {
                    var conf = confirm("You are deleting the records uploaded by the Employee. Are you sure?");
                    if (conf == true) {
                        var checkList = $('.remove:checkbox:checked');
                        var ids = [""];
                        $(checkList).each(function (i) {
                            ids[i] = $(this).val();
                        });
                        var dataValue = "{ ids: '" + ids + "'}";
                        $.ajax({
                            type: "POST",
                            url: "Fitness_Records_request.aspx/Delete",
                            data: dataValue,
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                            },
                            success: function (result) {
                                alert("The selected records are deleted.");
                                location.reload(true);
                            }
                        });
                    }
                }
            }
        });

        $('#myModal').on('shown.bs.modal', function() {
            var oTable1 = $('#example1').dataTable( {
        "oLanguage": {
            "sSearch": "Search all columns:"
        },
        "columnDefs": [ {
"targets": 1,
"orderable": false
} ],destroy: true,
    } );
        $('#mail_send').click(function() {
        
        if($('#email').val() == "") {
        alert("Please Enter the mail address to the recipient");
        } else {
        var checkList_att = $('.sel-att:checkbox:checked');
        var ids_att=[""];
        $(checkList_att).each(function(i){
        ids_att[i] = $(this).val();
        });
        var dataValue = "{ data: '"+ids_att+"', to: '"+$('#email').val()+"', msg: '"+$('#comment').val()+"'}";
        $.ajax({
    type: "POST",
    url: "Fitness_Records_request.aspx/SendMail",
    data: dataValue,
    contentType: 'application/json; charset=utf-8',
    dataType: 'json',
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        alert("Something went wrong");
    },
    success: function (result) {     
        alert('Mail Sent');
        $('#myModal').modal('toggle');
    }
});
        }
        });
        });
        } ); 

        $('.sel').click(function() {
        var name = $(this).html(); 
        window.location = "Fitness_Records_request.aspx?name="+name;
        });
         

</script>
     <div class="modal" id="myModal" >
<div class="modal-dialog modal-lg">
  <div class="modal-content">
    <div class="modal-header">
      <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
      <h3 class="modal-title">Send Mail</h3>
    </div>
    <div class="modal-body" id="modal-sum">
                    <h4 class="text-danger"><b>Select the files to be attached from the table below</b></h4>
                     <table id="example1" class="table table-striped table-bordered table-hover dt-responsive nowrap" cellspacing="0" style="border-radius: 5px; height: auto;" >
                           <thead>
                                <tr>
                                <th class="text-center" >File Name</th>
                                <th class="text-center" ><input type="checkbox" id="select-all1" value=""/></th>
                                </tr>
                            </thead>
                            <tbody>
                                 <%=BindData1()%>
                           </tbody>
                        </table><br/>
  <div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
    <input id="email" type="text" class="form-control" name="email" placeholder="Recipient's Email">
  </div><br/>
  <div class="input-group">
    <span class="input-group-addon">Message</span>
    <textarea class="form-control" rows="5" id="comment"></textarea>
  </div>
    </div>
    <div class="modal-footer">
    <button type="button" class="btn btn-default" id="mail_send">Send Mail</button>
      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
    </div>
  </div><!-- /.modal-content -->
</div><!-- /.modal-dialog -->
</div><!-- /.modal -->
</asp:Content>