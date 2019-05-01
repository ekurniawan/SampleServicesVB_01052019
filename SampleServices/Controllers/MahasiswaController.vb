Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class MahasiswaController
        Inherits ApiController

        Private mhsDb As New MahasiswaDAL

        ' GET: api/Mahasiswa
        Public Function GetValues() As IEnumerable(Of Mahasiswa)
            Return mhsDb.GetAllDapper()
        End Function

        ' GET: http://localhost:53712/api/Mahasiswa/72098787
        Public Function GetValue(ByVal id As String) As Mahasiswa
            Return mhsDb.GetById(id)
        End Function

        <Route("api/Mahasiswa/GetByNama/{id}")>
        Public Function GetByNama(id As String)
            Return mhsDb.GetByNama(id)
        End Function

        ' POST: api/Mahasiswa
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Mahasiswa/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Mahasiswa/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace