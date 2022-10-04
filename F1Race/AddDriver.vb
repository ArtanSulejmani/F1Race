Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms



Partial Public Class AddDriver
    Inherits Form

    Public Property Result As Driver

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub tbName_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles TextBox1.Validating
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            e.Cancel = True
            ErrorProvider1.SetError(TextBox1, "Името е задолжително")
        Else
            ErrorProvider1.SetError(TextBox1, Nothing)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Result = New Driver()
        Result.Name = TextBox1.Text
        Result.Age = CInt(NumericUpDown1.Value)
        Result.IsFirst = RadioButton1.Checked()
        DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Close()
    End Sub


End Class
