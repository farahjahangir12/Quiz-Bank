Imports System.Data.SqlClient

Partial Class AddQuestion
    Inherits System.Web.UI.Page

    Protected Sub qtext_TextChanged(sender As Object, e As EventArgs) Handles qtext.TextChanged
        If IsPostBack Then
            Pnldetails.Visible = True
            Label1.Text = "Please Provide Options For the Above Question.Check the Right Option."

        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim count As Integer = CType(Session("Count"), Integer)
        Dim allowed As Integer = CType(Session("Input"), Integer)


        If count >= allowed Then
            Pnldetails.Controls.Clear()
            Label1.Text = "Cannot add more questions.Click Return to navigate to input page"
            Dim btn As New Button
            btn.Text = "Return"
            btn.PostBackUrl = "~/AdminView.aspx"
            btn.CssClass = "button"
            Pnldetails.Controls.Add(btn)
            Return
        End If

        Dim checkCounter As Integer = 0
        Dim correctChoice As String = ""


        If OptTrue1.Checked Then
            checkCounter += 1
            correctChoice = opt1.Text
        End If

        If OptTrue2.Checked Then
            checkCounter += 1
            correctChoice = opt2.Text
        End If

        If OptTrue3.Checked Then
            checkCounter += 1
            correctChoice = opt3.Text
        End If

        If OptTrue4.Checked Then
            checkCounter += 1
            correctChoice = opt4.Text
        End If


        If opt1.Text = "" Or opt2.Text = "" Or opt3.Text = "" Or opt4.Text = "" Or checkCounter <> 1 Then
            Label1.Text = "Enter Valid Data"
        Else
            Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"
            Dim query As String = "INSERT INTO QUESTIONS_T ([QUESTION_STRING], [OPTION_A], [OPTION_B], [OPTION_C],[OPTION_D],[CORRECT_CHOICE],[CREATED_BY]) VALUES (@QuestionString, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectChoice, @CreatedBy)"

            Dim con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, con)
            Try
                con.Open()
                cmd.Parameters.AddWithValue("@QuestionString", qtext.Text)
                cmd.Parameters.AddWithValue("@OptionA", opt1.Text)
                cmd.Parameters.AddWithValue("@OptionB", opt2.Text)
                cmd.Parameters.AddWithValue("@OptionC", opt3.Text)
                cmd.Parameters.AddWithValue("@OptionD", opt4.Text)
                cmd.Parameters.AddWithValue("@CorrectChoice", correctChoice)

                Dim createdBy As Integer
                If Session("ID") IsNot Nothing AndAlso Integer.TryParse(Session("ID"), createdBy) Then
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy)
                End If

                Dim inserted As Integer = cmd.ExecuteNonQuery()
                If inserted > 0 Then
                    Label1.Text = "Question added successfully."

                    count += 1
                    Session("Count") = count
                Else
                    Label1.Text = "Failed to add question."
                End If
            Catch ex As Exception
                Label1.Text = "An error occurred: " & ex.Message
            Finally
                con.Close()
            End Try
        End If


        qtext.Text = ""
        opt1.Text = ""
        opt2.Text = ""
        opt3.Text = ""
        opt4.Text = ""
        OptTrue1.Checked = False
        OptTrue2.Checked = False
        OptTrue3.Checked = False
        OptTrue4.Checked = False
    End Sub

    Private Sub AddQuestion_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Input") IsNot Nothing Then
                ViewState("Count") = Session("Input")
            Else
                ViewState("Count") = 0
            End If
        End If
    End Sub
End Class
