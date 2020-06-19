Public Class Form3
    Private Sub Button1_Click(sender As Button, e As EventArgs) Handles Button1.Click
        GroupBox1.Enabled = True
        Label4.Text = sender.Text
        sender.BackColor = Color.Orange
        sender.ForeColor = Color.White
        SetButtonEnabled(Button2, False)
        Button5.Enabled = True
        Button5.Focus()
        TextBox2.Enabled = False
    End Sub
    Private Sub Button2_Click(sender As Button, e As EventArgs) Handles Button2.Click
        GroupBox1.Enabled = True
        Label4.Text = sender.Text
        Label4.Text = sender.Text
        sender.BackColor = Color.Orange
        sender.ForeColor = Color.White
        SetButtonEnabled(Button1, False)
        Button5.Enabled = False
        TextBox2.Focus()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Sub SetButtonEnabled(b As Button, enabled As Boolean)
        If enabled Then
            Try
                b.ForeColor = b.Tag
            Catch : End Try
        Else
            b.Tag = b.ForeColor
            b.ForeColor = Color.LightGray
        End If
        b.Enabled = enabled
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Label4.Text = Button1.Text AndAlso MsgBox("Soll ein Ausdruck erstellt werden?", vbYesNo) = vbYes Then
            MsgBox("Ausdrücke können noch nicht gemacht werden", MsgBoxStyle.Exclamation)
        End If
        SetButtonEnabled(Button1, True)
        SetButtonEnabled(Button2, True)
        GroupBox1.Enabled = False
        Label2.Text = "--"
        Label4.Text = "--"
        TextBox1.Text = ""
        Button1.BackColor = Me.BackColor
        Button1.ForeColor = Color.Orange
        Button2.BackColor = Me.BackColor
        Button2.ForeColor = Color.Orange
        Button5.Enabled = False
        TextBox2.Enabled = True
        ListView1.Items.Clear()
    End Sub
    Sub LoadBookList()
        Dim Command = New OleDb.OleDbCommand("Select * from [Buecher]", Form1.ActiveConnection)
        Dim adapter = New OleDb.OleDbDataAdapter(Command)
        Dim usertables = New DataTable()
        adapter.Fill(usertables)
        Dim data2 As IEnumerable(Of DataRow) = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                                                          If x(3).ToString() = TextBox1.Text Then
                                                                                              Return True
                                                                                          End If
                                                                                          Return False
                                                                                      End Function)
        ListView1.Items.Clear()
        For Each row As DataRow In data2
            Dim a As New ListViewItem
            a.Text = row(0).ToString()
            a.SubItems.Add(row(1).ToString())
            a.SubItems.Add(row(2).ToString())
            ListView1.Items.Add(a)
            Debug.Print(row(0).ToString())
        Next
    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyData = Keys.Enter Then
            If Label4.Text = Button1.Text Then 'Ausleihen
                Dim Command = New OleDb.OleDbCommand("Select * from [Buecher]", Form1.ActiveConnection)
                Dim adapter = New OleDb.OleDbDataAdapter(Command)
                Dim usertables = New DataTable()
                adapter.Fill(usertables)
                Dim data2 As IEnumerable(Of DataRow) = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                                                                  If x(2).ToString() = TextBox2.Text Then
                                                                                                      Return True
                                                                                                  End If
                                                                                                  Return False
                                                                                              End Function)
                If data2.Count = 0 Then
                    My.Computer.Audio.Play(My.Resources.Windows_Critical_Stop, AudioPlayMode.Background)
                    MsgBox("Mediennummer unbekannt!", MsgBoxStyle.Critical)
                    TextBox2.Text = ""
                    Exit Sub
                End If
                If Not data2(0)(3).ToString = "" Then
                    My.Computer.Audio.Play(My.Resources.Windows_Critical_Stop, AudioPlayMode.Background)
                    MsgBox("Buch ist schon verliehen!", MsgBoxStyle.Critical)
                    TextBox2.Text = ""
                    Exit Sub
                End If

                Dim cmd As New OleDb.OleDbCommand("", Form1.ActiveConnection)
                cmd.CommandText = "UPDATE [Buecher] SET Verlien_an = '" + TextBox1.Text + "' WHERE Barcode = '" + TextBox2.Text + "';"
                cmd.ExecuteNonQuery()
                TextBox2.Text = ""
                Try
                Catch ex As Exception

                End Try
                LoadBookList()
            End If
            If Label4.Text = Button2.Text Then 'Rückgabe
                Dim Command = New OleDb.OleDbCommand("Select * from [Buecher]", Form1.ActiveConnection)
                Dim adapter = New OleDb.OleDbDataAdapter(Command)
                Dim usertables = New DataTable()
                adapter.Fill(usertables)
                Dim data2 As IEnumerable(Of DataRow) = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                                                                  If x(2).ToString() = TextBox2.Text Then
                                                                                                      Return True
                                                                                                  End If
                                                                                                  Return False
                                                                                              End Function)
                If data2.Count = 0 Then
                    My.Computer.Audio.Play(My.Resources.Windows_Critical_Stop, AudioPlayMode.Background)
                    MsgBox("Mediennummer unbekannt!", MsgBoxStyle.Critical)
                    TextBox2.Text = ""
                    Exit Sub
                End If
                If data2(0)(3).ToString = "" Then
                    My.Computer.Audio.Play(My.Resources.Windows_Critical_Stop, AudioPlayMode.Background)
                    MsgBox("Buch nicht verliehen!", MsgBoxStyle.Critical)
                    TextBox2.Text = ""
                    Exit Sub
                End If
                Try
                    Dim pid = data2(0)(3).ToString
                    Dim cmd As New OleDb.OleDbCommand("", Form1.ActiveConnection)
                    cmd.CommandText = "UPDATE [Buecher] SET Verlien_an = '' WHERE Barcode = '" + TextBox2.Text + "';"
                    cmd.ExecuteNonQuery()
                    TextBox2.Text = ""
                    TextBox1.Text = pid
                    Command = New OleDb.OleDbCommand("Select * from [Personen]", Form1.ActiveConnection)
                    adapter = New OleDb.OleDbDataAdapter(Command)
                    usertables = New DataTable()
                    adapter.Fill(usertables)
                    Dim data = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                                          If x(0).ToString = pid Then Return True
                                                                          Return False
                                                                      End Function).ToList()(0)
                    Label2.Text = data(1).ToString
                    LoadBookList()
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Button, e As EventArgs) Handles Button5.Click
        Dim a As New Form4
        If a.ShowDialog = DialogResult.OK Then
            sender.Enabled = False
            TextBox2.Enabled = True
            TextBox2.Focus()
            TextBox1.Text = a.UserID
            Label2.Text = a.UserName
            LoadBookList()
        End If
    End Sub
End Class