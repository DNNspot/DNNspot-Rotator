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
        private bool _hasCustomField1;
        private bool _hasCustomField2;
        private bool _hasCustomField3;
        private string _pause;
        private string _random;
        private string _speed;

        [Obsolete]
        private string _speedIn;
        [Obsolete]
        private string _speedOut;
        private string _transitionSpeed;
        private string _sync;
        private string _randomizeTransitions;
        private int? _templateId;
        private string _timeout;
        private string _transitionEffect;
        private string _visibleCarouselSlides;
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
            //var jsString = new StringBuilder();

            //if (_hasPager)
            //{
            //    jsString.Append(String.Format("function slides_{0}_pagerAnchorBuilder(idx, slide) {{ ", ModuleId));

            //    jsString.Append(
            //        String.Format(
            //            "return 'ul#slides_{0}_pager li#slides_{0}_pager_' + idx + ' a'; ",
            //            ModuleId));



            //    jsString.Append("} ");

            //    jsString.Append(String.Format("function slides_{0}_updateActivePagerLink(pager, currSlide) {{ ", ModuleId));
            //    jsString.Append("jQuery(pager).find('li').removeClass('activeSlide').filter('li:eq('+currSlide+')').addClass('activeSlide'); ");
            //    jsString.Append("jQuery(pager).find('li').removeClass('prevSlide').filter('li:eq('+currSlide+')').prev().addClass('prevSlide'); ");
            //    jsString.Append("jQuery(pager).find('li').removeClass('nextSlide').filter('li:eq('+currSlide+')').next().addClass('nextSlide'); ");
            //    jsString.Append("}; ");
            //}

            //jsString.Append("jQuery(function() { ");
            //jsString.Append(String.Format("jQuery('#slides_{0}').cycle({{", ModuleId));
            //jsString.Append(String.Format("fx: {0}, ", _transitionEffect));
            //jsString.Append(String.Format("speedIn: {0}, ", _speedIn));
            //jsString.Append(String.Format("speedOut: {0}, ", _speedOut));
            //jsString.Append(String.Format("easeIn: {0}, ", _easeInEffect));
            //jsString.Append(String.Format("easeOut: {0}, ", _easeOutEffect));
            //jsString.Append(String.Format("sync: {0}, ", _sync));
            //jsString.Append(String.Format("timeout: {0}, ", _timeout));
            //jsString.Append(String.Format("delay: {0}, ", _delay));
            //jsString.Append(String.Format("pause: {0}, ", _pause));
            //jsString.Append(String.Format("random: {0}, ", _random));
            //jsString.Append(String.Format("autostop: {0}, ", _loop));
            //jsString.Append(String.Format("autostopCount: {0}, ", _numberOfTransitions));
            //jsString.Append(String.Format("cleartypeNoBg: {0}, ", "true"));
            //jsString.Append(String.Format("startingSlide: {0}, ", _slideStart));
            //jsString.Append(String.Format("randomizeEffects: {0}, ", _randomizeTransitions));
            //jsString.Append(String.Format("height: {0}, ", _height));

            //if (_hasNextButton)
            //    jsString.Append(String.Format("next: '#slides_{0}_next', ", ModuleId));

            //if (_hasPreviousButton)
            //    jsString.Append(String.Format("prev: '#slides_{0}_prev', ", ModuleId));

            //if (_hasPager)
            //{
            //    jsString.Append(String.Format("pager: '#slides_{0}_pager', ", ModuleId));
            //    jsString.Append(String.Format("pagerAnchorBuilder: slides_{0}_pagerAnchorBuilder, ", ModuleId));
            //    jsString.Append(String.Format("updateActivePagerLink: slides_{0}_updateActivePagerLink, ", ModuleId));
            //}

            //jsString.Append("cleartype: 1");
            //jsString.Append("}); ");

            //if (_hasPager)
            //{
            //    jsString.Append(string.Format("jQuery('#slides_{0}_pager li:first').addClass('firstSlide'); ", ModuleId));
            //    jsString.Append(string.Format("jQuery('#slides_{0}_pager li:last').addClass('lastSlide'); ", ModuleId));
            //}

            //if (_hasPauseButton)
            //{
            //    jsString.Append(string.Format("jQuery('#slides_{0}_pause_button').click(function() {{ ", ModuleId));
            //    jsString.Append(string.Format("jQuery('#slides_{0}').cycle('pause'); ", ModuleId));
            //    jsString.Append("}); ");
            //}

            //if (_hasPlayButton)
            //{
            //    jsString.Append(string.Format("jQuery('#slides_{0}_play_button').click(function() {{ ", ModuleId));
            //    jsString.Append(string.Format("jQuery('#slides_{0}').cycle('resume'); ", ModuleId));
            //    jsString.Append("}); ");
            //}

            //if (_hasPausePlayButton)
            //{
            //    jsString.Append(string.Format("jQuery('#slides_{0}_pauseplay_button').click(function() {{ ", ModuleId));
            //    jsString.Append("if(jQuery(this).hasClass('pause')) { ");
            //    jsString.Append("jQuery(this).removeClass('pause').addClass('resume').text('Play'); ");
            //    jsString.Append(string.Format("jQuery('#slides_{0}').cycle('pause'); ", ModuleId));
            //    jsString.Append("} else if(jQuery(this).hasClass('resume')) { ");
            //    jsString.Append("jQuery(this).removeClass('resume').addClass('pause').text('Pause'); ");
            //    jsString.Append(string.Format("jQuery('#slides_{0}').cycle('resume'); ", ModuleId));
            //    jsString.Append("} ");
            //    jsString.Append("}); ");
            //}

            //jsString.Append("}); ");

            //litJSOutput.Text = String.Format("<script type=\"text/javascript\">{0}</script>", jsString);
        }

        private string GenerateNext()
        {
            return String.Format("<a href='javascript:void(0);' id='slides_{0}_next'>Next</a>", ModuleId);
        }

        private void GenerateOutputFromTemplate()
        {
            var template = new Template();
            template.LoadByPrimaryKey(Convert.ToInt32(_templateId));

            litOutput.Text = Tokenize(template);
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

        private string GenerateSlides(Template template)
        {
            var output = new StringBuilder();

            output.Append(String.Format("<div id='slides_{0}' ", ModuleId));
            output.Append("class='cycle-slideshow' "); // AUTO-INITIALIZE
            output.Append("data-cycle-slides='> div.slide' "); // SELECT SLIDES
            output.Append("data-cycle-log='false' "); // SHUT OFF CONSOLE LOGGING
            output.Append("data-cycle-slide-active-class='activeSlide' ");
            output.Append("data-cycle-pager-active-class='activeSlide' ");
            output.AppendFormat("data-cycle-fx='{0}' ", _transitionEffect);
            output.AppendFormat("data-cycle-carousel-visible='{0}' ", _visibleCarouselSlides);
            output.AppendFormat("data-cycle-speed='{0}' ", _speed);
            output.AppendFormat("data-cycle-delay='{0}' ", _delay);
            output.AppendFormat("data-cycle-pause-on-hover='{0}' ", _pause);
            output.AppendFormat("data-cycle-sync='{0}' ", _sync);
            output.AppendFormat("data-cycle-random='{0}' ", _random);
            output.AppendFormat("data-cycle-timeout='{0}' ", _timeout);
            output.AppendFormat("data-cycle-loop='{0}' ", _loop);
            output.Append("data-cycle-swipe='true' ");
            output.AppendFormat("data-cycle-auto-height='{0}' ", _height);
            output.Append("data-cycle-swipe='true' ");
            output.AppendFormat("data-cycle-starting-slide='{0}'", _slideStart);

            if (_hasPager)
            {
                output.AppendFormat("data-cycle-pager='#slides_{0}_pager' ", ModuleId);
                output.Append("data-cycle-pager-template='' ");
            }

            if (_hasPreviousButton)
            {
                output.AppendFormat("data-cycle-prev='#slides_{0}_prev' ", ModuleId);
            }

            if (_hasNextButton)
            {
                output.AppendFormat("data-cycle-next='#slides_{0}_next' ", ModuleId);
            }

            if (!String.IsNullOrEmpty(_easeInEffect))
            {
                output.AppendFormat("data-cycle-easing={0} ", _easeInEffect);
            }

            if (!String.IsNullOrEmpty(_easeOutEffect))
            {
                output.AppendFormat("data-cycle-ease-out={0} ", _easeOutEffect);
            }


            output.Append(">");

            foreach (Slide slide in _slides)
            {
                output.Append(String.Format("<div class='slide' title='{0}'>{1}</div>", slide.Title, TokenizeSlideBody(template, slide)));
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

            return slides.Where(s => s.IsViewable).ToList();
        }

        private void IncludeJS()
        {
            const string jsCycle = "DNNspot-Rotator-Cycle";
            const string jsEasing = "DNNspot-Rotator-Easing";

            const string jsCaption = "DNNspot-Rotator-Caption";
            const string jsCenter = "DNNspot-Rotator-Center";
            const string jsSwipe = "DNNspot-Rotator-Swipe";
            const string jsVideo = "DNNspot-Rotator-Video";

            const string jsCarousel = "DNNspot-Rotator-Carousel";
            const string jsFlip = "DNNspot-Rotator-Flip";
            const string jsIEFade = "DNNspot-Rotator-IEFade";
            const string jsScrollVert = "DNNspot-Rotator-ScrollVert";
            const string jsShuffle = "DNNspot-Rotator-Shuffle";
            const string jsTile = "DNNspot-Rotator-Tile";

            RegisterJavascriptFileOnceInBody(jsCycle, String.Format("{0}{1}js/jquery.cycle2.min.js", Globals.ApplicationPath, ModuleWebPath));
            RegisterJavascriptFileOnceInBody(jsEasing, String.Format("{0}{1}js/jquery.easing.1.3.js", Globals.ApplicationPath, ModuleWebPath));
            RegisterJavascriptFileOnceInBody(jsCaption, String.Format("{0}{1}js/jquery.cycle2.caption2.min.js", Globals.ApplicationPath, ModuleWebPath));
            RegisterJavascriptFileOnceInBody(jsCenter, String.Format("{0}{1}js/jquery.cycle2.center.min.js", Globals.ApplicationPath, ModuleWebPath));
            RegisterJavascriptFileOnceInBody(jsSwipe, String.Format("{0}{1}js/jquery.cycle2.swipe.min.js", Globals.ApplicationPath, ModuleWebPath));
            RegisterJavascriptFileOnceInBody(jsVideo, String.Format("{0}{1}js/jquery.cycle2.video.min.js", Globals.ApplicationPath, ModuleWebPath));

            switch (_transitionEffect)
            {
                case "carousel":
                    RegisterJavascriptFileOnceInBody(jsCarousel, String.Format("{0}{1}js/jquery.cycle2.carousel.min.js", Globals.ApplicationPath, ModuleWebPath));
                    break;
                
                case "flipHorz":
                    RegisterJavascriptFileOnceInBody(jsFlip, String.Format("{0}{1}js/jquery.cycle2.flip.min.js", Globals.ApplicationPath, ModuleWebPath));
                    break;

                case "scrollVert":
                    RegisterJavascriptFileOnceInBody(jsScrollVert, String.Format("{0}{1}js/jquery.cycle2.scrollVert.min.js", Globals.ApplicationPath, ModuleWebPath));
                    break;

                case "shuffle":
                    RegisterJavascriptFileOnceInBody(jsShuffle, String.Format("{0}{1}js/jquery.cycle2.shuffle.min.js", Globals.ApplicationPath, ModuleWebPath));
                    break;

                case "tileSlide":
                    RegisterJavascriptFileOnceInBody(jsTile, String.Format("{0}{1}js/jquery.cycle2.tile.min.js", Globals.ApplicationPath, ModuleWebPath));
                    break;

                default:
                    RegisterJavascriptFileOnceInBody(jsIEFade, String.Format("{0}{1}js/jquery.cycle2.ie-fade.min.js", Globals.ApplicationPath, ModuleWebPath));
                    break;
            }
        }

        private void LoadVariables()
        {
            if (Settings[ModuleSettingNames.TemplateId] != null)
                _templateId = Convert.ToInt32(Settings[ModuleSettingNames.TemplateId]);

            _transitionEffect = Settings[ModuleSettingNames.TransitionEffect] != null
                                    ? Convert.ToString(Settings[ModuleSettingNames.TransitionEffect])
                                    : "fade";

            _visibleCarouselSlides = Settings[ModuleSettingNames.VisibleCarouselSlides] != null
                                    ? Convert.ToString(Settings[ModuleSettingNames.VisibleCarouselSlides])
                                    : "2";

            _easeInEffect = Settings[ModuleSettingNames.EaseInEffect] != null
                                ? "'" + Settings[ModuleSettingNames.EaseInEffect] + "'"
                                : "'swing'";

            _easeOutEffect = Settings[ModuleSettingNames.EaseOutEffect] != null
                                 ? "'" + Settings[ModuleSettingNames.EaseOutEffect] + "'"
                                 : "'swing'";

            _speed = Settings[ModuleSettingNames.Speed] != null
                           ? Settings[ModuleSettingNames.Speed].ToString()
                           : "1000";

            _timeout = Settings[ModuleSettingNames.Timeout] != null
                           ? Settings[ModuleSettingNames.Timeout].ToString()
                           : "1000";

            _delay = Settings[ModuleSettingNames.Delay] != null
                         ? Settings[ModuleSettingNames.Delay].ToString()
                         : "0";

            _pause = Settings[ModuleSettingNames.Pause] != null
                         ? "true"
                         : "false";

            _random = Settings[ModuleSettingNames.Random] != null
                          ? "true"
                          : "false";

            _sync = Settings[ModuleSettingNames.Sync] != null
                           ? "false"
                           : "true";

            _loop = Settings[ModuleSettingNames.Loop] != null
                           ? "true"
                           : "false";

            _numberOfTransitions = Settings[ModuleSettingNames.NumberOfTransitions] != null
                           ? Settings[ModuleSettingNames.NumberOfTransitions].ToString()
                           : "0";

            _slideStart = Settings[ModuleSettingNames.SlideStart] != null
               ? Settings[ModuleSettingNames.SlideStart].ToString()
               : "0";

            _height = Settings[ModuleSettingNames.Height] != null
               ? Settings[ModuleSettingNames.Height].ToString()
               : "calc";
        }

        private string Tokenize(Template template)
        {
            var output = new StringBuilder();
            string templateString = template.Body ?? Tokens.Slides;
            MatchCollection templateArray = Regex.Matches(templateString, @"\[.*?\]|[^\[.*?\]]+|[\.|\?]+");

            _hasPager = templateString.Contains(Tokens.Pager) ? true : false;
            _hasPlayButton = templateString.Contains(Tokens.Play) ? true : false;
            _hasPausePlayButton = templateString.Contains(Tokens.PausePlay) ? true : false;
            _hasPauseButton = templateString.Contains(Tokens.Pause) ? true : false;
            _hasNextButton = templateString.Contains(Tokens.Next) ? true : false;
            _hasPreviousButton = templateString.Contains(Tokens.Previous) ? true : false;

            for (int i = 0; i < templateArray.Count; i++)
            {
                // We're using this type of loop rather than a foreach loop so we
                // can implement code blocks e.g. [HASSLIDES] lipsum [/HASSLIDES].
                switch (templateArray[i].Value)
                {
                    case Tokens.Slides:
                        output.Append(GenerateSlides(template));
                        break;
                    case Tokens.Pager:
                        output.Append(GeneratePager());
                        break;
                    case Tokens.Next:
                        output.Append(GenerateNext());
                        break;
                    case Tokens.Previous:
                        output.Append(GeneratePrev());
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
                    //case Tokens.CustomField1:
                    //    output.Append(_.CustomField1);
                    //    break;
                    //case Tokens.CustomField2:
                    //    output.Append(slide.CustomField2);
                    //    break;
                    //case Tokens.CustomField3:
                    //    output.Append(slide.CustomField3);
                    //    break;
                    default:
                        output.Append(templateArray[i]);
                        break;
                }
            }

            return output.ToString();
        }

        private static string TokenizeSlideBody(Template template, Slide slide)
        {
            var output = new StringBuilder();
            string slideTemplate = String.IsNullOrEmpty(template.SlideTemplate) ? "[BODY]" : template.SlideTemplate;
            MatchCollection templateArray = Regex.Matches(slideTemplate, @"\[.*?\]|[^\[.*?\]]+|[\.|\?]+");

            for (int i = 0; i < templateArray.Count; i++)
            {
                // We're using this type of loop rather than a foreach loop so we
                // can implement code blocks e.g. [HASSLIDES] lipsum [/HASSLIDES].
                switch (templateArray[i].Value)
                {
                    case SlideTokens.Title:
                        output.Append(slide.Title);
                        break;
                    case SlideTokens.Body:
                        output.Append(slide.Body);
                        break;
                    case SlideTokens.CustomField1:
                        output.Append(slide.CustomField1);
                        break;
                    case SlideTokens.CustomField2:
                        output.Append(slide.CustomField2);
                        break;
                    case SlideTokens.CustomField3:
                        output.Append(slide.CustomField3);
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
        public const string Body = "[BODY]";
        public const string CustomField1 = "[CUSTOMFIELD1]";
        public const string CustomField2 = "[CUSTOMFIELD2]";
        public const string CustomField3 = "[CUSTOMFIELD3]";
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