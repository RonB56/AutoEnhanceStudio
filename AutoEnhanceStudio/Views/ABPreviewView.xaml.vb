Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input

Namespace AutoEnhanceStudio

    Partial Public Class ABPreviewViewModel
        Inherits ObservableObject

        <ObservableProperty> Private _previewPath As String  ' e.g., path to before/after clips

        Private ReadOnly _ipcService As IpcService

        Public Sub New(ipcService As IpcService)
            _ipcService = ipcService
        End Sub

        Public Async Sub GeneratePreview(videoPath As String, plan As EnhancementPlan)
            Dim planJson = Newtonsoft.Json.JsonConvert.SerializeObject(plan)
            PreviewPath = Await _ipcService.SendPreviewRequest(videoPath, planJson)
        End Sub
    End Class

End Namespace