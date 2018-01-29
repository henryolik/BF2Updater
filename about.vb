Public Class about

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If MsgBox("Do you really want to delete ALL downloaded files?", MsgBoxStyle.YesNo, "Are you sure?") = MsgBoxResult.Yes Then
            Try
                IO.Directory.Delete(Application.StartupPath & "/dl", True)
                Button1.Enabled = False
            Catch ex As Exception
                MsgBox("Clearing folder failed! Error: " & ex.ToString, MsgBoxStyle.Critical, "Error!")
            End Try
        End If
    End Sub

    Private Sub about_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            If IO.Directory.Exists(Application.StartupPath & "/dl") = False Or main.bu_start.Enabled = False Then
                Button1.Enabled = False
            End If
    End Sub
End Class