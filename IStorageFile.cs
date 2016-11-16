using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Storage
{
	/// <summary>
	/// Represents a file in a <see cref="IStorageContainer"/>.
	/// </summary>
	public interface IStorageFile
	{
		/// <summary>
		/// The name of the file.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// The URI of the file.
		/// Whether it is publicly accessible, depends on the <see cref="Container"/>'s permissions.
		/// </summary>
		Uri URI { get; }

		/// <summary>
		/// The content type of the file.
		/// </summary>
		string ContentType { get; }

		/// <summary>
		/// The last modification date of the file.
		/// </summary>
		DateTimeOffset LastModificationDate { get; }

		/// <summary>
		/// User-defined metadata.
		/// </summary>
		IDictionary<string, string> Metadata { get; }

		/// <summary>
		/// The container of the file.
		/// </summary>
		IStorageContainer Container { get; }

		/// <summary>
		/// Open a stream for reading the file.
		/// </summary>
		/// <returns>Returns a task whose result is the stream.</returns>
		/// <remarks>
		/// If the file is encrypted, it will be transparently decrypted 
		/// according to the storage provider settings.
		/// </remarks>
		Task<Stream> OpenReadAsync();

		/// <summary>
		/// Open a stream for overwriting the file. Intended for large files.
		/// For smaller files, the <see cref="UploadFromStreamAsync(Stream, bool)"/>
		/// method is expected to be faster.
		/// </summary>
		/// <param name="encrypt">
		/// If true, encrypt the file contents according to the storage provider settings.
		/// </param>
		/// <returns>Returns a task whose result is the stream.</returns>
		Task<Stream> OpenWriteAsync(bool encrypt);

		/// <summary>
		/// Download the contents of a file to a stream.
		/// </summary>
		/// <param name="stream">The output stream receiving the file contents.</param>
		/// <returns>Returns a task completing the action.</returns>
		/// <remarks>
		/// If the file is encrypted, it will be transparently decrypted 
		/// according to the storage provider settings.
		/// </remarks>
		Task DownloadToStreamAsync(Stream stream);

		/// <summary>
		/// Overwrite the file using the contents of a <paramref name="stream"/>.
		/// </summary>
		/// <param name="stream">The input stream providing the file contents.</param>
		/// <param name="encrypt">
		/// If true, encrypt the file contents according to the storage provider settings.
		/// </param>
		/// <returns>Returns a task completing the action.</returns>
		Task UploadFromStreamAsync(Stream stream, bool encrypt);

		/// <summary>
		/// Save any changes made to <see cref="Metadata"/>.
		/// </summary>
		/// <returns>Returns a task completing the action.</returns>
		Task SaveMetadataAsync();
	}
}
