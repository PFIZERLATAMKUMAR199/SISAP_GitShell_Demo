Imports proveedor
Partial Class Usuarios
    Inherits System.Web.UI.Page

    Dim cadena As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Usuario") = Nothing Then
            Response.Redirect("Login.aspx")
            Return
        End If

        If Not IsPostBack Then

        End If
    End Sub

   


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim ddl As DropDownList = DirectCast(sender, DropDownList)
        Dim row As GridViewRow = CType(sender, Control).NamingContainer

        ddl = grdvUsuarios.Rows(row.RowIndex).FindControl("DropDownList1")
        txtCodPerfil.Text = ddl.SelectedValue




    End Sub

    Protected Sub IbtnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnAgregar.Click
     
        Dim tabla As New Procesar_proveedor(cadena)
        Dim nro_confirmacion As Integer
        nro_confirmacion = tabla.crearUsuarios(1, UCase(txtCod_usuario.Text), txtNombre.Text, ddlCod_perfil.SelectedValue, txtCorreo.Text)

        grdvUsuarios.DataBind()
        txtCod_usuario.Text = ""
        txtNombre.Text = ""
        txtCorreo.Text = ""
    End Sub

    'Protected Sub EditarGrid(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles grdvUsuarios.RowEditing

    '    Dim ddlPerfil As DropDownList
    '    Dim index As Int32 = e.NewEditIndex
    '    Dim tb_perfil As Data.DataTable
    '    Dim tabla As New Procesar_proveedor(cadena)

    '    grdvUsuarios.EditIndex = index
    '    ddlPerfil = CType(grdvUsuarios.Rows(index).Cells(2).FindControl("DropDownList1"), DropDownList)

    '    If ddlPerfil.SelectedValue = 0 Then

    '        tb_perfil = tabla.TraerTabla("SELECT COD_PERFIL FROM USUARIOS WHERE COD_USUARIO='" & grdvUsuarios.Rows(index).Cells(0).Text & "'")
    '        ddlPerfil.SelectedValue = tb_perfil.Rows(0)("COD_PERFIL").ToString

    '    End If

    'End Sub

    'Protected Sub ComandGrid(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)



    'End Sub
End Class
