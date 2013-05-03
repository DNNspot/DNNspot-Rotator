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
    public partial class Slides : ModuleBase, IActionable
    {
        #region Members

        private int _displayOrderMax;
        private int _displayOrderMin;

        #endregion

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
                    "Add slide",
                    ModuleActionType.AddContent,
                    "",
                    "",
                    EditUrl(ControlKeys.Slide),
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
            var hidSlideId = (HiddenField) row.FindControl("hidSlideId");

            var slide = new Slide();
            if (slide.LoadByPrimaryKey(Convert.ToInt32(hidSlideId.Value)))
            {
                slide.MarkAsDeleted();
                slide.Save();
            }

            BindSlides();
        }

        protected void btnDown_Command(object sender, CommandEventArgs e)
        {
            var btnDown = (ImageButton) sender;
            var row = (RepeaterItem) btnDown.Parent;
            var hidSlideId = (HiddenField) row.FindControl("hidSlideID");

            DemoteSlideOrder(Convert.ToInt32(hidSlideId.Value));

            BindSlides();
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            var btnEdit = (ImageButton) sender;
            var row = (RepeaterItem) btnEdit.Parent;
            var hidSlideId = (HiddenField) row.FindControl("hidSlideID");

            Response.Redirect(EditUrl("", "", ControlKeys.Slide, new[] {String.Format("{0}={1}", RequestVariables.SlideId, hidSlideId.Value)}));
        }

        protected void btnUp_Command(object sender, CommandEventArgs e)
        {
            var btnUp = (ImageButton) sender;
            var row = (RepeaterItem) btnUp.Parent;
            var hidSlideId = (HiddenField) row.FindControl("hidSlideID");

            PromoteSlideOrder(Convert.ToInt32(hidSlideId.Value));

            BindSlides();
        }

        protected new void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            ModuleConfiguration.ModuleTitle = ControlKeys.Slides;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetDisplayOrderBounds();

            if (!IsPostBack)
            {
                BindSlides();
            }
        }

        protected void rptSlides_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            BindSlideItem(e);
        }

        #endregion

        #region Functions

        private void BindSlideItem(RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var slide = (Slide) e.Item.DataItem;
                var hidSlideId = (HiddenField) e.Item.FindControl("hidSlideID");
                var litTitle = (Literal) e.Item.FindControl("litTitle");
                var btnUp = (ImageButton)e.Item.FindControl("btnUp");
                var btnDown = (ImageButton)e.Item.FindControl("btnDown");
                var btnEdit = (ImageButton)e.Item.FindControl("btnEdit");
                var btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
                var imgSpacer = (Image)e.Item.FindControl("imgSpacer");

                btnUp.ImageUrl = String.Format("{0}{1}images/up.gif", Globals.ApplicationPath, ModuleWebPath);
                btnDown.ImageUrl = String.Format("{0}{1}images/down.gif", Globals.ApplicationPath, ModuleWebPath);
                btnEdit.ImageUrl = String.Format("{0}{1}images/edit.gif", Globals.ApplicationPath, ModuleWebPath);
                btnDelete.ImageUrl = String.Format("{0}{1}images/delete.gif", Globals.ApplicationPath, ModuleWebPath);
                imgSpacer.ImageUrl = String.Format("{0}{1}images/spacer.gif", Globals.ApplicationPath, ModuleWebPath);

                hidSlideId.Value = slide.Id.ToString();
                litTitle.Text = slide.Title;

                if (slide.DisplayOrder == _displayOrderMin)
                {
                    btnUp.Visible = false;
                }

                if (slide.DisplayOrder == _displayOrderMax)
                {
                    btnDown.Visible = false;
                    imgSpacer.Visible = true;
                }
            }
        }

        private void BindSlides()
        {
            GetDisplayOrderBounds();

            rptSlides.DataSource = GetAllModuleSlides();
            rptSlides.DataBind();
        }

        private void DemoteSlideOrder(int slideId)
        {
            var slide = new Slide();
            slide.LoadByPrimaryKey(slideId);

            var q = new SlideQuery();
            q.es.Top = 1;
            q.Where(q.PortalID == PortalId && q.ModuleID == ModuleId && q.DisplayOrder > slide.DisplayOrder);
            q.OrderBy(q.DisplayOrder.Ascending);

            var swap = new Slide();
            swap.Load(q);

            var swapDisplayOrder = swap.DisplayOrder;

            swap.DisplayOrder = slide.DisplayOrder;
            slide.DisplayOrder = swapDisplayOrder;

            slide.Save();
            swap.Save();
        }

        private List<Slide> GetAllModuleSlides()
        {
            var q = new SlideQuery();
            q.Where(q.PortalID == PortalId && q.ModuleID == ModuleId);
            q.OrderBy(q.DisplayOrder.Ascending);

            var slides = new SlideCollection();
            slides.Load(q);

            return slides.ToList();
        }

        private void GetDisplayOrderBounds()
        {
            var q = new SlideQuery();
            q.Select(q.DisplayOrder.Min().As("MinOrder"));
            q.Where(q.PortalID == PortalId && q.ModuleID == ModuleId);

            object o = q.ExecuteScalar();

            _displayOrderMin = o.GetType() == typeof(DBNull) ? 0 : (int)o;

            q = new SlideQuery();
            q.Select(q.DisplayOrder.Max());
            q.Where(q.PortalID == PortalId && q.ModuleID == ModuleId);

            o = q.ExecuteScalar();

            _displayOrderMax = o.GetType() == typeof(DBNull) ? 0 : (int)o;
        }

        private void PromoteSlideOrder(int slideId)
        {
            var slide = new Slide();
            slide.LoadByPrimaryKey(slideId);

            var q = new SlideQuery();
            q.es.Top = 1;
            q.Where(q.PortalID == PortalId && q.ModuleID == ModuleId && q.DisplayOrder < slide.DisplayOrder);
            q.OrderBy(q.DisplayOrder.Descending);

            var swap = new Slide();
            swap.Load(q);

            var swapDisplayOrder = swap.DisplayOrder;

            swap.DisplayOrder = slide.DisplayOrder;
            slide.DisplayOrder = swapDisplayOrder;

            slide.Save();
            swap.Save();
        }

        #endregion
    }
}