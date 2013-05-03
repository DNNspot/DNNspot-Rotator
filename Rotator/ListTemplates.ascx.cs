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
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using DNNspot.Rotator.Common;
using DNNspot.Rotator.DataModel;

namespace DNNspot.Rotator
{
    public partial class Templates : ModuleBase, IActionable
    {
        #region Properties

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection();

                actions.Add(
                    GetNextActionID(),
                    "Back",
                    ModuleActionType.AddContent,
                    "",
                    "",
                    Globals.NavigateURL(TabId),
                    false,
                    SecurityAccessLevel.Edit,
                    true,
                    false);

                actions.Add(
                    GetNextActionID(),
                    "Add template",
                    ModuleActionType.AddContent,
                    "",
                    "",
                    EditUrl(ControlKeys.Template),
                    false,
                    SecurityAccessLevel.Edit,
                    true,
                    false);


                return actions;
            }
        }

        #endregion

        #region Events

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            var btnDelete = (ImageButton) sender;
            var row = (RepeaterItem) btnDelete.Parent;
            var hidTemplateId = (HiddenField) row.FindControl("hidTemplateID");

            var template = new Template();
            if(template.LoadByPrimaryKey(Convert.ToInt32(hidTemplateId.Value)))
            {
                template.MarkAsDeleted();
                template.Save();
            }

            BindTemplates();
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            var btnEdit = (ImageButton) sender;
            var row = (RepeaterItem) btnEdit.Parent;
            var hidTemplateId = (HiddenField) row.FindControl("hidTemplateID");

            Response.Redirect(EditUrl("", "", ControlKeys.Template, new[] {String.Format("{0}={1}", RequestVariables.TemplateId, hidTemplateId.Value)}));
        }

        protected new void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            ModuleConfiguration.ModuleTitle = ControlKeys.Templates;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTemplates();
            }
        }

        protected void rptTemplates_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            BindTemplateItem(e);
        }

        #endregion

        #region Functions

        private void BindTemplateItem(RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var template = (Template) e.Item.DataItem;
                var hidTemplateId = (HiddenField) e.Item.FindControl("hidTemplateID");
                var litTitle = (Literal) e.Item.FindControl("litTitle");
                var btnEdit = (ImageButton)e.Item.FindControl("btnEdit");
                var btnDelete = (ImageButton)e.Item.FindControl("btnDelete");

                btnEdit.ImageUrl = String.Format("{0}{1}images/edit.gif", Globals.ApplicationPath, ModuleWebPath);
                btnDelete.ImageUrl = String.Format("{0}{1}images/delete.gif", Globals.ApplicationPath, ModuleWebPath);

                hidTemplateId.Value = template.Id.ToString();
                litTitle.Text = template.Title;
            }
        }

        private void BindTemplates()
        {
            rptTemplates.DataSource = GetAllModuleTemplates();
            rptTemplates.DataBind();
        }

        private List<Template> GetAllModuleTemplates()
        {
            var q = new TemplateQuery();
            q.Where(q.PortalID == PortalId);

            var templates = new TemplateCollection();
            templates.Load(q);

            return templates.ToList();
        }

        private bool AddDefaultTemplate(int PortalId, int ModuleId, string Title, string Body)
        {
            Template template = new Template();
            template.PortalID = PortalId;
            template.ModuleID = ModuleId;
            template.Title = Title;
            template.Body = Body;
            template.Save();

            return true;
        }

        #endregion

        protected void btnDefaultTemplates_Click(object sender, EventArgs e)
        {
            string TemplateOneBody = @"<div class=""DNNSpotTemplateOne""><div id=""whole""><div class=""prev_small"">[PREV]</div><div class=""slides_small"">[SLIDES]</div><div class=""next_small"">[NEXT]</div></div><div style=""clear: both;"">&#160;</div></div>";
            AddDefaultTemplate(PortalId, ModuleId, "DNNspot Template One", TemplateOneBody);

            string TemplateTwoBody = @"<div class=""DNNSpotTemplateTwo""><div class=""slide_small2"">[SLIDES]</div><div class=""navigation""><div class=""previousNav"">[PREV]</div><div class=""pager"">[PAGER]</div><div class=""nextNav"">[NEXT]</div></div><div style=""clear: both;"">&#160;</div></div>";
            AddDefaultTemplate(PortalId, ModuleId, "DNNspot Template Two", TemplateTwoBody);

            
            Response.Redirect(EditUrl(ControlKeys.Templates));
        }
    }
}