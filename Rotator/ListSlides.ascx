<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSlides.ascx.cs"
    Inherits="DNNspot.Rotator.Slides" %>
<asp:Repeater ID="rptSlides" runat="server" OnItemDataBound="rptSlides_ItemDataBound">
    <HeaderTemplate>
        <table width="100%" class="TabularData" cellspacing="0">
            <thead>
                <tr>
                    <th>
                        Title
                    </th>
                    <th>
                        Visible?
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
                <asp:HiddenField ID="hidSlideId" runat="server" />
                <asp:Literal ID="litTitle" runat="server"></asp:Literal>
            </td>
            <td>
                <%# Eval("IsVisible") %>
            </td>
            <td align="right">
                <asp:ImageButton ID="btnUp" runat="server" OnCommand="btnUp_Command" />
                <asp:ImageButton ID="btnDown" runat="server" OnCommand="btnDown_Command" />
                <asp:Image ID="imgSpacer" runat="server" Visible="false" />
                <asp:ImageButton ID="btnEdit" runat="server" OnCommand="btnEdit_Command" />
                <asp:ImageButton ID="btnDelete" runat="server" OnCommand="btnDelete_Command" OnClientClick="return confirm('Are you sure you want to delete this slide?');" />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
</asp:Repeater>
