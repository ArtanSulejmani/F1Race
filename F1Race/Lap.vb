Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text


Public Class Lap
    Public Property Minutes As Integer
    Public Property Seconds As Integer

    Public Overrides Function ToString() As String
        Return String.Format("{0}:{1:00}", Minutes, Seconds)
    End Function

    Public ReadOnly Property Time As Integer
        Get
            Return Minutes * 60 + Seconds
        End Get
    End Property
End Class
