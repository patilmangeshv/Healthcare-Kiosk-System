Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json

Public Class fLogin
    Public IsValidCredentials As Boolean = False

    Private Sub fLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblVersion.Text = "ver1.0"

        Call MainModule.RoundButton(btnLogin)
        Call MainModule.RoundButton(btnExit)

        If PopulateData() Then
            If MainModule.BoxServiceDesks IsNot Nothing AndAlso MainModule.BoxServiceDesks.Count > 1 Then
                Dim desks = From dr In MainModule.BoxServiceDesks.Values
                            Select dr.DeskId, dr.Desk.DeskCode, dr.Desk.DeskName, DeskCodeName = dr.Desk.DeskCode & " - " & dr.Desk.DeskName
                            Distinct
                            Order By DeskCodeName

                For Each desk In desks
                    cbDeskCode.Items.Add(desk)
                Next

                cbDeskCode.ValueMember = "DeskId"
                cbDeskCode.DisplayMember = "DeskCodeName"
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserName.Text.Trim() = "" Or txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Username and Password are mandatory!", "Login", MessageBoxButtons.OK)
        ElseIf cbDeskCode.SelectedItem Is Nothing OrElse cbBoxNo.SelectedItem Is Nothing Then
            MessageBox.Show("Please select desk and box!", "Login", MessageBoxButtons.OK)
        ElseIf txtUserName.Text.Trim() = "" OrElse txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Please enter user name and password!", "Login", MessageBoxButtons.OK)
        Else
            If Login() Then
                IsValidCredentials = True
                Me.Close()
            Else
                MessageBox.Show("Invalid credentials!", "Login", MessageBoxButtons.OK)
            End If
        End If
    End Sub

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
                'client.DefaultRequestHeaders.Accept.Clear()
                'client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

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
                    .DeskCode = cbDeskCode.SelectedItem.DeskCode.Trim(),
                    .BoxNo = cbBoxNo.SelectedItem.BoxNo.Trim()
                }
                Dim httpContent = New StringContent(JsonConvert.SerializeObject(details), Encoding.UTF8, "application/json")

                strValidateURI = "api/account/login"

                Dim response = client.PostAsync(strValidateURI, httpContent)
                response.Wait()

                If response.Result.StatusCode = HttpStatusCode.OK Then
                    'Dim res = JsonConvert.DeserializeObject(response.ToString)
                    Dim UserInfo = response.Result.Content.ReadAsAsync(Of UserDTO)()
                    UserInfo.Wait()

                    MainModule.BoxId = UserInfo.Result.BoxId
                    MainModule.BoxNo = UserInfo.Result.BoxNo
                    MainModule.DeskCode = UserInfo.Result.DeskCode
                    MainModule.DeskId = UserInfo.Result.DeskId
                    MainModule.Token = UserInfo.Result.Token
                    MainModule.UserId = UserInfo.Result.UserId
                    MainModule.Username = UserInfo.Result.Username

                    Return True
                Else
                    'show the response status code 
                    Dim failureMsg = "HTTP Status: " + response.Result.StatusCode.ToString() + " – Reason: " + response.Result.ReasonPhrase

                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Some exception has occured: " + ex.Message, "Login error", MessageBoxButtons.OK)
            Return False
        End Try
    End Function

    Private Function PopulateData() As Boolean
        Try
            Using client As New HttpClient()
                Dim strValidateURI As String = ""
                MainModule.BoxServiceDesks = New Dictionary(Of Integer, BoxServiceDesk)

                client.BaseAddress = New Uri(MainModule.WebAPIServerURL)
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

                strValidateURI = "api/boxservice/boxservice"

                Dim response = client.GetAsync(strValidateURI)
                response.Wait()

                If response.Result.StatusCode = HttpStatusCode.OK Then
                    Dim boxesResponse = response.Result.Content.ReadAsAsync(Of BoxServiceDesk())()
                    boxesResponse.Wait()

                    If boxesResponse.Result IsNot Nothing Then
                        For Each b In boxesResponse.Result
                            MainModule.BoxServiceDesks.Add(b.Id, b)
                        Next
                    End If

                    Return True
                Else
                    'show the response status code 
                    Dim failureMsg = "HTTP Status: " + response.Result.StatusCode.ToString() + " – Reason: " + response.Result.ReasonPhrase

                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Some exception has occured: " + ex.Message, "Populate data error", MessageBoxButtons.OK)
            Return False
        End Try
    End Function

    Private Sub cbDeskCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDeskCode.SelectedIndexChanged
        cbBoxNo.Text = ""
        cbBoxNo.Items.Clear()
        cbBoxNo.SelectedIndex = -1
        If cbDeskCode.SelectedItem IsNot Nothing Then
            Dim boxes = From dr In MainModule.BoxServiceDesks.Values
                        Where dr.DeskId = cbDeskCode.SelectedItem.DeskId
                        Select dr.BoxId, dr.Box.BoxNo, dr.Box.BoxName, BoxNoName = dr.Box.BoxNo & " - " & dr.Box.BoxName
                        Distinct
                        Order By BoxNoName

            If boxes IsNot Nothing AndAlso boxes.Count > 0 Then
                For Each box In boxes
                    cbBoxNo.Items.Add(box)
                Next

                cbBoxNo.ValueMember = "BoxId"
                cbBoxNo.DisplayMember = "BoxNoName"
                cbBoxNo.SelectedIndex = 0
            End If
        End If
    End Sub
End Class