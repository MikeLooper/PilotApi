using System;
using System.Reflection;

namespace PilotApi.Web.Tests.TestDoubles
{
	internal class NoOpDispatchProxy : DispatchProxy
	{
		protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
		{
			if (targetMethod == null)
			{
				return null;
			}

			var returnType = targetMethod.ReturnType;
			if (returnType == typeof(void))
			{
				return null;
			}

			if (returnType == typeof(string))
			{
				return string.Empty;
			}

			if (returnType.IsValueType)
			{
				return Activator.CreateInstance(returnType);
			}

			return null;
		}
	}
}
