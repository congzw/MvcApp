namespace CommonFx.ConfigGroups
{
    public static class ConfigGroupRegistryExtensionsForDefault
    {
        public static string ConfigGroupDefault = "Default";
        public static ConfigGroup Default(this ConfigGroupRegistry registry)
        {
            return registry.CreateIf(ConfigGroupDefault);
        }
    }
}
