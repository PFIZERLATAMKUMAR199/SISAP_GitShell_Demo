<%@ Page Language="VB" MasterPageFile="~/prove.master" AutoEventWireup="false" Inherits="SISAP_VB.Usuarios" title="Usuarios" Codebehind="Usuarios.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" width="100%">
            <tr>
                <td colspan="2" align="center" style="background-color: #e0e0e0;">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                        ForeColor="Black" Text="Administración de Usuarios"></asp:Label></td>
            </tr>
            <tr>
                <td align=left style="width: 20%"  >
                    <asp:Label ID="lblCod_Usuario" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Text="Usuario de Red" Font-Bold="True"></asp:Label></td>
                <td style="width: 80%">
                    <asp:TextBox ID="txtCod_usuario" runat="server" Font-Names="Verdana" Font-Size="X-Small" MaxLength="50" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtCod_usuario" ValidationGroup="Agregar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align=left style="width: 20%" >
                    <asp:Label ID="lblNombre" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Text="Nombre del Usuario" Font-Bold="True"></asp:Label></td>
                <td style="width: 80%">
                    <asp:TextBox ID="txtNombre" runat="server" Font-Names="Verdana" Font-Size="X-Small" MaxLength="50" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtNombre" ValidationGroup="Agregar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align=left style="width: 20%" >
                    <asp:Label ID="lblCod_perfil" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Text="Perfil del Usuario" Font-Bold="True"></asp:Label></td>
                <td colspan="" style="width: 80%" rowspan="">
                    <asp:DropDownList ID="ddlCod_perfil" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="DESCRIPCION" DataValueField="COD_PERFIL" Font-Names="Verdana"
                        Font-Size="X-Small" Width="159px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="ddlCod_perfil" ValidationGroup="Agregar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="left" style="width: 20%">
                    <asp:Label ID="lblCorreo" runat="server" Font-Names="Verdana" Font-Size="X-Small" Text="Correo del Usuario" Font-Bold="True"></asp:Label></td>
                <td style="width: 80%">
                    <asp:TextBox ID="txtCorreo" runat="server" Font-Names="Verdana" Font-Size="X-Small" MaxLength="50" Width="155px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtCorreo" ValidationGroup="Agregar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="" align="center" rowspan="" style="height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:ImageButton
                        ID="IbtnAgregar" runat="server" ImageUrl="~/images/Agregar.png" ToolTip="Agregar Usuario" ValidationGroup="Agregar" /></td>                   
            </tr>
            <tr>
                <td colspan="" align="left" rowspan="" style="height: 19px">
                    &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="X-Small" Text="Nombre"></asp:Label></td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtbuscar" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        MaxLength="50" Width="155px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server"
                            BackColor="White" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" Height="17px"
                            Text="Buscar..." /></td>                   
            </tr>
             <tr>
                <td colspan="2" align="center">
        <asp:GridView ID="grdvUsuarios" runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="COD_USUARIO"
            DataSourceID="SqldsUsuarios" ForeColor="#333333" BorderStyle="Solid" Width="100%" Font-Names="Verdana" Font-Size="Small">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller"
                ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="COD_USUARIO" HeaderText="Usuario de Red" ReadOnly="True"
                    SortExpression="COD_USUARIO" />
                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre del Usuario" SortExpression="NOMBRE" />
                <asp:TemplateField HeaderText="Perfil del Usuario">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" SelectedValue='<%# Bind("COD_PERFIL") %>'
                            DataTextField="DESCRIPCION" DataValueField="COD_PERFIL" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="193px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="COD_PERFIL" SortExpression="COD_PERFIL" ReadOnly="True" Visible="False" >
                    <ItemStyle Width="0px" />
                </asp:BoundField>
                <asp:BoundField DataField="CORREO" HeaderText="E-Mail" SortExpression="CORREO" />
                <asp:CheckBoxField DataField="ACTIVO" HeaderText="Activo" SortExpression="ACTIVO">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/Cancelar.png" CancelText="Cancelar"
                    DeleteImageUrl="~/images/Delete.png" DeleteText="Eliminar" EditImageUrl="~/images/Modificar.png"
                    EditText="Modificar" ShowEditButton="True" UpdateImageUrl="~/images/Actualizar.png"
                    UpdateText="Actualizar" />
            </Columns>
            <RowStyle BackColor="#EFF3FB" Font-Names="Verdana" Font-Size="Smaller" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#E0E0E0" Font-Names="Verdana" Font-Size="X-Small" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#507CD1" Font-Names="Verdana" Font-Size="Smaller" ForeColor="White"
                HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller"
                ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
                    </td>
            </tr>
        </table>
    <asp:TextBox ID="txtCodPerfil" runat="server" Visible="False" Width="19px"></asp:TextBox><br />
        <asp:SqlDataSource ID="SqldsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
            DeleteCommand="sp_EliminarUsuario" DeleteCommandType="StoredProcedure" InsertCommand="crearUsuarios"
            InsertCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:SISAPConnectionString.ProviderName %>"
            SelectCommand="SELECT A.COD_USUARIO, A.NOMBRE, A.COD_PERFIL, B.DESCRIPCION, A.CORREO, A.ACTIVO FROM dbo.USUARIOS AS A INNER JOIN dbo.PERFIL AS B ON A.COD_PERFIL = B.COD_PERFIL WHERE (A.NOMBRE LIKE '%' + ISNULL(@nombre, '') + '%')"
            UpdateCommand="crearUsuarios" UpdateCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:ControlParameter ControlID="grdvUsuarios" DefaultValue="" Name="COD_USUARIO"
                    PropertyName="SelectedValue" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter DefaultValue="2" Name="Accion" Type="String" />
                <asp:ControlParameter ControlID="grdvUsuarios" DefaultValue="" Name="COD_USUARIO"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="grdvUsuarios" Name="NOMBRE" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="txtCodPerfil" DefaultValue="" Name="COD_PERFIL"
                    PropertyName="Text" />
                <asp:Parameter Name="CORREO" Type="String" DefaultValue="" />
                <asp:ControlParameter ControlID="grdvUsuarios" Name="ACTIVO" PropertyName="SelectedValue"
                    Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter DefaultValue="1" Name="Accion" Type="String" />
                <asp:Parameter Name="COD_USUARIO" Type="String" />
                <asp:Parameter Name="NOMBRE" Type="String" />
                <asp:Parameter Name="COD_PERFIL" Type="Int32" />
                <asp:Parameter Name="CORREO" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtbuscar" Name="nombre" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
                        SelectCommand="SELECT COD_PERFIL, DESCRIPCION FROM dbo.PERFIL UNION SELECT 0 AS COD_PERFIL, '' AS DESCRIPCION ORDER BY DESCRIPCION">
                    </asp:SqlDataSource>
</asp:Content>

