Partial Class AdminView
    Inherits System.Web.UI.Page

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Dim num As Integer
        If Integer.TryParse(Input.Text, num) Then

            If num <= 0 Then
                Label1.Text = "Enter a valid number greater than 0"
                Input.Text = ""
            Else

                Session("Input") = num
                OK.PostBackUrl = "~/AddQuestion.aspx"
            End If
        Else

            Label1.Text = "Enter a valid number"
            Input.Text = ""
        End If
    End Sub


End Class
