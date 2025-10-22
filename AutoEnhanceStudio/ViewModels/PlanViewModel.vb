Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input
Imports Newtonsoft.Json

Partial Public Class PlanViewModel
    Inherits ObservableObject

    Private _plan As EnhancementPlan
    Public Property Plan As EnhancementPlan
        Get
            Return _plan
        End Get
        Set(value As EnhancementPlan)
            SetProperty(_plan, value)
        End Set
    End Property

    Private ReadOnly _ipcService As IpcService

    Public Sub New(ipcService As IpcService)
        _ipcService = ipcService
    End Sub

    Public Async Function GeneratePlan(diagnostics As DiagnosticResult) As Task
        Dim diagnosticsJson = JsonConvert.SerializeObject(diagnostics)
        Plan = Await _ipcService.SendPlanRequest(diagnosticsJson)
    End Function

End Class