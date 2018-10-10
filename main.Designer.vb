<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.bu_reset = New System.Windows.Forms.Button()
        Me.la_dloc = New System.Windows.Forms.Label()
        Me.tb_dloc = New System.Windows.Forms.TextBox()
        Me.la_perc = New System.Windows.Forms.Label()
        Me.la_dl = New System.Windows.Forms.Label()
        Me.la_speed = New System.Windows.Forms.Label()
        Me.la_11 = New System.Windows.Forms.Label()
        Me.la_pb = New System.Windows.Forms.Label()
        Me.la_dx = New System.Windows.Forms.Label()
        Me.la_150 = New System.Windows.Forms.Label()
        Me.la_atf = New System.Windows.Forms.Label()
        Me.la_bf2hub = New System.Windows.Forms.Label()
        Me.la_141 = New System.Windows.Forms.Label()
        Me.la_size = New System.Windows.Forms.Label()
        Me.bu_start = New System.Windows.Forms.Button()
        Me.pb_load = New System.Windows.Forms.ProgressBar()
        Me.la_version = New System.Windows.Forms.Label()
        Me.la_selup = New System.Windows.Forms.Label()
        Me.clb_updates = New System.Windows.Forms.CheckedListBox()
        Me.la_loc = New System.Windows.Forms.Label()
        Me.tb_loc = New System.Windows.Forms.TextBox()
        Me.ms_main = New System.Windows.Forms.MenuStrip()
        Me.mi_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.tt_main = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ms_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'bu_reset
        '
        Me.bu_reset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bu_reset.Location = New System.Drawing.Point(483, 92)
        Me.bu_reset.Name = "bu_reset"
        Me.bu_reset.Size = New System.Drawing.Size(75, 23)
        Me.bu_reset.TabIndex = 43
        Me.bu_reset.Text = "Reset"
        Me.bu_reset.UseVisualStyleBackColor = True
        '
        'la_dloc
        '
        Me.la_dloc.AutoSize = True
        Me.la_dloc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_dloc.Location = New System.Drawing.Point(10, 78)
        Me.la_dloc.Name = "la_dloc"
        Me.la_dloc.Size = New System.Drawing.Size(124, 13)
        Me.la_dloc.TabIndex = 42
        Me.la_dloc.Text = "Download folder location"
        '
        'tb_dloc
        '
        Me.tb_dloc.Location = New System.Drawing.Point(13, 94)
        Me.tb_dloc.Name = "tb_dloc"
        Me.tb_dloc.ReadOnly = True
        Me.tb_dloc.Size = New System.Drawing.Size(464, 20)
        Me.tb_dloc.TabIndex = 41
        '
        'la_perc
        '
        Me.la_perc.AutoSize = True
        Me.la_perc.BackColor = System.Drawing.Color.Transparent
        Me.la_perc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_perc.Location = New System.Drawing.Point(10, 265)
        Me.la_perc.Name = "la_perc"
        Me.la_perc.Size = New System.Drawing.Size(10, 13)
        Me.la_perc.TabIndex = 40
        Me.la_perc.Text = "."
        '
        'la_dl
        '
        Me.la_dl.AutoSize = True
        Me.la_dl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_dl.Location = New System.Drawing.Point(43, 244)
        Me.la_dl.Name = "la_dl"
        Me.la_dl.Size = New System.Drawing.Size(10, 13)
        Me.la_dl.TabIndex = 39
        Me.la_dl.Text = "."
        '
        'la_speed
        '
        Me.la_speed.AutoSize = True
        Me.la_speed.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_speed.Location = New System.Drawing.Point(397, 244)
        Me.la_speed.Name = "la_speed"
        Me.la_speed.Size = New System.Drawing.Size(10, 13)
        Me.la_speed.TabIndex = 38
        Me.la_speed.Text = "."
        '
        'la_11
        '
        Me.la_11.AutoSize = True
        Me.la_11.ForeColor = System.Drawing.Color.Red
        Me.la_11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_11.Location = New System.Drawing.Point(105, 133)
        Me.la_11.Name = "la_11"
        Me.la_11.Size = New System.Drawing.Size(92, 13)
        Me.la_11.TabIndex = 37
        Me.la_11.Text = "NOT INSTALLED"
        '
        'la_pb
        '
        Me.la_pb.AutoSize = True
        Me.la_pb.ForeColor = System.Drawing.Color.Orange
        Me.la_pb.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_pb.Location = New System.Drawing.Point(105, 225)
        Me.la_pb.Name = "la_pb"
        Me.la_pb.Size = New System.Drawing.Size(84, 13)
        Me.la_pb.TabIndex = 36
        Me.la_pb.Text = "NOT RUNNING"
        '
        'la_dx
        '
        Me.la_dx.AutoSize = True
        Me.la_dx.ForeColor = System.Drawing.Color.Red
        Me.la_dx.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_dx.Location = New System.Drawing.Point(105, 209)
        Me.la_dx.Name = "la_dx"
        Me.la_dx.Size = New System.Drawing.Size(92, 13)
        Me.la_dx.TabIndex = 35
        Me.la_dx.Text = "NOT INSTALLED"
        '
        'la_150
        '
        Me.la_150.AutoSize = True
        Me.la_150.ForeColor = System.Drawing.Color.Red
        Me.la_150.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_150.Location = New System.Drawing.Point(105, 163)
        Me.la_150.Name = "la_150"
        Me.la_150.Size = New System.Drawing.Size(92, 13)
        Me.la_150.TabIndex = 34
        Me.la_150.Text = "NOT INSTALLED"
        '
        'la_atf
        '
        Me.la_atf.AutoSize = True
        Me.la_atf.ForeColor = System.Drawing.Color.Red
        Me.la_atf.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_atf.Location = New System.Drawing.Point(105, 194)
        Me.la_atf.Name = "la_atf"
        Me.la_atf.Size = New System.Drawing.Size(92, 13)
        Me.la_atf.TabIndex = 33
        Me.la_atf.Text = "NOT INSTALLED"
        '
        'la_bf2hub
        '
        Me.la_bf2hub.AutoSize = True
        Me.la_bf2hub.ForeColor = System.Drawing.Color.Red
        Me.la_bf2hub.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_bf2hub.Location = New System.Drawing.Point(105, 178)
        Me.la_bf2hub.Name = "la_bf2hub"
        Me.la_bf2hub.Size = New System.Drawing.Size(92, 13)
        Me.la_bf2hub.TabIndex = 32
        Me.la_bf2hub.Text = "NOT INSTALLED"
        '
        'la_141
        '
        Me.la_141.AutoSize = True
        Me.la_141.ForeColor = System.Drawing.Color.Red
        Me.la_141.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_141.Location = New System.Drawing.Point(105, 148)
        Me.la_141.Name = "la_141"
        Me.la_141.Size = New System.Drawing.Size(92, 13)
        Me.la_141.TabIndex = 31
        Me.la_141.Text = "NOT INSTALLED"
        '
        'la_size
        '
        Me.la_size.AutoSize = True
        Me.la_size.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_size.Location = New System.Drawing.Point(200, 244)
        Me.la_size.Name = "la_size"
        Me.la_size.Size = New System.Drawing.Size(10, 13)
        Me.la_size.TabIndex = 30
        Me.la_size.Text = "."
        '
        'bu_start
        '
        Me.bu_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!)
        Me.bu_start.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bu_start.Location = New System.Drawing.Point(214, 132)
        Me.bu_start.Name = "bu_start"
        Me.bu_start.Size = New System.Drawing.Size(345, 109)
        Me.bu_start.TabIndex = 29
        Me.bu_start.Text = "START"
        Me.bu_start.UseVisualStyleBackColor = True
        '
        'pb_load
        '
        Me.pb_load.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pb_load.Location = New System.Drawing.Point(46, 260)
        Me.pb_load.Name = "pb_load"
        Me.pb_load.Size = New System.Drawing.Size(514, 23)
        Me.pb_load.TabIndex = 28
        '
        'la_version
        '
        Me.la_version.AutoSize = True
        Me.la_version.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_version.Location = New System.Drawing.Point(394, 36)
        Me.la_version.Name = "la_version"
        Me.la_version.Size = New System.Drawing.Size(162, 13)
        Me.la_version.TabIndex = 27
        Me.la_version.Text = "Detected BF2 version: Unknown"
        '
        'la_selup
        '
        Me.la_selup.AutoSize = True
        Me.la_selup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_selup.Location = New System.Drawing.Point(10, 117)
        Me.la_selup.Name = "la_selup"
        Me.la_selup.Size = New System.Drawing.Size(119, 13)
        Me.la_selup.TabIndex = 26
        Me.la_selup.Text = "Select updates to install"
        '
        'clb_updates
        '
        Me.clb_updates.CheckOnClick = True
        Me.clb_updates.FormattingEnabled = True
        Me.clb_updates.Items.AddRange(New Object() {"Patch 1.1", "Patch 1.41", "Patch 1.50", "BF2Hub", "Alt+Tab Fix", "DirectX 9.0c", "PunkBuster"})
        Me.clb_updates.Location = New System.Drawing.Point(13, 132)
        Me.clb_updates.Name = "clb_updates"
        Me.clb_updates.Size = New System.Drawing.Size(86, 109)
        Me.clb_updates.TabIndex = 25
        '
        'la_loc
        '
        Me.la_loc.AutoSize = True
        Me.la_loc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.la_loc.Location = New System.Drawing.Point(10, 36)
        Me.la_loc.Name = "la_loc"
        Me.la_loc.Size = New System.Drawing.Size(66, 13)
        Me.la_loc.TabIndex = 24
        Me.la_loc.Text = "BF2 location"
        '
        'tb_loc
        '
        Me.tb_loc.Enabled = False
        Me.tb_loc.Location = New System.Drawing.Point(13, 52)
        Me.tb_loc.Name = "tb_loc"
        Me.tb_loc.Size = New System.Drawing.Size(546, 20)
        Me.tb_loc.TabIndex = 23
        Me.tb_loc.Text = "C:/Program Files (x86)/EA Games/Battlefield 2"
        '
        'ms_main
        '
        Me.ms_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_about})
        Me.ms_main.Location = New System.Drawing.Point(0, 0)
        Me.ms_main.Name = "ms_main"
        Me.ms_main.Size = New System.Drawing.Size(571, 24)
        Me.ms_main.TabIndex = 44
        Me.ms_main.Text = "MenuStrip1"
        '
        'mi_about
        '
        Me.mi_about.Name = "mi_about"
        Me.mi_about.Size = New System.Drawing.Size(52, 20)
        Me.mi_about.Text = "About"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(538, 275)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "BETA"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 289)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bu_reset)
        Me.Controls.Add(Me.la_dloc)
        Me.Controls.Add(Me.tb_dloc)
        Me.Controls.Add(Me.la_perc)
        Me.Controls.Add(Me.la_dl)
        Me.Controls.Add(Me.la_speed)
        Me.Controls.Add(Me.la_11)
        Me.Controls.Add(Me.la_pb)
        Me.Controls.Add(Me.la_dx)
        Me.Controls.Add(Me.la_150)
        Me.Controls.Add(Me.la_atf)
        Me.Controls.Add(Me.la_bf2hub)
        Me.Controls.Add(Me.la_141)
        Me.Controls.Add(Me.la_size)
        Me.Controls.Add(Me.bu_start)
        Me.Controls.Add(Me.pb_load)
        Me.Controls.Add(Me.la_version)
        Me.Controls.Add(Me.la_selup)
        Me.Controls.Add(Me.clb_updates)
        Me.Controls.Add(Me.la_loc)
        Me.Controls.Add(Me.tb_loc)
        Me.Controls.Add(Me.ms_main)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.ms_main
        Me.Name = "main"
        Me.Text = "BF2Updater"
        Me.ms_main.ResumeLayout(False)
        Me.ms_main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bu_reset As System.Windows.Forms.Button
    Friend WithEvents la_dloc As System.Windows.Forms.Label
    Friend WithEvents tb_dloc As System.Windows.Forms.TextBox
    Friend WithEvents la_perc As System.Windows.Forms.Label
    Friend WithEvents la_dl As System.Windows.Forms.Label
    Friend WithEvents la_speed As System.Windows.Forms.Label
    Friend WithEvents la_11 As System.Windows.Forms.Label
    Friend WithEvents la_pb As System.Windows.Forms.Label
    Friend WithEvents la_dx As System.Windows.Forms.Label
    Friend WithEvents la_150 As System.Windows.Forms.Label
    Friend WithEvents la_atf As System.Windows.Forms.Label
    Friend WithEvents la_bf2hub As System.Windows.Forms.Label
    Friend WithEvents la_141 As System.Windows.Forms.Label
    Friend WithEvents la_size As System.Windows.Forms.Label
    Friend WithEvents bu_start As System.Windows.Forms.Button
    Friend WithEvents pb_load As System.Windows.Forms.ProgressBar
    Friend WithEvents la_version As System.Windows.Forms.Label
    Friend WithEvents la_selup As System.Windows.Forms.Label
    Friend WithEvents clb_updates As System.Windows.Forms.CheckedListBox
    Friend WithEvents la_loc As System.Windows.Forms.Label
    Friend WithEvents tb_loc As System.Windows.Forms.TextBox
    Friend WithEvents ms_main As System.Windows.Forms.MenuStrip
    Friend WithEvents mi_about As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tt_main As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
