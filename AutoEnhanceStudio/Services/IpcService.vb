Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class IpcService

    Private ReadOnly _httpClient As New HttpClient() With {.BaseAddress = New Uri("http://localhost:50051/")}

    Public Async Function SendDiagnosticsRequest(videoPath As String) As Task(Of DiagnosticResult)
        Dim requestContent = New StringContent(JsonConvert.SerializeObject(New With {.video_path = videoPath}), Encoding.UTF8, "application/json")
        Dim response = Await _httpClient.PostAsync("diagnostics", requestContent)
        response.EnsureSuccessStatusCode()
        Dim jsonResult = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of DiagnosticResult)(jsonResult)
    End Function

    ' Similar async methods for other endpoints
    Public Async Function SendPlanRequest(diagnosticsJson As String) As Task(Of EnhancementPlan)
        Dim requestContent = New StringContent(JsonConvert.SerializeObject(New With {.diagnostics_json = diagnosticsJson}), Encoding.UTF8, "application/json")
        Dim response = Await _httpClient.PostAsync("plan", requestContent)
        response.EnsureSuccessStatusCode()
        Dim jsonResult = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of EnhancementPlan)(jsonResult)
    End Function

    Public Async Function SendPreviewRequest(videoPath As String, planJson As String) As Task(Of String)
        Dim requestContent = New StringContent(JsonConvert.SerializeObject(New With {.video_path = videoPath, .plan_json = planJson}), Encoding.UTF8, "application/json")
        Dim response = Await _httpClient.PostAsync("preview", requestContent)
        response.EnsureSuccessStatusCode()
        Return Await response.Content.ReadAsStringAsync()  ' e.g., path to preview file
    End Function

    Public Async Function SendEnhanceRequest(videoPath As String, planJson As String) As Task(Of String)
        Dim requestContent = New StringContent(JsonConvert.SerializeObject(New With {.video_path = videoPath, .plan_json = planJson}), Encoding.UTF8, "application/json")
        Dim response = Await _httpClient.PostAsync("enhance", requestContent)
        response.EnsureSuccessStatusCode()
        Return Await response.Content.ReadAsStringAsync()  ' e.g., path to output file
    End Function

End Class
