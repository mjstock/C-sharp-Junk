Imports System.IO
Imports System.Xml

Public Class FileManager
    Dim strFileName As String
    Dim writer As StreamWriter
    Dim reader As StreamReader
    Dim isOpenToRead As Boolean
    Dim isOpenToWrite As Boolean
    Dim xmlDoc As New XmlDocument()
    Dim _numberOfEntrys As Integer

    Sub FileManager()
        _numberOfEntrys = CInt(xmlDoc.LastChild("Appliance_ID").InnerText)
    End Sub

    'file.Exists(filename) checks for file avalability
    'file.endOfStream checks for end of file will result in a true
    'file.ReadToEnd() reads everything in file

    Public Sub readXML(ByRef Appliance As Object, ByVal id As Integer)
        Dim app As Appliance = DirectCast(Activator.CreateInstance(Appliance), Object)
        xmlDoc.Load("XMLAppliance.xml") ' file name
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/Table/Appliance")
        For Each nobe As XmlNode In nodes

            app.unitType = nobe.SelectSingleNode("Appliace_Name").InnerText
            app.powerNeed = nobe.SelectSingleNode("Appliance_PowerNeed").InnerText
            app.waterNeed = nobe.SelectSingleNode("Appliance_WaterNeed").InnerText
            app.powerCost = nobe.SelectSingleNode("Appliance_PowerCost").InnerText
            app.powerUsed = nobe.SelectSingleNode("Appliace_PowerUsed").InnerText
            app.hoursUsed = nobe.SelectSingleNode("Appliance_HoursUsed").InnerText
            app.powerResult = nobe.SelectSingleNode("Appliance_PowerResult").InnerText
            app.waterUsed = nobe.SelectSingleNode("Appliance_WaterUsed").InnerText
            app.waterCost = nobe.SelectSingleNode("Appliance_WaterCost").InnerText
            app.waterResult = nobe.SelectSingleNode("Appliance_WaterResult").InnerText
        Next

    End Sub
    Property numberOfEntrys As Integer
        Get
            Return _numberOfEntrys
        End Get
        Private Set(value As Integer)
            _numberOfEntrys = value
        End Set
    End Property



End Class
