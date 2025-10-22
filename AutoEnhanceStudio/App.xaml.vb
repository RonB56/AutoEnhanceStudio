Imports Microsoft.Extensions.DependencyInjection
Imports CommunityToolkit.Mvvm.DependencyInjection
Imports System.Diagnostics
Imports System.IO

Partial Public Class App
    Inherits Application

    Protected Overrides Sub OnStartup(e As StartupEventArgs)
        MyBase.OnStartup(e)

        Dim services = New ServiceCollection()
        services.AddTransient(Of MainViewModel)()
        services.AddTransient(Of DiagnosticsViewModel)()
        services.AddTransient(Of PlanViewModel)()
        services.AddTransient(Of ABPreviewViewModel)()
        services.AddTransient(Of WorkerManagerViewModel)()
        services.AddSingleton(Of IpcService)()
        services.AddSingleton(Of LoggerService)()
        Ioc.Default.ConfigureServices(services.BuildServiceProvider())

        Dim mainWindow = New MainWindow() With {.DataContext = Ioc.Default.GetService(Of MainViewModel)()}
        mainWindow.Show()
    End Sub

    ' In New() or a method
    Private Sub StartWorker()
        Dim workerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workers", "worker.py")
        Dim psi = New ProcessStartInfo("python", workerPath) With {.UseShellExecute = True, .CreateNoWindow = True}
        Process.Start(psi)
    End Sub

End Class