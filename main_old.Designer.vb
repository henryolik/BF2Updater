<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main_old
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main_old))
        Me.tb_loc = New System.Windows.Forms.TextBox()
        Me.ms_main = New System.Windows.Forms.MenuStrip()
        Me.mi_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.la_loc = New System.Windows.Forms.Label()
        Me.clb_updates = New System.Windows.Forms.CheckedListBox()
        Me.la_selup = New System.Windows.Forms.Label()
        Me.la_version = New System.Windows.Forms.Label()
        Me.pb_load = New System.Windows.Forms.ProgressBar()
        Me.bu_start = New System.Windows.Forms.Button()
        Me.la_size = New System.Windows.Forms.Label()
        Me.la_141 = New System.Windows.Forms.Label()
        Me.la_bf2hub = New System.Windows.Forms.Label()
        Me.la_atf = New System.Windows.Forms.Label()
        Me.la_150 = New System.Windows.Forms.Label()
        Me.la_dx = New System.Windows.Forms.Label()
        Me.la_pb = New System.Windows.Forms.Label()
        Me.la_11 = New System.Windows.Forms.Label()
        Me.la_speed = New System.Windows.Forms.Label()
        Me.la_dl = New System.Windows.Forms.Label()
        Me.la_perc = New System.Windows.Forms.Label()
        Me.la_dloc = New System.Windows.Forms.Label()
        Me.tb_dloc = New System.Windows.Forms.TextBox()
        Me.bu_reset = New System.Windows.Forms.Button()
        Me.tt_main = New System.Windows.Forms.ToolTip(Me.components)
        Me.ms_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_loc
        '
        resources.ApplyResources(Me.tb_loc, "tb_loc")
        Me.tb_loc.Name = "tb_loc"
        Me.tt_main.SetToolTip(Me.tb_loc, resources.GetString("tb_loc.ToolTip"))
        '
        'ms_main
        '
        resources.ApplyResources(Me.ms_main, "ms_main")
        Me.ms_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_about})
        Me.ms_main.Name = "ms_main"
        Me.tt_main.SetToolTip(Me.ms_main, resources.GetString("ms_main.ToolTip"))
        '
        'mi_about
        '
        resources.ApplyResources(Me.mi_about, "mi_about")
        Me.mi_about.Name = "mi_about"
        '
        'la_loc
        '
        resources.ApplyResources(Me.la_loc, "la_loc")
        Me.la_loc.Name = "la_loc"
        Me.tt_main.SetToolTip(Me.la_loc, resources.GetString("la_loc.ToolTip"))
        '
        'clb_updates
        '
        resources.ApplyResources(Me.clb_updates, "clb_updates")
        Me.clb_updates.CheckOnClick = True
        Me.clb_updates.FormattingEnabled = True
        Me.clb_updates.Items.AddRange(New Object() {resources.GetString("clb_updates.Items"), resources.GetString("clb_updates.Items1"), resources.GetString("clb_updates.Items2"), resources.GetString("clb_updates.Items3"), resources.GetString("clb_updates.Items4"), resources.GetString("clb_updates.Items5"), resources.GetString("clb_updates.Items6")})
        Me.clb_updates.Name = "clb_updates"
        Me.tt_main.SetToolTip(Me.clb_updates, resources.GetString("clb_updates.ToolTip"))
        '
        'la_selup
        '
        resources.ApplyResources(Me.la_selup, "la_selup")
        Me.la_selup.Name = "la_selup"
        Me.tt_main.SetToolTip(Me.la_selup, resources.GetString("la_selup.ToolTip"))
        '
        'la_version
        '
        resources.ApplyResources(Me.la_version, "la_version")
        Me.la_version.Name = "la_version"
        Me.tt_main.SetToolTip(Me.la_version, resources.GetString("la_version.ToolTip"))
        '
        'pb_load
        '
        resources.ApplyResources(Me.pb_load, "pb_load")
        Me.pb_load.Name = "pb_load"
        Me.tt_main.SetToolTip(Me.pb_load, resources.GetString("pb_load.ToolTip"))
        '
        'bu_start
        '
        resources.ApplyResources(Me.bu_start, "bu_start")
        Me.bu_start.Name = "bu_start"
        Me.tt_main.SetToolTip(Me.bu_start, resources.GetString("bu_start.ToolTip"))
        Me.bu_start.UseVisualStyleBackColor = True
        '
        'la_size
        '
        resources.ApplyResources(Me.la_size, "la_size")
        Me.la_size.Name = "la_size"
        Me.tt_main.SetToolTip(Me.la_size, resources.GetString("la_size.ToolTip"))
        '
        'la_141
        '
        resources.ApplyResources(Me.la_141, "la_141")
        Me.la_141.ForeColor = System.Drawing.Color.Red
        Me.la_141.Name = "la_141"
        Me.tt_main.SetToolTip(Me.la_141, resources.GetString("la_141.ToolTip"))
        '
        'la_bf2hub
        '
        resources.ApplyResources(Me.la_bf2hub, "la_bf2hub")
        Me.la_bf2hub.ForeColor = System.Drawing.Color.Red
        Me.la_bf2hub.Name = "la_bf2hub"
        Me.tt_main.SetToolTip(Me.la_bf2hub, resources.GetString("la_bf2hub.ToolTip"))
        '
        'la_atf
        '
        resources.ApplyResources(Me.la_atf, "la_atf")
        Me.la_atf.ForeColor = System.Drawing.Color.Red
        Me.la_atf.Name = "la_atf"
        Me.tt_main.SetToolTip(Me.la_atf, resources.GetString("la_atf.ToolTip"))
        '
        'la_150
        '
        resources.ApplyResources(Me.la_150, "la_150")
        Me.la_150.ForeColor = System.Drawing.Color.Red
        Me.la_150.Name = "la_150"
        Me.tt_main.SetToolTip(Me.la_150, resources.GetString("la_150.ToolTip"))
        '
        'la_dx
        '
        resources.ApplyResources(Me.la_dx, "la_dx")
        Me.la_dx.ForeColor = System.Drawing.Color.Red
        Me.la_dx.Name = "la_dx"
        Me.tt_main.SetToolTip(Me.la_dx, resources.GetString("la_dx.ToolTip"))
        '
        'la_pb
        '
        resources.ApplyResources(Me.la_pb, "la_pb")
        Me.la_pb.ForeColor = System.Drawing.Color.Orange
        Me.la_pb.Name = "la_pb"
        Me.tt_main.SetToolTip(Me.la_pb, resources.GetString("la_pb.ToolTip"))
        '
        'la_11
        '
        resources.ApplyResources(Me.la_11, "la_11")
        Me.la_11.ForeColor = System.Drawing.Color.Red
        Me.la_11.Name = "la_11"
        Me.tt_main.SetToolTip(Me.la_11, resources.GetString("la_11.ToolTip"))
        '
        'la_speed
        '
        resources.ApplyResources(Me.la_speed, "la_speed")
        Me.la_speed.Name = "la_speed"
        Me.tt_main.SetToolTip(Me.la_speed, resources.GetString("la_speed.ToolTip"))
        '
        'la_dl
        '
        resources.ApplyResources(Me.la_dl, "la_dl")
        Me.la_dl.Name = "la_dl"
        Me.tt_main.SetToolTip(Me.la_dl, resources.GetString("la_dl.ToolTip"))
        '
        'la_perc
        '
        resources.ApplyResources(Me.la_perc, "la_perc")
        Me.la_perc.BackColor = System.Drawing.Color.Transparent
        Me.la_perc.Name = "la_perc"
        Me.tt_main.SetToolTip(Me.la_perc, resources.GetString("la_perc.ToolTip"))
        '
        'la_dloc
        '
        resources.ApplyResources(Me.la_dloc, "la_dloc")
        Me.la_dloc.Name = "la_dloc"
        Me.tt_main.SetToolTip(Me.la_dloc, resources.GetString("la_dloc.ToolTip"))
        '
        'tb_dloc
        '
        resources.ApplyResources(Me.tb_dloc, "tb_dloc")
        Me.tb_dloc.Name = "tb_dloc"
        Me.tb_dloc.ReadOnly = True
        Me.tt_main.SetToolTip(Me.tb_dloc, resources.GetString("tb_dloc.ToolTip"))
        '
        'bu_reset
        '
        resources.ApplyResources(Me.bu_reset, "bu_reset")
        Me.bu_reset.Name = "bu_reset"
        Me.tt_main.SetToolTip(Me.bu_reset, resources.GetString("bu_reset.ToolTip"))
        Me.bu_reset.UseVisualStyleBackColor = True
        '
        'main
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.MainMenuStrip = Me.ms_main
        Me.Name = "main"
        Me.tt_main.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.ms_main.ResumeLayout(False)
        Me.ms_main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_loc As System.Windows.Forms.TextBox
    Friend WithEvents ms_main As System.Windows.Forms.MenuStrip
    Friend WithEvents mi_about As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents la_loc As System.Windows.Forms.Label
    Friend WithEvents clb_updates As System.Windows.Forms.CheckedListBox
    Friend WithEvents la_selup As System.Windows.Forms.Label
    Friend WithEvents la_version As System.Windows.Forms.Label
    Friend WithEvents pb_load As System.Windows.Forms.ProgressBar
    Friend WithEvents bu_start As System.Windows.Forms.Button
    Friend WithEvents la_size As System.Windows.Forms.Label
    Friend WithEvents la_141 As System.Windows.Forms.Label
    Friend WithEvents la_bf2hub As System.Windows.Forms.Label
    Friend WithEvents la_atf As System.Windows.Forms.Label
    Friend WithEvents la_150 As System.Windows.Forms.Label
    Friend WithEvents la_dx As System.Windows.Forms.Label
    Friend WithEvents la_pb As System.Windows.Forms.Label
    Friend WithEvents la_11 As System.Windows.Forms.Label
    Friend WithEvents la_speed As System.Windows.Forms.Label
    Friend WithEvents la_dl As System.Windows.Forms.Label
    Friend WithEvents la_perc As System.Windows.Forms.Label
    Friend WithEvents la_dloc As System.Windows.Forms.Label
    Friend WithEvents tb_dloc As System.Windows.Forms.TextBox
    Friend WithEvents bu_reset As System.Windows.Forms.Button
    Friend WithEvents tt_main As System.Windows.Forms.ToolTip

End Class
