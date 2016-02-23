<%@ Page Language="VB" MasterPageFile="~/prove.master" AutoEventWireup="false" Inherits="SISAP_VB.Index" MaintainScrollPositionOnPostback="true" Title="Solicitud de Creación de Proveedores" CodeBehind="Index.aspx.vb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%" id="TABLE1" cellspacing="0">
        <tr>
            <td colspan="6" style="height: 14px; background-color: #e0e0e0;" align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="Medium" ForeColor="Black" Text="Solicitudes"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 30px; border-bottom-style: solid; vertical-align: bottom;" align="left">
                <strong><span style="font-family: Verdana; color: #000099; font-size: 10pt;">Datos Básicos</span></strong>
            </td>
            <td colspan="1" style="height: 30px; border-bottom-style: solid; vertical-align: bottom;" align="right">
                <asp:Label ID="lblCod_proceso" runat="server" Text="Solicitud Nro." Width="93px" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"></asp:Label>
                <asp:TextBox ID="txtCod_proceso" runat="server" Enabled="False" Width="47px" Height="12px" Font-Size="X-Small" BorderColor="White" BorderWidth="0px"></asp:TextBox></td>
        </tr>


        <tr>

            <td style="width: 122px; height: 9px;" align="left">
                <asp:Label ID="lblRif" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Rif" Width="18px" Height="1px"></asp:Label></td>
            <td align="left" colspan="" style="width: 162px; height: 9px;">
                <asp:DropDownList onclick="LennarLookUp();" onkeyup="LennarLookUp();" ID="ddlRif" runat="server" Font-Size="X-Small" Width="40px" AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>E</asp:ListItem>
                    <asp:ListItem>G</asp:ListItem>
                    <asp:ListItem>J</asp:ListItem>
                    <asp:ListItem>V</asp:ListItem>
                    <asp:ListItem>P</asp:ListItem>
                    <asp:ListItem>NA</asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvRif" runat="server" ControlToValidate="ddlRif"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator>
                <asp:TextBox onkeyup="LennarLookUp();" onblur="javascript:validarlng(this);" ID="txtRif" runat="server" Width="60px" Font-Size="X-Small"></asp:TextBox><asp:RequiredFieldValidator ID="reqvRif2" runat="server" ControlToValidate="txtRif" ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator>
                <asp:ImageButton ID="ibtnValidarRif" runat="server" ImageUrl="~/images/Find.png" ToolTip="Validar Rif" OnClick="ibtnValidarRif_Click" /></td>
            <td align="left" style="width: 75px; height: 9px;">
                <asp:Label ID="lblLookup" runat="server" Text="Lookup" Width="18px" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" Height="3px"></asp:Label></td>
            <td align="left" style="height: 9px">
                <asp:TextBox ID="txtLookup" runat="server" Font-Size="X-Small" Width="99px" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                    ID="reqvLookup" runat="server" ControlToValidate="txtLookup" ErrorMessage="*"
                    ValidationGroup="DatosPago"></asp:RequiredFieldValidator></td>
            <td style="height: 9px" align="right">&nbsp;<a style="font-family: Verdana; color: #2C6EB8; font-weight: bold; font-size: 'X-Small'; font-size: xx-small; text-decoration: underline;" href="javascript:AbrirBuscarRif('<%= System.Configuration.ConfigurationManager.AppSettings("RIF_SENIAT").ToString %>');">Consultar Rif en el Seniat</a>
            </td>
        </tr>

        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="lblRazon" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Razón Social" Width="76px"></asp:Label></td>
            <td colspan="4" align="left">
                <asp:TextBox ID="txtRazon" runat="server" Width="343px" Font-Size="X-Small" MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="reqvrazon" runat="server" ControlToValidate="txtRazon"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>

        </tr>
        <tr>
            <td align="left" style="width: 122px; height: 21px;">
                <asp:Label ID="lblExtranjera" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Moneda Extranjera?" Width="114px"></asp:Label></td>
            <td align="left" style="width: 162px">
                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Size="X-Small" AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                    <asp:ListItem Value="Y">Si</asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvMoneda" runat="server" ControlToValidate="ddlMoneda"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
            <td align="left" style="width: 75px; height: 21px;">
                <asp:Label ID="lblTipo_Moneda" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Tipo Moneda" Width="76px"></asp:Label></td>
            <td align="left">
                <asp:DropDownList ID="ddlCodmoneda" runat="server" DataSourceID="SqlDataSource1"
                    DataTextField="CODE" DataValueField="CODE" Font-Size="X-Small" Enabled="False" Width="105px" AutoPostBack="True">
                </asp:DropDownList><asp:RequiredFieldValidator ID="rfvMoneda" runat="server"
                    ErrorMessage="*" ValidationGroup="Enviar" ControlToValidate="ddlCodmoneda"></asp:RequiredFieldValidator></td>
            <td></td>
        </tr>
        <tr>

            <td colspan="3" align="left">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Factura con Orden de Servicio?" Width="180px"></asp:Label><asp:DropDownList ID="ddlOS" runat="server" Font-Size="X-Small">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="OS">Si</asp:ListItem>
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlOS"
                        ErrorMessage="*" ValidationGroup="Enviar">
                    </asp:RequiredFieldValidator></td>

            <td colspan="2" align="left">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Factura con Orden de Compra?" Width="182px"></asp:Label><asp:DropDownList ID="ddlOC" runat="server" Font-Size="X-Small">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="OC">Si</asp:ListItem>
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                        ErrorMessage="*" ValidationGroup="Enviar" ControlToValidate="ddlOC">
                    </asp:RequiredFieldValidator></td>

        </tr>



    </table>
    <table width="100%" cellspacing="0">
        <tr>
            <td style="height: 30px; border-bottom-style: solid; vertical-align: bottom;" colspan="6" align="left">
                <strong><span style="font-family: Verdana; color: #000099; font-size: 10pt; vertical-align: bottom;">Datos de Contacto</span></strong></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px; height: 23px;">
                <asp:Label ID="lblDireccion" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Dirección Fiscal" Width="92px" Height="9px"></asp:Label></td>
            <td colspan="5" align="left" style="height: 23px">
                <asp:TextBox ID="txtDireccion" runat="server" Width="629px" Font-Size="X-Small" MaxLength="75"></asp:TextBox><asp:RequiredFieldValidator ID="reqvDireccion" runat="server" ControlToValidate="txtDireccion"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px;">
                <asp:Label ID="lblEstado" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Height="11px" Text="Estado" Width="1px"></asp:Label></td>
            <td align="left" style="width: 171px; height: 21px;">
                <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" DataSourceID="SqldsEstado"
                    DataTextField="DESCRIPCION" DataValueField="COD_ESTADO" Font-Size="X-Small" Width="161px">
                </asp:DropDownList></td>
            <td align="left" style="width: 70px;">
                <asp:Label ID="lblCiudad" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Height="6px" Text="Ciudad" Width="20px"></asp:Label></td>
            <td align="left" style="width: 127px">
                <asp:DropDownList ID="ddlCiudad" runat="server" DataSourceID="SqldsCiudad" DataTextField="DESCRIPCION"
                    DataValueField="COD_CIUDAD" Font-Size="X-Small" Width="119px">
                </asp:DropDownList></td>
            <td align="left" style="width: 86px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Pais" Width="34px"></asp:Label></td>
            <td align="left">
                <asp:DropDownList ID="ddlPais" runat="server" DataSourceID="SDSPais" DataTextField="NOMBRE_PAIS"
                    DataValueField="NOMBRE_PAIS" Font-Size="X-Small" Width="175px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="lblTelefono" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Height="4px" Text="Teléfono" Width="54px"></asp:Label></td>
            <td align="left" style="width: 171px">
                <asp:TextBox ID="txtTelefono" runat="server" Width="155px" Font-Size="X-Small" MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="reqvTelefono" runat="server" ControlToValidate="txtTelefono"
                    ErrorMessage="*" ValidationGroup="Enviar" Width="5px"></asp:RequiredFieldValidator></td>
            <td align="left" style="width: 70px">
                <asp:Label ID="lblFax" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Fax" Width="26px"></asp:Label></td>
            <td align="left" style="width: 127px">
                <asp:TextBox ID="txtFax" runat="server" Width="113px" Font-Size="X-Small" MaxLength="15"></asp:TextBox></td>
            <td align="left" style="width: 86px">
                <asp:Label ID="lblContacto" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Contacto" Width="34px"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="txtContacto" runat="server" Width="167px" Font-Size="X-Small" MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="reqvContacto" runat="server" ControlToValidate="txtContacto"
                    ErrorMessage="*" Width="1px" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Height="9px" Text="E-mail" Width="40px"></asp:Label></td>
            <td align="left" style="width: 171px">
                <asp:TextBox ID="txtEmail" runat="server" Width="155px" Font-Size="X-Small" MaxLength="124"></asp:TextBox><asp:RequiredFieldValidator
                    ID="reqvCorreo" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="*" ValidationGroup="Enviar" Width="1px"></asp:RequiredFieldValidator>
            </td>
            <td align="left" style="width: 70px">
                <asp:Label ID="lblPagina" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Height="5px" Text="Página Web" Width="68px"></asp:Label></td>
            <td align="left" style="width: 127px">
                <asp:TextBox ID="txtPagina" runat="server" Font-Size="X-Small" Width="113px" MaxLength="124"></asp:TextBox></td>
            <td align="left" style="width: 86px">
                <asp:Label ID="lblCodPostal" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Código Postal" Width="85px"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="txtCodPostal" runat="server" Font-Size="X-Small" MaxLength="15"
                    Width="167px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="height: 21px">
                <asp:Label ID="lblAct_Ppal" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Actividad Principal" Width="106px"></asp:Label></td>
            <td align="left" colspan="2" style="height: 21px">
                <asp:DropDownList ID="ddlAct_ppal" runat="server" DataSourceID="SqlDataSource2"
                    DataTextField="NAME" DataValueField="CODE" Font-Size="X-Small" Width="226px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvAct_ppal" runat="server" ControlToValidate="ddlAct_ppal"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
            <td align="left" style="width: 127px; height: 21px;">
                <asp:Label ID="lblAct_sec" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Actividad Secundaria" Width="120px"></asp:Label></td>
            <td align="left" colspan="2" style="height: 21px">
                <asp:DropDownList ID="ddlAct_sec" runat="server" DataSourceID="SqlDataSource2"
                    DataTextField="NAME" DataValueField="CODE" Font-Size="X-Small" Width="258px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvAct_sec" runat="server" ControlToValidate="ddlAct_sec"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>

        </tr>
    </table>
    <table width="100%" cellspacing="0">
        <tr>
            <td colspan="6" style="height: 30px; border-bottom-style: solid; vertical-align: bottom;" align="left">
                <span style="font-family: Verdana; color: #000099; font-size: 10pt;"><strong>Datos del Banco</strong></span></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px; height: 23px;">
                <asp:Label ID="lblBanco" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Height="6px" Text="Banco" Width="4px"></asp:Label></td>
            <td align="left" style="height: 23px; width: 183px;">
                <asp:DropDownList ID="ddlBanco" runat="server" DataSourceID="SqlDataSource3"
                    DataTextField="DESCRIPCION" DataValueField="COD_BANCO" Font-Size="X-Small" Width="174px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvBanco" runat="server" ErrorMessage="*" ControlToValidate="ddlBanco" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
            <td align="left" style="width: 103px;">
                <asp:Label ID="lblCuenta" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Height="5px" Text="Cuenta Bancaria" Width="98px"></asp:Label></td>
            <td style="width: 169px;" align="left">
                <asp:TextBox ID="txtCuenta" runat="server" Width="120px" Font-Size="X-Small"></asp:TextBox><asp:RequiredFieldValidator ID="reqvCuenta" runat="server" ControlToValidate="txtCuenta"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
            <td align="left" style="width: 113px; height: 23px;">
                <asp:Label ID="lblTipo_cuenta" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Height="1px" Text="Tipo de Cuenta" Width="86px"></asp:Label></td>
            <td align="left">
                <asp:DropDownList ID="ddlTipocuenta" runat="server" Font-Size="X-Small">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="CORRIENTE">Corriente</asp:ListItem>
                    <asp:ListItem Value="AHORRO">Ahorro</asp:ListItem>
                    <asp:ListItem>FAL</asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvTipo_cuenta" runat="server" ControlToValidate="ddlTipocuenta"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
        </tr>

    </table>
    <table width="100%" cellspacing="0">
        <tr>
            <td colspan="6" style="height: 30px; border-bottom-style: solid; vertical-align: bottom;" align="left">
                <strong><span style="font-family: Verdana; color: #000099; font-size: 10pt;">Datos del Pago <span style="color: red; font-size: 8pt;">(Para ser llenado por el área de Impuestos)</span></span></strong></td>
        </tr>
        <tr>
            <td style="width: 122px; height: 23px;" align="left">
                <asp:Label ID="lblTipo_pago" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Tipo Pago" Width="56px" Height="7px"></asp:Label></td>
            <td align="left" style="height: 23px; width: 182px;">
                <asp:DropDownList ID="ddlTipo_pago" runat="server" Font-Size="X-Small" Width="129px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="T">Transferencia</asp:ListItem>
                    <asp:ListItem Value="U">Cheque</asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvTipo_Banco" runat="server"
                    ControlToValidate="ddlTipo_pago" ErrorMessage="*" ValidationGroup="DatosPago"
                    Width="4px"></asp:RequiredFieldValidator></td>
            <td align="left" style="height: 23px; width: 103px;">
                <asp:Label ID="lblDias_pago" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Días de Pago" Width="76px"></asp:Label></td>
            <td align="left" style="height: 23px; width: 258px;">
                <asp:TextBox ID="txtDias_pago" runat="server" Width="31px" Font-Size="X-Small"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDias_pago"
                    ErrorMessage="*" ValidationGroup="DatosPago" Width="4px"></asp:RequiredFieldValidator></td>
            <td align="left" style="height: 23px; width: 98px;">
                <asp:Label ID="lblMonetario" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Monet/no Monet" Width="100px"></asp:Label></td>
            <td align="left" style="height: 23px">
                <asp:DropDownList ID="ddlMonetario" runat="server" Font-Size="X-Small" Width="105px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="02">No Monetario</asp:ListItem>
                    <asp:ListItem Value="01">Monetario</asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="ddlMonetario" ErrorMessage="*" ValidationGroup="DatosPago"
                    Width="1px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 122px; height: 21px;" align="left">
                <asp:Label ID="lblTaquilla" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Taquilla" Width="44px"></asp:Label></td>
            <td style="width: 182px; height: 21px;" align="left">
                <asp:DropDownList ID="ddlTaquilla" runat="server" DataSourceID="SqlDataSource4"
                    DataTextField="CODE" DataValueField="CODE" Font-Size="X-Small" Width="129px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="ddlTaquilla" ErrorMessage="*" ValidationGroup="DatosPago"
                    Width="4px"></asp:RequiredFieldValidator></td>
            <td align="left" style="height: 21px; width: 103px;">
                <asp:Label ID="lblRetISLR" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Retención ISLR" Width="92px"></asp:Label></td>
            <td align="left" style="height: 21px; width: 258px;">
                <asp:DropDownList ID="ddlRetencionISLR" runat="server" Width="245px" Font-Size="X-Small" AppendDataBoundItems="True" DataSourceID="SDSIslr" DataTextField="NAME" DataValueField="CODE">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ControlToValidate="ddlRetencionISLR" ErrorMessage="*" ValidationGroup="DatosPago"
                    Width="4px"></asp:RequiredFieldValidator></td>
            <td align="left" style="height: 21px; width: 98px;">
                <asp:Label ID="lblNat_jur" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Tipo Persona" Width="76px"></asp:Label></td>
            <td align="left" style="height: 21px">
                <asp:DropDownList ID="ddlTipopersona" runat="server" DataSourceID="SqlDataSource5"
                    DataTextField="NAME" DataValueField="CODE" Font-Size="X-Small" Width="105px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="ddlTipopersona" ErrorMessage="*" ValidationGroup="DatosPago"
                    Width="4px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 122px; height: 21px;" align="left">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Tipo Proveedor" Width="90px"></asp:Label></td>
            <td align="left" colspan="2" style="height: 21px">
                <asp:DropDownList ID="ddlGP" runat="server" Font-Size="X-Small" Width="239px" AppendDataBoundItems="True" DataSourceID="SqlDataSource6" DataTextField="NAME" DataValueField="CODE">
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ControlToValidate="ddlGP" ErrorMessage="*" ValidationGroup="DatosPago"
                    Width="4px" InitialValue="0"></asp:RequiredFieldValidator></td>
            <td align="left" style="height: 21px; width: 258px;"></td>
            <td align="left" style="height: 21px; width: 98px;"></td>
            <td align="left" style="height: 21px"></td>
        </tr>

    </table>
    <table width="100%" cellspacing="0">
        <tr>
            <td colspan="6" style="height: 30px; border-bottom-style: solid; vertical-align: bottom;" align="left">
                <strong><span style="font-family: Verdana; color: #000099; font-size: 10pt;">Observaciones Generales</span></strong></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="lblObservaciones" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Observaciones" Width="86px"></asp:Label></td>
            <td colspan="5" align="left">
                <asp:TextBox ID="txtObservaciones" runat="server" Width="605px" Font-Size="X-Small" Height="33px" TextMode="MultiLine" MaxLength="150"></asp:TextBox>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="lblAprob1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Primer Aprobador" Width="108px"></asp:Label></td>
            <td align="left">
                <%-- <asp:DropDownList ID="ddlAprob1" runat="server" Font-Size="X-Small" DataSourceID="SqldsAprob1" DataTextField="NOMBRE" DataValueField="COD_USUARIO" Width="243px">
                </asp:DropDownList>--%>
                <asp:DropDownList ID="ddlAprob1" runat="server" Font-Size="X-Small"
                    DataTextField="NOMBRE" DataValueField="COD_USUARIO" Width="243px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvAprob1" runat="server" ControlToValidate="ddlAprob1"
                    ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
            <td align="left">
                <asp:Label ID="lblAprob2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Segundo Aprobador" Width="118px"></asp:Label></td>
            <td align="left">
                <%--<asp:DropDownList ID="ddlAprob2" runat="server" DataSourceID="SqldsAprob2"
                    DataTextField="NOMBRE" DataValueField="COD_USUARIO" Font-Size="X-Small" Width="229px">--%>
                <asp:DropDownList ID="ddlAprob2" runat="server"
                    DataTextField="NOMBRE" DataValueField="COD_USUARIO" Font-Size="X-Small" Width="229px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="reqvAprob2" runat="server" ControlToValidate="ddlAprob2"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>

        </tr>
        <tr>
            <td align="left" style="width: 122px;">
                <asp:Label ID="lblSolicitante" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" Text="Solicitante" Width="56px"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="txtSolicitante" runat="server" Font-Size="X-Small" ReadOnly="True"
                    Width="211px"></asp:TextBox><asp:RequiredFieldValidator ID="reqvSolicitante" runat="server" ControlToValidate="txtSolicitante"
                        ErrorMessage="*" ValidationGroup="Enviar"></asp:RequiredFieldValidator></td>
            <td align="left">
                <asp:TextBox ID="txtCod_Solicitante" runat="server" Visible="False" Width="111px" Height="12px"></asp:TextBox></td>

        </tr>
    </table>
    <table width="100%" cellspacing="0">

        <tr>
            <td colspan="6" style="height: 30px; border-bottom-style: solid; vertical-align: bottom;" align="left">
                <strong><span style="font-family: Verdana; color: #000099; font-size: 10pt;">Rechazo
                            de la Solicitud <span style="color: #ff0000; font-size: 8pt;">(Para ser llenado en caso de rechazo)</span></span></strong></td>
        </tr>
        <tr>
            <td style="width: 122px" align="left">
                <asp:Label ID="lblMotivo" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    Text="Motivo Rechazo" Width="98px"></asp:Label></td>
            <td colspan="5" align="left">
                <asp:TextBox ID="txtMotivo" runat="server" Font-Size="X-Small" Width="607px" Enabled="False" Height="33px" TextMode="MultiLine" MaxLength="150"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMotivo" ErrorMessage="*"
                    ValidationGroup="Rechazar"></asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td colspan="6" style="height: 14px;" align="center">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" Width="100px" ValidationGroup="Enviar" />
                <asp:Button ID="btnAprobar" runat="server" Text="Aprobar" Visible="False" Width="100px" />
                <asp:Button ID="btnAprobar2" runat="server" Text="Aprobación final" Visible="False" Width="122px" ValidationGroup="DatosPago" />
                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" Visible="False" Width="100px" ValidationGroup="Rechazar" /><br />
                <span style="color: #ff0000; font-size: 10pt; font-family: Verdana;">* El campo no puede quedar en blanco<br />
                </span>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="- El correo no posee un formato correcto " Font-Names="Verdana" Font-Size="10pt"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Enviar"></asp:RegularExpressionValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPagina"
                    ErrorMessage="- La página Web no posee un formato correcto" Font-Names="Verdana" Font-Size="10pt"
                    ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ValidationGroup="Enviar"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Label ID="lblError" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    <br />
    <cc1:MaskedEditExtender ID="meeRif" runat="server" Mask="999999999" MaskType="Number"
        TargetControlID="txtRif" AutoComplete="false">
    </cc1:MaskedEditExtender>
    <cc1:MaskedEditExtender ID="meeTelefono" runat="server" DisplayMoney="Left"
        Mask="999999-9999999" MaskType="Number" TargetControlID="txtTelefono" ClearMaskOnLostFocus="true" AutoComplete="false">
    </cc1:MaskedEditExtender>
    <asp:ScriptManager ID="scmIndex" runat="server">
    </asp:ScriptManager>
    <cc1:MaskedEditExtender ID="meeFax" runat="server" DisplayMoney="Left" Enabled="True"
        Mask="999999-9999999" MaskType="Number" TargetControlID="txtFax" ClearMaskOnLostFocus="true" AutoComplete="false">
    </cc1:MaskedEditExtender>
    <cc1:MaskedEditExtender ID="meeCuenta" AutoComplete="false" runat="server" Mask="99999999999999999999" MaskType="Number"
        TargetControlID="txtCuenta">
    </cc1:MaskedEditExtender>
    <cc1:MaskedEditExtender ID="meeDias" runat="server" Enabled="True" Mask="999" MaskType="Number" AutoComplete="false"
        TargetControlID="txtDias_pago">
    </cc1:MaskedEditExtender>
    &nbsp; &nbsp;&nbsp;&nbsp;
    <asp:SqlDataSource ID="SDSIslr" runat="server" ConnectionString="<%$ ConnectionStrings:SUN426ConnectionString %>"
        SelectCommand="SELECT LTRIM(RTRIM(CODE)) AS CODE, NAME + '- ' + LOOKUP AS NAME FROM dbo.SSRFANV WHERE (SUN_DB = 'PVL') AND (CATEGORY = 'T8') AND (LEN(CODE) = 4) OR (SUN_DB = 'PVL') AND (CATEGORY = 'T8') AND (CODE = 'X')" ProviderName="<%$ ConnectionStrings:SUN426ConnectionString.ProviderName %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SUN426ConnectionString %>"
        SelectCommand="SELECT DISTINCT LTRIM(RTRIM(CODE)) AS CODE FROM [SSRFCNV] WHERE ([SUN_DB] = @SUN_DB) &#13;&#10;UNION&#13;&#10;SELECT ''" ProviderName="<%$ ConnectionStrings:SUN426ConnectionString.ProviderName %>">
        <SelectParameters>
            <asp:Parameter DefaultValue="PVL" Name="SUN_DB" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SUN426ConnectionString %>"
        SelectCommand="SELECT LTRIM(RTRIM(CODE)) AS CODE, LTRIM(RTRIM(NAME)) AS NAME FROM dbo.SSRFANV WHERE (CATEGORY = @CATEGORY) AND (CODE LIKE '%' + @CODE + '%') AND (PROHB_POST <> @PROHB_POST) AND (SUN_DB = @SUN_DB) UNION SELECT '' AS Expr1, '' AS Expr2" ProviderName="<%$ ConnectionStrings:SUN426ConnectionString.ProviderName %>">
        <SelectParameters>
            <asp:Parameter DefaultValue="C1" Name="CATEGORY" Type="String" />
            <asp:Parameter DefaultValue="P" Name="CODE" Type="String" />
            <asp:Parameter DefaultValue="Y" Name="PROHB_POST" Type="String" />
            <asp:Parameter DefaultValue="PVL" Name="SUN_DB" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqldsEstado" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT [COD_ESTADO], [DESCRIPCION] FROM [ESTADO]&#13;&#10;UNION &#13;&#10;SELECT 0, ''"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqldsCiudad" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT [COD_CIUDAD], [DESCRIPCION] FROM [CIUDAD] WHERE ([COD_ESTADO] = @COD_ESTADO)&#13;&#10;UNION&#13;&#10;SELECT 0,''&#13;&#10;">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlEstado" Name="COD_ESTADO" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT LTRIM(RTRIM(DESCRIPCION)) AS DESCRIPCION, LTRIM(RTRIM(CONVERT (VARCHAR, COD_BANCO))) AS COD_BANCO FROM dbo.BANCO WHERE (ACTIVO = 1) AND (LOCAL = CASE WHEN @LOCAL = 'N' THEN 1 ELSE 0 END) UNION SELECT '' AS Expr1, '' AS Expr2">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlMoneda" Name="LOCAL" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SUN426ConnectionString %>"
        SelectCommand="SELECT LTRIM(RTRIM(CODE)) AS CODE FROM [SSRFANV] WHERE (([CATEGORY] = @CATEGORY) AND ([SUN_DB] = @SUN_DB))&#13;&#10;UNION&#13;&#10;SELECT ''" ProviderName="<%$ ConnectionStrings:SUN426ConnectionString.ProviderName %>">
        <SelectParameters>
            <asp:Parameter DefaultValue="A4" Name="CATEGORY" Type="String" />
            <asp:Parameter DefaultValue="PVL" Name="SUN_DB" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SUN426ConnectionString %>"
        SelectCommand="SELECT LTRIM(RTRIM(CODE)) AS CODE, [NAME] FROM [SSRFANV] WHERE (([SUN_DB] = @SUN_DB) AND ([CATEGORY] = @CATEGORY))&#13;&#10;UNION&#13;&#10;SELECT '',''&#13;&#10;" ProviderName="<%$ ConnectionStrings:SUN426ConnectionString.ProviderName %>">
        <SelectParameters>
            <asp:Parameter DefaultValue="PVL" Name="SUN_DB" Type="String" />
            <asp:Parameter DefaultValue="A7" Name="CATEGORY" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <%--<asp:SqlDataSource ID="SqldsAprob1" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
                    SelectCommand="SELECT COD_USUARIO, NOMBRE FROM dbo.USUARIOS WHERE (COD_PERFIL = @COD_PERFIL) AND (ACTIVO = 1) UNION SELECT '' AS COD_USUARIO, '' AS NOMBRE">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
    <%-- <asp:SqlDataSource ID="SqldsAprob1" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT @UserNTID as COD_USUARIO, @NOMBRE as NOMBRE UNION SELECT '' AS COD_USUARIO, '' AS NOMBRE">
        <SelectParameters>
            <asp:SessionParameter Name="UserNTID" SessionField="COD_USUARIO" />
            <asp:SessionParameter Name="NOMBRE" SessionField="Nombre" />
            <%--<asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Int32" />--%>
    <%--</SelectParameters>--%>
    <%--</asp:SqlDataSource>--%>
    <%--<asp:SqlDataSource ID="SqldsAprob2" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT [COD_USUARIO], [NOMBRE] FROM [USUARIOS] WHERE ([COD_PERFIL] = @COD_PERFIL) AND ACTIVO=1">
        <SelectParameters>
            <asp:Parameter DefaultValue="5" Name="COD_PERFIL" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
  <%-- <asp:SqlDataSource ID="SqldsAprob2" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT @UserNTID as COD_USUARIO, @NOMBRE as NOMBRE">
        <SelectParameters>
            <asp:SessionParameter Name="UserNTID" SessionField="COD_USUARIO" />
            <asp:SessionParameter Name="NOMBRE" SessionField="Nombre" />
           <asp:Parameter DefaultValue="5" Name="COD_PERFIL" Type="Int32" />
     </SelectParameters>
    </asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="SDSPais" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
        SelectCommand="SELECT * FROM [PAIS] &#13;&#10;UNION&#13;&#10;SELECT '',''&#13;&#10;ORDER BY [NOMBRE_PAIS]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SUN426ConnectionString %>"
        SelectCommand="SELECT LTRIM(RTRIM(CODE)) AS CODE, RTRIM(LOOKUP) + ' - ' + NAME AS NAME FROM dbo.SSRFANV WHERE (SUN_DB = 'PVL') AND (CATEGORY = 'A8') AND (ISNUMERIC(LTRIM(RTRIM(CODE))) = 1) UNION SELECT 0 AS CODE, '' AS NAME" ProviderName="<%$ ConnectionStrings:SUN426ConnectionString.ProviderName %>"></asp:SqlDataSource>

</asp:Content>

