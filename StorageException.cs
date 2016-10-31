using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Storage
{
	/// <summary>
	/// Exception for the storage system.
	/// </summary>
	[Serializable]
	public class StorageException : SystemException
	{
		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="message">The exception message.</param>
		public StorageException(string message) : base(message) { }

		/// <summary>
		/// The 
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="inner">The inner cause of the exception.</param>
		public StorageException(string message, Exception inner) : base(message, inner) { }

		/// <summary>
		/// Used for serialization.
		/// </summary>
		protected StorageException(
		System.Runtime.Serialization.SerializationInfo info,
		System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
