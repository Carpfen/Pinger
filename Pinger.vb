Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text.Json
Imports System.Text.Json.Nodes

Public Class Pinger
    Const Version = "3.0"



    Private Sub PingBtn_Click(sender As Object, e As EventArgs) Handles PingBtn.Click
        If Not Address.pinging Then
            Address.StartAll()
        Else
            Address.StopAll()
        End If
    End Sub

    Private Sub NewGroupBtn_Click(sender As Object, e As EventArgs) Handles NewGroupBtn.Click
        Dim addr As New Address(Me, Not Address.pinging, "", 5000)
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Address.SaveAddresses()
    End Sub

    Private Sub LoadBtn_Click(sender As Object, e As EventArgs) Handles LoadBtn.Click
        Address.LoadAddresses(Me)
    End Sub

    Private Sub Pinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text &= $" ({Version})"
        If Environment.GetCommandLineArgs.Length > 1 Then
            Address.LoadAddresses(Me, Environment.GetCommandLineArgs(1))
        Else
            Dim a As New Address(Me, True, "", 5000)
        End If
    End Sub
End Class



Public Class Address
    Public Shared pinging As Boolean = False
    Private Shared addresses As New List(Of Address)

    Private id As Integer = 0
    Private pinger As Pinger
    Private active As Boolean
    Private success As Boolean = True
    Private startTime As DateTime

    Private ReadOnly panel As Panel
    Private ReadOnly ActiveBtn As Button
    Private ReadOnly AddressBox As TextBox
    Private ReadOnly PingLbl As Label
    Private ReadOnly SecBox As TextBox
    Private ReadOnly DeleteBtn As Button
    Private ReadOnly timer As New Timer
    Private ReadOnly pingSender As New Ping



    Public Sub New(ByRef pinger As Pinger, active As Boolean, address As String, sec As Integer)
        Me.pinger = pinger
        id = addresses.Count
        panel = New Panel With {
            .Location = New Point(0, 80 + id * (45 + 10)),
            .Size = New Size(900, 45)
        }

        ' 
        ' ActiveBtn
        ' 
        ActiveBtn = New Button With {
            .Cursor = Cursors.Hand,
            .BackColor = Color.Transparent,
            .BackgroundImageLayout = ImageLayout.Stretch,
            .FlatStyle = FlatStyle.Flat,
            .Location = New Point(45, 0),
            .Size = New Size(43, 43)
        }
        ActiveBtn.FlatAppearance.BorderSize = 0
        ActiveBtn.FlatAppearance.MouseDownBackColor = Color.Transparent
        ActiveBtn.FlatAppearance.MouseOverBackColor = Color.Transparent
        AddHandler ActiveBtn.Click, AddressOf ActiveBtn_Click
        panel.Controls.Add(ActiveBtn)

        ' 
        ' AddressBox
        ' 
        AddressBox = New TextBox With {
            .BorderStyle = BorderStyle.None,
            .PlaceholderText = "Address",
            .Location = New Point(140, 0),
            .Size = New Size(380, 43),
            .Text = address,
            .TextAlign = HorizontalAlignment.Center
        }
        panel.Controls.Add(AddressBox)

        ' 
        ' PingLbl
        ' 
        PingLbl = New Label With {
            .BackColor = SystemColors.Window,
            .Location = New Point(560, 0),
            .Size = New Size(70, 43),
            .Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0)),
            .Text = "-",
            .TextAlign = ContentAlignment.MiddleCenter
        }
        panel.Controls.Add(PingLbl)

        ' 
        ' SecBox
        ' 
        SecBox = New TextBox With {
            .BorderStyle = BorderStyle.None,
            .MaxLength = 4,
            .PlaceholderText = "x",
            .Location = New Point(670, 0),
            .Size = New Size(70, 43),
            .Text = (sec / 1000).ToString,
            .TextAlign = HorizontalAlignment.Center
        }
        panel.Controls.Add(SecBox)

        ' 
        ' DeleteBtn
        ' 
        DeleteBtn = New Button With {
            .Cursor = Cursors.Hand,
            .BackColor = Color.Transparent,
            .BackgroundImage = My.Resources.Resources.trash,
            .BackgroundImageLayout = ImageLayout.Stretch,
            .FlatStyle = FlatStyle.Flat,
            .Location = New Point(820, 0),
            .Size = New Size(43, 43)
        }
        DeleteBtn.FlatAppearance.BorderSize = 0
        DeleteBtn.FlatAppearance.MouseDownBackColor = Color.Transparent
        DeleteBtn.FlatAppearance.MouseOverBackColor = Color.Transparent
        AddHandler DeleteBtn.Click, AddressOf DeleteBtn_Click
        panel.Controls.Add(DeleteBtn)


        ' Timer
        timer = New Timer With {
            .Interval = sec
        }
        AddHandler timer.Tick, AddressOf Timer_Tick
        startTime = DateTime.Now

        ChangeActive(active)
        pinger.ClientSize = New Size(pinger.ClientSize.Width, pinger.ClientSize.Height + 55)
        pinger.Controls.Add(panel)
        addresses.Add(Me)
    End Sub


    Public Function Check() As Boolean
        Dim number As Double
        If Not Double.TryParse(SecBox.Text, number) OrElse number <= 0 Then
            MsgBox($"The seconds in line {id + 1} are invalid.", MsgBoxStyle.Critical, "Invalid seconds")
            Return False
        Else
            timer.Interval = number * 1000
        End If
        If AddressBox.Text = "" Then
            MsgBox($"The address in line {id + 1} is empty.", MsgBoxStyle.Critical, "Empty address")
            Return False
        End If
        Return True
    End Function


    Public Sub ChangeActive(act As Boolean)
        If act Then
            If Not pinging OrElse Check() Then
                active = True
                ActiveBtn.BackgroundImage = My.Resources.Resources.active
                If pinging Then
                    StartPing()
                End If
            End If
        Else
            active = False
            ActiveBtn.BackgroundImage = My.Resources.Resources.inactive
            If pinging Then
                StopPing()
            End If
        End If
    End Sub


    Public Sub StartPing()
        If active Then
            success = True
            AddressBox.ReadOnly = True
            AddressBox.BackColor = Color.Orange
            AddressBox.TabStop = False
            SecBox.ReadOnly = True
            SecBox.TabStop = False
            timer.Start()
            Task.Run(Sub() Ping())
        End If
    End Sub

    Public Sub StopPing()
        timer.Stop()
        If Not success Then
            LogFail()
        End If
        AddressBox.ReadOnly = False
        AddressBox.BackColor = SystemColors.Window
        AddressBox.TabStop = True
        PingLbl.Text = "-"
        SecBox.ReadOnly = False
        SecBox.TabStop = True
    End Sub


    Private Sub Ping()
        Dim time As Long = -1
        Dim s As Boolean = success
        If s Then startTime = DateTime.Now

        If pinging AndAlso active Then
            Try
                Dim reply As PingReply = pingSender.Send(AddressBox.Text)
                If reply.Status = IPStatus.Success Then
                    time = reply.RoundtripTime
                End If
            Catch ex As Exception
                time = -1
            End Try

            If pinging AndAlso active Then
                If time > 0 Then
                    If Not s Then
                        success = True
                        LogFail()
                    End If
                    PingLbl.BeginInvoke(Sub() PingLbl.Text = time.ToString)
                    AddressBox.BackColor = Color.Green
                Else
                    If success Then
                        success = False
                    End If
                    PingLbl.BeginInvoke(Sub() PingLbl.Text = "-")
                    AddressBox.BackColor = Color.Red
                End If
            End If
        End If
    End Sub



    Private Sub ActiveBtn_Click(sender As Object, e As EventArgs)
        ChangeActive(Not active)
        pinger.PingBtn.Focus()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs)
        ' Stoppe den Timer
        If pinging AndAlso active Then
            timer.Stop()
        End If

        ' Lösche Panel und gebe frei
        For Each c As Control In panel.Controls
            c.Dispose()
        Next
        pinger.Controls.Remove(panel)
        panel.Dispose()

        ' alle Panels um 55 weiter nach unten setzen
        For i As Integer = id + 1 To addresses.Count - 1
            Dim a As Address = addresses(i)
            a.panel.Location = New Point(a.panel.Location.X, a.panel.Location.Y - 55)
            a.id -= 1
        Next
        pinger.ClientSize = New Size(pinger.ClientSize.Width, pinger.ClientSize.Height - 55)
        addresses.RemoveAt(id)

        If addresses.Count = 0 Then
            StopAll()
        End If

        pinger.PingBtn.Focus()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        Task.Run(Sub() Ping())
    End Sub


    Private Sub LogFail()
        Dim writer As New StreamWriter("FailedPingLog.txt", True)
        writer.WriteLine($"Failded pings to [{AddressBox.Text}] from [{startTime}] to [{DateTime.Now}]")
        writer.Close()
        writer.Dispose()
    End Sub



    Public Shared Function StartAll() As Boolean
        If addresses.Count <> 0 Then
            For Each a As Address In addresses
                If a.active AndAlso Not a.Check() Then Return False
            Next
            pinging = True
            For Each a As Address In addresses
                a.StartPing()
            Next
            Pinger.PingBtn.Text = "Stop"
            Pinger.SaveBtn.Enabled = False
            Pinger.LoadBtn.Enabled = False
            Return True
        Else
            MsgBox("There are no addresses to ping.", MsgBoxStyle.Critical, "No addresses")
            Return False
        End If
    End Function

    Public Shared Sub StopAll()
        pinging = False
        For Each a As Address In addresses
            a.StopPing()
        Next
        Pinger.PingBtn.Text = "Ping"
        Pinger.SaveBtn.Enabled = True
        Pinger.LoadBtn.Enabled = True
    End Sub



    Public Shared Sub SaveAddresses()
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Title = "Save Config"
        saveDialog.Filter = "*.ckping|*.ckping"
        saveDialog.FileName = "config.ckping"
        saveDialog.InitialDirectory = Environment.CurrentDirectory
        If saveDialog.ShowDialog() = DialogResult.OK Then
            Dim addrList As New JsonArray()
            For Each a As Address In addresses
                Dim addrGroup As New JsonObject From {
                    {"active", a.active},
                    {"address", a.AddressBox.Text},
                    {"interval", CDbl(a.SecBox.Text)}
                }
                addrList.Add(addrGroup)
            Next
            Try
                Dim writer As New StreamWriter(saveDialog.FileName)
                writer.Write(addrList.ToJsonString(New JsonSerializerOptions With {.WriteIndented = True}))
                writer.Close()
                writer.Dispose()
            Catch ex As Exception
                MsgBox($"An error occured while saving: {vbCrLf & ex.Message}", MsgBoxStyle.Critical, "Error while saving")
            End Try
        End If
    End Sub

    Public Shared Sub LoadAddresses(pinger As Pinger, Optional fileName As String = "")
        If fileName = "" Then
            Dim openDialog As New OpenFileDialog
            openDialog.Title = "Load Config"
            openDialog.Filter = "*.ckping|*.ckping|All Files|*.*"
            openDialog.InitialDirectory = Environment.CurrentDirectory
            openDialog.Multiselect = False
            If openDialog.ShowDialog() = DialogResult.OK Then
                fileName = openDialog.FileName
            End If
        End If

        Try
            Dim reader As New StreamReader(fileName)
            Dim addrList As JsonArray = JsonNode.Parse(reader.ReadToEnd()).AsArray()
            reader.Close()
            reader.Dispose()

            For i As Integer = 0 To addrList.Count - 1
                Dim addrGroup As JsonObject = addrList(i).AsObject()
                Dim a As New Address(pinger, addrGroup("active").GetValue(Of Boolean), addrGroup("address").GetValue(Of String), addrGroup("interval").GetValue(Of Double) * 1000)
            Next
        Catch ex As Exception
            MsgBox($"An error occured while loading: {vbCrLf & ex.Message}", MsgBoxStyle.Critical, "Error while loading")
        End Try
    End Sub
End Class