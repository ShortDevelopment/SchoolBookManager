Public Class Buecher
    Dim SavedItems As New List(Of ListViewItem)
    Public Sub Buecher_Load() Handles MyBase.Load
        Me.UseWaitCursor = True
        Try
            Dim command As New OleDb.OleDbCommand("Select * from [Buecher]", Form1.ActiveConnection)
            Dim adapter As New OleDb.OleDbDataAdapter(command)
            Dim usertables As New DataTable()
            adapter.Fill(usertables)
            Dim t1 As New Threading.Thread(Sub()
                                               Dim items As New List(Of ListViewItem)
                                               For i = 0 To usertables.Rows.Count - 1
                                                   Dim a As New ListViewItem
                                                   a.Text = usertables.Rows(i)(0).ToString()
                                                   'a.Text = usertables.Columns(1).ColumnName
                                                   a.Tag = usertables.Rows(i)(0).ToString()
                                                   a.SubItems.Add(usertables.Rows(i)(1).ToString())
                                                   a.SubItems.Add(usertables.Rows(i)(2).ToString())
                                                   a.ToolTipText = "Buch " + usertables.Rows(i)(0).ToString()
                                                   items.Add(a)
                                               Next
                                               items = items.OrderBy(Function(x) x.SubItems(1).Text).ToList
                                               SavedItems = items
                                               Me.Invoke(Sub()
                                                             ListView1.Items.Clear()
                                                             ListView1.Items.AddRange(items.ToArray)
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim items As New List(Of ListViewItem)
        items.AddRange(SavedItems.ToArray)
        items = items.OrderBy(Function(x) Int(x.Text)).ToList
        Form5.Add((Int(items(items.Count - 1).Text) + 1).ToString)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            If MessageBox.Show("Wollen Sie das Buch """ + ListView1.SelectedItems(0).SubItems(1).Text + """ wirklich löschen?!", "SchoolBook Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) Then
                MsgBox("Diese Funktion ist noch nicht implementiert!", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Bitte ein Buch auswählen!", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Form5.LoadBook(ListView1.SelectedItems(0).Text)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Bitte ein Buch auswählen!", MsgBoxStyle.Exclamation)
        Else
            Form5.LoadBook(ListView1.SelectedItems(0).Text)
        End If
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
        items = items.OrderBy(Function(x) x.SubItems(1).Text).ToList()
        ListView1.Items.AddRange(items.ToArray)
    End Sub
End Class