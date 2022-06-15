Imports System.Data.SqlClient
Public Class Form2
    Dim con As New SqlConnection("Data Source=LAPTOP-JTB4JJF4;Initial Catalog=Laboratorio3;Integrated Security=True")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim control, control2 As Integer

        Dim titLibro As String = TextBox1.Text
        Dim nomAutor As String = TextBox2.Text
        Dim paisAutor As String = TextBox3.Text
        Dim consultaLibro As String
        Dim consultaAutor As String

        control = control2 = 0
        If titLibro = "" Or nomAutor = "" Or paisAutor = "" Then
            MsgBox("Por favor ingrese un dato valido en los campo", vbOKOnly, "ERROR")
        Else
            consultaLibro = "Insert into Books (Title) Values ('" & titLibro & "')"
            consultaAutor = "Insert into Authors(Name,Country) Values('" & nomAutor & "', '" & paisAutor & "')"
            Try
                Dim command As New SqlCommand(consultaLibro, con)
                Dim command2 As New SqlCommand(consultaAutor, con)
                control = command.ExecuteNonQuery()
                control2 = command2.ExecuteNonQuery()
                If control > 0 And control2 > 0 Then
                    MsgBox("Ingreso de nuevos datos exitosa", vbOKOnly, "Ingreso de datos")
                    con.Close()
                End If
            Catch ex As Exception
                MsgBox("Error en el ingreso de datos", vbOKOnly, "ERROR")
            End Try
            con.Close()
        End If

    End Sub
    'EVENTOS DE LOS TEXTBOX'

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
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
    End Sub

    Private Sub VolverAInicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverAInicioToolStripMenuItem.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub BorrarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarDatosToolStripMenuItem.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub BuscarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarDatosToolStripMenuItem.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub ActualizarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarDatosToolStripMenuItem.Click
        Me.Hide()
        Form5.Show()

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        If MsgBox("¿Desea salir de la aplicación?", vbQuestion + vbYesNoCancel, "Pregunta") = vbYes Then
            End
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
End Class