<%@ Page Language="VB" MasterPageFile="~/prove.master" AutoEventWireup="false" Inherits="SISAP_VB.Aprobar_proveedor" title="Listado de Solicitudes" Codebehind="Aprobar_proveedor.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td style="text-align: center; background-color: #e0e0e0;">
                
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                        ForeColor="Black" Text="Pendientes por Aprobación"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:GridView ID="grdvProveedor" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqldsAprobaciones"
                    Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="100%">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="URL" DataTextField="COD_PROCESO" HeaderText="Solicitud" />
                        <asp:BoundField DataField="RIF" HeaderText="Rif" SortExpression="RIF" />
                        <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Raz&#243;n Social" SortExpression="RAZON_SOCIAL" />
                        <asp:BoundField DataField="TIPO_SERVICIO" HeaderText="Actividad Principal" SortExpression="TIPO_SERVICIO" />
                        <asp:BoundField DataField="TIPO_SERVICIO2" HeaderText="Actividad Secundaria" SortExpression="TIPO_SERVICIO2" />
                        <asp:BoundField DataField="OBSERVACIONES" HeaderText="Observaciones" SortExpression="OBSERVACIONES" />
                        <asp:BoundField DataField="NOMBRE" HeaderText="Solicitante" SortExpression="NOMBRE" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#E0E0E0" Font-Names="Verdana" Font-Size="X-Small" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="Medium" ForeColor="Red" />
                    <EmptyDataTemplate>
                        Actualmente usted no posee aprobaciones pendientes.
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:SqlDataSource ID="SqldsAprobaciones" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
                    SelectCommand="leerAprobaciones" SelectCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:SISAPConnectionString.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblTipoaprob" Name="TIPO_APROB" PropertyName="Text"
                            Type="Int32" />
                        <%--<asp:SessionParameter Name="cod_usuario" SessionField="Usuario" Type="String" />--%>
                           <asp:SessionParameter Name="NOMBRE" SessionField="UserNTID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Label ID="lblTipoaprob" runat="server" Visible="False"></asp:Label></td>
        </tr>
       
    </table>
    <br />
    <br />
</asp:Content>

