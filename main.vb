Imports Microsoft.Win32
Imports System.ServiceProcess
Imports System.IO
Imports System.Security.Cryptography
Imports System.Net

Public Class main
    Dim SW As Stopwatch
    Dim dl As Boolean
    Dim bf2ver As String = "Unknown"
    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mi_about.Click
        about.Show()
    End Sub

    Public Sub locate()
        Try
            Dim regkey As RegistryKey
            Dim folder As String
            regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{04858915-9F49-4B2A-AED4-DC49A7DE6A7B}", True)
            folder = regkey.GetValue("InstallLocation")
            If Directory.Exists(folder) = False Then
                MsgBox("BF2 installation was detected, but folder doesn't exist. Install it, please, from the CD via installator or from https://bf2.ministudios.ml.")
                tb_loc.Text = "NOT DETECTED"
                clb_updates.Items.Remove("Patch 1.41")
                clb_updates.Items.Remove("Patch 1.50")
                clb_updates.Items.Remove("BF2hub")
                clb_updates.Items.Remove("Alt+Tab Fix")
                clb_updates.Items.Insert(0, ".")
                clb_updates.Items.Insert(0, ".")
                clb_updates.Items.Insert(0, ".")
                clb_updates.Items.Insert(0, ".")
                la_141.Hide()
                la_150.Hide()
                la_bf2hub.Hide()
                la_atf.Hide()
            End If
            If My.Computer.FileSystem.DirectoryExists(tb_loc.Text) = False Then
                MsgBox("Installation folder was not found! Install the game from DVD or from https://bf2.ministudios.ml")
            End If
            tb_loc.Text = folder
        Catch ex As Exception
            MsgBox(ex.ToString & " BF2 installation was not detected. Install it, please, from the CD via installator or from https://bf2.ministudios.ml.")
            tb_loc.Text = "NOT DETECTED"
        End Try
    End Sub

    Public Sub check()
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
        Else
            clb_updates.SetItemCheckState(5, CheckState.Checked)
        End If
        'Check for BF2 version
        Dim bf2exe_sha1 As String = getfilesha1(tb_loc.Text & "/BF2.exe")
        If bf2exe_sha1 = "aa5d39541c6dcda42f766eefead02ebbbcb10525" Then
            bf2ver = "1.50 BF2hub"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            la_141.Text = "INSTALLED!"
            la_141.ForeColor = Color.Green
            la_150.Text = "INSTALLED!"
            la_150.ForeColor = Color.Green
            If My.Computer.FileSystem.FileExists("C:\Program Files (x86)\BF2Hub Client\bf2hub.exe") Then
                la_bf2hub.Text = "INSTALLED!"
                la_bf2hub.ForeColor = Color.Green
            End If
        End If
        If bf2exe_sha1 = "3681849f05f6963223c74d98066fbbc9b8520a15" Then
            bf2ver = "1.50"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            la_141.Text = "INSTALLED!"
            la_141.ForeColor = Color.Green
            la_150.Text = "INSTALLED!"
            la_150.ForeColor = Color.Green
            clb_updates.SetItemCheckState(3, CheckState.Checked)
        End If
        If bf2exe_sha1 = "c3bd54bbf23a3b727ae245b14784e3dbd78c525f" Then
            bf2ver = "1.0/1.01"
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "72515c2641ea4e241b252eefd9fbaee0f33cbb38" Then
            bf2ver = "1.03"
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "30a0071d82a42c2d7e908069b58dbc40d7f1699b" Then
            bf2ver = "1.1"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "0ba2bcef97513a1cc770f8bd383e198c43612642" Then
            bf2ver = "1.12"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "243527754c7aa03bb5af43c6308ab89753ce510f" Then
            bf2ver = "1.2"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "8afa4a0febfcf2b9a4aa6177fa51c33902ec4f6d" Then
            bf2ver = "1.21"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "786b41c4660b62fd42fe9935a12fe815dd23a80b" Then
            bf2ver = "1.22"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "6197bfc5310b86bbf0ecffb96e308cadf9fa52f0" Then
            bf2ver = "1.3"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "6c2224b348b90710624607c24af7aa78f2204536" Then
            bf2ver = "1.4"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            clb_updates.SetItemCheckState(1, CheckState.Checked)
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        If bf2exe_sha1 = "85b27c0ee23cc3a1a67e1c2fe66ff4049e40fa42" Then
            bf2ver = "1.41"
            la_11.Text = "INSTALLED!"
            la_11.ForeColor = Color.Green
            la_141.Text = "INSTALLED!"
            la_141.ForeColor = Color.Green
            clb_updates.SetItemCheckState(2, CheckState.Checked)
        End If
        la_version.Text = "Detected BF2 version: " & bf2ver
        'Check for Alt+Tab fix
        Dim alttab_sha1 As String = getfilesha1(tb_loc.Text & "/RendDX9.dll")
        If alttab_sha1 = "5f92d7dfdf36ba3b1f5feab7228a90c4fc331764" Then
            la_atf.Text = "INSTALLED!"
            la_atf.ForeColor = Color.Green
        Else
            clb_updates.SetItemCheckState(4, CheckState.Checked)
        End If
        'Check if PunkBuster is running
        For Each s As ServiceController In ServiceController.GetServices()
            If s.ServiceName = "PnkBstrA" Then
                If s.Status = ServiceControllerStatus.Running Then
                    la_pb.Text = "RUNNING"
                    la_pb.ForeColor = Color.Green
                Else
                    clb_updates.SetItemCheckState(6, CheckState.Checked)
                End If
            End If
        Next
    End Sub

    Private Sub bu_click(sender As System.Object, e As System.EventArgs) Handles bu_start.Click
        If clb_updates.CheckedItems.Count = 0 Then
            MsgBox("No update is selected!")
            enable()
        Else
            If MsgBox("Do you want to install checked updates?", MsgBoxStyle.YesNo, "Install") = MsgBoxResult.Yes Then
                predl()
            End If
        End If
    End Sub

    Private Sub main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim osVer As Version = Environment.OSVersion.Version
        If osVer.Major = 5 And osVer.Minor = 1 Then
            MsgBox("Windows XP isn't supported. You can download all files at https://dl.ministudios.ml/bf2", MsgBoxStyle.Critical, "OS isn't supported")
            Me.Close()
        End If
        If IsConnectionAvailable() = False Then
            MsgBox("Connection isn't available! Please check your internet connection and try again.", MsgBoxStyle.Critical, "Error")
            Me.Close()
        Else
            CheckForUpdates()
        End If
        check()
        locate()
    End Sub

    Function getfilesha1(ByVal file_name As String)
        Dim hash = SHA1.Create
        Dim hashValue() As Byte
        Dim fileStream As IO.FileStream = File.OpenRead(file_name)
        fileStream.Position = 0
        hashValue = hash.ComputeHash(fileStream)
        Dim hash_hex = PrintByteArray(hashValue)
        fileStream.Close()
        Return hash_hex
    End Function

    Public Function PrintByteArray(ByVal array() As Byte)
        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("X2")
        Next i
        Return hex_value.ToLower
    End Function

    Sub download(ByVal file As String, ByVal uri As String, ByVal ffile As String)
        la_dl.Text = file
        SW = Stopwatch.StartNew
        Dim client As WebClient = New WebClient
        AddHandler client.DownloadProgressChanged, AddressOf download_change
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "/dl") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "/dl")
        End If
        client.DownloadFileAsync(New Uri(uri), Application.StartupPath & "/dl/" & ffile)
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

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        dl = True
        SW.Stop()
        predl()
    End Sub

    Private Sub install()
        la_dl.Text = "Installing..."
        If My.Settings.patch11 = True Or My.Settings.patch141 = True Or My.Settings.patch150 = True Or My.Settings.bf2hub = True Or My.Settings.dx = True Or My.Settings.pb = True Then
            MsgBox("Updates will now install. If you'll be prompted to restart your PC, choose restart later. It'll be better for everyone :)", MsgBoxStyle.Exclamation, "Warning")
        End If
        If My.Settings.patch11 = True Then
            la_dl.Text = "Patch 1.1"
            pb_load.Value = 50
            Process.Start(Application.StartupPath & "/dl/bf2patch_1.1.exe").WaitForExit(3600000)
            pb_load.Value = 100
            My.Settings.patch11 = False
        End If
        If My.Settings.patch141 = True Then
            la_dl.Text = "Patch 1.41"
            pb_load.Value = 50
                Process.Start(Application.StartupPath & "/dl/bf2patch_1.41.exe").WaitForExit(3600000)
            My.Settings.patch141 = False
            pb_load.Value = 100
            End If
        If My.Settings.patch150 = True Then
            la_dl.Text = "Patch 1.50"
            pb_load.Value = 50
            If bf2ver = "1.41" Then
                Process.Start(Application.StartupPath & "/dl/bf2patch_1.50.exe").WaitForExit(3600000)
                My.Settings.patch150 = False
                pb_load.Value = 100
            Else
                MsgBox("Patch 1.41 is required to install patch 1.50")
                My.Settings.patch150 = False
                pb_load.Value = 100
            End If
        End If
        If My.Settings.bf2hub = True Then
            la_dl.Text = "BF2Hub"
            pb_load.Value = 50
            Process.Start(Application.StartupPath & "/dl/bf2hub_setup.exe").WaitForExit(3600000)
            My.Settings.bf2hub = False
            pb_load.Value = 100
        End If
        If My.Settings.atf = True Then
            la_dl.Text = "Alt+Tab Fix"
            pb_load.Value = 50
            Dim regkey As RegistryKey
            Dim folder As String
            regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{04858915-9F49-4B2A-AED4-DC49A7DE6A7B}", True)
            folder = regkey.GetValue("InstallLocation")
            If File.Exists(folder & "/RendDX9-backup.dll") = False Then
                File.Copy(folder & "/RendDX9.dll", folder & "/RendDX9-backup.dll", True)
            End If
            File.Copy(Application.StartupPath & "/dl/RendDX9.dll", folder & "/RendDX9.dll", True)
            My.Settings.atf = False
            pb_load.Value = 100
        End If
        If My.Settings.dx = True Then
            la_dl.Text = "DirectX 9.0c"
            pb_load.Value = 50
            Process.Start(Application.StartupPath & "/dl/dxsetup.exe").WaitForExit(3600000)
            Threading.Thread.Sleep(1000)
            My.Settings.dx = False
            pb_load.Value = 100
        End If
        If My.Settings.pb = True Then
            la_dl.Text = "PunkBuster"
            pb_load.Value = 50
            Process.Start(Application.StartupPath & "/dl/pbsvc.exe").WaitForExit(3600000)
            Threading.Thread.Sleep(1000)
            My.Settings.pb = False
            pb_load.Value = 100
        End If
        enable()
        check()
        MsgBox("Done!")
    End Sub

    Private Sub predl()
        If clb_updates.CheckedItems.Count = 0 And dl = True Then
            disable()
            install()
        Else
            disable()
            la_dl.Text = "Checking for files..."
            dl = False
            If clb_updates.CheckedItems.Contains("Patch 1.1") Then
                My.Settings.patch11 = True
                If File.Exists(Application.StartupPath & "/dl/bf2patch_1.1.exe") Then
                    If getfilesha1(Application.StartupPath & "/dl/bf2patch_1.1.exe") = "f30c27ff0f1398c11c0065d415eb79c6def1ea2d" = False Then
                        download("Patch 1.1", "https://dl.ministudios.ml/bf2/patches/bf2patch_1.1.exe", "bf2patch_1.1.exe")
                    Else
                        clb_updates.Items.RemoveAt(0)
                        clb_updates.Items.Insert(0, "Patch 1.1")
                        dl = True
                        predl()
                    End If
                Else
                    download("Patch 1.1", "https://dl.ministudios.ml/bf2/patches/bf2patch_1.1.exe", "bf2patch_1.1.exe")
                End If
                clb_updates.Items.RemoveAt(0)
                clb_updates.Items.Insert(0, "Patch 1.1")
            Else
                If clb_updates.CheckedItems.Contains("Patch 1.41") Then
                    My.Settings.patch141 = True
                    If File.Exists(Application.StartupPath & "/dl/bf2patch_1.41.exe") Then
                        If getfilesha1(Application.StartupPath & "/dl/bf2patch_1.41.exe") = "4956f67dbe8873d20f40f87e051f08170420e164" = False Then
                            download("Patch 1.41", "https://dl.ministudios.ml/bf2/patches/bf2patch_1.41.exe", "bf2patch_1.41.exe")
                        Else
                            clb_updates.Items.RemoveAt(1)
                            clb_updates.Items.Insert(1, "Patch 1.41")
                            dl = True
                            predl()
                        End If
                    Else
                        download("Patch 1.41", "https://dl.ministudios.ml/bf2/patches/bf2patch_1.41.exe", "bf2patch_1.41.exe")
                    End If
                    clb_updates.Items.RemoveAt(1)
                    clb_updates.Items.Insert(1, "Patch 1.41")
                Else
                    If clb_updates.CheckedItems.Contains("Patch 1.50") Then
                        My.Settings.patch150 = True
                        If File.Exists(Application.StartupPath & "/dl/bf2patch_1.50.exe") Then
                            If getfilesha1(Application.StartupPath & "/dl/bf2patch_1.50.exe") = "578e66b5695723ce375f52bef780d853220734cc" = False Then
                                download("Patch 1.50", "https://dl.ministudios.ml/bf2/patches/bf2patch_1.50.exe", "bf2patch_1.50.exe")
                            Else
                                clb_updates.Items.RemoveAt(2)
                                clb_updates.Items.Insert(2, "Patch 1.50")
                                dl = True
                                predl()
                            End If
                        Else
                            download("Patch 1.50", "https://dl.ministudios.ml/bf2/patches/bf2patch_1.50.exe", "bf2patch_1.50.exe")
                        End If
                        clb_updates.Items.RemoveAt(2)
                        clb_updates.Items.Insert(2, "Patch 1.50")
                    Else
                        If clb_updates.CheckedItems.Contains("BF2Hub") Then
                            My.Settings.bf2hub = True
                            If File.Exists(Application.StartupPath & "/dl/bf2hub_setup.exe") Then
                                If getfilesha1(Application.StartupPath & "/dl/bf2hub_setup.exe") = "92b6fc5af14c7b20d0a909b19570ae3337b89193" = False Then
                                    download("BF2Hub", "https://www.bf2hub.com/downloads/bf2hub-client-setup.exe", "bf2hub_setup.exe")
                                Else
                                    clb_updates.Items.RemoveAt(3)
                                    clb_updates.Items.Insert(3, "BF2Hub")
                                    dl = True
                                    predl()
                                End If
                            Else
                                download("BF2Hub", "https://www.bf2hub.com/downloads/bf2hub-client-setup.exe", "bf2hub_setup.exe")
                            End If
                            clb_updates.Items.RemoveAt(3)
                            clb_updates.Items.Insert(3, "BF2hub")
                        Else
                            If clb_updates.CheckedItems.Contains("Alt+Tab Fix") Then
                                My.Settings.atf = True
                                If File.Exists(Application.StartupPath & "/dl/RendDX9.dll") Then
                                    If getfilesha1(Application.StartupPath & "/dl/RendDX9.dll") = "5f92d7dfdf36ba3b1f5feab7228a90c4fc331764" = False Then
                                        download("Alt+Tab Fix", "https://dl.ministudios.ml/bf2/RendDX9.dll", "RendDX9.dll")
                                    Else
                                        clb_updates.Items.RemoveAt(4)
                                        clb_updates.Items.Insert(4, "Alt+Tab Fix")
                                        dl = True
                                        predl()
                                    End If
                                Else
                                    download("Alt+Tab Fix", "https://dl.ministudios.ml/bf2/RendDX9.dll", "RendDX9.dll")
                                End If
                                clb_updates.Items.RemoveAt(4)
                                clb_updates.Items.Insert(4, "Alt+Tab Fix")
                            Else
                                If clb_updates.CheckedItems.Contains("DirectX 9.0c") Then
                                    My.Settings.dx = True
                                    If File.Exists(Application.StartupPath & "/dl/dxsetup.exe") Then
                                        If getfilesha1(Application.StartupPath & "/dl/dxsetup.exe") = "f8f1217f666bf2f6863631a7d5e5fb3a8d1542df" = False Then
                                            download("DirectX 9.0c", "https://dl.ministudios.ml/bf2/dxsetup.exe", "dxsetup.exe")
                                        Else
                                            clb_updates.Items.RemoveAt(5)
                                            clb_updates.Items.Insert(5, "DirectX 9.0c")
                                            dl = True
                                            predl()
                                        End If
                                    Else
                                        download("DirectX 9.0c", "https://dl.ministudios.ml/bf2/dxsetup.exe", "dxsetup.exe")
                                    End If
                                    clb_updates.Items.RemoveAt(5)
                                    clb_updates.Items.Insert(5, "DirectX 9.0c")
                                Else
                                    If clb_updates.CheckedItems.Contains("PunkBuster") Then
                                        My.Settings.pb = True
                                        If File.Exists(Application.StartupPath & "/dl/pbsvc.exe") Then
                                            If getfilesha1(Application.StartupPath & "/dl/pbsvc.exe") = "dbc4aa6f3bebd60310bd53c52691df401b9b4ea1" = False Then
                                                download("PunkBuster", "https://www.evenbalance.com/downloads/pbsvc/pbsvc.exe", "pbsvc.exe")
                                            Else
                                                clb_updates.Items.RemoveAt(6)
                                                clb_updates.Items.Insert(6, "PunkBuster")
                                                dl = True
                                                predl()
                                            End If
                                        Else
                                            download("PunkBuster", "https://www.evenbalance.com/downloads/pbsvc/pbsvc.exe", "pbsvc.exe")
                                        End If
                                        clb_updates.Items.RemoveAt(6)
                                        clb_updates.Items.Insert(6, "PunkBuster")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub enable()
        about.Button1.Enabled = True
        bu_start.Enabled = True
        clb_updates.Enabled = True
        la_dl.Text = ""
        la_size.Text = ""
        la_speed.Text = ""
        la_perc.Text = ""
        pb_load.Value = 0
    End Sub

    Public Sub disable()
        about.Button1.Enabled = False
        bu_start.Enabled = False
        clb_updates.Enabled = False
        la_dl.Text = ""
        la_size.Text = ""
        la_speed.Text = ""
        la_perc.Text = ""
        pb_load.Value = 0
    End Sub

    Public Sub CheckForUpdates()
        Dim version As String = Application.StartupPath & "/version.txt"
        Dim updater As String = Application.StartupPath & "/updater.exe"
        Dim MyVer As String = My.Application.Info.Version.ToString
        If My.Computer.FileSystem.FileExists(version) Then
            My.Computer.FileSystem.DeleteFile(version)
        End If
        Dim wc As WebClient = New WebClient()
        If IsConnectionAvailable() = True Then
            wc.DownloadFile("https://dl.ministudios.ml/bf2/updater/version.txt", version)
        End If
        Dim LastVer As String = My.Computer.FileSystem.ReadAllText(version)
        If Not MyVer = LastVer Then
            Dim result As Integer = MessageBox.Show("An update is available! Do you want to download it?", "Update", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                If My.Computer.FileSystem.FileExists(updater) Then
                    My.Computer.FileSystem.DeleteFile(updater)
                End If
                If IsConnectionAvailable() = True Then
                    wc.DownloadFile("https://dl.ministudios.ml/updater/updater.exe", updater)
                End If
                Process.Start(Application.StartupPath & "/updater.exe", "-bf2")
                Me.Close()
            End If
        End If
    End Sub

    Public Function IsConnectionAvailable() As Boolean
        Dim objUrl As New System.Uri("https://dl.ministudios.ml/status.txt")
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
End Class
