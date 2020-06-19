Public Class Personen
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Dim SavedItems As New List(Of ListViewItem)
    Public Sub Personen_Load() Handles MyBase.Load
        Me.UseWaitCursor = True
        Try
            Dim command As New OleDb.OleDbCommand("Select * from [Personen]", Form1.ActiveConnection)
            Dim adapter As New OleDb.OleDbDataAdapter(command)
            Dim usertables As New DataTable()
            adapter.Fill(usertables)
            Dim t1 As New Threading.Thread(Sub()
                                               Dim items As New List(Of ListViewItem)
                                               For i = 0 To usertables.Rows.Count - 1
                                                   Dim a As New ListViewItem
                                                   a.Text = usertables.Rows(i)(0).ToString()
                                                   a.Tag = usertables.Rows(i)(0).ToString()
                                                   a.SubItems.Add(usertables.Rows(i)(1).ToString())
                                                   a.SubItems.Add(usertables.Rows(i)(2).ToString())
                                                   a.SubItems.Add(usertables.Rows(i)(3).ToString())
                                                   a.SubItems.Add(usertables.Rows(i)(4).ToString())
                                                   a.SubItems.Add(usertables.Rows(i)(5).ToString())
                                                   a.SubItems.Add(usertables.Rows(i)(6).ToString())
                                                   a.ToolTipText = "Person " + usertables.Rows(i)(0).ToString()
                                                   Try
                                                       'a.Group = ListView1.Groups.Item(Int(usertables.Rows(i)(7).ToString()))
                                                       a.Group = ListView1.Groups.Item(0)
                                                   Catch
                                                       a.Group = ListView1.Groups.Item(0)
                                                   End Try
                                                   items.Add(a)
                                               Next
                                               If CheckBox2.Checked Then
                                                   items = items.OrderBy(Function(x) Int(x.Text)).ToList
                                               Else
                                                   items = items.OrderBy(Function(x) x.SubItems(1).Text).ToList
                                               End If
                                               SavedItems = items
                                               Me.Invoke(Sub()
                                                             ListView1.Items.Clear()
                                                             ListView1.Items.AddRange(items.ToArray)
                                                             'ListView1.Sorting = SortOrder.Ascending
                                                             'ListView1.Sort()
                                                             ListView1.ShowGroups = CheckBox1.Checked
                                                             Me.UseWaitCursor = False
                                                         End Sub)
                                           End Sub)
            t1.IsBackground = True
            t1.Priority = Threading.ThreadPriority.Highest
            t1.Start()
        Catch ex As Exception
            Me.UseWaitCursor = False
        End Try
    End Sub
    Private Sub Button2_Click() Handles Button2.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            Form2.LoadPerson(ListView1.SelectedItems(0).Tag)
        Else
            MsgBox("Bitte eine Person auswählen!", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If Not ListView1.SelectedItems.Count = 0 Then
            Form2.LoadPerson(ListView1.SelectedItems(0).Tag)
        End If
    End Sub
    Private Sub Button3_Click() Handles Button3.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            Form2.LoadPerson(ListView1.SelectedItems(0).Tag)
            Form2.Edit()
        Else
            MsgBox("Bitte eine Person auswählen!", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub Button4_Click() Handles Button4.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            If MessageBox.Show("Wollen Sie die Person """ + ListView1.SelectedItems(0).SubItems(1).Text + """ wirklich löschen?!", "SchoolBook Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) Then
                MsgBox("Diese Funktion ist noch nicht implementiert!", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Bitte eine Person auswählen!", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub Personen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not ListView1.SelectedItems.Count = 0 AndAlso e.KeyData = Keys.F10 Then
            Form2.LoadPerson(ListView1.SelectedItems(0).Tag, True)
        End If
    End Sub
    Private Sub Button5_Click() Handles Button5.Click
        Form2.Show()
        Dim items As New List(Of ListViewItem)
        items.AddRange(SavedItems.ToArray)
        items = items.OrderBy(Function(x) Int(x.Text)).ToList
        Form2.Add((Int(items(items.Count - 1).Text) + 1).ToString)
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        ListView1.ShowGroups = CheckBox1.Checked
    End Sub
    Public Sub Search(key As String, type As String)
        ListView1.Items.Clear()
        If key = "" Then
            ListView1.Items.AddRange(SavedItems.ToArray)
            Exit Sub
        End If
        Dim items As New List(Of ListViewItem)
        If type = "Nummer" Then
            items = SavedItems.Cast(Of ListViewItem).Where(Function(x)
                                                               If x.SubItems(0).Text.ToLower.Contains(key.ToLower) Then Return True
                                                               Return False
                                                           End Function).ToList
        Else
            items = SavedItems.Cast(Of ListViewItem).Where(Function(x)
                                                               If x.SubItems(1).Text.ToLower.Contains(key.ToLower) Then Return True
                                                               Return False
                                                           End Function).ToList
        End If
        If CheckBox2.Checked Then
            items = items.OrderBy(Function(x) Int(x.Text)).ToList()
        Else
            items = items.OrderBy(Function(x) x.SubItems(1).Text).ToList()
        End If
        ListView1.Items.AddRange(items.ToArray)
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ListView1.Items.Clear()
        Dim items As New List(Of ListViewItem)
        items.AddRange(SavedItems.ToArray)
        If CheckBox2.Checked Then
            items = items.OrderBy(Function(x) Int(x.Text)).ToList
        Else
            items = items.OrderBy(Function(x) x.SubItems(1).Text).ToList
        End If
        ListView1.Items.AddRange(items.ToArray)
    End Sub
    Private Sub AnsehenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnsehenToolStripMenuItem.Click
        Button2_Click()
    End Sub
    Private Sub BearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BearbeitenToolStripMenuItem.Click
        Button3_Click()
    End Sub
    Private Sub LöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LöschenToolStripMenuItem.Click
        Button4_Click()
    End Sub
    Private Sub HinzufügenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HinzufügenToolStripMenuItem.Click
        Button5_Click()
    End Sub
End Class