Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json

Public Class fMainForm
    Private RecallClickedCount As Short = 0
    Private CurrentCouponId As Integer = 0

    Private Sub fMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Locate the form to right corner
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Location = New Point(x, y)

        Me.KeyPreview = True

        Call ResetCoupon()

        'Disable buttons
        ppRecall.Enabled = False
        ppHold.Enabled = False
        ppHold.Visible = False
        ppFinish.Enabled = False
        ppNext.Enabled = True

        lblTotalCoupons.Text = 0
        lblPatientId.Text = ""
        lblStatusBar.Text = MainModule.DeskCode + " - " + MainModule.BoxNo + " - " + MainModule.Username
    End Sub

    Private Sub ResetCoupon()
        ttTips.SetToolTip(pbCouponNo, "")

        RecallClickedCount = 0
        lblRecallCount.Text = ""

        lblCouponNo.Text = 0
        CurrentCouponId = 0
    End Sub

    Private Async Function GetNextPendingCouponAsync() As Task(Of Boolean)
        Try
            'tmrNextPendingOrder.Enabled = False
            Debug.Print("GetNextPendingCouponAsync")

            Using client As New HttpClient()
                Dim strValidateURI As String = ""

                client.BaseAddress = New Uri(MainModule.WebAPIServerURL)
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("bearer", MainModule.Token)

                Dim details = New NextPendingCouponDTO With {
                    .DeskId = MainModule.DeskId,
                    .BoxId = MainModule.BoxId,
                    .BoxUserId = MainModule.UserId
                }

                strValidateURI = "api/coupon/get-next-pending-coupon"
                Dim httpContent = New StringContent(JsonConvert.SerializeObject(details), Encoding.UTF8, "application/json")

                Dim response = client.PostAsync(strValidateURI, httpContent)
                response.Wait()

                If response.Result.StatusCode = HttpStatusCode.OK Then
                    Dim NextPendingCouponInfo = Await response.Result.Content.ReadAsAsync(Of NextPendingCoupon())

                    If (NextPendingCouponInfo IsNot Nothing) Then
                        For Each coupon As NextPendingCoupon In NextPendingCouponInfo
                            ttTips.SetToolTip(pbCouponNo, coupon.ServiceName)
                            lblCouponNo.Text = coupon.CouponNo.ToString()
                            lblTotalCoupons.Text = coupon.TotalCoupons.ToString()
                            CurrentCouponId = coupon.Id
                        Next
                    End If

                    'tmrNextPendingOrder.Enabled = True

                    Return True
                Else
                    'tmrNextPendingOrder.Enabled = True
                    'Dim failureMsg = "HTTP Status: " + response.Result.StatusCode.ToString() + " – Reason: " + response.Result.ReasonPhrase

                    Call ResetCoupon()
                    ttTips.SetToolTip(pbCouponNo, "No patient in the queue. Please try again!")
                    lblPatientId.Text = "No patient in the queue."

                    Return False
                End If
            End Using
        Catch ex As Exception
            ' Disable the timer as there is exception
            'tmrNextPendingOrder.Enabled = True
            CurrentCouponId = 0

            MessageBox.Show("Some exception has occured: " + ex.Message, "QMS error", MessageBoxButtons.OK)

            Return False
        End Try
    End Function

    Private Function UpdateCouponStatus(ByVal Status As String) As Boolean
        Try
            'tmrNextPendingOrder.Enabled = False

            If CurrentCouponId = 0 Then Return False

            Using client As New HttpClient()
                Dim strValidateURI As String = ""

                client.BaseAddress = New Uri(MainModule.WebAPIServerURL)
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("bearer", MainModule.Token)

                Dim details = New UpdateCouponStatusDTO With {
                    .CouponId = CurrentCouponId,
                    .Status = Status
                }

                strValidateURI = "api/coupon/update-coupon-status"

                Dim httpContent = New StringContent(JsonConvert.SerializeObject(details), Encoding.UTF8, "application/json")

                Dim response = client.PostAsync(strValidateURI, httpContent)
                response.Wait()

                'tmrNextPendingOrder.Enabled = True
                'Dim failureMsg = "HTTP Status: " + response.Result.StatusCode.ToString() + " – Reason: " + response.Result.ReasonPhrase
                Return (response.Result.StatusCode = HttpStatusCode.OK) 'Return True if StatusCode is Ok else return False

            End Using
        Catch ex As Exception
            ' Disable the timer as there is exception
            'tmrNextPendingOrder.Enabled = True
            MessageBox.Show("Some exception has occured: " + ex.Message, "QMS error", MessageBoxButtons.OK)

            Return False
        End Try
    End Function

    Private Sub ppRecall_Click(sender As Object, e As EventArgs) Handles ppRecall.Click
        'NOTE:
        'Mark the patient as Abset as he did not turned up even after three recall

        ' Recall click - Disable - Finish, Recall, Next :: Enable: Hold - Change to UnHold

        If RecallClickedCount > 1 Then
            If UpdateCouponStatus("A") Then
                'Reset recall count
                RecallClickedCount = 0
                lblRecallCount.Text = ""

                ppNext.Enabled = True
                ppFinish.Enabled = False
                ppRecall.Enabled = False
                ppHold.Enabled = True

                ppRecall.Text = "&Recall"
                Call ResetCoupon()
            End If
        Else
            RecallClickedCount += 1
            lblRecallCount.Text = RecallClickedCount.ToString()

            'ppRecall.Text = "&Recall (" + RecallClickedCount.ToString() + ")"
        End If
    End Sub

    Private Sub ppHold_Click(sender As Object, e As EventArgs) Handles ppHold.Click
        'NOTE:
        'Update box status as Hold and Unhold based on the click in the database
        ' Hold click - Disable - Finish, Recall, Next :: Enable: Hold - Change to UnHold

        If ppHold.Text = "&Hold" Then
            ppHold.Text = "Un&hold"
            ppNext.Enabled = False
            ppFinish.Enabled = False
            ppRecall.Enabled = False
            ppHold.Enabled = True
        Else
            ppHold.Text = "&Hold"
            ppNext.Enabled = True
            ppFinish.Enabled = False
            ppRecall.Enabled = False
            ppHold.Enabled = True
        End If

        'Reset recall count
        RecallClickedCount = 0
        lblRecallCount.Text = ""
    End Sub

    Private Sub ppFinish_Click(sender As Object, e As EventArgs) Handles ppFinish.Click
        'NOTE:
        'Mark IsCompleted and Completion Date to current coupon number
        If UpdateCouponStatus("F") Then
            ' Finish click - Disable - Finish, Recall :: Enable: Next, Hold 
            ppNext.Enabled = True
            ppFinish.Enabled = False
            ppRecall.Enabled = False
            ppHold.Enabled = True
            ppRecall.Text = "&Recall"

            Call ResetCoupon()
        End If
    End Sub

    Private Sub ppNext_Click(sender As Object, e As EventArgs) Handles ppNext.Click
        'NOTE:
        'Fetch next pending coupon and tag that with local box number and logged in user
        If GetNextPendingCouponAsync().Result Then
            ' Next click - Disable - Next :: Enable: Finish, Recall, Hold 
            ppNext.Enabled = False
            ppFinish.Enabled = True
            ppRecall.Enabled = True
            ppHold.Enabled = False
            ppRecall.Text = "&Recall"

            'Reset recall count
            RecallClickedCount = 0
            lblRecallCount.Text = ""
        End If
    End Sub

    Private Sub fMainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F
                If ppFinish.Enabled Then
                    Call ppFinish_Click(ppFinish, e)
                End If
            Case Keys.N
                If ppNext.Enabled Then
                    Call ppNext_Click(ppFinish, e)
                End If
            Case Keys.R
                If ppRecall.Enabled Then
                    Call ppRecall_Click(ppFinish, e)
                End If
            Case Keys.H
                If ppHold.Enabled Then
                    Call ppHold_Click(ppFinish, e)
                End If
        End Select
    End Sub
End Class
