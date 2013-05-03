
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 4/12/2013 1:14:08 PM
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
	/// Encapsulates the 'DNNspot_Rotator_Templates' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Template))]	
	[XmlType("Template")]
	public partial class Template : esTemplate
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Template();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new Template();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new Template();
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
	[XmlType("TemplateCollection")]
	public partial class TemplateCollection : esTemplateCollection, IEnumerable<Template>
	{
		public Template FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Template))]
		public class TemplateCollectionWCFPacket : esCollectionWCFPacket<TemplateCollection>
		{
			public static implicit operator TemplateCollection(TemplateCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator TemplateCollectionWCFPacket(TemplateCollection collection)
			{
				return new TemplateCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class TemplateQuery : esTemplateQuery
	{
		public TemplateQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "TemplateQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(TemplateQuery query)
		{
			return TemplateQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator TemplateQuery(string query)
		{
			return (TemplateQuery)TemplateQuery.SerializeHelper.FromXml(query, typeof(TemplateQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esTemplate : esEntity
	{
		public esTemplate()
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
			TemplateQuery query = new TemplateQuery();
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
		/// Maps to DNNspot_Rotator_Templates.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(TemplateMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(TemplateMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(TemplateMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Templates.PortalID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? PortalID
		{
			get
			{
				return base.GetSystemInt32(TemplateMetadata.ColumnNames.PortalID);
			}
			
			set
			{
				if(base.SetSystemInt32(TemplateMetadata.ColumnNames.PortalID, value))
				{
					OnPropertyChanged(TemplateMetadata.PropertyNames.PortalID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Templates.ModuleID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ModuleID
		{
			get
			{
				return base.GetSystemInt32(TemplateMetadata.ColumnNames.ModuleID);
			}
			
			set
			{
				if(base.SetSystemInt32(TemplateMetadata.ColumnNames.ModuleID, value))
				{
					OnPropertyChanged(TemplateMetadata.PropertyNames.ModuleID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Templates.Title
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Title
		{
			get
			{
				return base.GetSystemString(TemplateMetadata.ColumnNames.Title);
			}
			
			set
			{
				if(base.SetSystemString(TemplateMetadata.ColumnNames.Title, value))
				{
					OnPropertyChanged(TemplateMetadata.PropertyNames.Title);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Templates.Body
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Body
		{
			get
			{
				return base.GetSystemString(TemplateMetadata.ColumnNames.Body);
			}
			
			set
			{
				if(base.SetSystemString(TemplateMetadata.ColumnNames.Body, value))
				{
					OnPropertyChanged(TemplateMetadata.PropertyNames.Body);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Templates.CreatedDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? CreatedDate
		{
			get
			{
				return base.GetSystemDateTime(TemplateMetadata.ColumnNames.CreatedDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(TemplateMetadata.ColumnNames.CreatedDate, value))
				{
					OnPropertyChanged(TemplateMetadata.PropertyNames.CreatedDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DNNspot_Rotator_Templates.ModifiedDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? ModifiedDate
		{
			get
			{
				return base.GetSystemDateTime(TemplateMetadata.ColumnNames.ModifiedDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(TemplateMetadata.ColumnNames.ModifiedDate, value))
				{
					OnPropertyChanged(TemplateMetadata.PropertyNames.ModifiedDate);
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
						case "CreatedDate": this.str().CreatedDate = (string)value; break;							
						case "ModifiedDate": this.str().ModifiedDate = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(TemplateMetadata.PropertyNames.Id);
							break;
						
						case "PortalID":
						
							if (value == null || value is System.Int32)
								this.PortalID = (System.Int32?)value;
								OnPropertyChanged(TemplateMetadata.PropertyNames.PortalID);
							break;
						
						case "ModuleID":
						
							if (value == null || value is System.Int32)
								this.ModuleID = (System.Int32?)value;
								OnPropertyChanged(TemplateMetadata.PropertyNames.ModuleID);
							break;
						
						case "CreatedDate":
						
							if (value == null || value is System.DateTime)
								this.CreatedDate = (System.DateTime?)value;
								OnPropertyChanged(TemplateMetadata.PropertyNames.CreatedDate);
							break;
						
						case "ModifiedDate":
						
							if (value == null || value is System.DateTime)
								this.ModifiedDate = (System.DateTime?)value;
								OnPropertyChanged(TemplateMetadata.PropertyNames.ModifiedDate);
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
			public esStrings(esTemplate entity)
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
			

			private esTemplate entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return TemplateMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public TemplateQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TemplateQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TemplateQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(TemplateQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private TemplateQuery query;		
	}



	[Serializable]
	abstract public partial class esTemplateCollection : esEntityCollection<Template>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TemplateMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "TemplateCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public TemplateQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TemplateQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TemplateQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TemplateQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(TemplateQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((TemplateQuery)query);
		}

		#endregion
		
		private TemplateQuery query;
	}



	[Serializable]
	abstract public partial class esTemplateQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return TemplateMetadata.Meta();
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
				case "CreatedDate": return this.CreatedDate;
				case "ModifiedDate": return this.ModifiedDate;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, TemplateMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem PortalID
		{
			get { return new esQueryItem(this, TemplateMetadata.ColumnNames.PortalID, esSystemType.Int32); }
		} 
		
		public esQueryItem ModuleID
		{
			get { return new esQueryItem(this, TemplateMetadata.ColumnNames.ModuleID, esSystemType.Int32); }
		} 
		
		public esQueryItem Title
		{
			get { return new esQueryItem(this, TemplateMetadata.ColumnNames.Title, esSystemType.String); }
		} 
		
		public esQueryItem Body
		{
			get { return new esQueryItem(this, TemplateMetadata.ColumnNames.Body, esSystemType.String); }
		} 
		
		public esQueryItem CreatedDate
		{
			get { return new esQueryItem(this, TemplateMetadata.ColumnNames.CreatedDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem ModifiedDate
		{
			get { return new esQueryItem(this, TemplateMetadata.ColumnNames.ModifiedDate, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}


	
	public partial class Template : esTemplate
	{

		
		
	}
	



	[Serializable]
	public partial class TemplateMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TemplateMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TemplateMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TemplateMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TemplateMetadata.ColumnNames.PortalID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TemplateMetadata.PropertyNames.PortalID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TemplateMetadata.ColumnNames.ModuleID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TemplateMetadata.PropertyNames.ModuleID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TemplateMetadata.ColumnNames.Title, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = TemplateMetadata.PropertyNames.Title;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TemplateMetadata.ColumnNames.Body, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = TemplateMetadata.PropertyNames.Body;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TemplateMetadata.ColumnNames.CreatedDate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = TemplateMetadata.PropertyNames.CreatedDate;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TemplateMetadata.ColumnNames.ModifiedDate, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = TemplateMetadata.PropertyNames.ModifiedDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public TemplateMetadata Meta()
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
			 public const string CreatedDate = "CreatedDate";
			 public const string ModifiedDate = "ModifiedDate";
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
			 public const string CreatedDate = "CreatedDate";
			 public const string ModifiedDate = "ModifiedDate";
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
			lock (typeof(TemplateMetadata))
			{
				if(TemplateMetadata.mapDelegates == null)
				{
					TemplateMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TemplateMetadata.meta == null)
				{
					TemplateMetadata.meta = new TemplateMetadata();
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
				meta.AddTypeMap("CreatedDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ModifiedDate", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration("data");
				Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];

				string objectQualifier = provider.Attributes["objectQualifier"];

				if ((objectQualifier != string.Empty) && (objectQualifier.EndsWith("_") == false))
				{
					objectQualifier += "_";
				}

				if (objectQualifier != string.Empty)
				{
					meta.Source = objectQualifier + "DNNspot_Rotator_Templates";
					meta.Destination = objectQualifier + "DNNspot_Rotator_Templates";
					
					meta.spInsert = objectQualifier + "proc_DNNspot_Rotator_TemplatesInsert";				
					meta.spUpdate = objectQualifier + "proc_DNNspot_Rotator_TemplatesUpdate";		
					meta.spDelete = objectQualifier + "proc_DNNspot_Rotator_TemplatesDelete";
					meta.spLoadAll = objectQualifier + "proc_DNNspot_Rotator_TemplatesLoadAll";
					meta.spLoadByPrimaryKey = objectQualifier + "proc_DNNspot_Rotator_TemplatesLoadByPrimaryKey";
				}
				else
				{
					meta.Source = "DNNspot_Rotator_Templates";
					meta.Destination = "DNNspot_Rotator_Templates";
									
					meta.spInsert = "proc_DNNspot_Rotator_TemplatesInsert";				
					meta.spUpdate = "proc_DNNspot_Rotator_TemplatesUpdate";		
					meta.spDelete = "proc_DNNspot_Rotator_TemplatesDelete";
					meta.spLoadAll = "proc_DNNspot_Rotator_TemplatesLoadAll";
					meta.spLoadByPrimaryKey = "proc_DNNspot_Rotator_TemplatesLoadByPrimaryKey";
				}
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TemplateMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
