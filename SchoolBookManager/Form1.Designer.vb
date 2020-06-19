<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BücherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DatenImportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenExportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbmeldenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SchülerHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuchHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BücherEinAusbuchenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunktionenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KlassenErhöhenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebOPACToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem, Me.FunktionenToolStripMenuItem, Me.ExtraToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(855, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatenToolStripMenuItem, Me.BücherToolStripMenuItem, Me.ToolStripSeparator1, Me.DatenImportierenToolStripMenuItem, Me.DatenExportierenToolStripMenuItem, Me.ToolStripSeparator2, Me.AbmeldenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'DatenToolStripMenuItem
        '
        Me.DatenToolStripMenuItem.Name = "DatenToolStripMenuItem"
        Me.DatenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.DatenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DatenToolStripMenuItem.Text = "Schüler / Lehrer"
        '
        'BücherToolStripMenuItem
        '
        Me.BücherToolStripMenuItem.Name = "BücherToolStripMenuItem"
        Me.BücherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BücherToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.BücherToolStripMenuItem.Text = "Bücher"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(173, 6)
        '
        'DatenImportierenToolStripMenuItem
        '
        Me.DatenImportierenToolStripMenuItem.Enabled = False
        Me.DatenImportierenToolStripMenuItem.Name = "DatenImportierenToolStripMenuItem"
        Me.DatenImportierenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DatenImportierenToolStripMenuItem.Text = "Daten Importieren"
        '
        'DatenExportierenToolStripMenuItem
        '
        Me.DatenExportierenToolStripMenuItem.Enabled = False
        Me.DatenExportierenToolStripMenuItem.Name = "DatenExportierenToolStripMenuItem"
        Me.DatenExportierenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DatenExportierenToolStripMenuItem.Text = "Daten exportieren"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(173, 6)
        '
        'AbmeldenToolStripMenuItem
        '
        Me.AbmeldenToolStripMenuItem.Name = "AbmeldenToolStripMenuItem"
        Me.AbmeldenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AbmeldenToolStripMenuItem.Text = "Abmelden"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SchülerHinzufügenToolStripMenuItem, Me.BuchHinzufügenToolStripMenuItem, Me.ToolStripSeparator5, Me.BücherEinAusbuchenToolStripMenuItem})
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
        '
        'SchülerHinzufügenToolStripMenuItem
        '
        Me.SchülerHinzufügenToolStripMenuItem.Name = "SchülerHinzufügenToolStripMenuItem"
        Me.SchülerHinzufügenToolStripMenuItem.ShortcutKeyDisplayString = "Strg+Einf"
        Me.SchülerHinzufügenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)
        Me.SchülerHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.SchülerHinzufügenToolStripMenuItem.Text = "Person hinzufügen"
        '
        'BuchHinzufügenToolStripMenuItem
        '
        Me.BuchHinzufügenToolStripMenuItem.Name = "BuchHinzufügenToolStripMenuItem"
        Me.BuchHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.BuchHinzufügenToolStripMenuItem.Text = "Buch hinzufügen"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(226, 6)
        '
        'BücherEinAusbuchenToolStripMenuItem
        '
        Me.BücherEinAusbuchenToolStripMenuItem.Name = "BücherEinAusbuchenToolStripMenuItem"
        Me.BücherEinAusbuchenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.BücherEinAusbuchenToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.BücherEinAusbuchenToolStripMenuItem.Text = "Bücher ein-/ ausbuchen"
        '
        'FunktionenToolStripMenuItem
        '
        Me.FunktionenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KlassenErhöhenToolStripMenuItem})
        Me.FunktionenToolStripMenuItem.Name = "FunktionenToolStripMenuItem"
        Me.FunktionenToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.FunktionenToolStripMenuItem.Text = "Funktionen"
        '
        'KlassenErhöhenToolStripMenuItem
        '
        Me.KlassenErhöhenToolStripMenuItem.Enabled = False
        Me.KlassenErhöhenToolStripMenuItem.Name = "KlassenErhöhenToolStripMenuItem"
        Me.KlassenErhöhenToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.KlassenErhöhenToolStripMenuItem.Text = "Klassen erhöhen"
        '
        'ExtraToolStripMenuItem
        '
        Me.ExtraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WebOPACToolStripMenuItem})
        Me.ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem"
        Me.ExtraToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ExtraToolStripMenuItem.Text = "Extra"
        '
        'WebOPACToolStripMenuItem
        '
        Me.WebOPACToolStripMenuItem.Name = "WebOPACToolStripMenuItem"
        Me.WebOPACToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.WebOPACToolStripMenuItem.Text = "WebOPAC"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 528)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(855, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(855, 477)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ComboBox1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(855, 27)
        Me.Panel2.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(71, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(588, 26)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(659, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Suchen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Name / Titel", "Nummer"})
        Me.ComboBox1.Location = New System.Drawing.Point(734, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 28)
        Me.ComboBox1.TabIndex = 3
        Me.ComboBox1.Text = "Name / Titel"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Suchbegriff:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(855, 550)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Enabled = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SchoolBook Manger"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BücherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DatenImportierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatenExportierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AbmeldenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SchülerHinzufügenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuchHinzufügenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents BücherEinAusbuchenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents FunktionenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KlassenErhöhenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebOPACToolStripMenuItem As ToolStripMenuItem
End Class
