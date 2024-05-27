﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PTProject.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PTProject")]
	public partial class PTProjectDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Définitions de méthodes d'extensibilité
    partial void OnCreated();
    partial void InsertEvents(Events instance);
    partial void UpdateEvents(Events instance);
    partial void DeleteEvents(Events instance);
    partial void InsertGood(Good instance);
    partial void UpdateGood(Good instance);
    partial void DeleteGood(Good instance);
    partial void InsertProcessState(ProcessState instance);
    partial void UpdateProcessState(ProcessState instance);
    partial void DeleteProcessState(ProcessState instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public PTProjectDataContext() : 
				base(global::PTProject.Data.Properties.Settings.Default.PTProjectConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PTProjectDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PTProjectDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PTProjectDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PTProjectDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Events> Events
		{
			get
			{
				return this.GetTable<Events>();
			}
		}
		
		public System.Data.Linq.Table<Good> Good
		{
			get
			{
				return this.GetTable<Good>();
			}
		}
		
		public System.Data.Linq.Table<ProcessState> ProcessState
		{
			get
			{
				return this.GetTable<ProcessState>();
			}
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Events")]
	public partial class Events : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ProcessStateId;
		
		private System.DateTime _EventDate;
		
		private string _Description;
		
		private string _EventType;
		
		private EntityRef<ProcessState> _ProcessState;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnProcessStateIdChanging(int value);
    partial void OnProcessStateIdChanged();
    partial void OnEventDateChanging(System.DateTime value);
    partial void OnEventDateChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnEventTypeChanging(string value);
    partial void OnEventTypeChanged();
    #endregion
		
		public Events()
		{
			this._ProcessState = default(EntityRef<ProcessState>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessStateId", DbType="Int NOT NULL")]
		public int ProcessStateId
		{
			get
			{
				return this._ProcessStateId;
			}
			set
			{
				if ((this._ProcessStateId != value))
				{
					if (this._ProcessState.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProcessStateIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessStateId = value;
					this.SendPropertyChanged("ProcessStateId");
					this.OnProcessStateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventDate", DbType="DateTime NOT NULL")]
		public System.DateTime EventDate
		{
			get
			{
				return this._EventDate;
			}
			set
			{
				if ((this._EventDate != value))
				{
					this.OnEventDateChanging(value);
					this.SendPropertyChanging();
					this._EventDate = value;
					this.SendPropertyChanged("EventDate");
					this.OnEventDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventType", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string EventType
		{
			get
			{
				return this._EventType;
			}
			set
			{
				if ((this._EventType != value))
				{
					this.OnEventTypeChanging(value);
					this.SendPropertyChanging();
					this._EventType = value;
					this.SendPropertyChanged("EventType");
					this.OnEventTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProcessState_Events", Storage="_ProcessState", ThisKey="ProcessStateId", OtherKey="Id", IsForeignKey=true)]
		public ProcessState ProcessState
		{
			get
			{
				return this._ProcessState.Entity;
			}
			set
			{
				ProcessState previousValue = this._ProcessState.Entity;
				if (((previousValue != value) 
							|| (this._ProcessState.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProcessState.Entity = null;
						previousValue.Events.Remove(this);
					}
					this._ProcessState.Entity = value;
					if ((value != null))
					{
						value.Events.Add(this);
						this._ProcessStateId = value.Id;
					}
					else
					{
						this._ProcessStateId = default(int);
					}
					this.SendPropertyChanged("ProcessState");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Good")]
	public partial class Good : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Description;
		
		private int _Price;
		
		private string _Name;
		
		private int _Id;
		
		private EntitySet<ProcessState> _ProcessState;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnPriceChanging(int value);
    partial void OnPriceChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    #endregion
		
		public Good()
		{
			this._ProcessState = new EntitySet<ProcessState>(new Action<ProcessState>(this.attach_ProcessState), new Action<ProcessState>(this.detach_ProcessState));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(255)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Int NOT NULL")]
		public int Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Good_ProcessState", Storage="_ProcessState", ThisKey="Id", OtherKey="GoodId")]
		public EntitySet<ProcessState> ProcessState
		{
			get
			{
				return this._ProcessState;
			}
			set
			{
				this._ProcessState.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ProcessState(ProcessState entity)
		{
			this.SendPropertyChanging();
			entity.Good = this;
		}
		
		private void detach_ProcessState(ProcessState entity)
		{
			this.SendPropertyChanging();
			entity.Good = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProcessState")]
	public partial class ProcessState : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _UserId;
		
		private int _GoodId;
		
		private string _Description;
		
		private EntitySet<Events> _Events;
		
		private EntityRef<Good> _Good;
		
		private EntityRef<User> _User;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnGoodIdChanging(int value);
    partial void OnGoodIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public ProcessState()
		{
			this._Events = new EntitySet<Events>(new Action<Events>(this.attach_Events), new Action<Events>(this.detach_Events));
			this._Good = default(EntityRef<Good>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoodId", DbType="Int NOT NULL")]
		public int GoodId
		{
			get
			{
				return this._GoodId;
			}
			set
			{
				if ((this._GoodId != value))
				{
					if (this._Good.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGoodIdChanging(value);
					this.SendPropertyChanging();
					this._GoodId = value;
					this.SendPropertyChanged("GoodId");
					this.OnGoodIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProcessState_Events", Storage="_Events", ThisKey="Id", OtherKey="ProcessStateId")]
		public EntitySet<Events> Events
		{
			get
			{
				return this._Events;
			}
			set
			{
				this._Events.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Good_ProcessState", Storage="_Good", ThisKey="GoodId", OtherKey="Id", IsForeignKey=true)]
		public Good Good
		{
			get
			{
				return this._Good.Entity;
			}
			set
			{
				Good previousValue = this._Good.Entity;
				if (((previousValue != value) 
							|| (this._Good.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Good.Entity = null;
						previousValue.ProcessState.Remove(this);
					}
					this._Good.Entity = value;
					if ((value != null))
					{
						value.ProcessState.Add(this);
						this._GoodId = value.Id;
					}
					else
					{
						this._GoodId = default(int);
					}
					this.SendPropertyChanged("Good");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ProcessState", Storage="_User", ThisKey="UserId", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.ProcessState.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.ProcessState.Add(this);
						this._UserId = value.Id;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Events(Events entity)
		{
			this.SendPropertyChanging();
			entity.ProcessState = this;
		}
		
		private void detach_Events(Events entity)
		{
			this.SendPropertyChanging();
			entity.ProcessState = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _UserName;
		
		private int _Id;
		
		private EntitySet<ProcessState> _ProcessState;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    #endregion
		
		public User()
		{
			this._ProcessState = new EntitySet<ProcessState>(new Action<ProcessState>(this.attach_ProcessState), new Action<ProcessState>(this.detach_ProcessState));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ProcessState", Storage="_ProcessState", ThisKey="Id", OtherKey="UserId")]
		public EntitySet<ProcessState> ProcessState
		{
			get
			{
				return this._ProcessState;
			}
			set
			{
				this._ProcessState.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ProcessState(ProcessState entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_ProcessState(ProcessState entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
}
#pragma warning restore 1591
