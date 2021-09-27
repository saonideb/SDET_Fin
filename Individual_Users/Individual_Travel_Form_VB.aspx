<%@ Page Title="" Language="VB" MasterPageFile="~/Individual_Users/MasterPage.master" AutoEventWireup="false" CodeFile="Individual_Travel_Form_VB.aspx.vb" Inherits="Individual_Users_Individual_Travel_Form_VB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />--%>

    <link type="text/css" href="Datepicker/datepicker_style.css" rel="stylesheet" />
    <script type="text/javascript" src="Datepicker/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Datepicker/jquery-ui.js"></script>
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


    <script type="text/javascript">
        $(function () {
            $('#<%=txt_StartDate.ClientID%>').datepicker
        ({

            dateFormat: 'dd-M-yy',
            maxDate: "+0M +0D", //Futer dates are disabled from the current date
            minDate: "+0M -360D" //Past 380 days are shown from the current date		 
        });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#<%=txt_End_Date.ClientID%>').datepicker
        ({

            dateFormat: 'dd-M-yy',
            maxDate: "+0M +0D", //Futer dates are disabled from the current date
            minDate: "+0M -360D" //Past 380 days are shown from the current date		 
        });
        });
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

        .border {
            border: solid 1px black;
            padding: 25px;
            height: 25px;
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
        <table style="border-collapse: collapse; border: solid 1px gray; font-family: Arial; width: 90%; font-size: 13px;" border="1" cellpadding="3" cellspacing="2">
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
                        <asp:Label ID="Label1" runat="server" Font-Size="13px" Text="Department/Division/Unit/Centre:" Font-Bold="true"></asp:Label>
                        &nbsp;
                               <asp:Label ID="lbl_department_name" runat="server" ForeColor="darkred" Font-Bold="true" Font-Size="13px" Text=""></asp:Label>
                    </div>
                </td>
            </tr>

            <tr>
                <td colspan="3" style="height: 15px;" align="center"></td>
            </tr>
            <tr class="border">
                <td style="padding: 10px;">1</td>
                <td style="padding: 10px;">Project No./Sanction No.</td>
                <td style="padding: 10px;">
                    <asp:Label ID="Lbl_Project_No" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="border">
                <td style="padding: 10px;">2</td>
                <td style="padding: 10px;">Name and Department of PI</td>
                <td style="padding: 10px;">
                    <asp:Label ID="Lbl_Name_Department_PI" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="border">
                <td style="padding: 10px;">3</td>
                <td style="padding: 10px;">Funding Agency</td>
                <td style="padding: 10px;">
                    <asp:Label ID="Lbl_Funding_Agency" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="border">
                <td style="padding: 10px;">4</td>
                <td colspan="2">Project Title
                    <asp:TextBox ID="txt_Project_Title" runat="server" Width="250px"></asp:TextBox>
                    <br />
                    <br />
                    (a) Start Date:                   
                    <asp:TextBox ID="txt_StartDate" runat="server" autocomplete="off" CssClass="datepicker" TabIndex="2" Width="130px" Height="26px" Font-Bold="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txt_StartDate" Font-Bold="true" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>


                    (b)End Date:
                     <asp:TextBox ID="txt_End_Date" runat="server" autocomplete="off" CssClass="datepicker" TabIndex="2" Width="130px" Height="26px" Font-Bold="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_End_Date" Font-Bold="true" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="border">
                <td style="padding: 10px;">5</td>
                <td style="padding: 10px;" colspan="2">Name and Designation of travelling person(s);     
                    <br />
                    <br />
                    (a) 
                    <asp:TextBox ID="txt_Name_Deg_1" runat="server"></asp:TextBox>
                    (b)
                    <asp:TextBox ID="txt_Name_Deg_2" runat="server"></asp:TextBox><br />
                    <br />
                    (c) 
                    <asp:TextBox ID="txt_Name_Deg_3" runat="server"></asp:TextBox>
                    (d)
                    <asp:TextBox ID="txt_Name_Deg_4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="border">
                <td style="padding: 10px;" rowspan="4">6</td>
                <td style="padding: 10px;">(a)	Place(s) to be visited along with dates:</td>
                <td style="padding: 10px;">
                    <asp:TextBox ID="txt_Place_Visited" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="border">

                <td style="padding: 10px;">(b)	Purpose of visit:</td>
                <td style="padding: 10px;">
                    <asp:TextBox ID="txt_Purpose_visit" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="border">

                <td style="padding: 10px;">(c)	Type of Leave applied for:</td>
                <td style="padding: 10px;">
                    <asp:TextBox ID="txt_Type_of_Leave" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="border">

                <td style="padding: 10px;">(d)	Mode of Travel*:</td>
                <td style="padding: 10px;">
                    <asp:TextBox ID="txt_Mode_Of_Travel" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="border">
                <td style="padding: 10px;">7</td>
                <td style="padding: 10px;" colspan="2">Estimated Expenditure:<br />
                    <br />
                    (a)	Road/Rail Fare: Rs.<asp:TextBox ID="txt_rail_fare" runat="server"></asp:TextBox>(to & fro).  (Specify AC taxi if applicable)<br />
                    <br />
                    (b)	Air Fare: Rs.<asp:TextBox ID="txt_Air_fare" runat="server"></asp:TextBox>.
                    <br />
                    <br />
                    (c) Local Journey: Rs.
                    <asp:TextBox ID="txt_Local_Journey" runat="server"></asp:TextBox><br />
                    <br />
                    (d)Accommodation @<asp:TextBox ID="txt_Accommodation_Rate" runat="server"></asp:TextBox>for
                    <asp:TextBox ID="txt_Accommodation_Day" runat="server"></asp:TextBox>days = Rs.
                    <asp:TextBox ID="txt_Accommodation_Total_Amount" runat="server"></asp:TextBox><br />
                    <br />
                    (e)Food Expenses: @ 
                    <asp:TextBox ID="txt_Food_Rate" runat="server"></asp:TextBox>for<asp:TextBox ID="txt_Food_Day" runat="server"></asp:TextBox>days = Rs. 
                    <asp:TextBox ID="txt_Food_Expenses_total_Amount" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    (f)Registration fee (if applicable) Rs<asp:TextBox ID="txt_Registration_fee" runat="server"></asp:TextBox><br />
                    <br />

                    Total: Rs
                    <asp:TextBox ID="txt_total_Amount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div align="right" style="margin-right: 110px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_preview" runat="server" OnClick="btn_save_Click" Width="160px" Height="28px" Font-Bold="true" TabIndex="7" Text="Save and Preview" CausesValidation="False" />
                                </td>
                            </tr>

                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

