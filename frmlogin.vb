Public Class frmlogin

    Private Sub btndangnhap_Click(sender As Object, e As EventArgs) Handles btndangnhap.Click
        Dim Id As String
        Dim Pw As String

        Id = txtid.Text()
        Pw = txtpass.Text()

        If Id = "admin" Then
            If Pw = "admin" Then
                MessageBox.Show("Đăng Nhập Thành Công")
                DangnhapID = Id
                MatKhauPW = Pw
                frmmain.ShowDialog()
            Else
                MessageBox.Show("Sai Mật Khẩu")
            End If
        Else
            MessageBox.Show("Sai Tên Đăng Nhập")
        End If
    End Sub
End Class
