Imports System.Data
Imports proveedor
Imports System.Configuration
Imports System.Web.Mail
Imports System.IO





Partial Class Index
    Inherits System.Web.UI.Page

    Dim Servidor As String = System.Configuration.ConfigurationManager.AppSettings("servidor")
    Dim jsID As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cod_proceso As String
        'Session("estatus") = Nothing

        'If Session("Usuario") = Nothing Then
        '    Response.Redirect("Login.aspx")
        '    Return
        'End If

        If Session("ADGroup") = Nothing Then
            Response.Redirect("Inicio.aspx")
            Return
        End If

        If Not IsPostBack Then

            'SISAP Change Start
            If (ddlAprob1.SelectedValue = String.Empty) Then
                Dim tabla1 As New DataTable
                Dim ad1 As New WebApplication2.ADAuthorizationUtil()
                tabla1 = ad1.GetMembersFromADGroup(WebApplication2.ADAuthorizationUtil.SISAPPAprobadorL)
                ddlAprob1.DataSource = tabla1
                ddlAprob1.DataBind()
            End If

            If (ddlAprob2.SelectedValue = String.Empty) Then
                Dim tabla2 As New DataTable
                Dim ad2 As New WebApplication2.ADAuthorizationUtil()
                tabla2 = ad2.GetMembersFromADGroup(WebApplication2.ADAuthorizationUtil.SISAPSAprobadorL)
                ddlAprob2.DataSource = tabla2
                ddlAprob2.DataBind()
            End If
            'SISAP Change End

            'btnAprobar.Attributes.Add("onclick", "this.value='Aprobando...';this.disabled = true;" & Me.GetPostBackEventReference(Me.btnAprobar))
            'btnAprobar2.Attributes.Add("onclick", "this.value='Aprobando...';this.disabled = true;" & Me.GetPostBackEventReference(Me.btnAprobar2))
            'btnEnviar.Attributes.Add("onclick", "this.value='Enviando...';this.disabled = true;" & Me.ClientScript.GetPostBackEventReference(Me.btnEnviar, String.Empty))
            btnRechazar.Attributes.Add("onclick", "if(document.getElementById('ctl00_ContentPlaceHolder1_txtMotivo').value == ''){alert('Por favor indique el motivo del rechazo.'); return false;}   return confirm('¿Está seguro que desea rechazar la solicitud?')") '== false){return false;}this.value='Rechazando...';this.disabled = true;" & Me.GetPostBackEventReference(Me.btnRechazar))

            cod_proceso = Request.QueryString("cod_proceso")
            If cod_proceso Is Nothing Then
                cargar_solicitud(0)
                lblCod_proceso.Visible = False
            Else
                cargar_solicitud(cod_proceso)
                lblCod_proceso.Visible = True
            End If
        End If

    End Sub

    Protected Sub ddlMoneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMoneda.SelectedIndexChanged
        If ddlMoneda.SelectedValue = "Y" Then
            ddlCodmoneda.Enabled = True
            'reqvRif.ValidationGroup = ""
            'reqvRif2.ValidationGroup = ""
            reqvTipo_cuenta.ValidationGroup = ""
            reqvTipo_cuenta.Visible = False
            meeRif.MaskType = AjaxControlToolkit.MaskedEditType.None
            'reqvRif.Visible = False
            'reqvRif2.Visible = False
            rfvMoneda.ValidationGroup = "Enviar"
            rfvMoneda.Visible = True
            txtDireccion.MaxLength = 105
            ddlEstado.Enabled = False
            ddlCiudad.Enabled = False


        Else
            ddlCodmoneda.Enabled = False
            ddlCodmoneda.SelectedValue = ""
            rfvMoneda.Visible = False
            reqvRif.ValidationGroup = "Enviar"
            reqvRif2.ValidationGroup = "Enviar"
            reqvTipo_cuenta.ValidationGroup = "Enviar"
            reqvTipo_cuenta.Visible = True
            meeRif.MaskType = AjaxControlToolkit.MaskedEditType.Number
            reqvRif.Visible = True
            reqvRif2.Visible = True
            txtDireccion.MaxLength = 75
            ddlEstado.Enabled = True
            ddlCiudad.Enabled = True

            'ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", "<script language='javascript'>window.open('Recaudos.aspx?Recaudos=2','Recaudos','toolbar=no,status=no,menubar=no,scrollbars=no,resizable=no,Width=653px,Height=70px');</script>")

        End If

        ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", "<script language='javascript'>window.open('Recaudos.aspx?Recaudos=1','Recaudos','toolbar=no,status=no,menubar=no,scrollbars=yes,resizable=no,Width=817px,Height=740px,top=50px');</script>")

    End Sub

    Private Sub cargar_solicitud(ByVal cod_proceso As Integer)

        Dim ds, ds_es As Data.DataSet
        Dim row, row_es
        Dim fila, fila_es As Data.DataRow
        Dim cadena As String
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        Dim tabla_es As New Procesar_proveedor(cadena)
       

        ds = New Data.DataSet
        ds_es = New Data.DataSet
        If cod_proceso <> 0 Then
            ds_es = tabla_es.ValidarEstatus(cod_proceso)  'Verificando el estatus de la solicitud
            For Each row_es In ds_es.Tables("tabla_est").Rows
                fila_es = CType(ds_es.Tables("tabla_est").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
                Session("estatus") = fila_es("COD_ESTATUS")
            Next
        End If


        'ds = tabla.Existe(Mid(UCase(User.Identity.Name.ToString), 6))  'Verificando que el usuario este autorizado
        'SISAP Code Start
        'ds = tabla.Existe(Session("Usuario"))  'Verificando que el usuario este autorizado  
        ds = tabla.Existe(Session("ADGroup"))  'Verificando que el usuario este autorizado  
        Dim Nombre As String = Session("NOMBRE").ToString()
        Dim NTID As String = Session("UserNTID").ToString()
        'SISAP Code end


        For Each row In ds.Tables("tabla").Rows
            fila = CType(ds.Tables("tabla").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos

            Session("perfil") = fila("COD_PERFIL")

            Select Case Session("perfil")
                Case 2
                    If cod_proceso = 0 Then
                        txtSolicitante.Text = Nombre
                        txtCod_Solicitante.Text = NTID
                        txtLookup.Enabled = False
                        ddlTipo_pago.Enabled = False
                        ddlGP.Enabled = False
                        txtDias_pago.Enabled = False
                        ddlMonetario.Enabled = False
                        ddlTaquilla.Enabled = False
                        ddlRetencionISLR.Enabled = False
                        ddlTipopersona.Enabled = False
                    Else
                        Dim ds_prov As Data.DataSet
                        Dim row_prov
                        Dim fila_prov As Data.DataRow
                        Dim cadena_prov As String
                        cadena_prov = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
                        Dim tabla2 As New Procesar_proveedor(cadena_prov)
                        ds_prov = New Data.DataSet
                        ds_prov = tabla2.Mostrar_datos(cod_proceso)
                        For Each row_prov In ds_prov.Tables("tabla2").Rows
                            fila_prov = CType(ds_prov.Tables("tabla2").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
                            txtCod_proceso.Text = fila_prov("COD_PROCESO")
                            If Mid(fila_prov("RIF"), 1, 1) <> "V" And Mid(fila_prov("RIF"), 1, 1) <> "J" And Mid(fila_prov("RIF"), 1, 1) <> "G" And Mid(fila_prov("RIF"), 1, 1) <> "E" And Mid(fila_prov("RIF"), 1, 1) <> "P" And Mid(fila_prov("RIF"), 1, 2) <> "NA" Then
                                ddlRif.SelectedValue = ""
                                txtRif.Text = fila_prov("RIF")
                            Else
                                If Mid(fila_prov("RIF"), 1, 2) = "NA" Then
                                    ddlRif.SelectedValue = Mid(fila_prov("RIF"), 1, 2)
                                    txtRif.Text = Mid(fila_prov("RIF"), 3)
                                Else
                                    ddlRif.SelectedValue = Mid(fila_prov("RIF"), 1, 1)
                                    txtRif.Text = Mid(fila_prov("RIF"), 2)
                                End If


                            End If

                            txtLookup.Text = fila_prov("LOOKUP")
                            txtRazon.Text = fila_prov("RAZON_SOCIAL")
                            ddlMoneda.SelectedValue = fila_prov("CONV_CNTRL")

                            HabilitarRif(fila_prov("CONV_CNTRL"))

                            ddlCodmoneda.SelectedValue = fila_prov("CONV_CODE")
                            txtDireccion.Text = fila_prov("DIRECCION")
                            ddlEstado.SelectedValue = fila_prov("COD_ESTADO")
                            ddlEstado.DataBind()
                            ddlCiudad.SelectedValue = fila_prov("COD_CIUDAD")
                            txtTelefono.Text = fila_prov("TELEFONO")
                            txtFax.Text = fila_prov("FAX")
                            txtContacto.Text = fila_prov("CONTACTO")
                            txtEmail.Text = fila_prov("E_MAIL")
                            txtPagina.Text = fila_prov("WEB_PAGE")
                            ddlAct_ppal.SelectedValue = fila_prov("TIPO_SERVICIO")
                            ddlAct_sec.SelectedValue = fila_prov("TIPO_SERVICIO2")
                            ddlBanco.SelectedValue = fila_prov("COD_BANCO")
                            txtCuenta.Text = fila_prov("CUENTA_BANCO")
                            ddlTipocuenta.SelectedValue = fila_prov("TIPO_CTA_BANCO")
                            ddlTipo_pago.SelectedValue = fila_prov("PRIORITY")
                            ddlGP.SelectedValue = fila_prov("ANAL_A8")
                            txtDias_pago.Text = fila_prov("PAYMENT_DAY")
                            ddlMonetario.SelectedValue = fila_prov("MONETARIO")
                            ddlTaquilla.SelectedValue = fila_prov("TAQUILLA")
                            ddlRetencionISLR.SelectedValue = fila_prov("RET_PEND").ToString().Trim()
                            ddlTipopersona.SelectedValue = fila_prov("NAT_JUR")
                            txtObservaciones.Text = fila_prov("OBSERVACIONES")
                            'ddlAprob1.SelectedValue = 4
                            'ddlAprob2.SelectedValue = 5
                            ddlAprob1.SelectedValue = fila_prov("COD_APROB1")
                            ddlAprob2.SelectedValue = fila_prov("COD_APROB2")

                            'SISAP Change Start
                            Dim ad1 As New WebApplication2.ADAuthorizationUtil()
                            txtSolicitante.Text = ad1.GetNombreByNTID(fila_prov("COD_SOLICITANTE").ToString())
                            'txtSolicitante.Text = fila_prov("NOMBRE")
                            'SISAP Change End

                            txtMotivo.Text = fila_prov("MOTIVO_RECHAZO")
                            ddlPais.SelectedValue = fila_prov("PAIS")
                            ddlOC.SelectedValue = fila_prov("ANAL_C4")
                            ddlOS.SelectedValue = fila_prov("ANAL_C5")
                            txtCodPostal.Text = fila_prov("COD_POSTAL")


                        Next
                        If Session("estatus") = 4 Then
                            ddlRif.Enabled = True
                            reqvRif.Enabled = True
                            txtRif.Enabled = True
                            reqvRif2.Enabled = True
                            txtLookup.Enabled = False
                            txtRazon.Enabled = True
                            reqvrazon.Enabled = True
                            ddlMoneda.Enabled = True
                            reqvMoneda.Enabled = True
                            'ddlCodmoneda.Enabled = True
                            txtDireccion.Enabled = True
                            ddlEstado.Enabled = True
                            ddlCiudad.Enabled = True
                            txtTelefono.Enabled = True
                            reqvTelefono.Enabled = True
                            txtFax.Enabled = True
                            txtContacto.Enabled = True
                            reqvContacto.Enabled = True
                            txtEmail.Enabled = True
                            txtPagina.Enabled = True
                            ddlAct_ppal.Enabled = True
                            reqvAct_ppal.Enabled = True
                            ddlAct_sec.Enabled = True
                            reqvAct_sec.Enabled = True
                            ddlBanco.Enabled = True
                            reqvBanco.Enabled = True
                            txtCuenta.Enabled = True
                            reqvCuenta.Enabled = True
                            ddlTipocuenta.Enabled = True
                            reqvTipo_cuenta.Enabled = True

                            ddlTipo_pago.Enabled = False
                            ddlGP.Enabled = False
                            txtDias_pago.Enabled = False
                            ddlMonetario.Enabled = False
                            ddlTaquilla.Enabled = False
                            ddlRetencionISLR.Enabled = False
                            ddlTipopersona.Enabled = False

                            txtObservaciones.Enabled = True
                            ddlAprob1.Enabled = True
                            ddlAprob2.Enabled = True
                            txtSolicitante.Enabled = False
                            ddlOC.Enabled = True
                            ddlOS.Enabled = True
                            txtCodPostal.Enabled = True

                        Else
                            If Session("estatus") <> 4 Then
                                ddlRif.Enabled = False
                                reqvRif.Enabled = False
                                txtRif.Enabled = False
                                reqvRif2.Enabled = False
                                txtLookup.Enabled = False
                                txtRazon.Enabled = False
                                reqvrazon.Enabled = False
                                ddlMoneda.Enabled = False
                                reqvMoneda.Enabled = False
                                ddlCodmoneda.Enabled = False
                                txtDireccion.Enabled = False
                                ddlEstado.Enabled = False
                                ddlCiudad.Enabled = False
                                txtTelefono.Enabled = False
                                reqvTelefono.Enabled = False
                                txtFax.Enabled = False
                                txtContacto.Enabled = False
                                reqvContacto.Enabled = False
                                txtEmail.Enabled = False
                                txtPagina.Enabled = False
                                ddlAct_ppal.Enabled = False
                                reqvAct_ppal.Enabled = False
                                ddlAct_sec.Enabled = False
                                reqvAct_sec.Enabled = False
                                ddlBanco.Enabled = False
                                reqvBanco.Enabled = False
                                txtCuenta.Enabled = False
                                reqvCuenta.Enabled = False
                                ddlTipocuenta.Enabled = False
                                reqvTipo_cuenta.Enabled = False
                                ddlTipo_pago.Enabled = False
                                ddlGP.Enabled = False
                                txtDias_pago.Enabled = False
                                ddlMonetario.Enabled = False
                                ddlTaquilla.Enabled = False
                                ddlRetencionISLR.Enabled = False
                                ddlTipopersona.Enabled = False
                                txtObservaciones.Enabled = False
                                ddlAprob1.Enabled = False
                                ddlAprob2.Enabled = False
                                txtSolicitante.Enabled = False
                                btnEnviar.Visible = False
                                ddlPais.Enabled = False
                                ddlOC.Enabled = False
                                ddlOS.Enabled = False
                                txtCodPostal.Enabled = False

                            End If
                        End If

                    End If
                Case 4

                    btnAprobar.Visible = True
                    btnRechazar.Visible = True
                    btnEnviar.Visible = False
                    txtMotivo.Enabled = True
                    Dim ds_prov As Data.DataSet
                    Dim row_prov
                    Dim fila_prov As Data.DataRow
                    Dim cadena_prov As String
                    cadena_prov = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
                    Dim tabla2 As New Procesar_proveedor(cadena_prov)
                    ds_prov = New Data.DataSet
                    ds_prov = tabla2.Mostrar_datos(cod_proceso)
                    For Each row_prov In ds_prov.Tables("tabla2").Rows
                        fila_prov = CType(ds_prov.Tables("tabla2").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
                        txtCod_proceso.Text = fila_prov("COD_PROCESO")

                        If Mid(fila_prov("RIF"), 1, 1) <> "V" And Mid(fila_prov("RIF"), 1, 1) <> "J" And Mid(fila_prov("RIF"), 1, 1) <> "G" And Mid(fila_prov("RIF"), 1, 1) <> "E" And Mid(fila_prov("RIF"), 1, 1) <> "P" And Mid(fila_prov("RIF"), 1, 2) <> "NA" Then
                            ddlRif.SelectedValue = ""
                            txtRif.Text = fila_prov("RIF")
                        Else
                            If Mid(fila_prov("RIF"), 1, 2) = "NA" Then
                                ddlRif.SelectedValue = Mid(fila_prov("RIF"), 1, 2)
                                txtRif.Text = Mid(fila_prov("RIF"), 3)
                            Else
                                ddlRif.SelectedValue = Mid(fila_prov("RIF"), 1, 1)
                                txtRif.Text = Mid(fila_prov("RIF"), 2)
                            End If

                        End If

                        txtLookup.Text = fila_prov("LOOKUP")
                        txtRazon.Text = fila_prov("RAZON_SOCIAL")
                        ddlMoneda.SelectedValue = fila_prov("CONV_CNTRL")
                        HabilitarRif(fila_prov("CONV_CNTRL"))
                        ddlCodmoneda.SelectedValue = fila_prov("CONV_CODE")
                        txtDireccion.Text = fila_prov("DIRECCION")
                        ddlEstado.SelectedValue = fila_prov("COD_ESTADO")
                        ddlEstado.DataBind()
                        ddlCiudad.SelectedValue = fila_prov("COD_CIUDAD")
                        txtTelefono.Text = fila_prov("TELEFONO")
                        txtFax.Text = fila_prov("FAX")
                        txtContacto.Text = fila_prov("CONTACTO")
                        txtEmail.Text = fila_prov("E_MAIL")
                        txtPagina.Text = fila_prov("WEB_PAGE")
                        ddlAct_ppal.SelectedValue = fila_prov("TIPO_SERVICIO")
                        ddlAct_sec.SelectedValue = fila_prov("TIPO_SERVICIO2")
                        ddlBanco.SelectedValue = fila_prov("COD_BANCO")
                        txtCuenta.Text = fila_prov("CUENTA_BANCO")
                        ddlTipocuenta.SelectedValue = fila_prov("TIPO_CTA_BANCO")
                        ddlTipo_pago.SelectedValue = fila_prov("PRIORITY")
                        ddlGP.SelectedValue = fila_prov("ANAL_A8")
                        txtDias_pago.Text = fila_prov("PAYMENT_DAY")
                        ddlMonetario.SelectedValue = fila_prov("MONETARIO")
                        ddlTaquilla.SelectedValue = fila_prov("TAQUILLA")
                        ddlRetencionISLR.SelectedValue = fila_prov("RET_PEND").ToString().Trim()
                        ddlTipopersona.SelectedValue = fila_prov("NAT_JUR")
                        txtObservaciones.Text = fila_prov("OBSERVACIONES")
                        'ddlAprob1.SelectedValue = 4
                        'ddlAprob2.SelectedValue = 5
                        ddlAprob1.SelectedValue = fila_prov("COD_APROB1")
                        ddlAprob2.SelectedValue = fila_prov("COD_APROB2")

                        'SISAP Change Start
                        Dim ad3 As New WebApplication2.ADAuthorizationUtil()
                        txtSolicitante.Text = ad3.GetNombreByNTID(fila_prov("COD_SOLICITANTE").ToString())
                        'txtSolicitante.Text = fila_prov("NOMBRE")
                        'SISAP Change End

                        txtMotivo.Text = fila_prov("MOTIVO_RECHAZO")
                        ddlPais.SelectedValue = fila_prov("PAIS")
                        ddlOC.SelectedValue = fila_prov("ANAL_C4")
                        ddlOS.SelectedValue = fila_prov("ANAL_C5")
                        txtCodPostal.Text = fila_prov("COD_POSTAL")

                    Next

                    ddlRif.Enabled = False
                    reqvRif.Enabled = False
                    txtRif.Enabled = False
                    reqvRif2.Enabled = False
                    txtLookup.Enabled = True
                    txtRazon.Enabled = False
                    ddlMoneda.Enabled = False
                    reqvMoneda.Enabled = False
                    ddlCodmoneda.Enabled = False
                    txtDireccion.Enabled = False
                    ddlEstado.Enabled = False
                    ddlCiudad.Enabled = False
                    txtTelefono.Enabled = False
                    reqvTelefono.Enabled = False
                    txtFax.Enabled = False
                    txtContacto.Enabled = False
                    reqvContacto.Enabled = False
                    txtEmail.Enabled = False
                    txtPagina.Enabled = False
                    ddlAct_ppal.Enabled = False
                    reqvAct_ppal.Enabled = False
                    ddlAct_sec.Enabled = False
                    reqvAct_sec.Enabled = False
                    ddlBanco.Enabled = False
                    reqvBanco.Enabled = False
                    txtCuenta.Enabled = False
                    reqvCuenta.Enabled = False
                    ddlTipocuenta.Enabled = False
                    reqvTipo_cuenta.Enabled = False
                    'txtObservaciones.Enabled = False
                    ddlAprob1.Enabled = False
                    ddlAprob2.Enabled = False
                    txtSolicitante.Enabled = False
                    ddlPais.Enabled = False
                    'btnAprobar.Visible = True
                    ddlOC.Enabled = False
                    ddlOS.Enabled = False
                    txtCodPostal.Enabled = False


                    ddlTipo_pago.Enabled = False
                    ddlGP.Enabled = False
                    txtDias_pago.Enabled = False
                    ddlMonetario.Enabled = False
                    ddlTaquilla.Enabled = False
                    ddlRetencionISLR.Enabled = False
                    ddlTipopersona.Enabled = False


                Case 5

                    btnAprobar2.Visible = True
                    btnRechazar.Visible = True
                    btnEnviar.Visible = False
                    txtMotivo.Enabled = True
                    Dim ds_prov As Data.DataSet
                    Dim row_prov
                    Dim fila_prov As Data.DataRow
                    Dim cadena_prov As String
                    cadena_prov = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
                    Dim tabla2 As New Procesar_proveedor(cadena_prov)
                    ds_prov = New Data.DataSet
                    ds_prov = tabla2.Mostrar_datos(cod_proceso)
                    For Each row_prov In ds_prov.Tables("tabla2").Rows
                        fila_prov = CType(ds_prov.Tables("tabla2").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
                        txtCod_proceso.Text = fila_prov("COD_PROCESO")
                        If Mid(fila_prov("RIF"), 1, 1) <> "V" And Mid(fila_prov("RIF"), 1, 1) <> "J" And Mid(fila_prov("RIF"), 1, 1) <> "G" And Mid(fila_prov("RIF"), 1, 1) <> "E" And Mid(fila_prov("RIF"), 1, 1) <> "P" And Mid(fila_prov("RIF"), 1, 2) <> "NA" Then
                            ddlRif.SelectedValue = ""
                            txtRif.Text = fila_prov("RIF")
                        Else
                            If Mid(fila_prov("RIF"), 1, 2) = "NA" Then
                                ddlRif.SelectedValue = Mid(fila_prov("RIF"), 1, 2)
                                txtRif.Text = Mid(fila_prov("RIF"), 3)
                            Else
                                ddlRif.SelectedValue = Mid(fila_prov("RIF"), 1, 1)
                                txtRif.Text = Mid(fila_prov("RIF"), 2)
                            End If

                        End If

                        txtLookup.Text = fila_prov("LOOKUP")
                        txtRazon.Text = fila_prov("RAZON_SOCIAL")
                        ddlMoneda.SelectedValue = fila_prov("CONV_CNTRL")
                        HabilitarRif(fila_prov("CONV_CNTRL"))
                        ddlCodmoneda.SelectedValue = fila_prov("CONV_CODE")
                        txtDireccion.Text = fila_prov("DIRECCION")
                        ddlEstado.SelectedValue = fila_prov("COD_ESTADO")
                        ddlEstado.DataBind()
                        ddlCiudad.SelectedValue = fila_prov("COD_CIUDAD")
                        txtTelefono.Text = fila_prov("TELEFONO")
                        txtFax.Text = fila_prov("FAX")
                        txtContacto.Text = fila_prov("CONTACTO")
                        txtEmail.Text = fila_prov("E_MAIL")
                        txtPagina.Text = fila_prov("WEB_PAGE")
                        ddlAct_ppal.SelectedValue = fila_prov("TIPO_SERVICIO")
                        ddlAct_sec.SelectedValue = fila_prov("TIPO_SERVICIO2")
                        ddlBanco.SelectedValue = fila_prov("COD_BANCO")
                        txtCuenta.Text = fila_prov("CUENTA_BANCO")
                        ddlTipocuenta.SelectedValue = fila_prov("TIPO_CTA_BANCO")
                        ddlTipo_pago.SelectedValue = fila_prov("PRIORITY")
                        ddlGP.SelectedValue = fila_prov("ANAL_A8")
                        txtDias_pago.Text = fila_prov("PAYMENT_DAY")
                        ddlMonetario.SelectedValue = fila_prov("MONETARIO")
                        ddlTaquilla.SelectedValue = fila_prov("TAQUILLA")
                        ddlRetencionISLR.SelectedValue = fila_prov("RET_PEND").ToString().Trim()
                        ddlTipopersona.SelectedValue = fila_prov("NAT_JUR")
                        txtObservaciones.Text = fila_prov("OBSERVACIONES")
                        ddlAprob1.SelectedValue = fila_prov("COD_APROB1")
                        ddlAprob2.SelectedValue = fila_prov("COD_APROB2")

                        'SISAP Change Start
                        Dim ad1 As New WebApplication2.ADAuthorizationUtil()
                        txtSolicitante.Text = ad1.GetNombreByNTID(fila_prov("COD_SOLICITANTE").ToString())
                        'txtSolicitante.Text = fila_prov("NOMBRE")
                        'SISAP Change End

                        txtMotivo.Text = fila_prov("MOTIVO_RECHAZO")
                        ddlPais.SelectedValue = fila_prov("PAIS")
                        ddlOC.SelectedValue = fila_prov("ANAL_C4")
                        ddlOS.SelectedValue = fila_prov("ANAL_C5")
                        txtCodPostal.Text = fila_prov("COD_POSTAL")

                    Next
                    ddlRif.Enabled = False
                    reqvRif.Enabled = False
                    txtRif.Enabled = False
                    reqvRif2.Enabled = False
                    txtLookup.Enabled = False
                    txtRazon.Enabled = False
                    reqvrazon.Enabled = False
                    ddlMoneda.Enabled = False
                    reqvMoneda.Enabled = False
                    ddlCodmoneda.Enabled = False
                    txtDireccion.Enabled = False
                    ddlEstado.Enabled = False
                    ddlCiudad.Enabled = False
                    txtTelefono.Enabled = False
                    reqvTelefono.Enabled = False
                    txtFax.Enabled = False
                    txtContacto.Enabled = False
                    reqvContacto.Enabled = False
                    txtEmail.Enabled = False
                    txtPagina.Enabled = False
                    ddlAct_ppal.Enabled = False
                    reqvAct_ppal.Enabled = False
                    ddlAct_sec.Enabled = False
                    reqvAct_sec.Enabled = False
                    ddlBanco.Enabled = False
                    reqvBanco.Enabled = False
                    txtCuenta.Enabled = False
                    reqvCuenta.Enabled = False
                    ddlTipocuenta.Enabled = False
                    reqvTipo_cuenta.Enabled = False

                    'ddlTipo_pago.Enabled = False
                    'ddlGP.Enabled = False
                    'txtDias_pago.Enabled = False
                    'ddlMonetario.Enabled = False
                    'ddlTaquilla.Enabled = False
                    'ddlRetencionISLR.Enabled = False
                    'ddlTipopersona.Enabled = False

                    ddlTipo_pago.Enabled = True
                    ddlGP.Enabled = True
                    txtDias_pago.Enabled = True
                    ddlMonetario.Enabled = True
                    ddlTaquilla.Enabled = True
                    ddlRetencionISLR.Enabled = True
                    ddlTipopersona.Enabled = True


                    txtObservaciones.Enabled = False
                    ddlAprob1.Enabled = False
                    ddlAprob2.Enabled = False
                    txtSolicitante.Enabled = False
                    ddlPais.Enabled = False
                    ddlOC.Enabled = False
                    ddlOS.Enabled = False
                    txtCodPostal.Enabled = False

            End Select
            'HabilitarRif()  // commented by manish
        Next
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim cadena, mensaje_confirmacion As String
        Dim row_email
        Dim fila_email As Data.DataRow
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        Dim nro_confirmacion As Integer
        Dim ds_email As Data.DataSet
        Dim mensaje As String
        Dim correo As String
        Dim DSExisteRif As DataTable
        ds_email = New Data.DataSet

        Try

            If Session("estatus") <> 4 Then
                DSExisteRif = tabla.TraerTabla("sp_VerificarRif " & ddlRif.SelectedValue.ToString + UCase(txtRif.Text))

                If DSExisteRif.Rows(0)("RESULTADO").ToString = 1 Then
                    jsID = "<script language='javascript'>"
                    jsID += "alert('Ya existe un proveedor con el Rif " & ddlRif.SelectedValue.ToString + UCase(txtRif.Text) & ". Por favor ingrese uno nuevo.');"
                    jsID += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)
                    Exit Sub
                End If

            End If

            'making RIF filed value  of 9 digits part  strats
            If txtRif.Text.Length < 9 Then
                Dim size As Int32
                Dim i As Int32
                size = txtRif.Text.Length
                Dim rif As String
                rif = txtRif.Text
                For i = 1 To (9 - size)
                    rif = "0" & rif
                Next i
                txtRif.Text = rif
            End If
            ' ends

            If Session("perfil") = 2 And txtCod_proceso.Text = "" Then

                nro_confirmacion = tabla.crearSolicitud(1, 0, ddlRif.SelectedValue.ToString + UCase(txtRif.Text), ddlRif.SelectedValue.ToString + UCase(txtRif.Text), UCase(txtRazon.Text), _
                                    ddlMoneda.SelectedValue, ddlCodmoneda.SelectedValue, "", "", "", _
                                    "", "", "", UCase(txtDireccion.Text), txtTelefono.Text, txtFax.Text, UCase(txtContacto.Text), _
                                    txtEmail.Text, txtPagina.Text, ddlAct_ppal.SelectedValue, ddlAct_sec.SelectedValue, txtCuenta.Text, _
                                    ddlTipocuenta.SelectedValue, ddlCiudad.SelectedValue, ddlBanco.SelectedValue, txtObservaciones.Text, _
                                    ddlAprob1.SelectedValue, ddlAprob2.SelectedValue, txtCod_Solicitante.Text, txtMotivo.Text, ddlPais.SelectedItem.Text, "0", ddlOC.SelectedValue.ToString(), ddlOS.SelectedValue.ToString(), txtCodPostal.Text.Trim())

                'SISAP Change Start
                'ds_email = tabla.Leer_email(ddlAprob1.SelectedValue)
                Dim ad1 As New WebApplication2.ADAuthorizationUtil()
                Dim Nombre As String
                correo = ad1.GetEmailByNTID((ddlAprob1.SelectedValue).ToString())
                Nombre = ad1.GetNombreByNTID((ddlAprob1.SelectedValue).ToString())

                'For Each row_email In ds_email.Tables("tabla3").Rows
                '    fila_email = CType(ds_email.Tables("tabla3").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
                '    mensaje = "Estimado(a) " & fila_email("NOMBRE") & "," & Chr(13) & Chr(13) & "Se registró una solicitud de creación del proveedor  " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & ", la cual requiere de su aprobación. " & Chr(13) & Chr(13) & "Por favor haz click en el siguiente link para ingresar a la aplicación y realizar la aprobación http://" & Servidor
                '    correo = fila_email("CORREO")
                'Next
                mensaje = "Estimado(a) " & Nombre & "," & Chr(13) & Chr(13) & "Se registró una solicitud de creación del proveedor  " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & ", la cual requiere de su aprobación. " & Chr(13) & Chr(13) & "Por favor haz click en el siguiente link para ingresar a la aplicación y realizar la aprobación http://" & Servidor
                'SISAP Change End
                mensaje_confirmacion = "Su Solicitud fue registrada exitosamente con el Nro. " & nro_confirmacion.ToString

            End If
            If Session("perfil") = 2 And txtCod_proceso.Text <> "" Then

                nro_confirmacion = tabla.crearSolicitud(2, txtCod_proceso.Text, ddlRif.SelectedValue.ToString + UCase(txtRif.Text), ddlRif.SelectedValue.ToString + UCase(txtRif.Text), UCase(txtRazon.Text), _
                                    ddlMoneda.SelectedValue, ddlCodmoneda.SelectedValue, "", "", "", "", "", "", _
                                    UCase(txtDireccion.Text), txtTelefono.Text, txtFax.Text, UCase(txtContacto.Text), txtEmail.Text, txtPagina.Text, _
                                    ddlAct_ppal.SelectedValue, ddlAct_sec.SelectedValue, txtCuenta.Text, ddlTipocuenta.SelectedValue, ddlCiudad.SelectedValue, _
                                    ddlBanco.SelectedValue, txtObservaciones.Text, ddlAprob1.SelectedValue, ddlAprob2.SelectedValue, _
                                   txtCod_Solicitante.Text, txtMotivo.Text, ddlPais.SelectedItem.Text, "0", ddlOC.SelectedValue.ToString(), ddlOS.SelectedValue.ToString(), txtCodPostal.Text.Trim())

                'SISAP Change Start
                'ds_email = tabla.Leer_email(ddlAprob1.SelectedValue)
                Dim ad2 As New WebApplication2.ADAuthorizationUtil()
                Dim Nombre As String
                correo = ad2.GetEmailByNTID((ddlAprob1.SelectedValue).ToString())
                Nombre = ad2.GetNombreByNTID((ddlAprob1.SelectedValue).ToString())
                
                'For Each row_email In ds_email.Tables("tabla3").Rows
                '    fila_email = CType(ds_email.Tables("tabla3").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
                '    mensaje = "Estimado(a) " & fila_email("NOMBRE") & "," & Chr(13) & Chr(13) & "Se registró una solicitud de creación del proveedor " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & ", la cual requiere de su aprobación. " & Chr(13) & Chr(13) & "Por favor haz click en el siguiente link para ingresar a la aplicación y realizar la aprobación http://" & Servidor
                '    correo = fila_email("CORREO")
                'Next
                mensaje = "Estimado(a) " & Nombre & "," & Chr(13) & Chr(13) & "Se registró una solicitud de creación del proveedor " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & ", la cual requiere de su aprobación. " & Chr(13) & Chr(13) & "Por favor haz click en el siguiente link para ingresar a la aplicación y realizar la aprobación http://" & Servidor
                'SISAP Change End

                mensaje_confirmacion = "La Solicitud fue actualizada exitosamente."

            End If


            If nro_confirmacion >= 0 Then
                enviar_correo(correo, mensaje, 1)

                If (nro_confirmacion = 0) Then
                    Session("Proceso_Reporte") = txtCod_proceso.Text
                Else
                    Session("Proceso_Reporte") = nro_confirmacion.ToString
                End If

                jsID = "<script language='javascript'>"
                jsID += "alert('" & mensaje_confirmacion & "'); window.open('Reporte/ReporteSolicitud.aspx','window','top=0,left=0,menubar=1,scrollbars=1,location=0,resizable=1,status=1,toolbar=0'); location.href='Index.aspx';"
                jsID += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)

                'MsgBox("Su solicitud ha sido registrada exitosamente.", MsgBoxStyle.OkOnly, "Registro Almacenado")
                Limpiar()

                If (nro_confirmacion = 0) Then
                    Session("Proceso_Reporte") = txtCod_proceso.Text
                Else
                    Session("Proceso_Reporte") = nro_confirmacion.ToString
                End If

            End If

        Catch ex As Exception

            jsID = "<script language='javascript'>"
            jsID += "alert('" & ex.Message & "');"
            jsID += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)

        End Try



    End Sub

    Protected Sub enviar_correo(ByVal correo As String, ByVal mensaje As String, ByVal tipo_mensaje As Integer)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New Net.Mail.SmtpClient
        _SMTP.Host = System.Configuration.ConfigurationManager.AppSettings("SMTP").ToString




        ' CONFIGURACION DEL MENSAJE

        _Message.[To].Add(correo) 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress("sisap@pfizer.com", "Sistema de Proveedores", System.Text.Encoding.UTF8) 'Quien lo envía
        If tipo_mensaje = 1 Then
            _Message.Subject = "Aprobación Pendiente" 'Sujeto del e-mail
        Else
            If tipo_mensaje = 2 Then
                _Message.Subject = "Solicitud Aprobada" 'Sujeto del e-mail
            Else
                If tipo_mensaje = 3 Then
                    _Message.Subject = "Solicitud Rechazada" 'Sujeto del e-mail
                End If
            End If
        End If
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
        _Message.Body = mensaje 'contenido del mail
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False

        ' ADICION DE DATOS ADJUNTOS
        'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar
        'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet)
        '_Message.Attachments.Add(_Attachment)

        'ENVIO
        Try
            _SMTP.Send(_Message)
        Catch ex As System.Net.Mail.SmtpException
            'MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Error")
            lblError.Text = ex.Message.ToString()
        End Try

    End Sub

    Protected Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Dim nro_confirmacion As Integer
        Dim cadena As String
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        Dim row_email, row
        Dim fila, fila_email As Data.DataRow
        Dim ds_email, ds As Data.DataSet
        Dim mensaje As String
        Dim correo As String
        Dim tipo_aprob As Integer
        ds_email = New Data.DataSet
        ds = New Data.DataSet

        'SISAP Change Start
        'ds = tabla.Existe(Session("Usuario"))  'Verificando que el usuario este autorizado  
        ds = tabla.Existe(Session("ADGroup"))  'Verificando que el usuario este autorizado  
        'SISAP Change End

        For Each row In ds.Tables("tabla").Rows
            fila = CType(ds.Tables("tabla").Rows(0), Data.DataRow)

            If Session("perfil") = 4 Then
                tipo_aprob = 1
                'AL DESCOMENTARLO SE CAMBIA EL GLUJO DE APROBACIÓN
                'nro_confirmacion = tabla.crearSolicitud(2, txtCod_proceso.Text, ddlRif.SelectedValue.ToString + UCase(txtRif.Text), UCase(txtLookup.Text), UCase(txtRazon.Text), _
                '                            ddlMoneda.SelectedValue, ddlCodmoneda.SelectedValue, ddlTipo_pago.SelectedValue, txtDias_pago.Text, ddlMonetario.SelectedValue, _
                '                            ddlTaquilla.SelectedValue, ddlRetencionISLR.SelectedValue, ddlTipopersona.SelectedValue, _
                '                            UCase(txtDireccion.Text), txtTelefono.Text, txtFax.Text, UCase(txtContacto.Text), txtEmail.Text, txtPagina.Text, _
                '                            ddlAct_ppal.SelectedValue, ddlAct_sec.SelectedValue, txtCuenta.Text, ddlTipocuenta.SelectedValue, ddlCiudad.SelectedValue, _
                '                            ddlBanco.SelectedValue, txtObservaciones.Text, ddlAprob1.SelectedValue, ddlAprob2.SelectedValue, _
                '                            txtCod_Solicitante.Text, txtMotivo.Text, ddlPais.SelectedItem.Text, ddlGP.SelectedValue.ToString(), ddlOC.SelectedValue.ToString(), ddlOS.SelectedValue.ToString(), txtCodPostal.Text.Trim())
                nro_confirmacion = tabla.aprobarSolicitud(txtCod_proceso.Text, tipo_aprob)

            End If

        Next
        If nro_confirmacion = 0 And tipo_aprob = 1 Then

            'SISAP Change Start
            'ds_email = tabla.Leer_email(ddlAprob2.SelectedValue)
            Dim ad1 As New WebApplication2.ADAuthorizationUtil()
            Dim Nombre As String
            correo = ad1.GetEmailByNTID((ddlAprob2.SelectedValue).ToString())
            Nombre = ad1.GetNombreByNTID((ddlAprob2.SelectedValue).ToString())

            'For Each row_email In ds_email.Tables("tabla3").Rows
            '    fila_email = CType(ds_email.Tables("tabla3").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
            '    mensaje = "Estimado(a) " & fila_email("NOMBRE") & "," & Chr(13) & Chr(13) & "Se registró una solicitud de creación con el Nro. " & txtCod_proceso.Text & " del proveedor " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & ", la cual requiere de su aprobación para ser creado en SUN." & Chr(13) & Chr(13) & "Por favor haz click en el siguiente link para ingresar a la aplicación y realizar la aprobación http://" & Servidor
            '    correo = fila_email("CORREO")
            '    enviar_correo(correo, mensaje, 1)
            'Next

            mensaje = "Estimado(a) " & Nombre & "," & Chr(13) & Chr(13) & "Se registró una solicitud de creación con el Nro. " & txtCod_proceso.Text & " del proveedor " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & ", la cual requiere de su aprobación para ser creado en SUN." & Chr(13) & Chr(13) & "Por favor haz click en el siguiente link para ingresar a la aplicación y realizar la aprobación http://" & Servidor
            enviar_correo(correo, mensaje, 1)

            'SISAP Change End

            jsID = "<script language='javascript'>"
            jsID += "alert('La Solicitud fue aprobada con éxito.');location.href='Aprobar_Proveedor.aspx';"
            jsID += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)

        End If


    End Sub

    Protected Sub btnRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Dim nro_confirmacion As Integer
        Dim cadena As String
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        Dim row_email
        Dim fila_email As Data.DataRow
        Dim ds_email As Data.DataSet
        Dim mensaje As String
        Dim correo As String
        ds_email = New Data.DataSet

        'SISAP Change Start 
        'nro_confirmacion = tabla.rechazarSolicitud(txtCod_proceso.Text, txtMotivo.Text, Session("Usuario").ToString())
        nro_confirmacion = tabla.rechazarSolicitud(txtCod_proceso.Text, txtMotivo.Text, Session("UserNTID").ToString())
        'SISAP Change End

        If nro_confirmacion = 0 Then
            ds_email = tabla.Leer_email_Solicitante(txtCod_proceso.Text)
            For Each row_email In ds_email.Tables("tabla4").Rows
                fila_email = CType(ds_email.Tables("tabla4").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos
                'mensaje = "Estimado (a) " & fila_email("NOMBRE") & "," & Chr(13) & Chr(13) & "La solicitud de creación de proveedor Nro. " & txtCod_proceso.Text & " ha sido rechazada por el siguiente motivo:" & Chr(13) & Chr(13) & txtMotivo.Text & "." & Chr(13) & Chr(13) & "Para proceder a realizar los ajustes respectivos por favor has click en el siguiente link http://" & Servidor

                'SISAP Change Start
                'mensaje = "Estimado (a) " & row_email("NOMBRE").ToString() & "," & Chr(13) & Chr(13) & "La solicitud de creación de proveedor Nro. " & txtCod_proceso.Text & " ha sido rechazada por el siguiente motivo:" & Chr(13) & Chr(13) & txtMotivo.Text & "." & Chr(13) & Chr(13) & "Para proceder a realizar los ajustes respectivos por favor has click en el siguiente link http://" & Servidor
                Dim Nombre As String
                Dim ad1 As New WebApplication2.ADAuthorizationUtil()
                Nombre = ad1.GetNombreByNTID(row_email("COD_SOLICITANTE").ToString())
                mensaje = "Estimado (a) " & Nombre & "," & Chr(13) & Chr(13) & "La solicitud de creación de proveedor Nro. " & txtCod_proceso.Text & " ha sido rechazada por el siguiente motivo:" & Chr(13) & Chr(13) & txtMotivo.Text & "." & Chr(13) & Chr(13) & "Para proceder a realizar los ajustes respectivos por favor has click en el siguiente link http://" & Servidor
                'correo = row_email("CORREO")
                correo = ad1.GetEmailByNTID(row_email("COD_SOLICITANTE").ToString())
                'SISAP Change end


                enviar_correo(correo, mensaje, 3)
            Next
            Limpiar()
            'MsgBox("El registro ha sido actualizado exitosamente.", MsgBoxStyle.OkOnly, "Registro Rechazado")
            jsID = "<script language='javascript'>"
            jsID += "alert('La Solicitud fue rechazada con éxito.');location.href='Aprobar_Proveedor.aspx';"
            jsID += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)
            'Response.Redirect("Aprobar_proveedor.aspx", True)
        End If

    End Sub

    Protected Sub btnAprobar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar2.Click
        Dim nro_confirmacion As Integer
        Dim cadena As String
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        Dim row_email, row
        Dim fila, fila_email As Data.DataRow
        Dim ds_email, ds As Data.DataSet
        Dim mensaje As String
        Dim correo As String
        Dim tipo_aprob As Integer

        Dim ArchivoSalida As String
        Dim texto As String

        Try
            ds_email = New Data.DataSet
            ds = New Data.DataSet

            If File.Exists(System.Configuration.ConfigurationManager.AppSettings("Directorio_TXT") + "ACC_SISAP.txt") Then
                ArchivoSalida = System.Configuration.ConfigurationManager.AppSettings("Directorio_TXT") + "ACC_SISAP.txt"
                Dim oTxtE As StreamReader = New StreamReader(ArchivoSalida)
                texto = oTxtE.ReadToEnd()
                oTxtE.Close()
            Else
                Dim oTxt As StreamWriter = New StreamWriter(System.Configuration.ConfigurationManager.AppSettings("Directorio_TXT") + "ACC_SISAP.txt", True, System.Text.Encoding.ASCII)
                oTxt.Write("")
                oTxt.Close()
                oTxt = Nothing

            End If

            'ds = tabla.Existe(Mid(UCase(User.Identity.Name.ToString), 6))  'Verificando que el usuario este autorizado

            'SISAP Change Start
            'ds = tabla.Existe(Session("Usuario"))  'Verificando que el usuario este autorizado  
            ds = tabla.Existe(Session("ADGroup"))  'Verificando que el usuario este autorizado  
            'SISAP Change End

            For Each row In ds.Tables("tabla").Rows
                fila = CType(ds.Tables("tabla").Rows(0), Data.DataRow)

                If Session("perfil") = 5 Then
                    tipo_aprob = 2
                    nro_confirmacion = tabla.crearSolicitud(3, txtCod_proceso.Text, ddlRif.SelectedValue.ToString + UCase(txtRif.Text), UCase(txtLookup.Text), UCase(txtRazon.Text), _
                                            ddlMoneda.SelectedValue, ddlCodmoneda.SelectedValue, ddlTipo_pago.SelectedValue, txtDias_pago.Text, ddlMonetario.SelectedValue, _
                                            ddlTaquilla.SelectedValue, ddlRetencionISLR.SelectedValue, ddlTipopersona.SelectedValue, _
                                            UCase(txtDireccion.Text), txtTelefono.Text, txtFax.Text, UCase(txtContacto.Text), txtEmail.Text, txtPagina.Text, _
                                            ddlAct_ppal.SelectedValue, ddlAct_sec.SelectedValue, txtCuenta.Text, ddlTipocuenta.SelectedValue, ddlCiudad.SelectedValue, _
                                            ddlBanco.SelectedValue, txtObservaciones.Text, ddlAprob1.SelectedValue, ddlAprob2.SelectedValue, _
                                            txtCod_Solicitante.Text, txtMotivo.Text, ddlPais.SelectedItem.Text, ddlGP.SelectedValue.ToString(), ddlOC.SelectedValue.ToString(), ddlOS.SelectedValue.ToString(), txtCodPostal.Text.Trim())
                    nro_confirmacion = tabla.aprobarSolicitud(txtCod_proceso.Text, tipo_aprob)
                End If
            Next


            If nro_confirmacion = 0 Then
                ds_email = tabla.Leer_email_Solicitante(txtCod_proceso.Text)

                For Each row_email In ds_email.Tables("tabla4").Rows
                    fila_email = CType(ds_email.Tables("tabla4").Rows(0), Data.DataRow)  'Llenando los campos con la informacion de la base de datos

                    'SISAP Change Start
                    Dim Nombre As String
                    Dim ad1 As New WebApplication2.ADAuthorizationUtil()
                    Nombre = ad1.GetNombreByNTID(row_email("COD_SOLICITANTE").ToString())
                    'mensaje = "Estimado(a) " & fila_email("NOMBRE") & "," & Chr(13) & Chr(13) & "Su solicitud de creación Nro. " & txtCod_proceso.Text & " del proveedor " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & " ha sido aprobada." '& Chr(13) & Chr(13) & "Por favor haga click sobre el siguiente link http://" & Servidor & "/Consultar_proveedor.aspx"
                    mensaje = "Estimado(a) " & Nombre & "," & Chr(13) & Chr(13) & "Su solicitud de creación Nro. " & txtCod_proceso.Text & " del proveedor " & ddlRif.SelectedValue.ToString.Trim & txtRif.Text.Trim & " - " & txtRazon.Text & " ha sido aprobada." '& Chr(13) & Chr(13) & "Por favor haga click sobre el siguiente link http://" & Servidor & "/Consultar_proveedor.aspx"
                    'correo = fila_email("CORREO")
                    correo = ad1.GetEmailByNTID(row_email("COD_SOLICITANTE").ToString())
                    'SISAP Change End

                    enviar_correo(correo, mensaje, 2)
                Next

                'MsgBox("La solicitud ha sido aprobada exitosamente.", MsgBoxStyle.OkOnly, "Aprobación de Solicitud")

                Limpiar()
                Me.GenerarArchivos()

                jsID = "<script language='javascript'>"
                jsID += "alert('La Solicitud fue aprobada con éxito.');location.href='Aprobar_Proveedor.aspx';"
                jsID += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "Aprobación", jsID)




                'Response.Redirect("Aprobar_Proveedor.aspx")

            Else
                jsID = "<script language='javascript'>"
                jsID += "alert('Se capturó un error de base de datos con el número " & nro_confirmacion & ".');"
                jsID += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)
            End If

        Catch ex As Exception

            'jsID = "<script language='javascript'>"
            'jsID += "alert('" & ex.Message & "');"
            'jsID += "</script>"
            'ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)
            lblError.Text = ex.Message.ToString()

        End Try


    End Sub

    Protected Sub Limpiar()
        ddlRif.ClearSelection()
        txtRif.Text = ""
        txtRazon.Text = ""
        ddlMoneda.ClearSelection()
        ddlCodmoneda.ClearSelection()
        txtLookup.Text = ""
        ddlTipo_pago.ClearSelection()
        txtDias_pago.Text = ""
        ddlMonetario.ClearSelection()
        ddlTaquilla.ClearSelection()
        ddlRetencionISLR.ClearSelection()
        ddlTipopersona.ClearSelection()
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        txtFax.Text = ""
        txtContacto.Text = ""
        txtEmail.Text = ""
        txtPagina.Text = ""
        ddlAct_ppal.ClearSelection()
        ddlAct_sec.ClearSelection()
        txtCuenta.Text = ""
        ddlTipocuenta.ClearSelection()
        ddlEstado.ClearSelection()
        ddlCiudad.ClearSelection()
        ddlBanco.ClearSelection()
        txtObservaciones.Text = ""
        txtMotivo.Text = ""
        ddlPais.ClearSelection()
        ddlGP.ClearSelection()

        ddlOC.ClearSelection()
        ddlOS.ClearSelection()
        txtCodPostal.Text = ""

    End Sub

    Protected Sub GenerarArchivos()

        Dim ArchivoSalida As String
        Dim ArchivoRespaldo As String
        Dim Filas As String
        Dim I As Integer
        Dim cadena As String
        Dim ds As Data.DataSet

        ArchivoSalida = String.Empty
        ArchivoRespaldo = String.Empty
        Filas = String.Empty

        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)

        ds = tabla.TraerDataset("sp_ArchivosTXT " & Me.txtCod_proceso.Text)

        For I = 1 To 6

            Select Case I
                Case 1
                    ArchivoSalida = "BKA_SISAP.txt"
                    ArchivoRespaldo = "BKA_SISAP_RESPALDO.txt"
                    Filas = Me.ExtraerFilas(ds.Tables(I - 1))
                Case 2
                    ArchivoSalida = "ADD_SISAP.txt"
                    ArchivoRespaldo = "ADD_SISAP_RESPALDO.txt"
                    Filas = Me.ExtraerFilas(ds.Tables(I - 1))
                Case 3
                    ArchivoSalida = "ACC_SISAP.txt"
                    ArchivoRespaldo = "ACC_SISAP_RESPALDO.txt"
                    Filas = Me.ExtraerFilas(ds.Tables(I - 1))
                Case 4
                    ArchivoSalida = "ADB_SISAP.txt"
                    ArchivoRespaldo = "ADB_SISAP_RESPALDO.txt"
                    Filas = Me.ExtraerFilas(ds.Tables(I - 1))
                Case 5
                    ArchivoSalida = "ANV_SISAP.txt"
                    ArchivoRespaldo = "ANV_SISAP_RESPALDO.txt"
                    Filas = Me.ExtraerFilas(ds.Tables(I - 1))
                Case 6
                    ArchivoSalida = "MSC_SISAP.txt"
                    ArchivoRespaldo = "MSC_SISAP_RESPALDO.txt"
                    Filas = Me.ExtraerFilas(ds.Tables(I - 1))

            End Select

            ArchivoSalida = System.Configuration.ConfigurationManager.AppSettings("Directorio_TXT") + ArchivoSalida
            ArchivoRespaldo = System.Configuration.ConfigurationManager.AppSettings("Directorio_TXT") + ArchivoRespaldo

            Dim oTxt As StreamWriter = New StreamWriter(ArchivoSalida, True, System.Text.Encoding.ASCII)
            'oTxt.Write(ds.Tables(I - 1).Rows(0).ItemArray(0))
            oTxt.Write(Filas)
            oTxt.Close()
            oTxt = Nothing

            Dim oTxtRespaldo As StreamWriter = New StreamWriter(ArchivoRespaldo, True, System.Text.Encoding.ASCII)
            'oTxtRespaldo.Write(ds.Tables(I - 1).Rows(0).ItemArray(0))
            oTxtRespaldo.Write(Filas)
            oTxtRespaldo.Close()
            oTxtRespaldo = Nothing

        Next

    End Sub

    Public Function ExtraerFilas(ByVal TB As Data.DataTable) As String
        Dim Filas As String
        Dim Fila As DataRow
        Dim Col As DataColumn
        Dim Cols As DataColumnCollection

        Cols = TB.Columns
        Filas = String.Empty

        For Each Fila In TB.Rows

            For Each Col In Cols
                Filas = Filas + Fila(Col.ColumnName).ToString
            Next
            Filas = Filas + System.Environment.NewLine ' + "\r\n"
        Next

        Return Filas

    End Function

    Private Sub HabilitarRif(ByVal Moneda_Extranjera As String)

        If Moneda_Extranjera = "Y" Then
            ddlCodmoneda.Enabled = True
            reqvRif.ValidationGroup = ""
            reqvRif.Visible = False
            reqvRif2.ValidationGroup = ""
            reqvRif2.Visible = False
        Else
            ddlCodmoneda.Enabled = False
            reqvRif.ValidationGroup = "Enviar"
            reqvRif.Visible = True
            reqvRif2.ValidationGroup = "Enviar"
            reqvRif2.Visible = True
            rfvMoneda.Visible = False
        End If
    End Sub

    Protected Sub ibtnValidarRif_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnValidarRif.Click
        Dim cadena As String
        cadena = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim tabla As New Procesar_proveedor(cadena)
        Dim DSExisteRif As DataTable
        Try

            DSExisteRif = tabla.TraerTabla("sp_VerificarRif " & ddlRif.SelectedValue.ToString + UCase(txtRif.Text))

            If DSExisteRif.Rows(0)("RESULTADO").ToString = 1 Then
                jsID = "<script language='javascript'>"
                jsID += "alert('Ya existe un proveedor con el Rif " & ddlRif.SelectedValue.ToString + UCase(txtRif.Text) & ". Por favor ingrese uno nuevo.');"
                jsID += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)
                Exit Sub
            Else
                jsID = "<script language='javascript'>"
                jsID += "alert('No existe proveedor con el número de Rif " & ddlRif.SelectedValue.ToString + UCase(txtRif.Text) & ".'); LennarLookUp();"
                jsID += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "VentanaMensaje", jsID)
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlRif_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRif.SelectedIndexChanged
        HabilitarRif()
    End Sub

    Private Sub HabilitarRif()
        If ddlRif.SelectedValue = "NA" Then
            reqvRif2.Enabled = False
            txtRif.Enabled = False
        Else
            reqvRif2.Enabled = True
            txtRif.Enabled = True
        End If
    End Sub

End Class
