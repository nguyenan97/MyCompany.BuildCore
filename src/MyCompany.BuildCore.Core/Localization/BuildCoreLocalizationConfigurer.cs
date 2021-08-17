using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyCompany.BuildCore.Localization
{
    public static class BuildCoreLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BuildCoreConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BuildCoreLocalizationConfigurer).GetAssembly(),
                        "MyCompany.BuildCore.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
