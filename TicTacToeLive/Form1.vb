Imports Newtonsoft.Json.Linq
Public Class Form1
    Dim RoomID As Integer
    Dim checkInfo = ""
    Dim flag = True
    Dim gameStart = True
    Dim Matrix(0 To 2, 0 To 2)
    Dim steps=0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim liveAddress = "http://api.live.bilibili.com/ajax/msg?roomid=145205" '直播间地址
        Dim JSONStr = GetData(liveAddress, "") '定义json字符串对象
        Dim js = JObject.Parse(JSONStr) '定义json对象（jobject）
        checkInfo = js.SelectToken("data").SelectToken("room[9]").SelectToken("check_info").SelectToken("ct")
        RoomID = js.SelectToken("data").SelectToken("room").LongCount - 1
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim liveAddress = "http://api.live.bilibili.com/ajax/msg?roomid=145205" '直播间地址
        Dim JSONStr = GetData(liveAddress, "") '定义json字符串对象
        Dim js = JObject.Parse(JSONStr) '定义json对象（jobject）
        Dim Command = "" '指令
        RoomID = js.SelectToken("data").SelectToken("room").LongCount - 1 '先获取数量
        If RoomID < 9 Then '小于9时
            Command = js.SelectToken("data").SelectToken("room[" & RoomID & "]").SelectToken("text") '指令赋值
            checkInfo = js.SelectToken("data").SelectToken("room[" & RoomID & "]").SelectToken("check_info").SelectToken("ct")
        End If
        If RoomID = 9 Then '等于9
            If js.SelectToken("data").SelectToken("room[9]").SelectToken("check_info").SelectToken("ct") <> checkInfo Then '如果两次checkinfo不同
                Command = js.SelectToken("data").SelectToken("room[9]").SelectToken("text") '指令赋值
                checkInfo = js.SelectToken("data").SelectToken("room[9]").SelectToken("check_info").SelectToken("ct") '定义新的checkinfo
                Dim nickname = ""
                nickname = js.SelectToken("data").SelectToken("room[9]").SelectToken("nickname")
                TextBox1.Text = nickname & " | " & Command & vbCrLf & TextBox1.Text
            End If
        End If
        ActMain(Command)
        Timer1.Enabled = True
    End Sub
    Private Function ActMain(Command As String) '互动主函数
        'MsgBox(Command)
        Label10.Text = "正常运行中..."
        Select Case Command
            Case "11"
                If flag = True And Matrix(0, 0) = 0 Then
                    Label1.Text = "O"
                    Label1.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(0, 0) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(0, 0) = 0 Then
                    Label1.Text = "X"
                    Label1.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(0, 0) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "12"
                If flag = True And Matrix(0, 1) = 0 Then
                    Label2.Text = "O"
                    Label2.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(0, 1) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(0, 1) = 0 Then
                    Label2.Text = "X"
                    Label2.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(0, 1) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "13"
                If flag = True And Matrix(0, 2) = 0 Then
                    Label3.Text = "O"
                    Label3.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(0, 2) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(0, 2) = 0 Then
                    Label3.Text = "X"
                    Label3.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(0, 2) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "21"
                If flag = True And Matrix(1, 0) = 0 Then
                    Label4.Text = "O"
                    Label4.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(1, 0) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(1, 0) = 0 Then
                    Label4.Text = "X"
                    Label4.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(1, 0) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "22"
                If flag = True And Matrix(1, 1) = 0 Then
                    Label5.Text = "O"
                    Label5.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(1, 1) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(1, 1) = 0 Then
                    Label5.Text = "X"
                    Label5.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(1, 1) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "23"
                If flag = True And Matrix(1, 2) = 0 Then
                    Label6.Text = "O"
                    Label6.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(1, 2) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(1, 2) = 0 Then
                    Label6.Text = "X"
                    Label6.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(1, 2) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "31"
                If flag = True And Matrix(2, 0) = 0 Then
                    Label7.Text = "O"
                    Label7.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(2, 0) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(2, 0) = 0 Then
                    Label7.Text = "X"
                    Label7.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(2, 0) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "32"
                If flag = True And Matrix(2, 1) = 0 Then
                    Label8.Text = "O"
                    Label8.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(2, 1) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(2, 1) = 0 Then
                    Label8.Text = "X"
                    Label8.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(2, 1) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "33"
                If flag = True And Matrix(2, 2) = 0 Then
                    Label9.Text = "O"
                    Label9.ForeColor = Color.FromArgb(255, 0, 0)
                    Matrix(2, 2) = 1
                    flag = False
                    steps += 1
                ElseIf flag = False And Matrix(2, 2) = 0 Then
                    Label9.Text = "X"
                    Label9.ForeColor = Color.FromArgb(0, 0, 255)
                    Matrix(2, 2) = 2
                    flag = True
                    steps += 1
                End If
                Exit Select
            Case "0"
                If gameStart = True Then
                    Label10.Text = "当前比赛进行中，无法重置！"
                Else
                    For i = 0 To 2
                        For j = 0 To 2
                            Matrix(i, j) = 0 '重置为0
                        Next
                    Next
                    steps = 0
                    Label1.ForeColor = Color.FromArgb(0, 0, 0)
                    Label1.Text = "11"
                    Label2.ForeColor = Color.FromArgb(0, 0, 0)
                    Label2.Text = "12"
                    Label3.ForeColor = Color.FromArgb(0, 0, 0)
                    Label3.Text = "13"
                    Label4.ForeColor = Color.FromArgb(0, 0, 0)
                    Label4.Text = "21"
                    Label5.ForeColor = Color.FromArgb(0, 0, 0)
                    Label5.Text = "22"
                    Label6.ForeColor = Color.FromArgb(0, 0, 0)
                    Label6.Text = "23"
                    Label7.ForeColor = Color.FromArgb(0, 0, 0)
                    Label7.Text = "31"
                    Label8.ForeColor = Color.FromArgb(0, 0, 0)
                    Label8.Text = "32"
                    Label9.ForeColor = Color.FromArgb(0, 0, 0)
                    Label9.Text = "33"
                    Label10.ForeColor = Color.FromArgb(0, 0, 0)
                End If
        End Select

        If Matrix(0, 0) = 1 And Matrix(0, 1) = 1 And Matrix(0, 2) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If
        If Matrix(1, 0) = 1 And Matrix(1, 1) = 1 And Matrix(1, 2) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If
        If Matrix(2, 0) = 1 And Matrix(2, 1) = 1 And Matrix(2, 2) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If
        If Matrix(0, 0) = 1 And Matrix(1, 0) = 1 And Matrix(2, 0) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If
        If Matrix(0, 1) = 1 And Matrix(1, 1) = 1 And Matrix(2, 1) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If
        If Matrix(0, 2) = 1 And Matrix(1, 2) = 1 And Matrix(2, 2) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If
        If Matrix(0, 0) = 1 And Matrix(1, 1) = 1 And Matrix(2, 2) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If
        If Matrix(0, 2) = 1 And Matrix(1, 1) = 1 And Matrix(2, 0) = 1 Then
            Label10.Text = "红方获胜"
            Label10.ForeColor = Color.FromArgb(255, 0, 0)
            gameStart = False
        End If

        If Matrix(0, 0) = 2 And Matrix(0, 1) = 2 And Matrix(0, 2) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If Matrix(1, 0) = 2 And Matrix(1, 1) = 2 And Matrix(1, 2) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If Matrix(2, 0) = 2 And Matrix(2, 1) = 2 And Matrix(2, 2) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If Matrix(0, 0) = 2 And Matrix(1, 0) = 2 And Matrix(2, 0) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If Matrix(0, 1) = 2 And Matrix(1, 1) = 2 And Matrix(2, 1) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If Matrix(0, 2) = 2 And Matrix(1, 2) = 2 And Matrix(2, 2) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If Matrix(0, 0) = 2 And Matrix(1, 1) = 2 And Matrix(2, 2) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If Matrix(0, 2) = 2 And Matrix(1, 1) = 2 And Matrix(2, 0) = 2 Then
            Label10.Text = "蓝方获胜"
            Label10.ForeColor = Color.FromArgb(0, 0, 255)
            gameStart = False
        End If
        If steps = 9 Then
            Label10.Text = "平局"
            gameStart = False
        End If
        Return 0
    End Function
End Class
