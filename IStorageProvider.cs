using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Storage
{
	/// <summary>
	/// Root contract for handling files of a storage system.
	/// The implementations must be thread-safe.
	/// </summary>
	public interface IStorageProvider
	{
		/// <summary>
		/// The base URL of the files provided.
		/// </summary>
		string URLBase { get; }

		/// <summary>
		/// Get a client for file operations.
		/// </summary>
		IStorageClient GetClient();
	}
}
