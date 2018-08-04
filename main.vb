Imports Microsoft.Win32
Imports System.ServiceProcess
Imports System.IO
Imports System.Security.Cryptography
Imports System.Net
Imports System.Threading.Tasks
Imports Ionic.Zip

'Semi-rewritten, not complete yet

Public Class main
    Public dloc As String
    Dim SW As Stopwatch
    Dim dlistxt As String = Path.GetTempPath & "/BF2Updater/dlist.txt"
    Dim wc As WebClient = New WebClient
    Dim bf2ver As Integer

    Sub init()
        Dim appname As String = System.Reflection.Assembly.GetExecutingAssembly.GetName().Name
        Dim appver As String = My.Application.Info.Version.ToString
        Dim app As String = appname & " v" & appver
        Me.Text = app
    End Sub

    Private Sub main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        init()
        Dim osVer As Version = Environment.OSVersion.Version
        If osVer.Major < 6 Then
            MsgBox("Your OS isn't supported. But don't worry. You can download all files at https://dl.henryolik.ga/bf2", MsgBoxStyle.Critical, "OS isn't supported")
            Me.Close()
        End If
        If Directory.Exists(Path.GetTempPath & "BF2Updater") = True Then
            If File.Exists(Path.GetTempPath & "BF2Updater\dloc.txt") = True AndAlso File.ReadAllText(Path.GetTempPath & "BF2Updater\dloc.txt") = Nothing = False Then
                tb_dloc.Text = File.ReadAllText(Path.GetTempPath & "BF2Updater\dloc.txt")
                dloc = File.ReadAllText(Path.GetTempPath & "BF2Updater\dloc.txt")
            Else
                tb_dloc.Text = Path.GetTempPath & "BF2Updater\dl"
                dloc = Path.GetTempPath & "BF2Updater/dl"
            End If
        Else
            tb_dloc.Text = Path.GetTempPath & "BF2Updater\dl"
            dloc = Path.GetTempPath & "BF2Updater\dl"
        End If
        locate()
        If IsConnectionAvailable() = False Then
            'this is going away soon :)
            MsgBox("Connection isn't available! Please check your internet connection and try again.", MsgBoxStyle.Critical, "Error")
            Me.Close()
        Else
            CheckForUpdates()
            msg()
        End If
        check()
    End Sub

    Private Sub mi_about_Click(sender As System.Object, e As System.EventArgs) Handles mi_about.Click
        about.Show()
    End Sub

    Public Sub locate()
        Try
            Dim regkey As RegistryKey
            Dim folder As String
            regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{04858915-9F49-4B2A-AED4-DC49A7DE6A7B}", True)
            folder = regkey.GetValue("InstallLocation")
            tb_loc.Text = folder
            If My.Computer.FileSystem.DirectoryExists(tb_loc.Text) = False Then
                MsgBox("BF2 folder was not found! Please, install the game properly and try again.")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("BF2 installation was not detected. Install it properly and try again." & Environment.NewLine & ex.ToString)
            Me.Close()
        End Try
    End Sub

    Sub check()
        pb_load.Minimum = 0
        pb_load.Maximum = 100
        'Check for DX9.0c
        Dim regKey As RegistryKey
        Dim ver As String
        regKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\DirectX", True)
        ver = regKey.GetValue("Version")
        If ver = "4.09.00.0904" Then
            la_dx.Text = "INSTALLED!"
            la_dx.ForeColor = Color.Green
        End If
        'Check for BF2 version
        Dim bf2exe_sha1 As String = getfilesha1(tb_loc.Text & "/BF2.exe")
        Dim getver As String = gethash(bf2exe_sha1)
        Dim bf2hub As Boolean = False
        If getver.IndexOf(2) = 0 Then
            bf2hub = True
        End If
        bf2ver = getver.Substring(1)
        If bf2ver >= 110 Then
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
        End If
        If bf2ver >= 141 Then
            la_141.Text = "INSTALLED!"
            la_141.ForeColor = Color.Green
        End If
        If bf2ver >= 150 Then
            la_150.Text = "INSTALLED!"
            la_150.ForeColor = Color.Green
        End If
        Dim sb As New System.Text.StringBuilder(bf2ver.ToString)
        For x As Integer = sb.Length - 2 To 1 Step -1
            sb.Insert(x, ".")
        Next
        Dim dispverwoext As String = sb.ToString
        Dim dispver As String
        Dim revive As Boolean
        If dispverwoext = "1.51" Then
            revive = True
            dispverwoext = "1.50"
        End If
        If bf2hub = True Then
            dispver = dispverwoext & " BF2Hub"
        Else
            If revive = True Then
                dispver = dispverwoext & " Revive"
            Else
                dispver = dispverwoext
            End If
        End If
        la_version.Text = "Detected BF2 version: " & dispver
        'Check for BF2Hub
        If Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "/BF2Hub Client") AndAlso File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "/BF2Hub Client/bf2hub.exe") Then
            If bf2ver < 150 And bf2hub = True Then
                la_bf2hub.Text = "INSTALLED, OLD PATCH"
                la_bf2hub.ForeColor = Color.Orange
                tt_main.SetToolTip(la_bf2hub, "Make sure you have installed patch 1.50 and run BF2Hub")
                la_bf2hub.Font = New Font("Microsoft Sans Serif", 6)
                la_bf2hub.Location = New Point(la_bf2hub.Location.X, la_bf2hub.Location.Y + 3)
            End If
            If bf2ver >= 150 And bf2hub = True Then
                la_bf2hub.Text = "INSTALLED!"
                la_bf2hub.ForeColor = Color.Green
            End If
            If bf2hub = False Then
                la_bf2hub.Text = "INSTALLED, NOT PATCHED"
                la_bf2hub.ForeColor = Color.Orange
                tt_main.SetToolTip(la_bf2hub, "Run BF2Hub")
                la_bf2hub.Font = New Font("Microsoft Sans Serif", 6)
                la_bf2hub.Location = New Point(la_bf2hub.Location.X, la_bf2hub.Location.Y + 3)
            End If
        Else
            If bf2ver >= 150 And bf2hub = True Then
                la_bf2hub.Text = "NOT INSTALLED, PATCHED"
                la_bf2hub.ForeColor = Color.Orange
                tt_main.SetToolTip(la_bf2hub, "Install BF2Hub to keep your game up to date")
                la_bf2hub.Font = New Font("Microsoft Sans Serif", 6)
                la_bf2hub.Location = New Point(la_bf2hub.Location.X, la_bf2hub.Location.Y + 3)
            End If
            If bf2ver < 150 And bf2hub = True Then
                la_bf2hub.Text = "NOT INSTALLED, OLD PATCH"
                la_bf2hub.ForeColor = Color.Red
                tt_main.SetToolTip(la_bf2hub, "Make sure you have patch 1.50 installed and install and run BF2Hub")
                la_bf2hub.Font = New Font("Microsoft Sans Serif", 6)
                la_bf2hub.Location = New Point(la_bf2hub.Location.X, la_bf2hub.Location.Y + 3)
            End If
        End If
        'Check for Alt+Tab Fix
        Dim alttab_sha1 As String = getfilesha1(tb_loc.Text & "/RendDX9.dll")
        If alttab_sha1 = gethash("Alt+Tab Fix") Then
            la_atf.Text = "INSTALLED!"
            la_atf.ForeColor = Color.Green
        End If
        'Check if PunkBuster is running
        For Each s As ServiceController In ServiceController.GetServices()
            If s.ServiceName = "PnkBstrA" Then
                If s.Status = ServiceControllerStatus.Running Then
                    la_pb.Text = "RUNNING"
                    la_pb.ForeColor = Color.Green
                End If
            End If
        Next
    End Sub

    Public Sub msg()
        Dim MyVer As String = My.Application.Info.Version.ToString
        Dim osVer As Version = Environment.OSVersion.Version
        Dim wc As WebClient = New WebClient()
        Dim os As String = Nothing
        If osVer.Major = 6 And osVer.Minor = 0 Then
            os = "vista"
        End If
        If osVer.Major = 6 And osVer.Minor = 1 Then
            os = "7"
        End If
        If osVer.Major = 6 And osVer.Minor = 2 Then
            If My.Computer.Info.OSFullName.Contains("10") Then
                os = "10"
            Else
                If My.Computer.Info.OSFullName.Contains("8.1") Then
                    os = "8.1"
                Else
                    os = "8"
                End If
            End If
        End If
        If Not os = Nothing Then
            Dim msg As String = Application.StartupPath & "/msg.txt"
            wc.DownloadFile(New Uri("https://dl.henryolik.ga/bf2/updater/msgs/" & MyVer & "/" & os & ".txt"), msg)
            If Not My.Computer.FileSystem.ReadAllText(msg) = "" Then
                MsgBox(My.Computer.FileSystem.ReadAllText(msg), MsgBoxStyle.Information, "Message")
            End If
        End If
    End Sub

    Public Sub CheckForUpdates()
        If Directory.Exists(IO.Path.GetTempPath & "BF2Updater") = False Then
            Directory.CreateDirectory(IO.Path.GetTempPath & "BF2Updater")
        End If
        Dim version As String = IO.Path.GetTempPath & "BF2Updater/version.txt"
        Dim updater As String = IO.Path.GetTempPath & "BF2Updater/updater.exe"
        Dim MyVer As String = My.Application.Info.Version.ToString
        wc.DownloadFile("https://dl.henryolik.ga/f/bf2updaterver", version)
        Dim LastVer As String = My.Computer.FileSystem.ReadAllText(version)
        If Not MyVer = LastVer Then
            Dim result As Integer = MessageBox.Show("An update is available! Do you want to download it?", "Update", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                wc.DownloadFile("https://dl.henryolik.ga/f/updaterv2", updater)
                Process.Start(updater, "-bf2 -e:" & """" & Application.ExecutablePath & """")
                Me.Close()
            End If
        End If
    End Sub

    Public Function IsConnectionAvailable() As Boolean
        Dim objUrl As New System.Uri("https://dl.henryolik.ga/f/status")
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try
            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception
            objWebReq = Nothing
            Return False
        End Try
    End Function

    Sub download()
        Dim down() As String = IO.File.ReadAllLines(Path.GetTempPath & "/BF2Updater/dlist.txt")
        Dim data As String
        If down(0) = "" Then
            install()
            Exit Sub
        End If
        data = down(0)
        Dim file As String
        Dim ffile As String
        Dim uri As String
        Dim items As String() = data.Split("|".ToCharArray())
        file = items(0)
        uri = items(1)
        ffile = items(2)
        la_dl.Text = file
        SW = Stopwatch.StartNew
        AddHandler wc.DownloadProgressChanged, AddressOf download_change
        AddHandler wc.DownloadFileCompleted, AddressOf download_completed
        If My.Computer.FileSystem.DirectoryExists(dloc) = False Then
            My.Computer.FileSystem.CreateDirectory(dloc)
        End If
        wc.DownloadFileAsync(New Uri(uri), dloc & "/" & ffile)
        rml(Path.GetTempPath & "/BF2Updater/dlist.txt", 1)
    End Sub

    Public Sub rml(ByVal path As String, ByVal ln As Integer)
        Dim tb As New TextBox
        tb.Text = My.Computer.FileSystem.ReadAllText(path)
        Dim str As New List(Of String)
        Dim i As Integer = 0
        For Each l In tb.Lines
            str.Add(tb.Lines(i))
            i += 1
        Next
        str.RemoveAt(ln - 1)
        tb.Text = ""
        For Each h In str
            tb.Text = tb.Text & h & Environment.NewLine
        Next
        Dim writer As New System.IO.StreamWriter(path)
        writer.Write(tb.Text)
        writer.Close()
    End Sub

    Private Sub download_change(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim mbytesIn As Double = Double.Parse(e.BytesReceived.ToString()) / 1000000
        Dim totalmBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString()) / 1000000
        Dim percentage As Double = mbytesIn / totalmBytes * 100
        pb_load.Value = Int32.Parse(Math.Truncate(percentage).ToString())
        percentage = Math.Round(percentage, 0)
        la_perc.Text = percentage & " %"
        Dim unita As String
        If totalmBytes < 1 Then
            totalmBytes = totalmBytes * 1000
            unita = " kB"
            If totalmBytes < 1 Then
                totalmBytes = totalmBytes * 1000
                unita = " B"
            End If
        ElseIf totalmBytes > 1000 Then
            totalmBytes = totalmBytes / 1000
            unita = " GB"
        Else
            unita = " MB"
        End If
        Dim unitb As String
        If mbytesIn < 1 Then
            mbytesIn = mbytesIn * 1000
            unitb = " kB"
            If mbytesIn < 1 Then
                mbytesIn = mbytesIn * 1000
                unitb = " B"
            End If
        ElseIf mbytesIn > 1000 Then
            mbytesIn = mbytesIn / 1000
            unitb = " GB"
        Else
            unitb = " MB"
        End If
        mbytesIn = Math.Round(mbytesIn, 2)
        totalmBytes = Math.Round(totalmBytes, 2)
        la_size.Text = mbytesIn & unitb & " / " & totalmBytes & unita
        Dim speed As Double = e.BytesReceived / SW.ElapsedMilliseconds / 1000
        Dim unit As String
        If speed < 1 Then
            unit = " kB/s"
            speed = speed * 1000
            If speed < 1 Then
                unit = " B/s"
                speed = speed * 1000
            End If
        Else
            unit = " MB/s"
        End If
        speed = Math.Round(speed, 1)
        la_speed.Text = "Download speed: " & speed & unit
    End Sub

    Private Sub download_completed(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        RemoveHandler wc.DownloadProgressChanged, AddressOf download_change
        RemoveHandler wc.DownloadFileCompleted, AddressOf download_completed
        If Not e.Error Is Nothing Then
            Dim actualException = e.Error
            While actualException.InnerException IsNot Nothing
                actualException = actualException.InnerException
            End While

            MessageBox.Show("There was an error downloading the file. Error: " & actualException.Message)
        Else
            wc.Dispose()
            SW.Stop()
            download()
        End If
    End Sub

    Sub predl()
        la_dl.Text = "Checking for files, please wait..."
        IO.File.Create(dlistxt).Close()
        Using sw As StreamWriter = New StreamWriter(dlistxt)
            sw.Write(Environment.NewLine)
        End Using
        pb_load.Value = 12
        If clb_updates.CheckedItems.Contains("Patch 1.1") AndAlso clb_updates.CheckedItems.Contains("Patch 1.41") = False Then
            If bf2ver >= 110 Then
                Dim result As Integer = MessageBox.Show("Patch 1.1 is already installed, do you really want to install it again?", "Warning", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    enable()
                    Exit Sub
                End If
            End If
            My.Settings.patch11 = True
            If getfilesha1(dloc & "/bf2patch_1.1.exe") = gethash("Patch 1.1") = False Then
                dlist("Patch 1.1", "https://dl.henryolik.ga/f/bf2patch11", "bf2patch_1.1.exe")
            End If
        End If
        pb_load.Value = 24
        If clb_updates.CheckedItems.Contains("Patch 1.41") Then
            If bf2ver >= 141 Then
                Dim result As Integer = MessageBox.Show("Patch 1.41 is already installed, do you really want to install it again?", "Warning", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    enable()
                    Exit Sub
                End If
            End If
            My.Settings.patch141 = True
            If getfilesha1(dloc & "/bf2patch_1.41.exe") = gethash("Patch 1.41") = False Then
                dlist("Patch 1.41", "https://dl.henryolik.ga/f/bf2patch141", "bf2patch_1.41.exe")
            End If
        End If
        pb_load.Value = 36
        If clb_updates.CheckedItems.Contains("Patch 1.50") Then
            If bf2ver >= 150 Then
                Dim result As Integer = MessageBox.Show("Patch 1.50 is already installed, do you really want to install it again?", "Warning", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    enable()
                    Exit Sub
                End If
            ElseIf bf2ver < 141 AndAlso My.Settings.patch141 = False Then
                MsgBox("You need to install patch 1.41 first in order to install patch 1.50.")
                enable()
                Exit Sub
            End If
            My.Settings.patch150 = True
            If getfilesha1(dloc & "/bf2patch_1.50.exe") = gethash("Patch 1.50") = False Then
                dlist("Patch 1.50", "https://dl.henryolik.ga/f/bf2patch150", "bf2patch_1.50.exe")
            End If
        End If
        pb_load.Value = 48
        If clb_updates.CheckedItems.Contains("BF2Hub") Then
            If bf2ver < 150 AndAlso My.Settings.patch150 = False Then
                MsgBox("You need to install patch 1.50 first in order to install BF2Hub.")
                enable()
                Exit Sub
            End If
            My.Settings.bf2hub = True
            If getfilesha1(dloc & "/bf2hub_setup.exe") = gethash("BF2Hub") = False Then
                dlist("BF2Hub", "https://dl.henryolik.ga/f/bf2hub", "bf2hub_setup.exe")
            End If
        End If
        pb_load.Value = 60
        If clb_updates.CheckedItems.Contains("Alt+Tab Fix") Then
            If bf2ver < 150 AndAlso My.Settings.patch150 = False Then
                MsgBox("You need to install patch 1.50 first in order to install Alt+Tab fix.")
                enable()
                Exit Sub
            End If
            My.Settings.atf = True
            If getfilesha1(dloc & "/RendDX9.dll") = gethash("Alt+Tab Fix") = False Then
                dlist("Alt+Tab Fix", "https://dl.henryolik.ga/f/bf2alttabfix", "RendDX9.dll")
            End If
        End If
        pb_load.Value = 72
        If clb_updates.CheckedItems.Contains("DirectX 9.0c") Then
            My.Settings.dx = True
            If getfilesha1(dloc & "/dxsetup.exe") = gethash("DirectX 9.0c") = False Then
                dlist("DirectX 9.0c", "https://dl.henryolik.ga/f/dx90c", "dxsetup.exe")
            End If
        End If
        pb_load.Value = 84
        If clb_updates.CheckedItems.Contains("PunkBuster") Then
            My.Settings.pb = True
            If getfilesha1(dloc & "/pbsvc.exe") = gethash("PunkBuster") = False Then
                dlist("PunkBuster", "https://dl.henryolik.ga/f/punkbuster", "pbsvc.exe")
            End If
        End If
        pb_load.Value = 100
        download()
    End Sub

    Sub dlist(ByVal file As String, ByVal uri As String, ByVal ffile As String)
        Dim lines() As String = IO.File.ReadAllLines(dlistxt)
        Dim count As Integer
        count = lines.Length - 1
        Try
            lines(count) = file & "|" & uri & "|" & ffile & Environment.NewLine
            IO.File.WriteAllLines(dlistxt, lines)
        Catch ex As Exception
            MsgBox("Error!" & Environment.NewLine & ex.ToString)
        End Try
    End Sub

    Function getfilesha1(ByVal file_name As String)
        If My.Computer.FileSystem.FileExists(file_name) = False Then
            Return Nothing
        Else
            Dim hash = SHA1.Create
            Dim hashValue() As Byte
            Dim fileStream As IO.FileStream = File.OpenRead(file_name)
            fileStream.Position = 0
            hashValue = hash.ComputeHash(fileStream)
            Dim hash_hex = PrintByteArray(hashValue)
            fileStream.Close()
            Return hash_hex
        End If
    End Function

    Public Function PrintByteArray(ByVal array() As Byte)
        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("X2")
        Next i
        Return hex_value.ToLower
    End Function

    Private Sub resetdloc(sender As System.Object, e As System.EventArgs) Handles bu_reset.Click
        tb_dloc.Text = Path.GetTempPath & "BF2Updater\dl"
        dloc = Path.GetTempPath & "BF2Updater\dl"
    End Sub

    Private Sub bu_start_Click(sender As System.Object, e As System.EventArgs) Handles bu_start.Click
        disable()
        If clb_updates.CheckedItems.Count = 0 Then
            MsgBox("No update is selected!")
            enable()
        Else
            If MsgBox("Do you want to install checked updates?", MsgBoxStyle.YesNo, "Install") = MsgBoxResult.Yes Then
                predl()
            Else
                enable()
            End If
        End If
    End Sub

    Sub install()
        Dim i As Integer = -1
        Do Until i = 6
            i = i + 1
            clb_updates.SetItemChecked(i, False)
        Loop
        enable()
        MsgBox("Download complete!")
        'something big in progress :)
    End Sub

    Public Sub enable()
        about.bu_clean.Enabled = True
        bu_start.Enabled = True
        clb_updates.Enabled = True
        la_dl.Text = ""
        la_size.Text = ""
        la_speed.Text = ""
        la_perc.Text = ""
        pb_load.Value = 0
        tb_dloc.Enabled = True
        bu_reset.Enabled = True
    End Sub

    Public Sub disable()
        bu_reset.Enabled = False
        about.bu_clean.Enabled = False
        bu_start.Enabled = False
        clb_updates.Enabled = False
        la_dl.Text = ""
        la_size.Text = ""
        la_speed.Text = ""
        la_perc.Text = ""
        pb_load.Value = 0
        tb_dloc.Enabled = False
    End Sub

    Function gethash(ByVal item As String)
        Dim i As Integer = -1
        Dim line As Integer
        Dim hashlist As String = Path.GetTempPath & "/BF2Updater/hashlist.txt"
        wc.DownloadFile("https://dl.henryolik.ga/f/bf2hashlist", hashlist)
        Dim hashlst() As String = IO.File.ReadAllLines(hashlist)
        For Each j As String In hashlst
            i = i + 1
            If j.IndexOf(item) = 0 Then
                line = i
            End If
        Next
        Dim hash As String
        Dim mystr As String = hashlst(line)
        Dim cut_at As String = "|"
        Dim x As Integer = InStr(mystr, cut_at)
        hash = mystr.Substring(x + cut_at.Length - 1)
        Return hash
    End Function

    Private Sub tb_dloc_click(sender As System.Object, e As System.EventArgs) Handles tb_dloc.Click
        Dim fold As New FolderBrowserDialog
        fold.ShowNewFolderButton = True
        If fold.ShowDialog() = DialogResult.OK Then
            tb_dloc.Text = fold.SelectedPath
            Dim root As Environment.SpecialFolder = fold.RootFolder
            dloc = fold.SelectedPath
        End If
    End Sub

    Private Sub tb_dloc_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_dloc.TextChanged
        Dim dloctxt As String = Path.GetTempPath & "BF2Updater/dloc.txt"
        If Directory.Exists(Path.GetTempPath & "BF2Updater") = False Then
            Directory.CreateDirectory(Path.GetTempPath & "BF2Updater")
        Else
            If File.Exists(dloctxt) = False Then
                File.Create(dloctxt).Dispose()
            End If
        End If
        File.WriteAllText(dloctxt, tb_dloc.Text)
        dloc = tb_dloc.Text
    End Sub
End Class