/*
* This software is licensed under the GNU General Public License, version 2
* You may copy, distribute and modify the software as long as you track changes/dates of in source files and keep all modifications under GPL. You can distribute your application using a GPL library commercially, but you must also provide the source code.

* DNNspot Software (http://www.dnnspot.com)
* Copyright (C) 2013 Atriage Software LLC
* Authors: Kevin Southworth, Matthew Hall, Ryan Doom

* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; either version 2
* of the License, or (at your option) any later version.

* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.

* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

* Full license viewable here: http://www.gnu.org/licenses/gpl-2.0.txt
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using DotNetNuke.Common;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using DNNspot.Rotator.Common;
using DNNspot.Rotator.DataModel;

namespace DNNspot.Rotator
{
    public partial class Default : ModuleBase, IActionable
    {
        #region Members

        private string _delay;
        private string _easeInEffect;
        private string _easeOutEffect;
        private bool _hasNextButton;
        private bool _hasPager;
        private bool _hasPauseButton;
        private bool _hasPausePlayButton;
        private bool _hasPlayButton;
        private bool _hasPreviousButton;
        private string _pause;
        private string _random;
        private string _speedIn;
        private string _speedOut;
        private string _syncOff;
        private string _randomizeTransitions;
        private int? _templateId;
        private string _timeout;
        private string _transitionEffect;
        private string _loop;
        private string _numberOfTransitions;
        private string _slideStart;
        private string _height;

        List<Slide> _slides = new List<Slide>();

        #endregion

        #region Properties

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection();

                actions.Add(
                    GetNextActionID(),
                    "Edit slides",
                    ModuleActionType.AddContent,
                    "",
                    "",
                    EditUrl(ControlKeys.Slides),
                    false,
                    SecurityAccessLevel.Edit,
                    true,
                    false);

                actions.Add(
                    GetNextActionID(),
                    "Edit Templates",
                    ModuleActionType.AddContent,
                    "",
                    "",
                    EditUrl(ControlKeys.Templates),
                    false,
                    SecurityAccessLevel.Edit,
                    true,
                    false);

                return actions;
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _slides = GetAllModuleSlides();
                LoadVariables();
                GenerateOutputFromTemplate();
                GenerateJavascript();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            IncludeJS();
        }

        #endregion

        #region Functions

        private void GenerateJavascript()
        {
            var jsString = new StringBuilder();

            if (_hasPager)
            {
                jsString.Append(String.Format("function slides_{0}_pagerAnchorBuilder(idx, slide) {{ ", ModuleId));

                jsString.Append(
                    String.Format(
                        "return 'ul#slides_{0}_pager li#slides_{0}_pager_' + idx + ' a'; ",
                        ModuleId));



                jsString.Append("} ");

                jsString.Append(String.Format("function slides_{0}_updateActivePagerLink(pager, currSlide) {{ ", ModuleId));
                jsString.Append("jQuery(pager).find('li').removeClass('activeSlide').filter('li:eq('+currSlide+')').addClass('activeSlide'); ");
                jsString.Append("jQuery(pager).find('li').removeClass('prevSlide').filter('li:eq('+currSlide+')').prev().addClass('prevSlide'); ");
                jsString.Append("jQuery(pager).find('li').removeClass('nextSlide').filter('li:eq('+currSlide+')').next().addClass('nextSlide'); ");
                jsString.Append("}; ");
            }

            jsString.Append("jQuery(function() { ");
            jsString.Append(String.Format("jQuery('#slides_{0}').cycle({{", ModuleId));
            jsString.Append(String.Format("fx: {0}, ", _transitionEffect));
            jsString.Append(String.Format("speedIn: {0}, ", _speedIn));
            jsString.Append(String.Format("speedOut: {0}, ", _speedOut));
            jsString.Append(String.Format("easeIn: {0}, ", _easeInEffect));
            jsString.Append(String.Format("easeOut: {0}, ", _easeOutEffect));
            jsString.Append(String.Format("sync: {0}, ", _syncOff));
            jsString.Append(String.Format("timeout: {0}, ", _timeout));
            jsString.Append(String.Format("delay: {0}, ", _delay));
            jsString.Append(String.Format("pause: {0}, ", _pause));
            jsString.Append(String.Format("random: {0}, ", _random));
            jsString.Append(String.Format("autostop: {0}, ", _loop));
            jsString.Append(String.Format("autostopCount: {0}, ", _numberOfTransitions));
            jsString.Append(String.Format("cleartypeNoBg: {0}, ", "true"));
            jsString.Append(String.Format("startingSlide: {0}, ", _slideStart));
            jsString.Append(String.Format("randomizeEffects: {0}, ", _randomizeTransitions));
            jsString.Append(String.Format("height: {0}, ", _height));

            if (_hasNextButton)
                jsString.Append(String.Format("next: '#slides_{0}_next', ", ModuleId));

            if (_hasPreviousButton)
                jsString.Append(String.Format("prev: '#slides_{0}_prev', ", ModuleId));

            if (_hasPager)
            {
                jsString.Append(String.Format("pager: '#slides_{0}_pager', ", ModuleId));
                jsString.Append(String.Format("pagerAnchorBuilder: slides_{0}_pagerAnchorBuilder, ", ModuleId));
                jsString.Append(String.Format("updateActivePagerLink: slides_{0}_updateActivePagerLink, ", ModuleId));
            }

            jsString.Append("cleartype: 1");
            jsString.Append("}); ");

            if (_hasPager)
            {
                jsString.Append(string.Format("jQuery('#slides_{0}_pager li:first').addClass('firstSlide'); ", ModuleId));
                jsString.Append(string.Format("jQuery('#slides_{0}_pager li:last').addClass('lastSlide'); ", ModuleId));
            }

            if (_hasPauseButton)
            {
                jsString.Append(string.Format("jQuery('#slides_{0}_pause_button').click(function() {{ ", ModuleId));
                jsString.Append(string.Format("jQuery('#slides_{0}').cycle('pause'); ", ModuleId));
                jsString.Append("}); ");
            }

            if (_hasPlayButton)
            {
                jsString.Append(string.Format("jQuery('#slides_{0}_play_button').click(function() {{ ", ModuleId));
                jsString.Append(string.Format("jQuery('#slides_{0}').cycle('resume'); ", ModuleId));
                jsString.Append("}); ");
            }

            if (_hasPausePlayButton)
            {
                jsString.Append(string.Format("jQuery('#slides_{0}_pauseplay_button').click(function() {{ ", ModuleId));
                jsString.Append("if(jQuery(this).hasClass('pause')) { ");
                jsString.Append("jQuery(this).removeClass('pause').addClass('resume').text('Play'); ");
                jsString.Append(string.Format("jQuery('#slides_{0}').cycle('pause'); ", ModuleId));
                jsString.Append("} else if(jQuery(this).hasClass('resume')) { ");
                jsString.Append("jQuery(this).removeClass('resume').addClass('pause').text('Pause'); ");
                jsString.Append(string.Format("jQuery('#slides_{0}').cycle('resume'); ", ModuleId));
                jsString.Append("} ");
                jsString.Append("}); ");
            }

            jsString.Append("}); ");

            litJSOutput.Text = String.Format("<script type=\"text/javascript\">{0}</script>", jsString);
        }

        private string GenerateNext()
        {
            return String.Format("<a href='javascript:void(0);' id='slides_{0}_next'>Next</a>", ModuleId);
        }

        private void GenerateOutputFromTemplate()
        {
            var template = new Template();
            template.LoadByPrimaryKey(Convert.ToInt32(_templateId));

            litOutput.Text = Tokenize(template.Body ?? Tokens.Slides);
        }

        private string GeneratePager()
        {
            StringBuilder pager = new StringBuilder();
            int slideNumber = 1;
            string pagerText = String.Empty;

            foreach (Slide slide in _slides)
            {
                pagerText = String.IsNullOrEmpty(slide.Thumbnail) ? slide.Title : slide.Thumbnail;
                pager.AppendFormat("<li id=\"slides_{0}_pager_{1}\" class=\"pager_button\"><a href=\"#\">{2}</a></li>", ModuleId, slideNumber - 1, pagerText);
                slideNumber++;

            }
            return String.Format("<ul id='slides_{0}_pager'>{1}</ul>", ModuleId, pager);
        }

        private string GeneratePause()
        {
            var output = string.Empty;

            if (Convert.ToInt32(_timeout) > 0)
            {
                _hasPauseButton = true;
                output = string.Format("<a href=\"javascript:void(0);\" id=\"slides_{0}_pause_button\" class=\"pause_button\">Pause</a>", ModuleId);
            }

            return output;
        }

        private string GeneratePausePlay()
        {
            var output = string.Empty;

            if (Convert.ToInt32(_timeout) > 0)
            {
                _hasPausePlayButton = true;
                output = string.Format("<a href=\"javascript:void(0);\" id=\"slides_{0}_pauseplay_button\" class=\"pauseplay_button pause\">Pause</a>", ModuleId);
            }

            return output;
        }

        private string GeneratePlay()
        {
            var output = string.Empty;

            if (Convert.ToInt32(_timeout) > 0)
            {
                _hasPlayButton = true;
                output = string.Format("<a href=\"javascript:void(0);\" id=\"slides_{0}_play_button\" class=\"play_button\">Play</a>", ModuleId);
            }

            return output;
        }

        private string GeneratePrev()
        {
            return String.Format("<a href='javascript:void(0);' id='slides_{0}_prev'>Previous</a>", ModuleId);
        }

        private string GenerateSlides()
        {
            var output = new StringBuilder();

            output.Append(String.Format("<div id='slides_{0}' class='slides'>", ModuleId));

            foreach (Slide slide in _slides)
            {
                output.Append(String.Format("<div class='slide' title='{0}' style='display:none;'>{1}</div>", slide.Title, TokenizeSlideBody(slide)));
            }

            output.Append("</div>");

            return output.ToString();
        }

        private List<Slide> GetAllModuleSlides()
        {
            var q = new SlideQuery();
            q.Where(q.PortalID == PortalId && q.ModuleID == ModuleId && q.IsVisible == true);
            q.OrderBy(q.DisplayOrder.Ascending);

            var slides = new SlideCollection();
            slides.Load(q);

            return slides.ToList();
        }

        private void IncludeJS()
        {
            const string jsEasingKey = "DNNspot-Rotator-Easing";
            const string jsCycleKey = "DNNspot-Rotator-Cycle";

            RegisterJavascriptFileOnceInBody(jsCycleKey, String.Format("{0}{1}js/jquery.cycle.all.min.js", Globals.ApplicationPath, ModuleWebPath));
            RegisterJavascriptFileOnceInBody(jsEasingKey, String.Format("{0}{1}js/jquery.easing.1.3.js", Globals.ApplicationPath, ModuleWebPath)); 
        }

        private void LoadVariables()
        {
            if (Settings[ModuleSettingNames.TemplateId] != null)
                _templateId = Convert.ToInt32(Settings[ModuleSettingNames.TemplateId]);

            _transitionEffect = Settings[ModuleSettingNames.TransitionEffect] != null
                                    ? "'" + Settings[ModuleSettingNames.TransitionEffect] + "'"
                                    : "'fade'";

            _easeInEffect = Settings[ModuleSettingNames.EaseInEffect] != null
                                ? "'" + Settings[ModuleSettingNames.EaseInEffect] + "'"
                                : "'swing'";

            _easeOutEffect = Settings[ModuleSettingNames.EaseOutEffect] != null
                                 ? "'" + Settings[ModuleSettingNames.EaseOutEffect] + "'"
                                 : "'swing'";

            _speedIn = Settings[ModuleSettingNames.SpeedIn] != null
                           ? Settings[ModuleSettingNames.SpeedIn].ToString()
                           : "300";

            _speedOut = Settings[ModuleSettingNames.SpeedOut] != null
                            ? Settings[ModuleSettingNames.SpeedOut].ToString()
                            : "300";

            _timeout = Settings[ModuleSettingNames.Timeout] != null
                           ? Settings[ModuleSettingNames.Timeout].ToString()
                           : "1000";

            _delay = Settings[ModuleSettingNames.Delay] != null
                         ? Settings[ModuleSettingNames.Delay].ToString()
                         : "0";

            _pause = Settings[ModuleSettingNames.Pause] != null
                         ? "1"
                         : "0";

            _random = Settings[ModuleSettingNames.Random] != null
                          ? "1"
                          : "0";

            _syncOff = Settings[ModuleSettingNames.SyncOff] != null
                           ? "0"
                           : "1";

            _randomizeTransitions = Settings[ModuleSettingNames.RandomizeTransitions] != null
                           ? "1"
                           : "0";

            _loop = Settings[ModuleSettingNames.Loop] != null
                           ? "1"
                           : "0";

            _numberOfTransitions = Settings[ModuleSettingNames.NumberOfTransitions] != null
                           ? Settings[ModuleSettingNames.NumberOfTransitions].ToString()
                           : "0";

            _slideStart = Settings[ModuleSettingNames.SlideStart] != null
               ? Settings[ModuleSettingNames.SlideStart].ToString()
               : "0";

            _height = Settings[ModuleSettingNames.Height] != null
               ? "'" + Settings[ModuleSettingNames.Height].ToString() + "'"
               : "'auto'";
        }

        private string Tokenize(string template)
        {
            var output = new StringBuilder();
            MatchCollection templateArray = Regex.Matches(template, @"\[.*?\]|[^\[.*?\]]+|[\.|\?]+");

            for (int i = 0; i < templateArray.Count; i++)
            {
                // We're using this type of loop rather than a foreach loop so we
                // can implement code blocks e.g. [HASSLIDES] lipsum [/HASSLIDES].
                switch (templateArray[i].Value)
                {
                    case Tokens.Slides:
                        output.Append(GenerateSlides());
                        break;
                    case Tokens.Pager:
                        output.Append(GeneratePager());
                        _hasPager = true;
                        break;
                    case Tokens.Next:
                        output.Append(GenerateNext());
                        _hasNextButton = true;
                        break;
                    case Tokens.Previous:
                        output.Append(GeneratePrev());
                        _hasPreviousButton = true;
                        break;
                    case Tokens.Pause:
                        output.Append(GeneratePause());
                        break;
                    case Tokens.Play:
                        output.Append(GeneratePlay());
                        break;
                    case Tokens.PausePlay:
                        output.Append(GeneratePausePlay());
                        break;
                    default:
                        output.Append(templateArray[i]);
                        break;
                }
            }

            return output.ToString();
        }

        private static string TokenizeSlideBody(Slide slide)
        {
            var output = new StringBuilder();
            MatchCollection templateArray = Regex.Matches(slide.Body, @"\[.*?\]|[^\[.*?\]]+|[\.|\?]+");

            for (int i = 0; i < templateArray.Count; i++)
            {
                // We're using this type of loop rather than a foreach loop so we
                // can implement code blocks e.g. [HASSLIDES] lipsum [/HASSLIDES].
                switch (templateArray[i].Value)
                {
                    case SlideTokens.Title:
                        output.Append(slide.Title);
                        break;
                    default:
                        output.Append(templateArray[i]);
                        break;
                }
            }

            return output.ToString();
        }

        #endregion
    }

    public static class SlideTokens
    {
        public const string Title = "[TITLE]";
    }

    public static class Tokens
    {
        public const String Next = "[NEXT]";
        public const String Pager = "[PAGER]";
        public const String Pause = "[PAUSE]";
        public const String PausePlay = "[PAUSEPLAY]";
        public const String Play = "[PLAY]";
        public const String Previous = "[PREV]";
        public const String Slides = "[SLIDES]";
    }
}