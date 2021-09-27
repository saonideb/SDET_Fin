<%@ Page Title="" Language="C#" MasterPageFile="~/Individual_Users/MasterPage.master" AutoEventWireup="true" CodeFile="View_Individual_Approval_Status_Step4.aspx.cs" Inherits="Individual_Users_View_Individual_Approval_Status_Step4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main" align="center" style="height: 100%">
        <table border="0" id="table_user_details" cellpadding="0" width="80%" cellspacing="0">
            <tbody>
                <tr valign="top">
                    <td class="head_already" style="height: 30px">
                        <div style="text-align: center">
                            <span>&nbsp;<span style="text-decoration: none">Approval Status</span></span>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>

        <table border="0" class="body_txt_in" cellpadding="0" cellspacing="0" style="width: 650px; height: 55px; border: 1px solid #008080">
            <tbody>
                <tr>
                    <td colspan="3" style="background-color: #4a9ace; height: 22px;">
                        <div class="boxHead">
                            <div class="heading">Approval Status</div>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td colspan="3" style="height: 15px;" align="center"></td>
                </tr>

                <tr>
                    <td>
                        <table border="0" class="body_txt_in" cellpadding="0" cellspacing="0" width="100%">
                            <tbody>


                                <tr>
                                    <td style="height: 30px; width: 400px; text-align: left;">&nbsp;&nbsp;<strong>Financial Year&nbsp;<span class="required"><strong>*</strong></span></strong></td>
                                    <td style="height: 30px; width: 19px; text-align: left;"><strong>:</strong></td>
                                    <td align="left" style="height: 30px; width: 500px;">
                                        <asp:DropDownList ID="ddl_financial_year" runat="server" Width="200px" TabIndex="1" Height="28px" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="Required" ControlToValidate="ddl_financial_year" Font-Bold="true" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="height: 2px"></td>
                                </tr>


                                <tr>
                                    <td style="height: 30px; width: 168px; text-align: left;">&nbsp;&nbsp;</td>
                                    <td style="height: 30px; width: 20px; text-align: left;">&nbsp;&nbsp;</td>
                                    <td align="left" style="height: 30px; width: 450px;">&nbsp;&nbsp; 
			                                <div align="left">
                                                <asp:Button ID="btn_sbumit" runat="server" Text="Procced" Width="110px" OnClick="btn_sbumit_Click" Font-Bold="True" Height="30px" TabIndex="2" />

                                            </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="3" style="height: 20px"></td>
                                </tr>

                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

