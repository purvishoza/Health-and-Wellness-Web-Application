<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="NasaFitness_Admin.AddCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.3.1/css/buttons.dataTables.min.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="http://cdn.datatables.net/responsive/1.0.2/css/dataTables.responsive.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" rel="stylesheet">

    <style>                
        .inputwrap label{
                display: inline-block;
                width: 200px;
                text-align: right;
            }
        .input{
                display: inline-block;
                text-align: left;
            }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
         <p style="color: #093965; font-size:32px">Add Company</p>
            <hr />
        <div class="form-group">
            <div class="col-lg-6" >
                <div class="inputwrap"><label for="user" class="labe2">Company Name: </label><asp:TextBox runat="server" ID ="cname" class="input" ></asp:TextBox></div>
                <div class="inputwrap"><label for="user" class="labe2">Location: </label><asp:TextBox runat="server" ID ="clocation" class="input" ></asp:TextBox></div>
            </div>
            <div class="col-log-6">
                <asp:Button runat="server" type="submit" class="button btn btn-primary center-block" value="Add" Text="Add" OnClick="add_company" />
            </div>
        </div>
      
    </form>

    </div>

    <div>
            
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <h1 style="color: #093965;">Companies</h1>
                    <hr />
                   <br /><br />
                     <asp:Panel ID="panel1" runat="server" Visible="true" Width="100%">
                         
                         <table id="example" class="table table-striped table-bordered table-hover dt-responsive nowrap" cellspacing="0" style="border-radius: 5px; overflow: hidden;" width="100%">
                           <thead>
                                <tr>
                                <th class="text-center" >Company Name</th>
                                <th class="text-center" >Company Location</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%=GetTable()%>

                           </tbody>

                        </table>
                             
                    </asp:Panel>

                </div>
            </div>
 

    </div>

    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/1.10.3/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/responsive/1.0.2/js/dataTables.responsive.js"></script>
    <script type="text/javascript" language="javascript" src="//cdn.datatables.net/plug-ins/a5734b29083/integration/bootstrap/3/dataTables.bootstrap.js"></script>
</asp:Content>
