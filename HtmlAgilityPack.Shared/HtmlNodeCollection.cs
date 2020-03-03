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
    public class HtmlNodeCollection : IList<HtmlNode>
    {
        #region Fields

        private readonly HtmlNode _parentnode;
        private readonly List<HtmlNode> _items = new List<HtmlNode>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize the HtmlNodeCollection with the base parent node
        /// </summary>
        /// <param name="parentnode">The base node of the collection</param>
        public HtmlNodeCollection(HtmlNode parentnode)
        {
            _parentnode = parentnode; // may be null
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a given node from the list.
        /// </summary>
        public int this[HtmlNode node]
        {
            get
            {
                int index = GetNodeIndex(node);
                if (index == -1)
                    throw new ArgumentOutOfRangeException("node",
                        "Node \"" + node.CloneNode(false).OuterHtml +
                        "\" was not found in the collection");
                return index;
            }
        }

        /// <summary>
        /// Get node with tag name
        /// </summary>
        /// <param name="nodeName"></param>
        
        public IEnumerable<HtmlNode> Nodes()
        {
            foreach (HtmlNode item in _items)
            foreach (HtmlNode n in item.ChildNodes)
                yield return n;
        }

        #endregion
    }
}