<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pinger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pinger))
        Me.ActiveLbl = New System.Windows.Forms.Label()
        Me.AddressLbl = New System.Windows.Forms.Label()
        Me.PingLbl = New System.Windows.Forms.Label()
        Me.SekLbl = New System.Windows.Forms.Label()
        Me.PingBtn = New System.Windows.Forms.Button()
        Me.NewGroupBtn = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.LoadBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ActiveLbl
        '
        Me.ActiveLbl.AutoSize = True
        Me.ActiveLbl.Location = New System.Drawing.Point(25, 25)
        Me.ActiveLbl.Name = "ActiveLbl"
        Me.ActiveLbl.Size = New System.Drawing.Size(107, 45)
        Me.ActiveLbl.TabIndex = 6
        Me.ActiveLbl.Text = "Active"
        '
        'AddressLbl
        '
        Me.AddressLbl.AutoSize = True
        Me.AddressLbl.Location = New System.Drawing.Point(255, 25)
        Me.AddressLbl.Name = "AddressLbl"
        Me.AddressLbl.Size = New System.Drawing.Size(166, 45)
        Me.AddressLbl.TabIndex = 7
        Me.AddressLbl.Text = "Addresses"
        '
        'PingLbl
        '
        Me.PingLbl.AutoSize = True
        Me.PingLbl.Location = New System.Drawing.Point(555, 25)
        Me.PingLbl.Name = "PingLbl"
        Me.PingLbl.Size = New System.Drawing.Size(83, 45)
        Me.PingLbl.TabIndex = 8
        Me.PingLbl.Text = "Ping"
        '
        'SekLbl
        '
        Me.SekLbl.AutoSize = True
        Me.SekLbl.Location = New System.Drawing.Point(670, 25)
        Me.SekLbl.Name = "SekLbl"
        Me.SekLbl.Size = New System.Drawing.Size(76, 45)
        Me.SekLbl.TabIndex = 9
        Me.SekLbl.Text = "Sec."
        '
        'PingBtn
        '
        Me.PingBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PingBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PingBtn.Location = New System.Drawing.Point(45, 116)
        Me.PingBtn.Name = "PingBtn"
        Me.PingBtn.Size = New System.Drawing.Size(160, 52)
        Me.PingBtn.TabIndex = 1
        Me.PingBtn.Text = "Ping"
        '
        'NewGroupBtn
        '
        Me.NewGroupBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NewGroupBtn.Location = New System.Drawing.Point(250, 116)
        Me.NewGroupBtn.Name = "NewGroupBtn"
        Me.NewGroupBtn.Size = New System.Drawing.Size(131, 52)
        Me.NewGroupBtn.TabIndex = 2
        Me.NewGroupBtn.Text = "New"
        '
        'SaveBtn
        '
        Me.SaveBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SaveBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveBtn.Location = New System.Drawing.Point(490, 116)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(170, 52)
        Me.SaveBtn.TabIndex = 3
        Me.SaveBtn.Text = "Save"
        '
        'LoadBtn
        '
        Me.LoadBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LoadBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadBtn.Location = New System.Drawing.Point(710, 116)
        Me.LoadBtn.Name = "LoadBtn"
        Me.LoadBtn.Size = New System.Drawing.Size(170, 52)
        Me.LoadBtn.TabIndex = 4
        Me.LoadBtn.Text = "Load"
        '
        'Pinger
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(914, 185)
        Me.Controls.Add(Me.ActiveLbl)
        Me.Controls.Add(Me.AddressLbl)
        Me.Controls.Add(Me.PingLbl)
        Me.Controls.Add(Me.SekLbl)
        Me.Controls.Add(Me.PingBtn)
        Me.Controls.Add(Me.NewGroupBtn)
        Me.Controls.Add(Me.LoadBtn)
        Me.Controls.Add(Me.SaveBtn)
        Me.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Pinger"
        Me.Text = "Pinger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActiveLbl As Label
    Friend WithEvents AddressLbl As Label
    Friend WithEvents PingLbl As Label
    Friend WithEvents SekLbl As Label
    Friend WithEvents PingBtn As Button
    Friend WithEvents NewGroupBtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents LoadBtn As Button

End Class
