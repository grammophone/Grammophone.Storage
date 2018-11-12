# Grammophone.Storage
This .NET framework library sets a contract to abstract a file storage system.
The specific adaptations must implement the `IStorageProvider` interface and the interfaces following from its methods:

<table>
<tbody>
<tr>
<td>
<strong>IStorageProvider</strong>
</td>
<td>
Root contract for handling files of a storage system.
Used to obtain <strong>IStorageClient</strong>s.
Implementations must be thread-safe.
</td>
</tr>
<tr>
<td>
<strong>IStorageClient</strong>
</td>
<td>
A client for accessing <strong>IStorageContainer</strong>s.
</td>
</tr>
<tr>
<td>
<strong>IStorageContainer</strong>
</td>
<td>
Represents a storage container in which <strong>IStorageFile</strong>s can be read or written.
</td>
</tr>
<tr>
<td>
<strong>IStorageFile</strong>
</td>
<td>
Represents a file in a <strong>IStorageContainer</strong>.
</td>
</tr>
</tbody>
</table>

Use your preferred dependency injection framework to obtain a singleton `IStorageProvider` instance. The project
[Grammophone.Storage.Azure](https://github.com/grammophone/Grammophone.Storage.Azure) provides an implementation for Azure blob storage.

This library has no dependencies.
