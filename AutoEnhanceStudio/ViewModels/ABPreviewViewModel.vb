Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input
Imports Newtonsoft.Json

Namespace AutoEnhanceStudio

    Partial Public Class ABPreviewViewModel
        Inherits ObservableObject

        Private _previewPath As String
        Public Property PreviewPath As String
            Get
                Return _previewPath
            End Get
            Set(value As String)
                SetProperty(_previewPath, value)
            End Set
        End Property

        Private _qualityScore As Double
        Public Property QualityScore As Double
            Get
                Return _qualityScore
            End Get
            Set(value As Double)
                SetProperty(_qualityScore, value)
            End Set
        End Property

        Private ReadOnly _ipcService As IpcService

        Public Sub New(ipcService As IpcService)
            _ipcService = ipcService
        End Sub

        Public Async Function GeneratePreview(videoPath As String, plan As EnhancementPlan) As Task
            Dim planJson = JsonConvert.SerializeObject(plan)
            PreviewPath = Await _ipcService.SendPreviewRequest(videoPath, planJson)
            QualityScore = 85.5  ' Placeholder
        End Function

    End Class

End Namespace