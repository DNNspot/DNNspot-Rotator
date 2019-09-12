<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditSlide.ascx.cs" Inherits="DNNspot.Rotator.EditSlide" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<div class="dnnFormItem">
    Title<br />
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
        ErrorMessage="* Please enter a slide title" CssClass="error"></asp:RequiredFieldValidator>
    <br />
    <br />
    Body<br />
    <dnn:TextEditor id="txtBody" runat="server" height="550" width="100%" HtmlEncode="false">
    </dnn:TextEditor><br />
    <br />
    Pager Text (default is slide title)s<br />
    <dnn:TextEditor id="txtThumbnail" runat="server" height="550" width="100%" HtmlEncode="false">
    </dnn:TextEditor><br />
    <p>
        Visible<br />
        <asp:CheckBox ID="chkVisible" runat="server" Checked="true" /><br />
    </p>
    <div id="dnnEditExtension">
        <h2 class="dnnFormSectionHead">
            <a href="javascript:void(0);">Custom Fields</a></h2>
        <fieldset>
            <div class="customFields">
                Custom Field 1<br />
                <dnn:TextEditor id="txtCustomField1" runat="server" height="550" width="100%" HtmlEncode="false">
                </dnn:TextEditor><br />
                <br />
                Custom Field 2<br />
                <dnn:TextEditor id="txtCustomField2" runat="server" height="550" width="100%" HtmlEncode="false">
                </dnn:TextEditor><br />
                <br />
                Custom Field 3<br />
                <dnn:TextEditor id="txtCustomField3" runat="server" height="550" width="100%" HtmlEncode="false">
                </dnn:TextEditor><br />
                <br />
            </div>
        </fieldset>
        <h2 class="dnnFormSectionHead">
            <a href="javascript:void(0);">View Permissions</a></h2>
        <fieldset>
            <table>
                <thead>
                    <tr>
                        <th>
                            Role
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="litViewPermissions" runat="server"></asp:Literal>
                </tbody>
            </table>
        </fieldset>
    </div>
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="dnnPrimaryAction"
        Text="Save"></asp:Button>
    |
    <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CausesValidation="false"
        CssClass="dnnSecondaryAction" OnClientClick="return confirm('Are you sure you want to delete this slide?');">Delete</asp:LinkButton>
    <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false"
        CssClass="dnnSecondaryAction">Cancel</asp:LinkButton>
</div>
<script type="text/javascript">
    jQuery(document).ready(function () {
        (function ($) {
            if ($.isFunction($.fn.dnnPanels)) {
                $('#dnnEditExtension').dnnPanels({
                    cookieDays: 0, // cookie state persistence time in days
                    cookieMilleseconds: 0
                });

                $('#dnnEditExtension fieldset').hide();
                $('#dnnEditExtension h2:nth-child(1) a').removeClass('dnnSectionExpanded');
            }
        })(jQuery);
    });

</script>
