<%@ Page Title="" Language="VB" MasterPageFile="~/Individual_Users/MasterPage.master" AutoEventWireup="false" CodeFile="Invalid_Request.aspx.vb" Inherits="Individual_Users_Invalid_Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" align="center" style="height: 100%">
        <table border="0" cellpadding="0" align="center" cellspacing="0" style="width: 600px;">
            <tbody>
                <tr>
                    <td class="head_already" width="100%" style="height: 20px"></td>
                </tr>
            </tbody>
        </table>

        <table border="0" align="center" class="body_txt_in" cellpadding="0" cellspacing="0" style="width: 45%; height: 55px; border: 1px solid #4a9ace">
            <tbody>
                <tr>
                    <td colspan="3" style="height: 22px;">
                        <div class="boxHead">
                            <div class="heading">Message</div>
                        </div>
                    </td>
                </tr>

                <tr style="color: #666666">
                    <td colspan="3" style="height: 20px;" align="center"></td>
                </tr>

                <tr>
                    <td colspan="3" style="height: 30px;" align="center">
                        <table>
                            <tr>
                                <td style="vertical-align: middle">
                                    <span style="font-size: 16pt; color: Red"><strong>Invalid Request. Please Try Agian.</strong></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 30px;" align="center">
                        <table>
                            <tr>
                                <td style="vertical-align: middle"></td>
                            </tr>
                        </table>
                    </td>
                </tr>

            </tbody>
        </table>
    </div>
</asp:Content>

