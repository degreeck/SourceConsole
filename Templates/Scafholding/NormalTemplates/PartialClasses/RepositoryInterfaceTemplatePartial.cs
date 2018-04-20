﻿using CorePCL.Generation.Templates;
using CorePCL.Generation.Templates.Extensions;
using CorePCL.Generation.Templates.PartialClasses;
using SourceConsole.Repository.Implementation;
using SourceConsole.Templates.DataModel;

namespace SourceConsole.Templates.Scafholding.NormalTemplates
{
    partial class RepositoryInterfaceTemplate : ITemplate<GroupTemplateDataModel>
    {
        public string FullProjectFileName => this.GetFullProjectFileName<RepositoryInterfaceTemplate, GroupTemplateDataModel>();

        public SourceEnum TemplateEnum => SourceEnum.RepositoryInterface;

        public TemplateEnum TemplateType => CorePCL.Generation.Templates.PartialClasses.TemplateEnum.Normal;

        public GroupTemplateDataModel DataModel { get; set; }

        public string GetFileName()
        {
            return this.GetFileName(
                new SourceFileMapRepository<RepositoryInterfaceTemplate, GroupTemplateDataModel>(
                    new ProjectReaderRepository(new FileService())), DataModel.RepositoryInterfaceName);
        }
    }
}
