<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMainForm))
        Me.ppRecall = New System.Windows.Forms.PictureBox()
        Me.ppHold = New System.Windows.Forms.PictureBox()
        Me.ppFinish = New System.Windows.Forms.PictureBox()
        Me.ppNext = New System.Windows.Forms.PictureBox()
        Me.pbCouponNo = New System.Windows.Forms.PictureBox()
        Me.lblCouponNo = New System.Windows.Forms.Label()
        Me.lblTotalCoupons = New System.Windows.Forms.Label()
        Me.pbTotalCoupons = New System.Windows.Forms.PictureBox()
        Me.ttTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblRecallCount = New System.Windows.Forms.Label()
        Me.lblStatusBar = New System.Windows.Forms.Label()
        Me.lblPatientId = New System.Windows.Forms.Label()
        CType(Me.ppRecall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppHold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppFinish, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ppNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCouponNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTotalCoupons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ppRecall
        '
        Me.ppRecall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ppRecall.BackgroundImage = CType(resources.GetObject("ppRecall.BackgroundImage"), System.Drawing.Image)
        Me.ppRecall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ppRecall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ppRecall.Location = New System.Drawing.Point(12, 52)
        Me.ppRecall.Name = "ppRecall"
        Me.ppRecall.Size = New System.Drawing.Size(50, 50)
        Me.ppRecall.TabIndex = 0
        Me.ppRecall.TabStop = False
        Me.ttTips.SetToolTip(Me.ppRecall, "Recall (Ctrl + R)")
        '
        'ppHold
        '
        Me.ppHold.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ppHold.BackgroundImage = CType(resources.GetObject("ppHold.BackgroundImage"), System.Drawing.Image)
        Me.ppHold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ppHold.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ppHold.Location = New System.Drawing.Point(77, 52)
        Me.ppHold.Name = "ppHold"
        Me.ppHold.Size = New System.Drawing.Size(50, 50)
        Me.ppHold.TabIndex = 1
        Me.ppHold.TabStop = False
        Me.ttTips.SetToolTip(Me.ppHold, "Hold (Ctrl + H)")
        '
        'ppFinish
        '
        Me.ppFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ppFinish.BackgroundImage = CType(resources.GetObject("ppFinish.BackgroundImage"), System.Drawing.Image)
        Me.ppFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ppFinish.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ppFinish.Location = New System.Drawing.Point(224, 52)
        Me.ppFinish.Name = "ppFinish"
        Me.ppFinish.Size = New System.Drawing.Size(50, 50)
        Me.ppFinish.TabIndex = 2
        Me.ppFinish.TabStop = False
        Me.ttTips.SetToolTip(Me.ppFinish, "Finish (Ctrl + F)")
        '
        'ppNext
        '
        Me.ppNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ppNext.BackgroundImage = CType(resources.GetObject("ppNext.BackgroundImage"), System.Drawing.Image)
        Me.ppNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ppNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ppNext.Location = New System.Drawing.Point(287, 48)
        Me.ppNext.Name = "ppNext"
        Me.ppNext.Size = New System.Drawing.Size(55, 55)
        Me.ppNext.TabIndex = 3
        Me.ppNext.TabStop = False
        Me.ttTips.SetToolTip(Me.ppNext, "Next (Ctrl + N)")
        '
        'pbCouponNo
        '
        Me.pbCouponNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbCouponNo.BackgroundImage = CType(resources.GetObject("pbCouponNo.BackgroundImage"), System.Drawing.Image)
        Me.pbCouponNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbCouponNo.Location = New System.Drawing.Point(183, 10)
        Me.pbCouponNo.Name = "pbCouponNo"
        Me.pbCouponNo.Size = New System.Drawing.Size(30, 30)
        Me.pbCouponNo.TabIndex = 4
        Me.pbCouponNo.TabStop = False
        Me.ttTips.SetToolTip(Me.pbCouponNo, "Current coupon number")
        '
        'lblCouponNo
        '
        Me.lblCouponNo.AutoSize = True
        Me.lblCouponNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCouponNo.Location = New System.Drawing.Point(219, 18)
        Me.lblCouponNo.Name = "lblCouponNo"
        Me.lblCouponNo.Size = New System.Drawing.Size(32, 16)
        Me.lblCouponNo.TabIndex = 5
        Me.lblCouponNo.Text = "999"
        Me.ttTips.SetToolTip(Me.lblCouponNo, "Current coupon number")
        '
        'lblTotalCoupons
        '
        Me.lblTotalCoupons.AutoSize = True
        Me.lblTotalCoupons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCoupons.Location = New System.Drawing.Point(302, 18)
        Me.lblTotalCoupons.Name = "lblTotalCoupons"
        Me.lblTotalCoupons.Size = New System.Drawing.Size(32, 16)
        Me.lblTotalCoupons.TabIndex = 7
        Me.lblTotalCoupons.Text = "999"
        Me.ttTips.SetToolTip(Me.lblTotalCoupons, "Total coupons issued on this box")
        '
        'pbTotalCoupons
        '
        Me.pbTotalCoupons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbTotalCoupons.BackgroundImage = CType(resources.GetObject("pbTotalCoupons.BackgroundImage"), System.Drawing.Image)
        Me.pbTotalCoupons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbTotalCoupons.Image = CType(resources.GetObject("pbTotalCoupons.Image"), System.Drawing.Image)
        Me.pbTotalCoupons.Location = New System.Drawing.Point(266, 10)
        Me.pbTotalCoupons.Name = "pbTotalCoupons"
        Me.pbTotalCoupons.Size = New System.Drawing.Size(30, 30)
        Me.pbTotalCoupons.TabIndex = 6
        Me.pbTotalCoupons.TabStop = False
        Me.ttTips.SetToolTip(Me.pbTotalCoupons, "Total coupons issued on this box")
        '
        'lblRecallCount
        '
        Me.lblRecallCount.AutoSize = True
        Me.lblRecallCount.BackColor = System.Drawing.Color.Transparent
        Me.lblRecallCount.Font = New System.Drawing.Font("Century", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecallCount.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRecallCount.Location = New System.Drawing.Point(2, 31)
        Me.lblRecallCount.Name = "lblRecallCount"
        Me.lblRecallCount.Size = New System.Drawing.Size(22, 23)
        Me.lblRecallCount.TabIndex = 8
        Me.lblRecallCount.Text = "1"
        '
        'lblStatusBar
        '
        Me.lblStatusBar.AutoEllipsis = True
        Me.lblStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblStatusBar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblStatusBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusBar.Location = New System.Drawing.Point(0, 112)
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(354, 18)
        Me.lblStatusBar.TabIndex = 9
        Me.lblStatusBar.Text = "lblStatusBar"
        '
        'lblPatientId
        '
        Me.lblPatientId.AutoSize = True
        Me.lblPatientId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatientId.Location = New System.Drawing.Point(12, 12)
        Me.lblPatientId.Name = "lblPatientId"
        Me.lblPatientId.Size = New System.Drawing.Size(86, 16)
        Me.lblPatientId.TabIndex = 10
        Me.lblPatientId.Text = "lblPatientId"
        Me.ttTips.SetToolTip(Me.lblPatientId, "Current coupon number")
        '
        'fMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 130)
        Me.Controls.Add(Me.lblPatientId)
        Me.Controls.Add(Me.lblStatusBar)
        Me.Controls.Add(Me.lblTotalCoupons)
        Me.Controls.Add(Me.pbTotalCoupons)
        Me.Controls.Add(Me.lblCouponNo)
        Me.Controls.Add(Me.pbCouponNo)
        Me.Controls.Add(Me.ppNext)
        Me.Controls.Add(Me.ppFinish)
        Me.Controls.Add(Me.ppHold)
        Me.Controls.Add(Me.ppRecall)
        Me.Controls.Add(Me.lblRecallCount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fMainForm"
        Me.Text = "Essalem - QMS - Call User"
        Me.TopMost = True
        CType(Me.ppRecall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppHold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppFinish, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ppNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCouponNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTotalCoupons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ppRecall As PictureBox
    Friend WithEvents ppHold As PictureBox
    Friend WithEvents ppFinish As PictureBox
    Friend WithEvents ppNext As PictureBox
    Friend WithEvents pbCouponNo As PictureBox
    Friend WithEvents lblCouponNo As Label
    Friend WithEvents lblTotalCoupons As Label
    Friend WithEvents pbTotalCoupons As PictureBox
    Friend WithEvents ttTips As ToolTip
    Friend WithEvents lblRecallCount As Label
    Friend WithEvents lblStatusBar As Label
    Friend WithEvents lblPatientId As Label
End Class
