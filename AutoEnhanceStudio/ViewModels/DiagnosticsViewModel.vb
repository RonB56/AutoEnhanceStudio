Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input

Partial Public Class DiagnosticsViewModel
    Inherits ObservableObject

    Private _result As DiagnosticResult
    Public Property Result As DiagnosticResult
        Get
            Return _result
        End Get
        Set(value As DiagnosticResult)
            SetProperty(_result, value)
        End Set
    End Property

    Private ReadOnly _ipcService As IpcService

    Public Sub New(ipcService As IpcService)
        _ipcService = ipcService
    End Sub

    Public Async Function RunDiagnostics(videoPath As String) As Task
        Result = Await _ipcService.SendDiagnosticsRequest(videoPath)
    End Function
End Class
