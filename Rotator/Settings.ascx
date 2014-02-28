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
            <asp:DropDownList ID="ddlTransitionEffect" RepeatColumns="2" runat="server">
                <%--DEFAULT TRANSITIONS--%>
                <asp:ListItem Text="None" Value="none"></asp:ListItem>
                <asp:ListItem Text="Fade" Value="fade"></asp:ListItem>
                <asp:ListItem Text="Fadeout" Value="fadeout"></asp:ListItem>
                <asp:ListItem Text="Scroll Horizontally" Value="scrollHorz"></asp:ListItem>
                <%--PLUGIN BASED TRANSITIONS--%>
                <asp:ListItem Text="Carousel" Value="carousel"></asp:ListItem>
                <asp:ListItem Text="Flip" Value="flipHorz"></asp:ListItem>
                <asp:ListItem Text="Scroll Vertically" Value="scrollVert"></asp:ListItem>
                <asp:ListItem Text="Shuffle" Value="shuffle"></asp:ListItem>
                <asp:ListItem Text="Tile" Value="tileSlide"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr class="visibleCarouselSlides">
        <td>
            <span class="SubHead">Number of visible carousel slides:</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlVisibleCarouselSlides" RepeatColumns="2" runat="server">
            </asp:DropDownList>
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
            <span class="SubHead">Transition Speed:</span>
        </td>
        <td>
            <asp:TextBox ID="txtSpeed" runat="server" Columns="5"></asp:TextBox>
            milliseconds*
        </td>
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
            <td valign="top">
                <span class="SubHead">Change first slide after:</span>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtDelay" runat="server" Columns="5"></asp:TextBox>
                milliseconds*
                <br />
                The number of milliseconds to add onto, or substract from "Display each slide for",
                to determine the time before the first slide transition occurs.
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
                <span class="SubHead">Auto-Height:</span>
            </td>
            <td>
                <asp:TextBox ID="txtHeight" runat="server" Columns="5"></asp:TextBox>
                <a class="moreInfoLink" href="javascript:void(0);">More Info...</a>
                <div class="moreInfo" style="display:none;">
                    <p>
                        This option determines whether or not the Rotator will provide height management for
                        the slideshow which can be very useful in fluid or responsive designs. By default, the Rotator will calculate the tallest slide and use that as the height. This setting can change that.</p>
                    <p>
                        There are two ways this option can be used, aside from the blank default to automatically calculate the height:
                    </p>
                    <ul>
                        <li>Provide an integer to identify the zero-based slide index for a default slide to use as the height
                            slide </li>
                        <li>Use a ratio string which identifies the width:height aspect ratio for
                            the container </li>
                    </ul>
                    <p>
                        To force the slideshow container to a specific aspect ratio, for example to hold
                        a set of images that are 600x400, use a ratio string like this:
                    </p>
                    <pre>data-cycle-auto-height="600:400"</pre>
                    <p>
                        To disable height management, set this option's value to <code>-1</code> or <code>false</code>.
                    </p>
                    <p>
                       Source: <a href="http://jquery.malsup.com/cycle2/api/" target="_blank">http://jquery.malsup.com/cycle2/api/</a>
                    </p>
                </div>
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
                <span class="SubHead">Loop:</span>
            </td>
            <td>
                <asp:CheckBox ID="chkLoop" runat="server" />
                <span style="font-size: 11px;">(Cycles through once, unless overwritten below)</span>
            </td>
        </tr>
        <%--    <tr>
        <td>
            <span class="SubHead">Number of slides to show:</span>
        </td>
        <td>
            <asp:TextBox ID="txtNumberOfTransitions" Columns="5" runat="server" />
            <span style="font-size:11px;">(used with the Autostop feature)</span>
        </td>
    </tr>--%>
</table>
<script type="text/javascript">
    jQuery(function () {
        jQuery("#<%= ddlTransitionEffect.ClientID %>").change(function () {
            if (jQuery(this).val() == "carousel") {
                jQuery(".visibleCarouselSlides").show();
            } else {
                jQuery(".visibleCarouselSlides").hide();
            }
        });

        jQuery("#<%= ddlTransitionEffect.ClientID %>").trigger("change");

        jQuery(".moreInfoLink").click(function () {
            jQuery(this).next(".moreInfo").toggle();
        });
    });
</script>
