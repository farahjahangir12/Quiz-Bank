
Imports System.Data.SqlClient

Partial Class UserInterface
    Inherits System.Web.UI.Page


    Private Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        Dim role As String = ""
        Dim id As String = ""
        If UserName.Text = "" OrElse Password.Text = "" Then
            Label1.Text = "Enter Credentials First!"
        Else
            Dim user As String = UserName.Text
            Dim pswd As String = Password.Text
            Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"
            Dim con As New SqlConnection(connectionString)
            Dim query As String = "SELECT [USER_ID],[USER_ROLE] FROM USERS_T WHERE USERNAME=@user AND PSWD=@pswd"
            Dim cmd As New SqlCommand(query, con)
            Dim reader As SqlDataReader

            cmd.Parameters.AddWithValue("@user", user)
            cmd.Parameters.AddWithValue("@pswd", pswd)

            Try
                con.Open()
                reader = cmd.ExecuteReader
                While reader.Read()
                    id = reader("USER_ID")
                    role = reader("USER_ROLE")

                End While

            Catch ex As Exception
                Label1.Text = ex.Message
            Finally
                con.Close()
            End Try
            If Not String.IsNullOrEmpty(id) AndAlso role = "Admin" Then
                Session("ID") = id
                LogIn.PostBackUrl = "~/AdminView.aspx"
            ElseIf Not String.IsNullOrEmpty(id) AndAlso role = "User" Then
                LogIn.PostBackUrl = "~/UserView.aspx"
                Session("UID") = id
            Else
                Label1.Text = "Invalid username or password."
            End If

        End If

    End Sub

    Private Sub Reg_Click(sender As Object, e As EventArgs) Handles Reg.Click
        If UserName.Text = "" OrElse Password.Text = "" OrElse rrl.SelectedIndex = -1 Then
            Label1.Text = "Enter Credentials First!"
        Else
            Dim user As String = UserName.Text
            Dim pswd As String = Password.Text
            Dim role As String = rrl.SelectedItem.Text
            Dim inserted As Integer = 0

            Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"
            Dim con As New SqlConnection(connectionString)


            Dim queryCheckUser As String = "SELECT COUNT(*) FROM USERS_T WHERE USERNAME=@user AND PSWD=@pswd"
            Dim cmdCheckUser As New SqlCommand(queryCheckUser, con)
            cmdCheckUser.Parameters.AddWithValue("@user", user)
            cmdCheckUser.Parameters.AddWithValue("@pswd", pswd)

            Try
                con.Open()
                Dim userCounter As Integer = Convert.ToInt32(cmdCheckUser.ExecuteScalar())
                If userCounter > 0 Then
                    Label1.Text = "User already exists, please login."
                    Return
                End If
            Catch ex As Exception
                Label1.Text = "Error checking user: " & ex.Message
                Return
            Finally
                con.Close()
            End Try


            Dim query As String = "INSERT INTO USERS_T ([USERNAME], [PSWD], [USER_ROLE]) VALUES (@user, @pswd, @role)"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@user", user)
            cmd.Parameters.AddWithValue("@pswd", pswd)
            cmd.Parameters.AddWithValue("@role", role)

            Try
                con.Open()
                inserted = cmd.ExecuteNonQuery()
            Catch ex As Exception
                Label1.Text = "Registration Failed: " & ex.Message
            Finally
                con.Close()
            End Try

            If inserted > 0 Then
                Label1.Text = "Registered Successfully.Login To Continue"

            Else
                Label1.Text = "Registration Failed"
            End If

            UserName.Text = ""
            Password.Text = ""
            rrl.Controls.Clear()
        End If
    End Sub
End Class
