Imports System.IO
Imports System.Security.Cryptography
Imports System.Diagnostics

Namespace AutoEnhanceStudio

    Public Class ModelManager

        Private ReadOnly _modelPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AutoEnhanceStudio", "models")

        Public Sub New()
            If Not Directory.Exists(_modelPath) Then
                Directory.CreateDirectory(_modelPath)
            End If
        End Sub

        ' Check model integrity (SHA256)
        Public Function VerifyModel(modelName As String, expectedHash As String) As Boolean
            Dim filePath = Path.Combine(_modelPath, modelName)
            If Not File.Exists(filePath) Then Return False

            Using sha256 As SHA256 = SHA256.Create()  ' Explicit type to fix inference
                Using stream = File.OpenRead(filePath)
                    Dim hash = sha256.ComputeHash(stream)
                    Dim hashString = BitConverter.ToString(hash).Replace("-", "").ToLower()
                    Return hashString = expectedHash.ToLower()
                End Using
            End Using
        End Function

        ' Download/Install models via PowerShell (called from GUI button)
        Public Sub InstallModels()
            Dim psi = New ProcessStartInfo("powershell.exe", "-File install_win.ps1") With {.UseShellExecute = True}
            Process.Start(psi)
        End Sub

        ' Placeholder for GUI integration (e.g., list models in WorkerManager pane)
        Public Function GetModelList() As List(Of String)
            Return Directory.GetFiles(_modelPath).ToList()
        End Function

    End Class

End Namespace