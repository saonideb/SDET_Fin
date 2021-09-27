<%@ Page Language="VB" MasterPageFile="~/Director/MasterLayout.master" AutoEventWireup="false" CodeFile="View_Attendance_Report.aspx.vb" Inherits="Director_View_Attendance_Report" title="Employee Attendance Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
	 $(document).ready(function(){	
	 
//	 
//	    $("#tr_sdate").hide();
//	    $("#tr_edate").hide();
//	    $("#tr_emp_name").hide();
//	 
//	    $('#<%=ddl_report_category.ClientID %>').change(function () {
//	
//	    var selectedValue = $('#<%=ddl_report_category.ClientID %>').val();
//	    if(selectedValue  == 0) 
//	        {
//                $("#tr_sdate").hide();
//	            $("#tr_edate").hide();
//	            $("#tr_emp_name").hide();
//            }
//		 
//	 $('#ddl_report_category').change(function()	 {
//	
//	if (this.value ==0) 
//	 {
//	    $('#tr_sdate').hide();
//	    $('#tr_edate').hide();
//	    $('#tr_emp_name').hide();
//	 }
//	 else if (this.value =='All Employees') 
//	 {
//	    $("#tr_sdate").hide();
//	    $("#tr_edate").hide();
//	   	$("#tr_emp_name").show();
//	 }

}
	 //});
 //});
</script>

<div align="center">
<table border="0"  cellpadding="0"  align ="center"cellspacing="0" style="width: 788px;">
    <tbody>
    <tr valign="top">
    <td class="head_already" width="100%" style="height: 20px; margin-right:150px">
        <div align="center" ><u>View Attendance Reports</u>
        </div>
    </td>
    </tr></tbody></table><br />
    
     <table border="0" class="body_txt_in" cellpadding="0" cellspacing="0" style="width: 610px; height: 100%; border: 1px solid #4a9ace">
                <tbody>
                    <tr>
			            <td colspan="6" style="background-color: #4a9ace; height: 22px;">
			            <div class="boxHead">    
			            <div class="heading">View Attendance Reports</div>
			            </div>
			            </td>
			        </tr>
			        
			        <tr>
			            <td colspan="3" style="height: 10px;">
			           	</td>
			        </tr>
			        
			         <tr>
                        <td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong> Report Category</strong></td>
                        <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
                        <td align="left"style="height: 30px; width: 323px;">&nbsp;&nbsp; 
                        <asp:DropDownList ID="ddl_report_type" runat="server" Style="position: static" Font-Bold="False" Width="192px" TabIndex="1" CssClass="select" AutoPostBack="True">
                        <asp:ListItem Value="0">------Please Select Option------</asp:ListItem>
                        <asp:ListItem Value="1">Date Wise Report</asp:ListItem>
                        <asp:ListItem Value="2">Month Wise Report</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddl_report_type"
                        ErrorMessage="Please Select Option" InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
			        
			          <div id="div_report_category" runat="server" visible="false">
			         <tr>
			                	<td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong> Search
                                    Category</strong></td>
			                    <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
			                    <td align="left"style="height: 30px; width: 323px;">&nbsp;&nbsp; 
                                   <asp:DropDownList ID="ddl_report_category" runat="server" Style="position: static" Font-Bold="False" Width="192px" TabIndex="1" CssClass="select" AutoPostBack="True">
                            <asp:ListItem Value="0">------Please Select Option------</asp:ListItem>
                            <asp:ListItem Value="1">All Employees</asp:ListItem>
                            <asp:ListItem Value="2">Individual Employee</asp:ListItem>
                            </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_report_category"
                                        ErrorMessage="Please Select Option" InitialValue="0"></asp:RequiredFieldValidator></td>
        			        </tr></div>
        			        
        			 <div id="div_month_Wise_Categogy" runat="server" visible="false">
			         <tr>
			                	<td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong> Search
                                    Category1</strong></td>
			                    <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
			                    <td align="left"style="height: 30px; width: 323px;">&nbsp;&nbsp; 
                                    <asp:DropDownList ID="ddl_month_report_category" runat="server" Style="position: static" Font-Bold="False" Width="192px" TabIndex="1" CssClass="select" AutoPostBack="True">
                                    <asp:ListItem Value="0">------Please Select Option------</asp:ListItem>
                                    <asp:ListItem Value="1">All Employees</asp:ListItem>
                                    <asp:ListItem Value="2">Individual Employee</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_month_report_category"
                                    ErrorMessage="Please Select Option" InitialValue="0"></asp:RequiredFieldValidator></td>
        			  </tr>
        			  </div>
			        
			        <div id="tr_sdate" runat="server" visible="false">
        			<tr>
			                	<td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong>Start Date</strong></td>
			                    <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
			                    <td align="left"style="height: 30px; width: 323px;">&nbsp;&nbsp; 
                                    <asp:TextBox ID="Sdate" runat="server" TabIndex="4" Width="119px" CssClass="select"></asp:TextBox>
                         <a  href="javascript:NewCal('<%=Sdate.ClientID%>','ddmmmyyyy')"><img alt="" src="../Images/cal.gif"  /></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Edate"
                            ErrorMessage="Please Enter Start Date"></asp:RequiredFieldValidator></td>
        			        </tr></div>
        			 <div id="tr_edate" runat="server" visible="false"> 
        			 <tr >
			                	<td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong>End Date</strong></td>
			                    <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
			                    <td align="left"style="height: 30px; width: 323px;">&nbsp;&nbsp; 
                                 <asp:TextBox ID="Edate" runat="server" TabIndex="4" Width="119px" CssClass="select"></asp:TextBox>
                         <a  href="javascript:NewCal('<%=Edate.ClientID%>','ddmmmyyyy')"><img alt="" src="../Images/cal.gif"  /></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Edate"
                            ErrorMessage="Please Enter End Date"></asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;</td>
        			   </tr> 
        			   </div> 
        			      
        			       <div id="tr_btn" runat="server" visible="false"> 
                          
        			         <tr>
			                	<td style="height: 30px; width: 165px; text-align:left;"></td>
			                    <td style="height: 30px; width: 19px; text-align:left;"></td>
			                    <td align="left"style="height: 30px; width: 323px;">
                                 &nbsp; &nbsp;<asp:Button ID="btn_search_all" runat="server" Font-Bold="True" Text="Submit" Width="81px" /></td>
        			        </tr> 
                                 </div>        
                                    
        			        
        			        
        			        
        			  <div id="tr_emp_name" runat="server" visible="false">       
        			      
        			  <tr>
			                	<td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong>Select
                                    Employee Name</strong></td>
			                    <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
			                    <td align="left"style="height: 30px; width: 323px;">&nbsp; &nbsp;<asp:DropDownList ID="ddl_emp_name" runat="server" Style="position: static" Font-Bold="False" Width="338px" TabIndex="1" CssClass="select" AppendDataBoundItems="True">
                            <asp:ListItem Value="-1">--------------------Please Select Employee Name-------------------</asp:ListItem>
                            </asp:DropDownList><br />&nbsp; &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_emp_name"
                            ErrorMessage="Please Select Employee Name" InitialValue="-1"></asp:RequiredFieldValidator><br />
                                   
                                 
                                    &nbsp; &nbsp;<asp:Button ID="btn_single_emp" runat="server" Font-Bold="True" Text="Submit"
                                        Width="81px" /></td>
        			        </tr> 
        			        <tr>
			            <td colspan="3" style="height: 10px;">
			           	</td>
			        </tr>  
        			        </div>
        			 <div id="month_year_div" runat="server" visible="false">  
			         <tr>
			            <td colspan="3" style="height: 10px;">
			           	</td>
			        </tr>   
			       
                    <tr>
                        <td style="height: 20px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong>Month</strong></td>
                        <td style="height: 20px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
                        <td align="left"style="height: 20px; width: 323px;">&nbsp;&nbsp; 
                        <asp:DropDownList ID="ddl_MonthName" runat="server" Style="position: static" Font-Bold="False" Width="154px" TabIndex="1"  AppendDataBoundItems="True" CssClass="select">
                        <asp:ListItem Value="-1">-------Select Month-----------</asp:ListItem>
                        <asp:ListItem Value="January">January</asp:ListItem>
                        <asp:ListItem Value="February">February</asp:ListItem>
                        <asp:ListItem Value="March">March</asp:ListItem>
                        <asp:ListItem Value="April">April</asp:ListItem>
                        <asp:ListItem Value="May">May</asp:ListItem>
                        <asp:ListItem Value="June">June</asp:ListItem>
                        <asp:ListItem Value="July">July</asp:ListItem>
                        <asp:ListItem Value="August">August</asp:ListItem>
                        <asp:ListItem Value="September">September</asp:ListItem>
                        <asp:ListItem Value="October">October</asp:ListItem>
                        <asp:ListItem Value="November">November</asp:ListItem>
                        <asp:ListItem Value="December">December</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddl_MonthName"
                        ErrorMessage="Please Select Month Name" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                     <tr>
			            <td colspan="3" style="height: 10px;">
			           	</td>
			        </tr>
                    
                     <tr>
                        <td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong>Year</strong></td>
                        <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
                        <td align="left"style="height: 30px; width: 323px;">&nbsp;&nbsp; 
                        <asp:DropDownList ID="ddl_Year" runat="server" Style="position: static" Font-Bold="False" Width="154px" TabIndex="3" AppendDataBoundItems="True" CssClass="select" >
                        <asp:ListItem Value="-1">-------Select Year------------</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="ddl_Year"
                        ErrorMessage="Please Select Year" InitialValue="-1">
                       </asp:RequiredFieldValidator>
                          
                       
                       </td>
                    </tr>
                    
                     <div id="div_month_view_emp_name" runat="server" visible="false">       
        			  <tr>
                            <td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;<strong>Select
                            Employee Name</strong></td>
                            <td style="height: 30px; width: 19px; text-align:left;">&nbsp;&nbsp;<strong>:</strong></td>
                            <td align="left"style="height: 30px; width: 323px;">&nbsp; &nbsp;<asp:DropDownList ID="ddl_emp_name_month_view" runat="server" Style="position: static" Font-Bold="False" Width="338px" TabIndex="1" CssClass="select" AppendDataBoundItems="True">
                            <asp:ListItem Value="-1">--------------------Please Select Employee Name-------------------</asp:ListItem>
                            </asp:DropDownList><br />&nbsp; &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddl_emp_name_month_view"
                            ErrorMessage="Please Select Employee Name" InitialValue="-1"></asp:RequiredFieldValidator><br />
                            </td>  
                       </tr> 
        			   </div>

			        <tr>
                        <td style="height: 30px; width: 165px; text-align:left;">&nbsp;&nbsp;</td>
                        <td style="height: 30px; width: 19px; text-align:left;">&nbsp;</td>
                        <td align="left"style="height: 30px; width: 323px;">&nbsp;&nbsp; 
                        <asp:Button ID="btn_submit_month_data" runat="server" Text="Submit" Font-Bold="True" /> 
                        <asp:Button ID="btn_submit_month_data_all_emp" runat="server" Text="Submit" Font-Bold="True" />
                           
                        </td>
                    </tr>
                    </div>
			     </tbody>
			    </table>        
    <br />
    </div>
   
   
   
   <div id="attendance_all_emp_results" runat="server" visible="false">
         <table border="0" class="body_txt_in"  align ="center"  cellspacing="0" style="width: 80%; height: 100%">
        <tbody>
            <tr valign="top">
                <td class="head_already" width="100%" style="height: 20px; margin-right:150px">
                    <div align="center" > 
                        <span style="color: #990000">Employee Attendance Report from
                            <asp:Label ID="lbl_startdate" runat="server"  Text="From"></asp:Label>
                            - <asp:Label ID="lbl_enddate" runat="server"  Text="To"></asp:Label><br />
                          </span>
                     </div>
                </td>
            </tr>
    
             <tr style="height:10px"></tr>
             <tr>
                    <td style="height: 30px; text-align: center;" colspan="3" >
                     <div align="center"> 
                        <asp:GridView ID="dg1" runat="server" Width="95%"  DataSourceID="Attendance_DS_All_Emp" AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" PageSize="100" >
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                 <%#Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <HeaderStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                             <asp:BoundField DataField="PSRNo" HeaderText="PSR No." />
                            <asp:BoundField DataField="Attendance_Date" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}"  HtmlEncode="False" />
                            <asp:BoundField DataField="Attendance_Time" HeaderText="Time" DataFormatString="{0:hh:mm:ss tt}" HtmlEncode="False" />
                            <asp:BoundField DataField="Attendance_Day" HeaderText="Day" />
                            <asp:BoundField DataField="Attendance_Status" HeaderText="Status" />
                            <asp:BoundField DataField="Attendance_Month" HeaderText="Month" />
                          </Columns>
                        <EmptyDataTemplate>No records found.</EmptyDataTemplate>
                        <RowStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"  />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" BorderWidth="1px" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#404040" BorderWidth="1px" Font-Bold="True" ForeColor="Red" />
                        </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr style="height:20px"></tr>
                <tr style="height:30px">
                 <td style="height: 30px;" colspan="2">
                 <div align="right">
                    <asp:Button ID="btn_Export_Excel" runat="server" Text="Save As Excel" Font-Bold="True" />
                </div>
                </tr>
                 
        </tbody>
        </table> 
       </div><br />
       
       <div id="attendance_individual_emp_results" runat="server" visible="false">
         <table border="0" class="body_txt_in"  align ="center"  cellspacing="0" style="width: 80%; height: 100%">
        <tbody>
            <tr valign="top">
                <td class="head_already" width="100%" style="height: 20px; margin-right:150px">
                    <div align="center" > 
                        <span style="color: #990000">Employee Attendance Report from
                            <asp:Label ID="lbl_start_date" runat="server"  Text="From"></asp:Label>
                            - <asp:Label ID="lbl_end_date" runat="server"  Text="To"></asp:Label><br />
                          </span>
                     </div>
                </td>
            </tr>
    
             <tr style="height:10px"></tr>
             <tr>
                    <td style="height: 30px; text-align: center;" colspan="3" >
                     <div align="center"> 
                        <asp:GridView ID="Dg2" runat="server" Width="95%"  DataSourceID="Attendance_DS_Single_Emp" AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" PageSize="100" >
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                 <%#Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <HeaderStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                             <asp:BoundField DataField="PSRNo" HeaderText="PSR No." />
                            <asp:BoundField DataField="Attendance_Date" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}"  HtmlEncode="False" />
                            <asp:BoundField DataField="Attendance_Time" HeaderText="Time" DataFormatString="{0:hh:mm:ss tt}" HtmlEncode="False" />
                            <asp:BoundField DataField="Attendance_Day" HeaderText="Day" />
                            <asp:BoundField DataField="Attendance_Status" HeaderText="Status" />
                            <asp:BoundField DataField="Attendance_Month" HeaderText="Month" />
                        </Columns>
                        <EmptyDataTemplate>No records found.</EmptyDataTemplate>
                        <RowStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"  />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" BorderWidth="1px" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#404040" BorderWidth="1px" Font-Bold="True" ForeColor="Red" />
                        </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr style="height:20px"></tr>
                <tr style="height:30px">
                 <td style="height: 30px;" colspan="2">
                 <div align="right">
                    <asp:Button ID="btn_export_single_data" runat="server" Text="Save As Excel" Font-Bold="True" />
                </div>
                </tr>
                 
        </tbody>
        </table> 
       </div><br />
       
       <div id="div_Month_Wise_All_Employess_Data" runat="server" visible="false">
         <table border="0" class="body_txt_in"  align ="center"  cellspacing="0" style="width: 80%; height: 100%">
        <tbody>
            <tr valign="top">
                <td class="head_already" width="100%" style="height: 20px; margin-right:150px">
                    <div align="center" > 
                        <span style="color: #990000">Employee Attendance Report for
                            <asp:Label ID="lbl_month_wise_month_name" runat="server"  Text="From"></asp:Label>
                            ,<asp:Label ID="lbl_month_wise_year_name" runat="server"  Text="To"></asp:Label><br />
                          </span>
                     </div>
                </td>
            </tr>
    
             <tr style="height:10px"></tr>
             <tr>
                    <td style="height: 30px; text-align: center;" colspan="3" >
                     <div align="center"> 
                        <asp:GridView ID="DG_Month_Wise_All_Employee" runat="server" Width="95%"   AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" PageSize="100" >
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                 <%#Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <HeaderStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                             <asp:BoundField DataField="PSRNo" HeaderText="PSR No." />
                            <asp:BoundField DataField="Attendance_Date" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}"  HtmlEncode="False" />
                            <asp:BoundField DataField="Attendance_Time" HeaderText="Time" DataFormatString="{0:hh:mm:ss tt}" HtmlEncode="False" />
                            <asp:BoundField DataField="Attendance_Day" HeaderText="Day" />
                            <asp:BoundField DataField="Attendance_Status" HeaderText="Status" />
                            <asp:BoundField DataField="Attendance_Month" HeaderText="Month" />
                        </Columns>
                        <EmptyDataTemplate>No records found.</EmptyDataTemplate>
                        <RowStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"  />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" BorderWidth="1px" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#404040" BorderWidth="1px" Font-Bold="True" ForeColor="Red" />
                        </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr style="height:20px"></tr>
                <tr style="height:30px">
                 <td style="height: 30px;" colspan="2">
                 <div align="right">
                    <asp:Button ID="btn_month_wise_all_emp_report" runat="server" Text="Save As Excel" Font-Bold="True" />
                </div>
                </tr>
                 
        </tbody>
        </table> 
       </div><br />
       
        
        
        <asp:SqlDataSource ID="Attendance_DS_All_Emp" runat="server"  ConnectionString="<%$ ConnectionStrings:ConnectionStringName %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionStringName.ProviderName %>" 
        SelectCommand="SELECT * FROM [Attendance_Records] WHERE ([Reporting_Incharge_PsrNo] =  @Reporting_Incharge_PsrNo AND [Attendance_Date] Between  @Startdate AND  @Enddate) ORDER BY Attendance_Date,PSRNo">
        <SelectParameters>
        <asp:sessionparameter name="Reporting_Incharge_PsrNo" sessionfield="user_psrno" Type="String" />
        <asp:sessionparameter Name="Startdate" Sessionfield="Sdate" Type="String" />
            <asp:sessionparameter Name="Enddate" Sessionfield="Edate" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource><br />
         
        <asp:SqlDataSource ID="Attendance_DS_Single_Emp" runat="server"  ConnectionString="<%$ ConnectionStrings:ConnectionStringName %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionStringName.ProviderName %>" 
        SelectCommand="SELECT * FROM [Attendance_Records] WHERE ([psrno] =  @user_psrno AND [Attendance_Date] Between  @Start_date AND  @End_date) ORDER BY Attendance_Date">
        <SelectParameters>
        <asp:sessionparameter name="user_psrno" sessionfield="Employee_Psrno" Type="String" />
        <asp:sessionparameter Name="Start_date" Sessionfield="Start_date" Type="String" />
         <asp:sessionparameter Name="End_date" Sessionfield="End_date" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>





















