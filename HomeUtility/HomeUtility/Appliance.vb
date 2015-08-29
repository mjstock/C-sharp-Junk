Public Class Appliance
    'appliance class for seting and getting 
    Private _unitType As String
    Private _powerNeed As Double
    Private _needWater As Boolean
    Private _waterNeed As Double
    Private _powerCost As Double
    Private _powerUsed As Double
    Private _hoursUsed As Double
    Private _powerResult As Double
    Private _waterUsed As Double
    Private _waterCost As Double
    Private _waterResult As Double


    Property waterResult As Double
        Get
            Return _waterResult
        End Get
        Set(value As Double)
            _waterResult = value
        End Set
    End Property

    Property waterCost As Double
        Get
            Return _waterCost
        End Get
        Set(value As Double)
            _waterCost = value
        End Set
    End Property

    Property waterUsed As Double
        Get
            Return _waterUsed
        End Get
        Set(value As Double)
            _waterUsed = value
        End Set
    End Property

    Property powerResult As Double
        Get
            Return _powerResult
        End Get
        Set(value As Double)
            _powerResult = value
        End Set
    End Property

    Property hoursUsed As Double
        Get
            Return _hoursUsed
        End Get
        Set(value As Double)
            _hoursUsed = value
        End Set
    End Property

    Property powerUsed As Double
        Get
            Return _powerUsed
        End Get
        Set(value As Double)
            _powerUsed = value
        End Set
    End Property

    Property powerCost As Double
        Get
            Return _powerCost
        End Get
        Set(value As Double)
            _powerCost = value
        End Set
    End Property

    Property unitType As String
        Get
            Return _unitType
        End Get
        Set(value As String)
            _unitType = value
        End Set
    End Property

    Property powerNeed As Double
        Get
            Return _powerNeed
        End Get
        Set(value As Double)
            _powerNeed = value
        End Set
    End Property

    Property needWater As Boolean
        Get
            Return _needWater
        End Get
        Set(value As Boolean)
            _needWater = value
        End Set
    End Property

    Property waterNeed As Double
        Get
            Return _waterNeed
        End Get
        Set(value As Double)
            _waterNeed = value
        End Set
    End Property

End Class
