Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports Dapper

Public Class MahasiswaDAL
    Public Function GetConnString() As String
        Return ConfigurationManager.ConnectionStrings("MyConnection").ConnectionString
    End Function

    Public Function GetAllDapper() As IEnumerable(Of Mahasiswa)
        Using conn As New MySqlConnection(GetConnString())
            Dim strSql = "select * from mahasiswa order by Nama"
            Dim results = conn.Query(Of Mahasiswa)(strSql)
            Return results
        End Using
    End Function

    Public Function GetAllAmbil() As IEnumerable(Of Pengambilan)
        Using conn As New MySqlConnection(GetConnString())
            Dim strSql = "select m.Nim,m.Nama,m.IPK,a.AmbilId,a.Matakuliah,a.Sks from mahasiswa m inner join ambil a on m.Nim=a.Nim"
            Dim results = conn.Query(Of Pengambilan)(strSql)
            Return results
        End Using
    End Function

    Public Function GetById(nim As String) As Mahasiswa
        Using conn As New MySqlConnection(GetConnString())
            Dim strSql = "select * from mahasiswa where Nim=@Nim"
            'memasukan parameter nim
            Dim param As New With {.Nim = nim}
            Dim result = conn.QuerySingle(Of Mahasiswa)(strSql, param)
            Return result
        End Using
    End Function

    Public Function GetByNama(nama As String) As IEnumerable(Of Mahasiswa)
        Using conn As New MySqlConnection(GetConnString())
            Dim strSql = "select * from mahasiswa where Nama like @Nama"
            Dim param As New With {.Nama = "%" & nama & "%"}
            Dim results = conn.Query(Of Mahasiswa)(strSql, param)
            Return results
        End Using
    End Function

    Public Function GetAll() As IEnumerable(Of Mahasiswa)
        Using conn As New MySqlConnection(GetConnString())
            Dim lstMhs As New List(Of Mahasiswa)
            Dim strSql = "select * from mahasiswa order by Nama"
            Dim cmd As New MySqlCommand(strSql, conn)
            conn.Open()
            Dim dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    lstMhs.Add(New Mahasiswa With {
                               .Nim = dr("Nim"),
                               .Nama = dr("Nama"),
                               .IPK = CDbl(dr("IPK"))})
                End While
            End If
            dr.Close()
            cmd.Dispose()
            conn.Close()

            Return lstMhs
        End Using
    End Function

    Public Sub Insert(mhs As Mahasiswa)
        Using conn As New MySqlConnection(GetConnString())
            Dim strSql = "insert into Mahasiswa(Nim,Nama,IPK) values(@Nim,@Nama,@IPK)"
            Try
                Dim param = New With {
                .Nim = mhs.Nim, .Nama = mhs.Nama, .IPK = mhs.IPK}
                conn.Execute(strSql, param)
            Catch sqlEx As MySqlException
                Throw New Exception($"Error: {sqlEx.Message}")
            End Try
        End Using
    End Sub

    Public Sub Update(mhs As Mahasiswa)
        Using conn As New MySqlConnection(GetConnString())
            Dim strSql = "update mahasiswa set Nama=@Nama,IPK=@IPK where Nim=@Nim"
            Try
                Dim param = New With {.Nama = mhs.Nama, .IPK = mhs.IPK, .Nim = mhs.Nim}
                conn.Execute(strSql, param)
            Catch ex As MySqlException
                Throw New Exception($"Error: {ex.Message}")
            End Try
        End Using
    End Sub

    Public Sub Delete(nim As String)
        Using conn As New MySqlConnection(GetConnString())
            Dim strSql = "delete from mahasiswa where Nim=@Nim"
            Try
                Dim param = New With {.Nim = nim}
                conn.Execute(strSql, param)
            Catch ex As MySqlException
                Throw New Exception($"Error: {ex.Message}")
            End Try
        End Using
    End Sub
End Class
