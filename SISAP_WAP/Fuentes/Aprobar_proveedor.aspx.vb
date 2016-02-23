Imports System.Data
Imports proveedor
Imports System.Configuration
Imports System.Web.Mail
Partial Class Aprobar_proveedor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'SISAP Change Start
        If Session("ADGroup") = Nothing Then
            Response.Redirect("Inicio.aspx")
            Return
        End If
        'SISAP Change End

        If Not IsPostBack Then
            aprobar_solicitud()

        End If

    End Sub
    Private Sub aprobar_solicitud()
        Dim ds As Data.DataSet
        Dim row
        Dim fila As Data.DataRow
        Dim cadena As String
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        ds = New Data.DataSet
        'ds = tabla.Existe(Mid(UCase(User.Identity.Name.ToString), 6))  'Verificando que el usuario este autorizado

        'SISAP Code Start
        ds = tabla.Existe(Session("ADGroup"))  'Verificando que el usuario este autorizado  
        'SISAP Code End

        For Each row In ds.Tables("tabla").Rows
            fila = CType(ds.Tables("tabla").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos

            Session("COD_PERFIL") = fila("COD_PERFIL")

            If Session("COD_PERFIL") = 4 Then
                lblTipoaprob.Text = 1
            Else
                If Session("COD_PERFIL") = 5 Then
                    lblTipoaprob.Text = 2
                End If
            End If
        Next
    End Sub


End Class
