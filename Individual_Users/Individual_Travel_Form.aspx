<%@ Page Title="" Language="C#" MasterPageFile="~/Individual_Users/MasterPage.master" AutoEventWireup="true" CodeFile="Individual_Travel_Form.aspx.cs" Inherits="Individual_Users_Individual_Travel_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script type="text/javascript">
         function confirmation() {

             //alert(i);
             var x;

             x = "Are you sure to proceed?";


             if (confirm(x)) {
                 return true;
             } else {
                 return false;
             }

         }



    </script>

    <script type="text/javascript" src="Signature/flashcanvas.js"></script>
    <script type="text/javascript" src="Signature/jSignature.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#signature").jSignature({ width: 450, height: 150, color: "#f00" });

        });
        function Reset() {
            var $sigdiv = $("#signature");
            //      $sigdiv.jSignature();
            $sigdiv.jSignature("reset")
        }
        function GetData() {
            var $sigdiv = $("#signature");
            var datapair = $sigdiv.jSignature("getData", "svgbase64")
            var image = document.getElementById("Image1");

            image.src = "data:" + datapair[0] + "," + datapair[1]
            var hiddenfield = $("#HiddenField1");
            hiddenfield.val("data:" + datapair[0] + "," + datapair[1]);

        }
    </script>

     <script language="javascript" type="text/javascript">
         /*Accept Only Integer In TextBOX*/
         function fnAllowNumeric() {
             if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode != 8) {
                 event.keyCode = 0;
                 /*alert("Accept only Integer..!");*/
                 return false;
             }
         }
    </script>
  

    <!--Amount in words-->
    <script>
        function convertNumberToWords(amount) {
            var words = new Array();
            words[0] = '';
            words[1] = 'One';
            words[2] = 'Two';
            words[3] = 'Three';
            words[4] = 'Four';
            words[5] = 'Five';
            words[6] = 'Six';
            words[7] = 'Seven';
            words[8] = 'Eight';
            words[9] = 'Nine';
            words[10] = 'Ten';
            words[11] = 'Eleven';
            words[12] = 'Twelve';
            words[13] = 'Thirteen';
            words[14] = 'Fourteen';
            words[15] = 'Fifteen';
            words[16] = 'Sixteen';
            words[17] = 'Seventeen';
            words[18] = 'Eighteen';
            words[19] = 'Nineteen';
            words[20] = 'Twenty';
            words[30] = 'Thirty';
            words[40] = 'Forty';
            words[50] = 'Fifty';
            words[60] = 'Sixty';
            words[70] = 'Seventy';
            words[80] = 'Eighty';
            words[90] = 'Ninety';
            amount = amount.toString();
            var atemp = amount.split(".");
            var number = atemp[0].split(",").join("");
            var n_length = number.length;
            var words_string = "";
            if (n_length <= 9) {
                var n_array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
                var received_n_array = new Array();
                for (var i = 0; i < n_length; i++) {
                    received_n_array[i] = number.substr(i, 1);
                }
                for (var i = 9 - n_length, j = 0; i < 9; i++, j++) {
                    n_array[i] = received_n_array[j];
                }
                for (var i = 0, j = 1; i < 9; i++, j++) {
                    if (i == 0 || i == 2 || i == 4 || i == 7) {
                        if (n_array[i] == 1) {
                            n_array[j] = 10 + parseInt(n_array[j]);
                            n_array[i] = 0;
                        }
                    }
                }
                value = "";
                for (var i = 0; i < 9; i++) {
                    if (i == 0 || i == 2 || i == 4 || i == 7) {
                        value = n_array[i] * 10;
                    } else {
                        value = n_array[i];
                    }
                    if (value != 0) {
                        words_string += words[value] + " ";
                    }
                    if ((i == 1 && value != 0) || (i == 0 && value != 0 && n_array[i + 1] == 0)) {
                        words_string += "Crores ";
                    }
                    if ((i == 3 && value != 0) || (i == 2 && value != 0 && n_array[i + 1] == 0)) {
                        words_string += "Lakhs ";
                    }
                    if ((i == 5 && value != 0) || (i == 4 && value != 0 && n_array[i + 1] == 0)) {
                        words_string += "Thousand ";
                    }
                    if (i == 6 && value != 0 && (n_array[i + 1] != 0 && n_array[i + 2] != 0)) {
                        words_string += "Hundred and ";
                    } else if (i == 6 && value != 0) {
                        words_string += "Hundred ";
                    }
                }
                words_string = words_string.split("  ").join(" ");
            }
            return words_string;
        }
    </script>

    <style>
        .disable_button {
            height: 30px;
            width: 210px;
            font-weight: bold;
        }
    </style>



    <script>

        $(document).ready(function () {
            $("#signature").jSignature({
                'background-color': 'transparent',
                'decor-color': 'transparent',
            });
        });
    </script>

    <script type="text/javascript">
        function intOnly(i) {
            if (i.value.length > 0) {
                i.value = i.value.replace(/[^\d]+/g, '');
            }
        }
    </script>

    <script type="text/javascript">
        $('#clear').click(function () {
            $('#signature').jSignature("reset");
        });

    </script>

    <script type="text/javascript">
        function Replace_SpecialChars(i) {
            if (i.value.length > 0) {
                i.value = i.value.replace(/[#'^&"]/g, '');
            }
        }
    </script>

    <script type="text/javascript">

        function validateLimit(obj, divID, maxchar) {
            objDiv = get_object(divID);
            if (this.id) obj = this;
            var remaningChar = maxchar - obj.value.length;
            if (objDiv) {
                objDiv.innerHTML = remaningChar + " Characters Left";
            }
            if (remaningChar <= 0) {

                obj.value = obj.value.substring(maxchar, 0);

                if (objDiv) {
                    objDiv.innerHTML = "0 Characters Left";
                }
                return false;
            }
            else {
                return true;
            }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            }
            else if (document.all) {
                object = document.all[id];
            }
            else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }
    </script>

    <style>
        textarea {
            resize: none;
        }

        .auto-style1 {
            color: #FF0000;
        }
    </style>

    <style>
        .txt {
            border: 1px solid black;
            padding: 4px;
            color: #333333;
            font-size: 14px;
            background-color: #ffffff;
        }

            .txt:hover {
                background-color: #fff4d8;
            }
    </style>

    <div align="center">
        <table border="0" id="table_user_details" cellpadding="0" width="80%" cellspacing="0">
            <tbody>
                <tr valign="top">
                    <td class="head_already" style="height: 30px">
                        <div style="text-align: center">
                            <span>&nbsp;<span style="text-decoration: none"></span></span>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />

        <asp:Panel ID="Panel1" runat="server">
            <table border="0" class="body_txt_in" cellpadding="0" cellspacing="0" style="width: 90%; height: 55px; border: 1px solid black">
                <tbody>
                    <%-- <tr>
			            <td colspan="3" style="background-color: #4a9ace; height: 22px;">
			            <div class="boxHead">    
			            <div class="heading">Form-A</div>
			            </div>
			            </td>
			        </tr>--%>

                    <tr>
                        <td colspan="3" style="height: 30px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="right" style="margin-right: 20px">
                                <span style="font-size: 16px; color: black"><strong>TRAVEL</strong></span>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center">
                            <div>
                                <span style="font-size: 20px; color: black"><strong>BIRLA INSTITUTE OF TECHNOLOGY AND SCIENCE, PILANI</strong></span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center">
                            <div>
                                <span style="font-size: 14px; color: black"><strong>SPONSORED RESEARCH AND CONSULTANCY DIVISION</strong></span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;" align="center">
                            <div>
                                <span style="font-size: 12px; color: black"><strong>(Approval Form for Travel under Funded Projects)</strong></span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="right" style="margin-right: 20px">
                                <asp:Label ID="lbl_date_heading" runat="server" Font-Size="13px" Text="Date:" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lbl_current_date" runat="server" Font-Size="13px" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="right" style="margin-right: 20px">
                                <asp:Label ID="Label1" runat="server" Font-Size="13px" Text="Department :" Font-Bold="true"></asp:Label>
                                &nbsp;
                               <asp:Label ID="Lbl_Name_Department_PI" runat="server" ForeColor="darkred" Font-Bold="true" Font-Size="13px" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>


                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Name of the User:</strong>
                                &nbsp;
                              <asp:Label ID="lbl_user_name" runat="server" ForeColor="darkred" Font-Bold="true" Font-Size="13px" Text="Head Name"></asp:Label>
                            </div>
                        </td>
                    </tr>



                    <tr>
                        <td colspan="3" style="height: 25px;" align="center"></td>
                    </tr>


                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                 <strong>Project Title : </strong>
                                <asp:Label ID="Lbl_Project_No" runat="server" ForeColor="darkred" Font-Bold="true" Font-Size="13px"></asp:Label>,
                                <asp:Label ID="Lbl_Funding_Agency" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="darkred" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="3" style="height: 15px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                              <strong>Project Budget Head/Sub Head: </strong>
                                <asp:Label ID="txt_Project_Title" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="darkred" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="3" style="height: 15px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Budget Head Balance Amount:</strong>
                                &nbsp;
                             <asp:Label ID="lbl_budget_head_balance_amount" runat="server" ForeColor="green" Font-Bold="true" Font-Size="16px"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="left" style="margin-left: 20px">
                                <table id="Table3" class="body_txt_in" style="border: 1px solid Black; width: 25%; border-collapse: collapse;" cellspacing="0" cellpadding="6">
                                    <tbody>

                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Project Start Date</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Project End Date</strong></span></td>
                                        </tr>

                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse">
                                                <asp:TextBox ID="txt_StartDate" runat="server" autocomplete="off" CssClass="txt" Style="position: static" Height="24px" TextMode="Date" Width="250px" MaxLength="5000"></asp:TextBox>
                                                <asp:RequiredFieldValidator  ID="rq1" runat="server" ControlToValidate="txt_StartDate" ValidationGroup="Travel" ErrorMessage="_Blank" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <asp:TextBox ID="txt_End_Date" runat="server" autocomplete="off" CssClass="txt" Font-Bold="true" ForeColor="Black" Font-Size="12px" TextMode="Date" Width="250px" Height="24px"></asp:TextBox>
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_End_Date" ValidationGroup="Travel" ErrorMessage="_Blank" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </td>
                    </tr>



                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Name and Designation of travelling person(s):</strong>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                    <!---Items Gridview-->
                    <div id="div_item_details" runat="server" visible="true">

                        <tr>
                            <td colspan="3">
                                <div align="left" style="margin-left: 20px">
                                    <asp:GridView Visible="false" ID="DG1" runat="server" Width="90%" AutoGenerateColumns="False" ShowFooter="true" CellSpacing="4" CellPadding="6" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px">
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="0px" Font-Bold="True" ForeColor="Red" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <HeaderStyle Width="10px" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Record_Id" HeaderText="Record Id" Visible="False" />
                                            <asp:BoundField DataField="Reference_No" HeaderText="Reference No" Visible="False" />
                                            <asp:BoundField DataField="Item_Cost" HeaderText="Approx. Total Cost (in Rs.)" Visible="False" />
                                            <asp:BoundField DataField="Item_Description" HeaderText="Description of Item(s)" HtmlEncode="False" ItemStyle-Width="193px" />
                                            <asp:BoundField DataField="Item_Quantity" HeaderText="Quantity" HtmlEncode="False" ItemStyle-Width="110px" />
                                            <asp:TemplateField HeaderText="Approx. Total Cost (in Rs.)" ItemStyle-Font-Bold="true">
                                                <HeaderStyle Width="180px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_item_amount" runat="server" Text="" Font-Size="13px" ForeColor="blue" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <div align="center">
                                                        <asp:Label ID="lbl_total_amount" runat="server" Text="Total Amount:" ForeColor="black" Font-Size="12px" />
                                                        <asp:Label ID="lbl_items_total_amount" runat="server" ForeColor="green" Font-Size="12px" />
                                                    </div>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <HeaderStyle Width="110px" />
                                                <ItemTemplate>
                                                    <a href="Individual_Approval_Delete_Items_Equipment.aspx?Record_Id=<%# Eval("Record_Id")%>&Reference_No=<%# Eval("Reference_No")%>" onclick="return confirm('Are you sure you want to delete this item?')"><span style="font-size: 13px"><b>Delte Item</b></span></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BorderColor="#CCCCCC" BackColor="WhiteSmoke" Font-Bold="True" Font-Size="Medium" BorderStyle="Solid" BorderWidth="1px"></PagerStyle>
                                        <EmptyDataTemplate>Please Add Your Educational Qualifications</EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#CCCCCC" BorderWidth="1px" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="Black" />
                                        <AlternatingRowStyle BackColor="White" HorizontalAlign="center" VerticalAlign="middle" />
                                    </asp:GridView>

                                    <asp:GridView ID="grd_Travel_details" runat="server" ShowFooter="True" ShowHeaderWhenEmpty="true" Width="50%"
                                        HeaderStyle-Font-Size="11px" RowStyle-Font-Size="11px" Style="letter-spacing: 1px;"
                                        OnRowDataBound="grd_Travel_details_RowDataBound" OnRowDeleting="grd_Travel_details_RowDeleting" AutoGenerateColumns="False" CellPadding="4" CellSpacing="2"
                                        ForeColor="#333333" GridLines="Both" Font-Names="arial" Font-Size="12px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="RowNumber" HeaderText="S.NO" Visible="false" />
                                            <asp:TemplateField HeaderText="Name and Designation">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_Name_and_Designation" runat="server" Text='<%#Eval("txt_Name_and_Designation") %>' CssClass="txt" Style="position: static" Height="40px" TextMode="MultiLine" Width="600px" MaxLength="5000" ></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txt_Name_and_Designation"
                                                        ErrorMessage="Enter Name and Designation" ValidationGroup="lab11" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Name_and_Designation" ValidationGroup="Travel" ErrorMessage="_Blank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:Button ID="ButtonAdd" runat="server" Width="140px" Height="28px" TabIndex="5" Text="Add More" 
                                                        OnClick="ButtonAdd_Click" ValidationGroup="lab11" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowDeleteButton="True" />
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="Black" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </div>

                            </td>
                        </tr>

                        <tr>
                            <td colspan="3" style="height: 15px;"></td>
                        </tr>

                    </div>

                    <tr style="display: none;">
                        <td colspan="3">
                            <div align="left" style="margin-left: 20px">
                                <table id="course_details_table" class="body_txt_in" style="border: 1px solid Black; border-collapse: collapse; width: 50%" cellspacing="0" cellpadding="6">

                                    <tbody>

                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Name and Designation</strong></span></td>
                                            <%-- <td style="border:1px solid Black;border-collapse:collapse"><span style="font-size:12px;color:black"><strong>Quantity</strong></span></td>
                                    <td style="border:1px solid Black;border-collapse:collapse"><span style="font-size:12px;color:black"><strong>Approx. Total Cost (in Rs.)</strong></span></td>--%>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong></strong></span></td>
                                        </tr>

                                        <tr align="center" style="height: 50px; width: 300px">
                                            <td style="border: 1px solid Black; border-collapse: collapse">
                                                <asp:TextBox ID="txt_item_description" runat="server" autocomplete="off" CssClass="txt" Style="position: static" Height="40px" TextMode="MultiLine" Width="600px" MaxLength="5000" ></asp:TextBox>
                                            </td>

                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 180px; vertical-align: top; margin-top: 2px">
                                                <asp:Button ID="btn_add_items" runat="server" Width="140px" Height="28px" TabIndex="5" Text="Save and Add More"  />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </td>
                    </tr>



                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>


                    <tr>
                        <td colspan="3">
                            <div align="left" style="margin-left: 20px">
                                <table id="Table1" class="body_txt_in" style="border: 1px solid Black; border-collapse: collapse; width: 90%" cellspacing="0" cellpadding="6">

                                    <tbody>

                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Place(s) to be visited along with dates</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Purpose of Visit</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Type of Leave applied for</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Mode of Travel</strong></span></td>
                                        </tr>

                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse">
                                                <asp:TextBox ID="txt_Place_Visited" runat="server" autocomplete="off" CssClass="txt" Style="position: static" Height="24px" TextMode="MultiLine" Width="250px" MaxLength="5000"></asp:TextBox>
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Place_Visited" ValidationGroup="Travel" ErrorMessage="_Blank" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <asp:TextBox ID="txt_Purpose_visit" runat="server" autocomplete="off" CssClass="txt" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px"></asp:TextBox>
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Purpose_visit" ValidationGroup="Travel" ErrorMessage="_Blank" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>

                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">

                                                <asp:TextBox ID="txt_Type_of_Leave" runat="server" autocomplete="off" CssClass="txt" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px"></asp:TextBox>
                                                <div id="word"></div>
                                            </td>

                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">

                                                <asp:TextBox ID="txt_Mode_Of_Travel" runat="server" autocomplete="off" CssClass="txt" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </td>
                    </tr>



                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Estimated Expenditure</strong>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="left" style="margin-left: 20px">
                                <table id="Table2" class="body_txt_in" style="border: 1px solid Black; border-collapse: collapse; width: 90%" cellspacing="0" cellpadding="6">

                                    <tbody>
                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Road/Rail Fare</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Air Fare</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Local Journey</strong></span></td>
                                        </tr>

                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse;width: 250px;">
                                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                                <asp:TextBox ID="txt_rail_fare" runat="server" autocomplete="off" onkeypress="return fnAllowNumeric();" CssClass="txt_rail_fare txt" Style="position: static" Height="24px" Width="250px" MaxLength="5000" ></asp:TextBox>
                                            </td>
                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                                <asp:TextBox ID="txt_Air_fare" runat="server" autocomplete="off" onkeypress="return fnAllowNumeric();" CssClass="txt" MaxLength="5" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" ></asp:TextBox>
                                            </td>

                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                                <asp:TextBox ID="txt_Local_Journey" runat="server" autocomplete="off" onkeypress="return fnAllowNumeric();" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px"></asp:TextBox>
                                                <div id="Div2"></div>
                                            </td>
                                        </tr>

                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Accommodation</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Food Expenses</strong></span></td>
                                            <td></td>
                                        </tr>
                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 14px; color: black"><strong>Rs.</strong></span>@<asp:TextBox ID="txt_Accommodation_Rate" onkeypress="return fnAllowNumeric();" runat="server" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="50px" Height="18px"></asp:TextBox> &nbsp;for &nbsp;
                    <asp:TextBox ID="txt_Accommodation_Day" onkeypress="return fnAllowNumeric();" runat="server" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="25px" Height="18px"></asp:TextBox>days = Rs.
                    <asp:TextBox ID="txt_Accommodation_Total_Amount" runat="server" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="80px" Height="18px" onkeypress="return fnAllowNumeric();" ></asp:TextBox></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 14px; color: black"><strong>Rs.</strong></span>@ 
                    <asp:TextBox ID="txt_Food_Rate" onkeypress="return fnAllowNumeric();" runat="server" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="50px" Height="18px"></asp:TextBox> &nbsp;for &nbsp;<asp:TextBox ID="txt_Food_Day" runat="server" onkeypress="return fnAllowNumeric();" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="25px" Height="18px"></asp:TextBox>days = Rs. 
                    <asp:TextBox ID="txt_Food_Expenses_total_Amount" runat="server" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="80px" Height="18px" onkeypress="return fnAllowNumeric();" ></asp:TextBox></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                    <tr>
                        <td style="height: 15px; width: 200px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Registration fee (if applicable)(apply under contingency head)</strong>
                            </div>
                        </td>
                        <td style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                <asp:TextBox ID="txt_Registration_fee" runat="server" onkeypress="return fnAllowNumeric();" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px"  Enabled="false"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                    <tr>
                        <td style="height: 15px;width: 200px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Total:</strong>
                            </div>
                        </td>
                        <td style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                <asp:TextBox ID="txt_total_Amount" runat="server" autocomplete="off" CssClass="txt" MaxLength="10" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" onkeypress="return fnAllowNumeric();" ></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>

                      <tr>
			            <td colspan="3" style=" height: 15px;"">
                        <div align="left" style="margin-left:20px" >
                            <strong>Justification:</strong>
                        </div>
			            </td>
			        </tr>
                    
                     <tr>
			            <td colspan="3" style=" height: 5px;">

			            </td>
			        </tr>

                     <tr>
			            <td colspan="3">
                           <div align="left" style="margin-left:20px" >
                               <table>
                                   <tr>
                                       <td>
                                           <asp:TextBox ID="txt_justification" runat="server"  autocomplete="off" CssClass="txt" Style="position: static"  Height="120px" TextMode="MultiLine" Width="1100px" MaxLength="5000" onChange="Replace_SpecialChars(this);"  onKeyPress="Replace_SpecialChars(this);" onkeydown="Replace_SpecialChars(this);"></asp:TextBox>
                                       </td>
                                   </tr>

                               </table>


                            </div>
			            </td>
			        </tr>

                    <!---Items Gridview-->
                    <div id="div3" runat="server" visible="false">

                        <tr>
                            <td colspan="3">
                                <div align="left" style="margin-left: 20px">
                                </div>

                            </td>
                        </tr>

                        <tr>
                            <td colspan="3" style="height: 15px;"></td>
                        </tr>

                    </div>
                    <tr>
                        <td colspan="3" style="height: 15px;"></td>
                    </tr>


                    <%--  <tr>
			            <td colspan="3" style=" height: 15px;">
                            <div id="signature"></div>
                          <button id="clear">Clear</button>
			            </td>
			        </tr>--%>

                    <tr>
                        <td colspan="3">
                            <div align="right" style="margin-right: 110px">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_preview" runat="server" OnClick="btn_preview_Click" Width="160px" Height="28px" ValidationGroup="Travel" Font-Bold="true" Text="Save and Preview"  />
                                        </td>
                                    </tr>

                                </table>


                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 20px;"></td>
                    </tr>


                </tbody>
            </table>
        </asp:Panel>


        <asp:Panel ID="Panel2" runat="server" Visible="false">

            <table border="0" class="body_txt_in" cellpadding="0" cellspacing="0" style="width: 90%; height: 55px; border: 1px solid black;">
                <tbody>


                    <tr>
                        <td colspan="3" style="height: 30px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="right" style="margin-right: 20px">
                                <span style="font-size: 16px; color: black"><strong>TRAVEL</strong></span>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center">
                            <div>
                                <span style="font-size: 20px; color: black"><strong>BIRLA INSTITUTE OF TECHNOLOGY AND SCIENCE, PILANI</strong></span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center">
                            <div>
                                <span style="font-size: 14px; color: black"><strong>SPONSORED RESEARCH AND CONSULTANCY DIVISION</strong></span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;" align="center">
                            <div>
                                <span style="font-size: 12px; color: black"><strong>(Approval Form for Travel under Funded Projects)</strong></span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="right" style="margin-right: 20px">
                                <asp:Label ID="Label2" runat="server" Font-Size="13px" Text="Date:" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lbl_current_date_p" runat="server" Font-Size="13px" Text="Date:"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="right" style="margin-right: 20px">
                                <asp:Label ID="Label4" runat="server" Font-Size="13px" Text="Department :" Font-Bold="true"></asp:Label>
                                &nbsp;
                               <asp:Label ID="Lbl_Name_Department_PI_p" runat="server" Font-Bold="true" ForeColor="black" Font-Size="13px" Text="Department Name"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;" align="center"></td>
                    </tr>


                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Name of the User:</strong>
                                <asp:Label ID="lbl_user_name_P" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="black" Text="Name of the User"></asp:Label>
                            </div>
                        </td>
                    </tr>



                    <tr>
                        <td colspan="3" style="height: 25px;" align="center"></td>
                    </tr>


                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Project Title : </strong>
                                <%--<asp:Label ID="lbl_budget_head_details_p" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="black" Text=""></asp:Label>--%>
                               
                                 <asp:Label ID="Lbl_Project_No_P" runat="server" ForeColor="darkred" Font-Bold="true" Font-Size="13px"></asp:Label>,
                                <asp:Label ID="Lbl_Funding_Agency_P" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="darkred" Text=""></asp:Label>

                            </div>
                        </td>
                    </tr>

                    
                    <tr>
                        <td colspan="3" style="height: 15px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Project Budget Head/Sub Head : </strong>
                                 <asp:Label ID="txt_Project_Title_P" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="darkred" Text=""></asp:Label>
                               
                            </div>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="3" style="height: 15px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Budget Head Balance Amount:</strong>
                                &nbsp;
                             <asp:Label ID="lbl_budget_head_balance_amount_P" runat="server" ForeColor="green" Font-Bold="true" Font-Size="16px" Text="Balance Amount"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="left" style="margin-left: 20px">
                                <table id="Table3" class="body_txt_in" style="border: 1px solid Black; width: 25%; border-collapse: collapse;" cellspacing="0" cellpadding="6">
                                    <tbody>

                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Start Date</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>End Date</strong></span></td>
                                        </tr>

                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse">
                                                <asp:Label ID="txt_StartDate_P" runat="server" autocomplete="off" Font-Bold="true" ForeColor="Black" Style="position: static" Height="24px" TextMode="MultiLine" Width="250px" MaxLength="5000" ></asp:Label>
                                            </td>
                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <asp:Label ID="txt_End_Date_P" runat="server" autocomplete="off"  MaxLength="5" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" ></asp:Label>
                                            </td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </td>
                    </tr>



                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Name and Designation of travelling person(s):</strong>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                    <!---Items Gridview-->
                    <div id="div_item_details_P" runat="server" visible="true">

                        <tr>
                            <td colspan="3">
                                <div align="left" style="margin-left: 20px">
                                    <asp:GridView ID="grd_Travel_details_P" runat="server" ShowFooter="True" ShowHeaderWhenEmpty="true" Width="50%"
                                        HeaderStyle-Font-Size="11px" RowStyle-Font-Size="11px" Style="letter-spacing: 1px;"
                                        AutoGenerateColumns="False" CellPadding="4" CellSpacing="2"
                                        ForeColor="#333333" GridLines="Both" Font-Names="arial" Font-Size="12px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="RowNumber" HeaderText="S.NO" Visible="false" />
                                            <asp:TemplateField HeaderText="Name and Designation">
                                                <ItemStyle VerticalAlign="Top" />
                                                <ItemTemplate>
                                                <asp:Label ID="txt_item_description" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#F4F4F4" Font-Bold="True" ForeColor="Black" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </div>

                            </td>
                        </tr>

                        <tr>
                            <td colspan="3" style="height: 15px;"></td>
                        </tr>

                    </div>


                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>


                    <tr>
                        <td colspan="3">
                            <div align="left" style="margin-left: 20px">
                                <table id="Table1" class="body_txt_in" style="border: 1px solid Black; border-collapse: collapse; width: 90%" cellspacing="0" cellpadding="6">

                                    <tbody>

                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Place(s) to be visited along with dates</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Purpose of Visit</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Type of Leave applied for</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Mode of Travel</strong></span></td>
                                        </tr>

                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse">
                                                <asp:Label ID="txt_Place_Visited_P" runat="server" autocomplete="off" Font-Bold="true" ForeColor="Black"  Style="position: static" Height="24px" TextMode="MultiLine" Width="250px" MaxLength="5000" ></asp:Label>
                                            </td>
                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <asp:Label ID="txt_Purpose_visit_P" runat="server" autocomplete="off"  MaxLength="5" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" ></asp:Label>
                                            </td>

                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">

                                                <asp:Label ID="txt_Type_of_Leave_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" onChange="intOnly(this);" onKeyUp="intOnly(this);word.innerHTML=convertNumberToWords(this.value)" onKeyPress="intOnly(this);"></asp:Label>
                                                <div id="word"></div>
                                            </td>

                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">

                                                <asp:Label ID="txt_Mode_Of_Travel_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" onChange="intOnly(this);" onKeyUp="intOnly(this);word.innerHTML=convertNumberToWords(this.value)" onKeyPress="intOnly(this);"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </td>
                    </tr>



                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Estimated Expenditure</strong>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 25px;"></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div align="left" style="margin-left: 20px">
                                <table id="Table2" class="body_txt_in" style="border: 1px solid Black; border-collapse: collapse; width: 90%" cellspacing="0" cellpadding="6">

                                    <tbody>
                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Road/Rail Fare</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Air Fare</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Local Journey</strong></span></td>
                                        </tr>

                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse">
                                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                                <asp:Label ID="txt_rail_fare_P" runat="server" autocomplete="off" Font-Bold="true"  ForeColor="Black"  Style="position: static" Height="24px" TextMode="MultiLine" Width="250px" MaxLength="5000" ></asp:Label>
                                            </td>
                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                                <asp:Label ID="txt_Air_fare_P" runat="server" autocomplete="off"  MaxLength="5" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" ></asp:Label>
                                            </td>

                                            <td style="border: 1px solid Black; border-collapse: collapse; width: 250px; vertical-align: top; margin-top: 2px">
                                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                                <asp:Label ID="txt_Local_Journey_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" onChange="intOnly(this);" onKeyUp="intOnly(this);word.innerHTML=convertNumberToWords(this.value)" onKeyPress="intOnly(this);"></asp:Label>
                                                <div id="Div2"></div>
                                            </td>
                                        </tr>

                                        <tr align="center" style="background: #F4F4F4">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Accommodation</strong></span></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 12px; color: black"><strong>Food Expenses</strong></span></td>
                                            <td></td>
                                        </tr>
                                        <tr align="center" style="height: 50px;">
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 14px; color: black"><strong>Rs.</strong></span>@<asp:Label ID="txt_Accommodation_Rate_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="25px" Height="18px"></asp:Label>&nbsp;&nbsp;for 
                    <asp:Label ID="txt_Accommodation_Day_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="25px" Height="18px"></asp:Label>days = Rs.
                    <asp:Label ID="txt_Accommodation_Total_Amount_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="50px" Height="18px"></asp:Label></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"><span style="font-size: 14px; color: black"><strong>Rs.</strong></span>@ 
                    <asp:Label ID="txt_Food_Rate_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="25px" Height="18px"></asp:Label>&nbsp;&nbsp;for <asp:Label ID="txt_Food_Day_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="25px" Height="18px"></asp:Label>days = Rs. 
                    <asp:Label ID="txt_Food_Expenses_total_Amount_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="50px" Height="18px"></asp:Label></td>
                                            <td style="border: 1px solid Black; border-collapse: collapse"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Registration fee (if applicable)</strong>
                            </div>
                        </td>
                        <td style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                <asp:Label ID="txt_Registration_fee_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" onChange="intOnly(this);" onKeyUp="intOnly(this);word.innerHTML=convertNumberToWords(this.value)" onKeyPress="intOnly(this);"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <strong>Total:</strong>
                            </div>
                        </td>
                        <td style="height: 15px;">
                            <div align="left" style="margin-left: 20px">
                                <span style="font-size: 14px; color: black"><strong>Rs.</strong></span>
                                <asp:Label ID="txt_total_Amount_P" runat="server" autocomplete="off"  MaxLength="10" TabIndex="4" Font-Bold="true" ForeColor="Black" Font-Size="12px" Width="250px" Height="24px" onChange="intOnly(this);" onKeyUp="intOnly(this);word.innerHTML=convertNumberToWords(this.value)" onKeyPress="intOnly(this);"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                      <tr>
			            <td colspan="3" style=" height: 15px;"">
                        <div align="left" style="margin-left:20px" >
                            <strong>Justification:</strong>
                        </div>
			            </td>
			        </tr>
                     <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                      <tr>
			            <td colspan="3">
                           <div align="left" style="margin-left:20px" >
                               <table>
                                   <tr>
                                       <td>
                                           <div id="justification" runat="server"></div>
                                       </td>
                                   </tr>

                               </table>


                            </div>
			            </td>
			        </tr>
                     <tr>
                        <td colspan="3" style="height: 10px;"></td>
                    </tr>
                      <tr>
                        <td colspan="3">
                            <div>
                                <table>
                                    <tr>
                                        <td width="20%">
                                            <div align="left" style="margin-left: 30px">
                                                <asp:Button ID="btn_edit" runat="server" Width="90px" Height="28px" Font-Bold="true" TabIndex="1" Text="Edit" OnClick="btn_edit_Click"  />
                                            </div>



                                        </td>

                                        <td width="70%">
                                            <div align="right" style="margin-left: 500px">

                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 200px">
                                                            <strong>Security Code:&nbsp;<span class="required">*</span></strong>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_captcha_code" runat="server" TabIndex="21" Width="80px" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" Height="23px" MaxLength="4" ></asp:TextBox>
                                                        </td>
                                                        <td valign="middle" style="height: 30px; width: 100px;">
                                                            <asp:Image ID="imgCaptcha" runat="server" />
                                                        </td>
                                                        <td style="width: 100px"></td>
                                                        <td>
                                                            <asp:Button ID="btn_submit" runat="server" Width="140px" Height="28px" Font-Bold="true" Text="Submit" OnClick="btn_submit_Click" />
                                                            <input type="button" id="bWait" class="disable_button" value="Please wait ..." disabled="disabled" style="display: none;" />
                                                        </td>
                                                    </tr>
                                                </table>



                                            </div>

                                        </td>


                                    </tr>

                                </table>


                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 20px;"></td>
                    </tr>


                    <tr>
                        <td colspan="3">
                            <div align="center">
                                <asp:Label ID="lbl_error_message" Visible="false" Font-Bold="true" ForeColor="Red" Font-Size="22px" runat="server" Text=""></asp:Label>
                            </div>


                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="height: 20px;"></td>
                    </tr>


                </tbody>
            </table>

        </asp:Panel>


    </div>
</asp:Content>

