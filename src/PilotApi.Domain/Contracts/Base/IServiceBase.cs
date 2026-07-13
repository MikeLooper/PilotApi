using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotApi.Domain.Contracts.Base
{
	public interface IServiceBase<T> where T : IDtoBase
	{
		Task<bool> DeleteAsync(int id);

		Task<IEnumerable<T>?> GetAllAsync();

		Task<T?> GetAsync(int id);

		Task<int> InsertAsync(T model);

		Task<IEnumerable<T>?> QueryAsync(string query, object? parameters = null);

		Task<T?> QueryFirstAsync(string query, object? parameters = null);

		Task<T?> QuerySingleAsync(string query, object? parameters = null);

		Task<bool> UpdateAsync(T model);
	}
}
