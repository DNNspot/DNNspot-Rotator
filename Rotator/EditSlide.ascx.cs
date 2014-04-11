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
using DNNspot.Rotator.Common;
using DNNspot.Rotator.DataModel;
using DotNetNuke.Security.Roles;

namespace DNNspot.Rotator
{
    public partial class EditSlide : ModuleBase
    {
        #region Members

        private int? _slideId;

        protected DotNetNuke.UI.UserControls.TextEditor txtBody;
        protected DotNetNuke.UI.UserControls.TextEditor txtThumbnail;
        protected DotNetNuke.UI.UserControls.TextEditor txtCustomField1;
        protected DotNetNuke.UI.UserControls.TextEditor txtCustomField2;
        protected DotNetNuke.UI.UserControls.TextEditor txtCustomField3;

        #endregion

        #region Events

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(EditUrl(ControlKeys.Slides));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DestroySlide(_slideId);
            Response.Redirect(EditUrl(ControlKeys.Slides));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveSlide(_slideId);
            Response.Redirect(EditUrl(ControlKeys.Slides));
        }

        protected new void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            ModuleConfiguration.ModuleTitle = (Request.QueryString[RequestVariables.SlideId] == null ? "Add " : "Edit ") + ControlKeys.Slide;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMembers();

            if (!IsPostBack)
                PopulateControls();
        }

        #endregion

        #region Functions

        private static void DestroySlide(int? slideId)
        {
            var slide = new Slide();
            if(slide.LoadByPrimaryKey(Convert.ToInt32(slideId)))
            {
                slide.MarkAsDeleted();
                slide.Save();
            }
        }

        private int GetDisplayOrderMax()
        {
            var q = new SlideQuery();
            q.Select(q.DisplayOrder.Max());
            q.Where(q.PortalID == PortalId && q.ModuleID == ModuleId);

            object o = q.ExecuteScalar();

            return o.GetType() == typeof(DBNull) ? 0 : (int)o;
        }

        private void LoadMembers()
        {
            if (Request.QueryString[RequestVariables.SlideId] != null)
                _slideId = Convert.ToInt32(Request.QueryString[RequestVariables.SlideId]);
        }

        private void PopulateControls()
        {

            //--- DNN roles -- VIEW PERMISSIONS
            StringBuilder viewPermissionsRolesUi = new StringBuilder();
            List<int> viewPermission = new List<int>();
            bool isSelected = false;


            var slide = new Slide();

            if (_slideId == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                slide.LoadByPrimaryKey(Convert.ToInt32(_slideId));

                txtTitle.Text = slide.Title;
                txtBody.Text = slide.Body;
                txtThumbnail.Text = slide.Thumbnail;
                txtCustomField1.Text = slide.CustomField1;
                txtCustomField2.Text = slide.CustomField2;
                txtCustomField3.Text = slide.CustomField3;
                chkVisible.Checked = Convert.ToBoolean(slide.IsVisible);
            }

            if (!String.IsNullOrEmpty(slide.ViewPermissions))
            {
                viewPermission = slide.ViewPermissions.ToListOfInt(',');
            }

            isSelected = viewPermission.Any(a => a == -1);

            viewPermissionsRolesUi.AppendFormat(@"
                    <tr>
                        <td>
                            <input type=""checkbox"" id=""viewPermissionId-{0}"" name=""viewPermissionRole"" value=""{0}"" {1} />
                            <label for=""viewPermissionId-{0}"">{2}</label>                                                    
                        </td>
                    </tr>
                ",
             -1,
             isSelected ? @"checked=""checked""" : "",
             "All Users"
            );


            RoleController roleController = new RoleController();
            List<RoleInfo> roleInfos = roleController.GetPortalRoles(PortalId).ToList<RoleInfo>();

            foreach (RoleInfo role in roleInfos)
            {
                if (role.RoleType != RoleType.Administrator)
                {
                    isSelected = viewPermission.Any(a => a == role.RoleID);

                    viewPermissionsRolesUi.AppendFormat(
                        @"
                    <tr>
                        <td>
                            <input type=""checkbox"" id=""viewPermissionId-{0}"" name=""viewPermissionRole"" value=""{0}"" {1} />
                            <label for=""viewPermissionId-{0}"">{2}</label>                                                    
                        </td>
                    </tr>
                ",
                        role.RoleID,
                        isSelected ? @"checked=""checked""" : "",
                        role.RoleName
                        );
                }
            }

            litViewPermissions.Text = viewPermissionsRolesUi.ToString();   
        }

        private string ParseViewPermissionInfoFromPost()
        {
            //toSave.CheckoutAssignRoleIds = chklAssignRoleIds.GetSelectedValues().ToCsv();     

            string[] checkedRoleIds = Request.Form.GetValues("viewPermissionRole") ?? new string[] { };

            return string.Join(",", checkedRoleIds.ToArray());
        }

        private void SaveSlide(int? slideId)
        {
            var slide = new Slide();

            if (slideId == null)
            {
                int displayOrderMax = GetDisplayOrderMax();

                slide.PortalID = PortalId;
                slide.ModuleID = ModuleId;
                slide.DisplayOrder = displayOrderMax + 1;
                slide.CreatedDate = DateTime.Now;
            }
            else
            {
                slide.LoadByPrimaryKey(Convert.ToInt32(slideId));
            }

            slide.Title = txtTitle.Text;
            slide.Body = txtBody.Text;

            slide.Thumbnail = txtThumbnail.Text == DefaultDnnEditorCrap ? txtThumbnail.Text.Replace(DefaultDnnEditorCrap, "") : txtThumbnail.Text;
            slide.CustomField1 = txtCustomField1.Text == DefaultDnnEditorCrap ? txtCustomField1.Text.Replace(DefaultDnnEditorCrap, "") : txtCustomField1.Text;
            slide.CustomField2 = txtCustomField2.Text == DefaultDnnEditorCrap ? txtCustomField2.Text.Replace(DefaultDnnEditorCrap, "") : txtCustomField2.Text;
            slide.CustomField3 = txtCustomField3.Text == DefaultDnnEditorCrap ? txtCustomField3.Text.Replace(DefaultDnnEditorCrap, "") : txtCustomField3.Text;
            slide.IsVisible = chkVisible.Checked;

            slide.ModifiedDate = DateTime.Now;
            slide.ViewPermissions = ParseViewPermissionInfoFromPost();
            slide.Save();
        }

        #endregion
    }
}