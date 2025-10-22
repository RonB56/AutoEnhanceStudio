Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input

Partial Public Class WorkerManagerViewModel
    Inherits ObservableObject

    Private _logs As String
    Public Property Logs As String
        Get
            Return _logs
        End Get
        Set(value As String)
            SetProperty(_logs, value)
        End Set
    End Property

    <ObservableProperty> Private _gpuUsage As Double

    Public Sub New()
        Logs = "Worker started..."
    End Sub

    Public Sub UpdateLogs(newLog As String)
        Logs &= Environment.NewLine & newLog
    End Sub

End Class