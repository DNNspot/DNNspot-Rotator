
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 4/4/2014 4:04:41 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;


using DotNetNuke.Framework.Providers;


namespace DNNspot.Rotator.DataModel
{
	/// <summary>
	/// Encapsulates the 'DNNspot_Rotator_Slides' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Slide))]	
	[XmlType("Slide")]
	public partial class Slide : esSlide
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Slide();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new Slide();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new Slide();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("SlideCollection")]
	public partial class SlideCollection : esSlideCollection, IEnumerable<Slide>
	{
		public Slide FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Slide))]
		public class SlideCollectionWCFPacket : esCollectionWCFPacket<SlideCollection>
		{
			public static implicit operator SlideCollection(SlideCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SlideCollectionWCFPacket(SlideCollection collection)
			{
				return new SlideCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class SlideQuery : esSlideQuery
	{
		public SlideQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SlideQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SlideQuery query)
		{
			return SlideQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SlideQuery(string query)
		{
			return (SlideQuery)SlideQuery.SerializeHelper.FromXml(query, typeof(SlideQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSlide : esEntity
	{
		public esSlide()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			SlideQuery query = new SlideQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(SlideMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(SlideMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.PortalID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? PortalID
		{
			get
			{
				return base.GetSystemInt32(SlideMetadata.ColumnNames.PortalID);
			}
			
			set
			{
				if(base.SetSystemInt32(SlideMetadata.ColumnNames.PortalID, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.PortalID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.ModuleID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ModuleID
		{
			get
			{
				return base.GetSystemInt32(SlideMetadata.ColumnNames.ModuleID);
			}
			
			set
			{
				if(base.SetSystemInt32(SlideMetadata.ColumnNames.ModuleID, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.ModuleID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.Title
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Title
		{
			get
			{
				return base.GetSystemString(SlideMetadata.ColumnNames.Title);
			}
			
			set
			{
				if(base.SetSystemString(SlideMetadata.ColumnNames.Title, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.Title);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.Body
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Body
		{
			get
			{
				return base.GetSystemString(SlideMetadata.ColumnNames.Body);
			}
			
			set
			{
				if(base.SetSystemString(SlideMetadata.ColumnNames.Body, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.Body);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.IsVisible
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? IsVisible
		{
			get
			{
				return base.GetSystemBoolean(SlideMetadata.ColumnNames.IsVisible);
			}
			
			set
			{
				if(base.SetSystemBoolean(SlideMetadata.ColumnNames.IsVisible, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.IsVisible);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.DisplayOrder
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? DisplayOrder
		{
			get
			{
				return base.GetSystemInt32(SlideMetadata.ColumnNames.DisplayOrder);
			}
			
			set
			{
				if(base.SetSystemInt32(SlideMetadata.ColumnNames.DisplayOrder, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.DisplayOrder);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.CreatedDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? CreatedDate
		{
			get
			{
				return base.GetSystemDateTime(SlideMetadata.ColumnNames.CreatedDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(SlideMetadata.ColumnNames.CreatedDate, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.CreatedDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.ModifiedDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? ModifiedDate
		{
			get
			{
				return base.GetSystemDateTime(SlideMetadata.ColumnNames.ModifiedDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(SlideMetadata.ColumnNames.ModifiedDate, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.ModifiedDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.Thumbnail
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Thumbnail
		{
			get
			{
				return base.GetSystemString(SlideMetadata.ColumnNames.Thumbnail);
			}
			
			set
			{
				if(base.SetSystemString(SlideMetadata.ColumnNames.Thumbnail, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.Thumbnail);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.CustomField1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomField1
		{
			get
			{
				return base.GetSystemString(SlideMetadata.ColumnNames.CustomField1);
			}
			
			set
			{
				if(base.SetSystemString(SlideMetadata.ColumnNames.CustomField1, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.CustomField1);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.CustomField2
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomField2
		{
			get
			{
				return base.GetSystemString(SlideMetadata.ColumnNames.CustomField2);
			}
			
			set
			{
				if(base.SetSystemString(SlideMetadata.ColumnNames.CustomField2, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.CustomField2);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.CustomField3
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomField3
		{
			get
			{
				return base.GetSystemString(SlideMetadata.ColumnNames.CustomField3);
			}
			
			set
			{
				if(base.SetSystemString(SlideMetadata.ColumnNames.CustomField3, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.CustomField3);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Slides.ViewPermissions
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ViewPermissions
		{
			get
			{
				return base.GetSystemString(SlideMetadata.ColumnNames.ViewPermissions);
			}
			
			set
			{
				if(base.SetSystemString(SlideMetadata.ColumnNames.ViewPermissions, value))
				{
					OnPropertyChanged(SlideMetadata.PropertyNames.ViewPermissions);
				}
			}
		}		
		
		#endregion	

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "Id": this.str().Id = (string)value; break;							
						case "PortalID": this.str().PortalID = (string)value; break;							
						case "ModuleID": this.str().ModuleID = (string)value; break;							
						case "Title": this.str().Title = (string)value; break;							
						case "Body": this.str().Body = (string)value; break;							
						case "IsVisible": this.str().IsVisible = (string)value; break;							
						case "DisplayOrder": this.str().DisplayOrder = (string)value; break;							
						case "CreatedDate": this.str().CreatedDate = (string)value; break;							
						case "ModifiedDate": this.str().ModifiedDate = (string)value; break;							
						case "Thumbnail": this.str().Thumbnail = (string)value; break;							
						case "CustomField1": this.str().CustomField1 = (string)value; break;							
						case "CustomField2": this.str().CustomField2 = (string)value; break;							
						case "CustomField3": this.str().CustomField3 = (string)value; break;							
						case "ViewPermissions": this.str().ViewPermissions = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(SlideMetadata.PropertyNames.Id);
							break;
						
						case "PortalID":
						
							if (value == null || value is System.Int32)
								this.PortalID = (System.Int32?)value;
								OnPropertyChanged(SlideMetadata.PropertyNames.PortalID);
							break;
						
						case "ModuleID":
						
							if (value == null || value is System.Int32)
								this.ModuleID = (System.Int32?)value;
								OnPropertyChanged(SlideMetadata.PropertyNames.ModuleID);
							break;
						
						case "IsVisible":
						
							if (value == null || value is System.Boolean)
								this.IsVisible = (System.Boolean?)value;
								OnPropertyChanged(SlideMetadata.PropertyNames.IsVisible);
							break;
						
						case "DisplayOrder":
						
							if (value == null || value is System.Int32)
								this.DisplayOrder = (System.Int32?)value;
								OnPropertyChanged(SlideMetadata.PropertyNames.DisplayOrder);
							break;
						
						case "CreatedDate":
						
							if (value == null || value is System.DateTime)
								this.CreatedDate = (System.DateTime?)value;
								OnPropertyChanged(SlideMetadata.PropertyNames.CreatedDate);
							break;
						
						case "ModifiedDate":
						
							if (value == null || value is System.DateTime)
								this.ModifiedDate = (System.DateTime?)value;
								OnPropertyChanged(SlideMetadata.PropertyNames.ModifiedDate);
							break;
					

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esSlide entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String PortalID
			{
				get
				{
					System.Int32? data = entity.PortalID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PortalID = null;
					else entity.PortalID = Convert.ToInt32(value);
				}
			}
				
			public System.String ModuleID
			{
				get
				{
					System.Int32? data = entity.ModuleID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ModuleID = null;
					else entity.ModuleID = Convert.ToInt32(value);
				}
			}
				
			public System.String Title
			{
				get
				{
					System.String data = entity.Title;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Title = null;
					else entity.Title = Convert.ToString(value);
				}
			}
				
			public System.String Body
			{
				get
				{
					System.String data = entity.Body;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Body = null;
					else entity.Body = Convert.ToString(value);
				}
			}
				
			public System.String IsVisible
			{
				get
				{
					System.Boolean? data = entity.IsVisible;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsVisible = null;
					else entity.IsVisible = Convert.ToBoolean(value);
				}
			}
				
			public System.String DisplayOrder
			{
				get
				{
					System.Int32? data = entity.DisplayOrder;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DisplayOrder = null;
					else entity.DisplayOrder = Convert.ToInt32(value);
				}
			}
				
			public System.String CreatedDate
			{
				get
				{
					System.DateTime? data = entity.CreatedDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CreatedDate = null;
					else entity.CreatedDate = Convert.ToDateTime(value);
				}
			}
				
			public System.String ModifiedDate
			{
				get
				{
					System.DateTime? data = entity.ModifiedDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ModifiedDate = null;
					else entity.ModifiedDate = Convert.ToDateTime(value);
				}
			}
				
			public System.String Thumbnail
			{
				get
				{
					System.String data = entity.Thumbnail;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Thumbnail = null;
					else entity.Thumbnail = Convert.ToString(value);
				}
			}
				
			public System.String CustomField1
			{
				get
				{
					System.String data = entity.CustomField1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomField1 = null;
					else entity.CustomField1 = Convert.ToString(value);
				}
			}
				
			public System.String CustomField2
			{
				get
				{
					System.String data = entity.CustomField2;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomField2 = null;
					else entity.CustomField2 = Convert.ToString(value);
				}
			}
				
			public System.String CustomField3
			{
				get
				{
					System.String data = entity.CustomField3;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomField3 = null;
					else entity.CustomField3 = Convert.ToString(value);
				}
			}
				
			public System.String ViewPermissions
			{
				get
				{
					System.String data = entity.ViewPermissions;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ViewPermissions = null;
					else entity.ViewPermissions = Convert.ToString(value);
				}
			}
			

			private esSlide entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SlideMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SlideQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SlideQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SlideQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SlideQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SlideQuery query;		
	}



	[Serializable]
	abstract public partial class esSlideCollection : esEntityCollection<Slide>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SlideMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SlideCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SlideQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SlideQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SlideQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SlideQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SlideQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SlideQuery)query);
		}

		#endregion
		
		private SlideQuery query;
	}



	[Serializable]
	abstract public partial class esSlideQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return SlideMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "PortalID": return this.PortalID;
				case "ModuleID": return this.ModuleID;
				case "Title": return this.Title;
				case "Body": return this.Body;
				case "IsVisible": return this.IsVisible;
				case "DisplayOrder": return this.DisplayOrder;
				case "CreatedDate": return this.CreatedDate;
				case "ModifiedDate": return this.ModifiedDate;
				case "Thumbnail": return this.Thumbnail;
				case "CustomField1": return this.CustomField1;
				case "CustomField2": return this.CustomField2;
				case "CustomField3": return this.CustomField3;
				case "ViewPermissions": return this.ViewPermissions;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem PortalID
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.PortalID, esSystemType.Int32); }
		} 
		
		public esQueryItem ModuleID
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.ModuleID, esSystemType.Int32); }
		} 
		
		public esQueryItem Title
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.Title, esSystemType.String); }
		} 
		
		public esQueryItem Body
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.Body, esSystemType.String); }
		} 
		
		public esQueryItem IsVisible
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.IsVisible, esSystemType.Boolean); }
		} 
		
		public esQueryItem DisplayOrder
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.DisplayOrder, esSystemType.Int32); }
		} 
		
		public esQueryItem CreatedDate
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.CreatedDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem ModifiedDate
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.ModifiedDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem Thumbnail
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.Thumbnail, esSystemType.String); }
		} 
		
		public esQueryItem CustomField1
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.CustomField1, esSystemType.String); }
		} 
		
		public esQueryItem CustomField2
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.CustomField2, esSystemType.String); }
		} 
		
		public esQueryItem CustomField3
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.CustomField3, esSystemType.String); }
		} 
		
		public esQueryItem ViewPermissions
		{
			get { return new esQueryItem(this, SlideMetadata.ColumnNames.ViewPermissions, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Slide : esSlide
	{

		
		
	}
	



	[Serializable]
	public partial class SlideMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SlideMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SlideMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SlideMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.PortalID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SlideMetadata.PropertyNames.PortalID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.ModuleID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SlideMetadata.PropertyNames.ModuleID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.Title, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = SlideMetadata.PropertyNames.Title;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.Body, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = SlideMetadata.PropertyNames.Body;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.IsVisible, 5, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = SlideMetadata.PropertyNames.IsVisible;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.DisplayOrder, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SlideMetadata.PropertyNames.DisplayOrder;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.CreatedDate, 7, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = SlideMetadata.PropertyNames.CreatedDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.ModifiedDate, 8, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = SlideMetadata.PropertyNames.ModifiedDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.Thumbnail, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = SlideMetadata.PropertyNames.Thumbnail;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.CustomField1, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = SlideMetadata.PropertyNames.CustomField1;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.CustomField2, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = SlideMetadata.PropertyNames.CustomField2;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.CustomField3, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = SlideMetadata.PropertyNames.CustomField3;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SlideMetadata.ColumnNames.ViewPermissions, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = SlideMetadata.PropertyNames.ViewPermissions;
			c.CharacterMaxLength = 150;
			c.HasDefault = true;
			c.Default = @"('-1')";
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SlideMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string Id = "ID";
			 public const string PortalID = "PortalID";
			 public const string ModuleID = "ModuleID";
			 public const string Title = "Title";
			 public const string Body = "Body";
			 public const string IsVisible = "IsVisible";
			 public const string DisplayOrder = "DisplayOrder";
			 public const string CreatedDate = "CreatedDate";
			 public const string ModifiedDate = "ModifiedDate";
			 public const string Thumbnail = "Thumbnail";
			 public const string CustomField1 = "CustomField1";
			 public const string CustomField2 = "CustomField2";
			 public const string CustomField3 = "CustomField3";
			 public const string ViewPermissions = "ViewPermissions";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string PortalID = "PortalID";
			 public const string ModuleID = "ModuleID";
			 public const string Title = "Title";
			 public const string Body = "Body";
			 public const string IsVisible = "IsVisible";
			 public const string DisplayOrder = "DisplayOrder";
			 public const string CreatedDate = "CreatedDate";
			 public const string ModifiedDate = "ModifiedDate";
			 public const string Thumbnail = "Thumbnail";
			 public const string CustomField1 = "CustomField1";
			 public const string CustomField2 = "CustomField2";
			 public const string CustomField3 = "CustomField3";
			 public const string ViewPermissions = "ViewPermissions";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(SlideMetadata))
			{
				if(SlideMetadata.mapDelegates == null)
				{
					SlideMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SlideMetadata.meta == null)
				{
					SlideMetadata.meta = new SlideMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("PortalID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ModuleID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Title", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Body", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("IsVisible", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("DisplayOrder", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("CreatedDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ModifiedDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Thumbnail", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CustomField1", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CustomField2", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CustomField3", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ViewPermissions", new esTypeMap("varchar", "System.String"));			
				
				
				
				ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration("data");
				Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];

				string objectQualifier = provider.Attributes["objectQualifier"];

				if ((objectQualifier != string.Empty) && (objectQualifier.EndsWith("_") == false))
				{
					objectQualifier += "_";
				}

				if (objectQualifier != string.Empty)
				{
					meta.Source = objectQualifier + "DNNspot_Rotator_Slides";
					meta.Destination = objectQualifier + "DNNspot_Rotator_Slides";
					
					meta.spInsert = objectQualifier + "proc_DNNspot_Rotator_SlidesInsert";				
					meta.spUpdate = objectQualifier + "proc_DNNspot_Rotator_SlidesUpdate";		
					meta.spDelete = objectQualifier + "proc_DNNspot_Rotator_SlidesDelete";
					meta.spLoadAll = objectQualifier + "proc_DNNspot_Rotator_SlidesLoadAll";
					meta.spLoadByPrimaryKey = objectQualifier + "proc_DNNspot_Rotator_SlidesLoadByPrimaryKey";
				}
				else
				{
					meta.Source = "DNNspot_Rotator_Slides";
					meta.Destination = "DNNspot_Rotator_Slides";
									
					meta.spInsert = "proc_DNNspot_Rotator_SlidesInsert";				
					meta.spUpdate = "proc_DNNspot_Rotator_SlidesUpdate";		
					meta.spDelete = "proc_DNNspot_Rotator_SlidesDelete";
					meta.spLoadAll = "proc_DNNspot_Rotator_SlidesLoadAll";
					meta.spLoadByPrimaryKey = "proc_DNNspot_Rotator_SlidesLoadByPrimaryKey";
				}
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SlideMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
