using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BL
{
	public static class EnumHelper<T>
	{
		
		private static string lookupResource(Type resourceManagerProvider, string resourceKey)
		{
			foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
			{
				if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
				{
					System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
					return resourceManager.GetString(resourceKey);
				}
			}

			return resourceKey; // Fallback with the key name
		}

		/// <summary>
		/// get enum value
		/// </summary>
		/// <param name="value">enum vaue</param>
		/// <returns>display name</returns>
		public static string GetDisplayValue(T value)
		{
			var fieldInfo = value.GetType().GetField(value.ToString());

			var descriptionAttributes = fieldInfo.GetCustomAttributes(
				typeof(DisplayAttribute), false) as DisplayAttribute[];

			if (descriptionAttributes[0].ResourceType != null)
				return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

			if (descriptionAttributes == null) return string.Empty;
			return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
		}
	}
}
