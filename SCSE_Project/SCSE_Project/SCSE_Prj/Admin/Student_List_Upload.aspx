<%@ Page Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Student_List_Upload.aspx.cs" Inherits="SCSE_Prj.Admin.Student_List_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section id="main-content">
                <section class="wrapper site-min-height">
                    <h2><i class="fa fa-angle-right"></i>Upload Excel Sheet</h2>

                    <div class="row mt">
                        <div class="col-lg-12">
                            <div class="col-md-5">
                                <div class="form-panel">
                                    <div class="box-body">
                                        <div class="form-group">
                                            <label for="progcode" style="font-size: medium">Choose Excel File</label>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                        <asp:Button ID="Button1" class="form-control" runat="server" Width="49%" Text="Upload" CssClass="btn btn-success" ValidationGroup="a"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </section>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

