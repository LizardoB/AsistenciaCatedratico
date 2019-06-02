<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Login</title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="background-image: url(media/fondo-login.png)">
    <div class="container" id="login-box">
        <div class="row">
            <div class="col-lg-4">

            </div>
            <div class="col-lg-4">
                <div class="jumbotron" style="margin-top:120px"> 
                    <h3  style="text-align:center">Inicio de Sesión</h3>
                    <br />
                    <form id="form1" runat="server">
                        <div class="form-group">
              
                          <label>Usuario: </label>
                            <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="User"></asp:TextBox>
                        </div>

                         <div class="form-group">
                              <label>Contraseña:</label>
                             <asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control" placeholder="********"></asp:TextBox>
                        </div>

                         <div class="checkbox" style="text-decoration:underline">
                          <a href="#">Olvide la contraseña</a>
                        </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion" type="submit" class="bton btn-primary form-control"  OnClick="Button1_Click"/>
                       <br />
                        <div style="text-align:center; color:red" >
                            <asp:Label runat="server" Text="" ID="Mensaje"></asp:Label>
                        </div>
                        <div style="text-align:center; color:red" >
                            <asp:Label runat="server" Text="" ID="Mensaje2"></asp:Label>
                        </div>

                    </form>
                </div>
           </div>
           <div class="col-lg-4"></div>
        </div>
    </div>
</body>
</html>
