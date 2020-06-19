Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                                               items = items.OrderBy(Function(x) x.SubItems(1).Text).ToList
                                               Me.Invoke(Sub()
                                                             ListView1.Items.AddRange(items.ToArray)
                                                             'ListView1.Sorting = SortOrder.Ascending
                                                             'ListView1.Sort()
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
    Property UserName As String
    Property UserID As String
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        DialogResult = DialogResult.OK
        UserName = ListView1.SelectedItems(0).SubItems(1).Text
        UserID = ListView1.SelectedItems(0).Text
        Me.Close()
    End Sub
End Class