'Q4. Demonstrate Use of RichText box with OpenFile dialog box control.

Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing ' Add this line to import the System.Drawing namespace

Public Class FileViewerForm
    Inherits Form

    Private WithEvents btnOpenFile As New Button()
    Private WithEvents richTextBox As New RichTextBox()
    Private openFileDialog As New OpenFileDialog()

    Public Sub New()
        Me.Text = "File Viewer"
        Me.ClientSize = New System.Drawing.Size(400, 300) ' Use System.Drawing.Size to define the size

        ' Configure OpenFileDialog
        openFileDialog.Title = "Open Text File"
        openFileDialog.Filter = "Text Files|*.txt|All Files|*.*"

        ' Configure Open File button
        btnOpenFile.Text = "Open File"
        btnOpenFile.Location = New System.Drawing.Point(10, 10) ' Use System.Drawing.Point to define the location

        ' Configure RichTextBox
        richTextBox.Size = New System.Drawing.Size(350, 200) ' Use System.Drawing.Size to define the size
        richTextBox.Location = New System.Drawing.Point(10, 50) ' Use System.Drawing.Point to define the location

        ' Add controls to the form
        Me.Controls.Add(btnOpenFile)
        Me.Controls.Add(richTextBox)
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        ' Show OpenFileDialog
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Read the selected file and display its content in the RichTextBox
            Dim filePath As String = openFileDialog.FileName

            Try
                Using reader As New StreamReader(filePath)
                    Dim fileContent As String = reader.ReadToEnd()
                    richTextBox.Text = fileContent
                End Using
            Catch ex As Exception
                MessageBox.Show("Error reading the file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Shared Sub Main()
        Application.Run(New FileViewerForm())
    End Sub
End Class
