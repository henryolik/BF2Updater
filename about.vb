Imports System.IO

Public Class about

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If MsgBox("Do you really want to delete ALL downloaded files?", MsgBoxStyle.YesNo, "Are you sure?") = MsgBoxResult.Yes Then
            Try
                Button1.Enabled = False
                For Each deleteFile In Directory.GetFiles(main.dloc, "*.*", SearchOption.TopDirectoryOnly)
                    File.Delete(deleteFile)
                Next
            Catch ex As Exception
                MsgBox("Clearing folder failed! Error: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
            End Try
        End If
    End Sub

    Private Sub about_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Directory.Exists(main.dloc) = False OrElse Directory.GetFiles(main.dloc).Count < 1 OrElse main.bu_start.Enabled = False Then
            Button1.Enabled = False
        End If
    End Sub
End Class