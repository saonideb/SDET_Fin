<%@ Page Title="Session Expired" Language="VB" MasterPageFile="~/Logout.master" AutoEventWireup="false" CodeFile="SessionExpire.aspx.vb" Inherits="SessionExpire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main" height="100%" align="center">
    <table border="0"  cellpadding="0"  align ="center"cellspacing="0" style="width: 600px;">
    <tbody>
		<tr>
		<td class="head_already" width="100%" style="height: 100px">
		</td>
		</tr>
	</tbody>
	</table>


<table border="0"  align ="center"  class="body_txt_in" cellpadding="0" cellspacing="0" style="width: 600px; height: 55px; border: 1px solid #4a9ace">
	<tbody>
					<tr>
						<td colspan="3" style="height: 22px;">
							<div class="boxHead">    
							<div class="heading">Session Expired</div>
							</div>
						</td>
					</tr>
                                    
					<tr style="color: #666666">
						<td colspan="3" style=" height: 10px;" align="center">
						</td>
					</tr>
					
                    <tr>
						<td colspan="3" style=" height: 30px;" align="center">
							<table>
								<tr>
									<td style="width: 48px">
									<img src="Images/Alert_Icon_New.jpeg" alt="" style="height: 43px">
									</td>
									
									<td style="vertical-align:middle; text-align: center;">
									<span style="font-size: 11pt;color:black"><strong><span style="font-size: 16pt"><span
                                        style="color: red">Your session has expired due to inactivity.</span><br />
                                    </span>
                                        <br />
                                        Please </strong></span>
                        <asp:HyperLink ID="LoginLink" runat="server" Font-Bold="True" NavigateUrl="https://ipcservices.bits-pilani.ac.in/BAS" Font-Size="14px">Click here </asp:HyperLink><span
                            style="font-size: 11pt;color:black"><strong> to re-login</strong></span>
									</td>
								</tr>
							</table>
						</td>
					</tr>
	</tbody> 
	</table>

 </div>
</asp:Content>







