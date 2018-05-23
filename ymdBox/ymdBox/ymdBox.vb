Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' 年月日入力テキストボックスクラス
''' </summary>
''' <remarks></remarks>
Public Class ymdBox

    Private Const VALUE_UP As Integer = 1
    Private Const VALUE_DOWN As Integer = -1

    'フォーカス位置保持用
    Private focusedTextBoxNum As Integer = 0

    Private focusControlFlg As Boolean = False

    '和暦の記号
    Private Const ERA_MEIJI As String = "M" '明治
    Private Const ERA_TAISYO As String = "T" '大正
    Private Const ERA_SYOWA As String = "S" '昭和
    Private Const ERA_HEISEI As String = "H" '平成
    Private Const ERA_X As String = "X" 'まだ未定

    '最小値、最大値
    Private Const MEIJI_MIN As String = ERA_MEIJI & "33/01/01"
    Private Const MEIJI_MAX As String = ERA_MEIJI & "45/07/29"
    Private Const TAISYO_MIN As String = ERA_TAISYO & "01/07/30"
    Private Const TAISYO_MAX As String = ERA_TAISYO & "15/12/24"
    Private Const SYOWA_MIN As String = ERA_SYOWA & "01/12/25"
    Private Const SYOWA_MAX As String = ERA_SYOWA & "64/01/07"
    Private Const HEISEI_MIN As String = ERA_HEISEI & "01/01/08"
    Private Const HEISEI_MAX As String = ERA_HEISEI & "31/04/30"
    Private Const X_MIN As String = ERA_X & "01/05/01"
    Private Const X_MAX As String = ERA_X & "99/12/31"

    Private _boxType As Integer

    Public Event YmLabelTextChage(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>
    ''' 和暦部分の文字列
    ''' </summary>
    ''' <value>設定する文字列</value>
    ''' <returns>和暦部分の文字列</returns>
    ''' <remarks></remarks>
    Public Property EraText() As String
        Get
            Return eraBox.Text
        End Get

        Set(ByVal value As String)
            eraBox.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 月の文字列
    ''' </summary>
    ''' <value>設定する文字列</value>
    ''' <returns>月の文字列</returns>
    ''' <remarks></remarks>
    Public Property MonthText() As String
        Get
            Return monthBox.Text
        End Get

        Set(ByVal value As String)
            monthBox.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 日にちの文字列
    ''' </summary>
    ''' <value>設定する日にち</value>
    ''' <returns>日にちの文字列</returns>
    ''' <remarks></remarks>
    Public Property DateText() As String
        Get
            Return dateBox.Text
        End Get

        Set(ByVal value As String)
            dateBox.Text = value
        End Set
    End Property

    Public Property EraLabelText() As String
        Get
            Return eraLabel.Text
        End Get

        Set(ByVal value As String)
            eraLabel.Text = value
        End Set
    End Property

    Public Property MonthLabelText() As String
        Get
            Return monthLabel.Text
        End Get

        Set(ByVal value As String)
            monthLabel.Text = value
        End Set
    End Property

    Public Property boxType() As Integer
        Get
            Return _boxType
        End Get
        Set(value As Integer)
            _boxType = value
            If value = 0 Then
                '文字サイズ変更
                eraBox.Font = New Font("MS UI Gothic", 9)
                monthBox.Font = New Font("MS UI Gothic", 9)
                dateBox.Font = New Font("MS UI Gothic", 9)
                Label1.Font = New Font("MS UI Gothic", 9)
                Label2.Font = New Font("MS UI Gothic", 9)

                '全体
                Me.Size = New Size(86, 20)

                'テキストボックスのサイズ
                eraBox.Size = New Size(27, 19)
                monthBox.Size = New Size(21, 19)
                dateBox.Size = New Size(21, 19)

                'テキストボックスの位置
                eraBox.Location = New Point(1, 1)
                monthBox.Location = New Point(37, 1)
                dateBox.Location = New Point(65, 1)

                'ラベルの位置
                Label1.Location = New Point(29, 8)
                Label2.Location = New Point(58, 8)

                '表示、非表示
                eraBox.Visible = True
                monthBox.Visible = True
                dateBox.Visible = True
                Label1.Visible = True
                Label2.Visible = True
                btnUp.Visible = False
                btnDown.Visible = False
                dayLabel.Visible = False
                eraLabel.Visible = False
                monthLabel.Visible = False
                Label3.Visible = False
                btnMonthUp.Visible = False
                btnMonthDown.Visible = False
            ElseIf value = 1 Then
                '文字サイズ変更
                eraBox.Font = New Font("MS UI Gothic", 14)
                monthBox.Font = New Font("MS UI Gothic", 14)
                dateBox.Font = New Font("MS UI Gothic", 14)

                '全体
                Me.Size = New Size(110, 30)

                'テキストボックスのサイズ
                eraBox.Size = New Size(38, 30)
                monthBox.Size = New Size(28, 30)
                dateBox.Size = New Size(28, 30)

                'テキストボックスの位置
                eraBox.Location = New Point(1, 1)
                monthBox.Location = New Point(47, 1)
                dateBox.Location = New Point(82, 1)

                'ラベルの位置
                Label1.Location = New Point(40, 13)
                Label2.Location = New Point(75, 13)

                '表示、非表示
                eraBox.Visible = True
                monthBox.Visible = True
                dateBox.Visible = True
                Label1.Visible = True
                Label2.Visible = True
                btnUp.Visible = False
                btnDown.Visible = False
                dayLabel.Visible = False
                eraLabel.Visible = False
                monthLabel.Visible = False
                Label3.Visible = False
                btnMonthUp.Visible = False
                btnMonthDown.Visible = False
            ElseIf value = 2 Then
                '文字サイズ変更
                eraBox.Font = New Font("MS UI Gothic", 9)
                monthBox.Font = New Font("MS UI Gothic", 9)
                dateBox.Font = New Font("MS UI Gothic", 9)
                Label1.Font = New Font("MS UI Gothic", 9)
                Label2.Font = New Font("MS UI Gothic", 9)

                '全体
                Me.Size = New Size(110, 34)

                'テキストボックスのサイズ
                eraBox.Size = New Size(27, 19)
                monthBox.Size = New Size(21, 19)
                dateBox.Size = New Size(21, 19)

                'テキストボックスの位置
                eraBox.Location = New Point(1, 7)
                monthBox.Location = New Point(37, 7)
                dateBox.Location = New Point(65, 7)

                'ラベルの位置
                Label1.Location = New Point(29, 12)
                Label2.Location = New Point(58, 12)

                'ボタンサイズ
                btnUp.Size = New Size(15, 17)
                btnDown.Size = New Size(15, 17)

                'ボタン位置
                btnUp.Location = New Point(96, 0)
                btnDown.Location = New Point(96, 16)

                'ボタンフォント
                btnUp.Font = New Font("MS UI Gothic", 7)
                btnDown.Font = New Font("MS UI Gothic", 7)

                '表示、非表示
                eraBox.Visible = True
                monthBox.Visible = True
                dateBox.Visible = True
                Label1.Visible = True
                Label2.Visible = True
                btnUp.Visible = True
                btnDown.Visible = True
                dayLabel.Visible = False
                eraLabel.Visible = False
                monthLabel.Visible = False
                Label3.Visible = False
                btnMonthUp.Visible = False
                btnMonthDown.Visible = False
            ElseIf value = 3 Then
                '文字サイズ変更
                eraBox.Font = New Font("MS UI Gothic", 14)
                monthBox.Font = New Font("MS UI Gothic", 14)
                dateBox.Font = New Font("MS UI Gothic", 14)

                '全体
                Me.Size = New Size(145, 46)

                'テキストボックスのサイズ
                eraBox.Size = New Size(38, 30)
                monthBox.Size = New Size(28, 30)
                dateBox.Size = New Size(28, 30)

                'テキストボックスの位置
                eraBox.Location = New Point(1, 10)
                monthBox.Location = New Point(47, 10)
                dateBox.Location = New Point(82, 10)

                'ラベルの位置
                Label1.Location = New Point(40, 24)
                Label2.Location = New Point(75, 24)

                'ボタンサイズ
                btnUp.Size = New Size(22, 23)
                btnDown.Size = New Size(22, 23)

                'ボタン位置
                btnUp.Location = New Point(120, 0)
                btnDown.Location = New Point(120, 22)

                'ボタンフォント
                btnUp.Font = New Font("MS UI Gothic", 9)
                btnDown.Font = New Font("MS UI Gothic", 9)

                '表示、非表示
                eraBox.Visible = True
                monthBox.Visible = True
                dateBox.Visible = True
                Label1.Visible = True
                Label2.Visible = True
                btnUp.Visible = True
                btnDown.Visible = True
                dayLabel.Visible = False
                eraLabel.Visible = False
                monthLabel.Visible = False
                Label3.Visible = False
                btnMonthUp.Visible = False
                btnMonthDown.Visible = False
            ElseIf value = 4 Then
                '文字サイズ変更
                eraBox.Font = New Font("MS UI Gothic", 9)
                monthBox.Font = New Font("MS UI Gothic", 9)
                dateBox.Font = New Font("MS UI Gothic", 9)
                Label1.Font = New Font("MS UI Gothic", 9)
                Label2.Font = New Font("MS UI Gothic", 9)

                '全体
                Me.Size = New Size(145, 34)

                'テキストボックスのサイズ
                eraBox.Size = New Size(27, 19)
                monthBox.Size = New Size(21, 19)
                dateBox.Size = New Size(21, 19)

                'テキストボックスの位置
                eraBox.Location = New Point(1, 7)
                monthBox.Location = New Point(37, 7)
                dateBox.Location = New Point(65, 7)

                'ラベルの位置
                Label1.Location = New Point(29, 12)
                Label2.Location = New Point(58, 12)

                '曜日ラベルサイズ、位置
                dayLabel.Size = New Size(32, 16)
                dayLabel.Location = New Point(91, 9)

                'ボタンサイズ
                btnUp.Size = New Size(15, 17)
                btnDown.Size = New Size(15, 17)

                'ボタン位置
                btnUp.Location = New Point(128, 0)
                btnDown.Location = New Point(128, 16)

                'ボタンフォント
                btnUp.Font = New Font("MS UI Gothic", 7)
                btnDown.Font = New Font("MS UI Gothic", 7)

                '表示、非表示
                eraBox.Visible = True
                monthBox.Visible = True
                dateBox.Visible = True
                Label1.Visible = True
                Label2.Visible = True
                btnUp.Visible = True
                btnDown.Visible = True
                dayLabel.Visible = True
                eraLabel.Visible = False
                monthLabel.Visible = False
                Label3.Visible = False
                btnMonthUp.Visible = False
                btnMonthDown.Visible = False
            ElseIf value = 5 Then
                '全体
                Me.Size = New Size(95, 40)

                'ラベルサイズ
                eraLabel.Size = New Size(44, 19)
                monthLabel.Size = New Size(44, 19)
                Label3.Size = New Size(7, 12)

                'ラベル位置
                eraLabel.Location = New Point(1, 11)
                Label3.Location = New Point(35, 16)
                monthLabel.Location = New Point(40, 11)

                'ラベルフォント
                eraLabel.Font = New Font("MS UI Gothic", 14)
                monthLabel.Font = New Font("MS UI Gothic", 14)
                Label3.Font = New Font("MS UI Gothic", 9)

                'ボタンサイズ
                btnMonthUp.Size = New Size(17, 20)
                btnMonthDown.Size = New Size(17, 20)

                'ボタン位置
                btnMonthUp.Location = New Point(78, 0)
                btnMonthDown.Location = New Point(78, 19)

                'ボタンフォント
                btnMonthUp.Font = New Font("MS UI Gothic", 8)
                btnMonthDown.Font = New Font("MS UI Gothic", 8)

                '表示、非表示
                eraBox.Visible = False
                monthBox.Visible = False
                dateBox.Visible = False
                Label1.Visible = False
                Label2.Visible = False
                btnUp.Visible = False
                btnDown.Visible = False
                dayLabel.Visible = False
                eraLabel.Visible = True
                monthLabel.Visible = True
                Label3.Visible = True
                btnMonthUp.Visible = True
                btnMonthDown.Visible = True
            Else
                Return
            End If
        End Set
    End Property

    ''' <summary>
    ''' 和暦の１文字目（記号）を取得する
    ''' </summary>
    ''' <returns>和暦の１文字目（記号）</returns>
    ''' <remarks></remarks>
    Private Function getEraChar() As String
        Return eraBox.Text.Substring(0, 1)
    End Function

    ''' <summary>
    ''' 和暦の数値部分を取得
    ''' </summary>
    ''' <returns>和暦の数値部分</returns>
    ''' <remarks></remarks>
    Private Function getEraNumStr() As String
        Return eraBox.Text.Substring(1, 2)
    End Function

    ''' <summary>
    ''' 入力されている和暦日付を西暦(yyyy/MM/dd)に変換して返す
    ''' </summary>
    ''' <returns>西暦(yyyy/MM/dd)の文字列</returns>
    ''' <remarks></remarks>
    Public Function getADStr() As String
        Dim ADStr As String = ""

        If EraText = "" OrElse MonthText = "" OrElse DateText = "" Then
            Return ""
        End If

        '和暦の記号取得
        Dim eraChar As String = EraText.Substring(0, 1)

        If eraChar = "M" Then
            '
        ElseIf eraChar = "T" Then
            ADStr = (1911 + Integer.Parse(EraText.Substring(1, 2))).ToString
        ElseIf eraChar = "S" Then
            ADStr = (1925 + Integer.Parse(EraText.Substring(1, 2))).ToString
        ElseIf eraChar = "H" Then
            ADStr = (1988 + Integer.Parse(EraText.Substring(1, 2))).ToString
        ElseIf eraChar = ERA_X Then
            ADStr = (2018 + Integer.Parse(EraText.Substring(1, 2))).ToString
        End If

        ADStr = ADStr & "/" & MonthText & "/" & DateText

        Return ADStr
    End Function

    Public Function getADStr4Ym() As String
        Dim ADStr As String = ""

        'yyyy/MMを返す

        If EraLabelText = "" OrElse MonthLabelText = "" Then
            Return ""
        End If

        '和暦の記号取得
        Dim eraChar As String = EraLabelText.Substring(0, 1)

        If eraChar = "T" Then
            ADStr = (1911 + Integer.Parse(EraLabelText.Substring(1, 2))).ToString
        ElseIf eraChar = "S" Then
            ADStr = (1925 + Integer.Parse(EraLabelText.Substring(1, 2))).ToString
        ElseIf eraChar = "H" Then
            ADStr = (1988 + Integer.Parse(EraLabelText.Substring(1, 2))).ToString
        ElseIf eraChar = ERA_X Then
            ADStr = (2018 + Integer.Parse(EraLabelText.Substring(1, 2))).ToString
        End If

        ADStr = ADStr & "/" & MonthLabelText

        Return ADStr
    End Function

    ''' <summary>
    ''' 西暦表記(yyyy/MM/dd)を和暦表記に変換してテキストボックスへ設定する
    ''' </summary>
    ''' <param name="ymdStr">設定する西暦表記文字列(yyyy/MM/dd)</param>
    ''' <remarks></remarks>
    Public Sub setADStr(ByVal ymdStr)
        clearText()
        If ymdStr = "" Then
            Return
        End If
        Dim ymdArray As String()
        ymdArray = Split(ymdStr, "/")
        Dim yearNum As Integer = Integer.Parse(ymdArray(0))
        Dim monthStr As String = ymdArray(1)
        Dim dateStr As String = ymdArray(2)
        Dim convertNum As Integer

        MonthText = monthStr
        DateText = dateStr

        '西暦から和暦への変換処理
        If yearNum >= 2118 Then
            setWarekiStr(X_MAX)
        ElseIf yearNum >= 2020 Then
            'X２年～
            convertNum = yearNum - 2018
            EraText = ERA_X & If(convertNum < 10, "0" & convertNum, "" & convertNum)
        ElseIf yearNum = 2019 Then
            '平成３１年orX1年
            If Integer.Parse(monthStr) <= 4 Then
                EraText = "H31"
            Else
                EraText = ERA_X & "01"
            End If
        ElseIf yearNum >= 1990 Then
            '平成２年～
            convertNum = yearNum - 1988
            EraText = "H" & If(convertNum < 10, "0" & convertNum, "" & convertNum)
        ElseIf yearNum = 1989 Then
            '平成１年or昭和64年
            If monthStr = "01" AndAlso Integer.Parse(dateStr) <= 7 Then
                EraText = "S64"
            Else
                EraText = "H01"
            End If
        ElseIf yearNum >= 1927 Then
            '昭和２年～
            convertNum = yearNum - 1925
            EraText = "S" & If(convertNum < 10, "0" & convertNum, "" & convertNum)
        ElseIf yearNum = 1926 Then
            '昭和１年or大正１５年
            If monthStr = "12" AndAlso Integer.Parse(dateStr) >= 25 Then
                EraText = "S01"
            Else
                EraText = "T15"
            End If
        ElseIf yearNum >= 1913 Then
            '大正２年～
            convertNum = yearNum - 1911
            EraText = "T" & If(convertNum < 10, "0" & convertNum, "" & convertNum)
        ElseIf yearNum <= 1912 Then
            If (yearNum = 1912 AndAlso Integer.Parse(monthStr) >= 8) OrElse (yearNum = 1912 AndAlso Integer.Parse(monthStr) = 7 AndAlso Integer.Parse(dateStr) >= 30) Then
                EraText = "T01"
            Else
                '大正の初期値(T01.07.30)より以前の場合は全て初期値に設定
                EraText = "T01"
                MonthText = "07"
                DateText = "30"
            End If
        End If

    End Sub

    Public Sub setADStr4Ym(ymStr As String)
        clearText()
        Dim ymArray As String()
        ymArray = Split(ymStr, "/")
        Dim yearNum As Integer = Integer.Parse(ymArray(0))
        Dim monthStr As String = ymArray(1)
        Dim convertNum As Integer

        MonthLabelText = monthStr

        '西暦から和暦への変換処理
        If yearNum >= 2118 Then
            EraLabelText = "99"
            MonthLabelText = "12"
        ElseIf yearNum >= 2020 Then
            'X２年～
            convertNum = yearNum - 2018
            EraLabelText = ERA_X & If(convertNum < 10, "0" & convertNum, "" & convertNum)
        ElseIf yearNum = 2019 Then
            '平成３１年orX1年
            If Integer.Parse(monthStr) <= 4 Then
                EraLabelText = "H31"
            Else
                EraLabelText = ERA_X & "01"
            End If
        ElseIf yearNum >= 1990 Then
            '平成２年～
            convertNum = yearNum - 1988
            EraLabelText = "H" & If(convertNum < 10, "0" & convertNum, "" & convertNum)
        ElseIf yearNum = 1989 Then
            EraLabelText = "H01"
        ElseIf yearNum <= 1988 Then
            EraLabelText = "H01"
            MonthLabelText = "01"
        End If
    End Sub

    ''' <summary>
    ''' 和暦表記(gyy/MM/dd)をテキストボックスへ設定する
    ''' </summary>
    ''' <param name="warekiStr"></param>
    ''' <remarks></remarks>
    Public Sub setWarekiStr(warekiStr As String)
        clearText()
        Dim warekiArray As String() = Split(warekiStr, "/")
        EraText = warekiArray(0)
        MonthText = warekiArray(1)
        DateText = warekiArray(2)
    End Sub

    Public Sub setWarekiStr4Ym(warekiStr As String)
        clearText()
        Dim warekiArray As String() = Split(warekiStr, "/")
        EraLabelText = warekiArray(0)
        MonthLabelText = warekiArray(1)
    End Sub

    ''' <summary>
    ''' 入力日付の曜日（日本語）を取得する
    ''' </summary>
    ''' <returns>曜日（日本語）</returns>
    ''' <remarks></remarks>
    Public Function getDay() As String
        Dim day As String = ""

        '入力値が空白の場合は空文字を返す
        If EraText = "" OrElse MonthText = "" OrElse DateText = "" Then
            Return day
        End If

        Dim ymdStr As String = getADStr()
        Dim yearNum As Integer = Integer.Parse(ymdStr.Substring(0, 4))
        Dim monthNum As Integer = Integer.Parse(ymdStr.Substring(5, 2))
        Dim dateNum As Integer = Integer.Parse(ymdStr.Substring(8, 2))
        Dim dateTime As DateTime = New DateTime(yearNum, monthNum, dateNum)

        '短縮表記の曜日を取得（例：月）
        day = dateTime.ToString("ddd")

        Return day
    End Function

    ''' <summary>
    ''' テキストボックスに設定されているテキストを全て削除する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clearText()
        If boxType <> 5 Then
            EraText = ""
            MonthText = ""
            DateText = ""
        Else
            EraLabelText = ""
            MonthLabelText = ""
        End If

    End Sub

    ''' <summary>
    ''' 年号テキストボックスのKeyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub eraBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles eraBox.KeyDown

        Dim selectedIndex As Integer = eraBox.SelectionStart

        If selectedIndex = 0 Then
            '1文字目（和暦の記号）
            If e.KeyCode = Keys.Right Then
                eraBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.T OrElse e.KeyCode = Keys.S OrElse e.KeyCode = Keys.H OrElse e.KeyCode = Asc(ERA_X) Then
                If e.KeyCode = Keys.T Then
                    '大正の初期値を設定
                    setWarekiStr(TAISYO_MIN)
                ElseIf e.KeyCode = Keys.S Then
                    '昭和の初期値を設定
                    setWarekiStr(SYOWA_MIN)
                ElseIf e.KeyCode = Keys.H Then
                    '平成の初期値を設定
                    setWarekiStr(HEISEI_MIN)
                ElseIf e.KeyCode = Asc(ERA_X) Then
                    'Xの初期値を設定
                    setWarekiStr(X_MIN)
                End If
                eraBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 1 Then
            '記号取得
            Dim eraChar As String = getEraChar()

            '2文字目(和暦の10の位)
            If e.KeyCode = Keys.Left Then
                eraBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                eraBox.Select(2, 1)
                e.SuppressKeyPress = True
            ElseIf (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) Then
                If (e.KeyCode = Keys.D0 OrElse e.KeyCode = Keys.NumPad0) AndAlso Integer.Parse(getEraNumStr.Substring(1, 1)) = 0 Then
                    EraText = eraChar & "09"
                End If
                Dim daysNum As Integer = getMonthDaysNum(getEraChar() & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & getEraNumStr().Substring(1, 1), MonthText)
                If Integer.Parse(DateText) > daysNum Then
                    DateText = "" & daysNum
                End If

                '入力された年月日が存在するかチェック
                If checkDate(getEraChar() & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & getEraNumStr().Substring(1, 1), MonthText, DateText) = True Then
                    EraText = getEraChar() & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & getEraNumStr().Substring(1, 1)
                Else
                    '存在しない場合は変換処理
                    convertEraText(getEraChar() & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & getEraNumStr().Substring(1, 1), MonthText, DateText)
                End If
                eraBox.Select(2, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If

        ElseIf selectedIndex = 2 Then
            '10の位の文字取得
            Dim secondEraChar As String = EraText.Substring(1, 1)

            '3文字目（和暦の１の位）
            If e.KeyCode = Keys.Left Then
                eraBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                monthBox.Focus()
                monthBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf (secondEraChar = "0" AndAlso Keys.D1 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (secondEraChar = "0" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) OrElse (secondEraChar <> "0" AndAlso Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (secondEraChar <> "0" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) Then
                Dim daysNum As Integer = getMonthDaysNum(getEraChar() & getEraNumStr().Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)), MonthText)
                If Integer.Parse(DateText) > daysNum Then
                    DateText = "" & daysNum
                End If
                '入力された年月日が存在するかチェック
                If checkDate(getEraChar() & getEraNumStr().Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)), MonthText, DateText) = True Then
                    EraText = getEraChar() & getEraNumStr().Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))
                Else
                    '存在しない場合は変換処理
                    convertEraText(getEraChar() & getEraNumStr().Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)), MonthText, DateText)
                End If
                monthBox.Focus()
                monthBox.Select(0, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If

        End If
    End Sub

    ''' <summary>
    ''' 月のテキストボックスのKeyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub monthBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles monthBox.KeyDown

        Dim selectedIndex As Integer = monthBox.SelectionStart

        If selectedIndex = 0 Then
            '1文字目(月の10の位)
            If e.KeyCode = Keys.Left Then
                eraBox.Focus()
                eraBox.Select(2, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                monthBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D1) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad1) Then
                If (e.KeyCode = Keys.D1 OrElse e.KeyCode = Keys.NumPad1) AndAlso Integer.Parse(MonthText.Substring(1, 1)) >= 3 Then
                    MonthText = "12"
                ElseIf (e.KeyCode = Keys.D0 OrElse e.KeyCode = Keys.NumPad0) AndAlso Integer.Parse(MonthText.Substring(1, 1)) = 0 Then
                    MonthText = "09"
                Else
                    MonthText = If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & MonthText.Substring(1, 1)
                End If
                Dim daysNum As Integer = getMonthDaysNum(EraText, MonthText)
                If Integer.Parse(DateText) > daysNum Then
                    DateText = "" & daysNum
                End If

                '入力された年月日が存在するかチェック
                If checkDate(EraText, If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & MonthText.Substring(1, 1), DateText) = True Then
                    MonthText = If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & MonthText.Substring(1, 1)
                Else
                    '存在しない場合は変換処理
                    convertEraText(EraText, If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & MonthText.Substring(1, 1), DateText)
                End If
                monthBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 1 Then
            '10の位の文字取得
            Dim firstMonthChar As String = MonthText.Substring(0, 1)

            '2文字目（月の１の位）の処理
            If e.KeyCode = Keys.Left Then
                monthBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                dateBox.Focus()
                dateBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf (firstMonthChar = "0" AndAlso Keys.D1 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (firstMonthChar = "0" AndAlso Keys.NumPad1 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9) OrElse (firstMonthChar = "1" AndAlso Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D2) OrElse (firstMonthChar = "1" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad2) Then

                MonthText = MonthText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))
                Dim daysNum As Integer = getMonthDaysNum(EraText, MonthText)
                If Integer.Parse(DateText) > daysNum Then
                    DateText = "" & daysNum
                End If

                '入力された年月日が存在するかチェック
                If checkDate(EraText, MonthText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)), DateText) = True Then
                    MonthText = MonthText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))
                Else
                    '存在しない場合は変換処理
                    convertEraText(EraText, MonthText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)), DateText)
                End If
                dateBox.Focus()
                dateBox.Select(0, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' 日にちテキストボックスのKeyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dateBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dateBox.KeyDown

        Dim selectedIndex As Integer = dateBox.SelectionStart
        '入力されている月の日数を取得
        Dim daysNum As Integer = getMonthDaysNum(EraText, MonthText)

        If selectedIndex = 0 Then
            '1文字目(日の10の位)
            If e.KeyCode = Keys.Left Then
                monthBox.Focus()
                monthBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (MonthText = "02" AndAlso Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D2) OrElse (MonthText = "02" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad2) OrElse (MonthText <> "02" AndAlso Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D3) OrElse (MonthText <> "02" AndAlso Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad3) Then
                If (e.KeyCode = Keys.D0 OrElse e.KeyCode = Keys.NumPad0) AndAlso DateText.Substring(1, 1) = "0" Then
                    DateText = "09"
                End If

                DateText = If(daysNum <= If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & DateText.Substring(1, 1), daysNum.ToString(), If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & DateText.Substring(1, 1))

                '入力された年月日が存在するかチェック
                If checkDate(EraText, MonthText, If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & DateText.Substring(1, 1)) = True Then
                    DateText = If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & DateText.Substring(1, 1)
                Else
                    '存在しない場合は変換処理
                    convertEraText(EraText, MonthText, If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)) & DateText.Substring(1, 1))
                End If
                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        ElseIf selectedIndex = 1 Then
            '10の位の文字取得
            Dim firstDateChar As String = DateText.Substring(0, 1)

            '2文字目（日の１の位）の処理
            If e.KeyCode = Keys.Left Then
                dateBox.Select(0, 1)
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Right Then
                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            ElseIf (firstDateChar = "0" AndAlso (Keys.D1 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad1 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9)) OrElse
                   (firstDateChar = "1" AndAlso (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9)) OrElse
                   (firstDateChar = "2" AndAlso daysNum = 28 AndAlso (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D8) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad8)) OrElse
                   (firstDateChar = "2" AndAlso daysNum >= 29 AndAlso (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D9) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad9)) OrElse
                   (firstDateChar = "3" AndAlso daysNum = 30 AndAlso (Keys.D0 = e.KeyCode) OrElse (Keys.NumPad0 = e.KeyCode)) OrElse
                   (firstDateChar = "3" AndAlso daysNum = 31 AndAlso (Keys.D0 <= e.KeyCode AndAlso e.KeyCode <= Keys.D1) OrElse (Keys.NumPad0 <= e.KeyCode AndAlso e.KeyCode <= Keys.NumPad1)) Then
                '入力された年月日が存在するかチェック
                If checkDate(EraText, MonthText, DateText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))) = True Then
                    DateText = DateText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode))
                Else
                    '存在しない場合は変換処理
                    convertEraText(EraText, MonthText, DateText.Substring(0, 1) & If(e.KeyCode >= Keys.NumPad0, Chr(e.KeyCode - 48), Chr(e.KeyCode)))
                End If
                dateBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' 入力された日付が存在するかチェック
    ''' </summary>
    ''' <param name="eraStr">年号の文字列</param>
    ''' <param name="monthStr">月の文字列</param>
    ''' <param name="dateStr">日にちの文字列</param>
    ''' <returns>存在するかの判定値（Boolean）</returns>
    ''' <remarks></remarks>
    Private Function checkDate(ByVal eraStr As String, ByVal monthStr As String, ByVal dateStr As String) As Boolean
        Dim eraChar As String = eraStr.Substring(0, 1)
        Dim eraNum As String = Integer.Parse(eraStr.Substring(1, 2))
        Dim monthNum As String = Integer.Parse(monthStr)
        Dim dateNum As String = Integer.Parse(dateStr)

        If eraChar = "T" Then
            '大正の判定(大正１年７月３０日～大正１５年１２月２４日)
            If eraNum = 1 Then
                If monthNum < 7 Then
                    Return False
                ElseIf monthNum = 7 Then
                    If dateNum < 30 Then
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            ElseIf 2 <= eraNum AndAlso eraNum <= 14 Then
                Return True
            ElseIf eraNum = 15 Then
                If monthNum = 12 Then
                    If dateNum <= 24 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return True
                End If
            Else
                Return False
            End If
        ElseIf eraChar = "S" Then
            '昭和の判定（昭和１年１２月２５日～昭和６４年１月７日）
            If eraNum = 1 Then
                If monthNum = 12 Then
                    If dateNum <= 24 Then
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return False
                End If
            ElseIf 2 <= eraNum AndAlso eraNum <= 63 Then
                Return True
            ElseIf eraNum = 64 Then
                If monthNum = 1 Then
                    If dateNum <= 7 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        ElseIf eraChar = "H" Then
            '平成の判定（平成１年１月８日～平成３1年４月３０日)
            If eraNum = 1 Then
                If monthNum = 1 Then
                    If dateNum < 8 Then
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            ElseIf 2 <= eraNum AndAlso eraNum <= 30 Then
                Return True
            ElseIf eraNum = 31 Then
                If monthNum < 5 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        ElseIf eraChar = ERA_X Then
            'Xの判定（X１年５月１日～X９９年１２月３１日）
            If eraNum = 1 Then
                If monthNum < 5 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 存在する日付に変換する
    ''' </summary>
    ''' <param name="eraStr">年号の文字列</param>
    ''' <param name="monthStr">月の文字列</param>
    ''' <param name="dateStr">日にちの文字列</param>
    ''' <remarks></remarks>
    Private Sub convertEraText(ByVal eraStr As String, ByVal monthStr As String, ByVal dateStr As String)
        Dim eraChar As String = eraStr.Substring(0, 1)
        Dim eraNum As String = Integer.Parse(eraStr.Substring(1, 2))
        Dim monthNum As String = Integer.Parse(monthStr)
        Dim dateNum As String = Integer.Parse(dateStr)

        If eraChar = ERA_X Then
            If eraNum = 1 Then
                EraText = "H31"
            End If
        ElseIf eraChar = "H" Then
            If eraNum = 1 Then
                EraText = "S64"
                DateText = dateStr
            ElseIf eraNum = 31 Then
                EraText = ERA_X & "01"
            ElseIf 32 <= eraNum Then
                Dim nextEraNum As Integer = eraNum - 31 + 1
                EraText = ERA_X & If(nextEraNum >= 10, "" & nextEraNum, "0" & nextEraNum)
            End If
        ElseIf eraChar = "S" Then
            If eraNum = 1 Then
                EraText = "T15"
                DateText = dateStr
            ElseIf eraNum = 64 Then
                EraText = "H01"
                DateText = dateStr
            ElseIf 65 <= eraNum Then
                Dim nextEraNum As Integer = eraNum - 64 + 1
                If nextEraNum <= 30 Then
                    EraText = "H" & If(nextEraNum >= 10, "" & nextEraNum, "0" & nextEraNum)
                ElseIf nextEraNum = 31 Then
                    If monthNum < 5 Then
                        EraText = "H31"
                    Else
                        EraText = ERA_X & "01"
                    End If
                Else
                    Dim nextNextEraNum As Integer = nextEraNum - 30
                    EraText = ERA_X & If(nextNextEraNum >= 10, "" & nextNextEraNum, "0" & nextNextEraNum)
                End If
            End If
        ElseIf eraChar = "T" Then
            If eraNum = 1 Then
                MonthText = "07"
                DateText = "30"
            ElseIf eraNum = 15 Then
                EraText = "S01"
                DateText = dateStr
            ElseIf 16 <= eraNum Then
                Dim nextEraNum As Integer = eraNum - 15 + 1
                If nextEraNum <= 63 Then
                    EraText = "S" & If(nextEraNum >= 10, "" & nextEraNum, "0" & nextEraNum)
                ElseIf nextEraNum = 64 Then
                    If monthNum = 1 Then
                        If dateNum <= 7 Then
                            EraText = "S64"
                        Else
                            EraText = "H01"
                        End If
                    Else
                        EraText = "H01"
                    End If
                ElseIf 65 <= nextEraNum Then
                    Dim nextNextEraNum As Integer = nextEraNum - 63
                    EraText = "H" & If(nextNextEraNum >= 10, "" & nextNextEraNum, "0" & nextNextEraNum)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 月の日数を取得
    ''' </summary>
    ''' <param name="eraStr">年号の文字列</param>
    ''' <param name="monthStr">月の文字列</param>
    ''' <returns>月の日数</returns>
    ''' <remarks></remarks>
    Private Function getMonthDaysNum(ByVal eraStr As String, ByVal monthStr As String) As Integer
        Dim daysNum, AD As Integer
        Dim eraChar As String = eraStr.Substring(0, 1)
        Dim eraStrNum As Integer = Integer.Parse(eraStr.Substring(1, 2))
        Dim monthStrNum As Integer = Integer.Parse(monthStr)

        If eraChar = "T" Then
            AD = 1911 + eraStrNum
        ElseIf eraChar = "S" Then
            AD = 1925 + eraStrNum
        ElseIf eraChar = "H" Then
            AD = 1988 + eraStrNum
        ElseIf eraChar = ERA_X Then
            AD = 2018 + eraStrNum
        End If

        daysNum = Date.DaysInMonth(AD, monthStrNum)

        Return daysNum
    End Function

    ''' <summary>
    ''' 年号テキストボックスのマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub eraBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles eraBox.MouseClick
        Dim selectedIndex As Integer = eraBox.SelectionStart
        If selectedIndex = 3 Then
            eraBox.Select(selectedIndex - 1, 1)
        Else
            eraBox.Select(selectedIndex, 1)
        End If
    End Sub

    ''' <summary>
    ''' 月のテキストボックスのマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub monthBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles monthBox.MouseClick
        If MonthText = "" Then
            eraBox.Focus()
            monthBox.Focus()
            eraBox.Focus()
            Return
        End If

        Dim selectedIndex As Integer = monthBox.SelectionStart
        If selectedIndex = 2 Then
            monthBox.Select(selectedIndex - 1, 1)
        Else
            monthBox.Select(selectedIndex, 1)
        End If
    End Sub

    ''' <summary>
    ''' 日にちのテキストボックスのマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dateBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dateBox.MouseClick
        If DateText = "" Then
            eraBox.Focus()
            dateBox.Focus()
            eraBox.Focus()
            Return
        End If

        Dim selectedIndex As Integer = dateBox.SelectionStart
        If selectedIndex = 2 Then
            dateBox.Select(selectedIndex - 1, 1)
        Else
            dateBox.Select(selectedIndex, 1)
        End If
    End Sub

    ''' <summary>
    ''' 年号のテキストボックスのダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub eraBox_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles eraBox.MouseDoubleClick
        eraBox.Select(0, 1)
        Dim calForm As calendarForm = New calendarForm(Me, getADStr())
        calForm.StartPosition = FormStartPosition.CenterScreen
        calForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 月のテキストボックスのダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub monthBox_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles monthBox.MouseDoubleClick
        eraBox.Focus()
        eraBox.Select(0, 1)
        Dim calForm As calendarForm = New calendarForm(Me, getADStr())
        calForm.StartPosition = FormStartPosition.CenterScreen
        calForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 日にちのテキストボックスのダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dateBox_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dateBox.MouseDoubleClick
        eraBox.Focus()
        eraBox.Select(0, 1)
        Dim calForm As calendarForm = New calendarForm(Me, getADStr())
        calForm.StartPosition = FormStartPosition.CenterScreen
        calForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' 年号のテキストボックスのフォーカスイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub eraBox_GotFocus(sender As Object, e As System.EventArgs) Handles eraBox.GotFocus
        If focusControlFlg = False Then
            eraBox.Select(0, 1)
        End If
        focusedTextBoxNum = 1
    End Sub

    Private Sub monthBox_GotFocus(sender As Object, e As System.EventArgs) Handles monthBox.GotFocus
        focusedTextBoxNum = 2
    End Sub

    Private Sub dateBox_GotFocus(sender As Object, e As System.EventArgs) Handles dateBox.GotFocus
        focusedTextBoxNum = 3
    End Sub

    Private Sub ymdBox_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.ContextMenu = New ContextMenu()
        eraBox.ContextMenu = New ContextMenu()
        monthBox.ContextMenu = New ContextMenu()
        dateBox.ContextMenu = New ContextMenu()

        setADStr4Ym(DateTime.Now.ToString("yyyy/MM"))

        Timer1.Interval = 500
        Timer2.Interval = 500
        Timer3.Interval = 500
        Timer4.Interval = 500
    End Sub

    Public Function getAge()
        Dim today As DateTime = DateTime.Today
        Dim inputDate As String = getADStr()
        Dim yyyy As Integer = inputDate.Substring(0, 4)
        Dim MM As Integer = inputDate.Substring(5, 2)
        Dim dd As Integer = inputDate.Substring(8, 2)
        Dim age As Integer = today.Year - yyyy
        '誕生日がまだ来ていなければ、1引く
        If today.Month < MM OrElse (today.Month = MM AndAlso today.Day < dd) Then
            age -= 1
        End If

        Return age
    End Function

    Private Function getDateTimeObject(ymdStr As String) As DateTime
        Dim ymdArray() As String = ymdStr.Split("/")
        Return New DateTime(CInt(ymdArray(0)), CInt(ymdArray(1)), CInt(ymdArray(2)))
    End Function

    Private Sub eraTextUpDown(upDown As Integer, selectionStart As Integer)
        Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr())
        If upDown = VALUE_UP Then
            '年の増加処理
            If selectionStart = 0 Then
                '記号が選択されている場合
                If getEraChar() = "T" Then
                    setWarekiStr(SYOWA_MIN)
                ElseIf getEraChar() = "S" Then
                    setWarekiStr(HEISEI_MIN)
                ElseIf getEraChar() = "H" Then
                    setWarekiStr(X_MIN)
                End If
            ElseIf selectionStart = 1 Then
                '10の位が選択されている場合、10年増加
                Dim plusTenYearDateTime As DateTime = currentInputDateTime.AddYears(10)
                setADStr(plusTenYearDateTime.ToString("yyyy/MM/dd"))
            ElseIf selectionStart = 2 Then
                '1の位が選択されている場合、1年増加
                Dim plusOneYearDateTime As DateTime = currentInputDateTime.AddYears(1)
                setADStr(plusOneYearDateTime.ToString("yyyy/MM/dd"))
            End If
        ElseIf upDown = VALUE_DOWN Then
            '年の減少処理
            If selectionStart = 0 Then
                '記号が選択されている場合
                If getEraChar() = "S" Then
                    setWarekiStr(TAISYO_MIN)
                ElseIf getEraChar() = "H" Then
                    setWarekiStr(SYOWA_MIN)
                ElseIf getEraChar() = ERA_X Then
                    setWarekiStr(HEISEI_MIN)
                End If
            ElseIf selectionStart = 1 Then
                '10の位が選択されている場合、10年減少
                Dim minusTenYearDateTime As DateTime = currentInputDateTime.AddYears(-10)
                setADStr(minusTenYearDateTime.ToString("yyyy/MM/dd"))
            ElseIf selectionStart = 2 Then
                '1の位が選択されている場合、1年減少
                Dim minusOneYearDateTime As DateTime = currentInputDateTime.AddYears(-1)
                setADStr(minusOneYearDateTime.ToString("yyyy/MM/dd"))
            End If
        End If
    End Sub

    Private Sub monthTextUpDown(upDown As Integer, selectionStart As Integer)
        Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr())
        Dim firstMonthStr As String = MonthText.Substring(0, 1)
        Dim secondMonthStr As String = MonthText.Substring(1, 1)
        If upDown = VALUE_UP Then
            '月の増加処理
            If selectionStart = 0 Then
                '10の位が選択されている場合
                Dim plusMonthDateTime As DateTime
                If firstMonthStr = "0" Then
                    If secondMonthStr = "1" OrElse secondMonthStr = "2" Then
                        plusMonthDateTime = currentInputDateTime.AddMonths(10)
                    Else
                        plusMonthDateTime = currentInputDateTime.AddMonths(12 - CInt(secondMonthStr))
                    End If
                ElseIf firstMonthStr = "1" Then
                    If secondMonthStr = "0" Then
                        plusMonthDateTime = currentInputDateTime.AddMonths(3)
                    ElseIf secondMonthStr = "1" OrElse secondMonthStr = "2" Then
                        plusMonthDateTime = currentInputDateTime.AddMonths(2)
                    End If
                End If
                setADStr(plusMonthDateTime.ToString("yyyy/MM/dd"))
            ElseIf selectionStart = 1 Then
                '1の位が選択されている場合、1ヶ月増加
                Dim plusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(1)
                setADStr(plusOneMonthDateTime.ToString("yyyy/MM/dd"))
            End If
        ElseIf upDown = VALUE_DOWN Then
            '月の減少処理
            If selectionStart = 0 Then
                '10の位が選択されている場合
                Dim minusMonthDateTime As DateTime
                If firstMonthStr = "0" Then
                    If secondMonthStr = "1" OrElse secondMonthStr = "2" Then
                        minusMonthDateTime = currentInputDateTime.AddMonths(-2)
                    Else
                        minusMonthDateTime = currentInputDateTime.AddMonths(-CInt(secondMonthStr))
                    End If
                ElseIf firstMonthStr = "1" Then
                    If secondMonthStr = "0" Then
                        minusMonthDateTime = currentInputDateTime.AddMonths(-9)
                    ElseIf secondMonthStr = "1" OrElse secondMonthStr = "2" Then
                        minusMonthDateTime = currentInputDateTime.AddMonths(-10)
                    End If
                End If
                setADStr(minusMonthDateTime.ToString("yyyy/MM/dd"))
            ElseIf selectionStart = 1 Then
                '1の位が選択されている場合、1ヶ月減少
                Dim minusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(-1)
                setADStr(minusOneMonthDateTime.ToString("yyyy/MM/dd"))
            End If
        End If
    End Sub

    Private Sub dateTextUpDown(upDown As Integer, selectionStart As Integer)
        Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr())
        If upDown = VALUE_UP Then
            '日の増加処理
            If selectionStart = 0 Then
                '10の位が選択されている場合
                Dim dateNum As Integer = CInt(DateText)
                Dim secondDateStrNum As Integer = CInt(DateText.Substring(1, 1))
                Dim plusDayDateTime As DateTime
                Dim daysOfMonth As Integer = getMonthDaysNum(EraText, MonthText)
                If dateNum + 10 > daysOfMonth Then
                    plusDayDateTime = currentInputDateTime.AddDays(daysOfMonth - dateNum + secondDateStrNum)
                Else
                    plusDayDateTime = currentInputDateTime.AddDays(10)
                End If
                setADStr(plusDayDateTime.ToString("yyyy/MM/dd"))
            ElseIf selectionStart = 1 Then
                '1の位が選択されている場合、1日増加
                Dim plusOneDayDateTime As DateTime = currentInputDateTime.AddDays(1)
                setADStr(plusOneDayDateTime.ToString("yyyy/MM/dd"))
            End If
        ElseIf upDown = VALUE_DOWN Then
            '日の減少処理
            If selectionStart = 0 Then
                '10の位が選択されている場合、10日減少
                '後でちゃんとした動きに修正する
                Dim minusTenDayDateTime As DateTime = currentInputDateTime.AddDays(-10)
                setADStr(minusTenDayDateTime.ToString("yyyy/MM/dd"))
            ElseIf selectionStart = 1 Then
                '1の位が選択されている場合、1日減少
                Dim minusOneDayDateTime As DateTime = currentInputDateTime.AddDays(-1)
                setADStr(minusOneDayDateTime.ToString("yyyy/MM/dd"))
            End If
        End If
    End Sub

    Private Sub monthLabelTextUpDown(upDown As Integer)
        Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr4Ym() & "/01")
        If upDown = VALUE_UP Then
            Dim plusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(1)
            setADStr4Ym(plusOneMonthDateTime.ToString("yyyy/MM"))
        ElseIf upDown = VALUE_DOWN Then
            Dim minusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(-1)
            setADStr4Ym(minusOneMonthDateTime.ToString("yyyy/MM"))
        Else
            Return
        End If
    End Sub

    Public Function getPrevYmStr()
        If boxType = 5 Then
            Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr4Ym() & "/01")
            If currentInputDateTime.ToString("yyyy/MM") = "1989/01" Then
                Return "1989/01"
            End If
            Dim minusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(-1)
            Return minusOneMonthDateTime.ToString("yyyy/MM")
        Else
            Return ""
        End If
    End Function

    Public Function getNextYmStr()
        If boxType = 5 Then
            Dim currentInputDateTime As DateTime = getDateTimeObject(getADStr4Ym() & "/01")
            If currentInputDateTime.ToString("yyyy/MM") = "2117/12" Then
                Return "2117/12"
            End If
            Dim plusOneMonthDateTime As DateTime = currentInputDateTime.AddMonths(1)
            Return plusOneMonthDateTime.ToString("yyyy/MM")
        Else
            Return ""
        End If
    End Function

    Private Sub upText()
        If EraText = "" Then
            Return
        End If

        If focusedTextBoxNum = 1 Then
            '和暦の増加処理
            Dim ss As Integer = eraBox.SelectionStart
            eraTextUpDown(VALUE_UP, ss)
            eraBox.Select(ss, 1)
            focusControlFlg = True
            eraBox.Focus()
            focusControlFlg = False
        ElseIf focusedTextBoxNum = 2 Then
            '月の増加処理
            Dim ss As Integer = monthBox.SelectionStart
            monthTextUpDown(VALUE_UP, ss)
            monthBox.Select(ss, 1)
            monthBox.Focus()
        ElseIf focusedTextBoxNum = 3 Then
            '日の増加処理
            Dim ss As Integer = dateBox.SelectionStart
            dateTextUpDown(VALUE_UP, ss)
            dateBox.Select(ss, 1)
            dateBox.Focus()
        Else
            Return
        End If
    End Sub

    Private Sub downText()
        If EraText = "" Then
            Return
        End If

        If focusedTextBoxNum = 1 Then
            '和暦の減少処理
            Dim ss As Integer = eraBox.SelectionStart
            eraTextUpDown(VALUE_DOWN, ss)
            eraBox.Select(ss, 1)
            focusControlFlg = True
            eraBox.Focus()
            focusControlFlg = False
        ElseIf focusedTextBoxNum = 2 Then
            '月の減少処理
            Dim ss As Integer = monthBox.SelectionStart
            monthTextUpDown(VALUE_DOWN, ss)
            monthBox.Select(ss, 1)
            monthBox.Focus()
        ElseIf focusedTextBoxNum = 3 Then
            '日の減少処理
            Dim ss As Integer = dateBox.SelectionStart
            dateTextUpDown(VALUE_DOWN, ss)
            dateBox.Select(ss, 1)
            dateBox.Focus()
        Else
            Return
        End If
    End Sub

    Private Sub btnUp_MouseDown(sender As Object, e As MouseEventArgs) Handles btnUp.MouseDown
        upText()
        Timer1.Start()
    End Sub

    Private Sub btnUp_MouseUp(sender As Object, e As MouseEventArgs) Handles btnUp.MouseUp
        Timer1.Stop()
        Timer1.Interval = 500
    End Sub

    Private Sub btnDown_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDown.MouseDown
        downText()
        Timer2.Start()
    End Sub

    Private Sub btnDown_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDown.MouseUp
        Timer2.Stop()
        Timer2.Interval = 500
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        upText()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As System.EventArgs) Handles Timer2.Tick
        Timer2.Interval = 100
        downText()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As System.EventArgs) Handles Timer3.Tick
        Timer3.Interval = 100
        monthLabelTextUpDown(VALUE_UP)
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As System.EventArgs) Handles Timer4.Tick
        Timer4.Interval = 100
        monthLabelTextUpDown(VALUE_DOWN)
    End Sub

    Private Sub textBox_TextChanged(sender As Object, e As System.EventArgs) Handles eraBox.TextChanged, monthBox.TextChanged, dateBox.TextChanged
        dayLabel.Text = "(" & getDay() & ")"
    End Sub

    Private Sub btnMonthUp_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles btnMonthUp.MouseDown
        monthLabelTextUpDown(VALUE_UP)
        Timer3.Start()
    End Sub

    Private Sub btnMonthUp_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles btnMonthUp.MouseUp
        Timer3.Stop()
        Timer3.Interval = 500
        RaiseEvent YmLabelTextChage(Me, New EventArgs)
    End Sub

    Private Sub btnMonthDown_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles btnMonthDown.MouseDown
        monthLabelTextUpDown(VALUE_DOWN)
        Timer4.Start()
    End Sub

    Private Sub btnMonthDown_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles btnMonthDown.MouseUp
        Timer4.Stop()
        Timer4.Interval = 500
        RaiseEvent YmLabelTextChage(Me, New EventArgs)
    End Sub
End Class
