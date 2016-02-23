<%@ Page Language="C#"  MasterPageFile="~/prove.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"  Inherits="Consultar_proveedor" Title="Consulta de Proveedores" Codebehind="Consultar_proveedor.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

   

    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <div style="text-align: center">
        <table width="100%" style="font-size: 8pt; font-family: Verdana; text-align: left;">
            <tr>
                <td colspan="2" align="center" style="background-color: #e0e0e0">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                        ForeColor="Black" Text="Consulta" Width="54px"></asp:Label></td>
              
            </tr>
            <tr>
                <td style="width: 129px; font-weight: bold;">
                    Rif:</td>
                <td style="width: 669px">
                    <asp:TextBox ID="txtRif" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Width="99px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 129px; font-weight: bold; height: 22px;">
                    Razón Social:</td>
                <td style="width: 669px">
                    <asp:TextBox ID="txtRazon" runat="server" Width="269px" Font-Names="Verdana" Font-Size="X-Small"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 129px; font-weight: bold;">
                    Tipo de Servicio:</td>
                <td style="width: 669px">
                    <asp:DropDownList ID="ddlTipoServicio" runat="server" DataSourceID="SISAPSqlDataSource"
                        DataTextField="NAME" DataValueField="CODE" Width="276px" Font-Names="Verdana" Font-Size="X-Small">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 129px; font-weight: bold;">
                </td>
                <td style="width: 669px"></td>
            </tr>
            <tr>
                <td style="width: 129px; font-weight: bold;">
                </td>
                <td style="width: 669px">
                    <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/images/Search.png" ToolTip="Iniciar busqueda" /></tr>
            <tr>
                <td style="width: 129px; font-weight: bold;">
                </td>
                <td style="width: 669px">
                    </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" DataKeyNames="COD_PROCESO"
            DataSourceID="SqlDataSource1" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333"
            GridLines="None" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/Select.png" />
                <asp:BoundField DataField="COD_PROCESO" HeaderText="COD_PROCESO" InsertVisible="False"
                    ReadOnly="True" SortExpression="COD_PROCESO" Visible="False" />
                <asp:BoundField DataField="RIF" HeaderText="RIF" SortExpression="RIF" />
                <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Raz&#243;n Social" SortExpression="RAZON_SOCIAL" />
                <asp:BoundField DataField="TIPO_SERVICIO" HeaderText="Tipo de Servicio" SortExpression="TIPO_SERVICIO" />
                <asp:BoundField DataField="FECHA_SOLICITUD" HeaderText="Fecha de la Solicitud" SortExpression="FECHA_SOLICITUD" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle Font-Bold="True" ForeColor="Black" Font-Strikeout="False" Font-Underline="True" />
            <PagerStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <EmptyDataTemplate>
                No existen registros para los datos seleccionados.
            </EmptyDataTemplate>
            <EmptyDataRowStyle Font-Bold="True" Font-Names="Verdana" ForeColor="Red" Font-Size="Medium" />
        </asp:GridView>
        <table style="width: 100%; font-size: 9pt; font-family: Verdana;">
            <tr>
                <td style="height: 15px;">
                </td>
            </tr>
        </table>
        <asp:DetailsView ID="DetailsView1" runat="server" CellPadding="4" DataSourceID="SqlDataSource2" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateRows="False" HeaderText="Datos del Proveedor" DataKeyNames="COD_PROCESO">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#507CD1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <RowStyle BackColor="#E0E0E0" HorizontalAlign="Left" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <FieldHeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderWidth="1px" Width="190px" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Fields>
                <asp:BoundField DataField="COD_PROCESO" HeaderText="Nro. Solicitud" InsertVisible="False"
                    SortExpression="COD_PROCESO" />
                <asp:BoundField DataField="ACCNT_CODE" HeaderText="C&#243;digo SUN" SortExpression="ACCNT_CODE" />
                <asp:BoundField DataField="RIF" HeaderText="RIF" SortExpression="RIF" />
                <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Raz&#243;n Social" SortExpression="RAZON_SOCIAL" />
                <asp:BoundField DataField="DIRECCION" HeaderText="Direcci&#243;n" SortExpression="DIRECCION" />
                <asp:BoundField DataField="CIUDAD" HeaderText="Ciudad" SortExpression="CIUDAD" />
                <asp:BoundField DataField="ESTADO" HeaderText="Estado" SortExpression="ESTADO" />
                <asp:BoundField DataField="COD_POSTAL" HeaderText="C&#243;digo Postal" SortExpression="COD_POSTAL" />
                <asp:BoundField DataField="TELEFONO" HeaderText="Tel&#233;fono" SortExpression="TELEFONO" />
                <asp:BoundField DataField="FAX" HeaderText="Fax" SortExpression="FAX" />
                <asp:BoundField DataField="CONTACTO" HeaderText="Contacto" SortExpression="CONTACTO" />
                <asp:BoundField DataField="E_MAIL" HeaderText="e-mail" SortExpression="E_MAIL" />
                <asp:BoundField DataField="WEB_PAGE" HeaderText="P&#225;gina Web" SortExpression="WEB_PAGE" />
                <asp:BoundField DataField="TIPO_SERVICIO" HeaderText="Actividad Econ&#243;mica Principal"
                    SortExpression="TIPO_SERVICIO" />
                <asp:BoundField DataField="TIPO_SERVICIO2" HeaderText="Actividad Econ&#243;mica Secundaria"
                    SortExpression="TIPO_SERVICIO2" />
                <asp:BoundField DataField="DESCRIPCION" HeaderText="Banco" SortExpression="DESCRIPCION" />
                <asp:BoundField DataField="CUENTA_BANCO" HeaderText="Nro. de Cuenta" SortExpression="CUENTA_BANCO" />
                <asp:BoundField DataField="TIPO_CTA_BANCO" HeaderText="Tipo de Cuenta" SortExpression="TIPO_CTA_BANCO" />
                <asp:BoundField DataField="STATUS" HeaderText="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <input id="Button1" onclick="window.open('Reporte/ReporteSolicitud.aspx','window','top=0,left=0,menubar=1,scrollbars=1,location=0,resizable=1,status=1,toolbar=0'); " style="font-weight: bold; font-size: 10pt; width: 125px; font-family: calibri;
                            height: 22px" type="button" value="Ver planilla" />&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
        </div>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
            SelectCommand="SELECT 
                                A.COD_PROCESO, 
                                A.RIF, A.ACCNT_CODE, 
                                A.LOOKUP, 
                                A.RAZON_SOCIAL, 
                                A.ACCNT_TYPE, 
                                A.BALANCE_OPN, 
                                A.CONV_CNTRL, 
                                A.CONV_CODE, 
                                A.ENTER_ANAL, 
                                A.PRIORITY, 
                                A.PAYMENT_DAY, 
                                A.MONETARIO, 
                                A.CONVER, 
                                A.TAQUILLA, 
                                A.TASA_IVA, 
                                A.RET_PEND, 
                                A.NAT_JUR, 
                                A.TIPO_CUENTA, 
                                A.DIRECCION, 
                                A.TELEFONO, 
                                A.FAX, 
                                A.CONTACTO, 
                                A.E_MAIL, 
                                A.WEB_PAGE, 
                                E.NAME AS TIPO_SERVICIO, 
                                F.NAME AS TIPO_SERVICIO2, 
                                A.OBJETO_RETEN, 
                                A.CUENTA_BANCO, 
                                A.TIPO_CTA_BANCO, 
                                A.COD_CIUDAD, 
                                A.COD_BANCO, 
                                A.COD_ESTATUS, 
                                A.OBSERVACIONES, 
                                A.COD_APROB1, 
                                A.COD_APROB2, 
                                A.COD_SOLICITANTE, 
                                A.MOTIVO_RECHAZO, 
                                CONVERT (SMALLDATETIME, A.FECHA_SOLICITUD, 106) AS FECHA_SOLICITUD, 
                                A.FECHA_APROB1, 
                                A.FECHA_APROB2, 
                                A.FECHA_RECHAZO, 
                                A.FECHA_CREACION, 
                                B.DESCRIPCION AS CIUDAD, 
                                C.DESCRIPCION AS ESTADO, 
                                D.DESCRIPCION AS STATUS, 
                                G.DESCRIPCION, 
                                LTRIM(RTRIM(A.COD_POSTAL)) AS COD_POSTAL 
                            FROM dbo.PROVEEDOR AS A 
                            INNER JOIN dbo.CIUDAD AS B ON A.COD_CIUDAD = B.COD_CIUDAD 
                            INNER JOIN dbo.ESTADO AS C ON B.COD_ESTADO = C.COD_ESTADO 
                            INNER JOIN dbo.ESTATUS AS D ON D.COD_ESTATUS = A.COD_ESTATUS 
                            INNER JOIN SISAP.SUNDB433_VE_P.dbo.SSRFANV AS E ON E.CODE = A.TIPO_SERVICIO 
                            COLLATE Latin1_General_Bin AND E.SUN_DB = 'PVL' AND E.CATEGORY = 'C1' 
                            INNER JOIN SISAP.SUNDB433_VE_P.dbo.SSRFANV AS F ON F.CODE = A.TIPO_SERVICIO2 
                            COLLATE Latin1_General_Bin AND F.SUN_DB = 'PVL' AND F.CATEGORY = 'C1' 
                            INNER JOIN dbo.BANCO AS G ON A.COD_BANCO = G.COD_BANCO WHERE (A.COD_PROCESO = @COD_PROCESO)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="COD_PROCESO" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
            SelectCommand="
                            SELECT 
                                P.COD_PROCESO, 
                                P.RIF, 
                                P.RAZON_SOCIAL, 
                                C.NAME AS TIPO_SERVICIO, 
                                SUBSTRING(CONVERT (VARCHAR, CONVERT (SMALLDATETIME, P.FECHA_SOLICITUD, 106)), 1, 11) AS FECHA_SOLICITUD 
                            FROM dbo.PROVEEDOR AS P 
                            INNER JOIN SISAP.SUNDB433_VE_P.dbo.SSRFANV AS C ON C.CODE = P.TIPO_SERVICIO COLLATE Latin1_General_Bin AND C.SUN_DB = 'PVL' AND C.CATEGORY = 'C1' 
                            WHERE (P.RAZON_SOCIAL LIKE '%' + @RAZON_SOCIAL + '%') OR (P.RIF LIKE '%' + @RIF + '%') OR (P.TIPO_SERVICIO =  @TIPO_SERVICIO) " CancelSelectOnNullParameter="False" OnSelecting="SqlDataSource1_Selecting">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtRazon" DefaultValue="" Name="RAZON_SOCIAL" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="ddlTipoServicio" Name="TIPO_SERVICIO" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="txtRif" Name="RIF" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SISAPSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SUN426ConnectionString %>"
            SelectCommand="
                            SELECT 
                                LTRIM(RTRIM(CODE)) AS CODE, 
                                LTRIM(RTRIM(NAME)) AS NAME 
                            FROM dbo.SSRFANV 
                            WHERE (SUN_DB = @SUN_DB) AND 
                                    (CATEGORY = @CATEGORY) AND 
                                    (CODE LIKE 'P%') 
                            UNION 
                                SELECT '' AS Expr1, '' AS Expr2">
            <SelectParameters>
                <asp:Parameter DefaultValue="PVL" Name="SUN_DB" Type="String" />
                <asp:Parameter DefaultValue="C1" Name="CATEGORY" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;&nbsp;
    </asp:Content>

