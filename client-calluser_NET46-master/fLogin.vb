Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers


Public Class fLogin
    Public IsValidCredentials As Boolean = False

    Private Sub fLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call MainModule.RoundButton(btnLogin)
        Call MainModule.RoundButton(btnExit)

    End Sub

    Private Function btnLogin_Click(sender As Object, e As EventArgs) As Task Handles btnLogin.Click
        If txtUserName.Text.Trim() = "" Or txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Username and Password are mandatory!", "Login", MessageBoxButtons.OK)
        Else
            If Me.Login() Then
                IsValidCredentials = True
                Me.Close()
            Else
                MessageBox.Show("Invalid credentials!", "Login", MessageBoxButtons.OK)
            End If
        End If
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        IsValidCredentials = False
        Me.Close()
    End Sub

    Private Function Login() As Boolean
        Try
            Using client As New HttpClient()
                Dim strValidateURI As String = ""
                Dim nApplicationType As Integer

                client.BaseAddress = New Uri(MainModule.WebAPIServerURL)
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

                If MainModule.ApplicationType.ToLower() = "CallUser".ToLower() Then
                    nApplicationType = 2
                Else
                    nApplicationType = 0
                End If

                Dim details = New LoginDTO With {
                    .ApplicationType = nApplicationType,
                    .Username = txtUserName.Text.Trim(),
                    .Password = txtPassword.Text.Trim(),
                    .MACAddress = "x",
                    .DeskCode = txtDeskNo.Text.Trim(),
                    .BoxNo = txtBoxNo.Text.Trim()
                }

                strValidateURI = "api/account/login"


                Dim response = client.PostAsJsonAsync(strValidateURI, details)
                response.Wait()

                If response.Result.StatusCode = HttpStatusCode.OK Then
                    Dim UserInfo = response.Result.Content.ReadAsAsync(Of UserDTO)()

                    MainModule.BoxId = UserInfo.Result.BoxId
                    MainModule.BoxNo = UserInfo.Result.BoxNo
                    MainModule.DeskCode = UserInfo.Result.DeskCode
                    MainModule.DeskId = UserInfo.Result.DeskId
                    MainModule.Token = UserInfo.Result.Token
                    MainModule.Username = UserInfo.Result.Username

                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Some exception has occured: " + ex.Message, "Login error", MessageBoxButtons.OK)
            Return False
        End Try
    End Function
End Class