<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TomaAsistencia.aspx.cs" Inherits="Presentacion.TomaAsistencia" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/FaceDetector.js"></script>
    <script src="../js/webcam.min.js"></script>
    <script src="../js/WebcamManager.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="padding: 20px; overflow: hidden;">
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
                        <li class="nav-item">
                            <input type="button" value="Iniciar Asistencia" onclick="take_camera()" class="btn btn-primary">
                            <asp:Button ID="btnFinalizarAsistencia" runat="server" Text="Finalizar Asistencia" CssClass="btn btn-warning" OnClick="FinalizarAsistencia"/>
                        </li>
                    </ul>
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-danger" OnClick="CerrarSesion"  />
                </div>
            </nav>

            <section class="content-header">
                <br />
                <br />
                <h3 align="center" style="margin-top: 5px">ASISTENCIA</h3>
                <asp:Label ID="grupo" Text="" runat="server"></asp:Label>

            </section>
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                </div>
            </div>
            <br />
            <br />

            <div class="row" style="align-content: center">
                <div class="col-md-4"></div>
                <div class="col-md-8">

                    <video id="video" autoplay
                        style="position: absolute; width: 420px; height: 320px; border: 1px solid black;">
                        <%--420px; height: 340px;--%>
                    </video>

                    <canvas id="canvas" style="position: absolute; left: 0px; top: 0px;"></canvas>

                </div>
            </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-lg-5"></div>
                <div class="col-lg-2">
                    <input type="button" value="Take Snapshot" onclick="take_snapshot()" class="btn btn-success" style="width: 210px">
                </div>

            </div>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnAsistencia" runat="server" Text="Guardar" OnClick="Button1_Click" BorderStyle="None" BackColor="Transparent" BorderColor="Transparent" Style="color: white" />
                </ContentTemplate>
            </asp:UpdatePanel>


            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div id="results"></div>
            <asp:Image ID="Fotografia" runat="server" ImageUrl="" />

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <!-- Configure a few settings and attach camera -->
    </form>

    <script>
        function take_camera() {
            var timer = null;
            var camStreamWidth = 640;
            var camStreamHeight = 480;

            var VIEW_WIDTH = 320;
            var VIEW_HEIGHT = 240;

          

            var video = document.getElementById("video");
            var canvas = document.getElementById("canvas");

            canvas.width = VIEW_WIDTH;
            canvas.height = VIEW_HEIGHT;

            var webcamParams = {
                video: {
                    mandatory: {
                        maxWidth: camStreamWidth,
                        maxHeight: camStreamHeight,
                        minWidth: camStreamWidth,
                        minHeight: camStreamHeight
                    }
                }
            };
            var webcamMgr = new WebCamManager(
                {
                    webcamParams: webcamParams, //Set params for web camera
                    testVideoMode: false,//true:force use example video for test false:use web camera
                    videoTag: video
                }
            );

            var faceDetector = new FaceDetector(
                        {
                            video: webcamMgr.getVideoTag(),
                            flipLeftRight: false,
                            flipUpsideDown: false
                        }
                    );

                    webcamMgr.setOnGetUserMediaCallback(function () {
                        faceDetector.startDetecting();
                    });

                    faceDetector.setOnFaceAddedCallback(function (addedFaces, detectedFaces) {
                        for (var i = 0; i < addedFaces.length; i++) {
                            console.log("[facedetector] New face detected id=" + addedFaces[i].faceId + " index=" + addedFaces[i].faceIndex);
                        }
                    });

                    faceDetector.setOnFaceLostCallback(function (lostFaces, detectedFaces) {

                        var ctx = canvas.getContext("2d");
                        ctx.clearRect(0, 0, VIEW_WIDTH, VIEW_HEIGHT);

                        for (var i = 0; i < lostFaces.length; i++) {
                            console.log("[facedetector] Face removed id=" + lostFaces[i].faceId + " index=" + lostFaces[i].faceIndex);
                        }

                    });

                    faceDetector.setOnFaceUpdatedCallback(function (detectedFaces) {


                        var ctx = canvas.getContext("2d");
                        ctx.clearRect(0, 0, VIEW_WIDTH, VIEW_HEIGHT);

                        ctx.strokeStyle = "red";
                        ctx.lineWidth = 3;
                        ctx.fillStyle = "red";
                        ctx.font = "italic small-caps bold 20px arial";

                        for (var i = 0; i < detectedFaces.length; i++) {

                            var face = detectedFaces[i];

                            //ctx.fillText(face.faceId, face.x * VIEW_WIDTH, face.y * VIEW_HEIGHT);
                            ctx.strokeRect(face.x * VIEW_WIDTH, face.y * VIEW_HEIGHT + 10, face.width * VIEW_WIDTH, face.height * VIEW_HEIGHT);
                            

                        }

                    });

            webcamMgr.startCamera();

            Webcam.set({
                /*width: 320,
                height: 240,*/
                width: 420,
                height: 320,
                image_format: 'jpeg',
                jpeg_quality: 90
            });
            //Webcam.attach('#my_camera');
            Webcam.attach('#canvas');

        }
        //<!-- Code to handle taking the snapshot and displaying it locally -->
        function take_snapshot() {

            // take snapshot and get image data
            Webcam.snap(function (data_uri) {
                document.getElementById('Fotografia').src = data_uri;
                document.getElementById('TextBox1').value = data_uri;
                document.getElementById('btnAsistencia').click();
            });
        }

    </script>
</body>
</html>
