Imports proveedor
Partial Class Bancos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'If Session("Usuario") = Nothing Then
        '    Response.Redirect("Login.aspx")
        '    Return
        'End If

        If Session("ADGroup") = Nothing Then
            Response.Redirect("Inicio.aspx")
            Return
        End If

        If Not IsPostBack Then

        End If
    End Sub


    Protected Sub ibtnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnAgregar.Click
        Dim cadena As String
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        Dim nro_confirmacion As Integer
        nro_confirmacion = tabla.crearBanco(1, 0, UCase(txtBanco.Text), UCase(txtSwift.Text), chbLocal.Checked)
        grdvBanco.DataBind()
    End Sub
End Class
