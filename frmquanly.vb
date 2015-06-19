Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class frmquanly
    Dim database As New DataTable ' Tạo đối tượng database để lưu trữ dữ liệu từ Database Online
    'Tạo chuỗi kết nối để kết nối tới Database Online
    Dim chuoiconnect As String = "workstation id=binhnvps02531a.mssql.somee.com;packet size=4096;user id=binh123;pwd=Admin@123;data source=binhnvps02531a.mssql.somee.com;persist security info=False;initial catalog=binhnvps02531a"

    Private Property txtmakhext As Object

    Private Sub btnthem_Click(sender As Object, e As EventArgs) Handles btnthem.Click
        ' Tạo đối tượng kết nối
        Dim connect As SqlConnection = New SqlConnection(chuoiconnect)
        'Tạo query câu truy vấn Insert into
        Dim Query2 As String = "insert into Khachhang values (@MaKH,@TenKH,@Email,@SDT,@DiaChi)"
        'Tạo đối tượng để thực thi câu truy vấn với DB ONline
        Dim ExecuteQuery1 As New SqlCommand(Query2, connect)
        'Kết nối mở ra
        connect.Open()

        Try
            'Truyền giá trị trong các ô textbox cho các biến tương ứng
            ExecuteQuery1.Parameters.AddWithValue("@MaKH", txtmakh.Text)
            ExecuteQuery1.Parameters.AddWithValue("@TenKH", txttenkh.Text)
            ExecuteQuery1.Parameters.AddWithValue("@Email", txtemail.Text)
            ExecuteQuery1.Parameters.AddWithValue("@SDT", txtsdt.Text)
            ExecuteQuery1.Parameters.AddWithValue("@DiaChi", txtdiachi.Text)

            'Exucute là ghi dữ liệu vào Database
            MessageBox.Show("Thêm thành công")
            ExecuteQuery1.ExecuteNonQuery()
        Catch ex As Exception
            'Nếu thêm không được thì hiển thị thông báo
            MessageBox.Show("Không thêm được!")

        End Try
        'Refresh bang
        Dim Query3 As SqlDataAdapter = New SqlDataAdapter("select * from Khachhang", connect)
        database.Clear()

        Query3.Fill(database)
        dtgkhachhang.DataSource = database.DefaultView

    End Sub
    Private Sub dtgKhachhang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgkhachhang.CellContentClick
        Dim index As Integer = dtgKhachhang.CurrentCell.RowIndex
        txtmakh.Text = dtgkhachhang.Item(0, index).Value
        txttenkh.Text = dtgkhachhang.Item(1, index).Value
        txtemail.Text = dtgkhachhang.Item(2, index).Value
        txtsdt.Text = dtgkhachhang.Item(3, index).Value
        txtdiachi.Text = dtgkhachhang.Item(4, index).Value
    End Sub
    Private Sub Loaddata()
        Dim connect As SqlConnection = New SqlConnection(chuoiconnect)
        Dim Query1 As SqlDataAdapter = New SqlDataAdapter("select * from Khachhang", connect)

        connect.Open()
        Query1.Fill(database)
        dtgkhachhang.DataSource = database.DefaultView
    End Sub

    Private Sub btnsua_Click(sender As Object, e As EventArgs) Handles btnsua.Click
        Dim Ketnoi1 As New SqlConnection(chuoiconnect)
        Ketnoi1.Open()
        Dim Stradd1 As String = "Update Khachhang set tenkh=@Tenkh,email=@Email,sdt=@SDT,diachi=@Diachi where makh=@Makh"
        Dim com As New SqlCommand(Stradd1, Ketnoi1)
        Try
            com.Parameters.AddWithValue("@MaKH", txtmakh.Text)
            com.Parameters.AddWithValue("@TenKH", txttenkh.Text)
            com.Parameters.AddWithValue("@Email", txtemail.Text)
            com.Parameters.AddWithValue("@SDT", txtsdt.Text)
            com.Parameters.AddWithValue("@DiaChi", txtdiachi.Text)
            com.ExecuteNonQuery()
            Ketnoi1.Close()
            MessageBox.Show("Sửa thành công")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công")
        End Try
        database.Clear()
        dtgkhachhang.DataSource = database
        dtgkhachhang.DataSource = Nothing
        Loaddata()
    End Sub

    Private Sub btnxoa_Click(sender As Object, e As EventArgs) Handles btnxoa.Click
        Dim ketnoi As New SqlConnection(chuoiconnect)
        ketnoi.Open()
        Dim xoadl As String = "Delete from Khachhang where makh=@makh"
        Dim lenh As New SqlCommand(xoadl, ketnoi)
        Try
            lenh.Parameters.AddWithValue("@MaKH", txtmakh.Text)
            lenh.ExecuteNonQuery()
            ketnoi.Close()
        Catch ex As Exception
            MessageBox.Show("Xoá không thành công")
        End Try
        database.Clear()
        dtgkhachhang.DataSource = database
        dtgkhachhang.DataSource = Nothing
        Loaddata()
    End Sub

    Private Sub btnxem_Click(sender As Object, e As EventArgs) Handles btnxem.Click

    End Sub
End Class