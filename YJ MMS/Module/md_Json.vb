Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Module md_Json
    Public Function Load_PHP(ByVal uri As String,
                             ByVal rootName As String,
                             ByVal childName As String) As String

        Try
            Dim wresp As WebResponse
            Dim wreq As WebRequest = HttpWebRequest.Create(uri)
            Dim str As String = String.Empty
            wresp = wreq.GetResponse()

            Using sr As New StreamReader(wresp.GetResponseStream())
                str = sr.ReadToEnd()
                sr.Close()
            End Using

            Dim jsonstring As String = str
            Dim json_results As New System.Net.Json.JsonTextParser
            Dim j_result As System.Net.Json.JsonObjectCollection
            Dim ser As JObject = JObject.Parse(jsonstring)

            j_result = json_results.Parse(jsonstring)
            Dim data As List(Of JToken) = ser.Children().ToList
            Dim output As String = String.Empty

            For Each item As JProperty In data
                item.CreateReader()
                'Select Case item.Name
                '    Case "makingCode"
                '        For Each comment As JObject In item.Values
                '            Dim news_subject As String = comment("CHECK_CODE")
                '            MsgBox(news_subject)
                '        Next
                'End Select
                If item.Name = rootName Then
                    For Each comment As JObject In item.Values
                        If output = String.Empty Then
                            output = comment(childName)
                        Else
                            output += "!~!" & CStr(comment(childName))
                        End If
                    Next
                End If
            Next
            Return "Success!/!" & output
        Catch ex As Exception
            Return "Fail!/!" & ex.Message
        End Try

    End Function
End Module
