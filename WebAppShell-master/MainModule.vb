Imports System.Configuration
Imports System.Management
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Net.NetworkInformation
Imports System.Net.Sockets

Module MainModule
    Public Class ValidateIPDTO
        Property ApplicationType As String
        Property IPAddress As String
        Property MACAddress As String
    End Class

    Private strApplicationType As String = ""
    Private strBrowserPath As String = ""
    Private strWebAPIServer As String = ""
    Private strClientServer As String = ""
    Private strStageProcess As String = ""

    Sub Main()
        Try
            '1. Reading config file
            strStageProcess = "Stage 1"
            strApplicationType = ConfigurationManager.AppSettings.Get("ApplicationType")
            strBrowserPath = ConfigurationManager.AppSettings.Get("BrowserPath")
            strWebAPIServer = ConfigurationManager.AppSettings.Get("WebAPIServer")
            strClientServer = ConfigurationManager.AppSettings.Get("ClientServer")

            Dim ipAddress As String = "", macAddress As String = ""
            '2. Reading IP
            strStageProcess = "Stage 2"
            ipAddress = GetLocalIPAddress()

            '3. Reading MACAddress
            strStageProcess = "Stage 3"
            macAddress = GetMacAddress()
            'ipAddress = "192.168.1.19"


            If ValidateMyIPAddress(ipAddress, macAddress) Then
                '5. Opening browser with client application
                strStageProcess = "Stage 5"
                ' Open browser with client server address
                ' https://peter.sh/experiments/chromium-command-line-switches/
                ' --kiosk - Enable kiosk mode. Please note this is not Chrome OS kiosk mode. 
                ' --kiosk-printing - Enable automatically pressing the print button in print preview
                Dim arguments = String.Format("{0} {1}", "--kiosk --kiosk-printing", strClientServer)

                System.Diagnostics.Process.Start(strBrowserPath, arguments)
            Else
                MessageBox.Show("Running this application is not authorised on this machine." & vbCrLf & "Please contact your admin!", "Unauthorised application", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured: " + ex.Message & vbCrLf & "at " & strStageProcess, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetLocalIPAddress() As String
        Dim host = Dns.GetHostEntry(Dns.GetHostName())


        For Each ip In host.AddressList
            If ip.AddressFamily = AddressFamily.InterNetwork Then
                Return ip.ToString()
            End If
        Next

        Throw New Exception("No network adapters with an IPv4 address in the system!")
    End Function

    Private Function GetMacAddress() As String
        Dim qstring As String = "SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled = true"
        For Each mo As ManagementObject In New ManagementObjectSearcher(qstring).Get()
            Dim macaddress As String = mo("MacAddress")
            If Not macaddress Is Nothing Then
                Return macaddress
            End If
        Next
        Return ""
    End Function

    Private Function ValidateMyIPAddress(IPAddress As String, MACAddress As String) As Boolean
        Try
            Using client As New HttpClient()
                Dim strValidateURI As String = ""

                client.BaseAddress = New Uri(strWebAPIServer)
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

                Dim details = New ValidateIPDTO With {
                    .ApplicationType = strApplicationType,
                    .IPAddress = IPAddress,
                    .MACAddress = MACAddress
                }

                If strApplicationType.ToLower() = "Kiosk".ToLower() Then
                    strValidateURI = "api/kiosk/validate-address"
                Else
                    strValidateURI = "api/iptv/validate-address"
                End If

                '4. Posting to WebAPI server
                strStageProcess = "Stage 4"

                Dim response = client.PostAsJsonAsync(strValidateURI, details)
                response.Wait()

                If response.Result.StatusCode = HttpStatusCode.OK Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Module

