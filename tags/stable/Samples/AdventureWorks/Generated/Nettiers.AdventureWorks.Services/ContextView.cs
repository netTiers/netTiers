﻿#region Using directives
using System;
using System.ComponentModel;
using System.Security;
using System.Web.Security;
using System.Security.Principal;
using System.Web.Profile;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

using Microsoft.Practices.EnterpriseLibrary.Security;
#endregion Using directives

namespace Nettiers.AdventureWorks.Services
{
    /// <summary>
    /// Used to create a general view of the current context.  
    /// Useful for firing events and giving the UI a picture of 
    /// current State of Operation.
    /// </summary>
    /// <typeparam name="Entity">The Entity object</typeparam>
    /// <typeparam name="Domain">Type that holds </typeparam>
	public class ContextView<Entity, Domain> where Entity : IEntity, new() where Domain : class
	{
		#region Fields
		#endregion Fields

		#region Properties
		private Entity persistingObject;
        /// <summary>
        /// Gets or sets the persisting object.
        /// </summary>
        /// <value>The persisting object.</value>
		public Entity PersistingObject
		{
			get { return persistingObject; }	
			set	{ persistingObject = value;	}
		}

		private SecurityContext<Entity> securityContext;
        /// <summary>
        /// Gets or sets the security context.
        /// </summary>
        /// <value>The security context.</value>
        public SecurityContext<Entity> SecurityContext
		{
			get { return securityContext; }	
			set	{ securityContext = value; }
		}

		private TransactionManager transactionManager; 
        /// <summary>
        /// Gets or sets the transaction manager.
        /// </summary>
        /// <value>The transaction manager.</value>
		public TransactionManager TransactionManager
		{
			get { return transactionManager; }
			set { transactionManager = value; }
		}
		#endregion Properties		
		
		#region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextView&lt;Entity, Domain&gt;"/> class.
        /// </summary>
		public ContextView()
		{
		}
		
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextView&lt;Entity, Domain&gt;"/> class.
        /// </summary>
        /// <param name="persistingObject">The persisting object.</param>
        /// <param name="securityContext">The security context.</param>
        public ContextView(Entity persistingObject, SecurityContext<Entity> securityContext)
		{
			this.persistingObject = persistingObject;
			this.securityContext = securityContext;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextView&lt;Entity, Domain&gt;"/> class.
        /// </summary>
        /// <param name="persistingObject">The persisting object.</param>
        /// <param name="securityContext">The security context.</param>
        /// <param name="transactionManager">The transaction manager.</param>
        public ContextView(Entity persistingObject, SecurityContext<Entity> securityContext, TransactionManager transactionManager)
		{
			this.persistingObject = persistingObject;
			this.securityContext = securityContext;
			this.transactionManager = transactionManager;
		}
		#endregion Constructors		
	}	
}
