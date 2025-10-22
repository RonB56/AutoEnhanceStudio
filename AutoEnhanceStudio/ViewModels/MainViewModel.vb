Imports CommunityToolkit.Mvvm.ComponentModel
Imports CommunityToolkit.Mvvm.Input
Imports System.IO
Imports Newtonsoft.Json

Namespace AutoEnhanceStudio

    Partial Public Class MainViewModel
        Inherits ObservableObject

        <ObservableProperty> Private _diagnosticsVM As DiagnosticsViewModel
        <ObservableProperty> Private _planVM As PlanViewModel
        <ObservableProperty> Private _aBPreviewVM As ABPreviewViewModel
        <ObservableProperty> Private _workerManagerVM As WorkerManagerViewModel

        Private _currentVideoPath As String
        Public Property CurrentVideoPath As String
            Get
                Return _currentVideoPath
            End Get
            Set(value As String)
                SetProperty(_currentVideoPath, value)
            End Set
        End Property

        Private ReadOnly _ipcService As IpcService
        Private ReadOnly _logger As LoggerService

        Public Sub New(diagnosticsVM As DiagnosticsViewModel, planVM As PlanViewModel, aBPreviewVM As ABPreviewViewModel, workerManagerVM As WorkerManagerViewModel, ipcService As IpcService, logger As LoggerService)
            _diagnosticsVM = diagnosticsVM
            _planVM = planVM
            _aBPreviewVM = aBPreviewVM
            _workerManagerVM = workerManagerVM
            _ipcService = ipcService
            _logger = logger
        End Sub

        ' Rest of code...
        Public Async Function Plan() As Task
            Await _planVM.GeneratePlan(_diagnosticsVM.Result)
        End Function

        Public Async Function ABPreview() As Task
            Await _aBPreviewVM.GeneratePreview(CurrentVideoPath, _planVM.Plan)
        End Function

        Public Async Function Render() As Task
            Dim planJson = JsonConvert.SerializeObject(_planVM.Plan)
            Dim result = Await _ipcService.SendEnhanceRequest(CurrentVideoPath, planJson)
            _logger.Log($"Render complete: {result}")
        End Function

        Private Sub GenerateReport()
            Dim reportGenerator As New ReportGenerator()  ' Add this class if missing (see below)
            Dim report = reportGenerator.CreateReport(_diagnosticsVM.Result, _planVM.Plan)
            File.WriteAllText("report.html", report)
        End Sub
    End Class

End Namespace