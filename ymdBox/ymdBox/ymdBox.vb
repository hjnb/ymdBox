Imports System.Windows.Forms
Imports System.Drawing

Public Class ymdBox

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

        If eraChar = "T" Then
            ADStr = (1911 + Integer.Parse(EraText.Substring(1, 2))).ToString
        ElseIf eraChar = "S" Then
            ADStr = (1925 + Integer.Parse(EraText.Substring(1, 2))).ToString
        ElseIf eraChar = "H" Then
            ADStr = (1988 + Integer.Parse(EraText.Substring(1, 2))).ToString
        End If

        ADStr = ADStr & "/" & MonthText & "/" & DateText

        Return ADStr

    End Function

    ''' <summary>
    ''' 西暦表記(yyyy/MM/dd)を和暦表記に変換してテキストボックスへ設定する
    ''' </summary>
    ''' <param name="ymdStr">設定する西暦表記文字列(yyyy/MM/dd)</param>
    ''' <remarks></remarks>
    Public Sub setADStr(ByVal ymdStr)
        Dim ymdArray As String()
        ymdArray = Split(ymdStr, "/")
        Dim yearNum As Integer = Integer.Parse(ymdArray(0))
        Dim monthStr As String = ymdArray(1)
        Dim dateStr As String = ymdArray(2)
        Dim convertNum As Integer

        MonthText = monthStr
        DateText = dateStr

        '西暦から和暦への変換処理
        If yearNum >= 2019 Then
            '平成の最終日（予定）
            EraText = "H30"
            MonthText = "12"
            DateText = "31"
        ElseIf yearNum >= 1990 Then
            '平成
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
            '昭和
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
            '大正
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
        Dim monthNum As Integer = Integer.Parse(ymdStr.Substring(4, 2))
        Dim dateNum As Integer = Integer.Parse(ymdStr.Substring(6, 2))
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
        EraText = ""
        MonthText = ""
        DateText = ""
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
            If eraBox.Text.Length = 0 Then
                If e.KeyCode = Keys.T Then
                    '大正の初期値を設定
                    EraText = "T01"
                    MonthText = "07"
                    DateText = "30"
                ElseIf e.KeyCode = Keys.S Then
                    '昭和の初期値を設定
                    EraText = "S01"
                    MonthText = "12"
                    DateText = "25"
                ElseIf e.KeyCode = Keys.H Then
                    '平成の初期値を設定
                    EraText = "H01"
                    MonthText = "01"
                    DateText = "08"
                End If
                eraBox.Select(1, 1)
                e.SuppressKeyPress = True
            Else
                If e.KeyCode = Keys.Right Then
                    eraBox.Select(1, 1)
                    e.SuppressKeyPress = True
                ElseIf e.KeyCode = Keys.T OrElse e.KeyCode = Keys.S OrElse e.KeyCode = Keys.H Then
                    Dim daysNum As Integer = getMonthDaysNum(Chr(e.KeyCode) & getEraNumStr(), MonthText)
                    If Integer.Parse(DateText) > daysNum Then
                        DateText = "" & daysNum
                    End If

                    '入力された年月日が存在するかチェック
                    If checkDate(Chr(e.KeyCode) & getEraNumStr(), MonthText, DateText) = True Then
                        EraText = Chr(e.KeyCode) & getEraNumStr()
                    Else
                        '存在しない場合は変換処理
                        convertEraText(Chr(e.KeyCode) & getEraNumStr(), MonthText, DateText)
                    End If
                    eraBox.Select(1, 1)
                    e.SuppressKeyPress = True
                Else
                    e.SuppressKeyPress = True
                End If
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
            '平成の判定（平成１年１月８日～平成３０年１２月３１日)
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
            Else
                Return False
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

        If eraChar = "H" Then
            If eraNum = 1 Then
                EraText = "S64"
                DateText = dateStr
            ElseIf 31 <= eraNum Then
                EraText = "H30"
                MonthText = "12"
                DateText = "31"
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
                If nextEraNum >= 31 Then
                    EraText = "H30"
                    MonthText = "12"
                    DateText = "31"
                Else
                    EraText = "H" & If(nextEraNum >= 10, "" & nextEraNum, "0" & nextEraNum)
                End If
            End If
        ElseIf eraChar = "T" Then
            If eraNum = 1 Then
                MonthText = "07"
                DateText = "30"
            ElseIf eraNum = 15 Then
                EraText = "S01"
                DateText = dateStr
            ElseIf 15 <= eraNum Then
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
        eraBox.Select(0, 1)
    End Sub

End Class
