Public Class Form1
    Private Sub DatenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatenToolStripMenuItem.Click
        ViewForm(Personen)
    End Sub
    Public Sub ViewForm(f As Form)
        If Not Panel1.Controls.Contains(f) Then
            f.TopLevel = False
            Panel1.Controls.Add(f)
        End If
        f.BringToFront()
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub
    Public Function ViewDialog(f As Form) As DialogResult
        f.BringToFront()
        Return f.ShowDialog
    End Function
    Public ActiveConnection As OleDb.OleDbConnection
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.Highest
        AddHandler My.Application.UnhandledException, Sub()
                                                          My.Computer.Audio.Play(My.Resources.Windows_Critical_Stop, AudioPlayMode.Background)
                                                          MsgBox("Ein schwerwiegender Fehler ist aufgetreten:" + vbNewLine + "" + vbNewLine + """SchoolBook Manager"" muss neugestartet werden...", MsgBoxStyle.Critical)
                                                          Try
                                                              Process.Start(Application.ExecutablePath)
                                                          Catch : End Try
                                                          Application.Exit()
                                                      End Sub
        Me.Enabled = False
    End Sub
    Public LoggedIn As Boolean
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not LoggedIn Then Exit Sub
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyData = Keys.F10 AndAlso Personen.Visible Then
            Personen.Personen_KeyDown(sender, e)
        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If mustclose Then Exit Sub
        If Not MessageBox.Show("Wollen Sie ""SchoolBook Manager"" wirklich beenden?!", "SchoolBook Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            e.Cancel = True
            Exit Sub
        End If
        ActiveConnection.Close()
    End Sub
    Private Sub Search() Handles Button1.Click
        Personen.Search(TextBox1.Text, ComboBox1.SelectedItem)
        Buecher.Search(TextBox1.Text, ComboBox1.SelectedItem)
    End Sub
    Dim mustclose As Boolean
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyData = Keys.Enter Then
            Search()
        End If
    End Sub
    Private Sub AbmeldenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbmeldenToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub BücherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BücherToolStripMenuItem.Click
        ViewForm(Buecher)
    End Sub
    Private Sub BücherEinAusbuchenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BücherEinAusbuchenToolStripMenuItem.Click
        ViewForm(Form3)
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim format As New StringFormat
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        Dim font As New Font("Arial", 48, FontStyle.Bold)
        e.Graphics.DrawString("Lernmittelsammlung", font, Brushes.White, Panel1.ClientRectangle, format)
    End Sub
    Private Sub SchülerHinzufügenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchülerHinzufügenToolStripMenuItem.Click
        Dim command As New OleDb.OleDbCommand("Select * from [Personen]", ActiveConnection)
        Dim adapter As New OleDb.OleDbDataAdapter(command)
        Dim usertables As New DataTable()
        adapter.Fill(usertables)
        Dim items As New List(Of String)
        For i = 0 To usertables.Rows.Count - 1
            items.Add(usertables.Rows(i)(0).ToString())
        Next
        items.OrderBy(Function(x) Int(x)).ToList
        Form2.Show()
        Form2.Add((Int(items(items.Count - 1)) + 1).ToString)
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If ViewDialog(LoginForm1) = DialogResult.OK Then
            Me.Enabled = True
            LoggedIn = True
            Try
                ActiveConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\Data.accdb")
                ActiveConnection.Open()
            Catch ex As Exception

            End Try
        Else
            mustclose = True
            Me.Close()
        End If
    End Sub
    Private Sub BuchHinzufügenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuchHinzufügenToolStripMenuItem.Click
        Dim command As New OleDb.OleDbCommand("Select * from [Buecher]", ActiveConnection)
        Dim adapter As New OleDb.OleDbDataAdapter(command)
        Dim usertables As New DataTable()
        adapter.Fill(usertables)
        Dim items As New List(Of String)
        For i = 0 To usertables.Rows.Count - 1
            items.Add(usertables.Rows(i)(0).ToString())
        Next
        items.OrderBy(Function(x) Int(x)).ToList
        Form5.Add((Int(items(items.Count - 1)) + 1).ToString)
    End Sub
    Private Sub Panel1_Resize(sender As Panel, e As EventArgs) Handles Panel1.Resize
        sender.Invalidate()
        sender.Update()
    End Sub
End Class