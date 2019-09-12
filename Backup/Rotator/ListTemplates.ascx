<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListTemplates.ascx.cs" Inherits="DNNspot.Rotator.Templates" %>

<asp:Repeater ID="rptTemplates" runat="server" OnItemDataBound="rptTemplates_ItemDataBound">
    <HeaderTemplate>
        <table width="100%" class="TabularData" cellspacing="0">
            <thead>
                <tr>
                    <th>
                        Title
                    </th>
                    <th>
                        &nbsp;
                    </th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
                <tr class="<%# (Container.ItemIndex % 2 == 0) ? "TableRowAlt" : "" %>">
                    <td>
                        <asp:HiddenField ID="hidTemplateID" runat="server" />
                        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="btnEdit" runat="server" OnCommand="btnEdit_Command" /> 
                        <asp:ImageButton ID="btnDelete" runat="server" OnCommand="btnDelete_Command"
                            OnClientClick="return confirm('Are you sure you want to delete this template?');" />
                    </td>
                </tr>
    </ItemTemplate>
    <FooterTemplate>
            </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>

<asp:Button ID="btnDefaultTemplates" runat="server" 
    text="Load Default Templates" onclick="btnDefaultTemplates_Click" />