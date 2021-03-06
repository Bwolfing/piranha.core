﻿/*
 * Copyright (c) 2016 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using Microsoft.EntityFrameworkCore;
using System;
using Piranha.Repositories;

namespace Piranha.EF
{
    public sealed class DataService : IDataService
    {
        #region Members
        /// <summary>
        /// The private db context.
        /// </summary>
        private readonly Db db;

        /// <summary>
        /// The private storage manager.
        /// </summary>
        private readonly IStorage storage;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the archive repository.
        /// </summary>
        public IArchiveRepository Archives { get; private set; }

        /// <summary>
        /// Gets the block type repository.
        /// </summary>
        public IBlockTypeRepository BlockTypes { get; private set; }

        /// <summary>
        /// Gets the category repository.
        /// </summary>
        public ICategoryRepository Categories { get; private set; }

        /// <summary>
        /// Gets the media repository.
        /// </summary>
        public IMediaRepository Media { get; private set; }

        /// <summary>
        /// Gets the media folder repository.
        /// </summary>
        public IMediaFolderRepository MediaFolders { get; private set; }

        /// <summary>
        /// Gets the page repository.
        /// </summary>
        public IPageRepository Pages { get; private set; }

        /// <summary>
        /// Gets the page type repository.
        /// </summary>
        public IPageTypeRepository PageTypes { get; private set; }

        /// <summary>
        /// Gets the post repository.
        /// </summary>
        public IPostRepository Posts { get; private set; }

        /// <summary>
        /// Gets the sitemap repository.
        /// </summary>
        public ISitemapRepository Sitemap { get; private set; }
        #endregion

        /// <summary>
        /// Default constructor. Creates a new Entity Framework Api object.
        /// </summary>
        /// <param name="storage">The currently registered storage manager</param>
        public DataService(IStorage storage) {
            var builder = new DbContextOptionsBuilder<Db>();
            Module.DbConfig(builder);
            this.db = new Db(builder.Options);
            this.storage = storage;

            Archives = new Repositories.ArchiveRepository(db);
            BlockTypes = new Repositories.BlockTypeRepository(db);
            Categories = new Repositories.CategoryRepository(db);
            Media = new Repositories.MediaRepository(db, storage);
            MediaFolders = new Repositories.MediaFolderRepository(db);
            Pages = new Repositories.PageRepository(this, db);
            PageTypes = new Repositories.PageTypeRepository(db);
            Posts = new Repositories.PostRepository(db);
            Sitemap = new Repositories.SitemapRepository(db);
        }

        /// <summary>
        /// Disposes the Api.
        /// </summary>
        public void Dispose() {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
