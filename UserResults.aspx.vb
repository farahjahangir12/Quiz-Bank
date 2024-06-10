Imports System.Data
Imports System.Data.SqlClient

Partial Class UserResults
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim query As String = "SELECT US.USER_ID, UT.USERNAME, US.SCORE 
                               FROM USER_SCORE US
                               JOIN USERS_T UT ON UT.USER_ID = US.USER_ID"

        Dim connectionString As String = "workstation id=PineValley.mssql.somee.com;packet size=4096;user id=farahjahangir_SQLLogin_1;pwd=74kd7f8awc;data source=PineValley.mssql.somee.com;persist security info=False;initial catalog=PineValley;TrustServerCertificate=True"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                Catch ex As Exception

                End Try
            End Using
        End Using
    End Sub
End Class
