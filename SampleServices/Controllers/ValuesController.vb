Imports System.Net
Imports System.Web.Http

Public Class ValuesController
    Inherits ApiController

    Public nama As New List(Of String)
    Public Sub New()
        nama.Add("Erick")
        nama.Add("Budi")
        nama.Add("Bambang")
    End Sub

    ' GET api/values
    Public Function GetValues() As IEnumerable(Of String)
        Return nama
    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As String) As String
        Return "value"
    End Function

    'untuk insert
    ' POST api/values
    Public Sub PostValue(<FromBody()> ByVal value As String)
        Return
    End Sub

    'untuk update
    ' PUT api/values/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    'untuk delete
    ' DELETE api/values/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
