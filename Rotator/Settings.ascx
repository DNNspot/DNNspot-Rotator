<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="DNNspot.Rotator.Settings" %>
<table cellpadding="5" cellspacing="5" width="100%">
    <tr>
        <td>
            <span class="SubHead">Template:</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlTemplates" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Transition effect:</span>
        </td>
        <td>
            <asp:CheckBoxList ID="ddlTransitionEffect" RepeatColumns="2" runat="server">
                <asp:ListItem Text="None" Value="none"></asp:ListItem>
                <asp:ListItem Text="Blind X" Value="blindX"></asp:ListItem>
                <asp:ListItem Text="Blind Y" Value="blindY"></asp:ListItem>
                <asp:ListItem Text="Blind Z" Value="blindZ"></asp:ListItem>
                <asp:ListItem Text="Cover" Value="cover"></asp:ListItem>
                <asp:ListItem Text="Curtain X" Value="curtainX"></asp:ListItem>
                <asp:ListItem Text="Curtain Y" Value="curtainY"></asp:ListItem>
                <asp:ListItem Text="Fade" Value="fade"></asp:ListItem>
                <asp:ListItem Text="Fade Zoom" Value="fadeZoom"></asp:ListItem>
                <asp:ListItem Text="Grow X" Value="growX"></asp:ListItem>
                <asp:ListItem Text="Grow Y" Value="growY"></asp:ListItem>
                <asp:ListItem Text="Scroll Up" Value="scrollUp"></asp:ListItem>
                <asp:ListItem Text="Scroll Down" Value="scrollDown"></asp:ListItem>
                <asp:ListItem Text="Scroll Left" Value="scrollLeft"></asp:ListItem>
                <asp:ListItem Text="scroll Right" Value="scrollRight"></asp:ListItem>
                <asp:ListItem Text="Scroll Horizontally" Value="scrollHorz"></asp:ListItem>
                <asp:ListItem Text="Scroll Vertically" Value="scrollVert"></asp:ListItem>
                <asp:ListItem Text="Shuffle" Value="shuffle"></asp:ListItem>
                <asp:ListItem Text="Slide X" Value="slideX"></asp:ListItem>
                <asp:ListItem Text="Slide Y" Value="slideY"></asp:ListItem>
                <asp:ListItem Text="Toss" Value="toss"></asp:ListItem>
                <asp:ListItem Text="Turn Up" Value="turnUp"></asp:ListItem>
                <asp:ListItem Text="Turn Down" Value="turnDown"></asp:ListItem>
                <asp:ListItem Text="Turn Left" Value="turnLeft"></asp:ListItem>
                <asp:ListItem Text="Turn Right" Value="turnRight"></asp:ListItem>
                <asp:ListItem Text="Uncover" Value="uncover"></asp:ListItem>
                <asp:ListItem Text="Wipe" Value="wipe"></asp:ListItem>
                <asp:ListItem Text="Zoom" Value="zoom"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Transition in style:</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlEaseInEffect" runat="server">
                <asp:ListItem Text="Default" Value="def"></asp:ListItem>
                <asp:ListItem Text="Swing" Value="swing"></asp:ListItem>
                <asp:ListItem Text="Ease in quadratic" Value="easeInQuad"></asp:ListItem>
                <asp:ListItem Text="Ease in & out quadratic" Value="easeInOutQuad"></asp:ListItem>
                <asp:ListItem Text="Ease in cubic" Value="easeInCubic"></asp:ListItem>
                <asp:ListItem Text="Ease in & out cubic" Value="easeInOutCubic"></asp:ListItem>
                <asp:ListItem Text="Ease in quartic" Value="easeInQuart"></asp:ListItem>
                <asp:ListItem Text="Ease in & out quartic" Value="easeInOutQuart"></asp:ListItem>
                <asp:ListItem Text="Ease in & quintic" Value="easeInQuint"></asp:ListItem>
                <asp:ListItem Text="Ease out quintic" Value="easeOutQuint"></asp:ListItem>
                <asp:ListItem Text="Ease in & out quintic" Value="easeInOutQuint"></asp:ListItem>
                <asp:ListItem Text="Ease in sine" Value="easeInSine"></asp:ListItem>
                <asp:ListItem Text="Ease out sine" Value="easeOutSine"></asp:ListItem>
                <asp:ListItem Text="Ease in & out sine" Value="easeInOutSine"></asp:ListItem>
                <asp:ListItem Text="Ease in exponential" Value="easeInExpo"></asp:ListItem>
                <asp:ListItem Text="Ease out exponential" Value="easeOutExpo"></asp:ListItem>
                <asp:ListItem Text="Ease in & out exponential" Value="easeInOutExpo"></asp:ListItem>
                <asp:ListItem Text="Ease in circular" Value="easeInCirc"></asp:ListItem>
                <asp:ListItem Text="Ease out circular" Value="easeOutCirc"></asp:ListItem>
                <asp:ListItem Text="Ease in & out circular" Value="easeInOutCirc"></asp:ListItem>
                <asp:ListItem Text="Ease in elastic" Value="easeInElastic"></asp:ListItem>
                <asp:ListItem Text="Ease out elastic" Value="easeOutElastic"></asp:ListItem>
                <asp:ListItem Text="Ease in out elastic" Value="easeInOutElastic"></asp:ListItem>
                <asp:ListItem Text="Ease in back" Value="easeInBack"></asp:ListItem>
                <asp:ListItem Text="Ease out back" Value="easeOutBack"></asp:ListItem>
                <asp:ListItem Text="Ease in & out back" Value="easeInOutBack"></asp:ListItem>
                <asp:ListItem Text="Ease in bounce" Value="easeInBounce"></asp:ListItem>
                <asp:ListItem Text="Ease out bounce" Value="easeOutBounce"></asp:ListItem>
                <asp:ListItem Text="Ease in & out bounce" Value="easeInOutBounce"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Transition out style:</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlEaseOutEffect" runat="server">
                <asp:ListItem Text="Default" Value="def"></asp:ListItem>
                <asp:ListItem Text="Swing" Value="swing"></asp:ListItem>
                <asp:ListItem Text="Ease in quadratic" Value="easeInQuad"></asp:ListItem>
                <asp:ListItem Text="Ease in & out quadratic" Value="easeInOutQuad"></asp:ListItem>
                <asp:ListItem Text="Ease in cubic" Value="easeInCubic"></asp:ListItem>
                <asp:ListItem Text="Ease in & out cubic" Value="easeInOutCubic"></asp:ListItem>
                <asp:ListItem Text="Ease in quartic" Value="easeInQuart"></asp:ListItem>
                <asp:ListItem Text="Ease in & out quartic" Value="easeInOutQuart"></asp:ListItem>
                <asp:ListItem Text="Ease in & quintic" Value="easeInQuint"></asp:ListItem>
                <asp:ListItem Text="Ease out quintic" Value="easeOutQuint"></asp:ListItem>
                <asp:ListItem Text="Ease in & out quintic" Value="easeInOutQuint"></asp:ListItem>
                <asp:ListItem Text="Ease in sine" Value="easeInSine"></asp:ListItem>
                <asp:ListItem Text="Ease out sine" Value="easeOutSine"></asp:ListItem>
                <asp:ListItem Text="Ease in & out sine" Value="easeInOutSine"></asp:ListItem>
                <asp:ListItem Text="Ease in exponential" Value="easeInExpo"></asp:ListItem>
                <asp:ListItem Text="Ease out exponential" Value="easeOutExpo"></asp:ListItem>
                <asp:ListItem Text="Ease in & out exponential" Value="easeInOutExpo"></asp:ListItem>
                <asp:ListItem Text="Ease in circular" Value="easeInCirc"></asp:ListItem>
                <asp:ListItem Text="Ease out circular" Value="easeOutCirc"></asp:ListItem>
                <asp:ListItem Text="Ease in & out circular" Value="easeInOutCirc"></asp:ListItem>
                <asp:ListItem Text="Ease in elastic" Value="easeInElastic"></asp:ListItem>
                <asp:ListItem Text="Ease out elastic" Value="easeOutElastic"></asp:ListItem>
                <asp:ListItem Text="Ease in out elastic" Value="easeInOutElastic"></asp:ListItem>
                <asp:ListItem Text="Ease in back" Value="easeInBack"></asp:ListItem>
                <asp:ListItem Text="Ease out back" Value="easeOutBack"></asp:ListItem>
                <asp:ListItem Text="Ease in & out back" Value="easeInOutBack"></asp:ListItem>
                <asp:ListItem Text="Ease in bounce" Value="easeInBounce"></asp:ListItem>
                <asp:ListItem Text="Ease out bounce" Value="easeOutBounce"></asp:ListItem>
                <asp:ListItem Text="Ease in & out bounce" Value="easeInOutBounce"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Transition in speed:</span>
        </td>
        <td>
            <asp:TextBox ID="txtSpeedIn" runat="server" Columns="5"></asp:TextBox>
            milliseconds*
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Transition out speed:</span>
        </td>
        <td>
            <asp:TextBox ID="txtSpeedOut" runat="server" Columns="5"></asp:TextBox>
            milliseconds*
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Display each slide for:</span>
        </td>
        <td>
            <asp:TextBox ID="txtTimeout" runat="server" Columns="5"></asp:TextBox>
            milliseconds*
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Change first slide after:</span>
        </td>
        <td>
            <asp:TextBox ID="txtDelay" runat="server" Columns="5"></asp:TextBox>
            milliseconds*
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <sup>*1 second = 1000 milliseconds</sup>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Height:</span>
        </td>
        <td>
            <asp:TextBox ID="txtHeight" runat="server" Columns="5"></asp:TextBox>pixels
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Pause on hover:</span>
        </td>
        <td>
            <asp:CheckBox ID="chkPause" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Randomize transitions:</span>
        </td>
        <td>
            <asp:CheckBox ID="chkRandomTransitions" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Randomize slide order:</span>
        </td>
        <td>
            <asp:CheckBox ID="chkRandom" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Disable simultaneous transitions:</span>
        </td>
        <td>
            <asp:CheckBox ID="chkSyncOff" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Start on slide number:</span>
        </td>
        <td>
            <asp:TextBox ID="txtSlideStart" Columns="5" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Autostop:</span>
        </td>
        <td>
            <asp:CheckBox ID="chkLoop" runat="server" />
            <span style="font-size:11px;">(Cycles through once, unless overwritten below)</span>
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Number of slides to show:</span>
        </td>
        <td>
            <asp:TextBox ID="txtNumberOfTransitions" Columns="5" runat="server" />
            <span style="font-size:11px;">(used with the Autostop feature)</span>
        </td>
    </tr>
    <tr>
        <td>
            <span class="SubHead">Do not include jQuery:</span>
        </td>
        <td>
            <asp:CheckBox ID="chkNoJQuery" runat="server" />
        </td>
    </tr>
</table>
