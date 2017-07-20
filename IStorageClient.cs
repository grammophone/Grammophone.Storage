using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Storage
{
	/// <summary>
	/// A client for accessing <see cref="IStorageContainer"/>s.
	/// </summary>
	public interface IStorageClient
	{
		/// <summary>
		/// The provider of this client.
		/// </summary>
		IStorageProvider Provider { get; }

		/// <summary>
		/// Get a reference to a container.
		/// </summary>
		/// <param name="containerName">The name of the container.</param>
		/// <returns>
		/// Returns a task whose result holds the container or null of the container doesn't exist.
		/// </returns>
		IStorageContainer GetContainer(string containerName);

		/// <summary>
		/// Get a reference to a container asynchronously.
		/// </summary>
		/// <param name="containerName">The name of the container.</param>
		/// <returns>
		/// Returns a task whose result holds the container or null of the container doesn't exist.
		/// </returns>
		Task<IStorageContainer> GetContainerAsync(string containerName);
	}
}
