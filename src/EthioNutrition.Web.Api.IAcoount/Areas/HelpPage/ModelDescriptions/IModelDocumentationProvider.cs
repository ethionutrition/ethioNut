using System;
using System.Reflection;

namespace EthioNutrition.Web.Api.IAcoount.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}