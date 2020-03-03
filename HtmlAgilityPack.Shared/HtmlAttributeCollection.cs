// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://www.zzzprojects.com/
// Copyright � ZZZ Projects Inc. 2014 - 2017. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents a combined list and collection of HTML nodes.
    /// </summary>
    public class HtmlAttributeCollection : IList<HtmlAttribute>
    {
        #region Fields

        public Dictionary<string, HtmlAttribute> Hashitems = new Dictionary<string, HtmlAttribute>(StringComparer.OrdinalIgnoreCase);
        private HtmlNode _ownernode;
        private List<HtmlAttribute> items = new List<HtmlAttribute>();

        #endregion

        #region Constructors

        public HtmlAttributeCollection(HtmlNode ownernode)
        {
            _ownernode = ownernode;
        }

        #endregion


        #region IList<HtmlAttribute> Members

        /// <summary>
        /// Gets the number of elements actually contained in the list.
        /// </summary>
        public int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// Gets readonly status of colelction
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the attribute at the specified index.
        /// </summary>
        public HtmlAttribute this[int index]
        {
            get { return items[index]; }
            set
            {
                var oldValue = items[index];
               
                items[index] = value;

                if (oldValue.Name != value.Name)
                {
                    Hashitems.Remove(oldValue.Name);
                }
                Hashitems[value.Name] = value;

                value._ownernode = _ownernode;
                _ownernode.SetChanged();
            }
        }


        /// <summary>
        /// Gets a given attribute from the list using its name.
        /// </summary>
        public HtmlAttribute this[string name]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException("name");
                }

                HtmlAttribute value;
                return Hashitems.TryGetValue(name, out value) ? value : null;
            }
            set
            {
                HtmlAttribute currentValue;

                if (!Hashitems.TryGetValue(name, out currentValue))
                {
                    Append(value);
                }

                this[items.IndexOf(currentValue)] = value;
            }
        }


        /// <summary>
        /// Adds a new attribute to the collection with the given values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, string value)
        {
            Append(name, value);
        }


        /// <summary>
        /// Adds supplied item to collection
        /// </summary>
        /// <param name="item"></param>
        public void Add(HtmlAttribute item)
        {
            Append(item);
        }

        /// <summary>Adds a range supplied items to collection.</summary>
        /// <param name="items">An IEnumerable&lt;HtmlAttribute&gt; of items to append to this.</param>
        public void AddRange(IEnumerable<HtmlAttribute> items)
	    {
		    foreach (var item in items)
		    { 
				Append(item);
			}
	    }

        /// <summary>Adds a range supplied items to collection using a dictionary.</summary>
        /// <param name="items">A Dictionary&lt;string,string&gt; of items to append to this.</param>
        public void AddRange(Dictionary<string, string> items)
	    {
		    foreach (var item in items)
            {
                Add(item.Key, item.Value);
            }
	    }

		/// <summary>
		/// Explicit clear
		/// </summary>
		void ICollection<HtmlAttribute>.Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Retreives existence of supplied item
        /// </summary>
        /// <param name="item"></param>
        
        public IEnumerable<HtmlAttribute> AttributesWithName(string attributeName)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (String.Equals(items[i].Name, attributeName, StringComparison.OrdinalIgnoreCase))
                    yield return items[i];
            }
        }

        /// <summary>
        /// Removes all attributes from the collection
        /// </summary>
        public void Remove()
        {
            items.Clear();
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Clears the attribute collection
        /// </summary>
        public void Clear()
        {
            Hashitems.Clear();
            items.Clear();
        }

        public int GetAttributeIndex(HtmlAttribute attribute)
        {
            if (attribute == null)
            {
                throw new ArgumentNullException("attribute");
            }

            for (int i = 0; i < items.Count; i++)
            {
                if ((items[i]) == attribute)
                    return i;
            }

            return -1;
        }

        public int GetAttributeIndex(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (String.Equals((items[i]).Name, name, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            return -1;
        }

        #endregion
    }
}