<%@ Page Language="C#" MasterPageFile="~/prove.master" AutoEventWireup="true" Inherits="Rechazados" Title="Solicitudes Rechazadas" Codebehind="Rechazados.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td style="background-color: #e0e0e0;" align="center">
                
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                        ForeColor="Black" Text="Solicitudes Rechazadas"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: center; height: 291px; vertical-align: top;">
                <asp:GridView ID="grdvProveedor" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" 
                    Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
                    Width="100%" CellSpacing="1">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="Medium" ForeColor="Red" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="URL" DataTextField="COD_PROCESO" HeaderText="Nro. Solicitud" />
                        <asp:BoundField DataField="RIF" HeaderText="Rif" SortExpression="RIF" />
                        <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Raz&#243;n Social" SortExpression="RAZON_SOCIAL" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MOTIVO_RECHAZO" HeaderText="Motivo del Rechazo" SortExpression="MOTIVO_RECHAZO" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EmptyDataTemplate>
                        Actualmente usted no posee rechazos pendientes.
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#E0E0E0" Font-Names="Verdana" Font-Size="X-Small" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
               <%-- <asp:SqlDataSource ID="SqldsAprobaciones" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
                    SelectCommand="SELECT A.COD_PROCESO, A.RIF, A.RAZON_SOCIAL, A.MOTIVO_RECHAZO, B.NOMBRE, 'Index.aspx?cod_Proceso=' + CONVERT (VARCHAR, A.COD_PROCESO) AS URL, CONVERT (DATETIME, A.FECHA_RECHAZO, 103) AS FECHA_RECHAZO FROM dbo.PROVEEDOR AS A INNER JOIN dbo.USUARIOS AS B ON A.COD_SOLICITANTE = B.COD_USUARIO WHERE (A.COD_ESTATUS = 4) AND (A.COD_SOLICITANTE = @USUARIO)">
                    <SelectParameters>
                        <asp:SessionParameter Name="USUARIO" SessionField="Usuario" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
            </td>
        </tr>
    </table>
</asp:Content>

