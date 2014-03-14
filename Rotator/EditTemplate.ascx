<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditTemplate.ascx.cs"
    Inherits="DNNspot.Rotator.EditTemplate" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<div class="dnnFormItem">
    Title<br />
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
        ErrorMessage="*" CssClass="error"></asp:RequiredFieldValidator>
    <br />
    <br />
    <h3>
        Body</h3>
    <dnn:TextEditor id="txtBody" runat="server" height="350" width="600" HtmlEncode="false">
    </dnn:TextEditor><br />
    
    <h3>
        Slide Template</h3>
    <dnn:TextEditor id="txtSlideTemplate" runat="server" height="350" width="600" HtmlEncode="false">
    </dnn:TextEditor><br />
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="dnnPrimaryAction"
        Text="Save"></asp:Button>
    |
    <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CausesValidation="false"
        CssClass="dnnSecondaryAction" OnClientClick="return confirm('Are you sure you want to delete this template?');">Delete</asp:LinkButton>
        |
    <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false"
        CssClass="dnnSecondaryAction">Cancel</asp:LinkButton><br />
    <h3>
        Body Token Reference</h3>
    <ul>
        <li>[SLIDES] – Displays all the slides</li>
        <li>[PAGER] – List of Slide Titles that allows a user to navigate to that specific slide.</li>
        <li>[PLAY] – Plays the rotator after paused</li>
        <li>[PAUSE] – Pauses the rotator</li>
        <li>[PAUSEPLAY] – Toggles a play and pause button</li>
        <li>[NEXT] – Navigates to the next slide</li>
        <li>[PREV] – Navigates to the previous slide</li>
    </ul>
    <h3>
        Slide Template Token Reference</h3>
    <ul>
        <li>[TITLE] – Displays the title of slide</li>
        <li>[BODY] – Displays body of slide</li>
        <li>[CUSTOMFIELD1] – Displays Custom Field 1 for a slide</li>
        <li>[CUSTOMFIELD2] – Displays Custom Field 2 for a slide</li>
        <li>[CUSTOMFIELD3] – Displays Custom Field 3 for a slide</li>
    </ul>
</div>
