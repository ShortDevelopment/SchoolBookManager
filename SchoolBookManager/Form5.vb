Public Class Form5
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Public Sub LoadBook(id As String)
        TextBox0.Text = id
        TextBox2.Text = id
        Dim Command = New OleDb.OleDbCommand("Select * from [Buecher]", Form1.ActiveConnection)
        Dim adapter = New OleDb.OleDbDataAdapter(Command)
        Dim usertables = New DataTable()
        adapter.Fill(usertables)
        Dim data2 = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                               If x(2).ToString() = id Then
                                                                   Return True
                                                               End If
                                                               Return False
                                                           End Function).ToList()(0)
        TextBox1.Text = data2(1).ToString()
        Command = New OleDb.OleDbCommand("Select * from [Personen]", Form1.ActiveConnection)
        adapter = New OleDb.OleDbDataAdapter(Command)
        usertables = New DataTable()
        adapter.Fill(usertables)
        Dim data = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                              If x(0).ToString = data2(3).ToString() Then Return True
                                                              Return False
                                                          End Function).ToList()
        If data.Count <= 0 Then
            TextBox3.Text = "---"
            TextBox3.Tag = ""
        Else
            TextBox3.Text = data(0)(1).ToString
            TextBox3.Tag = data2(3).ToString()
        End If
        Form1.ViewForm(Me)
    End Sub
    Private Sub Button3_Click(sender As Button, e As EventArgs) Handles Button3.Click
        sender.Enabled = False
        sender.Hide()
        Button2.Show()
    End Sub
    Private Sub Form5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Button2.Enabled Then
            If MsgBox("Sie befinden sich im Bearbeitungsmodus." + vbNewLine + "Es können Daten verloren gehen" + vbNewLine + "Wollen Sie das Fenster wirklich schließen?", vbYesNo) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    Public Sub Add(id As String)
        TextBox0.Text = id
        TextBox2.Text = id
        TextBox1.ReadOnly = False
        TextBox3.Text = "---"
        Form1.ViewForm(Me)
        Button2.Show()
        Button2.Enabled = True
        TextBox1.Focus()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Hide()
        Button2.Enabled = False
        TextBox1.ReadOnly = True
        Try
            Dim cmd As New OleDb.OleDbCommand("", Form1.ActiveConnection)
            cmd.CommandText = "Insert Into [Buecher] (ID, Titel, Barcode, Verlien_an) Values('" + TextBox0.Text + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', '')"
            cmd.ExecuteNonQuery()
            Buecher.Buecher_Load()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class