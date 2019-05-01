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

        <Route("api/Mahasiswa/GetAllAmbil")>
        Public Function GetAllAmbil() As IEnumerable(Of Pengambilan)
            Return mhsDb.GetAllAmbil()
        End Function

        ' POST: api/Mahasiswa
        Public Function PostValue(mhs As Mahasiswa) As IHttpActionResult
            Try
                mhsDb.Insert(mhs)
                Return Ok("Data berhasil ditambah")
            Catch ex As Exception
                Return BadRequest($"Error: {ex.Message}")
            End Try
        End Function

        ' PUT: api/Mahasiswa/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Mahasiswa/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace