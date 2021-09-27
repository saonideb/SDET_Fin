Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net.Mail
Imports System.IO
Imports System.Web.Configuration
Imports System.Collections.Specialized
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Globalization

Partial Class Individual_Users_Individual_Travel_Form_VB
    Inherits System.Web.UI.Page
    Public Email_User_ID As String = System.Configuration.ConfigurationManager.AppSettings("EmailID")
    Public Email_Password As String = System.Configuration.ConfigurationManager.AppSettings("EmailPassword")
    Public rail_fare As String
    Public Air_fare As String
    Public Local_Journey As String
    Public Accommodation_Rate As String
    Public Accommodation_Day As String
    Public Accommodation_Total_Amount As String
    Public Food_Rate As String
    Public Food_Day As String
    Public Food_Expenses_total_Amount As String
    Public Registration_fee As String
    Public total_Amount As String

    Protected Sub btn_save_Click(sender As Object, e As EventArgs)
        Dim con As New Data.SqlClient.SqlConnection
        con.ConnectionString = ConfigurationManager.ConnectionStrings("ConStr").ConnectionString

        If txt_rail_fare.Text = "" Then
            rail_fare = "0"
        Else
            rail_fare = txt_rail_fare.Text
        End If


        If txt_Air_fare.Text = "" Then
            Air_fare = "0"
        Else
            Air_fare = txt_Air_fare.Text
        End If


        If txt_Local_Journey.Text = "" Then
            Local_Journey = "0"
        Else
            Local_Journey = txt_Local_Journey.Text
        End If


        If txt_Accommodation_Rate.Text = "" Then
            Accommodation_Rate = "0"
        Else
            Accommodation_Rate = txt_Accommodation_Rate.Text
        End If

        If txt_Accommodation_Day.Text = "" Then
            Accommodation_Day = "0"
        Else
            Accommodation_Day = txt_Accommodation_Day.Text
        End If

        If txt_Accommodation_Total_Amount.Text = "" Then
            Accommodation_Total_Amount = "0"
        Else
            Accommodation_Total_Amount = txt_Accommodation_Total_Amount.Text
        End If

        If txt_Food_Rate.Text = "" Then
            Food_Rate = "0"
        Else
            Food_Rate = txt_Food_Rate.Text
        End If

        If txt_Food_Day.Text = "" Then
            Food_Day = "0"
        Else
            Food_Day = txt_Food_Day.Text
        End If

        If txt_Food_Expenses_total_Amount.Text = "" Then
            Food_Expenses_total_Amount = "0"
        Else
            Food_Expenses_total_Amount = txt_Food_Expenses_total_Amount.Text
        End If

        If txt_Registration_fee.Text = "" Then
            Registration_fee = "0"
        Else
            Registration_fee = txt_Registration_fee.Text
        End If

        If txt_total_Amount.Text = "" Then
            total_Amount = "0"
        Else
            total_Amount = txt_total_Amount.Text
        End If


        Dim commandstr3 As String
        Dim logincommand3 As New SqlCommand
        'commandstr3 = "INSERT INTO Form_A_Item_Details_Draft(Department_Id,Reference_No,Item_Description,Item_Quantity,Item_Cost,Submitted_On) values ( '" & department_division_id.ToString() & "','" & reference_no.ToString() & "','" & txt_item_description.Text.ToString() & "','" & txt_item_quantity.Text.ToString() & "','" & txt_item_cost.Text.ToString() & "','" & submitted_on.ToString() & "')"
        commandstr3 = "INSERT INTO Individual_Travel_Form(Project_No,Name_Department_PI,Funding_Agency,Project_Title,StatrtDate,End_Date,Name_Deg_1,Name_Deg_2,Name_Deg_3,Name_Deg_4,Place_Visited,Purpose_visit,Type_of_Leave,Mode_Of_Travel,rail_fare,Air_fare,Local_Journey,Accommodation_Rate,Accommodation_Day,Accommodation_Total_Amount,Food_Rate,Food_Day,Food_Expenses_total_Amount,Registration_fee,total_Amount,Created_On,Created_By) values ( '" & Lbl_Project_No.Text & "','" & Lbl_Name_Department_PI.Text & "','" & Lbl_Funding_Agency.Text.ToString() & "','" & txt_Project_Title.Text.ToString() & "','" & txt_StartDate.Text.ToString() & "','" & txt_End_Date.Text.ToString() & "','" & txt_Name_Deg_1.Text.ToString() & "','" & txt_Name_Deg_2.Text.ToString() & "','" & txt_Name_Deg_3.Text.ToString() & "','" & txt_Name_Deg_4.Text.ToString() & "','" & txt_Place_Visited.Text.ToString() & "','" & txt_Purpose_visit.Text.ToString() & "','" & txt_Type_of_Leave.Text.ToString() & "','" & txt_Mode_Of_Travel.Text.ToString() & "','" & rail_fare.ToString() & "','" & Air_fare.ToString() & "','" & Local_Journey.ToString() & "','" & Accommodation_Rate.ToString() & "','" & Accommodation_Day.ToString() & "','" & Accommodation_Total_Amount.ToString() & "','" & Food_Rate.ToString() & "','" & Food_Day.ToString() & "','" & Food_Expenses_total_Amount.ToString() & "','" & Registration_fee.ToString() & "','" & total_Amount.ToString() & "',getdate(),'" & Session("Email").ToString() & "')"
        logincommand3.CommandText = commandstr3
        logincommand3.Connection = con
        con.Open()
        logincommand3.ExecuteNonQuery()
        con.Close()

    End Sub
End Class
