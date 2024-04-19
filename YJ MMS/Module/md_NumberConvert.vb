Module md_CharConvert
    Public Function CharConvert(ByVal Number As String) As String

        CharConvert = ""

        Select Case Number
            Case "0"
                CharConvert += "0"
            Case "1"
                CharConvert += "1"
            Case "2"
                CharConvert += "2"
            Case "3"
                CharConvert += "3"
            Case "4"
                CharConvert += "4"
            Case "5"
                CharConvert += "5"
            Case "6"
                CharConvert += "6"
            Case "7"
                CharConvert += "7"
            Case "8"
                CharConvert += "8"
            Case "9"
                CharConvert += "9"
            Case "A"
                CharConvert += "10"
            Case "B"
                CharConvert += "11"
            Case "C"
                CharConvert += "12"
            Case "D"
                CharConvert += "13"
            Case "E"
                CharConvert += "14"
            Case "F"
                CharConvert += "15"
            Case "G"
                CharConvert += "16"
            Case "H"
                CharConvert += "17"
            Case "J"
                CharConvert += "18"
            Case "K"
                CharConvert += "19"
            Case "L"
                CharConvert += "20"
            Case "M"
                CharConvert += "21"
            Case "N"
                CharConvert += "22"
            Case "P"
                CharConvert += "23"
            Case "R"
                CharConvert += "24"
            Case "S"
                CharConvert += "25"
            Case "T"
                CharConvert += "26"
            Case "U"
                CharConvert += "27"
            Case "V"
                CharConvert += "28"
            Case "W"
                CharConvert += "29"
            Case "X"
                CharConvert += "30"
            Case "Z"
                CharConvert += "31"

        End Select

        Return CharConvert

    End Function

    Public Function NumberConvert(ByVal Number As Integer) As String

        NumberConvert = ""

        Select Case Number
            Case 0
                NumberConvert += "0"
            Case 1
                NumberConvert += "1"
            Case 2
                NumberConvert += "2"
            Case 3
                NumberConvert += "3"
            Case 4
                NumberConvert += "4"
            Case 5
                NumberConvert += "5"
            Case 6
                NumberConvert += "6"
            Case 7
                NumberConvert += "7"
            Case 8
                NumberConvert += "8"
            Case 9
                NumberConvert += "9"
            Case 10
                NumberConvert += "A"
            Case 11
                NumberConvert += "B"
            Case 12
                NumberConvert += "C"
            Case 13
                NumberConvert += "D"
            Case 14
                NumberConvert += "E"
            Case 15
                NumberConvert += "F"
            Case 16
                NumberConvert += "G"
            Case 17
                NumberConvert += "H"
            Case 18
                NumberConvert += "J"
            Case 19
                NumberConvert += "K"
            Case 20
                NumberConvert += "L"
            Case 21
                NumberConvert += "M"
            Case 22
                NumberConvert += "N"
            Case 23
                NumberConvert += "P"
            Case 24
                NumberConvert += "R"
            Case 25
                NumberConvert += "S"
            Case 26
                NumberConvert += "T"
            Case 27
                NumberConvert += "U"
            Case 28
                NumberConvert += "V"
            Case 29
                NumberConvert += "W"
            Case 30
                NumberConvert += "X"
            Case 31
                NumberConvert += "Z"

        End Select

        Return NumberConvert

    End Function
End Module
