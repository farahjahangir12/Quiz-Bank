Imports System.Data.SqlClient


Partial Class AttemptTest
    Inherits System.Web.UI.Page

    Private Sub AttemptTest_Load(sender As Object, e As EventArgs) Handles Me.Load
        Panel1.Visible = True
        Submit.Text = "Submit"
        Dim qId As Integer
        If Session("QId") Is Nothing Then
            qId = 0
        Else
            qId = CType(Session("QId"), Integer)
        End If
        Dim counter As Integer
        If Session("Qcount") Is Nothing Then
            counter = 0
        Else
            counter = CType(Session("Qcount"), Integer)
        End If

        If counter < 10 Then
            Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"
            Dim query As String = "SELECT TOP 1 * FROM QUESTIONS_T WHERE [QUESTION_STRING] NOT IN (
                                    SELECT [QUESTION_STRING] FROM QUESTIONS_T WHERE [QUESTION_ID]= @qId) ORDER BY NEWID()"

            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, con)
            Dim reader As SqlDataReader
            Try
                con.Open()
                cmd.Parameters.AddWithValue("@qId", qId)
                reader = cmd.ExecuteReader()
                If reader.Read() Then
                    DisplayQuestion(reader)
                End If
            Catch ex As Exception
                Label1.Text = ex.Message
            Finally

                con.Close()
            End Try
            counter += 1
            Session("Qcount") = counter
        Else
            SubmitTest.Visible = True
            AttemptAgain.Visible = True
            ExitTest.Visible = True
        End If
    End Sub

    Private Sub DisplayQuestion(reader As SqlDataReader)
        Dim qId As String = reader("QUESTION_ID").ToString()
        questLabel.Text = reader("QUESTION_STRING").ToString()
        opt1.Text = reader("OPTION_A").ToString()
        opt2.Text = reader("OPTION_B").ToString()
        opt3.Text = reader("OPTION_C").ToString()
        opt4.Text = reader("OPTION_D").ToString()
        Dim answer As String = reader("CORRECT_CHOICE").ToString()
        Session("Answer") = answer
        Session("QId") = qId
    End Sub

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        Dim score As Integer
        If Session("Score") Is Nothing Then
            score = 0
        Else
            score = CType(Session("Score"), Integer)
        End If
        score += MarkQuestion()
        Session("Score") = score
    End Sub

    Private Sub SubmitTest_Click(sender As Object, e As EventArgs) Handles SubmitTest.Click
        Dim score As Integer
        If Session("Score") Is Nothing Then
            score = 0
        Else
            score = CType(Session("Score"), Integer)
        End If
        Label1.Text = "Your score is: " & score.ToString()
        Session("Score") = score
    End Sub

    Private Sub AttemptAgain_Click(sender As Object, e As EventArgs) Handles AttemptAgain.Click
        Panel1.Visible = False
        Submit.Text = "Ready"
        Dim attempt As Integer = 0
        If Session("Attempt") Is Nothing Then
            attempt = 1
        Else
            attempt = CType(Session("Attempt"), Integer) + 1
        End If
        If attempt > 2 Then
            Label1.Text = "All Attempt Availed"
            ExitTest.Visible = True
            Session("Qcount") = 10
            Panel1.Visible = False
            AttemptAgain.Visible = False
            Session("Attempt") = attempt
        Else
            AttemptAgain.Visible = False
            rrl.Controls.Clear()
            ViewState("Qcount") = 0
            SubmitTest.Visible = False
            Session("Score") = 0
            Session("Attempt") = attempt


        End If

    End Sub


    Private Sub ExitTest_Click(sender As Object, e As EventArgs) Handles ExitTest.Click
        Dim userid As Integer = CType(Session("UID"), Integer)
        Dim score As Integer = CType(Session("Score"), Integer)
        Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"
        Dim query As String = "INSERT INTO USER_SCORE ([USER_ID],[SCORE]) VALUES (@USER_ID,@SCORE)"
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, con)
        Try
            con.Open()
            cmd.Parameters.AddWithValue("@USER_ID", userid)
            cmd.Parameters.AddWithValue("@SCORE", score)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Label1.Text = ex.Message
        Finally
            con.Close()
        End Try
        ExitTest.PostBackUrl = "UserInterface.aspx"

    End Sub

    Private Function MarkQuestion() As Integer
        Dim score As Integer
        Dim selected As String = rrl.SelectedItem?.Text
        Dim correct As String = CType(Session("Answer"), String)
        If selected IsNot Nothing AndAlso String.Equals(selected, correct) Then
            score = 1
        Else
            score = 0
        End If
        Return score
    End Function
End Class
