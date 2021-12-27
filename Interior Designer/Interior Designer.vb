Public Class Form1
    'Variable'
    Dim convertedC As Double
    Dim userName, PN, Symbol As String
    Dim roomWidth, roomLength, roomHeight, cConvert As Double
    Dim SideSA, EndSA, RoofSA, WallsSA, Cost, SurfaceArea, roomPaint, UnderCoat As Double '[Side Walls Area, End Walls Area, Roof Area, Walls Surface Area, Cost, Surface Area, roomPaint, UnderCoat]
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub BTNStart_Click(sender As Object, e As EventArgs) Handles BTNStart.Click
        'Declaring Variables'
        userName = TXTForename.Text & " " & TXTSurname.Text
        PN = TXTPhoneNumber.Text
        roomLength = TXTRoomLength.Text
        roomWidth = TXTRoomWidth.Text
        roomHeight = TXTRoomHeight.Text
        Symbol = ""



        SideSA = (roomHeight * roomWidth) * 2
        EndSA = (roomHeight * roomLength) * 2
        RoofSA = roomWidth * roomLength
        WallsSA = SideSA + EndSA
        SurfaceArea = ((roomHeight * roomWidth) * 2) + ((roomHeight * roomLength) * 2) + (roomWidth * roomLength)
        Cost = (roomPaint + UnderCoat) * SurfaceArea

        If RBTNLuxuryQuality.Checked Then
            roomPaint = 1.75
        ElseIf RBTNStandardQuality.Checked Then
            roomPaint = 1.1
        ElseIf RBTNEconomyQuality.Checked Then
            roomPaint = 0.45
        Else
            roomPaint = 0.45
        End If

        If CBUndercoat.Checked Then
            UnderCoat = 0.3
        Else
            UnderCoat = 0
        End If

        If RBTNGbp.Checked Then
            Symbol = "£"
            Cost = (roomPaint + UnderCoat) * SurfaceArea
            roomPaint = roomPaint
        ElseIf RBTNYen.Checked Then
            Cost = Cost * 142.31
            roomPaint = roomPaint * 142.31
            Symbol = "¥"
        ElseIf RBTNEuros.Checked Then
            Cost = Cost * 1.15
            roomPaint = roomPaint * 1.15
            Symbol = "€"
        ElseIf RBTNDollars.Checked Then
            Cost = Cost * 1.29
            roomPaint = roomPaint * 1.29
            Symbol = "$"
        Else
            Symbol = "£"
            Cost = (roomPaint + UnderCoat) * SurfaceArea
            roomPaint = roomPaint
        End If
        'Output'
        MessageBox.Show("Name " & userName & vbNewLine & "Phone Number " & PN & vbNewLine & "Surface Area " & SurfaceArea & vbNewLine & "Total Cost " & Symbol & Cost & vbNewLine & "Paint Cost: " & Symbol & roomPaint)

    End Sub

    Private Sub BTNCon_Click(sender As Object, e As EventArgs) Handles BTNCon.Click
        If String.IsNullOrEmpty(TXTCurvC.Text) Or String.IsNullOrWhiteSpace(TXTCurvC.Text) Then cConvert = Cost Else cConvert = TXTCurvC.Text

        If RBTNGbp.Checked Then
            convertedC = convertedC
            convertedLab.Text = "Converted: £" & convertedC
        ElseIf RBTNYen.Checked Then
            convertedC = convertedC * 0.00708
            convertedLab.Text = "Converted: £" & convertedC
        ElseIf RBTNEuros.Checked Then
            If String.IsNullOrWhiteSpace(Symbol) Then convertedC = convertedC * 1.15
            convertedLab.Text = "Converted: £" & convertedC
        ElseIf RBTNDollars.Checked Then
            convertedC = convertedC * 1.29
            convertedLab.Text = "Converted: £" & convertedC
        Else
            convertedC = convertedC
            convertedLab.Text = "Converted: £" & convertedC
        End If
    End Sub


End Class
