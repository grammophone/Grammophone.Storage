﻿using System;
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
		Task<Stream> OpenReadAsync();

		/// <summary>
		/// Open a stream for overwriting the file. Intended for large files.
		/// For smaller files, the <see cref="IStorageContainer.CreateFileAsync(string, string, Stream, bool)"/>
		/// with a non-null input stream is expected to be faster.
		/// </summary>
		/// <returns>Returns a task whose result is the stream.</returns>
		Task<Stream> OpenWriteAsync();

		/// <summary>
		/// Download the contents of a file to a stream.
		/// </summary>
		/// <returns>Returns a task completing the action.</returns>
		Task DownloadToStreamAsync(Stream stream);

		/// <summary>
		/// Save any changes made to <see cref="Metadata"/>.
		/// </summary>
		/// <returns>Returns a task completing the action.</returns>
		Task SaveMetadataAsync();
	}
}
