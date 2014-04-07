/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 4/12/2013 1:15:27 PM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace DNNspot.Rotator.DataModel
{
	public partial class Slide : esSlide
	{
		public Slide()
		{
		
		}

        public bool IsViewable
        {
            get
            {

                RoleController roleController = new RoleController();
                UserInfo userInfo = UserController.GetCurrentUserInfo();
                IEnumerable<RoleInfo> userRoles = (RoleInfo[])roleController.GetUserRoles(userInfo.PortalID, userInfo.UserID).ToArray(typeof(RoleInfo)); //.ToList<RoleInfo>();
                IEnumerable<int> roleIds = userRoles.Select(r => r.RoleID);

                if (userRoles.Any(a => a.RoleType == RoleType.Administrator) || userInfo.IsSuperUser)
                {
                    return true;
                }

                if (!String.IsNullOrEmpty(this.ViewPermissions))
                {




                    var viewPermissions = this.ViewPermissions.Split(',');

                    bool viewable = userRoles.Any(userRole => viewPermissions.Any(a => a == userRole.RoleID.ToString())) || viewPermissions.Any(a => a == "-1");
                    return viewable;
                }


                return false;
            }
        }
	}
}
