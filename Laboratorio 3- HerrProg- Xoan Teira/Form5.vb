Imports System.Data.SqlClient
Public Class Form5
    Dim con As New SqlConnection("Data Source=LAPTOP-JTB4JJF4;Initial Catalog=Laboratorio3;Integrated Security=True")
    Dim opcion As Integer

    Private Function BuscarLibros(num As String) As DataRow
        Dim consulta As String


        If (String.IsNullOrEmpty(num)) Then
            Throw New ArgumentNullException("id")
        End If
        Dim returnValue As DataRow = Nothing


        Dim ds As New DataSet

        consulta = "SELECT * FROM Books WHERE Id = '" & num & "'"

        Dim da As New SqlDataAdapter(consulta, con)
        da.Fill(ds)

        Using dt As New DataTable()
            da.Fill(dt)
            If (dt.Rows.Count > 0) Then
                returnValue = dt.Rows(0)
            End If
        End Using

        Return returnValue

    End Function
    Private Function BuscarAutor(num As String) As DataRow
        Dim consulta As String


        If (String.IsNullOrEmpty(num)) Then
            Throw New ArgumentNullException("id")
        End If
        Dim returnValue As DataRow = Nothing


        Dim ds As New DataSet

        consulta = "SELECT * FROM Authors WHERE Id = '" & num & "'"

        Dim da As New SqlDataAdapter(consulta, con)
        da.Fill(ds)

        Using dt As New DataTable()
            da.Fill(dt)
            If (dt.Rows.Count > 0) Then
                returnValue = dt.Rows(0)
            End If
        End Using

        Return returnValue

    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        opcion = 1
        Panel1.Show()
        Panel2.Hide()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        opcion = 2
        Panel2.Show()
        Panel1.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Id As String = TextBox1.Text
        Dim nomLibro As String = TextBox2.Text
        Dim nomAutor As String = TextBox3.Text
        Dim paisAutor As String = TextBox4.Text
        Dim consulta As String
        Dim control As Integer = 0

        If opcion = 1 Then
            If Id = "" Or nomLibro = "" Then
                MsgBox("Por favor ingrese un dato valido en los campo", vbOKOnly, "ERROR")
            ElseIf Id = 0 Then
                MsgBox("Por favor ingrese un valor de ID valido", vbOKOnly, "ERROR")
            Else

                Try
                    consulta = "UPDATE Books SET Title= '" & nomLibro & "' WHERE Id= '" & Id & "'"
                    BuscarLibros(Id)
                    Dim comando As New SqlCommand(consulta, con)
                    control = comando.ExecuteNonQuery
                    If control > 0 Then
                        MsgBox("Actualizacion de datos exitosa", vbOKOnly, "Actualizacion de datos")
                    End If
                Catch ex As Exception
                    MsgBox("¡ERROR!", vbOKOnly, "ERROR")
                End Try

            End If
        Else
            If Id = "" Or nomAutor = "" Or paisAutor = "" Then
                MsgBox("Por favor ingrese un dato valido en los campo", vbOKOnly, "ERROR")
            ElseIf Id = 0 Then
                MsgBox("Por favor ingrese un valor de ID valido", vbOKOnly, "ERROR")
            Else

                Try
                    consulta = "UPDATE Authors SET Name= '" & nomAutor & "',Country= '" & paisAutor & "' WHERE Id= '" & Id & "'"
                    BuscarAutor(Id)
                    Dim comando As New SqlCommand(consulta, con)
                    control = comando.ExecuteNonQuery
                    If control > 0 Then
                        MsgBox("Actualizacion de datos exitosa", vbOKOnly, "Actualizacion de datos")
                    End If
                Catch ex As Exception
                    MsgBox("¡ERROR!", vbOKOnly, "ERROR")
                End Try
            End If
        End If

    End Sub

    Private Sub VerYBorrarLibrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerYBorrarLibrosToolStripMenuItem.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            MessageBox.Show("Solo se admiten numeros enteros", "Advertencia", MessageBoxButtons.OK)
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK)
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK)
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

    End Sub

    Private Sub InsertarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarDatosToolStripMenuItem.Click
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub VerYBorrarAutoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerYBorrarAutoresToolStripMenuItem.Click
        Me.Hide()
        Form3.Show()

    End Sub

    Private Sub VolverAInicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverAInicioToolStripMenuItem.Click
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        If MsgBox("¿Desea salir de la aplicación?", vbQuestion + vbYesNoCancel, "Pregunta") = vbYes Then
            End
        End If
    End Sub
End Class