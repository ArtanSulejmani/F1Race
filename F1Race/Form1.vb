Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms



Partial Public Class Form1
    Inherits Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub btnAddDriver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim f As AddDriver = New AddDriver()

        If f.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ListBox1.Items.Add(f.Result)
        End If
    End Sub

    Private Sub Listbox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Button3.Enabled = ListBox1.SelectedIndex <> -1
        Button2.Enabled = ListBox1.SelectedIndex <> -1
        showLaps()
    End Sub

    Private Sub btnAddLap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Dim lap As Lap = New Lap()
        lap.Minutes = CInt(NumericUpDown1.Value)
        lap.Seconds = CInt(NumericUpDown2.Value)
        Dim driver As Driver = TryCast(ListBox1.SelectedItem, Driver)
        driver.Laps.Add(lap)
        NumericUpDown1.Value = 0
        NumericUpDown2.Value = 0
        showLaps()
    End Sub

    Private Sub showLaps()
        Dim driver As Driver = TryCast(ListBox1.SelectedItem, Driver)
        ListBox2.Items.Clear()

        If driver IsNot Nothing AndAlso driver.Laps.Count > 0 Then
            Dim limit As Integer = CInt(NumericUpDown3.Value)
            Dim best As Lap = driver.Laps(0)

            For Each lap As Lap In driver.Laps

                If limit > 0 Then

                    If lap.Time > limit Then
                        ListBox2.Items.Add(lap)
                    End If
                Else
                    ListBox2.Items.Add(lap)
                End If

                If lap.Time < best.Time Then
                    best = lap
                End If
            Next

            TextBox1.Text = best.ToString()
        Else
            TextBox1.Text = ""
        End If
    End Sub



    Private Sub nudLimit_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        showLaps()
    End Sub

    Private Sub btnDeleteDriver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Избриши возач?", "Дали сте сигурни?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub nudSeconds_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim value As Integer = CInt(NumericUpDown2.Value)

        If value < 0 Then
            Dim min As Integer = CInt(NumericUpDown1.Value)

            If min > 0 Then
                NumericUpDown1.Value = min - 1
                NumericUpDown2.Value = 59
            Else
                NumericUpDown2.Value = 0
            End If
        Else
            NumericUpDown2.Value = value Mod 60
            NumericUpDown1.Value += value / 60
        End If
    End Sub


End Class

