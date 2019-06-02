<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionesCatedratico.aspx.cs" Inherits="Presentacion.AsignacionesCatedratico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignacion Catedratico</title>
       <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="padding:20px">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
              <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <a class="navbar-brand" href="#"></a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <asp:Label runat="server" Text=""></asp:Label>
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link active" href="AsignacionesCatedratico.aspx">Cursos <span class="sr-only">(current)</span></a>
                        </li>
                       
                    </ul>
                    <input id="txtBuscar" class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" onkeyup="Search_Gridview(this)" style="width:250px;" />
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-danger" OnClick="CerrarSesion"  />

                </div>
            </nav>

             <section class="content-header">
                <br />
                <br />
                <h3 align="center" style="margin-top: 5px">CURSOS</h3>
            </section>
            <br />
            <br />

                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridCatedratico" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"  EmptyDataText="Datos no disponibles" OnRowCommand="GridCurso_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:ButtonField ButtonType="Button" CommandName="Evento" Text="Eventos" ControlStyle-CssClass="btn btn-primary" HeaderStyle-Width="2%" />

                            <asp:BoundField DataField="idAsignacionCatedratico" HeaderText="ID" />
                            <asp:BoundField DataField="idCurso" HeaderText="Codigo Curso" />
                            <asp:BoundField DataField="Nombre" HeaderText="Curso" />
                            <asp:BoundField DataField="Ciclo" HeaderText="Ciclo" />
                            <asp:BoundField DataField="personGroupId" HeaderText="Grupo" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
