Imports Serilog
Imports System.IO

Namespace AutoEnhanceStudio

    Public Class LoggerService

        Public Sub New()
            Log.Logger = New LoggerConfiguration() _
                .MinimumLevel.Debug() _
                .WriteTo.File(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AutoEnhanceStudio", "logs.txt"), rollingInterval:=RollingInterval.Day) _
                .CreateLogger()
            Log("Logger initialized.")  ' Added argument to fix BC30455
        End Sub

        Public Sub Log(message As String)
            Log.Information(message)
        End Sub

        Public Sub LogError(message As String)
            Log.Error(message)
        End Sub

    End Class

End Namespace