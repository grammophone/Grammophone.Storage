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
		/// The client which opened this container.
		/// </summary>
		IStorageClient Client { get; }

		/// <summary>
		/// The name of the container.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// The URI of the container.
		/// Whether it is publicly accessible, depends on the container's permissions.
		/// </summary>
		Uri URI { get; }

		/// <summary>
		/// Create an empty file. Use <see cref="IStorageFile.UploadFromStream(Stream, bool)"/>
		/// or <see cref="IStorageFile.OpenWrite(bool)"/> to write its contents.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <param name="contentType">The MIME content type of the file.</param>
		/// <param name="overwrite">If true, any existing file with the same name will be overwritten.</param>
		/// <returns>Returns a task whose result holds the file reference.</returns>
		IStorageFile CreateFile(string filename, string contentType, bool overwrite = true);

		/// <summary>
		/// Create an empty file asynchronously. Use <see cref="IStorageFile.UploadFromStreamAsync(Stream, bool)"/>
		/// or <see cref="IStorageFile.OpenWriteAsync(bool)"/> to write its contents.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <param name="contentType">The MIME content type of the file.</param>
		/// <param name="overwrite">If true, any existing file with the same name will be overwritten.</param>
		/// <returns>Returns a task whose result holds the file reference.</returns>
		Task<IStorageFile> CreateFileAsync(string filename, string contentType, bool overwrite = true);

		/// <summary>
		/// Checks whether a file exists.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is true if the file exists.</returns>
		bool FileExists(string filename);

		/// <summary>
		/// Checks whether a file exists asynchronously.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is true if the file exists.</returns>
		Task<bool> FileExistsAsync(string filename);

		/// <summary>
		/// Get an existing file.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is the file or null if it does not exit.</returns>
		IStorageFile GetFile(string filename);

		/// <summary>
		/// Get an existing file asynchronously.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is the file or null if it does not exit.</returns>
		Task<IStorageFile> GetFileAsync(string filename);

		/// <summary>
		/// Delete a file if it exists.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is true if the file existed and was deleted.</returns>
		bool DeleteFile(string filename);

		/// <summary>
		/// Delete a file if it exists asynchronously.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>Returns a task whose result is true if the file existed and was deleted.</returns>
		Task<bool> DeleteFileAsync(string filename);
	}
}
