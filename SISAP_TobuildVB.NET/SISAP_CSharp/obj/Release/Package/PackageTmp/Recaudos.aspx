<%@ Page Language="C#" AutoEventWireup="true" Inherits="Recaudos" Codebehind="Recaudos.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Recaudos</title>
</head>
<body>
    <form id="form1" runat="server">
   
        <asp:Panel ID="pnlNatResid" runat="server" Font-Names="Verdana" ForeColor="#C00000"
            Width="817px" Font-Size="Small">
            <strong>Recuerde que debe entregar los recaudos físicos, dependiendo del tipo de persona
                del proveedor
            que se muestran a continuación, con el objetivo de
            lograr la aprobación de la solicitud:</strong> <br />
            &nbsp;<br />
             <strong>Persona Natural Residente:</strong> <br />
            <br />
            &nbsp;- Copia fotostática de la cedula de identidad.<br />
            &nbsp;- Copia fotostática de Registro de Información Fiscal R.I.F (actualizado).<br />
            &nbsp;- Copia del documento constitutivo de la empresa (ultimo).<br />
            &nbsp;- Original de carta bancaria con los veinte (20) dígitos de la cuenta bancaria
            ó copia de chequera membretada.<br />
            &nbsp;- En caso de ser contribuyente formal de IVA Constancia expedida por la Administración
            Tributaria SENIAT (no limitativo).<br />
            &nbsp;- En caso de ejercer alguna actividad exonerada colocar el Decreto Base legal
            donde la actividad está exonerada (no limitativo).<br />
            &nbsp;- <span lang="ES-VE">Memo justificativo de la necesidad del proveedor (indispensable)</span></asp:Panel>
        
        <asp:Panel ID="pnlNatExtr" runat="server" Width="817px" Font-Names="Verdana" ForeColor="#C00000" Font-Size="Small">
            &nbsp;<br />
             <strong>Persona Natural No Residente:</strong><br />
            <br />
            &nbsp;- Copia de ID TAX Code (Similar al RIF de Venezuela) ó identificación tributaria
            del país de residencia (Certificada por la Administración Tributaria del país donde
            reside) Indispensable.<br />
            &nbsp;- Copia de pasaporte&nbsp;<?xml namespace="" ns="urn:schemas-microsoft-com:office:powerpoint"
                prefix="p" ?><p:colorscheme colors="#ffffff,#093a80,#666666,#ffffff,#009900,#2b5ca3,#800000,#663399"></p:colorscheme>
            (indispensable).<br />
            &nbsp;- Copia de contrato de la prestación de servicio&nbsp;<p:colorscheme colors="#ffffff,#093a80,#666666,#ffffff,#009900,#2b5ca3,#800000,#663399"></p:colorscheme>
            (indispensable).<br />
            &nbsp;- <span lang="ES-VE">Dirección de e-mail (indispensable).<br />
                &nbsp;- <span lang="ES-VE">Memo justificativo de la necesidad del proveedor (indispensable)</span></span></asp:Panel>
         <asp:Panel ID="pnlJudRes" runat="server" Font-Names="Verdana" ForeColor="#C00000"
            Width="817px" Font-Size="Small">
             <br />
              <strong>Persona Jurídica Domiciliada:</strong><br />
            &nbsp;<br />
             &nbsp;- Copia fotostática de la cedula de identidad del Representante Legal de la empresa&nbsp;<?xml namespace="" ns="urn:schemas-microsoft-com:office:powerpoint"
                 prefix="p" ?><p:colorscheme colors="#ffffff,#093a80,#666666,#ffffff,#009900,#2b5ca3,#800000,#663399"></p:colorscheme>
             (indispensable).<br />
             &nbsp;- Copia fotostática de Registro de Información Fiscal R.I.F (actualizado e
             indispensable).<br />
             &nbsp;- Copia del documento constitutivo de la empresa (ultimo).<br />
             &nbsp;- Original de carta bancaria con los veinte (20) dígitos de la cuenta bancaria
             ó copia de chequera membretada&nbsp;<p:colorscheme colors="#ffffff,#093a80,#666666,#ffffff,#009900,#2b5ca3,#800000,#663399"></p:colorscheme>
             (opcional).<br />
             &nbsp;- En caso de ser contribuyente formal de IVA Constancia expedida por la Administración
             Tributaria SENIAT&nbsp;<p:colorscheme colors="#ffffff,#093a80,#666666,#ffffff,#009900,#2b5ca3,#800000,#663399"></p:colorscheme>
             (no limitativo).<br />
             &nbsp;- En caso de ser exento de la actividad Resolución donde la Administración le otorga
             la calificación de exenta&nbsp;<p:colorscheme colors="#ffffff,#093a80,#666666,#ffffff,#009900,#2b5ca3,#800000,#663399"></p:colorscheme>
             (no limitativo).<br />
             &nbsp;- <span lang="ES-VE">Memo justificativo de la necesidad del proveedor (indispensable).</span></asp:Panel><asp:Panel ID="pnlJudExtr" runat="server" Width="817px" Font-Names="Verdana" ForeColor="#C00000" Font-Size="Small">
                <br />
                 <strong>Persona Jurídica No Domiciliada:</strong><br />
                 <br />
                 &nbsp;- Copia de identificación tributaria del país de domicilio (Certificada y
                 apostillada por la Autoridad competente del país de domicilio) (Ej. ID TAX Code
                 en el caso de USA) (indispensable).&nbsp;<br />
                 &nbsp;- Dirección fiscal completa del país donde esta domiciliada la empresa <span
                     style="left: -6.6%; position: absolute; mso-special-format: bullet">•</span>
                 (indispensable).<br />
                 &nbsp;- <span lang="ES-VE">Copia del pasaporte del representante legal (indispensable)</span><br />
                 &nbsp;- Copia del contrato de la prestación del servicio (indispensable)&nbsp;<br />
                 &nbsp;- <span lang="ES-VE">Dirección de e-mail (indispensable).<br />
                     &nbsp;- <span lang="ES-VE">Memo justificativo de la necesidad del proveedor (indispensable)</span>
                     <div style="mso-margin-left-alt: 216; mso-char-wrap: 1; mso-kinsoku-overflow: 1;
                         mso-line-spacing: '100 50 0'">
                     </div>
                 </span>
             </asp:Panel>
    </form>
</body>
</html>
