<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Inherits="FollowUp" Codebehind="FollowUp.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/responsive/1.0.2/css/dataTables.responsive.css" />
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/1.10.3/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/responsive/1.0.2/js/dataTables.responsive.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.js"></script>

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
        .toolbar { float: left; }
        .table thead tr th {
        background-color: #f9f9f9 !important;
        }

    </style>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p style="color: #093965; font-size:32px">Prescriptions
        </p><hr /><br /><br />
       <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <asp:Panel ID="panel1" runat="server" Visible="true" Width="100%">
                         <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                         
                        
                           <thead>
                                <tr>
                                    <th class="text-center">Date</th>
                                    <th class="text-center">Name</th>
                                    <th class="text-center">Number of Problems</th>
                                    <th class="text-center">Questionnaire Type</th>
							        <th class="text-center">Desired Problem</th>
                                    

                                </tr>
                            </thead>
					        <tfoot style="display: table-header-group;">
                                <tr>
                                    <td><input type="search" id="datepicker" placeholder="Search Entry date" class="form-control" style="width:100%"/></td>
                                    <th>Name</th>
                                    <th>Number of Problems</th>
                                    <th>Questionnaire Type</th>
							        <th>Desired Problem</th>
                                    
                                </tr>
                            </tfoot>
                            <tbody>
                                 <%=GetTable()%>
                             
                           </tbody>

                        </table>
				</asp:Panel>
                </div>
            </div>
       
             
   <input id="row" runat="server" type="hidden"/>


    <script>
        
        $(document).ready(function() {
 (function($) {
/*
 * Function: fnGetColumnData
 * Purpose:  Return an array of table values from a particular column.
 * Returns:  array string: 1d data array
 * Inputs:   object:oSettings - dataTable settings object. This is always the last argument past to the function
 *           int:iColumn - the id of the column to extract the data from
 *           bool:bUnique - optional - if set to false duplicated values are not filtered out
 *           bool:bFiltered - optional - if set to false all the table data is used (not only the filtered)
 *           bool:bIgnoreEmpty - optional - if set to false empty values are not filtered from the result array
 * Author:   Benedikt Forchhammer <b.forchhammer /AT\ mind2.de>
 */
$.fn.dataTableExt.oApi.fnGetColumnData = function ( oSettings, iColumn, bUnique, bFiltered, bIgnoreEmpty ) {
    // check that we have a column id
    if ( typeof iColumn == "undefined" ) return new Array();

    // by default we only want unique data
    if ( typeof bUnique == "undefined" ) bUnique = true;

    // by default we do want to only look at filtered data
    if ( typeof bFiltered == "undefined" ) bFiltered = true;

    // by default we do not want to include empty values
    if ( typeof bIgnoreEmpty == "undefined" ) bIgnoreEmpty = true;

    // list of rows which we're going to loop through
    var aiRows;

    // use only filtered rows
    if (bFiltered == true) aiRows = oSettings.aiDisplay;
    // use all rows
    else aiRows = oSettings.aiDisplayMaster; // all row numbers

    // set up data array   
    var asResultData = new Array();

    for (var i=0,c=aiRows.length; i<c; i++) {
        iRow = aiRows[i];
        var aData = this.fnGetData(iRow);
        var sValue = aData[iColumn];

        // ignore empty values?
        if (bIgnoreEmpty == true && sValue.length == 0) continue;

        // ignore unique values?
        else if (bUnique == true && jQuery.inArray(sValue, asResultData) > -1) continue;

        // else push the value onto the result data array
        else asResultData.push(sValue);
    }

    return asResultData;
}}(jQuery));


function fnCreateSelect( aData )
{
    var r='<select class="form-control" style="width:100%"><option value="">All</option>', i, iLen=aData.length;
    for ( i=0 ; i<iLen ; i++ )
    {
        r += '<option value="'+aData[i]+'">'+aData[i]+'</option>';
    }
    return r+'</select>';
}


$(document).ready(function() {
    /* Initialise the DataTable */
    var oTable = $('#example').dataTable( {
        "oLanguage": {
            "sSearch": "Search all columns:"
        },
        "sDom": '<"toolbar">frtip'
    } );
        
    $("div.toolbar").html('<button type="button" id="clear" class="btn btn-sm" style="background-color:#428bca; color: white;"><i class="fa fa-times" aria-hidden="true"></i> Clear all Filters</button>');
        
    /* Add a select menu for each TH element in the table footer */
    $("tfoot th").each( function ( i ) {
        var j = i+1;
        this.innerHTML = fnCreateSelect( oTable.fnGetColumnData(j) );
        $('select', this).change( function () {
            oTable.fnFilter( $(this).val(), j);
        } );
    } );

        $("tfoot td").each( function () {
        $('input', this).change( function () {
            oTable.fnFilter($(this).val());
        } );
    } );
        
    $( function() {
     $( "#datepicker" ).datepicker({
  dateFormat: "m/d/yy",
        showButtonPanel: true,
     closeText: 'Clear',
     onClose: function (dateText, inst) {
         if ($(window.event.srcElement).hasClass('ui-datepicker-close')) {
             var x = document.getElementsByTagName("input");
        document.getElementById("datepicker").value = "";
        x[1].value = "";
        oTable.fnFilter("");
         }
     }
});
    } );    


$( "#clear" ).click(function() {
        var x = document.getElementsByTagName("select");
        for (var i = 0, len = x.length; i < len; i++) {
  x[i].value = "";
        oTable.fnFilter( $(this).val(), i+1 );
}
        var x = document.getElementsByTagName("input");
        document.getElementById("datepicker").value = "";
        x[1].value = "";
        oTable.fnFilter("");
});

});     
});
		$('tbody tr').click(function() {
        var tds = $(this).children('td');
        var date = tds[0].innerText;
		var type = tds[3].innerText;
        var dp = tds[4].innerText;
        
        window.location = "Prescription.aspx?date="+date+"&type="+type+"&dp="+dp;
            });
    </script>
    

</asp:Content>

