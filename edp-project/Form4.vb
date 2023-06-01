Public Class Form4


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to confirm?", "Confirmation", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            MessageBox.Show("Going back to registration form")
        ElseIf result = DialogResult.No Then
            MessageBox.Show("Exiting")
            Me.Close()
            Form3.Close()

        ElseIf result = DialogResult.Yes Then
            MessageBox.Show("Confirmed")
            Me.Close()
        End If
    End Sub
End Class