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
        ActiveLbl = New Label()
        AddressLbl = New Label()
        PingLbl = New Label()
        SekLbl = New Label()
        PingBtn = New Button()
        NewGroupBtn = New Button()
        SaveBtn = New Button()
        LoadBtn = New Button()
        SuspendLayout()
        ' 
        ' ActiveLbl
        ' 
        ActiveLbl.AutoSize = True
        ActiveLbl.Location = New Point(25, 25)
        ActiveLbl.Name = "ActiveLbl"
        ActiveLbl.Size = New Size(107, 45)
        ActiveLbl.TabIndex = 6
        ActiveLbl.Text = "Active"
        ' 
        ' AddressLbl
        ' 
        AddressLbl.AutoSize = True
        AddressLbl.Location = New Point(255, 25)
        AddressLbl.Name = "AddressLbl"
        AddressLbl.Size = New Size(166, 45)
        AddressLbl.TabIndex = 7
        AddressLbl.Text = "Addresses"
        ' 
        ' PingLbl
        ' 
        PingLbl.AutoSize = True
        PingLbl.Location = New Point(555, 25)
        PingLbl.Name = "PingLbl"
        PingLbl.Size = New Size(83, 45)
        PingLbl.TabIndex = 8
        PingLbl.Text = "Ping"
        ' 
        ' SekLbl
        ' 
        SekLbl.AutoSize = True
        SekLbl.Location = New Point(670, 25)
        SekLbl.Name = "SekLbl"
        SekLbl.Size = New Size(76, 45)
        SekLbl.TabIndex = 9
        SekLbl.Text = "Sec."
        ' 
        ' PingBtn
        ' 
        PingBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        PingBtn.Cursor = Cursors.Hand
        PingBtn.Location = New Point(45, 116)
        PingBtn.Name = "PingBtn"
        PingBtn.Size = New Size(160, 52)
        PingBtn.TabIndex = 1
        PingBtn.Text = "Ping"
        ' 
        ' NewGroupBtn
        ' 
        NewGroupBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        NewGroupBtn.Location = New Point(250, 116)
        NewGroupBtn.Name = "NewGroupBtn"
        NewGroupBtn.Size = New Size(131, 52)
        NewGroupBtn.TabIndex = 2
        NewGroupBtn.Text = "New"
        ' 
        ' SaveBtn
        ' 
        SaveBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        SaveBtn.Cursor = Cursors.Hand
        SaveBtn.Location = New Point(490, 116)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(170, 52)
        SaveBtn.TabIndex = 3
        SaveBtn.Text = "Save"
        ' 
        ' LoadBtn
        ' 
        LoadBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        LoadBtn.Cursor = Cursors.Hand
        LoadBtn.Location = New Point(710, 116)
        LoadBtn.Name = "LoadBtn"
        LoadBtn.Size = New Size(170, 52)
        LoadBtn.TabIndex = 4
        LoadBtn.Text = "Load"
        ' 
        ' Pinger
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(914, 185)
        Controls.Add(ActiveLbl)
        Controls.Add(AddressLbl)
        Controls.Add(PingLbl)
        Controls.Add(SekLbl)
        Controls.Add(PingBtn)
        Controls.Add(NewGroupBtn)
        Controls.Add(LoadBtn)
        Controls.Add(SaveBtn)
        Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Pinger"
        Text = "Pinger"
        ResumeLayout(False)
        PerformLayout()
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
