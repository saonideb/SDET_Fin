<%@ Page Title="" Language="VB" MasterPageFile="~/Individual_Users/MasterPage.master" AutoEventWireup="false" CodeFile="Approved_Budget_All.aspx.vb" Inherits="Individual_Users_Approved_Budget_All" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        /**
    td
    {
        cursor: pointer;
    }
    */
        .hover_row {
            background-color: #A1DCF2;
        }
    </style>


    <script type="text/javascript">
        $(function () {
            $("[id*=DG1] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>


    <div align="center">
        <table border="0" id="table_user_details" cellpadding="0" width="80%" cellspacing="0">
            <tbody>
                <tr valign="top">
                    <td class="head_already" style="height: 30px">
                        <div style="text-align: center">
                            <span>&nbsp;<span style="text-decoration: none">Approved Projects</span></span>
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

        <table border="0" class="body_txt_in" align="center" cellspacing="0" style="width: 95%; height: 100%">
            <tbody>

                <tr>
                    <td style="height: 5px"></td>
                </tr>

                <tr>
                    <td>
                        <div align="left" style="margin-left: 2px">
                            <asp:Label ID="lbl_faculty_heading" runat="server" Font-Bold="true" class="head_already" Font-Size="18px" Text="Faculty :"></asp:Label>
                            <asp:Label ID="lbl_faculty_name" runat="server" Font-Bold="true" ForeColor="Blue" Font-Size="18px" Text="Faculty Name"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lbl_department_heading" runat="server" Font-Bold="true" class="head_already" Font-Size="18px" Text="Department :"></asp:Label>
                            <asp:Label ID="lbl_department_name" runat="server" Font-Bold="true" ForeColor="Blue" Font-Size="18px" Text="Department Name:"></asp:Label>
                        </div>
                    </td>
                </tr>


            </tbody>
        </table>

        <div id="main_div" runat="server" align="center">
            <table border="0" class="body_txt_in" align="center" cellspacing="0" style="width: 95%; height: 100%">
                <tbody>


                    <tr>
                        <td style="height: 10px"></td>
                    </tr>

                    <tr>
                        <td style="height: 30px; text-align: center;" colspan="3">
                            <div align="center">
                                <asp:GridView ID="DG1" runat="server" Width="100%" CellSpacing="3" CellPadding="5" DataKeyNames="Financial_Year, Head,Department_Id" AutoGenerateColumns="False" BorderColor="#008080" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="GridView_RowDataBound">
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#008080" BorderWidth="1px" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#008080" BorderWidth="1px" Font-Bold="True" ForeColor="Red" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" ItemStyle-Font-Size="14px">
                                            <HeaderStyle Width="35px" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--    <asp:BoundField DataField="Project_ID" HeaderText="Project ID" ItemStyle-Font-Size="14px" Visible="false" />--%>
                                        <asp:BoundField DataField="Financial_Year" HeaderText="Financial Year" ItemStyle-Font-Size="14px" Visible="false" />
                                        <asp:BoundField DataField="Department_Id" HeaderText="Department_Id" ItemStyle-Font-Size="14px" Visible="false" />

                                        <%--  <asp:BoundField DataField="Main_Head" HeaderText="Main Head" ItemStyle-Font-Size="14px" />                    --%>


                                          <asp:BoundField DataField="Project_Title" HeaderText="Project Title" ItemStyle-Font-Size="14px" />
                                        <asp:BoundField DataField="Head" HeaderText="Head" ItemStyle-Font-Size="14px" />


                                        <asp:TemplateField HeaderText="Action">
                                            <HeaderStyle Width="160px" />
                                            <ItemTemplate>
                                                <%--<a href='Institute_Approval_PreProcessing.aspx?FY=<%# Eval("Financial_Year")%>&Department_Id=<%# Eval("Department_Id")%>&Main_Head=<%# Eval("Main_Head")%>&Head=<%# Eval("Head")%>&Sub_Head=<%# Eval("Sub_Head")%>'><b>Create Approval</b></a>--%>
                                                <a href='Approved_Budget_Individual.aspx?FY=<%# Eval("Financial_Year")%>&Department_Id=<%# Eval("Department_Id")%>&Head=<%# Eval("Head")%>'><b>View Approved Budget</b></a>
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

