using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Storage
{
	/// <summary>
	/// Represents a storage container.
	/// </summary>
	public interface IStorageContainer
	{
		/// <summary>
		/// The name of the container.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// The URI of the file.
		/// Whether it is publicly accessible, depends on the container's permissions.
		/// </summary>
		Uri URI { get; }

		/// <summary>
		/// Create a file.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <param name="contentType">The MIME content type of the file.</param>
		/// <param name="stream">The input stream providing the contents of the file or null for empty file.</param>
		/// <param name="overwrite">If true, any existing file with the same name will be overwritten.</param>
		/// <returns>Returns a task whose result holds the file reference.</returns>
		Task<IStorageFile> CreateFileAsync(string filename, string contentType, Stream stream = null, bool overwrite = true);

		/// <summary>
		/// Checks whether a file exists.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is true if the file exists.</returns>
		Task<bool> FileExistsAsync(string filename);

		/// <summary>
		/// Get an axisting file.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is the file or null if ot does not exit.</returns>
		Task<IStorageFile> GetFileAsync(string filename);

		/// <summary>
		/// Delete a file if it exists.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is true if the file existed and was deleted.</returns>
		Task<bool> DeleteFileAsync(string filename);
	}
}
