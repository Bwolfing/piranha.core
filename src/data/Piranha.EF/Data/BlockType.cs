﻿/*
 * Copyright (c) 2016 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using System;
using System.Collections.Generic;

namespace Piranha.EF.Data
{
    public sealed class BlockType : ICreated, IModified
    {
        #region Properties
        /// <summary>
        /// Gets/sets the unique id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets/sets the JSON serialized body of the page type.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets/sets the created date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets/sets the last modification date.
        /// </summary>
        public DateTime LastModified { get; set; }
        #endregion

        #region Navigation properties
        /// <summary>
        /// Gets/sets the pages of this type.
        /// </summary>
        public IList<Block> Blocks { get; set; }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlockType() {
            Blocks = new List<Block>();
        }
    }
}
