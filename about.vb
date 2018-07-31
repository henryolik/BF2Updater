Imports System.IO

Public Class about
    Sub init()
        Dim appname As String = System.Reflection.Assembly.GetExecutingAssembly.GetName().Name
        Dim appver As String = My.Application.Info.Version.ToString
        Dim app As String = appname & " v" & appver
        Me.Text = app
        la_ver.Text = app
    End Sub

    Private Sub bu_clean_click(sender As System.Object, e As System.EventArgs) Handles bu_clean.Click
        If MsgBox("Do you really want to delete ALL downloaded files?", MsgBoxStyle.YesNo, "Are you sure?") = MsgBoxResult.Yes Then
            Try
                bu_clean.Enabled = False
                For Each deleteFile In Directory.GetFiles(main.dloc, "*.*", SearchOption.TopDirectoryOnly)
                    File.Delete(deleteFile)
                Next
            Catch ex As Exception
                MsgBox("Clearing folder failed! Error: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
            End Try
        End If
    End Sub

    Private Sub about_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        init()
        If Directory.Exists(main.dloc) = False OrElse Directory.GetFiles(main.dloc).Count < 1 OrElse main.bu_start.Enabled = False Then
            bu_clean.Enabled = False
        End If
    End Sub
End Class