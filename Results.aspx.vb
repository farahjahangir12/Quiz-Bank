Imports System.Data.SqlClient

Partial Class Results
    Inherits System.Web.UI.Page

    Private Sub Results_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim count As Integer = 1
        Dim query As String = "SELECT USER_SCORE.USER_ID, USERS_T.USERNAME, USER_SCORE.SCORE 
                               FROM USER_SCORE
                               JOIN USERS_T ON
                               USERS_T.USER_ID = USER_SCORE.USER_ID
                               "
        Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, con)
        Dim reader As SqlDataReader

        Try
            con.Open()
            reader = cmd.ExecuteReader
            While reader.Read()
                Dim lbl1 As New Label
                Dim lbl2 As New Label
                Dim lbl3 As New Label
                Dim lbl4 As New Label
                lbl1.Text = count.ToString

                Dim rows As New TableRow
                Dim cell1 As New TableCell
                cell1.Controls.Add(lbl1)
                Dim cell2 As New TableCell
                lbl2.Text = reader("USER_ID")
                cell2.Controls.Add(lbl2)
                Dim cell3 As New TableCell
                lbl3.Text = reader("USERNAME")
                cell3.Controls.Add(lbl3)
                Dim cell4 As New TableCell
                lbl4.Text = reader("SCORE")


                cell4.Controls.Add(lbl4)
                rows.Controls.Add(cell1)
                rows.Controls.Add(cell2)
                rows.Controls.Add(cell3)
                rows.Controls.Add(cell4)
                table.Controls.Add(rows)

                rows.CssClass = "qrow1"
                cell1.CssClass = "count1"
                cell2.CssClass = "qcell1"
                cell3.CssClass = "optcell1"
                cell4.CssClass = "correctcell1"
                count += 1
            End While
            reader.Close()

        Catch ex As Exception
            Label1.Text = ex.Message
        Finally
            con.Close()
        End Try

    End Sub


End Class
