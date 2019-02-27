namespace CommonFx.Web.JoinJsFiles
{
    public static class JoinJsFileRegistryExtensionsForRequireJs
    {
        public static string JoinJsFileKeyForRequireJs = "~/content/scripts/app_config_require.js";
        public static JoinJsFile RequireJs(this JoinJsFileRegistry registry)
        {
            return registry.CreateIf(JoinJsFileKeyForRequireJs);
        }
    }
}