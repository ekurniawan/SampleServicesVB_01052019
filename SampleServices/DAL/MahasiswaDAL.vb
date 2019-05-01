Imports System.Data.SqlClient
Imports System.Configuration

Public Class MahasiswaDAL
    Public Function GetConnString() As String
        Return ConfigurationManager.ConnectionStrings("MyConnection").ConnectionString
    End Function

    Public Function GetAll() As IEnumerable(Of Mahasiswa)
        Using conn As New SqlConnection(GetConnString())
            Dim lstMhs As New List(Of Mahasiswa)
            Dim strSql = "select * from mahasiswa order by Nama"
            Dim cmd As New SqlCommand(strSql, conn)
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
        End Using
    End Function
End Class
