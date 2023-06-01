Imports ClosedXML.Excel
Imports MySqlConnector
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Form3

    Private connectionString As String = "Server=localhost;Database=styleyou;Uid=root;Pwd=evanism392002;"
    Private connection As New MySqlConnection(connectionString)

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.Open()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form6.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form7.Show()
    End Sub

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        connection.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query As String = "SELECT * FROM `styleyou`.`users`"
        Dim adapter As New MySqlDataAdapter(query, connection)
        Dim dataSet As New DataSet()

        adapter.Fill(dataSet, "tableData")

        DataGridView1.DataSource = dataSet.Tables("tableData")
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim query As String = "SELECT * FROM `styleyou`.`users` WHERE ModelStat = 0"
        Dim adapter As New MySqlDataAdapter(query, connection)
        Dim dataSet As New DataSet()

        adapter.Fill(dataSet, "tableData")

        DataGridView1.DataSource = dataSet.Tables("tableData")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim query As String = "SELECT * FROM `styleyou`.`users` WHERE ModelStat = 1"
        Dim adapter As New MySqlDataAdapter(query, connection)
        Dim dataSet As New DataSet()

        adapter.Fill(dataSet, "tableData")

        DataGridView1.DataSource = dataSet.Tables("tableData")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click




        Dim wb As New XLWorkbook()
        Dim ws As IXLWorksheet = wb.Worksheets.Add("Sheet1")
        Dim row As Integer = 1

        For Each dgvRow As DataGridViewRow In DataGridView1.Rows
            Dim column As Integer = 1
            For Each cell As DataGridViewCell In dgvRow.Cells
                If cell.Value IsNot Nothing Then
                    ws.Cell(row, column).Value = cell.Value.ToString()
                End If
                column += 1
            Next
            row += 1
        Next

        ' Auto-fit columns
        ws.Columns().AdjustToContents()

        ' Save the Excel file
        Dim filePath As String = "TestFile.xlsx"
        wb.SaveAs(filePath)
        MessageBox.Show("DONE")
    End Sub
End Class