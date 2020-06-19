Public Class Form2
    Dim id As String
    Sub LoadPerson(id As String, Optional abc As Boolean = False)

        Me.id = id
            Dim command As New OleDb.OleDbCommand("Select * from [Personen]", Form1.ActiveConnection)
            Dim adapter As New OleDb.OleDbDataAdapter(command)
            Dim usertables As New DataTable()
            adapter.Fill(usertables)
        Dim data = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                              If x(0).ToString = id Then Return True
                                                              Return False
                                                          End Function).ToList(0)

        'data = usertables.Rows(0)
        TextBox6.Text = id
            TextBox1.Text = data(1).ToString()
            MaskedTextBox1.Text = data(4).ToString()
            TextBox3.Text = data(2).ToString()
            TextBox4.Text = data(3).ToString()
            TextBox2.Text = data(5).ToString()
            TextBox5.Text = data(6).ToString()
            TextBox1.ReadOnly = True
            TextBox1.BackColor = Color.LightGray
            TextBox2.ReadOnly = True
            TextBox2.BackColor = Color.LightGray
            TextBox3.ReadOnly = True
            TextBox3.BackColor = Color.LightGray
            TextBox4.ReadOnly = True
            TextBox4.BackColor = Color.LightGray
            TextBox5.ReadOnly = True
            TextBox5.BackColor = Color.LightGray
            TextBox6.ReadOnly = True
            TextBox6.BackColor = Color.LightGray
            Button2.Visible = False
            MaskedTextBox1.ReadOnly = True
            ComboBox1.Enabled = False
            Button3.Visible = True
            Button3.Enabled = True
            Try
                ComboBox1.SelectedIndex = Int(data(7).ToString())
            Catch ex As Exception
                ComboBox1.SelectedIndex = 0
            End Try

            command = New OleDb.OleDbCommand("Select * from [Buecher]", Form1.ActiveConnection)
            adapter = New OleDb.OleDbDataAdapter(command)
            usertables = New DataTable()
            adapter.Fill(usertables)
            Dim data2 As IEnumerable(Of DataRow) = usertables.Rows.Cast(Of DataRow).Where(Function(x)
                                                                                              Debug.Print("Verlien: " + x(3).ToString())
                                                                                              If x(3).ToString() = id Then
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
            If abc Then
                TabControl1.SelectedIndex = 1
            Else
                TabControl1.SelectedIndex = 0
            End If
        Form1.ViewForm(Me)
        Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Public Sub Edit() Handles Button3.Click
        TextBox1.ReadOnly = False
        TextBox1.BackColor = Color.White
        TextBox2.ReadOnly = False
        TextBox2.BackColor = Color.White
        TextBox3.ReadOnly = False
        TextBox3.BackColor = Color.White
        TextBox4.ReadOnly = False
        TextBox4.BackColor = Color.White
        TextBox5.ReadOnly = False
        TextBox5.BackColor = Color.White
        Button2.Visible = True
        MaskedTextBox1.ReadOnly = False
        ComboBox1.Enabled = True
        Button3.Visible = False
        Button3.Enabled = False
    End Sub
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Button3.Enabled Then
            If MsgBox("Sie befinden sich im Bearbeitungsmodus." + vbNewLine + "Es können Daten verloren gehen" + vbNewLine + "Wollen Sie das Fenster wirklich schließen?", vbYesNo) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Public Sub Add(id As String)
        AddNewEntry = True
        TextBox6.Text = id
        Form1.ViewForm(Me)
        Edit()
        TextBox1.Focus()
    End Sub
    Dim AddNewEntry As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim cmd As New OleDb.OleDbCommand("", Form1.ActiveConnection)
            If AddNewEntry Then
                cmd.CommandText = "Insert Into [Personen] (ID, Name, Adresse, Ort, Geburtstag, Klasse, Telefon) Values('" + TextBox6.Text + "', '" + TextBox1.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + MaskedTextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox5.Text + "')"
            Else
                cmd.CommandText = "UPDATE [Personen] SET Name = '" + TextBox1.Text + "', Adresse = '" + TextBox3.Text + "', Ort = '" + TextBox4.Text + "', Geburtstag = '" + MaskedTextBox1.Text + "', Klasse = '" + TextBox2.Text + "', Telefon = '" + TextBox5.Text + "' WHERE ID = " + TextBox6.Text + ";"
            End If
            cmd.ExecuteNonQuery()
            Personen.Personen_Load()
        Catch ex As Exception

        End Try
        AddNewEntry = False
        Button3.Visible = True
        Button3.Enabled = True
        Button2.Hide()
        TextBox1.ReadOnly = True
        TextBox1.BackColor = Color.LightGray
        TextBox2.ReadOnly = True
        TextBox2.BackColor = Color.LightGray
        TextBox3.ReadOnly = True
        TextBox3.BackColor = Color.LightGray
        TextBox4.ReadOnly = True
        TextBox4.BackColor = Color.LightGray
        TextBox5.ReadOnly = True
        TextBox5.BackColor = Color.LightGray
        TextBox6.ReadOnly = True
        TextBox6.BackColor = Color.LightGray
        MaskedTextBox1.ReadOnly = True
        ComboBox1.Enabled = False
    End Sub
End Class