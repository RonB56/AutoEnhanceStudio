Imports System.Windows

Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()
        ' Set DataContext to MainViewModel (injected via DI later)
    End Sub

    Private Sub OnVideoDrop(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If files.Length > 0 Then
                CType(DataContext, MainViewModel).LoadVideo(files(0))
            End If
        End If
    End Sub
End Class