Public Class fMainForm
    Private PatientName As String
    Private CurrentCouponNumber As Integer
    Private TotalCoupon As Integer

    Private Sub fMainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Locate the form to right corner
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Location = New Point(x, y)


        PatientName = "ABC EDF JHJD JFDFDFDF"
        CurrentCouponNumber = 8988
        TotalCoupon = 10999

        'lPatientName.Text = "Patient Name: " + PatientName
        lPatientName.Text = PatientName
        ssDeskNo.Text = "Desk Code.: " + MainModule.DeskCode + ", Box No.: " + MainModule.BoxNo
        ssLoggedInUser.Text = "Username: " + MainModule.Username

        lblCouponNo.Text = CurrentCouponNumber
        lblTotalCoupon.Text = TotalCoupon

        'Make round corner buttons
        Call MainModule.RoundButton(btnRecall)
        Call MainModule.RoundButton(btnHold)
        Call MainModule.RoundButton(btnFinish)
        Call MainModule.RoundButton(btnNext)

        'Disable all buttons
        btnRecall.Enabled = False
        btnHold.Enabled = False
        btnHold.Visible = False
        btnFinish.Enabled = False
        btnNext.Enabled = False
    End Sub

    Private Function GetNextPendingCoupon()

    End Function

    Private Sub btnRecall_Click(sender As Object, e As EventArgs) Handles btnRecall.Click
        Debug.Print("Recall")
    End Sub

    Private Sub btnHold_Click(sender As Object, e As EventArgs) Handles btnHold.Click
        Debug.Print("Hold")

    End Sub

    Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click
        Debug.Print("Finish")

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Debug.Print("Next")

    End Sub

    'Private Sub fMainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    '    Debug.Print(e.KeyValue)
    '    Debug.Print(e.KeyCode)
    '    Debug.Print(e.KeyData)
    'End Sub
End Class
