		#region Templates
		
			CodeTemplates.Add("NetTiersMapInstance.Internal.cst", base.CreateTemplate<MappingInstance>()); this.PerformStep();
			CodeTemplates.Add("vsnet2005.project.cst", base.CreateTemplate<vsnet2005Project>()); this.PerformStep();
			CodeTemplates.Add("vsnet2005.solution.cst", base.CreateTemplate<vsnet2005Solution>()); this.PerformStep();
			CodeTemplates.Add("vsnet2005.vsmdi.cst", base.CreateTemplate<vsnet2005Vsmdi>()); this.PerformStep();
			CodeTemplates.Add("vsnet2005.localtestrun.testrunconfig.cst", base.CreateTemplate<vsnet2005LocaltestrunTestrunconfig>()); this.PerformStep();
			CodeTemplates.Add("nAnt.cst", base.CreateTemplate<nAnt>()); this.PerformStep();
			CodeTemplates.Add("AssemblyInfo.cst", base.CreateTemplate<AssemblyInfo>()); this.PerformStep(); 
			CodeTemplates.Add("entlib.v2.config.cst", base.CreateTemplate<entlibv2config>()); this.PerformStep();																												
			CodeTemplates.Add("entlib.v3.config.cst", base.CreateTemplate<entlibv3config>()); this.PerformStep();																												
			CodeTemplates.Add("entlib.v3_1.config.cst", base.CreateTemplate<entlibv3_1config>()); this.PerformStep();																												
			CodeTemplates.Add("App.config.2005.cst", base.CreateTemplate<AppConfig>()); this.PerformStep();													
			CodeTemplates.Add("Enum.cst", base.CreateTemplate<Enum>()); this.PerformStep();
			CodeTemplates.Add("IEntity.cst", base.CreateTemplate<IEntity>()); this.PerformStep();
			CodeTemplates.Add("IEntityId.cst", base.CreateTemplate<IEntityId>()); this.PerformStep();
			CodeTemplates.Add("IEntityKey.cst", base.CreateTemplate<IEntityKey>()); this.PerformStep();
			CodeTemplates.Add("EntityBase.cst", base.CreateTemplate<EntityBase>()); this.PerformStep();
			CodeTemplates.Add("EntityBaseCore.generated.cst", base.CreateTemplate<EntityBaseCoreGenerated>()); this.PerformStep();
			CodeTemplates.Add("EntityKeyBase.cst", base.CreateTemplate<EntityKeyBase>()); this.PerformStep();
			CodeTemplates.Add("EntityKeyBaseCore.generated.cst", base.CreateTemplate<EntityKeyBaseCoreGenerated>()); this.PerformStep();
			CodeTemplates.Add("EntityFilter.cst", base.CreateTemplate<EntityFilter>()); this.PerformStep();
			CodeTemplates.Add("EntityHelper.cst", base.CreateTemplate<EntityHelper>()); this.PerformStep();	
			CodeTemplates.Add("EntityUtil.cst", base.CreateTemplate<EntityUtil>()); this.PerformStep();	
			CodeTemplates.Add("EntityPropertyComparer.cst", base.CreateTemplate<EntityPropertyComparer>()); this.PerformStep(); 
			CodeTemplates.Add("GenericTypeConverter.cst", base.CreateTemplate<GenericTypeConverter>()); this.PerformStep(); 
																
			CodeTemplates.Add("EntityFactory.cst", base.CreateTemplate<EntityFactory>()); this.PerformStep();
			CodeTemplates.Add("EntityFactoryBase.cst", base.CreateTemplate<EntityFactoryBase>()); this.PerformStep();
			CodeTemplates.Add("EntityCache.cst", base.CreateTemplate<EntityCache>()); this.PerformStep();
			CodeTemplates.Add("EntityLocator.cst", base.CreateTemplate<EntityLocator>()); this.PerformStep();
			CodeTemplates.Add("EntityManager.cst", base.CreateTemplate<EntityManager>()); this.PerformStep();
			CodeTemplates.Add("IEntityFactory.cst", base.CreateTemplate<IEntityFactory>()); this.PerformStep();
			CodeTemplates.Add("IEntityCacheItem.cst", base.CreateTemplate<IEntityCacheItem>()); this.PerformStep();
			
			CodeTemplates.Add("EntityInstanceBase.generated.cst", base.CreateTemplate<EntityInstanceBaseGenerated>()); this.PerformStep();
			CodeTemplates.Add("IEntityInstance.cst", base.CreateTemplate<IEntityInstance>()); this.PerformStep();
			CodeTemplates.Add("EntityData.cst", base.CreateTemplate<EntityData>()); this.PerformStep();
			CodeTemplates.Add("EntityInstance.cst", base.CreateTemplate<EntityInstance>()); this.PerformStep();
			CodeTemplates.Add("TList.cst", base.CreateTemplate<TList>()); this.PerformStep(); 
			CodeTemplates.Add("ListBase.cst", base.CreateTemplate<ListBase>()); this.PerformStep();
																	
			CodeTemplates.Add("VList.cst", base.CreateTemplate<VList>()); this.PerformStep();
			CodeTemplates.Add("EntityViewBase.generated.cst", base.CreateTemplate<EntityViewBaseGenerated>()); this.PerformStep();
			CodeTemplates.Add("EntityView.cst", base.CreateTemplate<EntityView>()); this.PerformStep();
																	
			CodeTemplates.Add("BrokenRule.cst", base.CreateTemplate<BrokenRule>()); this.PerformStep();
			CodeTemplates.Add("BrokenRulesList.cst", base.CreateTemplate<BrokenRulesList>()); this.PerformStep();
			CodeTemplates.Add("CommonRules.cst", base.CreateTemplate<CommonRules>()); this.PerformStep();
			CodeTemplates.Add("ValidationRuleArgs.cst", base.CreateTemplate<ValidationRuleArgs>()); this.PerformStep();
			CodeTemplates.Add("ValidationRuleHandler.cst", base.CreateTemplate<ValidationRuleHandler>()); this.PerformStep();
			CodeTemplates.Add("ValidationRuleInfo.cst", base.CreateTemplate<ValidationRuleInfo>()); this.PerformStep();
			CodeTemplates.Add("ValidationRules.cst", base.CreateTemplate<ValidationRules>()); this.PerformStep();
																															
			CodeTemplates.Add("Component.cst", base.CreateTemplate<Component>()); this.PerformStep();
			CodeTemplates.Add("ComponentBase.cst", base.CreateTemplate<ComponentBase>()); this.PerformStep();
			CodeTemplates.Add("ComponentService.cst", base.CreateTemplate<ComponentService>()); this.PerformStep();
			CodeTemplates.Add("ComponentServiceBase.cst", base.CreateTemplate<ComponentServiceBase>()); this.PerformStep();
																	
			CodeTemplates.Add("ComponentViewService.cst", base.CreateTemplate<ComponentViewService>()); this.PerformStep();
			CodeTemplates.Add("ComponentViewServiceBase.cst", base.CreateTemplate<ComponentViewServiceBase>()); this.PerformStep();														

			CodeTemplates.Add("ComponentDataAccess.cst", base.CreateTemplate<ComponentDataAccess>()); this.PerformStep();
			CodeTemplates.Add("ComponentViewDataAccess.cst", base.CreateTemplate<ComponentViewDataAccess>()); this.PerformStep();

			CodeTemplates.Add("ComponentView.cst", base.CreateTemplate<ComponentView>()); this.PerformStep();
			CodeTemplates.Add("ComponentViewBase.cst", base.CreateTemplate<ComponentViewBase>()); this.PerformStep();														
			
			
			CodeTemplates.Add("IComponentEntity.cst", base.CreateTemplate<IComponentEntity>()); this.PerformStep();
			CodeTemplates.Add("ConnectionScope.cst", base.CreateTemplate<ConnectionScope>()); this.PerformStep();
			CodeTemplates.Add("DomainUtil.cst", base.CreateTemplate<DomainUtil>()); this.PerformStep();
			CodeTemplates.Add("IComponentService.cst", base.CreateTemplate<IComponentService>()); this.PerformStep();
			CodeTemplates.Add("ServiceBase.cst", base.CreateTemplate<ServiceBase>()); this.PerformStep();
			CodeTemplates.Add("ServiceBaseCore.cst", base.CreateTemplate<ServiceBaseCore>()); this.PerformStep();
			
			CodeTemplates.Add("ServiceViewBase.cst", base.CreateTemplate<ServiceViewBase>()); this.PerformStep();
			CodeTemplates.Add("ServiceViewBaseCore.cst", base.CreateTemplate<ServiceViewBaseCore>()); this.PerformStep();
																	
			CodeTemplates.Add("ServiceResult.cst", base.CreateTemplate<ServiceResult>()); this.PerformStep();
			CodeTemplates.Add("ComponentEntityFactory.cst", base.CreateTemplate<ComponentEntityFactory>()); this.PerformStep();
			CodeTemplates.Add("IProcessor.cst", base.CreateTemplate<IProcessor>()); this.PerformStep();
			CodeTemplates.Add("IProcessorResult.cst", base.CreateTemplate<IProcessorResult>()); this.PerformStep();
			CodeTemplates.Add("ProcessorBase.cst", base.CreateTemplate<ProcessorBase>()); this.PerformStep();
			CodeTemplates.Add("GenericProcessorResult.cst", base.CreateTemplate<GenericProcessorResult>()); this.PerformStep();
			CodeTemplates.Add("SecurityContext.cst", base.CreateTemplate<SecurityContext>()); this.PerformStep();														
																															
																																													
			CodeTemplates.Add("DataRepository.cst", base.CreateTemplate<DataRepository>()); this.PerformStep();
			CodeTemplates.Add("Utility.cst", base.CreateTemplate<Utility>()); this.PerformStep();
			CodeTemplates.Add("TransactionManager.cst", base.CreateTemplate<TransactionManager>()); this.PerformStep();
			CodeTemplates.Add("IEntityProvider.cst", base.CreateTemplate<IEntityProvider>()); this.PerformStep();
			CodeTemplates.Add("IEntityViewProvider.cst", base.CreateTemplate<IEntityViewProvider>()); this.PerformStep();
																																													
			CodeTemplates.Add("NetTiersProvider.cst", base.CreateTemplate<NetTiersProvider>()); this.PerformStep();							
			CodeTemplates.Add("NetTiersProviderCollection.cst", base.CreateTemplate<NetTiersProviderCollection>()); this.PerformStep();							
			CodeTemplates.Add("NetTiersServiceSection.cst", base.CreateTemplate<NetTiersServiceSection>()); this.PerformStep();							
																	
			CodeTemplates.Add("EntityProviderBaseCore.generated.cst", base.CreateTemplate<EntityProviderBaseCoreGenerated>()); this.PerformStep();
			CodeTemplates.Add("EntityProviderBase.cst", base.CreateTemplate<EntityProviderBase>()); this.PerformStep();														
			CodeTemplates.Add("EntityViewProviderBase.cst", base.CreateTemplate<EntityViewProviderBase>()); this.PerformStep();														
			CodeTemplates.Add("EntityViewProviderBaseCore.generated.cst", base.CreateTemplate<EntityViewProviderBaseCoreGenerated>()); this.PerformStep();
																	
			CodeTemplates.Add("EntityProviderBaseClass.cst", base.CreateTemplate<EntityProviderBaseClass>()); this.PerformStep();														
			CodeTemplates.Add("EntityProviderBaseCoreClass.generated.cst", base.CreateTemplate<EntityProviderBaseCoreClassGenerated>()); this.PerformStep();
			CodeTemplates.Add("EntityViewProviderBaseClass.cst", base.CreateTemplate<EntityViewProviderBaseClass>()); this.PerformStep();														
			CodeTemplates.Add("EntityViewProviderBaseCoreClass.generated.cst", base.CreateTemplate<EntityViewProviderBaseCoreClassGenerated>()); this.PerformStep();
																																																										
			CodeTemplates.Add("ExpressionParserBase.cst", base.CreateTemplate<ExpressionParserBase>()); this.PerformStep();
			CodeTemplates.Add("SqlExpressionParser.cst", base.CreateTemplate<SqlExpressionParser>()); this.PerformStep();
			CodeTemplates.Add("SqlStringBuilder.cst", base.CreateTemplate<SqlStringBuilder>()); this.PerformStep();
			CodeTemplates.Add("SqlUtil.cst", base.CreateTemplate<SqlUtil>()); this.PerformStep();
			CodeTemplates.Add("StringTokenizer.cst", base.CreateTemplate<StringTokenizer>()); this.PerformStep();
																	
			CodeTemplates.Add("SqlNetTiersProvider.cst", base.CreateTemplate<SqlNetTiersProvider>()); this.PerformStep();
			CodeTemplates.Add("SqlEntityProviderBase.generated.cst", base.CreateTemplate<SqlEntityProviderBaseGenerated>()); this.PerformStep();
			CodeTemplates.Add("SqlEntityProvider.cst", base.CreateTemplate<SqlEntityProvider>()); this.PerformStep();
																	
			CodeTemplates.Add("StoredProcedureProvider.cst", base.CreateTemplate<StoredProcedureProvider>()); this.PerformStep();
			CodeTemplates.Add("StoredProceduresXml.cst", base.CreateTemplate<StoredProceduresXml>()); this.PerformStep();
																															
			CodeTemplates.Add("SqlEntityViewProviderBase.generated.cst", base.CreateTemplate<SqlEntityViewProviderBaseGenerated>()); this.PerformStep();
			CodeTemplates.Add("SqlEntityViewProvider.cst", base.CreateTemplate<SqlEntityViewProvider>()); this.PerformStep();
																															
			CodeTemplates.Add("GenericNetTiersProvider.cst", base.CreateTemplate<GenericNetTiersProvider>()); this.PerformStep();
			CodeTemplates.Add("GenericEntityProviderBase.generated.cst", base.CreateTemplate<GenericEntityProviderBaseGenerated>()); this.PerformStep();
			CodeTemplates.Add("GenericEntityProvider.cst", base.CreateTemplate<GenericEntityProvider>()); this.PerformStep();
																	
			CodeTemplates.Add("DbCommandManager.cst", base.CreateTemplate<DbCommandManager>()); this.PerformStep();
																	
			CodeTemplates.Add("System.Data.SQLite.Procedures.cst", base.CreateTemplate<SystemDataSQLiteProcedures>()); this.PerformStep();
			CodeTemplates.Add("System.Data.OleDb.Procedures.cst", base.CreateTemplate<SystemDataOleDbProcedures>()); this.PerformStep();
																															
																															
			CodeTemplates.Add("ServiceLayer.WebService.cst", base.CreateTemplate<ServiceLayerWebService>()); this.PerformStep();
			CodeTemplates.Add("WebService.cst", base.CreateTemplate<WebService>()); this.PerformStep();
			CodeTemplates.Add("WebInfo.cst", base.CreateTemplate<WebInfo>()); this.PerformStep();
																	
			CodeTemplates.Add("WsNetTiersProvider.cst", base.CreateTemplate<WsNetTiersProvider>()); this.PerformStep();
			CodeTemplates.Add("WsEntityProvider.cst", base.CreateTemplate<WsEntityProvider>()); this.PerformStep();
			CodeTemplates.Add("WsEntityProviderBase.generated.cst", base.CreateTemplate<WsEntityProviderBaseGenerated>()); this.PerformStep();
			CodeTemplates.Add("WsEntityViewProvider.cst", base.CreateTemplate<WsEntityViewProvider>()); this.PerformStep();
			CodeTemplates.Add("WsEntityViewProviderBase.generated.cst", base.CreateTemplate<WsEntityViewProviderBaseGenerated>()); this.PerformStep();
																	
																															
			CodeTemplates.Add("EntityRepositoryTest.cst", base.CreateTemplate<EntityRepositoryTest>()); this.PerformStep();
			CodeTemplates.Add("EntityRepositoryTest.generated.cst", base.CreateTemplate<EntityRepositoryTestGenerated>()); this.PerformStep();
			CodeTemplates.Add("EntityViewRepositoryTest.cst", base.CreateTemplate<EntityViewRepositoryTest>()); this.PerformStep();
			CodeTemplates.Add("EntityViewRepositoryTest.generated.cst", base.CreateTemplate<EntityViewRepositoryTestGenerated>()); this.PerformStep();
			CodeTemplates.Add("OrderedEntityRepositoryTestList.cst", base.CreateTemplate<OrderedEntityRepositoryTestList>()); this.PerformStep();
			CodeTemplates.Add("OrderedEntityViewRepositoryTestList.cst", base.CreateTemplate<OrderedEntityViewRepositoryTestList>()); this.PerformStep();
																	
			CodeTemplates.Add("AdminEntityUC_Designer.cst", base.CreateTemplate<AdminEntityUC_Designer>()); this.PerformStep();
			CodeTemplates.Add("AdminEntityUC_CodeBehind.cst", base.CreateTemplate<AdminEntityUC_CodeBehind>()); this.PerformStep();
			CodeTemplates.Add("Menu_xml.cst", base.CreateTemplate<Menu_xml>()); this.PerformStep();
																	
			CodeTemplates.Add("Default.aspx.cs.cst", base.CreateTemplate<DefaultAspxCs>()); this.PerformStep();
			CodeTemplates.Add("Default.aspx.cst", base.CreateTemplate<DefaultAspx>()); this.PerformStep();
			CodeTemplates.Add("WebConfig.cst", base.CreateTemplate<WebConfig>()); this.PerformStep();
			CodeTemplates.Add("WebConfigAtlas.cst", base.CreateTemplate<WebConfigAtlas>()); this.PerformStep();
			CodeTemplates.Add("Default.aspx.designer.cs.cst", base.CreateTemplate<DefaultAspxDesigner>()); this.PerformStep();
																	
			CodeTemplates.Add("BaseDataSource.cst", base.CreateTemplate<BaseDataSource>()); this.PerformStep();
			CodeTemplates.Add("BaseDataSourceDesigner.cst", base.CreateTemplate<BaseDataSourceDesigner>()); this.PerformStep();
			CodeTemplates.Add("CustomDataSource.cst", base.CreateTemplate<CustomDataSource>()); this.PerformStep();
			CodeTemplates.Add("CustomDataSourceDesigner.cst", base.CreateTemplate<CustomDataSourceDesigner>()); this.PerformStep();
			CodeTemplates.Add("CustomParameter.cst", base.CreateTemplate<CustomParameter>()); this.PerformStep();
			CodeTemplates.Add("DataParameter.cst", base.CreateTemplate<DataParameter>()); this.PerformStep();
			CodeTemplates.Add("EntityDataSource.cst", base.CreateTemplate<EntityDataSource>()); this.PerformStep();
			CodeTemplates.Add("EntityDataSourceFilter.cst", base.CreateTemplate<EntityDataSourceFilter>()); this.PerformStep();
			CodeTemplates.Add("EntityRelationship.cst", base.CreateTemplate<EntityRelationship>()); this.PerformStep();
			CodeTemplates.Add("EntityRelationshipMember.cst", base.CreateTemplate<EntityRelationshipMember>()); this.PerformStep();
			CodeTemplates.Add("EntityTransactionModule.cst", base.CreateTemplate<EntityTransactionModule>()); this.PerformStep();
			CodeTemplates.Add("ILinkedDataSource.cst", base.CreateTemplate<ILinkedDataSource>()); this.PerformStep();
			CodeTemplates.Add("ManyToManyListRelationship.cst", base.CreateTemplate<ManyToManyListRelationship>()); this.PerformStep();
			CodeTemplates.Add("ManyToManyViewRelationship.cst", base.CreateTemplate<ManyToManyViewRelationship>()); this.PerformStep();
			CodeTemplates.Add("OneToManyGridRelationship.cst", base.CreateTemplate<OneToManyGridRelationship>()); this.PerformStep();
			CodeTemplates.Add("OneToOneViewRelationship.cst", base.CreateTemplate<OneToOneViewRelationship>()); this.PerformStep();
			CodeTemplates.Add("ProviderDataSource.cst", base.CreateTemplate<ProviderDataSource>()); this.PerformStep();
			CodeTemplates.Add("ProviderDataSourceDesigner.cst", base.CreateTemplate<ProviderDataSourceDesigner>()); this.PerformStep();
			CodeTemplates.Add("ReadOnlyDataSource.cst", base.CreateTemplate<ReadOnlyDataSource>()); this.PerformStep();
			CodeTemplates.Add("ReadOnlyDataSourceDesigner.cst", base.CreateTemplate<ReadOnlyDataSourceDesigner>()); this.PerformStep();
			CodeTemplates.Add("SqlParameter.cst", base.CreateTemplate<SqlParameter>()); this.PerformStep();
			CodeTemplates.Add("TableDataSource.cst", base.CreateTemplate<TableDataSource>()); this.PerformStep();
			CodeTemplates.Add("ViewDataSource.cst", base.CreateTemplate<ViewDataSource>()); this.PerformStep();
																	
			CodeTemplates.Add("FormUtil.cst", base.CreateTemplate<FormUtil>()); this.PerformStep();
			CodeTemplates.Add("FormUtilBase.cst", base.CreateTemplate<FormUtilBase>()); this.PerformStep();
			CodeTemplates.Add("MultiBindableTemplate.cst", base.CreateTemplate<MultiBindableTemplate>()); this.PerformStep();
			CodeTemplates.Add("MultiFormView.cst", base.CreateTemplate<MultiFormView>()); this.PerformStep();
			CodeTemplates.Add("EntityGridView.cs.cst", base.CreateTemplate<EntityGridView>()); this.PerformStep();
			CodeTemplates.Add("EntityDropDownList.cs.cst", base.CreateTemplate<EntityDropDownList>()); this.PerformStep();
			CodeTemplates.Add("BoundEntityDropDownField.cs.cst", base.CreateTemplate<BoundEntityDropDownField>()); this.PerformStep();
			CodeTemplates.Add("BoundRadioButtonField.cs.cst", base.CreateTemplate<BoundRadioButtonField>()); this.PerformStep();			
			CodeTemplates.Add("GridViewSearchPanel.cs.cst", base.CreateTemplate<GridViewSearchPanel>()); this.PerformStep();
			CodeTemplates.Add("GridViewSearchPanelState.cs.cst", base.CreateTemplate<GridViewSearchPanelState>()); this.PerformStep();
			CodeTemplates.Add("EntityLabel.cs.cst", base.CreateTemplate<EntityLabel>()); this.PerformStep();
			CodeTemplates.Add("HyperlinkField.cs.cst", base.CreateTemplate<HyperlinkField>()); this.PerformStep();
																	
			CodeTemplates.Add("TableRepeater.cst", base.CreateTemplate<TableRepeater>()); this.PerformStep();
			CodeTemplates.Add("ViewRepeater.cst", base.CreateTemplate<ViewRepeater>()); this.PerformStep();
																	
			CodeTemplates.Add("Entity.aspx.cst", base.CreateTemplate<EntityAspx>()); this.PerformStep();
			CodeTemplates.Add("Entity.aspx.cs.cst", base.CreateTemplate<EntityAspxCs>()); this.PerformStep();
			CodeTemplates.Add("EntityEdit.aspx.cst", base.CreateTemplate<EntityEditAspx>()); this.PerformStep();
			CodeTemplates.Add("EntityEdit.aspx.cs.cst", base.CreateTemplate<EntityEditAspxCs>()); this.PerformStep();
			CodeTemplates.Add("EntityFields.ascx.cst", base.CreateTemplate<EntityFieldsAscx>()); this.PerformStep();
			CodeTemplates.Add("Web.Sitemap.cst", base.CreateTemplate<WebSitemap>()); this.PerformStep();
			CodeTemplates.Add("admin.master.cst", base.CreateTemplate<SiteMaster>()); this.PerformStep();
																	
			CodeTemplates.Add("TableEditControl.cst", base.CreateTemplate<TableEditControl>()); this.PerformStep();
			CodeTemplates.Add("TableEditControlBase.cst", base.CreateTemplate<TableEditControlBase>()); this.PerformStep();
			CodeTemplates.Add("TableGridView.cst", base.CreateTemplate<TableGridView>()); this.PerformStep();
			CodeTemplates.Add("TableGridViewBase.cst", base.CreateTemplate<TableGridViewBase>()); this.PerformStep();
			CodeTemplates.Add("TypedDataSource.cst", base.CreateTemplate<TypedDataSource>()); this.PerformStep();
	
		#endregion 
			