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
using DotNetNuke.Common;
using DNNspot.Rotator.Common;
using DNNspot.Rotator.DataModel;

namespace DNNspot.Rotator
{
    public partial class EditTemplate : ModuleBase
    {
        #region Members

        private int? _templateId;

        protected DotNetNuke.UI.UserControls.TextEditor txtBody;
        protected DotNetNuke.UI.UserControls.TextEditor txtSlideTemplate;

        #endregion

        #region Events

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(EditUrl(ControlKeys.Templates));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DestroyTemplate(_templateId);
            Response.Redirect(EditUrl(ControlKeys.Templates));
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveTemplate(_templateId);
            Response.Redirect(EditUrl(ControlKeys.Templates));
        }

        protected new void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            ModuleConfiguration.ModuleTitle = (Request.QueryString[RequestVariables.TemplateId] == null ? "Add " : "Edit ") + ControlKeys.Template;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMembers();

            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        #endregion

        #region Functions

        private static void DestroyTemplate(int? templateId)
        {
            var template = new Template();
            if (template.LoadByPrimaryKey(Convert.ToInt32(templateId)))
            {
                template.MarkAsDeleted();
                template.Save();
            }
        }

        private void LoadMembers()
        {
            if (Request.QueryString[RequestVariables.TemplateId] != null)
                _templateId = Convert.ToInt32(Request.QueryString[RequestVariables.TemplateId]);
        }

        private void PopulateControls()
        {
            if (_templateId == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                var template = new Template();
                template.LoadByPrimaryKey(Convert.ToInt32(_templateId));

                txtTitle.Text = template.Title;
                txtSlideTemplate.Text = template.SlideTemplate;
                txtBody.Text = template.Body;
            }
        }

        private void SaveTemplate(int? templateId)
        {
            var template = new Template();

            if (templateId == null)
                template.CreatedDate = DateTime.Now;
            else
                template.LoadByPrimaryKey(Convert.ToInt32(templateId));

            template.PortalID = PortalId;
            template.ModuleID = ModuleId;
            template.Title = txtTitle.Text;
            template.Body = txtBody.Text;
            template.SlideTemplate = txtSlideTemplate.Text == DefaultDnnEditorCrap ? txtSlideTemplate.Text.Replace(DefaultDnnEditorCrap, "") : txtSlideTemplate.Text;
            template.ModifiedDate = DateTime.Now;
            template.Save();
        }

        #endregion
    }
}