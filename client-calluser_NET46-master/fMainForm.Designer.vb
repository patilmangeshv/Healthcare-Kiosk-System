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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMainForm))
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.ssDeskNo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ssLoggedInUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnHold = New System.Windows.Forms.Button()
        Me.btnRecall = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblTotalCoupon = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lPatientName = New System.Windows.Forms.Label()
        Me.lblCouponNo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ssMain.SuspendLayout()
        Me.gbMain.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssMain
        '
        Me.ssMain.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssDeskNo, Me.ssLoggedInUser})
        Me.ssMain.Location = New System.Drawing.Point(0, 180)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Padding = New System.Windows.Forms.Padding(2, 0, 26, 0)
        Me.ssMain.Size = New System.Drawing.Size(693, 30)
        Me.ssMain.TabIndex = 0
        Me.ssMain.Text = "StatusStrip1"
        '
        'ssDeskNo
        '
        Me.ssDeskNo.Name = "ssDeskNo"
        Me.ssDeskNo.Size = New System.Drawing.Size(117, 25)
        Me.ssDeskNo.Text = "Desk No.: {0}"
        '
        'ssLoggedInUser
        '
        Me.ssLoggedInUser.Name = "ssLoggedInUser"
        Me.ssLoggedInUser.Size = New System.Drawing.Size(128, 25)
        Me.ssLoggedInUser.Text = "Username: {0}"
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.GroupBox1)
        Me.gbMain.Controls.Add(Me.lblTotalCoupon)
        Me.gbMain.Controls.Add(Me.PictureBox2)
        Me.gbMain.Controls.Add(Me.btnFinish)
        Me.gbMain.Controls.Add(Me.btnNext)
        Me.gbMain.Controls.Add(Me.btnHold)
        Me.gbMain.Controls.Add(Me.btnRecall)
        Me.gbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMain.Location = New System.Drawing.Point(0, 0)
        Me.gbMain.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Padding = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.gbMain.Size = New System.Drawing.Size(693, 180)
        Me.gbMain.TabIndex = 1
        Me.gbMain.TabStop = False
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.BackColor = System.Drawing.Color.Yellow
        Me.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFinish.ForeColor = System.Drawing.Color.Black
        Me.btnFinish.Location = New System.Drawing.Point(399, 106)
        Me.btnFinish.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(120, 50)
        Me.btnFinish.TabIndex = 2
        Me.btnFinish.Text = "&Finish"
        Me.btnFinish.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.Location = New System.Drawing.Point(544, 106)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(120, 50)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "&Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnHold
        '
        Me.btnHold.BackColor = System.Drawing.Color.Red
        Me.btnHold.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHold.ForeColor = System.Drawing.Color.White
        Me.btnHold.Location = New System.Drawing.Point(174, 106)
        Me.btnHold.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnHold.Name = "btnHold"
        Me.btnHold.Size = New System.Drawing.Size(120, 50)
        Me.btnHold.TabIndex = 0
        Me.btnHold.Text = "&Hold"
        Me.btnHold.UseVisualStyleBackColor = False
        '
        'btnRecall
        '
        Me.btnRecall.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnRecall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecall.ForeColor = System.Drawing.Color.White
        Me.btnRecall.Location = New System.Drawing.Point(27, 106)
        Me.btnRecall.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRecall.Name = "btnRecall"
        Me.btnRecall.Size = New System.Drawing.Size(120, 50)
        Me.btnRecall.TabIndex = 0
        Me.btnRecall.Text = "&Recall"
        Me.btnRecall.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(542, 34)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'lblTotalCoupon
        '
        Me.lblTotalCoupon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCoupon.AutoSize = True
        Me.lblTotalCoupon.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCoupon.Location = New System.Drawing.Point(591, 42)
        Me.lblTotalCoupon.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotalCoupon.Name = "lblTotalCoupon"
        Me.lblTotalCoupon.Size = New System.Drawing.Size(51, 25)
        Me.lblTotalCoupon.TabIndex = 8
        Me.lblTotalCoupon.Text = "999"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCouponNo)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.lPatientName)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 77)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Patient"
        '
        'lPatientName
        '
        Me.lPatientName.AutoSize = True
        Me.lPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lPatientName.Location = New System.Drawing.Point(8, 34)
        Me.lPatientName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lPatientName.Name = "lPatientName"
        Me.lPatientName.Size = New System.Drawing.Size(105, 20)
        Me.lPatientName.TabIndex = 1
        Me.lPatientName.Text = "Patient Name"
        '
        'lblCouponNo
        '
        Me.lblCouponNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCouponNo.AutoSize = True
        Me.lblCouponNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCouponNo.Location = New System.Drawing.Point(441, 30)
        Me.lblCouponNo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCouponNo.Name = "lblCouponNo"
        Me.lblCouponNo.Size = New System.Drawing.Size(51, 25)
        Me.lblCouponNo.TabIndex = 9
        Me.lblCouponNo.Text = "999"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(392, 22)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'fMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 210)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.ssMain)
        Me.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ESSALEM-Queue Management System - Call User"
        Me.TopMost = True
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ssMain As StatusStrip
    Friend WithEvents ssDeskNo As ToolStripStatusLabel
    Friend WithEvents ssLoggedInUser As ToolStripStatusLabel
    Friend WithEvents gbMain As GroupBox
    Friend WithEvents btnRecall As Button
    Friend WithEvents btnFinish As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnHold As Button
    Friend WithEvents lblTotalCoupon As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lPatientName As Label
    Friend WithEvents lblCouponNo As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
