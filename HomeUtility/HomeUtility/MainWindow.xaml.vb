'Utility Calculation application
'Auther: Morgan Stock
'Course: POS/408 
'Instructer: Tim Hagan
'Version: 1.2
'This application takes data from the user regarding power usage and calculates the cost based
'on price of kW per hour, kW used by an applince, and number of hours it was used.
'It will also calculate any water needed for the applice adding to the total
'the total is displayed in a label after all required data has been entered
Class MainWindow
    Private usesWater As Boolean = False
    Dim file As New FileManager
    Dim app As ArrayList
    Dim count As Integer

    Private Sub btnExit_Click(sender As Object, e As RoutedEventArgs) Handles btnExit.Click
        'Close application
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        'Clear all data
        txtCostPerKW.Clear()
        cbbAppliance.SelectedIndex = 0
        txtPowerNeed.Clear()
        cbbHoursUsed.SelectedIndex = 0
        Calculation.clearData()
        lblTotal.Content = ""
        txtCostGallon.Clear()
        txtGallon.Clear()
    End Sub

    Private Sub cbbAppliance_Loaded(sender As Object, e As RoutedEventArgs) Handles cbbAppliance.Loaded
        'adds the appliance options to the combo box
       
        cbbAppliance.Items.Add("")
        cbbAppliance.Items.Add("Refrigerator")
        cbbAppliance.Items.Add("TV")
        cbbAppliance.Items.Add("Space Heater")
        cbbAppliance.Items.Add("Fan")
        cbbAppliance.Items.Add("Dryer")
        cbbAppliance.Items.Add("Oven")
        cbbAppliance.Items.Add("Computer")
        cbbAppliance.Items.Add("Dish Washer")
        cbbAppliance.Items.Add("Washer")
    End Sub

    Private Sub cbbHoursUsed_Loaded(sender As Object, e As RoutedEventArgs) Handles cbbHoursUsed.Loaded
        'adds the hours used options to the combo box
        For hours As Integer = 0 To 24
            cbbHoursUsed.Items.Add(hours)
        Next
    End Sub

    Private Sub txtCostPerKW_LostFocus(sender As Object, e As RoutedEventArgs) Handles txtCostPerKW.LostFocus
        'checks for proper data entry a number and sets the value
        If IsNumeric(txtCostPerKW.Text) Then
            Dim cost As Double = CDbl(txtCostPerKW.Text)
            If cost >= 0.001 And cost <= 100.0 Then
                Calculation.unitCost = cost
            Else
                txtCostPerKW.Clear()
                MessageBox.Show("Invaled entry. Please enter an amount betwee .001 and 100.00")
            End If
        Else
            txtCostPerKW.Clear()
            MessageBox.Show("Invaled entry. Please enter a number.")
        End If
        resultDisplay()
    End Sub

    Private Sub txtPowerNeed_LostFocus(sender As Object, e As RoutedEventArgs) Handles txtPowerNeed.LostFocus
        'checks for proper data entry a number and sets the value
        If IsNumeric(txtPowerNeed.Text) Then
            Dim power As Double = CDbl(txtPowerNeed.Text)
            'checks for valued amount of power
            If power >= 1 And power <= 10000 Then
                Calculation.unitPower = power
            Else
                txtPowerNeed.Clear()
                MessageBox.Show("Invaled range. Please enter a number between 1 and 10,000")
            End If
        Else
            txtPowerNeed.Clear()
            MessageBox.Show("Invaled entry. Please enter a number.")
        End If
        resultDisplay()
    End Sub

    Private Sub cbbHoursUsed_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbbHoursUsed.SelectionChanged
        'selecting an hour from list and record value
        Calculation.unitHours = cbbHoursUsed.SelectedValue
        resultDisplay()
    End Sub

    Private Sub resultDisplay()
        'checks for all required information then displays results in a label
        Dim entryComplete As Boolean = False
        Dim waterEntryComplete As Boolean = False
        'checks for completed entry
        If Not Calculation.unitCost <= 0 And Not Calculation.unitHours <= 0 And Not Calculation.unitPower <= 0 And Not cbbAppliance.SelectedIndex <= 0 Then
            entryComplete = True
        Else
            entryComplete = False
        End If
        'checks for completed water usage if needed
        If usesWater = True Then
            If Not Calculation.unitWater <= 0 And Not Calculation.unitCostWater <= 0 Then
                waterEntryComplete = True
            Else
                waterEntryComplete = False
            End If
        End If
        'calculates the total depending on item selected with or without water usage
        If usesWater = False Then
            If entryComplete = True And waterEntryComplete = False Then
                lblTotal.Content = FormatCurrency(Calculation.totalResult)
                Dim data As String = ""
                data = cbbAppliance.SelectedItem.ToString() & "   " & Calculation.unitHours.ToString() & "   " & Format(Calculation.totalResult, "c")
                lstTotal.Items.Add(data)
            End If
        ElseIf waterEntryComplete = True And entryComplete = True Then
            lblTotal.Content = FormatCurrency(Calculation.totalWater)
            Dim data As String = ""
            data = cbbAppliance.SelectedItem.ToString() & "   " & Calculation.unitHours.ToString() & "   " & Format(Calculation.totalWater, "c")
            lstTotal.Items.Add(data)
        End If
    End Sub

    Private Sub cbbAppliance_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cbbAppliance.SelectionChanged
        'checks for water using appliance then desplays approprate text boxs for data entry
        If cbbAppliance.SelectedItem.ToString() = "Washer" Or cbbAppliance.SelectedItem.ToString() = "Dish Washer" Then
            Me.Height = 470
            waterGrid.Visibility = Windows.Visibility.Visible
            usesWater = True
        Else
            Me.Height = 420
            waterGrid.Visibility = Windows.Visibility.Hidden
            usesWater = False
        End If
    End Sub

    Private Sub txtGallon_LostFocus(sender As Object, e As RoutedEventArgs) Handles txtGallon.LostFocus
        'checks for proper data entry a number and sets the value
        If IsNumeric(txtGallon.Text) Then
            Dim water As Double = CDbl(txtGallon.Text)
            If water >= 0.5 And water <= 100 Then
                Calculation.unitWater = water
            Else
                txtGallon.Clear()
                MessageBox.Show("Invaled entry. Please enter an amount between .50 and 100")
            End If
        Else
            txtGallon.Clear()
            MessageBox.Show("Invaled entry. Please enter a number.")
        End If
        resultDisplay()
    End Sub

    Private Sub txtCostGallon_LostFocus(sender As Object, e As RoutedEventArgs) Handles txtCostGallon.LostFocus
        'checks for proper data entry a number and sets the value
        If IsNumeric(txtCostGallon.Text) Then
            Dim cost As Double = CDbl(txtCostGallon.Text)
            If cost >= 0.001 And cost <= 100.0 Then
                Calculation.unitCostWater = cost
            Else
                txtCostGallon.Clear()
                MessageBox.Show("Invaled entry. Please enter an amount betwee .001 and 100.00")
            End If
        Else
            txtCostGallon.Clear()
            MessageBox.Show("Invaled entry. Please enter a number.")
        End If
        resultDisplay()
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        file = New FileManager()

        count = file.numberOfEntrys
        For a As Integer = 0 To count
            app(a) = New Appliance()
            file.readXML(app(a), a)
        Next
    End Sub
End Class



