<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ymdBox
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.eraBox = New System.Windows.Forms.TextBox()
        Me.monthBox = New System.Windows.Forms.TextBox()
        Me.dateBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'eraBox
        '
        Me.eraBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.eraBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.eraBox.Location = New System.Drawing.Point(1, 1)
        Me.eraBox.MaxLength = 3
        Me.eraBox.Name = "eraBox"
        Me.eraBox.Size = New System.Drawing.Size(27, 19)
        Me.eraBox.TabIndex = 0
        '
        'monthBox
        '
        Me.monthBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.monthBox.Location = New System.Drawing.Point(37, 1)
        Me.monthBox.MaxLength = 2
        Me.monthBox.Name = "monthBox"
        Me.monthBox.Size = New System.Drawing.Size(21, 19)
        Me.monthBox.TabIndex = 1
        '
        'dateBox
        '
        Me.dateBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dateBox.Location = New System.Drawing.Point(65, 1)
        Me.dateBox.MaxLength = 2
        Me.dateBox.Name = "dateBox"
        Me.dateBox.Size = New System.Drawing.Size(21, 19)
        Me.dateBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(7, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(7, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "."
        '
        'ymdBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dateBox)
        Me.Controls.Add(Me.monthBox)
        Me.Controls.Add(Me.eraBox)
        Me.Name = "ymdBox"
        Me.Size = New System.Drawing.Size(88, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents eraBox As System.Windows.Forms.TextBox
    Friend WithEvents monthBox As System.Windows.Forms.TextBox
    Friend WithEvents dateBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
