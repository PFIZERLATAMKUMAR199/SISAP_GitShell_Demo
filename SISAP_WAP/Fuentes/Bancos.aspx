<%@ Page Language="VB" MasterPageFile="~/prove.master" AutoEventWireup="false" Inherits="SISAP_VB.Bancos" MaintainScrollPositionOnPostback="true"  title="Bancos" Codebehind="Bancos.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table border="0" width="100%">
            <tr>
                <td colspan="2" align="center" style="background-color: #e0e0e0">
                    
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                            ForeColor="Black" Text="Creación de Banco"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 20%">
                    <asp:Label ID="lblBanco" runat="server" Text="Nombre del Banco" Font-Names="Verdana" Font-Size="X-Small" Font-Bold="True"></asp:Label></td>
                <td style="width: 80%">
                    <asp:TextBox ID="txtBanco" runat="server" Font-Names="Verdana" Font-Size="X-Small" Width="281px" MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBanco"
                        ErrorMessage="Campo Requerido" ValidationGroup="Agregar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 20%">
                    <asp:Label ID="lblSwift" runat="server" Text="Código Swift" Font-Names="Verdana" Font-Size="X-Small" Font-Bold="True" Width="80px"></asp:Label></td>
                <td style="width: 80%">
                    <asp:TextBox ID="txtSwift" runat="server" Font-Names="Verdana" Font-Size="X-Small" Width="116px" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSwift"
                        ErrorMessage="Campo Requerido" ValidationGroup="Agregar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 20%">
                    <asp:Label ID="Label1" runat="server" Text="¿Local?" Font-Names="Verdana" Font-Size="X-Small" Font-Bold="True" Width="80px"></asp:Label></td>
                <td style="width: 80%">
                    <asp:CheckBox ID="chbLocal" runat="server" Checked="True" /></td>
            </tr>
            <tr>
                <td align="center" style="height: 18px">
                    &nbsp;</td>
                <td>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton
                        ID="ibtnAgregar" runat="server" ImageUrl="~/images/Agregar.png" ValidationGroup="Agregar" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
        <asp:GridView ID="grdvBanco" runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="COD_BANCO" DataSourceID="SqldsBanco"
            ForeColor="#333333" BorderStyle="Solid" Width="98%" BorderWidth="1px" Font-Names="Verdana" Font-Size="Small">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Verdana" Font-Size="Smaller" />
            <Columns>
                <asp:BoundField DataField="COD_BANCO" HeaderText="C&#243;digo del Banco" InsertVisible="False"
                    ReadOnly="True" SortExpression="COD_BANCO" />
                <asp:BoundField DataField="DESCRIPCION" HeaderText="Nombre del Banco" SortExpression="DESCRIPCION" />
                <asp:BoundField DataField="COD_SWIFT" HeaderText="C&#243;digo Swift" SortExpression="COD_SWIFT" />
                <asp:BoundField DataField="BRANCH" HeaderText="C&#243;digo Branch" SortExpression="BRANCH" />
                <asp:CheckBoxField DataField="LOCAL" HeaderText="&#191;Local?" SortExpression="LOCAL">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:CheckBoxField DataField="ACTIVO" HeaderText="Activo" SortExpression="ACTIVO">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/Cancelar.png" CancelText="Cancelar" 
                    DeleteImageUrl="~/images/Delete.png" EditImageUrl="~/images/Modificar.png" EditText="Actualizar" ShowEditButton="True" UpdateImageUrl="~/images/Actualizar.png"
                    UpdateText="Modificar" />
            </Columns>
            <RowStyle BackColor="#EFF3FB" Font-Names="Verdana" Font-Size="Smaller" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#E0E0E0" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Names="Verdana" Font-Size="Smaller" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Verdana" Font-Size="Smaller" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
                </td>
            </tr>
        </table>
    <br />
        <asp:SqlDataSource ID="SqldsBanco" runat="server" ConnectionString="<%$ ConnectionStrings:SISAPConnectionString %>"
            DeleteCommand="sp_EliminarBanco" DeleteCommandType="StoredProcedure" InsertCommand="crearBanco"
            InsertCommandType="StoredProcedure" SelectCommand="SELECT COD_BANCO, DESCRIPCION, COD_SWIFT, BRANCH, LOCAL, ACTIVO FROM BANCO"
             UpdateCommand="crearBanco" UpdateCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:SISAPConnectionString.ProviderName %>">
            <DeleteParameters>
                <asp:ControlParameter ControlID="grdvBanco" Name="COD_BANCO" PropertyName="SelectedValue" Type="Int32" DefaultValue="" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter DefaultValue="2" Name="Accion" Type="String" />
                <asp:ControlParameter ControlID="grdvBanco" DefaultValue="" Name="COD_BANCO" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="grdvBanco" DefaultValue="" Name="DESCRIPCION" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="grdvBanco" Name="COD_SWIFT" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="grdvBanco" Name="BRANCH" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="grdvBanco" Name="ACTIVO" PropertyName="SelectedValue" Type="Boolean" />
                <asp:ControlParameter ControlID="grdvBanco" Name="LOCAL" PropertyName="SelectedValue"  Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter DefaultValue="1" Name="Accion" Type="String" />
                <asp:Parameter DefaultValue="" Name="COD_BANCO" Type="Int32" />
                <asp:Parameter Name="DESCRIPCION" Type="String" />
                <asp:Parameter Name="COD_SWIFT" Type="String" />
                <asp:Parameter Name="BRANCH" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
</asp:Content>

