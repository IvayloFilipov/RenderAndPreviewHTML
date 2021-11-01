namespace RenderAndPreviewHTML.Common
{
    public static class GlobalConstants
    {
        // Common constants
        public const string SystemName = "RenderAndPreviewHTML";
        public const string AdministratorRoleName = "Administrator";

        // Content max size in MB
        public const int MaxSize5MB = 2621440;

        // Content max number of characters
        public const int MaxNumberCharacters = 2621440;

        // Content min number of characters
        public const int MinNumberCharacters = 3;

        // Content error message
        public const string ContentLenghtErrorMessage = "The area '{0}' must contains minimum {2} and maximum {1} characters.";
    }
}
