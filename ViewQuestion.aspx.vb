
Imports System.Data.SqlClient

Partial Class ViewQuestion
    Inherits System.Web.UI.Page

    Private Sub ViewQuestion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim count As Integer = 1
        Dim id As String = CType(Session("ID"), String)
        Dim query As String = "SELECT * FROM QUESTIONS_T WHERE [CREATED_BY] =" & id
        If id IsNot Nothing Then
            Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"
            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, con)
            Dim reader As SqlDataReader
            Try
                con.Open()
                reader = cmd.ExecuteReader
                While reader.Read
                    Dim lbl1 As New Label
                    Dim lbl2 As New Label
                    Dim lbl3 As New Label
                    Dim lbl4 As New Label
                    lbl1.Text = count.ToString

                    Dim rows As New TableRow
                    Dim cell1 As New TableCell
                    cell1.Controls.Add(lbl1)
                    Dim cell2 As New TableCell
                    lbl2.Text = reader("QUESTION_STRING").ToString
                    cell2.Controls.Add(lbl2)
                    Dim cell3 As New TableCell
                    lbl3.Text = reader("OPTION_A").ToString & "<br/>"
                    lbl3.Text &= reader("OPTION_B").ToString & "<br/>"
                    lbl3.Text &= reader("OPTION_C").ToString & "<br/>"
                    lbl3.Text &= reader("OPTION_D").ToString & "<br/>"
                    cell3.Controls.Add(lbl3)
                    Dim cell4 As New TableCell
                    lbl4.Text = reader("CORRECT_CHOICE").ToString
                    cell4.Controls.Add(lbl4)

                    rows.Controls.Add(cell1)
                    rows.Controls.Add(cell2)
                    rows.Controls.Add(cell3)
                    rows.Controls.Add(cell4)

                    qtable.Controls.Add(rows)

                    rows.CssClass = "qrow"
                    cell1.CssClass = "count"
                    cell2.CssClass = "qcell"
                    cell3.CssClass = "optcell"
                    cell4.CssClass = "correctcell"
                    count += 1
                End While
            Catch ex As Exception
                Label1.Text = ex.Message
            Finally
                con.Close()
            End Try
        End If
    End Sub
End Class
