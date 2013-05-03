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
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DNNspot.Rotator.Common;
using DNNspot.Rotator.DataModel;

namespace DNNspot.Rotator
{
    public partial class Settings : ModuleSettingsBase
    {
        #region Events

        public override void LoadSettings()
        {
            if (!IsPostBack)
                LoadControls();
        }

        public override void UpdateSettings()
        {
            SaveSettings();
        }

        #endregion

        #region Functions

        private List<Template> GetAllModuleTemplates()
        {
            var q = new TemplateQuery();
            q.Where(q.PortalID == PortalId);

            var templates = new TemplateCollection();
            templates.Load(q);

            return templates.ToList();
        }

        private void LoadControls()
        {

            ddlTemplates.DataSource = GetAllModuleTemplates();
            ddlTemplates.DataTextField = TemplateMetadata.ColumnNames.Title;
            ddlTemplates.DataValueField = TemplateMetadata.ColumnNames.Id;
            ddlTemplates.DataBind();

            ddlTemplates.Items.Insert(0, new ListItem("default", "default"));

            if (ModuleSettings[ModuleSettingNames.TemplateId] != null && ddlTemplates.Items.FindByValue(Convert.ToString(ModuleSettings[ModuleSettingNames.TemplateId])) != null)
                ddlTemplates.Items.FindByValue(Convert.ToString(ModuleSettings[ModuleSettingNames.TemplateId])).Selected = true;

            if (ModuleSettings[ModuleSettingNames.TransitionEffect] != null)
            {
                string[] values = Convert.ToString(ModuleSettings[ModuleSettingNames.TransitionEffect]).Split(',');
                foreach (string a in values)
                {
                    ddlTransitionEffect.Items.FindByValue(a).Selected = true;
                }
            }
            else
            {
                ddlTransitionEffect.SelectedValue = "fade";
            }

            if (ModuleSettings[ModuleSettingNames.EaseInEffect] != null)
                ddlEaseInEffect.Items.FindByValue(Convert.ToString(ModuleSettings[ModuleSettingNames.EaseInEffect])).Selected = true;

            if (ModuleSettings[ModuleSettingNames.EaseOutEffect] != null)
                ddlEaseOutEffect.Items.FindByValue(Convert.ToString(ModuleSettings[ModuleSettingNames.EaseOutEffect])).Selected = true;

            txtSpeedIn.Text = Convert.ToString(ModuleSettings[ModuleSettingNames.SpeedIn]);
            txtSpeedOut.Text = Convert.ToString(ModuleSettings[ModuleSettingNames.SpeedOut]);
            txtTimeout.Text = Convert.ToString(ModuleSettings[ModuleSettingNames.Timeout]);
            txtHeight.Text = Convert.ToString(ModuleSettings[ModuleSettingNames.Height]);
            txtDelay.Text = Convert.ToString(ModuleSettings[ModuleSettingNames.Delay]);
            chkPause.Checked = ModuleSettings[ModuleSettingNames.Pause] != null;
            chkRandom.Checked = ModuleSettings[ModuleSettingNames.Random] != null;
            chkSyncOff.Checked = ModuleSettings[ModuleSettingNames.SyncOff] != null;
            chkRandomTransitions.Checked = ModuleSettings[ModuleSettingNames.RandomizeTransitions] != null;
            chkLoop.Checked = ModuleSettings[ModuleSettingNames.Loop] != null;
            txtNumberOfTransitions.Text = Convert.ToString(ModuleSettings[ModuleSettingNames.NumberOfTransitions]);
            txtSlideStart.Text = Convert.ToString(ModuleSettings[ModuleSettingNames.SlideStart]);
            chkNoJQuery.Checked = !string.IsNullOrEmpty(HostSettings.GetHostSetting(ModuleSettingNames.NoJQuery));

        }

        private void SaveSettings()
        {
            try
            {
                var hostSettingsController = new HostSettingsController();
                var moduleController = new ModuleController();

                if (ddlTemplates.SelectedIndex != 0)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.TemplateId, ddlTemplates.SelectedValue);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.TemplateId);
                
                if (ddlTransitionEffect.SelectedValue != "")
                {
                    string values = String.Empty;

                    foreach (ListItem lst in ddlTransitionEffect.Items)
                    {
                        if (lst.Selected == true)
                        {
                            values += lst.Value + ",";
                        }
                    }
                    values = values.TrimEnd(',');
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.TransitionEffect, values);
                }
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.TransitionEffect);

                if (ddlEaseInEffect.SelectedIndex != 0)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.EaseInEffect, ddlEaseInEffect.SelectedValue);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.EaseInEffect);

                if (ddlEaseOutEffect.SelectedIndex != 0)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.EaseOutEffect, ddlEaseOutEffect.SelectedValue);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.EaseOutEffect);

                if (!String.IsNullOrEmpty(txtSpeedIn.Text))
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.SpeedIn, txtSpeedIn.Text);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.SpeedIn);

                if (!String.IsNullOrEmpty(txtSpeedOut.Text))
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.SpeedOut, txtSpeedOut.Text);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.SpeedOut);

                if (!String.IsNullOrEmpty(txtTimeout.Text))
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.Timeout, txtTimeout.Text);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.Timeout);

                if (!String.IsNullOrEmpty(txtDelay.Text))
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.Delay, txtDelay.Text);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.Delay);

                if (chkPause.Checked)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.Pause, chkPause.Checked.ToString());
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.Pause);

                if (chkRandom.Checked)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.Random, chkRandom.Checked.ToString());
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.Random);

                if (chkSyncOff.Checked)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.SyncOff, chkSyncOff.Checked.ToString());
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.SyncOff);

                if (chkRandomTransitions.Checked)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.RandomizeTransitions, chkRandomTransitions.Checked.ToString());
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.RandomizeTransitions);

                if (chkLoop.Checked)
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.Loop, chkLoop.Checked.ToString());
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.Loop);

                if (!String.IsNullOrEmpty(txtNumberOfTransitions.Text))
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.NumberOfTransitions, txtNumberOfTransitions.Text);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.NumberOfTransitions);

                if (!String.IsNullOrEmpty(txtHeight.Text))
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.Height, txtHeight.Text);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.Height);

                if (!String.IsNullOrEmpty(txtSlideStart.Text))
                    moduleController.UpdateModuleSetting(ModuleId, ModuleSettingNames.SlideStart, txtSlideStart.Text);
                else
                    moduleController.DeleteModuleSetting(ModuleId, ModuleSettingNames.SlideStart);

                if (chkNoJQuery.Checked)
                    hostSettingsController.UpdateHostSetting(ModuleSettingNames.NoJQuery, chkNoJQuery.Checked.ToString());
                else
                    hostSettingsController.UpdateHostSetting(ModuleSettingNames.NoJQuery, string.Empty);

                ModuleController.SynchronizeModule(ModuleId);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        #endregion
    }

    public static class ModuleSettingNames
    {
        public const string Delay = "Delay";
        public const string EaseInEffect = "EaseInEffect";
        public const string EaseOutEffect = "EaseOutEffect";
        public const string Pause = "Pause";
        public const string Random = "Random";
        public const string SpeedIn = "SpeedIn";
        public const string SpeedOut = "SpeedOut";
        public const string SyncOff = "SyncOff";
        public const string TemplateId = "TemplateId";
        public const string Timeout = "Timeout";
        public const string TransitionEffect = "TransitionEffect";
        public const string Loop = "Loop";
        public const string Height = "Height";
        public const string RandomizeTransitions = "RandomizeTransitions";
        public const string NumberOfTransitions = "NumberOfTransitions";
        public const string SlideStart = "SlideStart";
        public const string SerialNumber = "DNNspot_Rotator_SerialNumber";
        public const string NoJQuery = "DNNspot_Rotator_NoJQuery";
    }
}