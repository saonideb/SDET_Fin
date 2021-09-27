<%@ Page Title="" Language="VB" MasterPageFile="~/Individual_Users/MasterPage.master" AutoEventWireup="false" CodeFile="Approval_Instructions_Individual.aspx.vb" Inherits="Individual_Users_Approval_Instructions_Individual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div id="container">
        <table border="0" id="table_attendance_details" cellpadding="0" width="70%" cellspacing="0">
            <tbody>
                <tr valign="top">
                    <td class="head_already" style="height: 30px">
                        <div style="text-align: center">
                            <span>Important Instructions</span>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />

    </div>


    <div id="main_div" align="center">
        <table border="0" cellpadding="0" cellspacing="0" width="70%">
            <tbody>
                <tr>
                    <td valign="top">
                        <table border="0" class="body_txt_in round_corner" cellpadding="0" cellspacing="0" style="width: 100%; height: 249px; border: 1px solid #008080;">
                            <tbody>
                                <tr>
                                    <td colspan="3" style="background-color: #4A9ACE; height: 22px;">
                                        <div class="boxHead">
                                            <div class="heading">
                                                Instructions
                                            </div>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="3" style="height: 20px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <div align="justify" style="margin-left: 10px; margin-right: 10px">
                                            <p style="text-align: center">
                                                <span style="font-size: 14px; font-weight: bold">
                                                    The funds allocated in the financial year 2021-22 can be utilized for the items sanctioned and funds available under a specific budget head. <br />The interchange of the budget head is not permitted. 
                                                </span>
                                            </p>
                                        </div>
                                    </td>
                                </tr>



                                <tr>
                                    <td colspan="3">
                                        <div align="center" style="margin-left: 8px; margin-right: 8px">
                                            <asp:CheckBox ID="chk_agree" runat="server" Text="I have read the above mentioned instructions carefully." Font-Bold="true" AutoPostBack="True" />
                                        </div>

                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="3" style="height: 10px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 10px;">
                                        <div align="center">
                                            <asp:Button ID="btn_submit" runat="server" Text="Continue" Font-Bold="True" Height="28px" Width="120px" Enabled="False" />
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="3" style="height: 20px;"></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

