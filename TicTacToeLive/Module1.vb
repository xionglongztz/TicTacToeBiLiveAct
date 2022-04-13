Module Module1
    Public Function PostData(ByVal url As String, ByVal data As String) As String '消息推送函数
        System.Net.ServicePointManager.Expect100Continue = False
        Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)
        'Post请求方式
        request.Method = "POST"
        '内容类型
        request.ContentType = "application/json"
        '将URL编码后的字符串转化为字节
        Dim encoding As New System.Text.UTF8Encoding()
        Dim bys As Byte() = encoding.GetBytes(data)
        '设置请求的 ContentLength 
        request.ContentLength = bys.Length
        '获得请求流
        Dim newStream As System.IO.Stream = request.GetRequestStream()
        newStream.Write(bys, 0, bys.Length)
        newStream.Close()
        '获得响应流
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(request.GetResponse().GetResponseStream)
        'Return sr.ReadToEnd
        Return "执行状态：" & Split(sr.ReadToEnd, """",)(5)
    End Function
    Public Function GetData(ByVal url As String, ByVal data As String) As String '发送GET请求
        Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url) '+ "?" + data
        request.Method = "GET"
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(request.GetResponse().GetResponseStream)
        Return sr.ReadToEnd
    End Function
End Module
