<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUploadAndDownloadApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload & Download</title>
    <!--Bootstrap CSS-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <!--Left Column-->
                <div class="col"></div>
                <!--Middle Column-->
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label class="form-label" ID="lblUpload" runat="server" Text="Upload Syllabus"></asp:Label>
                        <asp:FileUpload class="form-control" ID="fUpload" runat="server" />
                        <div class="form-text">Only DOCX and PDF. Filesize<10MB</div>
                    </div>
                    <div>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    </div>
                    <asp:LinkButton ID="lbtnDownload" runat="server" Visible="false" OnClick="lbtnDownload_Click">Download</asp:LinkButton>
                </div>
                <!--Right Column-->
                <div class="col"></div>
            </div>
        </div>
    </form>
    <!--Bootstrap JS-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>