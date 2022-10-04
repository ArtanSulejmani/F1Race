Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class Driver
    Public Property Name As String
    Public Property IsFirst As Boolean
    Public Property Age As Integer
    Public Property Laps As List(Of Lap)

    Public Sub New()
        Laps = New List(Of Lap)()
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0} ({1}) - {2}", Name, Age, If(IsFirst, "F", "S"))
    End Function
End Class

