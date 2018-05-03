<%@ Page Language="C#" AutoEventWireup="true" Inherits="FitnessPARQ" Codebehind="FitnessPARQ.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
     <div class="modal-header">
      <button type="button" class="close" data-dismiss="modal">x</button>
      <h4>PARQ Answers</h4>
    </div>
    <div class="modal-body">
      
             <table class="table table-striped table-bordered nowrap">

                                                            <thead class="addnew">
                                                                <tr>
                                                                    <th>Questions</th>
                                                                    <th>Answers</th>


                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%=BindData1()%>
                                                            </tbody>
                                                        </table>
        
      </div>
      <div class="modal-footer">
      
           <asp:Button runat="server" ID="Save" class="btn  btn-danger" Text="Close"  data-dismiss="modal" />
         
      </div>
        </form>
</body>
</html>

