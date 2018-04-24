﻿using System;
using CorePCL.Generation.Repository;
using CorePCL.Generation.Repository.Implementation;
using SourceConsole.Factory;
using SourceConsole.Templates.DataModel;
using CorePCL.Generation.DataModel;

namespace SourceConsole.Repository.Implementation
{
    public class XamarinFormsRepository
    {
        public void GenerateXamarinScreen()
        {
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            IGenerationReposetory<GroupTemplateDataModel> repo =
                new GenerationReposetory<GroupTemplateDataModel>(new FileService(), new SimpleCSharpProjectFactory(readerRepo));
            Func<string> getScreenName = () =>
            {
                Console.Write("Screen Name:");
                return Console.ReadLine();
            };
            var screenData = repo.GetBaseDataModel(getScreenName());
            screenData.ProjectName = readerRepo.GetProjectName();
            Func<string> getEventName = () =>
            {
                Console.Write("Event Name:");
                return Console.ReadLine();
            };
            screenData.EventName = getEventName();
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewModelTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewCodeBehindTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.NormalTemplates.ViewControllerInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.ViewControllerTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.RepositoryInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.RepositoryTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.ServiceInterfaceTemplate, GroupTemplateDataModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Scafholding.ReturningServiceTemplates.ServiceTemplate, GroupTemplateDataModel>(readerRepo));
        }

        public void GenerateXamarinPreSetup()
        {
            IProjectReaderRepository readerRepo = new ProjectReaderRepository(new FileService());
            IGenerationReposetory<PreSetupTemplateModel> repo =
                new GenerationReposetory<PreSetupTemplateModel>(new FileService(), new SimpleCSharpProjectFactory(readerRepo));
            var screenData = repo.GetBaseDataModel("App2");
            screenData.ProjectName = readerRepo.GetProjectName();

            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Framework.AppXamlTemplate, PreSetupTemplateModel>(readerRepo));
            repo.WriteTemplateToFile(screenData, new SourceFileMapRepository<Templates.Framework.AppCodeBehindTemplate, PreSetupTemplateModel>(readerRepo));
        }
    }
}
