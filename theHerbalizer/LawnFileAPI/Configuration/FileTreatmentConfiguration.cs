namespace LawnFile.API.Configuration
{
    /// <summary>
    /// Class FileTreatmentConfiguration.
    /// </summary>
    public class FileTreatmentConfiguration
    {
        /// <summary>
        /// Gets or sets the temporary file directory path.
        /// </summary>
        /// <value>The temporary file directory path.</value>
        public string TemporaryFileDirectoryPath { get; set; }

        /// <summary>
        /// Gets or sets the name of the output file.
        /// </summary>
        /// <value>The name of the output file.</value>
        public string OutputFileName { get; set; }
    }
}