// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.
#if !METRO && !NETSTANDARD1_3
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SunamoExceptions;

namespace HtmlAgilityPack
{
    public partial class HtmlNode
    {

        /// <summary>
        /// Fill an object and go through it's properties and fill them too.
        /// </summary>
        /// <typeparam name="T">Type of object to want to fill. It should have atleast one property that defined XPath.</typeparam>
        /// <param name="htmlDocument">If htmlDocument includes data , leave this parameter null. Else pass your specific htmldocument.</param>
        /// <returns>Returns an object of type T including Encapsulated data.</returns>
        public T GetEncapsulatedData<T>(HtmlDocument htmlDocument = null)
        {
            return (T)GetEncapsulatedData(typeof(T), htmlDocument);
        }
        /// <summary>
        /// Fill an object and go through it's properties and fill them too.
        /// </summary>
        /// <param name="targetType">Type of object to want to fill. It should have atleast one property that defined XPath.</param>
        /// <param name="htmlDocument">If htmlDocument includes data , leave this parameter null. Else pass your specific htmldocument.</param>
        /// <returns>Returns an object of type targetType including Encapsulated data.</returns>
        public object GetEncapsulatedData(Type targetType, HtmlDocument htmlDocument = null)
        {
            #region SettingPrerequisite
            if (targetType == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter targetType is null");
            }
            HtmlDocument source = null;
            if (htmlDocument == null)
            {
                source = OwnerDocument;
            }
            else
            {
                source = htmlDocument;
            }
            object targetObject = null;
            if (targetType.IsInstantiable() == false) // if it can not create instanse of T because of lack of constructor in type T.
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameterless Constructor excpected for " + targetType.FullName);
            }
            else
            {
                targetObject = Activator.CreateInstance(targetType);
            }
            #endregion SettingPrerequisite
            #region targetObject_Defined_XPath
            if (targetType.IsDefinedAttribute(typeof(HasXPathAttribute)) == true) // Object has xpath attribute (Defined HasXPath)
            {
                // Store list of properties that defined xpath attribute
                IEnumerable<PropertyInfo> validProperties = targetType.GetPropertiesDefinedXPath();
                if (validProperties.CountOfIEnumerable() == 0) // if no XPath property exist in type T while T defined HasXpath attribute.
                {
                    ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Type " + targetType.FullName +
                        " defined HasXPath Attribute but it does not have any property with XPath Attribte.");
                }
                else
                {
                    // Fill targetObject variable Properties ( T targetObject )
                    foreach (PropertyInfo propertyInfo in validProperties)
                    {
                        // Get xpath attribute from valid properties
                        // for .Net old versions:
                        XPathAttribute xPathAttribute = (propertyInfo.GetCustomAttributes(typeof(XPathAttribute), false) as IList)[0] as XPathAttribute;
                        #region Property_IsNOT_IEnumerable
                        if (propertyInfo.IsIEnumerable() == false) // Property is None-IEnumerable
                        {
                            HtmlNode htmlNode = null;
                            // try to fill htmlNode based on XPath given
                            try
                            {
                                htmlNode = source.DocumentNode.SelectSingleNode(xPathAttribute.XPath);
                            }
                            catch // if it can not select node based on given xpath
                            {
                                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Cannot find node with giving XPath to bind to " + propertyInfo.PropertyType.FullName + " " + propertyInfo.Name);
                            }
                            if (htmlNode == null)
                            {
                                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Cannot find node with givig XPath to bind to " +
                                    propertyInfo.PropertyType.FullName + " " + propertyInfo.Name);
                            }
                            #region Property_Is_HasXPath_UserDefinedClass
                            // Property is None-IEnumerable HasXPath-user-defined class
                            if (propertyInfo.PropertyType.IsDefinedAttribute(typeof(HasXPathAttribute)) == true)
                            {
                                HtmlDocument innerHtmlDocument = new HtmlDocument();
                                innerHtmlDocument.LoadHtml(htmlNode.InnerHtml);
                                object o = GetEncapsulatedData(propertyInfo.PropertyType, innerHtmlDocument);
                                propertyInfo.SetValue(targetObject, o, null);
                            }
                            #endregion Property_Is_HasXPath_UserDefinedClass
                            #region Property_Is_SimpleType
                            // Property is None-IEnumerable value-type or .Net class or user-defined class.
                            // AND does not deifned xpath and shouldn't have property that defined xpath.
                            else
                            {
                                string result = string.Empty;
                                if (xPathAttribute.AttributeName == null) // It target None-IEnumerable value of HTMLTag 
                                {
                                    result = Tools.GetNodeValueBasedOnXPathReturnType<string>(htmlNode, xPathAttribute);
                                }
                                else // It target None-IEnumerable attribute of HTMLTag
                                {
                                    result = htmlNode.GetAttributeValue(xPathAttribute.AttributeName, null);
                                }
                                if (result == null)
                                {
                                    ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can not find " +
                                        xPathAttribute.AttributeName + " Attribute in " + htmlNode.Name +
                                        " related to " + propertyInfo.PropertyType.FullName + " " + propertyInfo.Name);
                                }
                                object resultCastedToTargetPropertyType = null;
                                try
                                {
                                    resultCastedToTargetPropertyType = Convert.ChangeType(result, propertyInfo.PropertyType);
                                }
                                catch (FormatException)
                                {
                                    ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can not convert Invalid string to " + propertyInfo.PropertyType.FullName + " " + propertyInfo.Name);
                                }
                                catch (Exception ex)
                                {
                                    ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Unhandled Exception : " + ex.Message);
                                }
                                propertyInfo.SetValue(targetObject, resultCastedToTargetPropertyType, null);
                            }
                            #endregion Property_Is_SimpleType
                        }
                        #endregion Property_IsNOT_IEnumerable
                        #region Property_Is_IEnumerable
                        else // Property is IEnumerable<T>
                        {
                            IList<Type> T_Types = propertyInfo.GetGenericTypes() as IList<Type>; // Get T type
                            if (T_Types == null || T_Types.Count == 0)
                            {
                                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),propertyInfo.Name + " should have one generic argument.");
                            }
                            else if (T_Types.Count > 1)
                            {
                                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),propertyInfo.Name + " should have one generic argument.");
                            }
                            else if (T_Types.Count == 1) // It is NOT something like Dictionary<Tkey , Tvalue>
                            {
                                HtmlNodeCollection nodeCollection = null;
                                // try to fill nodeCollection based on given xpath.
                                try
                                {
                                    nodeCollection = source.DocumentNode.SelectNodes(xPathAttribute.XPath);
                                }
                                catch
                                {
                                    ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Cannot find node with givig XPath to bind to " + propertyInfo.PropertyType.FullName + " " + propertyInfo.Name);
                                }
                                if (nodeCollection == null || nodeCollection.Count == 0)
                                {
                                    ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Cannot find node with givig XPath to bind to " + propertyInfo.PropertyType.FullName + " " + propertyInfo.Name);
                                }
                                IList result = T_Types[0].CreateIListOfType();
                                #region Property_Is_IEnumerable<HasXPath-UserDefinedClass>
                                if (T_Types[0].IsDefinedAttribute(typeof(HasXPathAttribute)) == true) // T is IEnumerable HasXPath-user-defined class (T type Defined XPath properties)
                                {
                                    foreach (HtmlNode node in nodeCollection)
                                    {
                                        HtmlDocument innerHtmlDocument = new HtmlDocument();
                                        innerHtmlDocument.LoadHtml(node.InnerHtml);
                                        object o = GetEncapsulatedData(T_Types[0], innerHtmlDocument);
                                        result.Add(o);
                                    }
                                }
                                #endregion Property_Is_IEnumerable<HasXPath-UserDefinedClass>
                                #region Property_Is_IEnumerable<SimpleClass>
                                else // T is value-type or .Net class or user-defined class ( without xpath )
                                {
                                    if (xPathAttribute.AttributeName == null) // It target value
                                    {
                                        try
                                        {
                                            result = Tools.GetNodesValuesBasedOnXPathReturnType(nodeCollection, xPathAttribute, T_Types[0]);
                                        }
                                        catch (FormatException)
                                        {
                                            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can not convert Invalid string in node collection to " + T_Types[0].FullName + " " + propertyInfo.Name);
                                        }
                                        catch (Exception ex)
                                        {
                                            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Unhandled Exception : " + ex.Message);
                                        }
                                    }
                                    else // It target attribute
                                    {
                                        foreach (HtmlNode node in nodeCollection)
                                        {
                                            string nodeAttributeValue = node.GetAttributeValue(xPathAttribute.AttributeName, null);
                                            if (nodeAttributeValue == null)
                                            {
                                                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can not find " + xPathAttribute.AttributeName + " Attribute in " + node.Name + " related to " +
                                                propertyInfo.PropertyType.FullName + " " + propertyInfo.Name);
                                            }
                                            object resultCastedToTargetPropertyType = null;
                                            try
                                            {
                                                resultCastedToTargetPropertyType = Convert.ChangeType(nodeAttributeValue, T_Types[0]);
                                            }
                                            catch (FormatException) // if it can not cast result(string) to type of property.
                                            {
                                                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can not convert Invalid string to " + T_Types[0].FullName + " " + propertyInfo.Name);
                                            }
                                            catch (Exception ex)
                                            {
                                                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Unhandled Exception : " + ex.Message);
                                            }
                                            result.Add(resultCastedToTargetPropertyType);
                                        }
                                    }
                                }
                                #endregion Property_Is_IEnumerable<SimpleClass>
                                if (result == null || result.Count == 0)
                                {
                                    ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Cannot fill " + propertyInfo.PropertyType.FullName + " " + propertyInfo.Name + " because it is null.");
                                }
                                propertyInfo.SetValue(targetObject, result, null);
                            }
                        }
                        #endregion Property_IsNOT_IEnumerable
                    }
                    return targetObject;
                }
            }
            #endregion targetObject_Defined_XPath
            #region targetObject_NOTDefined_XPath
            else // Object doesen't have xpath attribute
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Type T must define HasXPath attribute and include properties with XPath attribute.");
            }
            #endregion targetObject_NOTDefined_XPath
            return null;
        }
    }
    /// <summary>
    /// Includes tools that GetEncapsulatedData method uses them.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Determine if a type define an attribute or not , supporting both .NetStandard and .NetFramework2.0
        /// </summary>
        /// <param name="type">Type you want to test it.</param>
        /// <param name="attributeType">Attribute that type must have or not.</param>
        /// <returns>If true , The type parameter define attributeType parameter.</returns>
        public static bool IsDefinedAttribute(this Type type, Type attributeType)
        {
            if (type == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter type is null when checking type defined attributeType or not.");
            }
            if (attributeType == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter attributeType is null when checking type defined attributeType or not.");
            }
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            if (type.IsDefined(attributeType, false) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
#endif
#if NETSTANDARD1_3 || NETSTANDARD1_6
            if (type.GetTypeInfo().IsDefined(attributeType) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
#endif
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can't Target any platform when checking " + type.FullName + " is a " + attributeType.FullName + " or not.");
        }
        /// <summary>
        /// Retrive properties of type that defined <see cref="XPathAttribute"/>.
        /// </summary>
        /// <param name="type">Type that you want to find it's XPath-Defined properties.</param>
        /// <returns>IEnumerable of property infos of a type , that defined specific attribute.</returns>
        public static IEnumerable<PropertyInfo> GetPropertiesDefinedXPath(this Type type)
        {
            if (type == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter type is null while retrieving properties defined XPathAttribute of Type type.");
            }
            PropertyInfo[] properties = null;
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            properties = type.GetProperties();
#endif
#if NETSTANDARD1_3 || NETSTANDARD1_6
            properties = type.GetTypeInfo().GetProperties();
#endif
            return properties.HAPWhere(x => x.IsDefined(typeof(XPathAttribute), false) == true);
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can't Target any platform while retrieving properties defined XPathAttribute of Type type.");
        }
        /// <summary>
        /// Determine if a <see cref="PropertyInfo"/> has implemented <see cref="IEnumerable"/> BUT <see cref="string"/> is considered as NONE-IEnumerable !
        /// </summary>
        /// <param name="propertyInfo">The property info you want to test.</param>
        /// <returns>True if property info is IEnumerable.</returns>
        public static bool IsIEnumerable(this PropertyInfo propertyInfo)
        {
            //return propertyInfo.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null;
            if (propertyInfo == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter propertyInfo is null while checking propertyInfo for being IEnumerable or not.");
            }
            if (propertyInfo.PropertyType == typeof(string))
            {
                return false;
            }
            else
            {
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
                return typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
#endif
#if NETSTANDARD1_3 || NETSTANDARD1_6
                return typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(propertyInfo.PropertyType);
#endif
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can't Target any platform while checking propertyInfo for being IEnumerable or not.");
            }
        }
        /// <summary>
        /// Returns T type(first generic type) of <see cref="IEnumerable{T}"/> or <see cref="List{T}"/>.
        /// </summary>
        /// <param name="propertyInfo">IEnumerable-Implemented property</param>
        /// <returns>List of generic types.</returns>
        public static IEnumerable<Type> GetGenericTypes(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter propertyInfo is null while Getting generic types of Property.");
            }
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            return propertyInfo.PropertyType.GetGenericArguments();
#endif
#if NETSTANDARD1_3 || NETSTANDARD1_6
            return propertyInfo.PropertyType.GetTypeInfo().GetGenericArguments();
#endif
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can't Target any platform while Getting generic types of Property.");
        }
        /// <summary>
        /// Find and Return a mehtod that defined in a class by it's name.
        /// </summary>
        /// <param name="type">Type of class include requested method.</param>
        /// <param name="methodName">Name of requested method as string.</param>
        /// <returns>Method info of requested method.</returns>
        public static MethodInfo GetMethodByItsName(this Type type, string methodName)
        {
            if (type == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter type is null while Getting method from it.");
            }
            if (methodName == null || methodName == "")
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter methodName is null while Getting method from Type type.");
            }
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            return type.GetMethod(methodName);
#endif
#if NETSTANDARD1_3 || NETSTANDARD1_6
            return type.GetTypeInfo().GetMethod(methodName);
#endif
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can't Target any platform while getting Method methodName from Type type.");
        }
        /// <summary>
        /// Create <see cref="IList"/> of given type.
        /// </summary>
        /// <param name="type">Type that you want to make a List of it.</param>
        /// <returns>Returns IList of given type.</returns>
        public static IList CreateIListOfType(this Type type)
        {
            if (type == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter type is null while creating List<type>.");
            }
            Type listType = typeof(List<>);
            Type constructedListType = listType.MakeGenericType(type);
            return Activator.CreateInstance(constructedListType) as IList;
        }
        /// <summary>
        /// Returns the part of value of <see cref="HtmlNode"/> you want as .
        /// </summary>
        /// <param name="htmlNode">A htmlNode instance.</param>
        /// <param name="xPathAttribute">Attribute that includes ReturnType</param>
        /// <returns>String that choosen from HtmlNode as result.</returns>
        public static T GetNodeValueBasedOnXPathReturnType<T>(HtmlNode htmlNode, XPathAttribute xPathAttribute)
        {
            if (htmlNode == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"parameter html node is null");
            }
            if (xPathAttribute == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"parameter xpathAttribute is null");
            }
            T result = default(T);
            Type TType = typeof(T);
            switch (xPathAttribute.NodeReturnType)
            {
                case ReturnType.InnerHtml:
                    {
                        result = (T)Convert.ChangeType(htmlNode.InnerHtml, TType);
                    }
                    break;
                case ReturnType.InnerText:
                    {
                        result = (T)Convert.ChangeType(htmlNode.InnerText, TType);
                    }
                    break;
                case ReturnType.OuterHtml:
                    {
                        result = (T)Convert.ChangeType(htmlNode.OuterHtml, TType);
                    }
                    break;
                default: 
                    ThrowExceptions.NotImplementedCase(Exc.GetStackTrace(), type, Exc.CallingMethod(), xPathAttribute.NodeReturnType.ToString());
                    break;
            }
            return (T)result;
        }

        static Type type = typeof(Tools);

        /// <summary>
        /// Returns parts of values of <see cref="HtmlNode"/> you want as <see cref="IList{T}"/>.
        /// </summary>
        /// <param name="htmlNodeCollection"><see cref="HtmlNodeCollection"/> that you want to retrive each <see cref="HtmlNode"/> value.</param>
        /// <param name="xPathAttribute">A <see cref="XPathAttribute"/> instnce incules <see cref="ReturnType"/>.</param>
        /// <param name="listGenericType">Type of IList generic you want.</param>
        public static IList GetNodesValuesBasedOnXPathReturnType(HtmlNodeCollection htmlNodeCollection, XPathAttribute xPathAttribute, Type listGenericType)
        {
            if (htmlNodeCollection == null || htmlNodeCollection.Count == 0)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"parameter htmlNodeCollection is null or empty.");
            }
            if (xPathAttribute == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"parameter xpathAttribute is null");
            }
            IList result = listGenericType.CreateIListOfType();
            switch (xPathAttribute.NodeReturnType)
            {
                case ReturnType.InnerHtml:
                    {
                        foreach (HtmlNode node in htmlNodeCollection)
                        {
                            result.Add(Convert.ChangeType(node.InnerHtml, listGenericType));
                        }
                    }
                    break;
                case ReturnType.InnerText:
                    {
                        foreach (HtmlNode node in htmlNodeCollection)
                        {
                            result.Add(Convert.ChangeType(node.InnerText, listGenericType));
                        }
                    }
                    break;
                case ReturnType.OuterHtml:
                    {
                        foreach (HtmlNode node in htmlNodeCollection)
                        {
                            result.Add(Convert.ChangeType(node.OuterHtml, listGenericType));
                        }
                    }
                    break;
            }
            return result;
        }
        /// <summary>
        /// Simulate Func method to use in Lambada Expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="arg"></param>
        public delegate TResult HAPFunc<T, TResult>(T arg);
        /// <summary>
        /// This method works like Where method in LINQ.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        public static IEnumerable<TSource> HAPWhere<TSource>(this IEnumerable<TSource> source, HAPFunc<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        /// <summary>
        /// Check if the type can instantiated.
        /// </summary>
        /// <param name="type"></param>
        public static bool IsInstantiable(this Type type)
        {
            if (type == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"type is null");
            }
#if !(NETSTANDARD1_3 || NETSTANDARD1_6)
            // checking for having parameterless constructor.
            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
#endif
#if NETSTANDARD1_3 || NETSTANDARD1_6
            // checking for having parameterless constructor.
            if (type.GetTypeInfo().DeclaredConstructors.HAPWhere(x => x.GetParameters().Length == 0).CountOfIEnumerable() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
#endif
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can't Target any platform while getting Method methodName from Type type.");
        }
        /// <summary>
        /// Returns count of elements stored in IEnumerable of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static int CountOfIEnumerable<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Parameter source is null while counting the IEnumerable");
            }
            int counter = 0;
            foreach (T item in source)
            {
                counter++;
            }
            return counter;
        }
    }
    /// <summary>
    /// Specify which part of <see cref="HtmlNode"/> is requested.
    /// </summary>
    public enum ReturnType
    {
        InnerText,
        InnerHtml,
        OuterHtml
    }
    /// <summary>
    /// Just mark and flag classes to show they have properties that defined <see cref="XPathAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class HasXPathAttribute : Attribute
    {
    }
    /// <summary>
    /// Includes XPath and <see cref="NodeReturnType"/>. XPath for finding html tags and <see cref="NodeReturnType"/> for specify which part of <see cref="HtmlNode"/> you want to return.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class XPathAttribute : Attribute
    {
        public string XPath { get; }
        public string AttributeName { get; set; }
        public ReturnType NodeReturnType { get; set; }
        public XPathAttribute(string xpathString, ReturnType nodeReturnType = ReturnType.InnerText)
        {
            XPath = xpathString;
            NodeReturnType = nodeReturnType;
        }
        public XPathAttribute(string xpathString, string attributeName)
        {
            XPath = xpathString;
            AttributeName = attributeName;
        }
    }
    public class NodeNotFoundException : Exception
    {
        public NodeNotFoundException() { }
        public NodeNotFoundException(string message) : base(message) { }
        public NodeNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
    public class NodeAttributeNotFoundException : Exception
    {
        public NodeAttributeNotFoundException() { }
        public NodeAttributeNotFoundException(string message) : base(message) { }
        public NodeAttributeNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
    public class MissingXPathException : Exception
    {
        public MissingXPathException() { }
        public MissingXPathException(string message) : base(message) { }
        public MissingXPathException(string message, Exception inner) : base(message, inner) { }
    }
}
#if FX20 
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method |
    AttributeTargets.Class | AttributeTargets.Assembly)]
    public sealed class ExtensionAttribute : Attribute
    {
    }
}
#endif
#endif
