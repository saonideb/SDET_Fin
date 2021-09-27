<%@ Page Title="" Language="C#" MasterPageFile="~/Individual_Users/MasterPage.master" AutoEventWireup="true" CodeFile="View_Individual_Approval_Status_Step2.aspx.cs" Inherits="Individual_Users_View_Individual_Approval_Status_Step2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var window_style = "width=1100,height=1400,toolbar=0,menubar=0,location=0,status=yes,scrollbars=yes,resizable=yes,left=50,top=50";
        function Popup_window(window_url) {
            window.open(window_url, "", window_style);
        }
    </script>
    <div align="center">
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
        <div align="center">
            <table border="0" id="table_attendance_details" cellpadding="0" width="95%" cellspacing="0">
                <tbody>
                    <tr valign="top">
                        <td class="head_already" style="height: 30px">
                            <div style="text-align: center">
                                <span>
                                    <asp:Label ID="lbl_current_financial_year" runat="server" Text="Label"></asp:Label></span>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />


        <div id="main_div" runat="server" align="center">
            <table border="0" class="body_txt_in" align="center" cellspacing="0" style="width: 98%; height: 100%">
                <tbody>


                    <tr>
                        <td style="height: 10px"></td>
                    </tr>

                    <tr>
                        <td style="height: 30px; text-align: center;" colspan="3">
                            <div align="center">
                                <asp:GridView ID="DG1" runat="server" Width="100%" CellSpacing="3" CellPadding="5" DataKeyNames="Financial_Year,Approval_No,Department_Id" AutoGenerateColumns="False" BorderColor="#008080" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="GridView_RowDataBound">
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#008080" BorderWidth="1px" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#008080" BorderWidth="1px" Font-Bold="True" ForeColor="Red" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" ItemStyle-Font-Size="14px">
                                            <HeaderStyle Width="35px" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Approval_No" HeaderText="Approval #" />
                                        <asp:BoundField DataField="Head" HeaderText="Head" />
                                        <asp:BoundField DataField="Sub_Head" HeaderText="Sub Head" />
                                        <asp:BoundField DataField="Approval_No" HeaderText="Approval ID" Visible="false" />
                                        <asp:BoundField DataField="Financial_Year" HeaderText="Financial Year" Visible="false" />
                                        <asp:BoundField DataField="Department_Id" HeaderText="Department_Id" Visible="false" />
                                        <asp:BoundField DataField="Added_On" HeaderText="Submitted On" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="90px" />
                                        <asp:BoundField DataField="All_Total_Cost" HeaderText="Approval Total Amount (in Rs.)" DataFormatString="{0:c}" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="black" />
                                        <asp:BoundField DataField="Approval_Status" HeaderText="Approval Status" />

                                        <asp:BoundField DataField="HOD_Approval_Status" HeaderText="HOD Approval Status" />
                                        <asp:BoundField DataField="HOD_Approval_Remarks" HeaderText="HOD Approval Remarks" />
                                        <asp:BoundField DataField="HOD_Approval_Processed_On" HeaderText="HOD Approval Processed On" DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="SRCD_Dean_Approval_Status" HeaderText="SRCD Approval Status" />
                                        <asp:BoundField DataField="SRCD_Dean_Approval_Remarks" HeaderText="SRCD Remarks" />
                                        <asp:BoundField DataField="SRCD_Dean_Approval_Processed_On" HeaderText="SRCD Approval Processed On" DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="Dean_Approval_Status" HeaderText="Dean Admin Approval Status" />
                                        <asp:BoundField DataField="Dean_Approval_Processed_On" HeaderText="Dean Admin Approval Processed On" DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="Dean_Approval_Remarks" HeaderText="Dean Admin Remarks" DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="Director_Approval_Status" HeaderText="Director Approval Status" />
                                        <asp:BoundField DataField="Director_Approval_Processed_On" HeaderText="Director Approval Processed On" DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="Director_Approval_Remarks" HeaderText="Director  Remarks" DataFormatString="{0:dd-MMM-yyyy}" />
										
										<asp:BoundField DataField="Bill_Amount_Submit_Status" HeaderText="Bill Approval Status" />
                                        <asp:BoundField DataField="Bill_Amount" HeaderText="Bill Amount" />
										
                                        <asp:TemplateField HeaderText="Edit" Visible="false">
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <%-- <a href="javascript:Popup_window('PrintForm/PrintConsumbaleForm.aspx?FY=<%# Eval("Financial_Year")%>&AID=<%# Eval("Approval_No")%>')">
                                                    <img src="Images/print_button_icon.jpg" height="18px" width="90px" /></a>--%>

                                                <a href='Edit_Form.aspx?Approval_No=<%#Eval("Approval_No").ToString() %>'><%#Eval("Approval_Status").ToString()=="Not Approved"?"Edit":"" %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Print">
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <%#Eval("Sub_Head").ToString()=="Travel"?"<a href=\"javascript:Popup_window('PopUp_Webpages/Print_Form_A_Travel.aspx?FY="+Eval("Financial_Year")+"&AID="+Eval("Approval_No")+"')\"><img src=\"Images/print_button_icon.jpg\" height=\"18px\" width=\"90px\"  /></a>":"<a href=\"javascript:Popup_window('PopUp_Webpages/Print_Form_A.aspx?FY="+Eval("Financial_Year")+"&AID="+Eval("Approval_No")+"')\"><img src=\"Images/print_button_icon.jpg\" height=\"18px\" width=\"90px\"  /></a>" %>
                                                <%--<a href="javascript:Popup_window('PopUp_Webpages/Print_Form_A.aspx?FY=<%# Eval("Financial_Year")%>&AID=<%# Eval("Approval_No")%>')">
                                                    <img src="Images/print_button_icon.jpg" height="18px" width="90px"  /></a>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BorderColor="#008080" BackColor="WhiteSmoke" Font-Bold="True" Font-Size="Medium" BorderStyle="Solid" BorderWidth="1px"></PagerStyle>
                                    <EmptyDataTemplate>No records found.</EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#008080" Font-Bold="True" ForeColor="white" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#008080" BorderWidth="1px" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" HorizontalAlign="center" VerticalAlign="middle" BorderColor="#008080" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>

                   <tr>
                     <td style="height: 10px;" colspan="2">
                     </td>
                 </tr>

                  <tr>
                     <td colspan="2">
                         <div align="right">
                              <asp:Button ID="btn_refresh" runat="server" Font-Bold="true" tabindex="1" Height="30px" Width="140px" Text="Refresh Page" />
                         </div>
                        
                     </td>
                 </tr>
                 
                 <tr>
                     <td style="height: 30px;" colspan="2">
                     </td>
                 </tr>



                </tbody>
            </table>
        </div>
        <br />
</asp:Content>

