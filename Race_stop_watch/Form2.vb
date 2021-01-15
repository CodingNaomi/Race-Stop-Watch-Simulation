

Public Class Form1

    'Declaration of variables
    Dim arraySize As Integer = 0
    Dim rnd As New Random
    Dim items As New ArrayList
    Dim flagItems As New ArrayList
    Dim counter As Integer = 0
    Dim athList As New ArrayList
    Dim flagList As New ArrayList
    Dim lstCountryFin As New ArrayList
    Dim txtBoxArray(10) As TextBox
    Dim picBoxArray(10) As PictureBox
    Dim lstCountryArray(10) As ComboBox
    Dim lblHrArray(10) As Label
    Dim lblMinArray(10) As Label
    Dim lblSecArray(10) As Label
    Dim txtRankNamesArray(10) As TextBox
    Dim lblPlaceArray(10) As Label
    Dim lblColon1Array(10) As Label
    Dim lblColon2Array(10) As Label


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblSelectAth.Visible = True

    End Sub


    'SELECT radio button as an event
    Private Sub SelectNoOfAthletes(sender As Object, e As EventArgs) Handles rdoNoOfAthBtn1.Click, rdoNoOfAthBtn2.Click, rdoNoOfAthBtn3.Click, rdoNoOfAthBtn4.Click, rdoNoOfAthBtn5.Click, rdoNoOfAthBtn6.Click, rdoNoOfAthBtn7.Click, rdoNoOfAthBtn8.Click, rdoNoOfAthBtn9.Click, rdoNoOfAthBtn10.Click

        'Defining array size based on number radio button checked
        If rdoNoOfAthBtn1.Checked = True Then
            arraySize = 1
        ElseIf rdoNoOfAthBtn2.Checked = True Then
            arraySize = 2
        ElseIf rdoNoOfAthBtn3.Checked = True Then
            arraySize = 3
        ElseIf rdoNoOfAthBtn4.Checked = True Then
            arraySize = 4
        ElseIf rdoNoOfAthBtn5.Checked = True Then
            arraySize = 5
        ElseIf rdoNoOfAthBtn6.Checked = True Then
            arraySize = 6
        ElseIf rdoNoOfAthBtn7.Checked = True Then
            arraySize = 7
        ElseIf rdoNoOfAthBtn8.Checked = True Then
            arraySize = 8
        ElseIf rdoNoOfAthBtn9.Checked = True Then
            arraySize = 9
        ElseIf rdoNoOfAthBtn10.Checked = True Then
            arraySize = 10
        End If

        'Initializing arrays for textbox with athletes names and country
        txtBoxArray = {txtBoxAthName1, txtBoxAthName2, txtBoxAthName3, txtBoxAthName4, txtBoxAthName5, txtBoxAthName6, txtBoxAthName7, txtBoxAthName8, txtBoxAthName9, txtBoxAthName10}
        lstCountryArray = {cboBoxCtyAth1, cboBoxCtyAth2, cboBoxCtyAth3, cboBoxCtyAth4, cboBoxCtyAth5, cboBoxCtyAth6, cboBoxCtyAth7, cboBoxCtyAth8, cboBoxCtyAth9, cboBoxCtyAth10}


        'Activate visibility of textboxes to enter athletes names upon radio button selection
        lblAthheading.Visible = True
        lblCountyheading.Visible = True

        For i = arraySize To txtBoxArray.Count
            txtBoxArray(i - 1).Visible = False
            lstCountryArray(i - 1).Visible = False
        Next

        For j = 1 To arraySize
            txtBoxArray(j - 1).Visible = True
            lstCountryArray(j - 1).Visible = True
        Next

    End Sub

    'MARK GET SET button as an event
    Private Sub btnMark_Click(sender As Object, e As EventArgs) Handles btnMark.Click

        'add athlete's names and country to arraylists
        For i = 0 To arraySize - 1
            athList.Add(txtBoxArray(i).Text)
            flagList.Add(lstCountryArray(i).Text)
        Next

        'add athlete's and country to an arraylist for the randomizer
        For i = 0 To athList.Count - 1
            items.Add(athList(i))
        Next

        For i = 0 To flagList.Count - 1
            flagItems.Add(flagList(i))
        Next

        'move to next screen
        tabControl1.SelectedIndex = 1


    End Sub



    'CODE FOR RANKING PAGE AND STANDINGS
    'START/STOP button click event
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        'Initialization of arrays for displaying standings shown on next pagetab
        lblHrArray = {lbl1stHr, lbl2ndHr, lbl3rdHr, lbl4thHr, lbl5thHr, lbl6thHr, lbl7thHr, lbl8thHr, lbl9thHr, lbl10thHr}
        lblMinArray = {lbl1stMin, lbl2ndMin, lbl3rdMin, lbl4thMin, lbl5thMin, lbl6thMin, lbl7thMin, lbl8thMin, lbl9thMin, lbl10thMin}
        lblSecArray = {lbl1stSec, lbl2ndSec, lbl3rdSec, lbl4thSec, lbl5thSec, lbl6thSec, lbl7thSec, lbl8thSec, lbl9thSec, lbl10thSec}
        txtRankNamesArray = {txt1stName, txt2ndName, txt3rdName, txt4thName, txt5thName, txt6thName, txt7thName, txt8thName, txt9thName, txt10thName}
        picBoxArray = {picBox1stPlace, picBox2ndPlace, picBox2ndPlace, picBox3rdPlace, picBox4thPlace, picBox5thPlace, picBox6thPlace, picBox7thPlace, picBox8thPlace, picBox9thPlace, picBox10thPlace}
        lblPlaceArray = {lbl1stPlace, lbl2ndPlace, lbl3rdPlace, lbl4thPlace, lbl5thPlace, lbl6thPlace, lbl7thPlace, lbl8thPlace, lbl9thPlace, lbl10thPlace}
        lblColon1Array = {lbl1stCol, lbl2ndCol, lbl3rdCol, lbl4thCol, lbl5thCol, lbl6thCol, lbl7thCol, lbl8thCol, lbl9thCol, lbl10thCol}
        lblColon2Array = {lbl1stColon, lbl2ndColon, lbl3rdColon, lbl4thColon, lbl5thColon, lbl6thColon, lbl7thColon, lbl8thColon, lbl9thColon, lbl10thColon}

        'Code to make standings visible on standings page
        For i = arraySize To 9
            lblPlaceArray(i).Visible = False
            lblHrArray(i).Visible = False
            lblMinArray(i).Visible = False
            lblSecArray(i).Visible = False
            txtRankNamesArray(i).Visible = False
            picBoxArray(i).Visible = False
            lblColon1Array(i).Visible = False
            lblColon2Array(i).Visible = False
        Next

        'Disable changes to athletes once race starts
        For i = 0 To arraySize - 1
            txtBoxArray(i).Enabled = False
            lstCountryArray(i).Enabled = False
        Next


        'Turn on and off the stop watch as atheletes cross the finish line
        If btnStop.Text <> "FINISHED" Then
            counter += 1

            'name change on start button after each race crosses the finish line
            btnStop.Text = "Stop" & " " & counter

            If timer1.Enabled = False Then
                timer1.Enabled = True
                timer1.Start()
            End If


            If counter > 1 Then 'And counter <= arraySize Then

                lblHrArray(counter - 2).Text = lblHours.Text
                lblMinArray(counter - 2).Text = lblMinutes.Text
                lblSecArray(counter - 2).Text = lblSeconds.Text


                'randomizer to randomly determine the winners
                Dim numitems As Integer = items.Count
                Dim index As Integer = rnd.Next(0, (numitems - 1))
                lstBoxFinish.Items.Add(items(index))
                lstCountryFin.Add(flagItems(index))
                items.RemoveAt(index)
                flagItems.RemoveAt(index)

                'add winners names and country flags to standings page
                txtRankNamesArray(counter - 2).Text = lstBoxFinish.Items(counter - 2)
                picBoxArray(counter - 2).Image = imageList.Images(lstCountryFin(counter - 2))

                'if statement to ensure race ends when last athlete finishes
                If counter = arraySize + 1 Then
                    timer1.Enabled = False
                    btnStop.Text = "FINISHED"
                    btnAwards.Visible = True

                End If
            End If
        End If
        'End If
    End Sub


    'RESET the clock
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        lstBoxFinish.Items.Clear()
        timer1.Enabled = False
        btnStop.Text = "START"
        counter = 0


        'Upon reset, clear the athletes list and enable changes to athletes
        For i = 0 To arraySize - 1
            txtBoxArray(i).Enabled = True
            lstCountryArray(i).Enabled = True
            txtBoxArray(i).Text = " "
            lstCountryArray(i).Text = " "
            flagList.Clear()
            picBoxArray(i).Dispose()
            txtRankNamesArray(i).Text = " "
            lblHrArray(i).Text = "00"
            lblMinArray(i).Text = "00"
            lblSecArray(i).Text = "00"

        Next

        'reset clock labels
        lblHours.Text = "00"
        lblMinutes.Text = "00"
        lblSeconds.Text = "00"

    End Sub

    'BUTTON to move to the next tab
    Private Sub btnAwards_Click(sender As Object, e As EventArgs) Handles btnAwards.Click
        tabControl1.SelectedIndex = 2

    End Sub



    'CLOCK timer operation
    Private Sub timer1_Tick_1(sender As Object, e As EventArgs) Handles timer1.Tick
        lblSeconds.Text = lblSeconds.Text + 1
        If lblSeconds.Text = 60 Then
            lblMinutes.Text = lblMinutes.Text + 1
            lblSeconds.Text = "00"
        End If
        If lblMinutes.Text = 60 Then
            lblHours.Text = lblHours.Text + 1
            lblMinutes.Text = "00"
        End If

    End Sub


End Class