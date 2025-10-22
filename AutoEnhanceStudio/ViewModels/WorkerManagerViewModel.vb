Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input

Namespace AutoEnhanceStudio

    Partial Public Class WorkerManagerViewModel
        Inherits ObservableObject

        <ObservableProperty> Private _logs As String  ' For displaying GPU/CPU/logs

        <ObservableProperty> Private _gpuUsage As Double  ' Placeholder for telemetry

        Public Sub New()
            ' Initialize monitoring (e.g., timer for polling)
            Logs = "Worker started..."
        End Sub

        ' Add methods for updating logs/GPU (e.g., from Python feedback)
        Public Sub UpdateLogs(newLog As String)
            Logs &= Environment.NewLine & newLog
        End Sub

    End Class

End Namespace