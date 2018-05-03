<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="medical_menu" Codebehind="medical_menu.aspx.cs" %>

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
        .table tr
        {
        cursor: pointer;
        }
        body
        {
            margin: 50px;
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
		<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="row">
            <div class="col-md-10 col-md-offset-1" >
				<h1 style="color: #093965;">Upload Medical Records</h1>
                    <hr />
                   <br /><br />
            <asp:Panel ID="panel1" runat="server" Visible="true" Width="100%">
					 <label>
                        Click here to Add files
                    <input type="file" id="FileUpload1" class="btn btn-default" runat="server" />
                    </label>
                    <asp:Button runat="server" ID="UploadButton" Text="Upload" BackColor="#093965" ForeColor="White" OnClick="UploadButton_Click" CssClass="btn" />
                         <br/>
                         <table id="example" class="table table-striped table-bordered table-hover dt-responsive nowrap" cellspacing="0" style="border-radius: 5px;" >
                           <thead>
                                <tr>
                                <th class="text-center" >File Name</th>
								<th class="text-center" ><input type="checkbox" id="select-all" value=""/></th>
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
        },
		"columnDefs": [ {
"targets": 1,
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
        $('#clear').click(function () {
            var a = $(".remove");
            if (a.filter(":checked").length == 0) {
                alert("Select the files to be deleted");
            } else {
                if ($('#select-all').is(":checked")) {
                    var conf = confirm("You are deleting all the records in the database. Are you sure?");
                    if (conf == true) {
                        var dataValue = "{ ids: 'None'}";
                        $.ajax({
                            type: "POST",
                            url: "medical_menu.aspx/Delete",
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
                    } else {

                    }
                } else {
                    var checkList = $('.remove:checkbox:checked');
                    var ids = [""];
                    $(checkList).each(function (i) {
                        ids[i] = $(this).val();
                    });
                    var dataValue = "{ ids: '" + ids + "'}";
                    $.ajax({
                        type: "POST",
                        url: "medical_menu.aspx/Delete",
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
		});
		} ); 

		$('.sel').click(function() {
        var name = $(this).html(); 
        window.location = "medical_menu.aspx?name="+name;
		});
      	 

</script>
	
</asp:Content>