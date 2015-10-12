using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Reflection<T>
    {
        /// <summary>
        /// Uses reflection to get the Property value from an object.
        /// </summary>
        ///
        /// <param name="type">The instance type.</param>
        /// <param name="instance">The instance object.</param>
        /// <param name="fieldName">The Property's name which is to be fetched.</param>
        ///
        /// <returns>The Property value from the object.</returns>
        internal static T GetInstanceProperty(object instance, string propertyName)
        {
            var bindFlags = GetBinding();
            var field = instance.GetType().GetProperty(propertyName, bindFlags);
            return (T)field.GetValue(instance, null);
        }

        /// <summary>
        /// Uses reflection to get the field value from an object.
        /// </summary>
        ///
        /// <param name="type">The instance type.</param>
        /// <param name="instance">The instance object.</param>
        /// <param name="fieldName">The field's name which is to be fetched.</param>
        ///
        /// <returns>The field value from the object.</returns>
        internal static T GetInstanceField(object instance, string fieldName)
        {
            var bindFlags = GetBinding();
            var type = instance.GetType();
            var field = type.GetField(fieldName, bindFlags);
            return (T)field.GetValue(instance);
        }


        private static BindingFlags GetBinding()
        {
            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static;
            return bindFlags;
        }

        /// <summary>
        /// Uses reflection to get the create instance Expression Lambda from a Type
        /// The best performance >= 3 params
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        internal static T CreateInstanceDefaultExpressionLambda(Type instance)
        {
            return Expression.Lambda<Func<T>>(Expression.New(instance.GetConstructor(Type.EmptyTypes))).Compile().Invoke();
        }


        /// <summary>
        /// Uses reflection to get the create instance constructor from a Type
        /// The best performance >= 3 params
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        internal static T CreateInstanceConstructor(Type instance)
        {
            return (T) instance.GetConstructor(Type.EmptyTypes).Invoke(new object[] { });
        }


        /// <summary>
        /// Uses reflection to get the create instance constructor from a Type with arguments
        /// The best performance >= 3 params
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        internal static T CreateInstanceConstructor(Type instance, Type[] typesObject, object[] obj)
        {
            return (T)instance.GetConstructor(typesObject).Invoke(obj);
        }
       
            
        /// <summary>
        /// Uses reflection to get the create instance from a Type with arguments
        /// The best performance with less 2 params.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        internal static T CreateActivatorInstance(Type instance, object[] obj)
        {
            return (T) Activator.CreateInstance(instance, obj);
        }

        /// <summary>
        /// Uses reflection to get the create instance from a Type.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        internal static T CreateActivatorInstance(Type instance)
        {
            return (T)Reflection<T>.CreateActivatorInstance(instance, new object[] { });
        }


        /// <summary>
        /// Uses reflection to get the create instance from a namespace.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        internal static T CreateActivatorInstance(String _namespace)
        {
            return (T)Reflection<T>.CreateActivatorInstance(Type.GetType(_namespace), new object[] { });
        }
    }
}
