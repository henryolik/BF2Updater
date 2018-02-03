<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class about
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(about))
        Me.la_ver = New System.Windows.Forms.Label()
        Me.la_c = New System.Windows.Forms.Label()
        Me.la_www = New System.Windows.Forms.Label()
        Me.bu_clean = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'la_ver
        '
        Me.la_ver.AutoSize = True
        Me.la_ver.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.la_ver.Location = New System.Drawing.Point(15, 9)
        Me.la_ver.Name = "la_ver"
        Me.la_ver.Size = New System.Drawing.Size(284, 37)
        Me.la_ver.TabIndex = 0
        Me.la_ver.Text = "BF2Updater v1.0.5"
        '
        'la_c
        '
        Me.la_c.AutoSize = True
        Me.la_c.Location = New System.Drawing.Point(0, 82)
        Me.la_c.Name = "la_c"
        Me.la_c.Size = New System.Drawing.Size(109, 13)
        Me.la_c.TabIndex = 1
        Me.la_c.Text = "© henryolik 2017 - 18"
        '
        'la_www
        '
        Me.la_www.AutoSize = True
        Me.la_www.Location = New System.Drawing.Point(188, 82)
        Me.la_www.Name = "la_www"
        Me.la_www.Size = New System.Drawing.Size(125, 13)
        Me.la_www.TabIndex = 2
        Me.la_www.Text = "https://bf2.ministudios.ml"
        '
        'bu_clean
        '
        Me.bu_clean.Location = New System.Drawing.Point(12, 49)
        Me.bu_clean.Name = "bu_clean"
        Me.bu_clean.Size = New System.Drawing.Size(288, 23)
        Me.bu_clean.TabIndex = 3
        Me.bu_clean.Text = "Clean download folder"
        Me.bu_clean.UseVisualStyleBackColor = True
        '
        'about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 98)
        Me.Controls.Add(Me.bu_clean)
        Me.Controls.Add(Me.la_www)
        Me.Controls.Add(Me.la_c)
        Me.Controls.Add(Me.la_ver)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "about"
        Me.Text = "About | BF2Updater"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents la_ver As System.Windows.Forms.Label
    Friend WithEvents la_c As System.Windows.Forms.Label
    Friend WithEvents la_www As System.Windows.Forms.Label
    Friend WithEvents bu_clean As System.Windows.Forms.Button
End Class
