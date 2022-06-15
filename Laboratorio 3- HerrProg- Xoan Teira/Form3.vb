Imports System.Data.SqlClient
Public Class Form3
    Dim con As New SqlConnection("Data Source=LAPTOP-JTB4JJF4;Initial Catalog=Laboratorio3;Integrated Security=True")

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()

        Dim dataV As New DataView
        Dim dataS As New DataSet
        Dim consulta As String

        consulta = "SELECT * FROM Books"

        Try
            Dim command As New SqlDataAdapter(consulta, con)
            command.Fill(dataS)
            dataV.Table = dataS.Tables(0)
            DataGridView1.DataSource = dataV

        Catch ex As Exception
            MsgBox("¡ERROR!", vbOKOnly, "ERROR")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dataV As New DataView
        Dim dataS As New DataSet



        Dim consulta As String
        Dim idLibro As String = TextBox1.Text
        Dim control As Integer = 0

        If idLibro = "" Then
            MsgBox("Por favor ingrese un dato valido en los campo", vbOKOnly, "ERROR")
        ElseIf idLibro = 0 Then
            MsgBox("Por favor ingrese un valor de ID valido", vbOKOnly, "ERROR")
        Else

            Try
                consulta = "DELETE FROM Books Where Id= '" & idLibro & "'"
                Dim command2 As New SqlCommand(consulta, con)
                control = command2.ExecuteNonQuery()
                If control > 0 Then
                    MsgBox("Eliminacion de datos exitosa", vbOKOnly, "Eliminación de datos")
                    TextBox1.Clear()
                    consulta = "SELECT * FROM Books"
                    Dim command As New SqlDataAdapter(consulta, con)
                    command.Fill(dataS)
                    dataV.Table = dataS.Tables(0)
                    DataGridView1.DataSource = dataV
                End If

            Catch ex As Exception
                MsgBox("¡ERROR!", vbOKOnly, "ERROR")
            End Try
            con.Close()
        End If

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

    Private Sub InsertarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarDatosToolStripMenuItem.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub VerYBorrarAutorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerYBorrarAutorToolStripMenuItem.Click
        Me.Hide()
        Form4.Show()

    End Sub

    Private Sub ActualizarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarDatosToolStripMenuItem.Click
        Me.Hide()
        Form5.Show()

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