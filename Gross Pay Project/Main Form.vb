' Name:         Gross Pay Project
' Purpose:      Displays an employee's gross pay.
' Programmer:   <your name> on <current date>

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Selects the first pay code in the list box.

        lstCodes.SelectedIndex = 0
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub ClearGross(sender As Object, e As EventArgs) Handles lstCodes.SelectedIndexChanged, txtHours.TextChanged
        lblGross.Text = String.Empty
    End Sub

    Private Sub txtHours_Enter(sender As Object, e As EventArgs) Handles txtHours.Enter
        txtHours.SelectAll()
    End Sub

    Private Sub txtHours_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHours.KeyPress
        ' Accept only numbers, the period, and the Backspace key.

        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Dim grossIncome As Double
        Dim workedHours As Integer

        'Array for rates'
        '{"P23", "P56", "P45", "P68", "P96"}'
        Dim payRate() As Double = {10.5, 12.5, 14.25, 15.75, 17.65}

        Integer.TryParse(txtHours.Text, workedHours)
        grossIncome = payRate(lstCodes.SelectedIndex) * workedHours

        If workedHours <= 40 Then
            grossIncome = payRate(lstCodes.SelectedIndex) * workedHours
        ElseIf workedHours > 40 Then
            grossIncome = 40 * (payRate(lstCodes.SelectedIndex)) + ((workedHours - 40) * payRate(lstCodes.SelectedIndex)) * 1.5
        End If

        lblGross.Text = grossIncome.ToString("C")

    End Sub
End Class
