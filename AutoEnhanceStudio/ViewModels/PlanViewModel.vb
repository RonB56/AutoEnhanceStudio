Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input
Imports Newtonsoft.Json  ' For JSON serialization

Namespace AutoEnhanceStudio

    Partial Public Class PlanViewModel
        Inherits ObservableObject

        <ObservableProperty> Private _plan As EnhancementPlan  ' Assumes EnhancementPlan model exists

        Private ReadOnly _ipcService As IpcService

        Public Sub New(ipcService As IpcService)
            _ipcService = ipcService
        End Sub

        Public Async Sub GeneratePlan(diagnostics As DiagnosticResult)
            Dim diagnosticsJson = JsonConvert.SerializeObject(diagnostics)
            Plan = Await _ipcService.SendPlanRequest(diagnosticsJson)
        End Sub

    End Class

End Namespace