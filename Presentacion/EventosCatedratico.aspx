<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventosCatedratico.aspx.cs" Inherits="Presentacion.EventosCatedratico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eventos</title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="padding: 20px">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <a class="navbar-brand" href="#"></a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="AsignacionesCatedratico.aspx">Cursos</a>
                        </li>
                    </ul>

                    <input id="txtBuscar" class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" onkeyup="Search_Gridview(this)" style="width: 250px;" />
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-danger" OnClick="CerrarSesion"  />
                </div>
            </nav>

            <section class="content-header">
                <br />
                <br />
                <h3 align="center" style="margin-top: 5px">EVENTOS</h3>
            </section>
            <br />
            <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridEventos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" EmptyDataText="Datos no disponibles" OnRowCommand="GridCurso_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:ButtonField ButtonType="Button" CommandName="Asistencia" Text="Asistencia" ControlStyle-CssClass="btn btn-primary" HeaderStyle-Width="2%" />
                            <asp:ButtonField ButtonType="Button" CommandName="VerAsistencia" Text="Ver Asistencia" ControlStyle-CssClass="btn btn-primary" HeaderStyle-Width="2%" />

                            <asp:BoundField DataField="idAsignacionEvento" HeaderText="ID" />
                            <asp:BoundField DataField="idEvento" HeaderText="Codigo Evento" />
                            <asp:BoundField DataField="Nombre" HeaderText="Evento" />
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
