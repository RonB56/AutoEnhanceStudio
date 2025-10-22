Imports System.Text

Public Class ReportGenerator

    Public Function CreateReport(diagnostics As DiagnosticResult, plan As EnhancementPlan) As String
        Dim sb = New StringBuilder()
        sb.AppendLine("<html><body>")
        sb.AppendLine("<h1>AutoEnhance Report</h1>")
        sb.AppendLine("<h2>Diagnostics</h2>")
        sb.AppendLine($"Motion Score: {diagnostics.MotionScore}<br/>")
        sb.AppendLine($"Sharpness: {diagnostics.Sharpness}<br/>")
        sb.AppendLine($"Noise Level: {diagnostics.NoiseLevel}<br/>")
        sb.AppendLine("<h2>Plan</h2>")
        sb.AppendLine(String.Join("<br/>", plan.Steps))
        sb.AppendLine("</body></html>")
        Return sb.ToString()
    End Function

End Class