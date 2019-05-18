Public Class Form1
    Dim usuarios(0 To 20) As String
    Dim senhas(0 To 20) As String
    Dim perm(0 To 20) As String
    Dim logado As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Items.Clear()
    End Sub
    Dim eae As Integer
    Private Sub ListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        eae = ListView1.FocusedItem.Index
        TextBox1.Text = usuarios(eae)
        TextBox2.Text = senhas(eae)
        TextBox3.Text = perm(eae)
    End Sub
    Function remover()
        Dim encontrado As Boolean = False
        For x As Integer = 0 To 20
            If encontrado = True Then
                If x + 1 > 20 Then
                    Exit For
                Else
                    usuarios(x - 1) = usuarios(x)
                    perm(x - 1) = perm(x)
                    senhas(x - 1) = senhas(x)
                End If

            Else
                If usuarios(x) = "" And usuarios(x + 1) IsNot "" Then
                    encontrado = True
                End If
            End If
        Next
    End Function
    Function carregar()
        ListView1.Items.Clear()
        Dim total As Integer
        For x As Integer = 0 To 20
            If usuarios(x) = "" Then
                total = x - 1
                Exit For
            End If
        Next
        For x As Integer = 0 To total
            ListView1.Items.Add(x)
            ListView1.Items(x).SubItems.Add(perm(x))
            ListView1.Items(x).SubItems.Add(usuarios(x))
            ListView1.Items(x).SubItems.Add(senhas(x))
        Next
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim total As Integer = usuarios.Length + 1
        For x As Integer = 0 To 20
            If usuarios(x) = "" Then
                total = x
                Exit For
            End If
        Next
        'MsgBox(total)
        usuarios(total) = TextBox1.Text
        senhas(total) = TextBox2.Text
        perm(total) = TextBox3.Text
        carregar()
        'ListView1.Items(ListView1.Items.Count).SubItems.Add()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        usuarios(eae) = TextBox1.Text
        senhas(eae) = TextBox2.Text
        perm(eae) = TextBox3.Text
        carregar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        usuarios(eae) = ""
        senhas(eae) = ""
        perm(eae) = ""
        remover()
        carregar()

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox4.Text = "" Then
            MsgBox("o campo usuario nao pode ficar em branco")
            Exit Sub
        End If
        If TextBox5.Text = "" Then
            MsgBox("o campo senha nao pode ficar em branco")
            Exit Sub
        End If
        For x As Integer = 0 To 20

            If TextBox4.Text = usuarios(x) And TextBox5.Text = senhas(x) Then
                Label8.Text = "Você esta Logado"
                Button4.Enabled = False
                Button5.Enabled = True
                Label6.Visible = True
                Label7.Visible = True
                Label7.Text = perm(x)
                Label8.Visible = True
                ResponsiveSleep(3500)
                Label8.Visible = False
                Exit Sub
            End If
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button4.Enabled = True
        Button5.Enabled = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = True
        Label8.Text = "Você esta Deslogado"
        ResponsiveSleep(3500)
        Label8.Visible = False
    End Sub
    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 20
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(20) : Application.DoEvents()
        Next i
    End Sub

End Class
