Module Calculation
    'Calculation module that stores and calculates data for the Utility application
    'Property Procedures were not required to run this application and added unneeded complexity
    'I added them for practice and experimentation rather than simplisity
    Private cost As Double = 0
    Private power As Double = 0
    Private hours As Integer = 0
    Private result As Double = 0
    Private water As Double = 0
    Private costWater As Double = 0
    Private waterResult As Double = 0

    Property unitCostWater() As Double
        'allows for setting the cost of water and returning it to main form
        Get
            Return costWater
        End Get
        Set(value As Double)
            costWater = value
        End Set
    End Property
    Property unitWater() As Double
        'allows for seting the water usage and returing the water to main form
        Get
            Return water
        End Get
        Set(value As Double)
            water = value
        End Set
    End Property
    Property unitCost() As Double
        'alows for seting the cost and returning the cost to main form
        Get
            Return cost
        End Get
        Set(value As Double)
            cost = value
        End Set
    End Property

    Property unitPower() As Double
        'alows for seting the power and returning the power to main form
        Get
            Return power
        End Get
        Set(value As Double)
            power = value
        End Set
    End Property

    Property unitHours() As Integer
        'alows for seting the hours and returning the hours to main form
        Get
            Return hours
        End Get
        Set(value As Integer)
            hours = value
        End Set
    End Property

    Public Function totalResult() As Double
        'calculates the results of the utility usage and returns the total for use
        result = (cost * power) * hours
        Return result
    End Function

    Public Function totalWater() As Double
        'calcultates the results of water usage and returns the total
        waterResult = (water * costWater) + ((cost * power) * hours)
        Return waterResult
    End Function

    Public Sub clearData()
        'clears all data in module
        cost = 0
        power = 0
        hours = 0
        result = 0
        water = 0
        costWater = 0
    End Sub
End Module
