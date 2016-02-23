Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Procesar_proveedor
#Region "declaracion y constructor"
    'Declaracion de las variables de la clase
    Private connectionString As String

    'Declaracion de los metodos
    'Constructor de la clase
    'Parametro connectionString para establecer la conexion con la base de datos
    Public Sub New(ByVal connectionString As String)
        Me.connectionString = connectionString
    End Sub

#End Region

    Public Function Existe(ByVal cod_usuario As String) As System.Data.DataSet

        Dim ad As Data.SqlClient.SqlDataAdapter
        Dim ds As Data.DataSet

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As New Data.SqlClient.SqlConnection(connectionString)
        Dim objCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand("ValidarUsuario", dbConexion)


        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = Data.CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro id_nt
        'SISAP Changes Start
        'Dim parameterid_nt As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter("@COD_USUARIO", Data.SqlDbType.VarChar, 50)1
        Dim parameterid_nt As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter("@ADGroupName", Data.SqlDbType.VarChar, 50)
        'SISAP Changes End
        parameterid_nt.Value = cod_usuario
        objCommand.Parameters.Add(parameterid_nt)


        dbConexion.Open()
        ad = New Data.SqlClient.SqlDataAdapter(objCommand)
        ds = New Data.DataSet
        ad.Fill(ds, "tabla")
        dbConexion.Close()
        Return ds

    End Function

    Public Function ValidarEstatus(ByVal cod_proceso As String) As System.Data.DataSet

        Dim ad As Data.SqlClient.SqlDataAdapter
        Dim ds As Data.DataSet

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As New Data.SqlClient.SqlConnection(connectionString)
        Dim objCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand("ValidarEstatus", dbConexion)


        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = Data.CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro cod_proceso
        Dim parametercod_proceso As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter("@cod_proceso", Data.SqlDbType.Int)
        parametercod_proceso.Value = cod_proceso
        objCommand.Parameters.Add(parametercod_proceso)


        dbConexion.Open()
        ad = New Data.SqlClient.SqlDataAdapter(objCommand)
        ds = New Data.DataSet
        ad.Fill(ds, "tabla_est")
        dbConexion.Close()
        Return ds

    End Function

    Public Function crearSolicitud(ByVal Accion As Integer, _
                                      ByVal COD_PROCESO As Integer, _
                                      ByVal RIF As String, _
                                      ByVal LOOKUP As String, _
                                      ByVal RAZON_SOCIAL As String, _
                                      ByVal CONV_CNTRL As String, _
                                      ByVal CONV_CODE As String, _
                                      ByVal PRIORITY As String, _
                                      ByVal PAYMENT_DAY As String, _
                                      ByVal MONETARIO As String, _
                                      ByVal TAQUILLA As String, _
                                      ByVal RET_PEND As String, _
                                      ByVal NAT_JUR As String, _
                                      ByVal DIRECCION As String, _
                                      ByVal TELEFONO As String, _
                                      ByVal FAX As String, _
                                      ByVal CONTACTO As String, _
                                      ByVal E_MAIL As String, _
                                      ByVal WEB_PAGE As String, _
                                      ByVal TIPO_SERVICIO As String, _
                                      ByVal TIPO_SERVICIO2 As String, _
                                      ByVal CUENTA_BANCO As String, _
                                      ByVal TIPO_CTA_BANCO As String, _
                                      ByVal COD_CIUDAD As String, _
                                      ByVal COD_BANCO As String, _
                                      ByVal OBSERVACIONES As String, _
                                      ByVal COD_APROB1 As String, _
                                      ByVal COD_APROB2 As String, _
                                      ByVal COD_SOLICITANTE As String, _
                                      ByVal MOTIVO As String, _
                                      ByVal PAIS As String, _
                                      ByVal ANAL_A8 As String, _
                                      ByVal ANAL_C4 As String, _
                                      ByVal ANAL_C5 As String, _
                                      ByVal COD_POSTAL As String) As Integer

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As SqlConnection = New SqlConnection(Me.connectionString)

        Dim objCommand As SqlCommand = New SqlCommand("crearSolicitud", dbConexion)

        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro Accion
        Dim parameterAccion As SqlParameter = New SqlParameter("@Accion", SqlDbType.Char, 1)
        parameterAccion.Value = Accion
        objCommand.Parameters.Add(parameterAccion)

        ' Parametro COD_PROCESO
        Dim parameterCOD_PROCESO As SqlParameter = New SqlParameter("@COD_PROCESO", SqlDbType.Int)
        parameterCOD_PROCESO.Value = COD_PROCESO
        objCommand.Parameters.Add(parameterCOD_PROCESO)

        ' Parametro RIF
        Dim parameterRIF As SqlParameter = New SqlParameter("@RIF", SqlDbType.VarChar, 50)
        parameterRIF.Value = RIF
        objCommand.Parameters.Add(parameterRIF)

        ' Parametro LOOKUP
        Dim parameterLOOKUP As SqlParameter = New SqlParameter("@LOOKUP", SqlDbType.VarChar, 50)
        parameterLOOKUP.Value = LOOKUP
        objCommand.Parameters.Add(parameterLOOKUP)

        ' Parametro RAZON_SOCIAL
        Dim parameterRAZON_SOCIAL As SqlParameter = New SqlParameter("@RAZON_SOCIAL", SqlDbType.VarChar, 50)
        parameterRAZON_SOCIAL.Value = RAZON_SOCIAL
        objCommand.Parameters.Add(parameterRAZON_SOCIAL)

        ' Parametro CONV_CNTRL
        Dim parameterCONV_CNTRL As SqlParameter = New SqlParameter("@CONV_CNTRL", SqlDbType.VarChar, 50)
        parameterCONV_CNTRL.Value = CONV_CNTRL
        objCommand.Parameters.Add(parameterCONV_CNTRL)

        ' Parametro CONV_CODE
        Dim parameterCONV_CODE As SqlParameter = New SqlParameter("@CONV_CODE", SqlDbType.VarChar, 50)
        parameterCONV_CODE.Value = CONV_CODE
        objCommand.Parameters.Add(parameterCONV_CODE)

        ' Parametro PRIORITY
        Dim parameterPRIORITY As SqlParameter = New SqlParameter("@PRIORITY", SqlDbType.Char, 10)
        parameterPRIORITY.Value = PRIORITY
        objCommand.Parameters.Add(parameterPRIORITY)

        ' Parametro PAYMENT_DAY
        Dim parameterPAYMENT_DAY As SqlParameter = New SqlParameter("@PAYMENT_DAY", SqlDbType.VarChar, 50)
        parameterPAYMENT_DAY.Value = PAYMENT_DAY
        objCommand.Parameters.Add(parameterPAYMENT_DAY)

        ' Parametro MONETARIO
        Dim parameterMONETARIO As SqlParameter = New SqlParameter("@MONETARIO", SqlDbType.Char, 10)
        parameterMONETARIO.Value = MONETARIO
        objCommand.Parameters.Add(parameterMONETARIO)

        ' Parametro TAQUILLA
        Dim parameterTAQUILLA As SqlParameter = New SqlParameter("@TAQUILLA", SqlDbType.VarChar, 50)
        parameterTAQUILLA.Value = TAQUILLA
        objCommand.Parameters.Add(parameterTAQUILLA)

        ' Parametro RET_PEND
        Dim parameterRET_PEND As SqlParameter = New SqlParameter("@RET_PEND", SqlDbType.VarChar, 50)
        parameterRET_PEND.Value = RET_PEND
        objCommand.Parameters.Add(parameterRET_PEND)

        ' Parametro NAT_JUR
        Dim parameterNAT_JUR As SqlParameter = New SqlParameter("@NAT_JUR", SqlDbType.VarChar, 50)
        parameterNAT_JUR.Value = NAT_JUR
        objCommand.Parameters.Add(parameterNAT_JUR)

        ' Parametro DIRECCION
        Dim parameterDIRECCION As SqlParameter = New SqlParameter("@DIRECCION", SqlDbType.VarChar, 150)
        parameterDIRECCION.Value = DIRECCION
        objCommand.Parameters.Add(parameterDIRECCION)

        ' Parametro TELEFONO
        Dim parameterTELEFONO As SqlParameter = New SqlParameter("@TELEFONO", SqlDbType.VarChar, 50)
        parameterTELEFONO.Value = TELEFONO
        objCommand.Parameters.Add(parameterTELEFONO)

        ' Parametro FAX
        Dim parameterFAX As SqlParameter = New SqlParameter("@FAX", SqlDbType.VarChar, 50)
        parameterFAX.Value = FAX
        objCommand.Parameters.Add(parameterFAX)

        ' Parametro CONTACTO
        Dim parameterCONTACTO As SqlParameter = New SqlParameter("@CONTACTO", SqlDbType.VarChar, 50)
        parameterCONTACTO.Value = CONTACTO
        objCommand.Parameters.Add(parameterCONTACTO)

        ' Parametro E_MAIL
        Dim parameterE_MAIL As SqlParameter = New SqlParameter("@E_MAIL", SqlDbType.VarChar, 50)
        parameterE_MAIL.Value = E_MAIL
        objCommand.Parameters.Add(parameterE_MAIL)

        ' Parametro WEB_PAGE
        Dim parameterWEB_PAGE As SqlParameter = New SqlParameter("@WEB_PAGE", SqlDbType.VarChar, 50)
        parameterWEB_PAGE.Value = WEB_PAGE
        objCommand.Parameters.Add(parameterWEB_PAGE)

        ' Parametro TIPO_SERVICIO
        Dim parameterTIPO_SERVICIO As SqlParameter = New SqlParameter("@TIPO_SERVICIO", SqlDbType.VarChar, 50)
        parameterTIPO_SERVICIO.Value = TIPO_SERVICIO
        objCommand.Parameters.Add(parameterTIPO_SERVICIO)

        ' Parametro TIPO_SERVICIO2
        Dim parameterTIPO_SERVICIO2 As SqlParameter = New SqlParameter("@TIPO_SERVICIO2", SqlDbType.VarChar, 50)
        parameterTIPO_SERVICIO2.Value = TIPO_SERVICIO2
        objCommand.Parameters.Add(parameterTIPO_SERVICIO2)

        ' Parametro CUENTA_BANCO
        Dim parameterCUENTA_BANCO As SqlParameter = New SqlParameter("@CUENTA_BANCO", SqlDbType.VarChar, 50)
        parameterCUENTA_BANCO.Value = CUENTA_BANCO
        objCommand.Parameters.Add(parameterCUENTA_BANCO)

        ' Parametro TIPO_CTA_BANCO
        Dim parameterTIPO_CTA_BANCO As SqlParameter = New SqlParameter("@TIPO_CTA_BANCO", SqlDbType.VarChar, 50)
        parameterTIPO_CTA_BANCO.Value = TIPO_CTA_BANCO
        objCommand.Parameters.Add(parameterTIPO_CTA_BANCO)

        ' Parametro COD_CIUDAD
        Dim parameterCOD_CIUDAD As SqlParameter = New SqlParameter("@COD_CIUDAD", SqlDbType.Int)
        parameterCOD_CIUDAD.Value = COD_CIUDAD
        objCommand.Parameters.Add(parameterCOD_CIUDAD)

        ' Parametro COD_BANCO
        Dim parameterCOD_BANCO As SqlParameter = New SqlParameter("@COD_BANCO", SqlDbType.Int)
        parameterCOD_BANCO.Value = COD_BANCO
        objCommand.Parameters.Add(parameterCOD_BANCO)

        ' Parametro OBSERVACIONES
        Dim parameterOBSERVACIONES As SqlParameter = New SqlParameter("@OBSERVACIONES", SqlDbType.VarChar, 150)
        parameterOBSERVACIONES.Value = OBSERVACIONES
        objCommand.Parameters.Add(parameterOBSERVACIONES)

        ' Parametro COD_APROB1
        Dim parameterCOD_APROB1 As SqlParameter = New SqlParameter("@COD_APROB1", SqlDbType.VarChar, 50)
        parameterCOD_APROB1.Value = COD_APROB1
        objCommand.Parameters.Add(parameterCOD_APROB1)

        ' Parametro COD_APROB2
        Dim parameterCOD_APROB2 As SqlParameter = New SqlParameter("@COD_APROB2", SqlDbType.VarChar, 50)
        parameterCOD_APROB2.Value = COD_APROB2
        objCommand.Parameters.Add(parameterCOD_APROB2)

        ' Parametro COD_SOLICITANTE
        Dim parameterCOD_SOLICITANTE As SqlParameter = New SqlParameter("@COD_SOLICITANTE", SqlDbType.VarChar, 50)
        parameterCOD_SOLICITANTE.Value = COD_SOLICITANTE
        objCommand.Parameters.Add(parameterCOD_SOLICITANTE)

        ' Parametro MOTIVO
        Dim parameterMOTIVO As SqlParameter = New SqlParameter("@MOTIVO_RECHAZO", SqlDbType.VarChar, 150)
        parameterMOTIVO.Value = MOTIVO
        objCommand.Parameters.Add(parameterMOTIVO)

        ' Parametro PAIS
        Dim parameterPAIS As SqlParameter = New SqlParameter("@PAIS", SqlDbType.VarChar, 150)
        parameterPAIS.Value = PAIS
        objCommand.Parameters.Add(parameterPAIS)

        ' Parametro ANAL_A8
        Dim parameterANAL_A8 As SqlParameter = New SqlParameter("@ANAL_A8", SqlDbType.VarChar, 150)
        parameterANAL_A8.Value = ANAL_A8
        objCommand.Parameters.Add(parameterANAL_A8)

        ' Parametro ANAL_C4
        Dim parameterANAL_C4 As SqlParameter = New SqlParameter("@ANAL_C4", SqlDbType.VarChar, 150)
        parameterANAL_C4.Value = ANAL_C4
        objCommand.Parameters.Add(parameterANAL_C4)

        ' Parametro ANAL_C5
        Dim parameterANAL_C5 As SqlParameter = New SqlParameter("@ANAL_C5", SqlDbType.VarChar, 150)
        parameterANAL_C5.Value = ANAL_C5
        objCommand.Parameters.Add(parameterANAL_C5)

        ' Parametro COD_POSTAL
        Dim parameterCOD_POSTAL As SqlParameter = New SqlParameter("@COD_POSTAL", SqlDbType.VarChar, 50)
        parameterCOD_POSTAL.Value = COD_POSTAL
        objCommand.Parameters.Add(parameterCOD_POSTAL)

        Try
            dbConexion.Open()
            'objCommand.ExecuteNonQuery()
            Return objCommand.ExecuteScalar()
            dbConexion.Close()
        Catch ex As SqlException
            Return ex.Number
        End Try

    End Function

    Public Function crearBanco(ByVal Accion As Integer, _
                                      ByVal COD_BANCO As Integer, _
                                      ByVal BANCO As String, _
                                      ByVal SWIFT As String, _
                                      ByVal LOCAL As Boolean) As Integer

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As SqlConnection = New SqlConnection(Me.connectionString)

        Dim objCommand As SqlCommand = New SqlCommand("crearBanco", dbConexion)

        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro Accion
        Dim parameterAccion As SqlParameter = New SqlParameter("@Accion", SqlDbType.Char, 1)
        parameterAccion.Value = Accion
        objCommand.Parameters.Add(parameterAccion)

        ' Parametro COD_BANCO
        Dim parameterCOD_BANCO As SqlParameter = New SqlParameter("@COD_BANCO", SqlDbType.Int)
        parameterCOD_BANCO.Value = COD_BANCO
        objCommand.Parameters.Add(parameterCOD_BANCO)

        ' Parametro BANCO
        Dim parameterBANCO As SqlParameter = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 50)
        parameterBANCO.Value = BANCO
        objCommand.Parameters.Add(parameterBANCO)

        ' Parametro COD_SWIFT
        Dim parameterCOD_SWIFT As SqlParameter = New SqlParameter("@COD_SWIFT", SqlDbType.VarChar, 50)
        parameterCOD_SWIFT.Value = SWIFT
        objCommand.Parameters.Add(parameterCOD_SWIFT)

        ' Parametro BRANCH
        Dim parameterBRANCH As SqlParameter = New SqlParameter("@BRANCH", SqlDbType.VarChar, 50)
        parameterBRANCH.Value = BANCO
        objCommand.Parameters.Add(parameterBRANCH)


        ' Parametro ACTIVO
        Dim parameterACTIVO As SqlParameter = New SqlParameter("@ACTIVO", SqlDbType.Bit, 50)
        parameterACTIVO.Value = True
        objCommand.Parameters.Add(parameterACTIVO)


        ' Parametro ACTIVO
        Dim parameterLOCAL As SqlParameter = New SqlParameter("@LOCAL", SqlDbType.Bit, 50)
        parameterLOCAL.Value = LOCAL
        objCommand.Parameters.Add(parameterLOCAL)
        Try
            dbConexion.Open()
            objCommand.ExecuteNonQuery()
            dbConexion.Close()
        Catch ex As SqlException
            Return ex.Number
        End Try

    End Function

    Public Function crearUsuarios(ByVal Accion As Integer, _
                                      ByVal COD_USUARIO As String, _
                                      ByVal NOMBRE As String, _
                                      ByVal COD_PERFIL As Integer, _
                                      ByVal CORREO As String) As Integer

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As SqlConnection = New SqlConnection(Me.connectionString)

        Dim objCommand As SqlCommand = New SqlCommand("crearUsuarios", dbConexion)

        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro Accion
        Dim parameterAccion As SqlParameter = New SqlParameter("@Accion", SqlDbType.Char, 1)
        parameterAccion.Value = Accion
        objCommand.Parameters.Add(parameterAccion)

        ' Parametro COD_USUARIO
        Dim parameterCOD_USUARIO As SqlParameter = New SqlParameter("@COD_USUARIO", SqlDbType.VarChar, 50)
        parameterCOD_USUARIO.Value = COD_USUARIO
        objCommand.Parameters.Add(parameterCOD_USUARIO)

        ' Parametro NOMBRE
        Dim parameterNOMBRE As SqlParameter = New SqlParameter("@NOMBRE", SqlDbType.VarChar, 50)
        parameterNOMBRE.Value = NOMBRE
        objCommand.Parameters.Add(parameterNOMBRE)

        ' Parametro COD_PERFIL
        Dim parameterCOD_PERFIL As SqlParameter = New SqlParameter("@COD_PERFIL", SqlDbType.Int)
        parameterCOD_PERFIL.Value = COD_PERFIL
        objCommand.Parameters.Add(parameterCOD_PERFIL)


        ' Parametro CORREO
        Dim parameterCORREO As SqlParameter = New SqlParameter("@CORREO", SqlDbType.VarChar, 50)
        parameterCORREO.Value = CORREO
        objCommand.Parameters.Add(parameterCORREO)

        ' Parametro CORREO
        Dim parameterACTIVO As SqlParameter = New SqlParameter("@ACTIVO", SqlDbType.Bit, 50)
        parameterACTIVO.Value = True
        objCommand.Parameters.Add(parameterACTIVO)

        Try
            dbConexion.Open()
            objCommand.ExecuteNonQuery()
            dbConexion.Close()
        Catch ex As SqlException
            Return ex.Number
        End Try

    End Function

    Public Function Mostrar_datos(ByVal cod_proceso As Integer) As System.Data.DataSet

        Dim ad As Data.SqlClient.SqlDataAdapter
        Dim ds As Data.DataSet

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As New Data.SqlClient.SqlConnection(connectionString)
        Dim objCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand("leerProveedor", dbConexion)


        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = Data.CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro cod_proceso
        Dim parametercod_proceso As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter("@COD_PROCESO", Data.SqlDbType.Int)
        parametercod_proceso.Value = cod_proceso
        objCommand.Parameters.Add(parametercod_proceso)

        dbConexion.Open()
        ad = New Data.SqlClient.SqlDataAdapter(objCommand)
        ds = New Data.DataSet
        ad.Fill(ds, "tabla2")
        dbConexion.Close()
        Return ds

    End Function

    Public Function aprobarSolicitud(ByVal COD_PROCESO As Integer, _
                                  ByVal TIPO_APROB As Integer) As Integer

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As SqlConnection = New SqlConnection(Me.connectionString)

        Dim objCommand As SqlCommand = New SqlCommand("aprobarSolicitud", dbConexion)

        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 
        ' Parametro COD_PROCESO 
        Dim parameterCOD_PROCESO As SqlParameter = New SqlParameter("@COD_PROCESO", SqlDbType.Int)
        parameterCOD_PROCESO.Value = COD_PROCESO
        objCommand.Parameters.Add(parameterCOD_PROCESO)

        ' Parametro TIPO_APROB
        Dim parameterTIPO_APROB As SqlParameter = New SqlParameter("@TIPO_APROB", SqlDbType.Char, 1)
        parameterTIPO_APROB.Value = TIPO_APROB
        objCommand.Parameters.Add(parameterTIPO_APROB)


        Try
            dbConexion.Open()
            Return objCommand.ExecuteScalar()
            dbConexion.Close()
        Catch ex As SqlException
            Return ex.Number
        End Try

    End Function

    Public Function Leer_email(ByVal cod_usuario As String) As System.Data.DataSet

        'SISAP Code Change Start
        Dim ad As Data.SqlClient.SqlDataAdapter
        Dim ds As Data.DataSet

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As New Data.SqlClient.SqlConnection(connectionString)
        Dim objCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand("LeeEmail", dbConexion)


        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = Data.CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro cod_perfil
        Dim parametercod_usuario As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter("@COD_USUARIO", Data.SqlDbType.VarChar)
        parametercod_usuario.Value = cod_usuario
        objCommand.Parameters.Add(parametercod_usuario)


        dbConexion.Open()
        ad = New Data.SqlClient.SqlDataAdapter(objCommand)
        ds = New Data.DataSet
        ad.Fill(ds, "tabla3")
        dbConexion.Close()
        Return ds
       
        'SISAP Code End

    End Function

    Public Function Leer_email_Solicitante(ByVal cod_proceso As Integer) As System.Data.DataSet

        Dim ad As Data.SqlClient.SqlDataAdapter
        Dim ds As Data.DataSet

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As New Data.SqlClient.SqlConnection(connectionString)
        Dim objCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand("LeeEmail_Solicitante", dbConexion)


        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = Data.CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 

        ' Parametro cod_proceso
        Dim parametercod_proceso As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter("@COD_PROCESO", Data.SqlDbType.Int)
        parametercod_proceso.Value = cod_proceso
        objCommand.Parameters.Add(parametercod_proceso)


        dbConexion.Open()
        ad = New Data.SqlClient.SqlDataAdapter(objCommand)
        ds = New Data.DataSet
        ad.Fill(ds, "tabla4")
        dbConexion.Close()
        Return ds

    End Function

    Public Function rechazarSolicitud(ByVal COD_PROCESO As Integer, _
                                  ByVal MOTIVO_RECHAZO As String, ByVal USUARIO As String) As Integer

        ' Se instancia la conexión y se crea el objeto command
        Dim dbConexion As SqlConnection = New SqlConnection(Me.connectionString)

        Dim objCommand As SqlCommand = New SqlCommand("rechazarSolicitud", dbConexion)

        ' Se define el Command como un Stored Procedure
        objCommand.CommandType = CommandType.StoredProcedure

        ' Se agregan los parametros del Stored Procedure 
        ' Parametro COD_PROCESO 
        Dim parameterCOD_PROCESO As SqlParameter = New SqlParameter("@COD_PROCESO", SqlDbType.Int)
        parameterCOD_PROCESO.Value = COD_PROCESO
        objCommand.Parameters.Add(parameterCOD_PROCESO)

        ' Parametro MOTIVO_RECHAZO
        Dim parameterMOTIVO_RECHAZO As SqlParameter = New SqlParameter("@MOTIVO_RECHAZO", SqlDbType.VarChar, 150)
        parameterMOTIVO_RECHAZO.Value = MOTIVO_RECHAZO
        objCommand.Parameters.Add(parameterMOTIVO_RECHAZO)

        ' Parametro MOTIVO_RECHAZO
        Dim parameterUSUARIO As SqlParameter = New SqlParameter("@USUARIO", SqlDbType.VarChar, 150)
        parameterUSUARIO.Value = USUARIO
        objCommand.Parameters.Add(parameterUSUARIO)

        Try
            dbConexion.Open()
            objCommand.ExecuteNonQuery()
            dbConexion.Close()
        Catch ex As SqlException
            Return ex.Number
        End Try

    End Function

    Public Function TraerTabla(ByVal ProcedimientoAlmacenado As String) As System.Data.DataTable
        Dim DS As New DataSet
        Dim DT As DataTable
        Dim DA As Data.SqlClient.SqlDataAdapter
        Dim dbConexion As New Data.SqlClient.SqlConnection(connectionString)
        DT = Nothing

        Try

            DA = New Data.SqlClient.SqlDataAdapter(ProcedimientoAlmacenado, dbConexion)
            DA.Fill(DS, "Tabla")
            If DS.Tables("Tabla").Rows.Count > 0 Then
                DT = DS.Tables("Tabla")
            End If

        Catch ex As Exception

        End Try

        Return DT

    End Function

    Public Function TraerDataset(ByVal ProcedimientoAlmacenado As String) As System.Data.DataSet
        Dim DS As New DataSet
        Dim DA As Data.SqlClient.SqlDataAdapter
        Dim dbConexion As New Data.SqlClient.SqlConnection(connectionString)

        Try

            DA = New Data.SqlClient.SqlDataAdapter(ProcedimientoAlmacenado, dbConexion)
            DA.Fill(DS)

        Catch ex As Exception

        End Try

        Return DS

    End Function


End Class
