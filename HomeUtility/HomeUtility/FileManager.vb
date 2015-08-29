Imports System.IO
Imports System.Xml

Public Class FileManager
    Dim strFileName As String
    Dim writer As StreamWriter
    Dim reader As StreamReader
    Dim isOpenToRead As Boolean
    Dim isOpenToWrite As Boolean
    Dim xmlDoc As XmlDocument
    Dim xmlNode As XmlNodeList
    Dim _numberOfEntrys As Integer

    Sub New()
        'inizulize sub
        xmlDoc.Load("..\XMLAppliance.sml")
        _numberOfEntrys = CInt(xmlDoc.LastChild("Appliance_ID").InnerText)

    End Sub

    'file.Exists(filename) checks for file avalability
    'file.endOfStream checks for end of file will result in a true
    'file.ReadToEnd() reads everything in file

    Public Sub readXML(ByRef app As Appliance, ByVal id As Integer)
        Dim nod As XmlNode = xmlDoc.SelectSingleNode("/Table/Appliance[@ID='id'")
        If nod IsNot Nothing Then
            app.unitType = nod.ChildNodes(1).InnerText.ToString
        End If


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


    End Sub

    Public Sub writeXML(ByRef app As Appliance)
        If IO.File.Exists("XMLAppliance.sml") = False Then
            Dim settings As New XmlWriterSettings()
            settings.Indent = True
            Dim xmlWrt As XmlWriter = XmlWriter.Create("XMLAppliance.xml", settings)
            With xmlWrt
                .WriteStartDocument()
                .WriteComment("XML DataBase.")
                .WriteStartElement("Table")
                .WriteStartElement("Appliance")
                .WriteStartElement("Appliance_ID")
                .WriteEndElement()
                .WriteStartElement("Appliance_Name")
                .WriteEndElement()
                .WriteStartElement("Appliance_PowerNeed")
                .WriteEndElement()
                .WriteStartElement("Appliance_NeedWater")
                .WriteEndElement()
                'add rest of elements
                .WriteEndElement()
                .WriteEndDocument()
                .Close()
            End With
        Else
            'write to file when already exists
        End If

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
